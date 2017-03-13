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
        public InputForm(string text)
        {
            InitializeComponent();
            this.Text = text;
        }
        public string InputText { get { return textBox1.Text; } }
    }
}
