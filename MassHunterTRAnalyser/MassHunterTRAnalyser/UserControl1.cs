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

namespace MassHunterTRAnalyser
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        Tuple<double, double> currRange = new Tuple<double, double>(0, 0);
        List<SampleData> loadedData;
        public void UpdateData(ListView loadeddata)
        {
            chart1.Enabled = true;
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.StripLines.Clear();
            chart1.ChartAreas[0].CursorX.SetSelectionPosition(double.NaN, double.NaN);
            checkedListBox1.Items.Clear();
            dataGridView1.Rows.Clear();
            foreach (ListViewItem selectedItem in loadeddata.SelectedItems)
            {
                loadedData = ((Form1)this.Parent).selectedBatch.MeasuredData.FindAll(item => item.DataFileName == selectedItem.Text);
                Dictionary<string, Series> serieses = new Dictionary<string, Series>();
                foreach (SampleData sampleData in loadedData)
                {
                    foreach (var traData in sampleData.TimeResolvedData)
                    {
                        //Load measured data into the chart
                        foreach (string element in traData.Item2.Keys)
                        {
                            if (serieses.ContainsKey(element) == false)
                            {
                                Series currentSeries = new Series(element + " - " + sampleData.DataFileName);
                                currentSeries.ChartType = SeriesChartType.Point;
                                serieses.Add(element, currentSeries);
                                chart1.Series.Add(serieses.Last().Value);
                                checkedListBox1.Items.Add(element + " - " + sampleData.DataFileName);
                                checkedListBox1.SetItemChecked(checkedListBox1.Items.Count - 1, true);

                            }
                            serieses[element].Points.AddXY(traData.Item1, traData.Item2[element]);
                        }
                    }
                    //load selected areas from sampleData object
                    loadSelections(sampleData);
                }
            }

            
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Change the visibility of measored elements
            if(e.NewValue == CheckState.Checked)
                chart1.Series.FindByName(checkedListBox1.Items[e.Index].ToString()).Enabled = true;
            else
                chart1.Series.FindByName(checkedListBox1.Items[e.Index].ToString()).Enabled = false;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        private void chart1_SelectionRangeChanging(object sender, CursorEventArgs e)
        {
            //Store current selection range
            currRange = new Tuple<double, double>(e.NewSelectionStart, e.NewSelectionEnd);
        }

        private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            //Add the selected range to the chart and datagridview, store the area in the corresponding sampledata object
            addStripeLineToChart(MassHunterTRAnalyser.SelectionType.None, currRange);
            dataGridView1.Rows.Add(chart1.ChartAreas[0].AxisX.StripLines.Count, "None", currRange.Item1, currRange.Item2);
            foreach (SampleData sampledata in loadedData)
            {
                sampledata.DataSelections.Add(new DataSelection(chart1.ChartAreas[0].AxisX.StripLines.Count.ToString(), currRange, MassHunterTRAnalyser.SelectionType.None));
            }
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Handle selection type change
            MassHunterTRAnalyser.SelectionType selectedType = MassHunterTRAnalyser.SelectionType.None;
            if(e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
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
                        selectedLine.BackColor = Color.DarkGreen;
                        selectedType = MassHunterTRAnalyser.SelectionType.Data;
                        break;
                }
            } //Handle Selection position change
            else if((e.ColumnIndex == 2 || e.ColumnIndex == 3) && e.RowIndex >= 0)
            {
                StripLine selectedLine = chart1.ChartAreas[0].AxisX.StripLines[e.RowIndex];
                selectedLine.IntervalOffset = Math.Min(Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value), Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value));
                selectedLine.StripWidth = Math.Abs(Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value) - Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value));
                chart1.ChartAreas[0].CursorX.SelectionEnd = selectedLine.IntervalOffset + selectedLine.StripWidth;
                chart1.ChartAreas[0].CursorX.SelectionStart = selectedLine.IntervalOffset;
                chart1.ChartAreas[0].CursorX.Position = selectedLine.IntervalOffset + selectedLine.StripWidth;
            }

            //Store selectedd areas in the SampleData objects for later use (maybe will change to store actual measured data aswell)
            if (e.RowIndex > -1)
            {
                foreach (SampleData sampledata in loadedData)
                {
                    sampledata.DataSelections[e.RowIndex].RangeOfSelection = new Tuple<double, double>(Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value), Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value));
                    sampledata.DataSelections[e.RowIndex].SelectionType = selectedType;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (dataGridView1.SelectedCells[0].RowIndex > -1)
                {
                    //Deselect all selection
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
            chart1.ChartAreas[0].AxisX.StripLines.RemoveAt(e.Row.Index);
            foreach (SampleData sampledata in loadedData)
            {
                sampledata.DataSelections.RemoveAt(e.Row.Index);
            }
        }

        private void loadSelections(SampleData sampledata)
        {
            foreach (DataSelection selection in sampledata.DataSelections)
            {
                dataGridView1.Rows.Add(selection.Name, selection.SelectionTypeToString(), selection.RangeOfSelection.Item1, selection.RangeOfSelection.Item2);
                addStripeLineToChart(selection.SelectionType, selection.RangeOfSelection);
            }
        }
        private void addStripeLineToChart(SelectionType type, Tuple<double, double> rangeofselection)
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
                    newLine.BackColor = Color.DarkGreen;
                    break;
            }
            newLine.IntervalOffset = Math.Min(rangeofselection.Item1, rangeofselection.Item2);
            newLine.StripWidth = Math.Abs(rangeofselection.Item1 - rangeofselection.Item2);
            chart1.ChartAreas[0].AxisX.StripLines.Add(newLine);
        }

        private void addSelectionButton_Click(object sender, EventArgs e)
        {
            foreach (SampleData sample in ((Form1)this.Parent).selectedBatch.MeasuredData)
            {
                if (loadedData[0].DataSelections.Count > 0)
                {
                    if(allRangeRadio.Checked)
                        sample.DataSelections = loadedData[0].DataSelections;
                    else if(selectedRangeRadio.Checked)
                    {
                        for(int i = 0;i < dataGridView1.SelectedRows.Count; i++)
                        {
                            sample.DataSelections.Add(loadedData[0].DataSelections[i]);
                        }
                    }
                }
            }
        }
    }
}