using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace MassHunterTRAnalyser
{
    public partial class SelectionControl : UserControl
    {
        public SelectionControl()
        {
            InitializeComponent();
        }

        (double SelectionStart, double SelectionEnd) currRange;
        SampleData selectedSample;
        Batch loadedBatch = null;

        #region Events
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Change the visibility of measured elements
            if(e.NewValue == CheckState.Checked)
                chart1.Series.FindByName(checkedListBox1.Items[e.Index].ToString()).Enabled = true;
            else
                chart1.Series.FindByName(checkedListBox1.Items[e.Index].ToString()).Enabled = false;
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        public void UserControl1_DataLoaded(object sender, DataLoadedEventArgs e)
        {
            loadedBatch = e.LoadedBatch;
            populateListBox();
            UpdateData();
        }

        private void chart1_SelectionRangeChanging(object sender, CursorEventArgs e)
        {
            //Store current selection range
            currRange = (SelectionStart: e.NewSelectionStart, SelectionEnd: e.NewSelectionEnd);
        }

        private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            //Add the selected range to the chart and datagridview, store the area in the corresponding sampledata object
            addStripeLineToChart(MassHunterTRAnalyser.SelectionType.None, currRange);
            dataGridView1.Rows.Add(chart1.ChartAreas[0].AxisX.StripLines.Count, "None", currRange.SelectionStart, currRange.SelectionEnd);
            selectedSample.DataSelections.Add(new DataSelection(chart1.ChartAreas[0].AxisX.StripLines.Count.ToString(), currRange, MassHunterTRAnalyser.SelectionType.None));
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Handle selection type change
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                SelectionType selectedType = selectedSample.DataSelections[e.RowIndex].SelectionType;
                StripLine selectedLine = chart1.ChartAreas[0].AxisX.StripLines[e.RowIndex];
                switch(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                {
                    case "None":
                       selectedLine.BackColor = Color.FromArgb(255, Color.LightBlue);
                        selectedType = MassHunterTRAnalyser.SelectionType.None;
                        break;
                    case "Background":
                        selectedLine.BackColor = Color.LightGray;
                        selectedType = MassHunterTRAnalyser.SelectionType.Background;
                        break;
                    case "Data":
                        selectedLine.BackColor = Color.LightGreen;
                        selectedType = MassHunterTRAnalyser.SelectionType.Data;
                        break;
                }

                selectedSample.DataSelections[e.RowIndex].SelectionType = selectedType;
            } //Handle Selection position change
            else if((e.ColumnIndex == 2 || e.ColumnIndex == 3) && e.RowIndex >= 0)
            {
                StripLine selectedLine = chart1.ChartAreas[0].AxisX.StripLines[e.RowIndex];
                selectedLine.IntervalOffset = Math.Min(Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value), Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value));
                selectedLine.StripWidth = Math.Abs(Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value) - Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value));
                chart1.ChartAreas[0].CursorX.SelectionEnd = selectedLine.IntervalOffset + selectedLine.StripWidth;
                chart1.ChartAreas[0].CursorX.SelectionStart = selectedLine.IntervalOffset;
                chart1.ChartAreas[0].CursorX.Position = selectedLine.IntervalOffset + selectedLine.StripWidth;

                selectedSample.DataSelections[e.RowIndex].RangeOfSelection = (SelectionStart: Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value), SelectionEnd: Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value));

            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (dataGridView1.SelectedCells[0].RowIndex > -1)
                {
                    //Deselect all of the selections
                    foreach (StripLine line in chart1.ChartAreas[0].AxisX.StripLines)
                    {
                        line.BorderWidth = 0;
                    }

                    //Highlight the selected range
                    if (chart1.ChartAreas[0].AxisX.StripLines.Count > 0)
                    {
                        StripLine selectedLine = chart1.ChartAreas[0].AxisX.StripLines[dataGridView1.SelectedCells[0].RowIndex];
                        selectedLine.BorderColor = Color.Red;
                        selectedLine.BorderWidth = 1;
                        chart1.ChartAreas[0].CursorX.SelectionEnd = selectedLine.IntervalOffset + selectedLine.StripWidth;
                        chart1.ChartAreas[0].CursorX.SelectionStart = selectedLine.IntervalOffset;
                    }
                }
            }
        }
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //Remove row from database
            chart1.ChartAreas[0].AxisX.StripLines.RemoveAt(e.Row.Index);
            selectedSample.DataSelections.RemoveAt(e.Row.Index);
        }
        private void addSelectionButton_Click(object sender, EventArgs e)
        {
            //Add selected ranges to all samples
            foreach (SampleData sample in loadedBatch.MeasuredData)
            {
                //Dont add to the selected sample
                if (sample.DataFileName != listView1.SelectedItems[0].Text)
                {
                    if (allRangeRadio.Checked)
                        sample.DataSelections = selectedSample.DataSelections;
                    else if (selectedRangeRadio.Checked)
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            sample.DataSelections.Add(selectedSample.DataSelections[row.Index]);
                        }
                    }
                }
            }
        }
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateData();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.IsLogarithmic = checkBox1.Checked;
            if (checkBox1.Checked)
                chart1.ChartAreas[0].AxisY.Minimum = 100;
            else
                chart1.ChartAreas[0].AxisY.Minimum = 0;
        }
        #endregion
        public void UpdateData()
        {
            //Reset GUI
            resetGUI();

            foreach (ListViewItem selectedItem in listView1.SelectedItems)
            {
                selectedSample = loadedBatch.MeasuredData.Find(item => item.DataFileName == selectedItem.Text);
                Dictionary<string, Series> serieses = new Dictionary<string, Series>();
                foreach (var traData in selectedSample.TimeResolvedData)
                {
                    //Load measured data into the chart
                    foreach (string element in traData.data.Keys)
                    {
                        if (serieses.ContainsKey(element) == false)
                        {
                            Series currentSeries = new Series(element + " - " + selectedSample.DataFileName)
                            {
                                ChartType = SeriesChartType.Line
                            };
                            serieses.Add(element, currentSeries);
                            chart1.Series.Add(serieses.Last().Value);
                            checkedListBox1.Items.Add(element + " - " + selectedSample.DataFileName);
                            checkedListBox1.SetItemChecked(checkedListBox1.Items.Count - 1, true);

                        }
                        serieses[element].Points.AddXY(traData.time, traData.data[element]);
                    }
                }
                //load selected areas from sampleData object
                loadSelections(selectedSample);
            }
        }
        private void populateListBox()
        {
            if (loadedBatch != null)
            {
                listView1.Items.Clear();
                foreach (SampleData data in loadedBatch.MeasuredData)
                {
                    if(data.Rejected == false)
                        listView1.Items.Add(new ListViewItem(new string[] { data.DataFileName, data.SampleName, data.SampleTypeString }));
                }
            }
        }
        private void loadSelections(SampleData sampledata)
        {
            foreach (DataSelection selection in sampledata.DataSelections)
            {
                dataGridView1.Rows.Add(selection.Name, selection.SelectionTypeToString, selection.RangeOfSelection.SelectionStart, selection.RangeOfSelection.SelectionEnd);
                addStripeLineToChart(selection.SelectionType, selection.RangeOfSelection);
            }
        }
        private void addStripeLineToChart(SelectionType type, (double SelectionStart, double SelectionEnd) rangeofselection)
        {
            StripLine newLine = new StripLine();
            switch (type)
            {
                case MassHunterTRAnalyser.SelectionType.None:
                    newLine.BackColor = Color.FromArgb(255, Color.LightBlue);
                    break;
                case MassHunterTRAnalyser.SelectionType.Background:
                    newLine.BackColor = Color.LightGray;
                    break;
                case MassHunterTRAnalyser.SelectionType.Data:
                    newLine.BackColor = Color.LightGreen;
                    break;
            }
            newLine.IntervalOffset = Math.Min(rangeofselection.SelectionStart, rangeofselection.SelectionEnd);
            newLine.StripWidth = Math.Abs(rangeofselection.SelectionStart - rangeofselection.SelectionEnd);
            chart1.ChartAreas[0].AxisX.StripLines.Add(newLine);
        }
        private void resetGUI()
        {
            chart1.Enabled = true;
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.StripLines.Clear();
            chart1.ChartAreas[0].CursorX.SetSelectionPosition(double.NaN, double.NaN);
            checkedListBox1.Items.Clear();
            dataGridView1.Rows.Clear();
        }
    }
}