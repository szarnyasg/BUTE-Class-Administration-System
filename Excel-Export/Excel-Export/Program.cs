using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;

namespace Excel_Export
{
  class Program
  {
    static void Main(string[] args)
    {
      String path = @"C:\exported.xlsx";
      String name = "név";
      String neptun = "neptun kód";
      
      // open an Excel application
      Excel.Application excelApp = new Excel.Application();
      excelApp.Visible = true;
      excelApp.Workbooks.Add();
      // work in quiet mode: no prompt to overwrite the file
      excelApp.DisplayAlerts = false;
      
      // open the workbook
      Excel.Worksheet worksheet = excelApp.ActiveSheet;

      // fill the header
      worksheet.Cells[1, 1] = name;
      worksheet.Cells[1, 2] = neptun;

      worksheet.Rows[1].Font.Bold = true;

      string[] students = new string[] { "Gipsz Jakab", "Mekk Elek", "Nagy Lajos" };
      string[] neptuns = new string[] { "ABC123", "QWE123", "A2B3C4" };

      int rowOffset = 2;

      for (int i = 0; i < students.Length; i++)
      {
        worksheet.Cells[i + rowOffset, 1] = students[i];
        worksheet.Cells[i + rowOffset, 2] = neptuns[i];
      }

      // set the columns to fit their width automatically
      for (int j = 1; j <= 2; j++)
      {
        worksheet.Columns[j].AutoFit();
      }

      worksheet.SaveAs(path);
      //excelApp.Quit();
    }
  }
}
