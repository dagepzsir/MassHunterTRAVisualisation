using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassHunterTRAnalyser.Data_Classes
{
    public class StandardData
    {
        public Dictionary<string, double> ElementConcentrations = new Dictionary<string, double>();
        public Dictionary<string, double> IsotopeRatios = new Dictionary<string, double>();
        public string StandardName;

        public StandardData(string name, Dictionary<string, double> elementconc, Dictionary<string, double> isotoperatios)
        {
            StandardName = name;
            ElementConcentrations = elementconc;
            IsotopeRatios = isotoperatios;
        }
    }
}
