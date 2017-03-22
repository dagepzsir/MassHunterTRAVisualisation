using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassHunterTRAnalyser.Data_Classes
{
    public class SampleGroup
    {
        private List<string> sampleDataFileNames = new List<string>();
        public bool ShouldSerializeSamples()
        {
            return false;
        }
        public  List<SampleData> Samples { get; private set; }
        public string GroupName { get; set; }
        public bool RejectedGroup { get; set; }
        public SampleGroup(string name)
        {
            Samples = new List<SampleData>();
            GroupName = name;
            RejectedGroup = true;
        }

        public void AddSample(SampleData sample)
        {
            Samples.Add(sample);
            sampleDataFileNames.Add(sample.DataFileName);
        }
        public void RemoveSample(SampleData sample)
        {
            sampleDataFileNames.Remove(sample.DataFileName);
            Samples.Remove(sample);
        }
        public void LoadSamplesByDataFile(List<SampleData> samples)
        {
            foreach (SampleData data in samples)
            {
                if (sampleDataFileNames.Contains(data.DataFileName))
                    Samples.Add(data);
            }
        }
        public Dictionary<string, (double average, double stdev)> CalulateGroupStatistics()
        {
            List<Dictionary<string, double>> combinedList = new List<Dictionary<string, double>>();
            foreach (SampleData sample in Samples)
            {
                var backgroundCorrectedSignals = sample.GetBackgroundCorrectedSignals();
                Dictionary<string, double> tempDict = new Dictionary<string, double>();
                foreach (string key in backgroundCorrectedSignals.Keys)
                {
                    tempDict.Add(key, backgroundCorrectedSignals[key].average);
                }
                combinedList.Add(tempDict);
            }
            return Calculations.CalculateSelectionAverageStdevFromElementDictList(combinedList);
        }
        public SampleGroup() { }
    }
}