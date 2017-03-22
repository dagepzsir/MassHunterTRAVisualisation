using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassHunterTRAnalyser
{
    class Calculations
    {
        public static Dictionary<string, (double average, double stdev)> SubstractBackground(Dictionary<string, (double average, double stdev)> background, Dictionary<string, (double average, double stdev)> data)
        {
            Dictionary<string, (double average, double stdev)> output = new Dictionary<string, (double average, double stdev)>();

            foreach (string key in data.Keys)
            {
                output.Add(key, (average: data[key].average - background[key].average, stdev: data[key].stdev));
            }
            return output;
        }
        public static Dictionary<string, (double average, double stdev)> CalculateSelectionAverageStdevFromElementDictList(List<Dictionary<string, double>> elementdata)
        {
            Dictionary<string, (double average, double stdev)> output = new Dictionary<string, (double average, double stdev)>();
            foreach (string key in elementdata[0].Keys)
            {
                List<double> measurementData = new List<double>();
                foreach (Dictionary<string, double> measurement in elementdata)
                {
                    if(measurement.ContainsKey(key))
                        measurementData.Add(measurement[key]);
                }
                var meanAndStdev = Statistics.MeanStandardDeviation(measurementData);
                output.Add(key, (meanAndStdev.Item1, meanAndStdev.Item2));
            }
            return output;
        }
        public static double RSD((double average, double stdev) averageandstdev)
        {
            return (averageandstdev.stdev / averageandstdev.average) * 100;
        }
    }
}