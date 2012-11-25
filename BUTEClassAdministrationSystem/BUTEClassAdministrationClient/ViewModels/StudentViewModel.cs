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
using BUTEClassAdministrationClient.ViewModels;
using System.ServiceModel;

namespace BUTEClassAdministrationClient
{
    public class StudentViewModel : ViewModelBase, IDataErrorInfo
    {
        bool modify;

        Window insertStudentWindow;

		#region Fields

		private Student _student;

		#endregion

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

        public Student ModifyableStudent { get; set; }

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

        #region Constructors

        public StudentViewModel(Semester selectedSemester, Course selectedCourse)
        {
            modify = false;

            _student = new Student();

            Name = "";
            Neptun = "";
            Semester = selectedSemester;
            Course = selectedCourse;

            insertStudentWindow = new InsertStudentWindow();

            insertStudentWindow.DataContext = this;

            insertStudentWindow.ShowDialog();
        }

        public StudentViewModel(Student selectedStudent, Semester selectedSemester, Course selectedCourse)
        {
            modify = true;

            ModifyableStudent = selectedStudent;

            _student = new Student();

            _student.clone(selectedStudent);

            Semester = selectedSemester;
            Course = selectedCourse;

            insertStudentWindow = new InsertStudentWindow();

            insertStudentWindow.DataContext = this;

            insertStudentWindow.ShowDialog();
        }


        #endregion

        #region save or modify studentCommand members

        private DelegateCommand _studentCommand;
        public ICommand StudentCommand
        {
            get
            {
                if (_studentCommand == null)
                {
                    if (modify)
                        _studentCommand = new DelegateCommand(new Action(modifyExecuted), new Func<bool>(saveOrModifyCanExecuted));
                    else
                        _studentCommand = new DelegateCommand(new Action(saveExecuted), new Func<bool>(saveOrModifyCanExecuted));
                }
                return _studentCommand;
            }
        }

        public bool saveOrModifyCanExecuted()
        {
            return nameIsValid(Name) && neptunIsValid(Neptun);
        }

        public void saveExecuted()
        {
            using (var service = new ClassAdministrationServiceClient(new BasicHttpBinding(), new EndpointAddress(BUTEClassAdministrationClient.Properties.Resources.endpointAddress)))
            {
                service.CreateStudents(new Student[] { _student });
                _student.AcceptChanges();
            }

            MessageBox.Show("Rekord beszúrva.");

            insertStudentWindow.Close();
        }

        public void modifyExecuted()
        {
            ModifyableStudent.clone(_student);

            using (var service = new ClassAdministrationServiceClient(new BasicHttpBinding(), new EndpointAddress(BUTEClassAdministrationClient.Properties.Resources.endpointAddress)))
            {
                service.UpdateStudents(new Student[] { ModifyableStudent });
                _student.AcceptChanges();
            }

            MessageBox.Show("Rekord módosítva.");

            insertStudentWindow.Close();
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
                    return "";
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
