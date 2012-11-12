using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;

namespace Database_Design
{
  class Worker
  {
    public void Test()
    {
      using (TerembeosztoEntitasok ctx = new TerembeosztoEntitasok())
      {
        var terem = new Terem();
        terem.Nev = "V2.637";
        terem.Gepek_szama = 20;
        terem.Ulohelyek_szama = 25;

        ctx.TeremSet.AddObject(terem);
        ctx.SaveChanges();
      }
    }

    public void TestImport()
    {
      String path = @"C:\worksheet.xlsx";
      String name = "név";
      String neptun = "neptun kód";
      int? nameCol = null;
      int? neptunCol = null;

      // open an Excel application
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

      using (TerembeosztoEntitasok ctx = new TerembeosztoEntitasok())
      {

        // scan through the rows from the second row
        for (int i = 2; i <= usedRange.Rows.Count; i++)
        {
          String aktNev = usedRange.Cells[i, nameCol].Value.ToString();
          String aktNeptun = usedRange.Cells[i, neptunCol].Value.ToString();

          Hallgato hallgato = new Hallgato();
          hallgato.Felev = "";
          hallgato.Nev = aktNev;
          hallgato.Neptun = aktNeptun;
          hallgato.Kurzus = null;
          hallgato.Csoport = null;

          ctx.HallgatoSet.AddObject(hallgato);

          Console.WriteLine("#" + (i - 1));
          Console.WriteLine("    név:    " + aktNev);
          Console.WriteLine("    neptun: " + aktNeptun);
        }

        ctx.SaveChanges();
      }
      excelApp.Quit();
    }

  }
}
