using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MassHunterTRAnalyser.Data_Classes;

namespace MassHunterTRAnalyser
{
    public partial class SampleTypeControl : UserControl
    {
        public SampleTypeControl()
        {
            InitializeComponent();
        }

        Batch loadedBatch;
        List<StandardData> StoredStandards;
        #region Events
        public void SampleTypeControl_DataLoaded(object sender, DataLoadedEventArgs e)
        {
            loadedBatch = e.LoadedBatch;
            StoredStandards = e.StoredStandards;
            loadStandardNames();
            loadSampleData();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                updateSampleData(e.RowIndex);
                if(e.ColumnIndex == 2)
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
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Fix combobox behaviour
            if (e.RowIndex > -1 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                if (dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor == dataGridView1[e.ColumnIndex, e.RowIndex].OwningColumn.DefaultCellStyle.BackColor)
                {
                    dataGridView1.BeginEdit(true);
                    ((ComboBox)dataGridView1.EditingControl).DroppedDown = true;
                }
            }
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() != "Standard")
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
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //Fix combobox behaviour
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void enableCell(DataGridViewCell cell, bool enabled)
        {
            if(cell is DataGridViewComboBoxCell)
            {
                if(enabled)
                {
                    (cell as DataGridViewComboBoxCell).DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    (cell as DataGridViewComboBoxCell).ReadOnly = false;
                    (cell as DataGridViewComboBoxCell).Style.BackColor = cell.OwningColumn.DefaultCellStyle.BackColor;
                    (cell as DataGridViewComboBoxCell).Style.ForeColor = cell.OwningColumn.DefaultCellStyle.ForeColor;
                    cell.Style.SelectionBackColor = cell.OwningColumn.DefaultCellStyle.SelectionBackColor;
                    cell.Style.SelectionForeColor = cell.OwningColumn.DefaultCellStyle.SelectionForeColor;
                }
                else
                {
                    (cell as DataGridViewComboBoxCell).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    (cell as DataGridViewComboBoxCell).ReadOnly = true;
                    (cell as DataGridViewComboBoxCell).Style.BackColor = Color.LightGray;
                    (cell as DataGridViewComboBoxCell).Style.ForeColor = Color.DarkGray;
                    cell.Style.SelectionBackColor = Color.LightGray;
                    cell.Style.SelectionForeColor = Color.DarkGray;
                }
            }
            else
            {
                if (enabled)
                {
                    cell.ReadOnly = false;
                    cell.Style.BackColor = cell.OwningColumn.DefaultCellStyle.BackColor;
                    cell.Style.ForeColor = cell.OwningColumn.DefaultCellStyle.ForeColor;
                    cell.Style.SelectionBackColor = cell.OwningColumn.DefaultCellStyle.SelectionBackColor;
                    cell.Style.SelectionForeColor = cell.OwningColumn.DefaultCellStyle.SelectionForeColor;
                }
                else
                {
                    cell.ReadOnly = true;
                    cell.Style.BackColor = Color.LightGray;
                    cell.Style.ForeColor = Color.DarkGray;
                    cell.Style.SelectionBackColor = Color.LightGray;
                    cell.Style.SelectionForeColor = Color.DarkGray;
                }
            }
            
        }
        #endregion

        private void updateSampleData(int index)
        {
            SampleData changedSample = loadedBatch.MeasuredData[index];
            SampleType sampleType = SampleType.NotSet;
            switch (dataGridView1[2, index].Value.ToString())
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
            changedSample.SampleName = dataGridView1[1, index].Value.ToString();
            changedSample.TypeOfSample = sampleType;
            changedSample.StandardLevel = int.Parse(dataGridView1[3, index].Value.ToString());
            if (dataGridView1[4, index].Value != null)
                changedSample.StandardType = dataGridView1[4, index].Value.ToString();
            else
                changedSample.StandardType = "";
        }
        private void loadSampleData()
        {
            if(loadedBatch != null)
            {
                foreach (SampleData sampleData in loadedBatch.MeasuredData)
                {
                    dataGridView1.Rows.Add(sampleData.DataFileName, sampleData.SampleName, sampleData.SampleTypeString, sampleData.StandardLevel, sampleData.StandardType);
                    updateSampleData(dataGridView1.Rows.Count - 1);
                }
            }
            else
            {
                MessageBox.Show("Nothing loaded!");
            }
        }
        private void loadStandardNames()
        {
            foreach (StandardData standard in StoredStandards)
            {
                (dataGridView1.Columns[4] as DataGridViewComboBoxColumn).Items.Add(standard.StandardName);
            }
        }


    }
}
