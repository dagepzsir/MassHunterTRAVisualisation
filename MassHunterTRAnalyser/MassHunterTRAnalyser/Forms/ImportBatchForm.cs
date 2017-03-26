using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassHunterTRAnalyser.Forms
{
    public partial class ImportBatchForm : Form
    {
        public ImportBatchForm(Batch imported)
        {
            InitializeComponent();
            importedBatch = imported;
        }

        Batch importedBatch;
        public List<SampleData> SampleDataToImport = new List<SampleData>();
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if(dataGridView1["checkColumn",i].Value.ToString() == "True")
                {
                    SampleDataToImport.Add(importedBatch.MeasuredData[i]);
                }
            }
        }

        private void ImportBatchForm_Load(object sender, EventArgs e)
        {
            foreach (SampleData sample in importedBatch.MeasuredData)
            {
                dataGridView1.Rows.Add(true, sample.SampleName, sample.Comment, sample.DataFileName);
            }
        }
    }
}
