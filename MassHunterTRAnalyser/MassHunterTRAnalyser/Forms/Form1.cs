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

namespace MassHunterTRAnalyser
{
    public partial class Form1 : Form
    {
        public Form1()
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
        private void openBtn_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if(folderBrowserDialog1.SelectedPath.Contains(".b"))
                {
                    selectedBatch = new Batch(folderBrowserDialog1.SelectedPath);

                    OnDataLoaded(new DataLoadedEventArgs(ref selectedBatch, ref StoredStandards));
                    saveToolStripMenuItem.Enabled = true;
                }
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            userControl11.UpdateData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DataLoaded += sampleTypeControl1.SampleTypeControl_DataLoaded;
            this.DataLoaded += userControl11.UserControl1_DataLoaded;

            //Load StandardData
            StoredStandards = new List<StandardData>();
            if (Settings.Default.StandardData != "")
                StoredStandards = JsonConvert.DeserializeObject<List<StandardData>>(Properties.Settings.Default.StandardData);

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                userControl11.PopulateListBox();
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

        private void saveWork()
        {
            
            using (StreamWriter sw = new StreamWriter(Path.Combine(folderBrowserDialog1.SelectedPath, "analysis.json"), false))
            {
                string serialized = JsonConvert.SerializeObject(selectedBatch.MeasuredData);
                sw.WriteLine(serialized);
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
