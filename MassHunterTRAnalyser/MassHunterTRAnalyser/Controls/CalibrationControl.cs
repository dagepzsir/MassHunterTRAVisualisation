using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MassHunterTRAnalyser.Data_Classes;
using MathNet.Numerics;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace MassHunterTRAnalyser.Controls
{
    public partial class CalibrationControl : UserControl
    {

        List<(double average, double stdev)> measuredStandardData = new List<(double average, double stdev)>();
        List<SampleGroup> sampleGroups;
        List<StandardData> storedStandards;
        DataTable dataTable = new DataTable();
        List<int> levels = new List<int>();
        Dictionary<int, List<(string element, double slope, double intercept, double r2)>> calibrationLines = new Dictionary<int, List<(string element, double slope, double intercept, double r2)>>();
        public CalibrationControl()
        {
            InitializeComponent();
            dataTable.Columns.Add("Level", typeof(int));
            dataTable.Columns.Add("Element", typeof(string));
            dataTable.Columns.Add("Slope", typeof(double));
            dataTable.Columns.Add("Intercept", typeof(double));
            dataTable.Columns.Add("r2", typeof(double));
            dataGridView1.DataSource = dataTable;
        }

        public void CalibrationControlDataLoaded(object sender, DataLoadedEventArgs e)
        {
            storedStandards = e.StoredStandards;
            UpdateCalibration();

        }

        public void UpdateCalibration()
        {
            dataTable.Rows.Clear();
            calibrationLines.Clear();
            chart1.Series.Clear();
            foreach (int level in levels)
            {
                calculateCalibration(level);
            }
        }

        public void SampleTypeControl1_SampleGroupsChanged(object sender, SampleDataChangedEventArgs e)
        {
            sampleGroups = e.SampleGroups;
            levels = e.Levels;
        }

        private void calculateCalibration(int level)
        {
            Dictionary<string, List<(string standard, double average)>> data = new Dictionary<string, List<(string standard, double average)>>();
            foreach (SampleGroup group in sampleGroups)
            {
                if (group.NumberofActiveSamples > 0)
                {
                    if (group.GroupType == SampleType.Standard && group.Samples[0].StandardLevel == level)
                    {
                        var groupAverage = group.CalulateGroupStatistics();

                        foreach (string key in groupAverage.Keys)
                        {
                            if (data.ContainsKey(key) == false)
                                data.Add(key, new List<(string standard, double average)>());
                            data[key].Add((group.Samples[0].StandardType, groupAverage[key].average));
                        }
                    }
                }
            }
            foreach (var item in data)
            {
                var calibrationLine = calibrationForElement(level, item.Key, item.Value);
                if (calibrationLines.ContainsKey(level) == false)
                    calibrationLines.Add(level, new List<(string element, double slope, double intercept, double r2)>());
                calibrationLines[level].Add((item.Key, calibrationLine.slope, calibrationLine.intercept, calibrationLine.rSquared));
                dataTable.Rows.Add(level, item.Key, calibrationLine.slope, calibrationLine.intercept, calibrationLine.rSquared);
            }
        }
        private (double slope, double intercept, double rSquared) calibrationForElement(int level, string element, List<(string standard, double average)> elementdata)
        {
            List<double> xStandard = new List<double>();
            List<double> yMeasured = new List<double>();
            Series dataSeries = new Series(string.Format("{0}-{1} data", level, element));
            Series regressionSeries = new Series(string.Format("{0}-{1} regression", level, element));
            dataSeries.ChartType = SeriesChartType.Point;
            dataSeries.MarkerStyle = MarkerStyle.Circle;
            dataSeries.MarkerSize = 10;
            regressionSeries.ChartType = SeriesChartType.Line;

            foreach (var data in elementdata)
            {
                yMeasured.Add(data.average);

                StandardData standard = storedStandards.Find(item => item.StandardName == data.standard);

                List<char> array = element.ToCharArray().ToList();
                array.RemoveAll(item => Char.IsNumber(item));
                string key = new string(array.ToArray());
                xStandard.Add(standard.ElementConcentrations[key].Concentration);
                dataSeries.Points.AddXY(xStandard.Last(), yMeasured.Last());
            }

            (double slope, double intercept, double rSquared) output;
            if (xStandard.Count > 1)
            {
                Tuple<double, double> linearfit = Fit.Line(xStandard.ToArray(), yMeasured.ToArray());
                double rSquared = GoodnessOfFit.RSquared(xStandard.Select(x => linearfit.Item2 + x * linearfit.Item1), yMeasured);
                output = (linearfit.Item2, linearfit.Item1, rSquared);
            }
            else
            {
                output = (0, xStandard[0], 0);
            }

            double y1 = output.intercept;
            double y2 = (xStandard.Max() * output.slope) + output.intercept;

            regressionSeries.Points.AddXY(0, y1);
            regressionSeries.Points.AddXY(xStandard.Max(), y2);

            chart1.Series.Add(regressionSeries);
            chart1.Series.Add(dataSeries);

            chart1.Series[chart1.Series.Count - 1].Enabled = false;
            chart1.Series[chart1.Series.Count - 2].Enabled = false;
            return output;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string selectedChart = string.Format("{0}-{1}", dataGridView1["Level", dataGridView1.SelectedCells[0].RowIndex].Value, dataGridView1["Element", dataGridView1.SelectedCells[0].RowIndex].Value);
                foreach (Series series in chart1.Series)
                {
                    if (series.Name.Contains(selectedChart) == false)
                        series.Enabled = false;
                    else
                        series.Enabled = true;
                }
                chart1.ChartAreas[0].RecalculateAxesScale();
                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Minimum = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculateCalibration(1);
        }
    }
}