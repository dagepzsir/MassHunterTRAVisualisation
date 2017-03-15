using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassHunterTRAnalyser
{
    public enum SelectionType
    {
        None = 0,
        Background = 1,
        Data = 2,
    }
    public class DataSelection
    {
        public SelectionType SelectionType { get; set; }
        public Tuple<double, double> RangeOfSelection { get; set; }
        public string Name { get; set; }
        public DataSelection(string name, Tuple<double, double> rangeofselection, SelectionType selectiontype)
        {
            this.Name = name;
            this.SelectionType = selectiontype;
            this.RangeOfSelection = rangeofselection;
        }

        public double Min { get { return Math.Min(RangeOfSelection.Item1, RangeOfSelection.Item2); } }
        public double Max { get { return Math.Max(RangeOfSelection.Item2, RangeOfSelection.Item2); } }
        public string SelectionTypeToString
        {
            get
            {
                switch (SelectionType)
                {
                    case SelectionType.None:
                        return "None";
                    case SelectionType.Background:
                        return "Background";
                    case SelectionType.Data:
                        return "Data";
                    default:
                        return "None";
                }
            }
        }
        public bool ShouldSerializeSelectionTypeToString()
        {
            return false;
        }
    }
}
