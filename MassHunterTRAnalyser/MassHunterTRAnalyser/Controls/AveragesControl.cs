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
    public partial class AveragesControl : UserControl
    {
        public AveragesControl()
        {
            InitializeComponent();
        }
        List<SampleGroup> sampleGroups;
        List<StandardData> standardDatas;
        DataTable dataTable = new DataTable();
        public void AveragesControlDataLoaded(object sender, DataLoadedEventArgs e)
        {
            standardDatas = e.StoredStandards;
            
        }
        public void SampleTypeControl1_SampleGroupsChanged(object sender, SampleDataChangedEventArgs e)
        {
            sampleGroups = e.SampleGroups;
            populateSampleGroupTree();
        }
        private void populateSampleGroupTree()
        {
            sampleTree.Nodes.Clear();
            foreach (SampleGroup group in sampleGroups)
            {
                if (group.RejectedGroup == false)
                {
                    sampleTree.Nodes.Add(group.GroupName, group.GroupName + " - " + group.GroupType);
                    foreach (SampleData sample in group.Samples)
                    {
                        TreeNode parent = sampleTree.Nodes[sampleTree.Nodes.Count - 1];
                        if (sample.Rejected == false)
                            parent.Nodes.Add(sample.DataFileName, sample.DataFileName + " -" + sample.SampleName + " (" + sample.SampleTypeString + ")");
                    }
                }
            }
        }

        private void sampleTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SampleGroup group;
            dataTable.Rows.Clear();
            if (e.Node != null)
            {
                if (e.Node.Parent != null)
                {
                    group = sampleGroups.Find(item => item.GroupName == e.Node.Parent.Name);
                    SampleData sampleData = group.Samples.Find(item => item.DataFileName == e.Node.Name);

                    var data = sampleData.GetBackgroundCorrectedSignals();
                    var background = sampleData.GetBackground();
                    foreach (string element in data.Keys)
                    {
                        dataTable.Rows.Add(element, data[element].average, data[element].stdev, Calculations.RSD(data[element]), background[element].average);
                        enableCell(dataGridView1["Background", dataTable.Rows.Count - 1], true);
                    }
                }
                else
                {
                    group = sampleGroups.Find(item => e.Node.Name == (item.GroupName));
                    var data = group.CalulateGroupStatistics();
                    foreach (string element in data.Keys)
                    {
                        dataTable.Rows.Add(element, data[element].average, data[element].stdev, Calculations.RSD(data[element]));
                        enableCell(dataGridView1["Background", dataTable.Rows.Count - 1], false);
                    }
                    
                }
            }
        }
        private void enableCell(DataGridViewCell cell, bool enabled)
        {
            if (enabled)
            {
                cell.Style.BackColor = cell.OwningColumn.DefaultCellStyle.BackColor;
                cell.Style.ForeColor = cell.OwningColumn.DefaultCellStyle.ForeColor;
                cell.Style.SelectionBackColor = cell.OwningColumn.DefaultCellStyle.SelectionBackColor;
                cell.Style.SelectionForeColor = cell.OwningColumn.DefaultCellStyle.SelectionForeColor;
            }
            else
            {
                cell.Style.BackColor = Color.LightGray;
                cell.Style.ForeColor = Color.DarkGray;
                cell.Style.SelectionBackColor = Color.LightGray;
                cell.Style.SelectionForeColor = Color.DarkGray;
            }
        }
        private void AveragesControl_Load(object sender, EventArgs e)
        {
            if(dataTable.Columns.Count == 0)
            {
                dataTable.Columns.Add("Element", typeof(string));
                dataTable.Columns.Add("Average CPS (bkrd corr.", typeof(double));
                dataTable.Columns.Add("SD", typeof(double));
                dataTable.Columns.Add("RSD", typeof(double));
                dataTable.Columns.Add("Background", typeof(double));
            }
            dataGridView1.DataSource = dataTable;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Format = "0.000";
            }

        }

        public void UpdateControl()
        {
            populateSampleGroupTree();
        }
    }
}