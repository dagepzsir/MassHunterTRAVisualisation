using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MassHunterTRAnalyser
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public List<SampleData> displayedSamples;
        public void UpdateData()
        {
            if(displayedSamples != null)
            {
                foreach (SampleData sampleData in displayedSamples)
                {
                    Dictionary<string, Series> series = new Dictionary<string, Series>();
                    foreach (var traData in sampleData.TimeResolvedData)
                    {
                        foreach(string element in traData.Item2.Keys)
                        {
                            if (series.ContainsKey(element) == false)
                            {
                                series.Add(element, new Series(element + " - " + sampleData.SampleName + "(" + sampleData.DataFileName + ")"));
                                checkedListBox1.Items.Add(element + " - " + sampleData.SampleName + "(" +sampleData.DataFileName + ")");
                            }
                            series[element].Points.AddXY(traData.Item1, traData.Item2[element]);
                        }
                    }
                }
            }
        }

    }
}