using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassHunterTRAnalyser.Data_Classes
{
    class CSV: IData
    {
        public CSV(string path, int startline = 0)
        {
            loadCSV(path, startline);
        }
        public DataTable Data { get; set; }

        private void loadCSV(string path, int startline = 0)
        {
            char splitChar = ';';

            int columnNumber = 0;
            using (StreamReader reader = new StreamReader(path))
            {
                DataTable table = new DataTable();
                for (int i = 0; i < startline; i++)
                    reader.ReadLine();

                while(reader.EndOfStream == false)
                {
                    string[] currentLine = reader.ReadLine().Split(splitChar);
                    columnNumber = currentLine.Length;
                    if (table.Columns.Count == 0)
                    {
                        for (int i = 0; i < currentLine.Length; i++)
                        {
                            table.Columns.Add(i.ToString());
                        }
                    }
                    DataRow row = table.NewRow();
                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        row[i] = currentLine[i];
                    }
                    table.Rows.Add(row);
                }
                Data = table;
            }
        }
    }
}
