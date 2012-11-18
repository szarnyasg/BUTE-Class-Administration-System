using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using BUTEClassAdministrationTypes;
using System.ComponentModel;
using BUTEClassAdministrationClient.ViewModels;



namespace BUTEClassAdministrationClient
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        #region Fields, properties

        private List<ComboBoxSemesterPair> _semesterPairs;

        public List<ComboBoxSemesterPair> SemesterPairs
        {
            get { return _semesterPairs; }
            set
                {
                    if (_semesterPairs != value)
                    {
                        _semesterPairs = value;
                        NotifyPropertyChanged("SemesterPairs");
                    }
                }
             
        }

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

        private List<ComboBoxCoursePair> _coursePairs;

        public List<ComboBoxCoursePair> CoursePairs
        {
            get { return _coursePairs; }
            set
            {
                if (_coursePairs != value)
                {
                    _coursePairs = value;
                    NotifyPropertyChanged("CoursePairs");
                }
            }

        }

        private Course _selectedCourse;

        public Course SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                if (_selectedCourse != value)
                {
                    _selectedCourse = value;
                    NotifyPropertyChanged("SelectedCourse");
                }
            }

        }

        #endregion


        public MainWindowViewModel()
        {

            SemesterPairs = new List<ComboBoxSemesterPair>();
            CoursePairs = new List<ComboBoxCoursePair>();

            using (var service = new ClassAdministrationServiceClient())
            {
                Semester[] semesters = service.ReadSemesters();
                foreach (var semester in semesters)
                {
                    SemesterPairs.Add(new ComboBoxSemesterPair() { SemesterObject = semester, SemesterString = semester.Name });
                }
            }

            CoursePairs = new List<ComboBoxCoursePair>();
            CoursePairs.Add(new ComboBoxCoursePair() { CourseObject = new Course(), CourseString = "Kérem, válasszon szemesztert."});

        }

        #region change selected item in semester combobox command members

        private DelegateCommand _changeSemesterCommand;
        public ICommand ChangeSemesterCommand
        {
            get
            {
                if (_changeSemesterCommand == null)
                    _changeSemesterCommand = new DelegateCommand(new Action(changeCourseCmbExecuted));
                return _changeSemesterCommand;
            }
        }

        public void changeCourseCmbExecuted()
        {
            CoursePairs.Clear();

            using (var service = new ClassAdministrationServiceClient())
            {
                Course[] courses = service.ReadCoursesFromSemester(SelectedSemester.Id);
                foreach (var course in courses)
                {
                    CoursePairs.Add(new ComboBoxCoursePair() 
                    { 
                        CourseObject = course,
                        CourseString = PrettyFormatter.dayFormatter(Convert.ToInt32(course.Day_of_week)) + ' '
                                            + course.Starting_time + ' '
                                            + PrettyFormatter.parityFormatter(course.Week_parity)
                                            
                    });
                    NotifyPropertyChanged("CoursePairs");
                }
            }
        }

        #endregion

        #region insert Student command members

        private DelegateCommand _insertStudentCommand;
        public ICommand InsertStudentCommand
        {
            get
            {
                if (_insertStudentCommand == null)
                    _insertStudentCommand = new DelegateCommand(new Action(insertStudentExecuted), new Func<bool>(insertStudenCanExecuted));
                return _insertStudentCommand;
            }
        }

        public void insertStudentExecuted()
        {
            StudentViewModel studentViewModel = new StudentViewModel(SelectedSemester, SelectedCourse);
        }

        public bool insertStudenCanExecuted()
        {
            if (SelectedSemester != null && SelectedCourse != null)
                return true;
            else return false;            
        }

        #endregion 

        #region insert Instructor command members

        private DelegateCommand _insertInstructorCommand;
        public ICommand InsertInstructorCommand
        {
            get
            {
                if (_insertInstructorCommand == null)
                    _insertInstructorCommand = new DelegateCommand(new Action(insertInstructorExecuted));
                return _insertInstructorCommand;
            }
        }

        public void insertInstructorExecuted()
        {
            InstructorViewModel studentViewModel = new InstructorViewModel();
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
    }

}
