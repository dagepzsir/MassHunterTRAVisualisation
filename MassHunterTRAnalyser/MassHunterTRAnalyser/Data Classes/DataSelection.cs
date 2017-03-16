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
        public (double SelectionStart, double SelectionEnd) RangeOfSelection { get; set; }
        public string Name { get; set; }
        public DataSelection(string name, (double SelectionStart, double SelectionEnd) rangeofselection, SelectionType selectiontype)
        {
            this.Name = name;
            this.SelectionType = selectiontype;
            this.RangeOfSelection = rangeofselection;
            
        }

        public double Min => Math.Min(RangeOfSelection.SelectionStart, RangeOfSelection.SelectionEnd);
        public double Max => Math.Max(RangeOfSelection.SelectionStart, RangeOfSelection.SelectionEnd);
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
