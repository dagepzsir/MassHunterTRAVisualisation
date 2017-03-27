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
        public event EventHandler<SampleDataChangedEventArgs> SampleDataChanged;
        protected virtual void OnSampleGroupsChanged(SampleDataChangedEventArgs e)
        {
            SampleDataChanged?.Invoke(this, e);
        }

        Batch loadedBatch;
        List<StandardData> StoredStandards;
        List<SampleGroup> SampleGroups = new List<SampleGroup>();
        string oldSampleGroup;
        List<int> levels = new List<int>();
        #region Events
        public void SampleTypeControl_DataLoaded(object sender, DataLoadedEventArgs e)
        {
            loadedBatch = e.LoadedBatch;
            StoredStandards = e.StoredStandards;
            LoadStandardNames();
            loadSampleData();
            constructGroups();
            populateSampleGroupTree();
        }

        private void populateSampleGroupTree()
        {
            sampleTree.Nodes.Clear();
            foreach (SampleGroup group in SampleGroups)
            {
                sampleTree.Nodes.Add(group.GroupName, group.GroupName + " - " + group.GroupType);
                if(group.RejectedGroup)
                    sampleTree.Nodes[sampleTree.Nodes.Count - 1].BackColor = Color.LightGray;
                foreach (SampleData sample in group.Samples)
                {
                    TreeNode parent = sampleTree.Nodes[sampleTree.Nodes.Count - 1];
                    parent.Nodes.Add(sample.DataFileName, sample.DataFileName + " -" + sample.SampleName + " (" + sample.SampleTypeString + ")");
                    if (sample.Rejected)
                        parent.Nodes[parent.Nodes.Count - 1].BackColor = Color.LightGray;
                }
            }
            sampleTree.ExpandAll();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void disableRejectedSampleLine(int rowindex)
        {
            DataGridViewCheckBoxCell chkBoxCell = (dataGridView1["rjctSample", rowindex] as DataGridViewCheckBoxCell);
            bool value;
            if (chkBoxCell.Value.ToString() == "True")
                value = true;
            else
                value = false;

            if (value == true)
            {
                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                {
                    enableCell(dataGridView1[i, rowindex], true);

                }
                if (dataGridView1["sampleType", rowindex].Value.ToString() != "Standard")
                {
                    enableCell(dataGridView1["standardLevel", rowindex], false);
                    enableCell(dataGridView1["standardType", rowindex], false);
                }
            }
            else
            {
                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                {
                    if(dataGridView1[i, rowindex].OwningColumn.Name != "sampleGroup")
                        enableCell(dataGridView1[i, rowindex], false);
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
            if(dataGridView1.SelectedCells[0].OwningColumn is DataGridViewComboBoxColumn || dataGridView1.SelectedCells[0].OwningColumn is DataGridViewCheckBoxColumn)
            {
                dataGridView1.EndEdit();
            }
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
            SampleGroups.Clear();
            sampleTree.Nodes.Clear();
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

            changedSample.Rejected = !value;

            if (dataGridView1["sampleGroup", index].Value != null)
                changedSample.SampleGroup = dataGridView1["sampleGroup", index].Value.ToString();
            else
                changedSample.SampleGroup = "";

            changedSample.Comment = dataGridView1["sampleComment", index].Value.ToString();

            if (dataGridView1["standardLevel", index].Value != null)
                changedSample.StandardLevel = Utils.ConvertToInt32(dataGridView1["standardLevel", index].Value);
            else
                changedSample.StandardLevel = -1;
            if (dataGridView1["standardType", index].Value != null)
                changedSample.StandardType = dataGridView1["standardType", index].Value.ToString();
            else
                changedSample.StandardType = "";
        }
        public void SetSampleNameCommentsRjct(List<string> samplenames, List<string> comments, List<bool> reject)
        {
            for (int i = 0; i < samplenames.Count; i++)
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
                updateSampleData(i);

                
                string sampleGroup = getSampleGroup(loadedBatch.MeasuredData[i], true);
                dataGridView1["sampleGroup", i].Value = sampleGroup;
                updateSampleData(i);
            }
            constructGroups();
        }
        private void loadSampleData()
        {
            if(loadedBatch != null)
            {
                dataGridView1.Rows.Clear();
                foreach (SampleData sampleData in loadedBatch.MeasuredData)
                {
                    bool rjctCellValue;
                    if (sampleData.Rejected == true)
                        rjctCellValue = false;
                    else
                        rjctCellValue = true;

                    string sampleGroupName = getSampleGroup(sampleData, false);

                    dataGridView1.Rows.Add(rjctCellValue, sampleData.DataFileName, sampleData.SampleName, sampleData.Comment, sampleData.SampleTypeString, sampleData.StandardLevel, sampleData.StandardType, sampleGroupName);
                    if (levels.Contains(sampleData.StandardLevel) == false)
                        levels.Add(sampleData.StandardLevel);
                    //Construct sample groups
                    SampleGroup existingGroup = SampleGroups.Find(item => item.GroupName == sampleData.SampleGroup);
                    if (existingGroup != null)
                    {
                        if (existingGroup.Samples.Contains(sampleData) == false)
                            existingGroup.AddSample(sampleData);
                    }
                    else
                    {
                        SampleGroup newGroup = new SampleGroup(loadedBatch.MeasuredData.IndexOf(sampleData).ToString());
                        newGroup.AddSample(sampleData);
                        SampleGroups.Add(newGroup);
                    }
                    disableRejectedSampleLine(dataGridView1.Rows.Count - 1);
                }
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Nothing loaded!");
            }
        }

        private string getSampleGroup(SampleData sampleData, bool newgroups)
        {
            string sampleGroupName = "";

            if (sampleData.SampleGroup == null || newgroups == true)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (sampleData.SampleName == dataGridView1["sampleName", i].Value.ToString() && sampleData.Comment == dataGridView1["sampleComment", i].Value.ToString())
                        {
                            sampleGroupName = dataGridView1["sampleGroup", i].Value.ToString();
                            break;
                        }
                        else
                            sampleGroupName = loadedBatch.MeasuredData.IndexOf(sampleData).ToString();
                    }
                }
                else
                {
                    sampleGroupName = loadedBatch.MeasuredData.IndexOf(sampleData).ToString();
                }
            }
            else
                sampleGroupName = sampleData.SampleGroup;

            return sampleGroupName;
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "rjctSample")
                {
                    disableRejectedSampleLine(e.RowIndex);
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "sampleType")
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

            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "standardLevel")
            {
                SampleGroup group = SampleGroups.Find(item => item.GroupName == dataGridView1["sampleGroup", e.RowIndex].Value.ToString());
                foreach (var sample in group.Samples)
                {
                    dataGridView1["standardLevel", loadedBatch.MeasuredData.IndexOf(sample)].Value = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
                    sample.StandardLevel = Utils.ConvertToInt32(dataGridView1[e.ColumnIndex, e.RowIndex].Value);
                }
                if (levels.Contains(Utils.ConvertToInt32(dataGridView1[e.ColumnIndex, e.RowIndex].Value)) == false)
                    levels.Add(Utils.ConvertToInt32(dataGridView1[e.ColumnIndex, e.RowIndex].Value));

                OnSampleGroupsChanged(new SampleDataChangedEventArgs(SampleGroups, levels));
                constructGroups();
            }
            if(dataGridView1.Columns[e.ColumnIndex].Name == "sampleGroup")
                constructGroups();
            updateSampleData(e.RowIndex);
            populateSampleGroupTree();
        }
        private void constructGroups()
        {
            SampleGroups.Clear();
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                SampleGroup existingGroup = SampleGroups.Find(item => item.GroupName == dataGridView1["sampleGroup", i].Value.ToString());
                if (existingGroup != null)
                {
                    existingGroup.AddSample(loadedBatch.MeasuredData[i]);
                    if (existingGroup.Samples.Last().Rejected == false)
                        existingGroup.RejectedGroup = false;
                }
                else
                {
                    SampleGroup newGroup = new SampleGroup(loadedBatch.MeasuredData[i].SampleGroup);
                    newGroup.AddSample(loadedBatch.MeasuredData[i]);
                    if (newGroup.Samples.Last().Rejected == false)
                        newGroup.RejectedGroup = false;
                    SampleGroups.Add(newGroup);
                
                }
            }
            OnSampleGroupsChanged(new SampleDataChangedEventArgs(SampleGroups, levels));
            populateSampleGroupTree();
        }
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            //Enable copy pasting cells
            if(e.Control && e.KeyCode == Keys.V)
            {
                string stringFromClipBoard = (string)Clipboard.GetDataObject().GetData(DataFormats.Text);
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    if(cell.ReadOnly == false)
                        cell.Value = stringFromClipBoard;
                }
                constructGroups();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            hilightSelectedSampleInRow();
            if (dataGridView1.SelectedCells.Count > 0)
                oldSampleGroup = dataGridView1["sampleGroup", dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
        }
        private void hilightSelectedSampleInRow()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1["sampleName", i].Style.BackColor != Color.LightGray)
                    dataGridView1["sampleName", i].Style.BackColor = dataGridView1["sampleName", i].OwningColumn.DefaultCellStyle.BackColor;
            }
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                if (dataGridView1["sampleName", cell.RowIndex].Style.BackColor != Color.LightGray)
                    dataGridView1["sampleName", cell.RowIndex].Style.BackColor = Color.LightBlue;
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "standardLevel")
            {
                int level = Utils.ConvertToInt32(e.FormattedValue);
                if(level == int.MinValue)
                {
                    e.Cancel = true;
                    (dataGridView1.EditingControl as TextBox).Undo();
                }
            }
        }
    }

    public class SampleDataChangedEventArgs: EventArgs
    {
        public List<SampleGroup> SampleGroups { get; private set; }
        public List<int> Levels { get; private set; }
        public SampleDataChangedEventArgs(List<SampleGroup> samplegroups, List<int> levels)
        {
            this.SampleGroups = samplegroups;
            this.Levels = levels;
        }
    }
}