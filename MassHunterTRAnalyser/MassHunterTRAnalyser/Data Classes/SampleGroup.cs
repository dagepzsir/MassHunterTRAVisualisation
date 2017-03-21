using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassHunterTRAnalyser.Data_Classes
{
    class SampleGroup
    {
        private List<string> sampleDataFileNames;
        public bool ShouldSerializeSamples()
        {
            return false;
        }
        public List<SampleData> Samples { get; set; }
        public string GroupName { get; set; }

        public SampleGroup(string name, List<SampleData> samples)
        {
            Samples = samples;
            GroupName = name;
            foreach (SampleData data in Samples)
            {
                sampleDataFileNames.Add(data.DataFileName);
            }
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