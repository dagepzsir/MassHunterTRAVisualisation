using MassHunterTRAnalyser.Data_Classes;
using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MassHunterTRAnalyser
{
    public enum SampleType
    {
        NotSet = 0,
        Blank = 1,
        Standard = 2,
        Sample = 3
    }
    public class SampleData
    {
        public string DataFileName { get; set; }

        //User set parameters
        public string SampleName { get; set; }
        public string Comment { get; set; }
        public bool Rejected { get; set; }
        public int StandardLevel  { get; set; }
        public SampleType TypeOfSample { get; set; }
        public string StandardType { get; set; }
        public string SampleGroup { get; set; }
        public List<DataSelection> DataSelections { get; set; }
         
        public List<(double time, Dictionary<string, double> data)> TimeResolvedData = new List<(double time, Dictionary<string, double> data)>();
       
        //Required for JsonSerializer
        public bool ShouldSerializeTimeResolvedData()
        {
            return false;
        }
        public SampleData() { }

        /// <summary>
        /// Use to initialize new SampleData, in the case of compleatly new data never opened with this software
        /// </summary>
        /// <param name="sampledatapath">Folder containing the tabulated measurement data</param>
        public SampleData(string sampledatapath, List<StandardData> storedstandards)
        {
            //Set to false to load NEW acq data (new batch file which were never opened with this software)
            LoadMeasuredSampleData(sampledatapath, false, storedstandards);       
            DataSelections = new List<DataSelection>();
            
        }

        /// <summary>
        /// Returns a dictionary containing the selected portions of the data series
        /// </summary>
        /// <returns></returns>
        public Dictionary<DataSelection, List<(double time, Dictionary<string, double> data)>> GetSelectedDataWithTime()
        {
            Dictionary<DataSelection, List<(double time, Dictionary<string, double> data)>> output = new Dictionary<DataSelection, List<(double time, Dictionary<string, double> data)>>();
            if (DataSelections.Count > 0)
            {
                foreach (DataSelection selection in DataSelections)
                {
                    output.Add(selection, new List<(double time, Dictionary<string, double> data)>());
                    foreach ((double time, Dictionary<string, double> data) data in TimeResolvedData)
                    {
                        if (data.time >= selection.Min && data.time <= selection.Max)
                            output[selection].Add(data);
                    }
                }
            }
            else
            {
                output.Add(new DataSelection("Whole dataset", (-1, -1), SelectionType.None), TimeResolvedData);
            }

            return output;
        }
        public Dictionary<DataSelection, List<Dictionary<string, double>>> GetAllSelectedData()
        {
            Dictionary<DataSelection, List<Dictionary<string, double>>> output = new Dictionary<DataSelection, List<Dictionary<string, double>>>();
            if (DataSelections.Count > 0)
            {
                foreach (DataSelection selection in DataSelections)
                {
                    output.Add(selection, new List<Dictionary<string, double>>());
                    foreach ((double time, Dictionary<string, double> data) data in TimeResolvedData)
                    {
                        if (data.time >= selection.Min && data.time <= selection.Max)
                            output[selection].Add(data.data);
                    }
                }
            }
            return output;
        }

        public List<Dictionary<string, double>> GetSelectedData(DataSelection selection)
        {
            List<Dictionary<string, double>> output = new List<Dictionary<string, double>>();
            foreach ((double time, Dictionary<string, double> data) data in TimeResolvedData)
            {
                if (data.time >= selection.Min && data.time <= selection.Max)
                    output.Add(data.data);
            }

            return output;
        }    
        private Dictionary<string, (double average, double stdev)> calculateSelectionStatistics(SelectionType selectiontype)
        {
            List<DataSelection> selections = DataSelections.FindAll(item => item.SelectionType == selectiontype);
            List<Dictionary<string, double>> input = new List<Dictionary<string, double>>();
            Dictionary<string, (double average, double stdev)> output = new Dictionary<string, (double average, double stdev)>();
            if (selections.Count > 0)
            {
                foreach (DataSelection selection in selections)
                {
                    input.AddRange(GetSelectedData(selection));
                }
                output = Calculations.CalculateSelectionAverageStdevFromElementDictList(input);
            }
            return output;
        }
        public Dictionary<string, (double average, double stdev)> GetBackground()
        {
            return calculateSelectionStatistics(SelectionType.Background);
        }
        public Dictionary<string, (double average, double stdev)> GetBackgroundCorrectedSignals()
        {
            var background = this.calculateSelectionStatistics(SelectionType.Background);
            var data = this.calculateSelectionStatistics(SelectionType.Data);
            return Calculations.SubstractBackground(background, data);
        }
  

        /// <summary>
        /// Returns the type of the sample in string format
        /// </summary>
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

        /// <summary>
        /// Load sample from file
        /// </summary>
        /// <param name="sampledatapath">Folder containing the tabulated acq. data</param>
        /// <param name="alreadysaved">Set to <b>true</b> to read newly acquired data (never analysed before). Set to <b>false/b> if there is a save file for it</param>
        public void LoadMeasuredSampleData(string sampledatapath, bool alreadysaved, List<StandardData> storedstandards)
        {
            string datafile = Path.GetFileNameWithoutExtension(sampledatapath) + ".csv";
            string finalPath = Path.Combine(sampledatapath, datafile);
            if (File.Exists(finalPath))
            {
                if (alreadysaved == false)
                {
                    //Load sample information from XML
                    string sampleInfoPath = Path.Combine(sampledatapath, "AcqData", "sample_info.xml");
                    XDocument sampleInfo = XDocument.Load(sampleInfoPath);
                    var fields = from field in sampleInfo.Descendants("Name")
                                 where field.Value == "Sample Name"
                                 select field.Parent;
                    var comment = from field in sampleInfo.Descendants("Name")
                                  where field.Value == "Comment"
                                  select field.Parent;
                    Comment = comment.ElementAt(0).Descendants("Value").ElementAt(0).Value;
                    SampleName = fields.ElementAt(0).Descendants("Value").ElementAt(0).Value;
                    DataFileName = Path.GetFileNameWithoutExtension(sampledatapath);
                    Rejected = false;
                    foreach (StandardData standard in storedstandards)
                    {
                        if (SampleName.Contains(standard.StandardName.Replace(" ", "")) || Comment.Contains(standard.StandardName.Replace(" ", "")))
                        {
                            StandardType = standard.StandardName;
                            TypeOfSample = SampleType.Standard;
                            break;
                        }
                        else
                        {
                            StandardType = null;
                            TypeOfSample = SampleType.Sample;
                        }
                    }
                    StandardLevel = -1;

                }

                List<(double time, Dictionary<string, double> data)> csvData = new List<(double time, Dictionary<string, double> data)>();
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
                        (double time, Dictionary<string, double> data) data;
                        Dictionary<string, double> measuredIntensities = new Dictionary<string, double>();
                        for (int i = 1; i < currentLine.Length; i++)
                        {
                            measuredIntensities.Add(header[i], Convert.ToDouble(currentLine[i], CultureInfo.CreateSpecificCulture("en-GB")));
                        }
                        data = (time: Convert.ToDouble(currentLine[0], CultureInfo.CreateSpecificCulture("en-GB")), data: measuredIntensities);
                        csvData.Add(data);
                    }
                }
                TimeResolvedData = csvData;
            }
        }
    }
}