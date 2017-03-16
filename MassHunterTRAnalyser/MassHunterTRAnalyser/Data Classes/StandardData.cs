using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassHunterTRAnalyser.Data_Classes
{
    public class StandardData
    {
        public Dictionary<string, (double Concentration, string Unit)> ElementConcentrations { get; set; }
        public Dictionary<string, (int Nominator, int Denominator, double Ratio)> IsotopeRatios { get; set; }
        public string StandardName { get; set; }

        public StandardData(string name, Dictionary<string, (double Concentration, string Unit)> elementconc, Dictionary<string, (int Nominator, int Denominator, double Ratio)> isotoperatios)
        {
            StandardName = name;
            ElementConcentrations = elementconc;
            IsotopeRatios = isotoperatios;
            
        }
        public StandardData()
        { }
    }
}