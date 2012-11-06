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
        StudentModelView studentModelView;

		public MainWindow()
		{
			InitializeComponent();
            studentModelView = new StudentModelView();
    	}

        private void InsertStudent_Click(object sender, RoutedEventArgs e)
        {
            Window window = new InsertStudentWindow();
            window.ShowDialog();

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

			}*/
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

        private void ImportFromExcel_Click(object sender, RoutedEventArgs e)
        {
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
            IEnumerable<Student> students = ExcelTools.ImportFromExcel(filename);

            using (var service = new ClassAdministrationServiceClient())
            {
                service.CreateStudents(students.ToArray());
                Console.WriteLine(students.Count());
            }

        }
	}
}
