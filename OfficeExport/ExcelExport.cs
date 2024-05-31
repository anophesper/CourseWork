using System;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace OfficeExport
{
    public class ExcelExport
    {
        public void ExportData(string fileName, string[,] data)
        {
            Excel.Application xlApp = null;
            Excel.Workbook xlBook = null;
            Excel.Worksheet xlSheet = null;
            try
            {
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Add();
                xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                int rows = data.GetLength(0);
                int cols = data.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        xlSheet.Cells[i + 1, j + 1] = data[i, j];
                    }
                }

                xlBook.SaveAs(fileName);
            }
            finally
            {
                if (xlSheet != null)
                {
                    Marshal.ReleaseComObject(xlSheet);
                }
                if (xlBook != null)
                {
                    xlBook.Close();
                    Marshal.ReleaseComObject(xlBook);
                }
                if (xlApp != null)
                {
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
