﻿using System;
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
            //Load standards from MainForm
            standardEditorControl1.StoredStandards = storedstandards;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Properties.Settings.Default.StandardData = JsonConvert.SerializeObject(standardEditorControl1.StoredStandards);
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            //(this.Owner as MainForm).sampleTypeControl1.LoadStandardNames();
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //IF user left empty cells prompt warning
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