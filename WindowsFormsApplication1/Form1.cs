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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<TRAData> LoadedData = new List<TRAData>();
        DataTable loadedFiles = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            loadedFiles.Columns.Add("Data file");
            loadedFiles.Columns.Add("Sample Name");
            loadedFiles.Columns.Add("Data file");
            loadedFiles.Columns.Add("Comment");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadBatch(folderBrowserDialog1.SelectedPath);
            }
        }
        private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            //Select on every diagram
            /*foreach (ChartArea area in chart1.ChartAreas)
            {
                if(area != e.ChartArea)
                if (area.CursorX.SelectionStart != e.NewSelectionStart && area.CursorX.SelectionEnd != e.NewSelectionEnd)
                {
                    area.CursorX.SelectionStart = e.NewSelectionStart;
                    area.CursorX.SelectionEnd = e.NewSelectionEnd;
                    area.RecalculateAxesScale();
                }
            }*/
        }
        private void chart1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                LoadBatch(path);
            }
        }
        private void chart1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void LoadBatch(string folderpath)
        {
            if (folderpath.Contains(".b"))
            {
                List<string> datafiles = Directory.EnumerateDirectories(folderpath, "*.d").ToList();
                foreach (string filename in datafiles)
                {
                    //Construct file path
                    string datafile = Path.GetFileNameWithoutExtension(filename) + ".csv";
                    string finalPath = Path.Combine(filename, datafile);
                    if (File.Exists(finalPath))
                    {
                        //Load file
                        TRAData currentData = TRAData.LoadCSVFile(finalPath);
                        AddChartArea(Path.GetFileNameWithoutExtension(datafile), 400);
                        LoadedData.Add(currentData);

                        foreach (Series series in currentData.DataSeries)
                        {
                            series.ChartArea = chart1.ChartAreas.Last().Name;
                            chart1.Series.Add(series);
                        }
                    }

                    string sampleInfoPath = Path.Combine(filename, "AcqData", "sample_info.xml");
                    XmlDocument sampleInfo = new XmlDocument();
                    sampleInfo.Load(sampleInfoPath);
                    XmlNodeList nodes = sampleInfo.SelectNodes("SampleInfo/Field");
                    foreach (XmlNode node in nodes)
                    {
                        
                    }

                }
                //Set legend
                foreach (Series series in LoadedData[0].DataSeries)
                {
                    series.IsVisibleInLegend = true;
                    series.LegendText = series.Name.Split('_')[0];
                }
            }
            else
            {
                MessageBox.Show("Selected folder is not a valid ICP-MS Batch folder!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddChartArea(string areaname, int areawith)
        {
            ChartArea newArea = new ChartArea(areaname);
            newArea.CursorX.IsUserSelectionEnabled = true;
            //newArea.AxisX.ScaleView.Zoomable = false;
            newArea.AlignmentStyle = AreaAlignmentStyles.PlotPosition;
            newArea.AlignmentOrientation = AreaAlignmentOrientations.Horizontal;
            newArea.AxisY.MajorTickMark.Enabled = false;
            newArea.Position.Auto = false;
            newArea.InnerPlotPosition = new ElementPosition(20, 5, 80, 85);
            newArea.AxisX.Title = areaname;
            if (chart1.ChartAreas.Count == 0)
            {
                newArea.Position = new ElementPosition(0, 0, areaWithPerctangle(areawith), 100);
            }
            else
            {

                //Resize Chart object
                if (chart1.Width <= chart1.ChartAreas.Count * areawith)
                    chart1.Width += areawith;

                //Recalculate existing ChartAreas
                chart1.ChartAreas[0].Position.Width = areaWithPerctangle(areawith);
                chart1.ChartAreas[0].Position.X = 0;
                for (int i = 1; i < chart1.ChartAreas.Count; i++)
                {
                    chart1.ChartAreas[i].Position.Width = areaWithPerctangle(areawith);
                    chart1.ChartAreas[i].Position.X = chart1.ChartAreas[i - 1].Position.Right;
                }

                //Calculate the new ChartArea
                ChartArea previousArea = chart1.ChartAreas[chart1.ChartAreas.Count - 1];
                newArea.Position = new ElementPosition(previousArea.Position.Right, 0, areaWithPerctangle(areawith), 100);
            }
            chart1.ChartAreas.Add(newArea);
            //if(chart1.Width <= chart1.ChartAreas.Count * areawith)
        }
        private double maxYAxisValue()
        {
            double max = 0;
            foreach (ChartArea area in chart1.ChartAreas)
            {
                if (area.AxisY.Maximum > max)
                    max = area.AxisY.Maximum;
            }
            return max;
        }
        private float areaWithPerctangle(int targetWidth)
        {
            int percent100 = chart1.Width;
            return targetWidth * 100 / (float)percent100;
        }

    }
}