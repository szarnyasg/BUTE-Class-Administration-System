using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using System.Windows;
using System.ComponentModel;

namespace BUTEClassAdministrationClient
{
    public class StudentViewModel : INotifyPropertyChanged
    {

        Window insertStudentWindow;

        public Student _student;


        #region Properties

        public string Name
        {
            get
            {
                return _student.Name;
            }
            set
            {
                if (_student.Name != value)
                {
                    _student.Name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public string Neptun
        {
            get
            {
                return _student.Neptun;
            }
            set
            {
                if (_student.Neptun != value)
                {
                    _student.Neptun = value;
                    NotifyPropertyChanged("Neptun");
                }
            }
        }

        public Semester Semester
        {
            get
            {
                return _student.Semester;
            }
            set
            {
                if (_student.Semester != value)
                {
                    _student.Semester = value;
                    NotifyPropertyChanged("Semester");
                }
            }
        }

        #endregion

        #region Construktor

        public StudentViewModel(Semester selectedSemester)
        {
            _student = new Student();

            Name = "";
            Neptun = "";
            Semester = selectedSemester;

            insertStudentWindow = new InsertStudentWindow();

            insertStudentWindow.DataContext = this;

            insertStudentWindow.ShowDialog();
        }

        #endregion

        #region saveStudentCommand members

        private DelegateCommand _saveStudentCommand;
        public ICommand SaveStudentCommand
        {
            get
            {
                if (_saveStudentCommand == null)
                    _saveStudentCommand = new DelegateCommand(new Action(saveExecuted), new Func<bool>(saveCanExecuted));
                return _saveStudentCommand;
            }
        }

        public bool saveCanExecuted()
        {
            return NameValidator.nameIsValid(Name) && NeptunValidator.neptunIsValid(Neptun);
        }

        public void saveExecuted()
        {
            using (var service = new ClassAdministrationServiceClient())
            {
                
                service.CreateStudents(new Student[] { _student });
                _student.AcceptChanges();

                MessageBox.Show("Rekord beszúrva.");

            }
        }

        #endregion

        #region INotifyPropertyChanged memers

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
