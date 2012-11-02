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
using STESchoolModelWPFTest.ServiceReference1;
using STESchoolModelTypes;

namespace STESchoolModelWPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    // <snippetSTESchoolModelWPFTestCodeBehind>
    public partial class MainWindow : Window
    {
        private List<Department> departments;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var service = new Service1Client())
            {
                // Set the parent of of your data bound controls to the root of the graph.
                // In the xaml page the appropriate paths should be set on each data bound control.
                // For the comboBoxDepartment it is empty because it is bound to Departments (which is root).
                // For the listViewItems it is set to Courses because it is bound to Department.Courses.
                // Note, that the TextBox controls are embedded in the two of the columns in the listViewItems.
                // This is done to enable editing in the ListView control.
                departments = service.GetDepartments();
                this.departmentsItemsGrid.DataContext = departments;
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            using (var service = new Service1Client())
            {
                // Save all the departments and their courses. 
                foreach (var department in departments)
                {
                    service.UpdateDepartment(department);

                    // Call AcceptChanges on all the objects 
                    // to resets the change tracker and set the state of the objects to Unchanged.
                    department.AcceptChanges();
                    foreach (var course in department.Courses)
                        course.AcceptChanges();
                }
            }

        }

        private void buttonClose_Click_1(object sender, RoutedEventArgs e)
        {
            //Close the form.
            this.Close();
        }
    }
    // </snippetSTESchoolModelWPFTest>
}
