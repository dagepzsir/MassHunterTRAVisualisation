﻿using System;
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
            LoadStandardNames();
            loadSampleData();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                updateSampleData(e.RowIndex);
                if(dataGridView1.Columns[e.ColumnIndex].Name == "sampleType")
                {
                    if(dataGridView1.Rows[e.RowIndex].Cells["sampleType"].Value.ToString() != "Standard")
                    {
                        enableCell(dataGridView1.Rows[e.RowIndex].Cells["standardLevel"], false);
                        enableCell(dataGridView1.Rows[e.RowIndex].Cells["standardType"], false);
                    }
                    else
                    {
                        enableCell(dataGridView1.Rows[e.RowIndex].Cells["standardLevel"], true);
                        enableCell(dataGridView1.Rows[e.RowIndex].Cells["standardType"], true);
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
            if (dataGridView1.Rows[e.RowIndex].Cells["sampleType"].Value.ToString() != "Standard")
            {
                enableCell(dataGridView1.Rows[e.RowIndex].Cells["standardLevel"], false);
                enableCell(dataGridView1.Rows[e.RowIndex].Cells["standardType"], false);
            }
            else
            {
                enableCell(dataGridView1.Rows[e.RowIndex].Cells["standardLevel"], true);
                enableCell(dataGridView1.Rows[e.RowIndex].Cells["standardType"], true);
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
        public void Reset()
        {
            dataGridView1.Rows.Clear();
        }
        #endregion
        private void updateSampleData(int index)
        {
            SampleData changedSample = loadedBatch.MeasuredData[index];
            SampleType sampleType = SampleType.NotSet;
            switch (dataGridView1["sampleType", index].Value.ToString())
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
            changedSample.SampleName = dataGridView1["sampleName", index].Value.ToString();
            changedSample.TypeOfSample = sampleType;
            DataGridViewCheckBoxCell chkBoxCell = (dataGridView1[0, index] as DataGridViewCheckBoxCell);
            bool value;
            if (chkBoxCell.Value.ToString() == "True")
                value = true;
            else
                value = false;
            if (chkBoxCell.Value != chkBoxCell.IndeterminateValue)
            {
                if (value == true)
                {
                    changedSample.Rejected = false;
                    for (int i = 1; i < dataGridView1.Columns.Count; i++)
                    {
                        enableCell(dataGridView1[i, index], true);

                    }
                    if(sampleType != SampleType.Standard)
                    {
                        enableCell(dataGridView1["standardLevel", index], false);
                        enableCell(dataGridView1["standardType", index], false);
                    }
                }
                else
                {
                    changedSample.Rejected = true;
                    for(int i = 1; i < dataGridView1.Columns.Count; i++)
                    {
                        enableCell(dataGridView1[i, index], false);
                    }
                }
            }

            changedSample.Comment = dataGridView1["sampleComment", index].Value.ToString();
            changedSample.StandardLevel = int.Parse(dataGridView1["standardLevel", index].Value.ToString());
            if (dataGridView1["standardType", index].Value != null)
                changedSample.StandardType = dataGridView1["standardType", index].Value.ToString();
            else
                changedSample.StandardType = "";
        }
        public void SetSampleNameCommentsRjct(List<string> samplenames, List<string> comments, List<bool> reject)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string newname = samplenames[i];
                string newcomment = comments[i];
                dataGridView1["sampleName", i].Value = newname;
                dataGridView1["sampleComment", i].Value = newcomment;

                DataGridViewCheckBoxCell cell = (dataGridView1["rjctSample", i] as DataGridViewCheckBoxCell);
                if (reject[i] == false)
                    cell.Value = cell.TrueValue;
                else
                    cell.Value = cell.FalseValue;

                foreach (StandardData standard in StoredStandards)
                {
                    if (newname.Replace(" ", "").ToLower().Contains(standard.StandardName.Replace(" ", "").ToLower()) || newcomment.Replace(" ", "").ToLower().Contains(standard.StandardName.Replace(" ", "").ToLower()))
                    {
                        dataGridView1["sampleType", i].Value = "Standard";
                        dataGridView1["standardType", i].Value = standard.StandardName;
                        break;
                    }

                }
            }
        }
        private void loadSampleData()
        {
            if(loadedBatch != null)
            {
                foreach (SampleData sampleData in loadedBatch.MeasuredData)
                {
                    bool rjctCellValue;
                    if (sampleData.Rejected == true)
                        rjctCellValue = false;
                    else
                        rjctCellValue = true;

                    dataGridView1.Rows.Add(rjctCellValue, sampleData.DataFileName, sampleData.SampleName, sampleData.Comment ,sampleData.SampleTypeString, sampleData.StandardLevel, sampleData.StandardType);
                    updateSampleData(dataGridView1.Rows.Count - 1);
                }
            }
            else
            {
                MessageBox.Show("Nothing loaded!");
            }
        }
        public void LoadStandardNames()
        {
            (dataGridView1.Columns["standardType"] as DataGridViewComboBoxColumn).Items.Clear();
            if (StoredStandards != null)
            {
                foreach (StandardData standard in StoredStandards)
                {
                    (dataGridView1.Columns["standardType"] as DataGridViewComboBoxColumn).Items.Add(standard.StandardName);
                }
            }
        }
    }
}
