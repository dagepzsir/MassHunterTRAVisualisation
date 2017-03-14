using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MassHunterTRAnalyser
{
    public enum SampleType
    {
        NotSet,
        Blank,
        Standard,
        Sample
    }
    public class SampleData
    {
        public string DataFileName { get; private set; }

        //Can be set
        public string SampleName { get; set; }
        //User set parameters
        public int StandardLevel  { get; set; }
        public SampleType TypeOfSample { get; set; }
        public string StandardType { get; set; }
        public List<DataSelection> DataSelections { get; set; }

        public List<Tuple<double, Dictionary<string, double>>> TimeResolvedData = new List<Tuple<double, Dictionary<string, double>>>();
        public bool ShouldSerializeTimeResolvedData()
        {
            return false;
        }

        public SampleData(string sampledatapath)
        {
            LoadSampleData(sampledatapath);
            
            DataSelections = new List<DataSelection>();
        }
        public Dictionary<DataSelection, List<Tuple<double, Dictionary<string, double>>>> GetSelectedData()
        {
            Dictionary<DataSelection, List<Tuple<double, Dictionary<string, double>>>> output = new Dictionary<DataSelection, List<Tuple<double, Dictionary<string, double>>>>();
            foreach (DataSelection selection in DataSelections)
            {
                output.Add(selection, new List<Tuple<double, Dictionary<string, double>>>());
                foreach (Tuple<double, Dictionary<string, double>> data in TimeResolvedData)
                {
                    if (data.Item1 >= selection.Min && data.Item1 <= selection.Max)
                        output[selection].Add(data);
                }
            }
            return output;
        }
        public string SampleTypeString
        {
            get
            {
                switch (TypeOfSample)
                {
                    case SampleType.NotSet:
                        return "Not set";
                    case SampleType.Blank:
                        return "Blank";
                    case SampleType.Standard:
                        return "Standard";
                    case SampleType.Sample:
                        return "Sample";
                    default:
                        return "Not set";
                }
            }
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