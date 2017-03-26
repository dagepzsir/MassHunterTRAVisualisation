using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using MassHunterTRAnalyser.Data_Classes;

namespace MassHunterTRAnalyser
{
    public class Batch
    {
        public List<SampleData> MeasuredData { get; set; }
        public bool AlreadySaved;
        public string FolderPath { get; private set; }
        public Batch(string path, List<StandardData> storedstandards)
        {
            loadFromFile(path, storedstandards);
            FolderPath = path;
        }

        //Load selected batch
        private void loadFromFile(string folderpath, List<StandardData> storedstandards)
        {
            List<string> dataFiles = Directory.EnumerateDirectories(folderpath, "*.d").ToList();

            //Load acq data
            string analysisFile = Path.Combine(folderpath, "analysis.json");
            if (File.Exists(analysisFile))
            {
                List<SampleData> storedData;
                AlreadySaved = true;
                //Load user set sample options
                using (StreamReader reader = new StreamReader(analysisFile))
                {
                    storedData = JsonConvert.DeserializeObject<List<SampleData>>(reader.ReadToEnd());
                }
                
                //Read acq data from MassHunter files
                foreach (SampleData data in storedData)
                {
                    string datafilepath = dataFiles.Find(item => item.Contains(data.DataFileName));
                    data.LoadMeasuredSampleData(datafilepath, true, storedstandards);
                }
                MeasuredData = storedData;
            }
            else
            {
                MeasuredData = new List<SampleData>();
                AlreadySaved = false;
                foreach (string dataFileFolder in dataFiles)
                {
                    MeasuredData.Add(new SampleData(dataFileFolder, storedstandards));
                }
            }
        }
    }
}