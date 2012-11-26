using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;

using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using System.Collections;

namespace BUTEClassAdministrationClient
{
	class ExcelTools
	{

		public static void ExportToExcel(string filename, List<Group> groups)
		{
			String name = "név";
			String neptun = "Neptun kód";

			// open an Excel application
			Excel.Application excelApp = new Excel.Application();
			excelApp.Visible = true;
			excelApp.Workbooks.Add();
			// work in quiet mode: no prompt to overwrite the file
			excelApp.DisplayAlerts = false;

			// open the workbook

			excelApp.Worksheets.Add();

			IEnumerator ws = excelApp.Worksheets.GetEnumerator();
			while (excelApp.Worksheets.Count > 1)
			{
				excelApp.Worksheets[excelApp.Worksheets.Count-1].Delete();
			}

			Excel.Worksheet worksheet = excelApp.ActiveSheet;

			// a worksheet about the groups, instructors, rooms, etc.
			worksheet.Name = "csoportok";
			worksheet.Cells[1, 1] = "csoport";
			worksheet.Cells[1, 2] = "nap";
			worksheet.Cells[1, 3] = "időpont";
			worksheet.Cells[1, 4] = "hét";
			worksheet.Cells[1, 5] = "terem";
			worksheet.Cells[1, 6] = "gyakorlatvezető";
			worksheet.Rows[1].Font.Bold = true;

			int i = 1;
			foreach (var group in groups)
			{
				i++;
				worksheet.Cells[i, 1] = group.Index + ".";
				worksheet.Cells[i, 2] = PrettyFormatter.dayFormatter(Convert.ToInt32(group.Course.Day_of_week));
				worksheet.Cells[i, 3] = group.Course.Starting_time;
				worksheet.Cells[i, 4] = PrettyFormatter.parityFormatter(group.Course.Week_parity);
				worksheet.Cells[i, 5] = group.Room.Name;
				worksheet.Cells[i, 6] = group.Instructor.Name;
			}

			// set the columns to fit their width automatically
			for (int k = 1; k <= 6; k++)
			{
				worksheet.Columns[k].AutoFit();
			}
			
			// separate worksheet for each group
			foreach (var group in groups)
			{
				// add new worksheet after the current one
				worksheet = excelApp.Worksheets.Add(Type.Missing, worksheet);	
				worksheet.Name = group.Index + ". csoport";

				// fill the header
				worksheet.Cells[1, 1] = name;
				worksheet.Cells[1, 2] = neptun;
				worksheet.Rows[1].Font.Bold = true;

				int rowOffset = 2;
				int j = 0;

				foreach (var student in group.Student)
				{
					worksheet.Cells[j + rowOffset, 1] = student.Name;
					worksheet.Cells[j + rowOffset, 2] = student.Neptun;

					j++;	
				}

				// set the columns to fit their width automatically
				for (int k = 1; k <= 2; k++)
				{
					worksheet.Columns[k].AutoFit();
				}
			}				

			worksheet.SaveAs(filename);
			//excelApp.Quit();
		}

		public static IEnumerable<Student> ImportFromExcel(string filename, Semester semester)
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
				throw new BUTEClassAdministrationException("Nem találhatók a szükséges oszlopok.");
			}

			// use List as an IEnumerable implementation
			List<Student> students = new List<Student>();
			// scan through the rows from the second row
			// instantiate new student entities
			for (int i = 2; i <= usedRange.Rows.Count; i++)
			{
				string name = usedRange.Cells[i, nameColumnIndex].Value.ToString();
				string neptun = usedRange.Cells[i, neptunColumnIndex].Value.ToString();
				 
				Student student = new Student();
				student.Name = name;
				student.Neptun = neptun;
				student.Semester = semester;
				
				students.Add(student);
			}

			excelApp.Quit();
			return students;
		}
	}
}
