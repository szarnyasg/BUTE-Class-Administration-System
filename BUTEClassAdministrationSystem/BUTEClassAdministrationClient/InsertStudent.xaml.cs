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
    public partial class InsertStudent : Window
    {
        private Student student;

        public InsertStudent()
        {
            InitializeComponent();

            using (var service = new ClassAdministrationServiceClient())
            {
                student = service.GetStudent();
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
                student.Name = "Cuppa";
                student.Neptun = "987654";

                service.SetStudent(student);

                student.AcceptChanges();
            }
        }
    }
}
