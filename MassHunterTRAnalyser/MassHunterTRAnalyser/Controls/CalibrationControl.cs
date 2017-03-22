using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MassHunterTRAnalyser.Data_Classes;

namespace MassHunterTRAnalyser.Controls
{
    public partial class CalibrationControl : UserControl
    {
        public CalibrationControl()
        {
            InitializeComponent();
        }
        List<SampleData> sampleStandards;
        List<StandardData> standardDatas;
        public void CalibrationControlDataLoaded(object sender, DataLoadedEventArgs e)
        {
            UpdateData(e.LoadedBatch, e.StoredStandards);
        }

        public void UpdateData(Batch loadedbatch, List<StandardData> storedstandards)
        {
            sampleStandards = new List<SampleData>();
            standardDatas = new List<StandardData>();
            foreach (SampleData sample in loadedbatch.MeasuredData)
            {
                if (sample.TypeOfSample == SampleType.Standard && sample.Rejected == false)
                {
                    sampleStandards.Add(sample);
                    StandardData standard = storedstandards.Find(item => item.StandardName == sample.StandardType);
                    if (standardDatas.Contains(standard) == false)
                        standardDatas.Add(standard);
                }
            }
        }
    }
}