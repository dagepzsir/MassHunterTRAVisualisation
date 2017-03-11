using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MassHunterTRAnalyser
{
    public class SampleData
    {
        public string SampleName { get; private set; }
        public string DataFileName { get; private set; }
        public List<Tuple<double, Dictionary<string, double>>> TimeResolvedData = new List<Tuple<double, Dictionary<string, double>>>();
        public SampleData(string sampledatapath)
        {
            LoadSampleData(sampledatapath);
        }

        private void LoadSampleData(string sampledatapath)
        {
            string datafile = Path.GetFileNameWithoutExtension(sampledatapath) + ".csv";
            string finalPath = Path.Combine(sampledatapath, datafile);
            if (File.Exists(finalPath))
            {
                //Load sample information from XML
                string sampleInfoPath = Path.Combine(sampledatapath, "AcqData", "sample_info.xml");
                XDocument sampleInfo = XDocument.Load(sampleInfoPath);
                var fields = from field in sampleInfo.Descendants("Name")
                             where field.Value == "Sample Name"
                             select field.Parent;
                SampleName = fields.ElementAt(0).Descendants("Value").ElementAt(0).Value;
                DataFileName = Path.GetFileNameWithoutExtension(sampledatapath);

                List<Tuple<double, Dictionary<string, double>>> csvData = new List<Tuple<double, Dictionary<string, double>>>();
                //Load sample data CSV
                using (StreamReader reader = new StreamReader(finalPath))
                {
                    //go to the start of the data
                    reader.ReadLine();
                    reader.ReadLine();
                    reader.ReadLine();

                    //read header
                    string[] header = reader.ReadLine().Split(',');

                    //Start reading looop

                    while (reader.EndOfStream == false)
                    {
                        string[] currentLine = reader.ReadLine().Split(',');
                        if (currentLine.Length == 1)
                            break;
                        Tuple<double, Dictionary<string, double>> data;
                        Dictionary<string, double> measuredIntensities = new Dictionary<string, double>();
                        for (int i = 1; i < currentLine.Length; i++)
                        {
                            measuredIntensities.Add(header[i], Convert.ToDouble(currentLine[i]));
                        }
                        data = new Tuple<double, Dictionary<string, double>>(Convert.ToDouble(currentLine[0]), measuredIntensities);
                        csvData.Add(data);
                    }
                }
                TimeResolvedData = csvData;
            }
        }
    }
}