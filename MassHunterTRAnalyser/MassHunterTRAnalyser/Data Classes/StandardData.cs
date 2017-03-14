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
        public Dictionary<string, Tuple<double, string>> ElementConcentrations { get; set; }
        public Dictionary<string, Tuple<int, int, double>> IsotopeRatios { get; set; }
        public string StandardName { get; set; }

        public StandardData(string name, Dictionary<string, Tuple<double, string>> elementconc, Dictionary<string, Tuple<int, int, double>> isotoperatios)
        {
            StandardName = name;
            ElementConcentrations = elementconc;
            IsotopeRatios = isotoperatios;
        }
        public StandardData()
        { }
    }
}