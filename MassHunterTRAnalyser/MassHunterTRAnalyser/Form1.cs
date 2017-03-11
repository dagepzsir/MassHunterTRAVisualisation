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
        static Batch selectedBatch;

        private void openBtn_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if(folderBrowserDialog1.SelectedPath.Contains(".b"))
                {
                    selectedBatch = new Batch(folderBrowserDialog1.SelectedPath);
                    foreach (SampleData data in selectedBatch.MeasuredData)
                    {
                        listView1.Items.Add(new ListViewItem(new string[] {data.DataFileName, data.SampleName }));
                    }
                    
                }
            }
        }
    }
}
