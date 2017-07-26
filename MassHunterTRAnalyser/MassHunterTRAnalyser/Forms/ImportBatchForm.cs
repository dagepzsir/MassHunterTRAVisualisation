using MassHunterTRAnalyser.Data_Classes;
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

        private void button3_Click(object sender, EventArgs e)
        {
            var loadedData = loadNamesAndComments();

            for(int i = 0; i < loadedData.comments.Count; i++)
            {
                dataGridView1["sampleName", i].Value = loadedData.names[i];
                dataGridView1["sampleComment", i].Value = loadedData.comments[i];

                DataGridViewCheckBoxCell cell = (dataGridView1["checkColumn", i] as DataGridViewCheckBoxCell);
                if (loadedData.rejects[i] == true)
                    cell.Value = cell.TrueValue;
                else
                    cell.Value = cell.FalseValue;

                updateSample(i, loadedData.names[i], loadedData.comments[i], loadedData.rejects[i]);
            }
        }
        private void updateSample(int index, string name, string comment, bool rejected)
        {
            importedBatch.MeasuredData[index].SampleName = name;
            importedBatch.MeasuredData[index].Comment = comment;
            importedBatch.MeasuredData[index].Rejected = rejected;
        }
        private (List<string> names, List<string> comments, List<bool> rejects) loadNamesAndComments()
        {
            if (openXLSDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable data;
                if (openXLSDialog.FileName.Contains("xls"))
                {
                    ExcelFile file = new ExcelFile(openXLSDialog.FileName);
                    data = file.Data;
                }
                else
                {
                    CSV csv = new CSV(openXLSDialog.FileName);
                    data = csv.Data;
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

                return (samplenames, comments, reject);
            }
            else
                return (new List<string>(), new List<string>(), new List<bool>());
        }
    }
}
