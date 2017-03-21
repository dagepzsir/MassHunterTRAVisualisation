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
        }

        //Local variables
        private Batch selectedBatch;
        public List<StandardData> StoredStandards;
        public event EventHandler<DataLoadedEventArgs> DataLoaded;
        protected virtual void OnDataLoaded(DataLoadedEventArgs e)
        {
            EventHandler<DataLoadedEventArgs> handler = DataLoaded;
            if (handler != null)
                handler(this, e);
        }

        #region FormEvents
        private void openBtn_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sampleTypeControl1.Reset();

                if (folderBrowserDialog1.SelectedPath.Contains(".b"))
                {
                    //Load selected batch from disk
                    selectedBatch = new Batch(folderBrowserDialog1.SelectedPath, StoredStandards);
                    //Trigger DataLoaded event
                    OnDataLoaded(new DataLoadedEventArgs(ref selectedBatch, ref StoredStandards));
                    saveToolStripMenuItem.Enabled = true;
                }
                if (!selectedBatch.AlreadySaved)
                {
                    if (MessageBox.Show("Do you want to load sample names and comments from MassHunter DA table export? (If you modified the names/comments after the batch was added to the queue this is required!)", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        loadNewNamesAndComments();
                    }
                }
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            userControl11.UpdateData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Wire in DatLoaded event handlers from controls
            this.DataLoaded += sampleTypeControl1.SampleTypeControl_DataLoaded;
            this.DataLoaded += userControl11.UserControl1_DataLoaded;

            //Load StandardData
            StoredStandards = new List<StandardData>();
            if (Settings.Default.StandardData != "")
                StoredStandards = JsonConvert.DeserializeObject<List<StandardData>>(Settings.Default.StandardData);

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Populate range selection listbox of tab opened
            if(tabControl1.SelectedIndex == 1)
                userControl11.PopulateListBox();
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
        #endregion

        private void saveWork()
        {    
            using (StreamWriter sw = new StreamWriter(Path.Combine(folderBrowserDialog1.SelectedPath, "analysis.json"), false))
            {
                //Serialize sample data to a json and save it to ~\analysis.json
                string serialized = JsonConvert.SerializeObject(selectedBatch.MeasuredData);
                sw.WriteLine(serialized);
            }
        }

        private void loadSampleNamesFromXlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadNewNamesAndComments();
        }

        private void loadNewNamesAndComments()
        {
            if (openXLSDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable data;
                if(openXLSDialog.FileName.Contains("xls"))
                {
                    ExcelFile file = new ExcelFile(openXLSDialog.FileName);
                    data = file.XLSData;
                }
                else
                {
                    CSV csv = new CSV(openXLSDialog.FileName);
                    data = csv.CSVData;
                }
                List<string> comments = new List<string>();
                List<string> samplenames = new List<string>();
                List<bool> reject = new List<bool>();
                int commentColumn = 0;
                int nameColumn = 0;
                int rjctColumn = 0;
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    if (data.Rows[1][i].ToString() == "Comment")
                        commentColumn = i;
                    else if (data.Rows[1][i].ToString() == "Sample Name")
                        nameColumn = i;
                    else if (data.Rows[1][i].ToString() == "Rjct")
                        rjctColumn = i;
                }
                for (int i = 2; i < data.Rows.Count; i++)
                {
                    comments.Add(data.Rows[i][commentColumn].ToString());
                    samplenames.Add(data.Rows[i][nameColumn].ToString());
                    if (data.Rows[i][rjctColumn].ToString() == "true")
                    {
                        reject.Add(true);
                    }
                    else
                        reject.Add(false);
                }
                

                sampleTypeControl1.SetSampleNameCommentsRjct(samplenames, comments, reject);
            }
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
