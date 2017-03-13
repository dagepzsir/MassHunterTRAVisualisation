using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassHunterTRAnalyser
{
    public partial class SampleTypeControl : UserControl
    {
        public SampleTypeControl()
        {
            InitializeComponent();
        }

        Batch loadedBatch;

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                updateSampleData(e.RowIndex);
                if(e.RowIndex == 2)
                {
                    if(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() != "Standard")
                    {
                        enableCell(dataGridView1.Rows[e.RowIndex].Cells[3], false);
                        enableCell(dataGridView1.Rows[e.RowIndex].Cells[4], false);
                    }
                    else
                    {
                        enableCell(dataGridView1.Rows[e.RowIndex].Cells[3], true);
                        enableCell(dataGridView1.Rows[e.RowIndex].Cells[4], true);
                    }
                }
            }
        }
        private void SampleTypeControl_Load(object sender, EventArgs e)
        {
            loadStandardLibrary();
        }


        public void SampleTypeControl_DataLoaded(object sender, DataLoadedEventArgs e)
        {
            loadedBatch = e.LoadedBatch;
            loadSampleData();
        }
        
        private void enableCell(DataGridViewCell cell, bool enabled)
        {
            cell.ReadOnly = true;
            if(enabled)
            {
                cell.Style.BackColor = cell.OwningColumn.DefaultCellStyle.BackColor;
                cell.Style.ForeColor = cell.OwningColumn.DefaultCellStyle.ForeColor;
            }
            else
            {
                cell.Style.BackColor = Color.LightGray;
                cell.Style.ForeColor = Color.DarkGray;
            }
        }

        public void SaveTypeChanges()
        {

        }

        private void loadStandardLibrary()
        {

        }

        private void updateSampleData(int index)
        {
            SampleData changedSample = loadedBatch.MeasuredData[index];
            SampleType sampleType = SampleType.NotSet;
            switch (dataGridView1.Rows[index].Cells[2].Value.ToString())
            {
                case "Not set":
                    sampleType = SampleType.NotSet;
                    break;
                case "Blank":
                    sampleType = SampleType.Blank;
                    break;
                case "Sample":
                    sampleType = SampleType.Sample;
                    break;
                case "Standard":
                    sampleType = SampleType.Standard;
                    break;
            }
            changedSample.SampleName = dataGridView1.Rows[index].Cells[1].Value.ToString();
            changedSample.TypeOfSample = sampleType;
            changedSample.StandardLevel = int.Parse(dataGridView1.Rows[index].Cells[3].Value.ToString());
            changedSample.StandardType = dataGridView1.Rows[index].Cells[4].Value.ToString();
        }
        private void loadSampleData()
        {
            if(loadedBatch != null)
            {
                foreach (SampleData sampleData in loadedBatch.MeasuredData)
                {

                    dataGridView1.Rows.Add(sampleData.DataFileName, sampleData.SampleName, "Sample", -1, "NIST 614");
                    updateSampleData(dataGridView1.Rows.Count - 1);
                }
            }
            else
            {
                MessageBox.Show("Nothing loaded!");
            }
        }


        //Enable one-click enter to combobox
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                dataGridView1.BeginEdit(true);
                ((ComboBox)dataGridView1.EditingControl).DroppedDown = true;
            }
        }
    }
}
