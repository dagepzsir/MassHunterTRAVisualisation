using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassHunterTRAnalyser
{
    public static class Utils
    {
        public static double ConvertToDouble(object input)
        {
            try
            {
                return Convert.ToDouble(input);
            }
            catch(FormatException)
            {
                MessageBox.Show("The input must be a valid number!", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return double.NaN;
            }
        }
        public static int ConvertToInt32(object input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch(FormatException)
            {
                MessageBox.Show("The input must be a valid number!", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return int.MinValue;
            }
        }
    }
}
