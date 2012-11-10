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
using System.Windows.Shapes;

using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;

namespace BUTEClassAdministrationClient
{
    /// <summary>
    /// Interaction logic for InsertStudent.xaml
    /// </summary>
    public partial class InsertStudentWindow : Window
    {
        //private Student student;
        private string[] coursesArray;

        public Semester semester { get; set; }



        public InsertStudentWindow()
        {
            InitializeComponent();

           
          //  svm = new StudentViewModel();

            // Automatically resize height relative to content 
            this.SizeToContent = SizeToContent.Height;

            /*using (var service = new ClassAdministrationServiceClient())
            {
                Course[] courses = service.ReadCoursesFromSemester("2012");
                IList<String> coursesToCombobox = new List<string>();
                foreach (var course in courses)
                {
                    string s = course.Semester + " " +
                                PrettyFormatter.dayFormatter(Convert.ToInt32(course.Day_of_week)) + " " +
                                course.Starting_time + " " +
                                PrettyFormatter.parityFormatter(course.Week_parity);
                    coursesToCombobox.Add(s);
                }
                //coursesArray = coursesToCombobox.ToArray();
                coursesArray = new string[] {"A","B","C"};
                Console.WriteLine(coursesArray[0]);
            }

            using (var service = new ClassAdministrationServiceClient())
            {
                student = service.GetStudent();
            }*/
        }

        public string[] Courses 
        { 
            get 
            { 
                return coursesArray; 
            } 
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Insert(object sender, RoutedEventArgs e)
        {
            using (var service = new ClassAdministrationServiceClient())
            {
                Student student = new Student();

                student.Name = nameTxtBox.Text;
                student.Neptun = neptunTxtBox.Text;
                student.Course = null;
                student.Semester = service.ReadSemesters().First(); // oh my

                service.CreateStudents(new Student[] { student });
                student.AcceptChanges();

                MessageBox.Show("Rekord beszúrva.");
            }
        }

        private void coursesCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
