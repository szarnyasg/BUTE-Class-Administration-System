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

            using (var service = new ClassAdministrationServiceClient())
            {
                Semester[] semesters = service.ReadSemesters();
                foreach (var semester in semesters)
                {
                    SemesterPairs.Add(new ComboBoxSemesterPair() { SemesterObject = semester, SemesterString = semester.Semester_name });
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
                    _changeSemesterCommand = new DelegateCommand(new Action(saveExecuted));
                return _changeSemesterCommand;
            }
        }

        public void saveExecuted()
        {
            CoursePairs = new List<ComboBoxCoursePair>();

            using (var service = new ClassAdministrationServiceClient())
            {
                Course[] courses = service.ReadCoursesFromSemester(SelectedSemester);
                //Student[] sss = service.ReadStudentsFromSemester(SelectedSemester);
                //Student[] sst = sss.Where(Student => Student.Course == mycourse).ToArray();
                foreach (var course in courses)
                {
                    CoursePairs.Add(new ComboBoxCoursePair() 
                    { 
                        CourseObject = course,
                        CourseString = PrettyFormatter.dayFormatter(Convert.ToInt32(course.Day_of_week))
                                            + course.Starting_time
                                            + PrettyFormatter.parityFormatter(course.Week_parity)
                                            
                    });
                }
            }
        }

        #endregion

        private void Insert()
        {
            using (var service = new ClassAdministrationServiceClient())
            {
                Semester[] semesters = service.ReadSemesters();
            }
        }

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
