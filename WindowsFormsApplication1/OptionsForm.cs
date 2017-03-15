using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }
        private bool loaded = false;
        public bool ColorsChanged { get; set; }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (e.RowIndex == dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.DefaultCellStyle.BackColor = colorDialog1.Color;
                    newRow.HeaderCell.Value = string.Format("{0}", dataGridView1.Rows.Count);
                    dataGridView1.Rows.Add(newRow);

                }
                else
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = colorDialog1.Color;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle = style;
                }
            }
            dataGridView1.ClearSelection();
        }
        private void OptionsForm_Load(object sender, EventArgs e)
        {
            foreach (Color color in Utils.GetColorsFromSettings())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.BackColor = color;
                row.HeaderCell.Value = dataGridView1.Rows.Count.ToString();
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.ClearSelection();
            loaded = true;
            ColorsChanged = false;
        }

        private void dataGridView1_RowDefaultCellStyleChanged(object sender, DataGridViewRowEventArgs e)
        {
            if(loaded)
            {
                ColorsChanged = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SaveColors();
            this.Close();
        }

        private void SaveColors()
        {
            List<string> saveString = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Index != dataGridView1.Rows.Count - 1)
                    saveString.Add(Utils.GetStringFromColor(row.DefaultCellStyle.BackColor));
            }
            Properties.Settings.Default.Colors = saveString.ToArray();
            Properties.Settings.Default.Save();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    ColorsChanged = true;
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int elementCount = ((MainForm)Owner).ElementCount;
            int colorCount = Utils.GetColorsFromSettings().Count;
            if (elementCount > colorCount)
            {
                e.Cancel = true;
                MessageBox.Show(string.Format("Not enough colors please pick atleast {0} more", (elementCount - colorCount)), "Not enough selected color!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
