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
using MassHunterTRAnalyser.Forms;
using Newtonsoft.Json;
using System.Globalization;
using System.Windows;

namespace MassHunterTRAnalyser.Controls
{
    public partial class StandardEditorControl : UserControl
    {
        public StandardEditorControl()
        {
            InitializeComponent();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<StandardData> StoredStandards { get; set; }
        public bool HasEmptyCell
        {
            get
            {
                bool empty = false;
                for(int i = 0; i < elementDataGridView.Rows.Count - 1; i++)
                { 
                    foreach (DataGridViewCell cell in elementDataGridView.Rows[i].Cells)
                    {
                        if(cell.Value == null)
                        {
                            empty = true;
                            break;
                        }
                    }
                }
                for (int i = 0; i < isotopeRatioDataGridView.Rows.Count - 1; i++)
                {
                    foreach (DataGridViewCell cell in isotopeRatioDataGridView.Rows[i].Cells)
                    {
                        if (cell.Value == null)
                        {
                            empty = true;
                            break;
                        }
                    }
                }
                return empty;
            }
        }
        private StandardData selectedStandard;
        #region Events
        private void standardEditorControl_Load(object sender, EventArgs e)
        {
            populateListView();
        }

        private void populateListView()
        {
            listView1.Items.Clear();
            //Populate listview with stored standards
            foreach (StandardData stdData in StoredStandards)
            {
                listView1.Items.Add(stdData.StandardName, stdData.StandardName, "");
            }

            if (listView1.Items.Count > 0)
                listView1.Items[0].Selected = true;
        }

        private void addStdButton_Click(object sender, EventArgs e)
        {
            InputForm txtForm = new InputForm("Standard's name", "");
            while(txtForm.ShowDialog(this) == DialogResult.OK)
            {
                txtForm.Focus();
                if (txtForm.InputText != "")
                {
                    if (listView1.Items.ContainsKey(txtForm.InputText) == false)
                    {
                        listView1.Items.Add(txtForm.InputText);
                        StoredStandards.Add(new StandardData(txtForm.InputText, new Dictionary<string, (double Concentration, string Unit)>(), new Dictionary<string, (int Nominator, int Denominator, double Ratio)>()));

                        elementDataGridView.Enabled = true;
                        isotopeRatioDataGridView.Enabled = true;

                        listView1.Items[listView1.Items.Count - 1].Selected = true;
                        listView1.Select();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Standard already exists in database!", "Error: Standard already exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You must give a standard name!");
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            elementDataGridView.Enabled = true;
            isotopeRatioDataGridView.Enabled = true;
            //Load selected standard
            if (listView1.SelectedIndices.Count > 0)
                selectedStandard = StoredStandards[listView1.SelectedIndices[0]];
            else
                selectedStandard = null;

            loadStanradData();
        }

        private void elementDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Fix combobox behaviour
            if (e.RowIndex > -1 && ((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                ((DataGridView)sender).BeginEdit(true);
                ((ComboBox)((DataGridView)sender).EditingControl).DroppedDown = true;
            }
        }
        private void elementDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                //If all cells filled store element data
                if (elementDataGridView[0, e.RowIndex].Value != null && elementDataGridView[1, e.RowIndex].Value != null && elementDataGridView[2, e.RowIndex].Value != null)
                {
                    string key = elementDataGridView[0, e.RowIndex].Value.ToString();
                    (double Concentration, string Unit) data = (Concentration: Convert.ToDouble(elementDataGridView[1, e.RowIndex].Value), Unit: elementDataGridView[2, e.RowIndex].Value.ToString());
                    if (selectedStandard.ElementConcentrations.ContainsKey(elementDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                        selectedStandard.ElementConcentrations[key] = data;
                    }
                    else
                    {
                        selectedStandard.ElementConcentrations.Add(key, data);
                    }
                }
            }
        }

        private void removeStdBurron_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int indexRemoved = listView1.SelectedIndices[0];
                StoredStandards.Remove(selectedStandard);
                listView1.Items.Remove(listView1.SelectedItems[0]);
                if (indexRemoved - 1 >= 0)
                {
                    listView1.Items[indexRemoved - 1].Selected = true;
                    listView1.Select();
                }
                else
                {
                    selectedStandard = null;
                    elementDataGridView.Rows.Clear();
                    isotopeRatioDataGridView.Rows.Clear();
                }
            }
        }
#endregion

        private void loadStanradData()
        {
            //Clear previous data
            elementDataGridView.Rows.Clear();
            isotopeRatioDataGridView.Rows.Clear();

            if (selectedStandard != null)
            {
                //Populate element dataGridView
                foreach (string key in selectedStandard.ElementConcentrations.Keys)
                {
                    elementDataGridView.Rows.Add(key, selectedStandard.ElementConcentrations[key].Concentration, selectedStandard.ElementConcentrations[key].Unit);
                }

                //Populate isotope ratio datagridview
                foreach (string key in selectedStandard.IsotopeRatios.Keys)
                {
                    isotopeRatioDataGridView.Rows.Add(key, selectedStandard.IsotopeRatios[key].Nominator, selectedStandard.IsotopeRatios[key].Denominator, selectedStandard.IsotopeRatios[key].Ratio);
                }
                
            }
        }

        private void loadCSV_Click(object sender, EventArgs e)
        {
            if(openCSVDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable data;
                if (openCSVDialog.FileName.Contains("xls"))
                {
                    ExcelFile file = new ExcelFile(openCSVDialog.FileName);
                    data = file.XLSData;
                }
                else
                {
                    CSV csv = new CSV(openCSVDialog.FileName);
                    data = csv.CSVData;
                }
                StoredStandards.AddRange(getStandardsFromCSV(data));
                populateListView();
            }
        }
        private List<StandardData> getStandardsFromCSV(DataTable fileData)
        {
            List<StandardData> standardsFromFile = new List<StandardData>();
            //DataRow elementNames = fileData.CSVData.Rows[0];

            for (int columnIndex = 1; columnIndex < fileData.Columns.Count - 1; columnIndex++)
            {
                int ratioCounter = 1;
                string standardName = fileData.Rows[0][columnIndex].ToString();

                if (listView1.Items.ContainsKey(standardName) == false)
                {
                    Dictionary<string, (double Concentration, string Unit)> concentrationData = new Dictionary<string, (double Concentration, string Unit)>(); ;
                    Dictionary<string, (int Nominator, int Denominator, double Ratio)> ratioData = new Dictionary<string, (int Nominator, int Denominator, double Ratio)>();
                    for (int rowIndex = 1; rowIndex < fileData.Rows.Count; rowIndex++)
                    {
                        if (fileData.Rows[rowIndex][columnIndex].ToString() != "")
                        {
                            string value = fileData.Rows[rowIndex][columnIndex].ToString();
                            double currentValue;
                            NumberFormatInfo provider = new NumberFormatInfo();
                            if (value.Contains(','))
                                provider.NumberDecimalSeparator = ",";
                            else if (value.Contains('.'))
                                provider.NumberDecimalSeparator = ".";
                            currentValue = Convert.ToDouble(value, provider);
                           
                            string elementName = fileData.Rows[rowIndex][0].ToString();
                            if (elementName.Contains("/"))
                            {
                                //Record is a ratio
                                string[] elementArray = elementName.Split('/');

                                //internal method to decode mass numbers
                                (string element, int massnumber) info(string fraction)
                                {
                                    char[] charArray = fraction.ToCharArray();
                                    string massstring = "";
                                    string name = "";
                                    foreach (char c in charArray)
                                    {
                                        if (Char.IsNumber(c))
                                            massstring += c;
                                        else
                                            name += c;
                                    }

                                    int massnumber = Convert.ToInt32(massstring);
                                    return (element: name, massnumber: massnumber);
                                }

                                var nominator = info(elementArray[0]);
                                var denominator = info(elementArray[1]);

                                if(ratioData.ContainsKey(nominator.element) || ratioData.ContainsKey(string.Format("{0}({1})", nominator.element, ratioCounter)))
                                {
                                    ratioData.Add(string.Format("{0}({1})", nominator.element, ratioCounter), (Nominator: nominator.massnumber, Denominator: denominator.massnumber, currentValue));
                                    ratioCounter++;
                                }

                                else
                                    ratioData.Add(nominator.element, (Nominator: nominator.massnumber, Denominator: denominator.massnumber, currentValue));
                            }
                            else
                            {
                                //Record is a concentration
                                string unit = fileData.Rows[rowIndex][fileData.Columns.Count - 1].ToString();
                                if (unit.Contains('u'))
                                    unit = unit.Replace('u', 'µ');

                                concentrationData.Add(elementName, (currentValue, unit));
                            }
                        }
                    }
                    standardsFromFile.Add(new StandardData(standardName, concentrationData, ratioData));
                }
            }
            return standardsFromFile;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem clicked = listView1.HitTest(e.Location).Item;
            string oldname = clicked.Text;
            InputForm input = new InputForm("Standard name", clicked.Text);
            if(input.ShowDialog() == DialogResult.OK)
            {
                StoredStandards.Find(item => item.StandardName == oldname).StandardName = input.InputText;
            }
            populateListView();
        }

        private void isotopeRatioDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isotopeRatioDataGridView[0, e.RowIndex].Value != null && isotopeRatioDataGridView[1, e.RowIndex].Value != null && isotopeRatioDataGridView[2, e.RowIndex].Value != null && isotopeRatioDataGridView[3, e.RowIndex].Value != null)
            {
                string key = isotopeRatioDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                (int Nominator, int Denominator, double Ratio) data = (Nominator: Convert.ToInt32(isotopeRatioDataGridView[1, e.RowIndex].Value), Denominator: Convert.ToInt32(elementDataGridView[2, e.RowIndex].Value), Ratio: Convert.ToDouble(isotopeRatioDataGridView[3, e.RowIndex].Value));
                if (selectedStandard.ElementConcentrations.ContainsKey(elementDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    selectedStandard.IsotopeRatios[key] = data;
                }
                else
                {
                    selectedStandard.IsotopeRatios.Add(key, data);
                }
            }
        }
    }
}