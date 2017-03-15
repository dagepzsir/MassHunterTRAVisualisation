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

namespace MassHunterTRAnalyser.Controls
{
    public partial class StandardEditorControl : UserControl
    {
        public StandardEditorControl()
        {
            InitializeComponent();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<StandardData> storedStandards
        {
            get; set;
        }
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
        private void StandardEditorControl_Load(object sender, EventArgs e)
        {
            //Populate listview with stored standards
            foreach (StandardData stdData in storedStandards)
            {
                listView1.Items.Add(stdData.StandardName, stdData.StandardName, "");
            }

            if(listView1.Items.Count > 0)
                listView1.Items[0].Selected = true;
        }
        private void addStdButton_Click(object sender, EventArgs e)
        {
            InputForm txtForm = new InputForm("Standard's name");
            while(txtForm.ShowDialog(this) == DialogResult.OK)
            {
                txtForm.Focus();
                if (txtForm.InputText != "")
                {
                    if (listView1.Items.ContainsKey(txtForm.InputText) == false)
                    {
                        listView1.Items.Add(txtForm.InputText);
                        storedStandards.Add(new StandardData(txtForm.InputText, new Dictionary<string, Tuple<double, string>>(), new Dictionary<string, Tuple<int, int, double>>()));

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
                selectedStandard = storedStandards[listView1.SelectedIndices[0]];
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
                    Tuple<double, string> data = new Tuple<double, string>(Convert.ToDouble(elementDataGridView[1, e.RowIndex].Value), elementDataGridView[2, e.RowIndex].Value.ToString());
                    if (selectedStandard.ElementConcentrations.ContainsKey(elementDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                        selectedStandard.ElementConcentrations[key] = data;
                    }
                    else
                    {
                        selectedStandard.ElementConcentrations.Add(key, data);
                    }
                }
                if(isotopeRatioDataGridView[0, e.RowIndex].Value != null && isotopeRatioDataGridView[1, e.RowIndex].Value != null && isotopeRatioDataGridView[2, e.RowIndex].Value != null && isotopeRatioDataGridView[3, e.RowIndex].Value != null)
                {
                    string key = isotopeRatioDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    Tuple<int, int, double> data = new Tuple<int, int, double>(Convert.ToInt32(isotopeRatioDataGridView[1, e.RowIndex].Value), Convert.ToInt32(elementDataGridView[2, e.RowIndex].Value), Convert.ToDouble(isotopeRatioDataGridView[3, e.RowIndex].Value));
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

        private void removeStdBurron_Click(object sender, EventArgs e)
        {
            int indexRemoved = listView1.SelectedIndices[0];
            storedStandards.Remove(selectedStandard);
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
                    elementDataGridView.Rows.Add(key, selectedStandard.ElementConcentrations[key].Item1, selectedStandard.ElementConcentrations[key].Item2);
                }

                //Populate isotope ratio datagridview
                foreach (string key in selectedStandard.IsotopeRatios.Keys)
                {
                    isotopeRatioDataGridView.Rows.Add(key, selectedStandard.IsotopeRatios[key].Item1, selectedStandard.IsotopeRatios[key].Item2, selectedStandard.IsotopeRatios[key].Item3);
                }
            }
        }
    }
}