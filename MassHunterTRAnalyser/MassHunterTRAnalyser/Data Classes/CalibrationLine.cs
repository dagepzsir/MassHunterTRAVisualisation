using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassHunterTRAnalyser.Data_Classes
{
    public class ChartSettings
    {
        public (double min, double max) XBoundaries;
        public (double min, double max) YBoundaries;
        public double XIntervall;
        public double YIntervall;
        public string XTitle;
        public bool XTitleBold;
        public string YTitle;
        public bool YTitleBold;

        public ChartSettings((double min, double max) xbounds, (double min, double max) ybounds, double xintervall, double yintervall, string xtitle, bool xtitlebold, string ytitle, bool ytitlebold)
        {
            XBoundaries = xbounds;
            YBoundaries = ybounds;
            XIntervall = xintervall;
            YIntervall = yintervall;
            XTitle = xtitle;
            YTitle = ytitle;
            XTitleBold = xtitlebold;
            YTitleBold = ytitlebold;
        }
    }
    class CalibrationLine
    {
        public int Level { get; private set; }
        public double Slope { get;  set; }
        public double Intercept { get;  set; }
        public double RSquared { get;  set; }
        public string Element { get; private set; }
        public ChartSettings ChartSettings { get; set; }
        public CalibrationLine(int level, string element, double slope, double intercept, double rsquared)
        {
            Level = level;
            Element = element;
            Slope = slope;
            Intercept = intercept;
            RSquared = rsquared;
            ChartSettings = null;
        }

        public double CalculateConcentration(double cps)
        {
            return (cps * Slope) + Intercept;
        }
        public void ReserCalibData()
        {
            Slope = double.NaN;
            Intercept = double.NaN;
            RSquared = double.NaN;
        }
    }
}
