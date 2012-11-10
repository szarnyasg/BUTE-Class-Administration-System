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
    internal class StudentViewModel //: INotifyPropertyChanged
    {
        public Student _student;
        
        public string Name
        {
            get
            {
                return _student.Name;
            }
            set
            {
                _student.Name = value;
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
                _student.Neptun = value;
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
                _student.Semester = value;
            }
        }

        public StudentViewModel()
        {
            _student = new Student();

            Name = "";
            Neptun = "";

        }

        #region savePersonCommand members
        
        private DelegateCommand _savePersonCommand;
        public ICommand SavePersonCommand
        {
            get
            {
                if (_savePersonCommand == null)
                    _savePersonCommand = new DelegateCommand(new Action(saveExecuted), new Func<bool>(saveCanExecuted));
                return _savePersonCommand;
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
                Semester = service.ReadSemesters().First();

                service.CreateStudents(new Student[] { _student });
                _student.AcceptChanges();

                MessageBox.Show("Rekord beszúrva.");

            }
        }

        #endregion


    }
}
