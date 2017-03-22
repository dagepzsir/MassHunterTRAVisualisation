using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassHunterTRAnalyser.Data_Classes
{
    class SampleGroup
    {
        private List<string> sampleDataFileNames = new List<string>();
        public bool ShouldSerializeSamples()
        {
            return false;
        }
        public  List<SampleData> Samples { get; private set; }
        public string GroupName { get; set; }

        public SampleGroup(string name)
        {
            Samples = new List<SampleData>();
            GroupName = name;
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
        public SampleGroup() { }
    }
}