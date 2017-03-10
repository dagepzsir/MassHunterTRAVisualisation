using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassHunterTRAnalyser
{
    static class Utils
    {
        public static List<Color> GetColorsFromSettings()
        {
            List<Color> output = new List<Color>();
            foreach (string colorString in Properties.Settings.Default.Colors)
            {
                string[] rgb = colorString.Split(',');
                output.Add(Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2])));
            }
            return output;
        }
        public static string GetStringFromColor(Color color)
        {
            return string.Format("{0},{1},{2}", color.R, color.G, color.B);
        }
    }
}
