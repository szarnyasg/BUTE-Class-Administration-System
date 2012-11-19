using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ViewModels;
using System.Collections.ObjectModel;



namespace BUTEClassAdministrationClient
{
    public class MainWindowViewModel : ViewModelBase
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

        private ObservableCollection<ComboBoxCoursePair> _coursePairs;

        public ObservableCollection<ComboBoxCoursePair> CoursePairs
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

        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    NotifyPropertyChanged("SelectedStudent");
                }
            }
        }

        private ObservableCollection<Student> _studentsForDatagrid;
        public ObservableCollection<Student> StudentsForDatagrid
        {
            get {return _studentsForDatagrid; }
            set
            {
                if (_studentsForDatagrid != value)
                {
                    _studentsForDatagrid = value;
                    NotifyPropertyChanged("StudentsForDatagrid");
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
                    SemesterPairs.Add(new ComboBoxSemesterPair() { SemesterObject = semester, SemesterString = semester.Name });
                }
            }

            CoursePairs = new ObservableCollection<ComboBoxCoursePair>();
            
            StudentsForDatagrid = new ObservableCollection<Student>();
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
            changeDatagridExecuted();
        }

        public bool insertStudenCanExecuted()
        {
            return (SelectedSemester != null && SelectedCourse != null);
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

        #region import from excel command members

        DelegateCommand _importFromExcelCommand;
        public ICommand ImportFromExcelCommand
        {
            get
            {
                if (_importFromExcelCommand == null)
                    _importFromExcelCommand = new DelegateCommand(new Action(importFromExcelExecuted), new Func<bool>(importFromExcelCanExecuted));
                return _importFromExcelCommand;
            }
        }

        public void importFromExcelExecuted()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "";
            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "Excel-fájl | *.xls; *.xlsx";

            bool? result = dlg.ShowDialog();

            if (result == false)
            {
                return;
            }

            string filename = dlg.FileName;

            using (var service = new ClassAdministrationServiceClient())
            {
                Semester semester = service.ReadSemesters().First();
                IEnumerable<Student> students = ExcelTools.ImportFromExcel(filename, semester);

                service.CreateStudents(students.ToArray());
                Console.WriteLine(students.Count());
            }
        }

        public bool importFromExcelCanExecuted()
        {
            return (SelectedSemester != null) && (SelectedCourse != null);
        }

        #endregion 

        #region modify student command members
        private DelegateCommand _modifyStudentCommand;
        public ICommand ModifyStudentCommand
        {
            get
            {
                if (_modifyStudentCommand == null)
                    _modifyStudentCommand = new DelegateCommand(new Action(modifyStudentExecuted), new Func<bool>(modifyStudenCanExecuted));
                return _modifyStudentCommand;
            }
        }

        public void modifyStudentExecuted()
        {
            StudentViewModel studentViewModel = new StudentViewModel(SelectedStudent, SelectedSemester, SelectedCourse);
        }

        public bool modifyStudenCanExecuted()
        {
            return (SelectedStudent != null);
        }

        #endregion

        #region assign command members

        private DelegateCommand _assignCommand;
        public ICommand AssignCommand
        {
            get
            {
                if (_assignCommand == null)
                    _assignCommand = new DelegateCommand(new Action(assignExecuted), new Func<bool>(assignCanExecuted));
                return _assignCommand;
            }
        }

		private Group newGroup(List<Room>.Enumerator roomEnumerator, List<Instructor>.Enumerator instructorEnumerator)
		{
			Group group = new Group();

			roomEnumerator.MoveNext();
			group.Room = roomEnumerator.Current;

			instructorEnumerator.MoveNext();
			group.Instructor = instructorEnumerator.Current;

			return group;
		}

        public void assignExecuted()
        {
			// ide ird amit akarsz 

			using (var service = new ClassAdministrationServiceClient())
			{
				List<Course> courses = service.ReadCoursesFromSemester(SelectedSemester.Id).ToList();

				List<Instructor> instructors = service.ReadInstructors().ToList();
				List<Instructor>.Enumerator instructorEnumerator = instructors.GetEnumerator();

				List<Room> rooms = service.ReadRooms().ToList();
				List<Room>.Enumerator roomEnumerator = rooms.GetEnumerator();

				List<Group> groups = new List<Group>();

				foreach (var course in courses)
				{
					Console.WriteLine("# " + course.Id);

					groups.Add(newGroup(roomEnumerator, instructorEnumerator));				
					
					List<Student> students = service.ReadStudentsFromCourse(course.Id).ToList();
					foreach (var student in students)
					{
						Group group = groups.Last();
						if (group.Room.Computer_count == group.Student.Count())
						{
							groups.Add(newGroup(roomEnumerator, instructorEnumerator));
							group = groups.Last();
						}


						student.Group = group;
						group.Student.Add(student);
						//group.Student.Room();


					}

					foreach (var student in students)
					{
						

						Console.WriteLine(student.Name);
					}


					foreach (var item in groups)
					{
						Console.WriteLine(item);
						List<Student> groupsStudents = item.Student.ToList();
						

						
					}



				}
			}

        }

        public bool assignCanExecuted()
        {
			return (SelectedSemester != null);
        }

        #endregion

        #region change datagrid source

        private DelegateCommand _changeDatagridCommand;
        public ICommand ChangeDatagridCommand
        {
            get
            {
                if (_changeDatagridCommand == null)
                    _changeDatagridCommand = new DelegateCommand(new Action(changeDatagridExecuted), new Func<bool>(changeExecutedCanExecuted));
                return _changeDatagridCommand;
            }
        }

        public void changeDatagridExecuted()
        {
            StudentsForDatagrid.Clear();

			if (SelectedCourse == null) return;

            using (var service = new ClassAdministrationServiceClient())
            {                
				Student[] students = service.ReadStudentsFromCourse(SelectedCourse.Id);
       
                foreach (var student in students)
                {
                    StudentsForDatagrid.Add(student);
                }
            }
        }

        public bool changeExecutedCanExecuted()
        {
            return (SelectedSemester != null);
        }

        #endregion


    }

}
