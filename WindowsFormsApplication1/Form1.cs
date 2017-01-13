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
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        List<TRAData> LoadedData = new List<TRAData>();
        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog1.SelectedPath.Contains(".b"))
                {
                    List<string> datafiles = Directory.EnumerateDirectories(folderBrowserDialog1.SelectedPath, "*.d").ToList();
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

                            //Set legend label
                            foreach (Series series in currentData.DataSeries)
                            {
                                series.ChartArea = chart1.ChartAreas.Last().Name;
                               // series.AxisLabel = series.Name;
                                chart1.Series.Add(series);
                            }
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
            DataTable table = new DataTable("chartareas");
            table.Columns.Add("Name");
            table.Columns.Add("X");
            table.Columns.Add("Y");
            table.Columns.Add("Width");
            DataTable table2 = new DataTable("inner");
            table2.Columns.Add("Name");
            table2.Columns.Add("X");
            table2.Columns.Add("Y");
            table2.Columns.Add("Width");

            foreach (ChartArea area in chart1.ChartAreas)
            {
                table.Rows.Add(area.Name, area.Position.X, area.Position.Y, area.Position.Width);
                table2.Rows.Add(area.Name, area.InnerPlotPosition.X, area.InnerPlotPosition.Y, area.InnerPlotPosition.Width);
            }
            //dataGridView1.DataSource = table;
            //dataGridView2.DataSource = table2;
            this.Text = chart1.Width.ToString();
        }
        private void AddChartArea(string areaname, int areawith)
        {
            ChartArea newArea = new ChartArea(areaname);
            newArea.CursorX.IsUserSelectionEnabled = true;
            newArea.AxisX.ScaleView.Zoomable = false;
            newArea.AlignmentStyle = AreaAlignmentStyles.PlotPosition;
            newArea.AlignmentOrientation = AreaAlignmentOrientations.Horizontal;
            newArea.AxisY.MajorTickMark.Enabled = false;
            newArea.Position.Auto = false;

            if(chart1.ChartAreas.Count == 0)
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
            chart1.Width += 400;
            newArea.InnerPlotPosition = new ElementPosition(20, 5, 80, 85);
            if (chart1.ChartAreas.Count > 0)
            {
                newArea.AlignWithChartArea = chart1.ChartAreas.Last().Name;
            }
            chart1.ChartAreas.Add(newArea);
            
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
        private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            foreach (ChartArea area in chart1.ChartAreas)
            {
                if(area != e.ChartArea)
                if (area.CursorX.SelectionStart != e.NewSelectionStart && area.CursorX.SelectionEnd != e.NewSelectionEnd)
                {
                    area.CursorX.SelectionStart = e.NewSelectionStart;
                    area.CursorX.SelectionEnd = e.NewSelectionEnd;
                    area.RecalculateAxesScale();
                }
            }
        }
    }
}