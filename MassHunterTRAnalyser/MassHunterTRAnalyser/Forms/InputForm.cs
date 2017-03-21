using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassHunterTRAnalyser.Forms
{
    public partial class InputForm : Form
    {
        public InputForm(string text, string textboxtext)
        {
            InitializeComponent();
            this.Text = text;
            this.textBox1.Text = textboxtext;
        }
        public string InputText { get { return textBox1.Text; } }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
