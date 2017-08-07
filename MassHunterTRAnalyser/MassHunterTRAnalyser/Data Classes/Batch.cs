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
using System.Data;

namespace MassHunterTRAnalyser
{
    public class Batch
    {
        public List<SampleData> MeasuredData { get; set; }
        public List<SampleGroup> SampleGroups { get; set; }
        public BindingSource DataSource { get { return new BindingSource(MeasuredData, null); } }

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
            SampleGroups = new List<SampleGroup>();

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

                    SampleGroup group = SampleGroups.Find(item => item.GroupName == data.SampleGroup);
                    if (group == null)
                    {
                        group = new SampleGroup(data.SampleGroup);
                        SampleGroups.Add(group);
                    }
                    group.AddSample(data);
                }
                MeasuredData = storedData;
            }
            else
            {
                MeasuredData = new List<SampleData>();
                
                AlreadySaved = false;


                DataTable sampleNamesAndComments = null;
                int commentColumn = 0;
                int nameColumn = 0;
                int rjctColumn = 0;
                int sampleTypeColumn = 0;

                if (MessageBox.Show("Do you want to load sample names and comments from MassHunter DA table export? (If you modified the names/comments after the batch was added to the queue this is required!)", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    OpenFileDialog openXLSDialog = new OpenFileDialog();

                    if (openXLSDialog.ShowDialog() == DialogResult.OK)
                    {
                        
                        IData fileData;
                        if (openXLSDialog.FileName.Contains("xls"))
                            fileData = new ExcelFile(openXLSDialog.FileName);
                        else
                            fileData = new CSV(openXLSDialog.FileName);
                        sampleNamesAndComments = fileData.Data;
                        
                        for (int i = 0; i < sampleNamesAndComments.Columns.Count; i++)
                        {
                            switch (sampleNamesAndComments.Rows[1][i].ToString())
                            {
                                case "Comment":
                                    commentColumn = i;
                                    break;
                                case "Sample Name":
                                    nameColumn = i;
                                    break;
                                case "Rjct":
                                    rjctColumn = i;
                                    break;
                                case "Type":
                                    sampleTypeColumn = i;
                                    break;
                            }
                            
                        }
                    }
                }
                foreach (string dataFileFolder in dataFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(dataFileFolder);
                    if (File.Exists(Path.Combine(dataFileFolder, fileName + ".csv")))
                    {
                        SampleData currentData = new SampleData(dataFileFolder, storedstandards);
                        if(sampleNamesAndComments != null)
                        {
                            currentData.SampleName = sampleNamesAndComments.Rows[dataFiles.IndexOf(dataFileFolder) + 2][nameColumn].ToString();
                            currentData.Comment = sampleNamesAndComments.Rows[dataFiles.IndexOf(dataFileFolder) + 2][commentColumn].ToString();
                            currentData.TypeOfSample = (SampleType)Enum.Parse(typeof(SampleType), sampleNamesAndComments.Rows[dataFiles.IndexOf(dataFileFolder) + 2][sampleTypeColumn].ToString());

                            if (sampleNamesAndComments.Rows[dataFiles.IndexOf(dataFileFolder)][rjctColumn].ToString() == "true")
                            {
                                currentData.Rejected = true;
                            }
                            else
                                currentData.Rejected = false;
                        }

                        MeasuredData.Add(currentData);

                        SampleGroup group = null;

                        if (SampleGroups.Count > 0)
                             group = SampleGroups.Find(item => item.Samples[0].SampleName == currentData.SampleName && item.Samples[0].Comment == currentData.Comment);
                        
                        if (group != null)
                        {
                            currentData.SampleGroup = group.GroupName;
                            group.AddSample(currentData);
                        }
                        else
                        {
                            group = new SampleGroup(dataFiles.IndexOf(dataFileFolder).ToString());
                            currentData.SampleGroup = group.GroupName;
                            group.AddSample(currentData);
                            SampleGroups.Add(group);
                        }
                    }
                }
            }
        }
    }
}