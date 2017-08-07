using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MassHunterTRAnalyser.Forms;
using MassHunterTRAnalyser.Data_Classes;
using Newtonsoft.Json;
using MassHunterTRAnalyser.Properties;
using System.IO;
using Newtonsoft.Json.Converters;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MassHunterTRAnalyser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //this.DataLoaded += sampleTypeControl1.SampleTypeControl_DataLoaded;
            this.DataLoaded += selectionControl.UserControl1_DataLoaded;
            this.DataLoaded += averagesControl.AveragesControlDataLoaded;
            this.DataLoaded += calibrationControl1.CalibrationControlDataLoaded;
            this.DataLoaded += sampleTypeContontrolV21.SampleTypeControl_DataLoaded;
            //sampleTypeControl1.SampleDataChanged += averagesControl.SampleTypeControl1_SampleGroupsChanged;
            //sampleTypeControl1.SampleDataChanged += calibrationControl1.SampleTypeControl1_SampleGroupsChanged;

        }

        //Local variables
        private Batch selectedBatch;
        public List<StandardData> StoredStandards;
        public event EventHandler<DataLoadedEventArgs> DataLoaded;
        protected virtual void OnDataLoaded(DataLoadedEventArgs e)
        {
            DataLoaded?.Invoke(this, e);
        }

        #region FormEvents
        private void openBtn_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //sampleTypeControl1.Reset();

                if (folderBrowserDialog1.SelectedPath.Contains(".b"))
                {

                    //Load selected batch from disk
                    selectedBatch = new Batch(folderBrowserDialog1.SelectedPath, StoredStandards);
                    //Trigger DataLoaded event
                    OnDataLoaded(new DataLoadedEventArgs(ref selectedBatch, ref StoredStandards));
                    saveToolStripMenuItem.Enabled = true;
                }
                else
                {
                    MessageBox.Show("The selected folder is not a valid MassHunter batch!");
                }
            }
        }
  

        private void Form1_Load(object sender, EventArgs e)
        {
            //Wire in DatLoaded event handlers from controls
            
            //Load StandardData
            StoredStandards = new List<StandardData>();
            if (Settings.Default.StandardData != "")
                StoredStandards = JsonConvert.DeserializeObject<List<StandardData>>(Settings.Default.StandardData);

        }
        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Populate range selection listbox of tab opened
            if (tabControl1.SelectedIndex == 1)
            {
                selectionControl.PopulateListBox();
                if (selectionControl.listView1.Items.Count > 0)
                {
                    selectionControl.listView1.Items[selectionControlLisViewIndex].Selected = true;
                }
                selectionControl.listView1.Select();

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["averagesTab"])
            {
                if(averagesTreeSelectedNode != null)
                    averagesControl.sampleTree.SelectedNode = averagesTreeSelectedNode;
                averagesControl.sampleTree.Select();
                averagesControl.UpdateControl();
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["calibrationTab"])
            {
                calibrationControl1.UpdateCalibration();
            }
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm(StoredStandards);
            optionsForm.ShowDialog(this);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveWork();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (selectionControl.listView1.SelectedIndices.Count > 0)
                selectionControlLisViewIndex = selectionControl.listView1.SelectedIndices[0];
            averagesTreeSelectedNode = averagesControl.sampleTree.SelectedNode;
        }

        private void loadSampleNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //loadNewNamesAndComments();
        }

        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog1.SelectedPath != selectedBatch.FolderPath)
                {
                    Batch importFrom = new Batch(folderBrowserDialog1.SelectedPath, StoredStandards);
                    ImportBatchForm importForm = new ImportBatchForm(importFrom);

                    if (importForm.ShowDialog() == DialogResult.OK)
                    {
                        List<SampleData> importedData = importForm.SampleDataToImport;
                        string lastDataFile = selectedBatch.MeasuredData.Last().DataFileName;

                        foreach (SampleData sample in importedData)
                        {
                            string folderName = generateDataFileName(lastDataFile, importedData.IndexOf(sample) + 1);
                            string newSampleFolderInSelectedBatch = Path.Combine(selectedBatch.FolderPath, folderName + ".d");
                            string sourcePath = Path.Combine(folderBrowserDialog1.SelectedPath, sample.DataFileName + ".d");

                            Directory.CreateDirectory(newSampleFolderInSelectedBatch);
                            foreach (string folder in Directory.GetDirectories(sourcePath))
                            {
                                Directory.CreateDirectory(folder.Replace(sourcePath, newSampleFolderInSelectedBatch));
                            }
                            foreach (string file in Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories))
                            {
                                if (file.Contains("csv") == false)
                                    File.Copy(file, file.Replace(sourcePath, newSampleFolderInSelectedBatch));
                                else
                                    File.Copy(file, file.Replace(sourcePath, newSampleFolderInSelectedBatch).Replace(sample.DataFileName, folderName));

                            }

                            sample.DataFileName = folderName;

                            selectedBatch.MeasuredData.Add(sample);
                        }
                        OnDataLoaded(new DataLoadedEventArgs(ref selectedBatch, ref StoredStandards));
                    }
                }
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveWork();
        }
        #endregion

        private void saveWork()
        {
            if (selectedBatch != null)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(selectedBatch.FolderPath, "analysis.json"), false))
                {
                    //Serialize sample data to a json and save it to ~\analysis.json
                    string serialized = JsonConvert.SerializeObject(selectedBatch.MeasuredData);
                    sw.WriteLine(serialized);
                }
            }
        }

        int selectionControlLisViewIndex;
        TreeNode averagesTreeSelectedNode;
        
        private string generateDataFileName(string lastName, int increment)
        {
            List<char> charList = lastName.ToCharArray().ToList();
            charList.RemoveAll(item => Char.IsLetter(item));
            int dataFileStartingDigit = Utils.ConvertToInt32(new string(charList.ToArray()));
            string stringszam = (dataFileStartingDigit + increment).ToString();
            while (stringszam.Length < 3)
                stringszam = stringszam.Insert(0, "0");
            string output = string.Format("{0}SMPL", stringszam);

            return output;
        }
        private void importSampleData(List<SampleData> datatoimport)
        {

        }
    }
    public class DataLoadedEventArgs: EventArgs
    {
        public Batch LoadedBatch;
        public List<StandardData> StoredStandards;
        public DataLoadedEventArgs(ref Batch loadeddata, ref List<StandardData> storedstandards)
        {
            LoadedBatch = loadeddata;
            StoredStandards = storedstandards;
        }
    }
}
