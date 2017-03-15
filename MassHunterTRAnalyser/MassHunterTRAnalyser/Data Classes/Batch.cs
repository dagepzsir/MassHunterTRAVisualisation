using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
namespace MassHunterTRAnalyser
{
    public class Batch
    {
        public List<SampleData> MeasuredData { get; set; }
        public Batch(string path)
        {
            LoadFromFile(path);
        }

        //Load selected batch
        private void LoadFromFile(string folderpath)
        {
            List<string> dataFiles = Directory.EnumerateDirectories(folderpath, "*.d").ToList();
            MeasuredData = new List<SampleData>();
            //Load acq data
            string analysisFile = Path.Combine(folderpath, "analysis.json");
            if (File.Exists(analysisFile))
            {
                List<SampleData> storedData;
                using (StreamReader reader = new StreamReader(analysisFile))
                {
                    storedData = JsonConvert.DeserializeObject<List<SampleData>>(reader.ReadToEnd());
                }
                
                foreach (SampleData data in storedData)
                {
                    string datafilepath = dataFiles.Find(item => item.Contains(data.DataFileName));
                    data.LoadMeasuredSampleData(datafilepath, true);
                }
                MeasuredData = storedData;
            }
            else
            {
                foreach (string dataFileFolder in dataFiles)
                {
                    MeasuredData.Add(new SampleData(dataFileFolder));
                }
            }
        }
    }
}