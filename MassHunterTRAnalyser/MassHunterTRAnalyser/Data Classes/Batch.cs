using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MassHunterTRAnalyser
{
    public class Batch
    {
        public List<SampleData> MeasuredData { get; set; }
        public Batch(string path)
        {
            LoadFromFile(path);
        }

        //Load selected batch
        private void LoadFromFile(string folderpath)
        {
            List<string> dataFiles = Directory.EnumerateDirectories(folderpath, "*.d").ToList();
            int elementCount;
            MeasuredData = new List<SampleData>();
            //Load acq data
            foreach (string dataFileFolder in dataFiles)
            {
                MeasuredData.Add(new SampleData(dataFileFolder));
            }

            //Get the number of analysed elements from AcqMethod.xml
            XElement acqMethod = XElement.Load(Path.Combine(folderpath, "Method", "AcqMethod.xml"));
            string xmlns = "{Acquisition}";
            var elements = from element in acqMethod.Elements(xmlns + "IcpmsElement")
                           select element;
            elementCount = elements.Count();

            /*if(elementCount > colorCount)
            {
                MessageBox.Show("Ide kell a szín beállító form!");
                OptionsForm options = new OptionsForm();
                options.ShowDialog();
            }*/
        }
    }
}