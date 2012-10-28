using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;

/// prototype class for importing from an Excel worbook (exported from the Neptun system)
namespace Excel_Import
{
  class Program
  {

    static void Main(string[] args)
    {
      String path = @"C:\worksheet.xlsx";
      String name = "név";
      String neptun = "neptun kód";
      int? nameCol = null;
      int? neptunCol = null;

      // opening an Excel application
      Excel.Application excelApp = new Excel.Application();      
      excelApp.Visible = false;

      // open the workbook in read-only mode
      Excel.Workbook workbook = excelApp.Workbooks.Open(path, Type.Missing, true);
      Excel.Worksheet worksheet = excelApp.ActiveSheet;

      Excel.Range usedRange = worksheet.UsedRange;
    
      // scan through the first row to get the column indices     
      for (int j = 1; j <= worksheet.UsedRange.Columns.Count; j++)      
			{
        Excel.Range cell = usedRange.Cells[1, j];
        if (cell.Value != null)
        {
          String cellValue = cell.Value.ToString();
          
          if (cellValue.ToLower() == name.ToLower())
          {
            nameCol = j;
          }

          if (cellValue.ToLower() == neptun.ToLower())
          {
            neptunCol = j;
          }
        }
			}

      // throw exception if a required a column does not exist
      if (nameCol == null || neptunCol == null)
      {
        throw new Exception("Nem találhatók a szükséges oszlopok.");
      }

      // scan through the rows from the second row
      for (int i = 2; i <= usedRange.Rows.Count; i++)
      {
        Console.WriteLine("#" + (i-1));
        Console.WriteLine("    név:    " + usedRange.Cells[i, nameCol].Value.ToString());
        Console.WriteLine("    neptun: " + usedRange.Cells[i, neptunCol].Value.ToString());
      }

      excelApp.Quit();
    }
  }
}
