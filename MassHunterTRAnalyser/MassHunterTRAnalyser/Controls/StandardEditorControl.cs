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
namespace MassHunterTRAnalyser.Controls
{
    public partial class StandardEditorControl : UserControl
    {
        public StandardEditorControl()
        {
            InitializeComponent();
        }
        List<StandardData> storedStandards;
        private void StandardEditorControl_Load(object sender, EventArgs e)
        {
            storedStandards = Properties.Settings.Default.Standards;
            foreach (StandardData stdData in storedStandards)
            {
                listView1.Items.Add(stdData.StandardName);
            }
        }

        private void addStdButton_Click(object sender, EventArgs e)
        {
            InputForm txtForm = new InputForm("Standard's name");
            if(txtForm.ShowDialog() == DialogResult.OK)
            {
                listView1.Items.Add(txtForm.InputText);
            }
        }
    }
}
