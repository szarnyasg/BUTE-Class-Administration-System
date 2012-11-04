using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;

namespace BUTEClassAdministrationClient
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
    	}

        private void Insert_Student(object sender, RoutedEventArgs e)
        {
            Window asd = new InsertStudent();
            asd.ShowDialog();
        }

		void Work()
		{
			/*
			using (var service = new ClassAdministrationServiceClient())
			{
				Student s = service.GetStudent();

				Console.WriteLine(s.Name);

				s.Name = "Móricz";
				s.Neptun = "ZL2V8F";

				service.SetStudent(s);

				s.AcceptChanges();
			}*/
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			IEnumerable<Student> students = ExcelTools.ImportFromExcel(@"C:\worksheet.xlsx");

			Console.WriteLine("----------------------------");
			foreach (var student in students)
			{
				Console.WriteLine("    név:    " + student.Name);
				Console.WriteLine("    neptun: " + student.Neptun);
			}

			using (var service = new ClassAdministrationServiceClient())
			{
				service.CreateStudents(students.ToArray());
			}

			/* 
			 Excel file dialog
			 
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.FileName = "";
			dlg.DefaultExt = ".xlsx";
			dlg.Filter = "Excel-fájl | *.xls; *.xlsx";

			bool? result = dlg.ShowDialog();

			if (result == false)
			{
				return;
			}

			string filename = dlg.FileName;
			ExcelTools.ImportFromExcel(filename);
			 */
		}

		private void button2_Click(object sender, RoutedEventArgs e)
		{
			using (var service = new ClassAdministrationServiceClient())
			{
				Student first = service.ReadStudentsFromSemester("félév").First();
				
				List<Student> students = new List<Student>();
				students.Add(first);

				service.DeleteStudent(students.ToArray());
			}
		}
	}
}
