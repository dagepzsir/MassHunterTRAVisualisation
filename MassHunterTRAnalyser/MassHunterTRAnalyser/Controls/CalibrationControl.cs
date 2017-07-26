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
using System.IO;
using Newtonsoft.Json;

namespace MassHunterTRAnalyser.Controls
{
    public partial class CalibrationControl : UserControl
    {

        List<(double average, double stdev)> measuredStandardData = new List<(double average, double stdev)>();
        List<SampleGroup> sampleGroups;
        List<StandardData> storedStandards;
        DataTable dataTable = new DataTable();
        List<int> levels = new List<int>();
        List<CalibrationLine> calibLines = new List<CalibrationLine>();
        CalibrationLine selectedCalibration;

        string calibrationFilePath;

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
            calibrationFilePath = Path.Combine(e.LoadedBatch.FolderPath, "calibLines.json");
            loadCalibrationFromFile(calibrationFilePath);
            UpdateCalibration();
        }
        public void UpdateCalibration()
        {
            dataTable.Rows.Clear();
            calibLines.ForEach(item => item.ReserCalibData());
            chart1.Series.Clear();
            foreach (int level in levels)
            {
                calculateCalibration(level);
            }
        }
        public void SaveCalibration()
        {
            using (StreamWriter sw = new StreamWriter(calibrationFilePath, false))
            {
                //Serialize sample data to a json and save it to ~\analysis.json
                string serialized = JsonConvert.SerializeObject(calibLines);
                sw.WriteLine(serialized);
            }
        }
        public void SampleTypeControl1_SampleGroupsChanged(object sender, SampleDataChangedEventArgs e)
        {
            sampleGroups = e.SampleGroups;
            levels = e.Levels;
            if(storedStandards != null)
                UpdateCalibration();
        }

        private void calculateCalibration(int level)
        {
            StandardData usedStandard = null;

            Dictionary<string, List<(string standard, double average)>> data = new Dictionary<string, List<(string standard, double average)>>();
            foreach (SampleGroup group in sampleGroups)
            {
                if (group.NumberofActiveSamples > 0)
                {
                    if (group.GroupType == SampleType.Standard && group.Samples[0].StandardLevel == level)
                    {
                        usedStandard = storedStandards.Find(item => item.StandardName == group.Samples[0].StandardType);
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
                CalibrationLine existingLine = calibLines.Find(it => it.Level == level && it.Element == item.Key);
                if (existingLine == null)
                {
                    foreach (string element in usedStandard.ElementConcentrations.Keys)
                    {
                        if(item.Key.Contains(element))
                        {
                            string unit = usedStandard.ElementConcentrations[element].Unit;
                            calibLines.Add(new CalibrationLine(level, item.Key, calibrationLine.slope, calibrationLine.intercept, calibrationLine.rSquared, unit));
                            break;
                        }
                    }
                }
                else
                {
                    existingLine.Slope = calibrationLine.slope;
                    existingLine.Intercept = calibrationLine.intercept;
                    existingLine.RSquared = calibrationLine.rSquared;
                }
                if(calibrationLine.rSquared != -1)
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

                if (standard.ElementConcentrations.ContainsKey(key))
                {
                    xStandard.Add(standard.ElementConcentrations[key].Concentration);
                    dataSeries.Points.AddXY(xStandard.Last(), yMeasured.Last());
                }
            }

            (double slope, double intercept, double rSquared) output;
            if (xStandard.Count > 1)
            {
                Tuple<double, double> linearfit = Fit.Line(xStandard.ToArray(), yMeasured.ToArray());
                double rSquared = GoodnessOfFit.RSquared(xStandard.Select(x => linearfit.Item2 + x * linearfit.Item1), yMeasured);
                output = (linearfit.Item2, linearfit.Item1, rSquared);

                double y1 = output.intercept;
                double y2 = (xStandard.Max() * output.slope) + output.intercept;

                regressionSeries.Points.AddXY(0, y1);
                regressionSeries.Points.AddXY(xStandard.Max(), y2);

                chart1.Series.Add(regressionSeries);
                chart1.Series.Add(dataSeries);

                chart1.Series[chart1.Series.Count - 1].Enabled = false;
                chart1.Series[chart1.Series.Count - 2].Enabled = false;

            }
            else
            {
                output = (0, 0, -1);
            }

           
            return output;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int level = Utils.ConvertToInt32(dataGridView1["Level", dataGridView1.SelectedCells[0].RowIndex].Value);
                string element = dataGridView1["Element", dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
                string selectedChart = string.Format("{0}-{1}", level, element);
                selectedCalibration = calibLines.Find(item => item.Level == level && item.Element == element);
                if (selectedCalibration != null)
                {
                    chart1.ChartAreas[0].AxisX.Title = string.Format("Koncentráció ({0})", selectedCalibration.Unit);
                    Debug.WriteLine(selectedCalibration.Element + " " + selectedCalibration.Level);

                    foreach (Series series in chart1.Series)
                    {
                        if (series.Name.Contains(selectedChart) == false)
                            series.Enabled = false;
                        else
                            series.Enabled = true;
                    }
                    if (selectedCalibration.ChartSettings == null)
                    {
                        chart1.ChartAreas[0].AxisX.Minimum = 0;
                        chart1.ChartAreas[0].AxisY.Minimum = 0;
                        chart1.ChartAreas[0].AxisX.Maximum = double.NaN;
                        chart1.ChartAreas[0].AxisY.Maximum = double.NaN;
                        chart1.ChartAreas[0].RecalculateAxesScale();
                        (double min, double max) xbounds = (chart1.ChartAreas[0].AxisX.Minimum, chart1.ChartAreas[0].AxisX.Maximum);
                        (double min, double max) ybounds = (chart1.ChartAreas[0].AxisY.Minimum, chart1.ChartAreas[0].AxisY.Maximum);
                        double xintervall = chart1.ChartAreas[0].AxisX.Interval;
                        double yintervall = chart1.ChartAreas[0].AxisY.Interval;
                        string xtitle = chart1.ChartAreas[0].AxisX.Title;
                        string ytitle = chart1.ChartAreas[0].AxisY.Title;
                        bool xtitlebold = chart1.ChartAreas[0].AxisX.TitleFont.Bold;
                        bool ytitlebold = chart1.ChartAreas[0].AxisY.TitleFont.Bold;
                        selectedCalibration.ChartSettings = new ChartSettings(xbounds, ybounds, xintervall, yintervall, xtitle, xtitlebold, ytitle, ytitlebold);
                    }

                    updateChartOptions(selectedCalibration);

                    fillChartOptions(selectedCalibration);
                }
            }


        }
        private void fillChartOptions(CalibrationLine calibration)
        {
            xMinTextBox.Text = calibration.ChartSettings.XBoundaries.min.ToString();
            xMaxTextbox.Text = calibration.ChartSettings.XBoundaries.max.ToString();
            yMinTextBox.Text = calibration.ChartSettings.YBoundaries.min.ToString();
            yMaxTextBox.Text = calibration.ChartSettings.YBoundaries.max.ToString();
            xIntervallTextBox.Text = calibration.ChartSettings.XIntervall.ToString();
            yIntervallTextBox.Text = calibration.ChartSettings.YIntervall.ToString();
            xTitleTextBox.Text = calibration.ChartSettings.XTitle;
            yTitelTextBox.Text = calibration.ChartSettings.YTitle;
            xTitleBoldCheckBox.Checked = calibration.ChartSettings.XTitleBold;
            yTitleBoldCheckBox.Checked = calibration.ChartSettings.YTitleBold;
            
        }
        private void updateChartOptions(CalibrationLine calibration)
        {
            try
            {
                chart1.ChartAreas[0].AxisX.Minimum = calibration.ChartSettings.XBoundaries.min;
                chart1.ChartAreas[0].AxisX.Maximum = calibration.ChartSettings.XBoundaries.max;
                chart1.ChartAreas[0].AxisY.Minimum = calibration.ChartSettings.YBoundaries.min;
                chart1.ChartAreas[0].AxisY.Maximum = calibration.ChartSettings.YBoundaries.max;

                chart1.ChartAreas[0].AxisX.Interval = calibration.ChartSettings.XIntervall;
                chart1.ChartAreas[0].AxisY.Interval = calibration.ChartSettings.YIntervall;

                chart1.ChartAreas[0].AxisX.Title = calibration.ChartSettings.XTitle;
                chart1.ChartAreas[0].AxisY.Title = calibration.ChartSettings.YTitle;
                Font boldfont = new Font("Times New Roman", 9, FontStyle.Bold);
                Font normalfont = new Font("Times New Roman", 9, FontStyle.Regular);
                if (calibration.ChartSettings.XTitleBold)
                {
                    chart1.ChartAreas[0].AxisX.TitleFont = boldfont;
                }
                else
                {
                    chart1.ChartAreas[0].AxisX.TitleFont = normalfont;
                }
                if(calibration.ChartSettings.YTitleBold)
                {
                    chart1.ChartAreas[0].AxisY.TitleFont = boldfont;
                }
                else
                {
                    chart1.ChartAreas[0].AxisY.TitleFont = normalfont;
                }

                chart1.ChartAreas[0].RecalculateAxesScale();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void xMinTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(sender as TextBox, true, true, true, true);
            }
        }

        private void xMaxTextbox_Validating(object sender, CancelEventArgs e)
        {
            double value = Utils.ConvertToDouble((sender as TextBox).Text);
            if (double.IsNaN(value))
            {
                e.Cancel = true;
            }
            else
            {
                if (selectedCalibration.ChartSettings.XBoundaries.min >= value)
                {
                    MessageBox.Show("The maximum value must be greater than the minimum!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
        }
        private void xMinTextBox_Validating(object sender, CancelEventArgs e)
        {
            double value = Utils.ConvertToDouble((sender as TextBox).Text);

            if (double.IsNaN(value))
            {
                e.Cancel = true;
            }
            else
            {
                if (selectedCalibration.ChartSettings.XBoundaries.max <= value)
                {
                    MessageBox.Show("The minimum value must be less than the maximum!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
        }
        private void yMaxTextBox_Validating(object sender, CancelEventArgs e)
        {
            double value = Utils.ConvertToDouble((sender as TextBox).Text);
            if (double.IsNaN(value))
            {
                e.Cancel = true;
            }
            else
            {
                if (selectedCalibration.ChartSettings.YBoundaries.min >= value)
                {
                    MessageBox.Show("The maximum value must be greater than the minimum!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
        }
        private void yMinTextBox_Validating(object sender, CancelEventArgs e)
        {
            double value = Utils.ConvertToDouble((sender as TextBox).Text);
            if (double.IsNaN(value))
            {
                e.Cancel = true;
            }
            else
            {
                if (selectedCalibration.ChartSettings.YBoundaries.max <= value)
                {
                    MessageBox.Show("The minimum value must be less than the maximum!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }

            }
        }
        private void xIntervallTextBox_Validating(object sender, CancelEventArgs e)
        {
            double value = Utils.ConvertToDouble((sender as TextBox).Text);
            if (double.IsNaN(value))
                e.Cancel = true;
        }
        private void yIntervallTextBox_Validating(object sender, CancelEventArgs e)
        {
            double value = Utils.ConvertToDouble((sender as TextBox).Text);
            if (double.IsNaN(value))
                e.Cancel = true;
        }

        private void xMinTextBox_Validated(object sender, EventArgs e)
        {
            selectedCalibration.ChartSettings.XBoundaries.min = Utils.ConvertToDouble((sender as TextBox).Text);
            updateChartOptions(selectedCalibration);
        }
        private void xMaxTextbox_Validated(object sender, EventArgs e)
        {
            selectedCalibration.ChartSettings.XBoundaries.max = Utils.ConvertToDouble((sender as TextBox).Text);
            updateChartOptions(selectedCalibration);
        }
        private void yMinTextBox_Validated(object sender, EventArgs e)
        {
            selectedCalibration.ChartSettings.YBoundaries.min = Utils.ConvertToDouble((sender as TextBox).Text);
            updateChartOptions(selectedCalibration);
        }
        private void yMaxTextBox_Validated(object sender, EventArgs e)
        {
            selectedCalibration.ChartSettings.YBoundaries.max = Utils.ConvertToDouble((sender as TextBox).Text);
            updateChartOptions(selectedCalibration);
        }
        private void xIntervallTextBox_Validated(object sender, EventArgs e)
        {
            selectedCalibration.ChartSettings.XIntervall = Utils.ConvertToDouble((sender as TextBox).Text);
            updateChartOptions(selectedCalibration);
        }
        private void yIntervallTextBox_Validated(object sender, EventArgs e)
        {
            selectedCalibration.ChartSettings.YIntervall = Utils.ConvertToDouble((sender as TextBox).Text);
            updateChartOptions(selectedCalibration);
        }

        private void loadCalibrationFromFile(string calibrationfile)
        {
            if(File.Exists(calibrationfile))
            {
                using (StreamReader reader = new StreamReader(calibrationfile))
                {
                    string calibDataJson = reader.ReadToEnd();
                    calibLines = JsonConvert.DeserializeObject<List<CalibrationLine>>(calibDataJson);
                }
                
            }
        }
    }
}