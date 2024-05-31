using System;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;

namespace OfficeExport
{
    public class WordExport
    {
        public void ExportData(string fileName, string[] data)
        {
            Word.Application wdApp = null;
            Word.Document doc = null;
            try
            {
                wdApp = new Word.Application();
                doc = wdApp.Documents.Add();

                // Розрахунок кількості рядків і стовпців
                int rowCount = data.Length;
                int colCount = data[0].Split(',').Length;

                // Створення таблиці
                Word.Table table = doc.Tables.Add(doc.Range(), rowCount, colCount);

                // Заповнення таблиці даними
                for (int i = 0; i < rowCount; i++)
                {
                    string[] lineData = data[i].Split(',');

                    for (int j = 0; j < colCount; j++)
                    {
                        string cellData = lineData.Length > j ? lineData[j].Trim() : string.Empty;
                        table.Cell(i + 1, j + 1).Range.Text = cellData;
                    }
                }

                // Збереження документу
                doc.SaveAs2(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close(false);
                    Marshal.ReleaseComObject(doc);
                }
                if (wdApp != null)
                {
                    wdApp.Quit();
                    Marshal.ReleaseComObject(wdApp);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
