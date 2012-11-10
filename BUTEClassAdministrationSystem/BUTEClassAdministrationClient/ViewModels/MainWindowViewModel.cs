using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using BUTEClassAdministrationTypes;
using System.ComponentModel;



namespace BUTEClassAdministrationClient
{
    public class MainWindowViewModel : INotifyPropertyChanged

    {
        public List<ComboBoxSemesterPair> SemesterPairs { get; set; }

        private Semester _selectedSemester;

        public Semester SelectedSemester 
        {
            get { return _selectedSemester; }
            set
            
                {
                    if (_selectedSemester != value)
                    {
                        _selectedSemester = value;
                        NotifyPropertyChanged("SelectedSemester");
                    }
                }
             
        }

        public MainWindowViewModel()
        {

            SemesterPairs = new List<ComboBoxSemesterPair>();

            using (var service = new ClassAdministrationServiceClient())
            {
                Semester[] semesters = service.ReadSemesters();
                foreach (var semester in semesters)
                {
                    SemesterPairs.Add(new ComboBoxSemesterPair() { SemesterObject = semester, SemesterString = semester.Semester_name });
                }
            }

        }



        private void Insert()
        {
            using (var service = new ClassAdministrationServiceClient())
            {
                Semester[] semesters = service.ReadSemesters();
            }
        }

        #region INotifyPropertyChanged methods

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

}
