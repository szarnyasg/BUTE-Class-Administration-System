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
    public class StudentViewModel //: INotifyPropertyChanged
    {
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

        #endregion

        public StudentViewModel()
        {
            _student = new Student();

            Name = "";
            Neptun = "";

           
        }

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
                Semester = service.ReadSemesters().First();

                service.CreateStudents(new Student[] { _student });
                _student.AcceptChanges();

                MessageBox.Show("Rekord beszúrva.");

            }
        }

        #endregion


    }
}
