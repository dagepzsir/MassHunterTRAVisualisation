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

namespace MassHunterTRAnalyser.Controls
{
    public partial class SampleTypeContontrolV2 : UserControl
    {
        public SampleTypeContontrolV2()
        {
            InitializeComponent();
        }

        public void SampleTypeControl_DataLoaded(object sender, DataLoadedEventArgs e)
        {
            setUpDataConnections(e);
            populateTreeView(e);
        }

        private void populateTreeView(DataLoadedEventArgs e)
        {
            foreach (SampleGroup group in e.LoadedBatch.SampleGroups)
            {
                treeView1.Nodes.Add(group.GroupName, group.GroupName + " - " + group.GroupType);
                if (group.RejectedGroup)
                    treeView1.Nodes[treeView1.Nodes.Count - 1].BackColor = Color.LightGray;
                foreach (SampleData sample in group.Samples)
                {
                    TreeNode parent = treeView1.Nodes[treeView1.Nodes.Count - 1];
                    parent.Nodes.Add(sample.DataFileName, sample.DataFileName + " -" + sample.SampleName + " (" + sample.SampleTypeString + ")");
                    if (sample.Rejected)
                        parent.Nodes[parent.Nodes.Count - 1].BackColor = Color.LightGray;
                }
            }
        }

        private void setUpDataConnections(DataLoadedEventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = e.LoadedBatch.DataSource;

            //Standard combobox item population
            List<string> standardnames = new List<string>();
            e.StoredStandards.ForEach(item => standardnames.Add(item.StandardName));
            standardTypeColumn.DataSource = standardnames.Select(value => new { Display = value }).ToList();
            standardTypeColumn.ValueMember = "Display";
            standardTypeColumn.DisplayMember = "Display";
            standardTypeColumn.ValueType = typeof(string);


            //Sample type combobox item population
            sampleTypeColumn.ValueType = typeof(SampleType);
            sampleTypeColumn.DataSource = Enum.GetValues(typeof(SampleType));

            //Databinding
            rejectedColumn.DataPropertyName = "Rejected";
            sampleNameColumn.DataPropertyName = "SampleName";
            commentColumn.DataPropertyName = "Comment";
            sampleTypeColumn.DataPropertyName = "TypeOfSample";
            standardTypeColumn.DataPropertyName = "StandardType";
            sampleGroupColumn.DataPropertyName = "SampleGroup";
            standardGroupColumn.DataPropertyName = "StandardLevel";
            dataFileColumn.DataPropertyName = "DataFileName";
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                if (dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor == dataGridView1[e.ColumnIndex, e.RowIndex].OwningColumn.DefaultCellStyle.BackColor)
                {
                    dataGridView1.BeginEdit(true);
                    ((ComboBox)dataGridView1.EditingControl).DroppedDown = true;
                }
            }
        }
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (dataGridView1.SelectedCells[0].OwningColumn is DataGridViewComboBoxColumn || dataGridView1.SelectedCells[0].OwningColumn is DataGridViewCheckBoxColumn)
            {
                dataGridView1.EndEdit();
            }
        }
    }
}
