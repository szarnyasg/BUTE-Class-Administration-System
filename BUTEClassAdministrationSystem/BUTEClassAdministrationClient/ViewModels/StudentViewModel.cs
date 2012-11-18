using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using System.Windows;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace BUTEClassAdministrationClient
{
    public class StudentViewModel : INotifyPropertyChanged, IDataErrorInfo
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

        public Course Course
        {
            get
            {
                return _student.Course;
            }
            set
            {
                if (_student.Course != value)
                {
                    _student.Course = value;
                    NotifyPropertyChanged("Course");
                }
            }
        }

        public string CourseToString
        {
            get
            {
                return PrettyFormatter.dayFormatter(Convert.ToInt32(Course.Day_of_week)) + ' '
                                            + Course.Starting_time + ' '
                                            + PrettyFormatter.parityFormatter(Course.Week_parity);
            }
        }

        public string SemesterToString
        {
            get
            {
                return Semester.Name;
            }
        }


        #endregion

        #region Construktor

        public StudentViewModel(Semester selectedSemester, Course selectedCourse)
        {
            _student = new Student();

            Name = "";
            Neptun = "";
            Semester = selectedSemester;

            Course = selectedCourse;

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
                    _saveStudentCommand = new DelegateCommand(new Action(saveExecuted), new Func<bool>(saveCanExecute));
                return _saveStudentCommand;
            }
        }

        public bool saveCanExecute()
        {
            return nameIsValid(Name) && neptunIsValid(Neptun);
        }

        public void saveExecuted()
        {
            using (var service = new ClassAdministrationServiceClient())
            {
                
                service.CreateStudents(new Student[] { _student });
                _student.AcceptChanges();

                MessageBox.Show("Rekord beszúrva.");

                insertStudentWindow.Close();
            }
        }

        #endregion

        #region cancelCommand members

        private DelegateCommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new DelegateCommand(new Action(cancelExecuted));
                return _cancelCommand;
            }
        }

        public void cancelExecuted()
        {
            insertStudentWindow.Close();
        }
    

        #endregion

        #region INotifyPropertyChanged members

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region validation

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { return validateStudent(columnName); }
        }

        private string validateStudent(string propName)
        {
            
            switch (propName)
            {
                case "Name":
                    {
                        if (nameIsValid(Name)) return null;
                        else return "Kérem adja meg a hallgató nevét!";
                    }
                case "Neptun":
                    {
                        if (neptunIsValid(Neptun)) return null;
                        else return "A Neptunkód nincs megadva, vagy hibás formátumú.";
                    }
                default:
                    return "Nem leteyo properti validalas.";
            }

        }

        public bool nameIsValid(string value)
        {
            return (value.Length > 0);
        }

        public bool neptunIsValid(string value)
        {
            string neptunregex = @"^[A-Z][A-Z0-9]{5}$";
            return Regex.IsMatch(value, neptunregex, RegexOptions.IgnoreCase);
        }

        public static bool emailIsValid(string value)
        {
            string emailregex = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return Regex.IsMatch(value, emailregex, RegexOptions.IgnoreCase);

        }

        #endregion 
    }
}
