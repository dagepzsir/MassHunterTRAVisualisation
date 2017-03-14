using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MassHunterTRAnalyser.Data_Classes;

namespace MassHunterTRAnalyser.Forms
{
    public partial class OptionsForm : Form
    {
        public OptionsForm(List<StandardData> storedstandards)
        {
            InitializeComponent();
            standardEditorControl1.storedStandards = storedstandards;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Properties.Settings.Default.StandardData = JsonConvert.SerializeObject(standardEditorControl1.storedStandards);
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(standardEditorControl1.HasEmptyCell)
            {
                if(MessageBox.Show("The elements concentrations, ratios will not be saved where you left empty cells! Do you want to close this window?", "Empty Cells", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==  DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}