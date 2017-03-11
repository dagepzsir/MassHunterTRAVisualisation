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
        public List<SampleData> displayedSamples;

        Tuple<double, double> currRange = new Tuple<double, double>(0, 0);
       // List<Tuple<double, double>> selectedRanges = new List<Tuple<double, double>>();
        List<StripLine> stripLines = new List<StripLine>();
        List<int> selectedIndices = new List<int>();

        public void UpdateData()
        {
            chart1.Series.Clear();
            checkedListBox1.Items.Clear();
            if(displayedSamples != null)
            {
                foreach (SampleData sampleData in displayedSamples)
                {
                    Dictionary<string, Series> serieses = new Dictionary<string, Series>();
                    foreach (var traData in sampleData.TimeResolvedData)
                    {
                        foreach(string element in traData.Item2.Keys)
                        {
                            if (serieses.ContainsKey(element) == false)
                            {
                                Series currentSeries = new Series(element);
                                currentSeries.ChartType = SeriesChartType.Point;
                                serieses.Add(element, currentSeries);
                                chart1.Series.Add(serieses.Last().Value);
                                checkedListBox1.Items.Add(element);
                                checkedListBox1.SetItemChecked(checkedListBox1.Items.Count - 1, true);

                            }
                            serieses[element].Points.AddXY(traData.Item1, traData.Item2[element]);
                        }
                    }

                }
            }
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
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
            currRange = new Tuple<double, double>(e.NewSelectionStart, e.NewSelectionEnd);
        }

        private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            //selectedRanges.Add(currRange);
            StripLine newLine = new StripLine();
            newLine.BackColor = Color.FromArgb(255, Color.LightBlue);
            newLine.Tag = stripLines.Count;
            newLine.IntervalOffset = Math.Min(currRange.Item1, currRange.Item2);
            newLine.StripWidth = Math.Abs(currRange.Item1 - currRange.Item2);
            chart1.ChartAreas[0].AxisX.StripLines.Add(newLine);
            stripLines.Add(newLine);
            dataGridView1.Rows.Add(chart1.ChartAreas[0].AxisX.StripLines.Count, "None", currRange.Item1, currRange.Item2);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                StripLine selectedLine = stripLines[e.RowIndex];
                switch(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                {
                    case "None":
                       selectedLine.BackColor = Color.FromArgb(255, Color.LightBlue);
                        break;
                    case "Background":
                        selectedLine.BackColor = Color.LightGray;
                        break;
                    case "Data":
                        selectedLine.BackColor = Color.DarkGreen;
                        break;
                }
            }
            else if((e.ColumnIndex == 2 || e.ColumnIndex == 3) && e.RowIndex >= 0)
            {
                StripLine selectedLine = stripLines[e.RowIndex];
                selectedLine.IntervalOffset = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                selectedLine.StripWidth = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                chart1.ChartAreas[0].CursorX.SelectionEnd = selectedLine.IntervalOffset + selectedLine.StripWidth;
                chart1.ChartAreas[0].CursorX.SelectionStart = selectedLine.IntervalOffset;
                chart1.ChartAreas[0].CursorX.Position = selectedLine.IntervalOffset + selectedLine.StripWidth;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            stripLines.ForEach(item => item.BorderWidth = 0);
            StripLine selectedLine =  stripLines[dataGridView1.SelectedCells[0].RowIndex];
            selectedLine.BorderColor = Color.Red;
            selectedLine.BorderWidth = 1;
            chart1.ChartAreas[0].CursorX.SelectionEnd = selectedLine.IntervalOffset + selectedLine.StripWidth;
            chart1.ChartAreas[0].CursorX.SelectionStart = selectedLine.IntervalOffset;
        }
    }
}