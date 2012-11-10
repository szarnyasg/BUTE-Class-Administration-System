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
        #region properties
        
        private StudentViewModel _studentViewModel;
        public StudentViewModel StudentViewModel 
        {
            get { return _studentViewModel; }
            set {_studentViewModel = value;} 
        }

        public Semester semester { get; set; }

        #endregion

        public InsertStudentWindow(Semester selectedSemester)
        {
            InitializeComponent();

            // Automatically resize height relative to content 
            this.SizeToContent = SizeToContent.Height;

            _studentViewModel = new StudentViewModel(selectedSemester);

            DataContext = this;
        }




    }
}
