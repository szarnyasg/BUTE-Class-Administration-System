using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;

using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;

namespace BUTEClassAdministrationClient
{
	class ExcelTools
	{

		public static void ExportToExcel(string filename)
		{
			throw new NotImplementedException();
		}

		public static IEnumerable<Student> ImportFromExcel(string filename)
		{
			const String nameColumnName = "név";
			const String neptunColumnName = "neptun kód";

			int? nameColumnIndex = null;
			int? neptunColumnIndex = null;

			// open an Excel application
			Excel.Application excelApp = new Excel.Application();
			excelApp.Visible = false;

			// open the workbook in read-only mode
			Excel.Workbook workbook = excelApp.Workbooks.Open(filename, Type.Missing, true);
			Excel.Worksheet worksheet = excelApp.ActiveSheet;

			Excel.Range usedRange = worksheet.UsedRange;

			// scan through the first row to get the column indices     
			for (int j = 1; j <= worksheet.UsedRange.Columns.Count; j++)
			{
				Excel.Range cell = usedRange.Cells[1, j];
				if (cell.Value != null)
				{
					String cellValue = cell.Value.ToString();

					if (cellValue.ToLower() == nameColumnName.ToLower())
					{
						nameColumnIndex = j;
					}

					if (cellValue.ToLower() == neptunColumnName.ToLower())
					{
						neptunColumnIndex = j;
					}
				}
			}

			// throw exception if a required a column does not exist
			if (nameColumnIndex == null || neptunColumnIndex == null)
			{
				throw new Exception("Nem találhatók a szükséges oszlopok.");
			}

			// use List as an IEnumerable implementation
			List<Student> students = new List<Student>();
			// scan through the rows from the second row
			// instantiate new student entities
			for (int i = 2; i <= usedRange.Rows.Count; i++)
			{
				string name = usedRange.Cells[i, nameColumnIndex].Value.ToString();
				string neptun = usedRange.Cells[i, neptunColumnIndex].Value.ToString();

                /*
				Console.WriteLine("#" + (i - 1));
				Console.WriteLine("    név:    " + name);
				Console.WriteLine("    neptun: " + neptun);
                */
 
				Student student = new Student();
				student.Name = name;
				student.Neptun = neptun;
				student.Semester = "félév";

				students.Add(student);
			}

			excelApp.Quit();
			return students;
		}
	}
}
