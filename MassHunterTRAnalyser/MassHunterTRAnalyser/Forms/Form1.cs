using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassHunterTRAnalyser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Local variables
        public Batch selectedBatch;
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
                    OnDataLoaded(new DataLoadedEventArgs(ref selectedBatch));
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
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                userControl11.PopulateListBox();
            }
        }
    }

    public class DataLoadedEventArgs: EventArgs
    {
        public Batch LoadedBatch;
        public DataLoadedEventArgs(ref Batch loadeddata)
        {
            LoadedBatch = loadeddata;
        }
    }
}
