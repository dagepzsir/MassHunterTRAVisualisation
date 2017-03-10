using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.ListView;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public List<TRAData> LoadedData = new List<TRAData>();
        public int ElementCount;
        public string LoadedBatchPath;
        DataTable loadedFiles = new DataTable();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ResetData();
                LoadBatch(folderBrowserDialog1.SelectedPath);
            }
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm();
            if (optionsForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadedData.ForEach(item => item.RefreshSeriesColor());
            }
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> datafiles = Directory.EnumerateDirectories(LoadedBatchPath, "*.d").ToList();
            foreach (TRAData data in LoadedData)
            {
                datafiles.Remove(data.FilePath);
            }
            foreach (string filepath in datafiles)
            {
                LoadBatchData(filepath);
            }
        }

        private void chart1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                ResetData();
                LoadedBatchPath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                LoadBatch(LoadedBatchPath);
            }
        }
        private void chart1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            float perctangleX = e.X * 100 / traChart.Width;
            ChartArea clickedChart = traChart.ChartAreas.ToList().Find(item => item.Position.X <= perctangleX && item.Position.Right >= perctangleX);
            var asd = listView1.FindItemWithText(clickedChart.Name);
            listView1.Select();
            asd.Selected = true;
        }

        private void ResetData()
        {
            LoadedData = new List<TRAData>();
            traChart.ChartAreas.Clear();
            traChart.Series.Clear();
            listView1.Clear();
        }
        private void LoadBatch(string folderpath)
        {
            if (folderpath.Contains(".b"))
            {
                List<string> datafiles = Directory.EnumerateDirectories(folderpath, "*.d").ToList();

                XElement acqMethod = XElement.Load(Path.Combine(folderpath, "Method", "AcqMethod.xml"));
                string xmlns = "{Acquisition}";
                var elements = from element in acqMethod.Elements(xmlns + "IcpmsElement")
                               select element;
                int colorCount = Utils.GetColorsFromSettings().Count;
                ElementCount = elements.Count();

                if (ElementCount > colorCount)
                {
                    MessageBox.Show(string.Format("Not enough color is selected, please select {0} more", ElementCount - colorCount), "Not enough color!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    OptionsForm optionForm = new OptionsForm();
                    optionForm.ShowDialog(this);
                }

                foreach (string filename in datafiles)
                {
                    LoadBatchData(filename);
                }
                //Set legend
                foreach (Series series in LoadedData[0].DataSeries)
                {
                    series.IsVisibleInLegend = true;
                    series.LegendText = series.Name.Split('_')[0];
                }
                refreshButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Selected folder is not a valid ICP-MS Batch folder!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadBatchData(string batchpath)
        {
            //Construct file path
            string datafile = Path.GetFileNameWithoutExtension(batchpath) + ".csv";
            string finalPath = Path.Combine(batchpath, datafile);
            if (File.Exists(finalPath))
            {
                //Load sample information from XML
                string sampleInfoPath = Path.Combine(batchpath, "AcqData", "sample_info.xml");
                XDocument sampleInfo = XDocument.Load(sampleInfoPath);
                var fields = from field in sampleInfo.Descendants("Name")
                             where field.Value == "Sample Name"
                             select field.Parent;
                string sampleName = fields.ElementAt(0).Descendants("Value").ElementAt(0).Value;

                //Load file
                TRAData currentData = TRAData.LoadCSVFile(finalPath);
                currentData.SampleName = sampleName;
                double timeStep = currentData.Time[1] - currentData.Time[0];
                AddChartArea(Path.GetFileNameWithoutExtension(datafile), 400, timeStep);
                LoadedData.Add(currentData);

                if (listView1.Columns.Count == 0)
                {
                    listView1.Columns.Add("Data File");
                    listView1.Columns.Add("Sample Name");
                }
                listView1.Items.Add(new ListViewItem(new string[] { traChart.ChartAreas.Last().Name, sampleName }));
                traChart.ChartAreas.Last().AxisX.Title += " - " + sampleName;

                foreach (Series series in currentData.DataSeries)
                {
                    series.ChartArea = traChart.ChartAreas.Last().Name;
                    traChart.Series.Add(series);
                }
            }
        }

        private void AddChartArea(string areaname, int areawith, double timestep)
        {
            ChartArea newArea = new ChartArea(areaname);

            //Turn off automatic shit on ChartAreas
            newArea.CursorX.IsUserSelectionEnabled = true;
            newArea.AxisX.ScaleView.Zoomable = false;
            newArea.AlignmentStyle = AreaAlignmentStyles.PlotPosition;
            newArea.AlignmentOrientation = AreaAlignmentOrientations.Horizontal;
            newArea.AxisY.MajorTickMark.Enabled = false;
            newArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            newArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            newArea.Position.Auto = false;
            newArea.InnerPlotPosition = new ElementPosition(20, 5, 80, 85);
            newArea.AxisX.Title = areaname;
            newArea.CursorX.Interval = timestep;
            newArea.CursorX.Interval = 0.15;
            if (traChart.ChartAreas.Count == 0)
            {
                newArea.Position = new ElementPosition(0, 0, areaWithPerctangle(areawith), 100);
            }
            else
            {
                //Resize Chart object
                if (traChart.Width <= traChart.ChartAreas.Count * areawith)
                    traChart.Width += areawith;

                //Recalculate existing ChartArea positions
                traChart.ChartAreas[0].Position.Width = areaWithPerctangle(areawith);
                traChart.ChartAreas[0].Position.X = 0;
                for (int i = 1; i < traChart.ChartAreas.Count; i++)
                {
                    traChart.ChartAreas[i].Position.Width = areaWithPerctangle(areawith);
                    traChart.ChartAreas[i].Position.X = traChart.ChartAreas[i - 1].Position.Right;
                }

                //Calculate the new ChartArea position
                ChartArea previousArea = traChart.ChartAreas[traChart.ChartAreas.Count - 1];
                newArea.Position = new ElementPosition(previousArea.Position.Right, 0, areaWithPerctangle(areawith), 100);
            }
            traChart.ChartAreas.Add(newArea);
        }
        private double maxYAxisValue()
        {
            double max = 0;
            foreach (ChartArea area in traChart.ChartAreas)
            {
                if (area.AxisY.Maximum > max)
                    max = area.AxisY.Maximum;
            }
            return max;
        }
        private float areaWithPerctangle(int targetWidth)
        {
            int percent100 = traChart.Width;
            return targetWidth * 100 / (float)percent100;
        }


        private void traChart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                foreach (ChartArea area in traChart.ChartAreas)
                {
                    if (area.CursorX.SelectionStart.ToString() != double.NaN.ToString())
                    {
                        area.AxisX.ScaleView.Zoom(area.CursorX.SelectionStart, area.CursorX.SelectionEnd);
                        TRAData changed = LoadedData.Find(item => Path.GetFileNameWithoutExtension(item.FilePath) == area.Name);
                        changed.SelectionEnd = area.CursorX.SelectionEnd;
                        changed.SelectionStart = area.CursorX.SelectionStart;
                    }
                }
            }
        }

        private void traChart_AxisViewChanged(object sender, ViewEventArgs e)
        {
            TRAData changed = LoadedData.Find(item => Path.GetFileNameWithoutExtension(item.FilePath) == e.ChartArea.Name);
            changed.SelectionEnd = e.ChartArea.CursorX.SelectionEnd;
            changed.SelectionStart = e.ChartArea.CursorX.SelectionStart;
        }
        private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            //Select on every diagram
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                if (traChart.ChartAreas.FindByName(item.Text).CursorX.SelectionStart != e.NewSelectionStart && traChart.ChartAreas.FindByName(item.Text).CursorX.SelectionEnd != e.NewSelectionEnd)
                {
                    traChart.ChartAreas.FindByName(item.Text).CursorX.SelectionStart = e.NewSelectionStart;
                    traChart.ChartAreas.FindByName(item.Text).CursorX.SelectionEnd = e.NewSelectionEnd;
                }
            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAnalysisDataTable(listView1.SelectedItems);
        }

        private void UpdateAnalysisDataTable(SelectedListViewItemCollection items)
        {
            if (items.Count > 0)
            {
                List<TRAData> selected = new List<TRAData>();

                foreach (ListViewItem item in items)
                {
                    selected.Add(LoadedData.Find(item2 => Path.GetFileNameWithoutExtension(item2.FilePath) == item.Text));
                }
                DataTable finalTable = new DataTable();
                finalTable = selected[0].Analysis();
                for (int i = 1; i < selected.Count; i++)
                {
                    finalTable.Merge(selected[i].Analysis());
                }
                selectedChartInfoTable.DataSource = finalTable;
            }
        }


    }
}