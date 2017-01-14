using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    static class Utils
    {
        public static string GetStringFromColor(Color color)
        {
            return string.Format("{0},{1},{2}", color.R, color.G, color.B);
        }
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
        public static Color GetColorFromSettings(int index)
        {
            string colorString = Properties.Settings.Default.Colors[index];
            string[] rgb = colorString.Split(',');
            return Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
        }
    }
}
