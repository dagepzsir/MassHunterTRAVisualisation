using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics.Statistics;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class TRAData
    {
        public string FilePath { get; set; }
        public string SampleName { get; set; }
        public Dictionary<string, List<double>> CSVData;
        public List<double> Time = new List<double>();
        public List<Series> DataSeries { get; set; }
        public double SelectionStart { get; set; }
        public double SelectionEnd { get; set; }
        public TRAData(string filepath, Dictionary<string, List<double>> csvdata, List<double> time, List<Series> series)
        {
            Time = time;
            FilePath = Path.GetDirectoryName(filepath);
            CSVData = csvdata;
            DataSeries = series;
            SelectionEnd = double.NaN;
            SelectionStart = double.NaN;
        }
        public void RefreshSeriesColor()
        {
            List<Color> colors = Utils.GetColorsFromSettings();
            for (int i = 0; i < DataSeries.Count; i++)
            {
                DataSeries[i].Color = colors[i];
            }
        }
        public static TRAData LoadCSVFile(string filepath)
        {
            Dictionary<string, List<double>> csvData = new Dictionary<string, List<double>>();
            List<double> times = new List<double>();
            List<string> elements = new List<string>();
            List<Series> serieses = new List<Series>();
            NumberFormatInfo numFormat = new NumberFormatInfo();
            numFormat.NumberDecimalSeparator = ".";
            List<Color> colors = Utils.GetColorsFromSettings();
            
            using (StreamReader reader = new StreamReader(filepath))
            {
                string fileName = Path.GetFileNameWithoutExtension(filepath);

                //go to the start of the data
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();

                //read header
                string[] data = reader.ReadLine().Split(',');

                for (int i = 1; i < data.Length; i++)
                {
                    Series newSeries = new Series(data[i] + "_" + fileName);
                    string asdf = Color.Black.ToString();
                    newSeries.ChartType = SeriesChartType.Spline;
                    newSeries.Color = colors[i - 1];
                    
                    newSeries.IsVisibleInLegend = false;
                    serieses.Add(newSeries);
                    elements.Add(data[i]);
                    csvData.Add(data[i], new List<double>());
                }
                while (reader.EndOfStream == false)
                {
                    string[] currentLine = reader.ReadLine().Split(',');
                    if (currentLine.Length == 1)
                        break;

                    //Add time to database
                    times.Add(Convert.ToDouble(currentLine[0], numFormat));
                    for (int i = 1; i < currentLine.Length; i++)
                    {
                        string elementName = elements[i - 1];

                        csvData[elementName].Add(Convert.ToDouble(currentLine[i], numFormat));
                    }
                }

                //Set series data
                foreach (string key in csvData.Keys)
                {
                    for (int i = 0; i < csvData[key].Count; i++)
                    {
                        serieses.Find(item => item.Name == (key + "_" + fileName)).Points.AddXY(times[i], csvData[key][i]);
                    }
                }
            }
            return new TRAData(filepath, csvData, times, serieses);
        }

        public DataTable Analysis()
        {
            DataTable output = new DataTable();
            output.Columns.Add("Sample Name");
            output.Columns.Add("Element");
            output.Columns.Add("Average");
            output.Columns.Add("SD");
            Dictionary<string, Tuple<double, double>> average = Average();
            foreach (string key in average.Keys)
            {
                output.Rows.Add(SampleName, key, average[key].Item1, average[key].Item2);
            }
            return output;
        }
        public Dictionary<string, Tuple<double,double>> Average()
        {
            Dictionary<string, Tuple<double, double>> output = new Dictionary<string, Tuple<double, double>>();
            if (SelectionStart.ToString() == double.NaN.ToString())
            {
                MessageBox.Show(SelectionStart.ToString() + " fent");
                foreach (string key in CSVData.Keys)
                {
                    output.Add(key, Statistics.MeanStandardDeviation(CSVData[key]));
                    double mean = Statistics.Mean(CSVData[key]);
                }
                return output;
                
            }
            else
            {
                MessageBox.Show(SelectionStart.ToString());
                return null;
            }
        }
        public double StandardDeviation()
        {
            return 0;
        }
    }
}