using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTable = System.Data.DataTable;

namespace MassHunterTRAnalyser.Data_Classes
{
    class ExcelFile: IData
    {
        public DataTable Data { get; set; }

        public ExcelFile(string path)
        {
            loadExcelFile(path);
        }

        private void loadExcelFile(string path)
        {
            DataTable table = new DataTable();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(path, false))
            {
                Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                for (int i = 0; i < rows.ElementAt(0).Count(); i++)
                {
                    table.Columns.Add(i.ToString());
                }
                foreach (Row row in rows)
                {
                    DataRow tempRow = table.NewRow();
                    for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                    {
                        tempRow[i] = GetCellValue(row.Descendants<Cell>().ElementAt(i), doc);
                    }
                    table.Rows.Add(tempRow);
                }
                Data = table;
            }
        }

        private string GetCellValue(Cell cell, SpreadsheetDocument doc)
        {
            string realValue = "";
            if (cell.CellValue != null)
            {
                string value = cell.CellValue.InnerText;
                if (cell.DataType != null)
                {
                    if (cell.DataType.Value == CellValues.SharedString)
                        realValue = doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
                    else if (cell.DataType.Value == CellValues.Boolean)
                    {
                        if (cell.CellValue.Text == "0")
                            realValue = "false";
                        else if(cell.CellValue.Text == "1")
                            realValue = "true";
                    }
                }
                else
                    realValue = cell.CellValue.Text;
            }
            return realValue;
        }
    }
}
