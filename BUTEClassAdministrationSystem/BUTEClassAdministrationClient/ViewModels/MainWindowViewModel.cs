using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace BUTEClassAdministrationClient
{
    public class MainWindowViewModel : ViewModelBase
    {

        #region Fields, properties

		#region SemesterPairs property

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

		#endregion

		#region SelectedSemester property

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

		#endregion

		#region CoursePairs property

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
		
		#endregion

		#region SelectedCourse property

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

		#region TargetCoursePairs

		private ObservableCollection<ComboBoxCoursePair> _targetCoursePairs;

		public ObservableCollection<ComboBoxCoursePair> TargetCoursePairs
		{
			get { return _targetCoursePairs; }
			set
			{
				if (_targetCoursePairs != value)
				{
					_targetCoursePairs = value;
					NotifyPropertyChanged("TargetCoursePairs");
				}
			}
		}

		#endregion

		#region SelectedTargetCourse property

		private Course _selectedTargetCourse;

		public Course SelectedTargetCourse
		{
			get { return _selectedTargetCourse; }
			set
			{
				if (_selectedTargetCourse != value)
				{
					_selectedTargetCourse = value;
					NotifyPropertyChanged("SelectedTargetCourse");
				}
			}
		}

		#endregion

		#region SelectedStudent

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

		#endregion

		#region StudentsForDataGrid

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

		#endregion

		#region Constructor

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
			TargetCoursePairs = new ObservableCollection<ComboBoxCoursePair>();            
            StudentsForDatagrid = new ObservableCollection<Student>();
        }

		#endregion

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
            changeCourseExecuted();
        }

        public bool insertStudenCanExecuted()
        {
            return (SelectedSemester != null && SelectedCourse != null);
        }

        #endregion 

        #region show Instructor window command members

        private DelegateCommand _instructorCommand;
        public ICommand InstructorCommand
        {
            get
            {
                if (_instructorCommand == null)
                    _instructorCommand = new DelegateCommand(new Action(InstructorExecuted));
                return _instructorCommand;
            }
        }

        public void InstructorExecuted()
        {
            ListOFInstructorsViewModel instructorViewModel = new ListOFInstructorsViewModel();
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

		#region delete student command members
		private DelegateCommand _deleteStudentCommand;
		public ICommand DeleteStudentCommand
		{
			get
			{
				if (_deleteStudentCommand == null)
					_deleteStudentCommand = new DelegateCommand(new Action(deleteStudentExecuted), new Func<bool>(deleteStudentCanExecuted));
				return _deleteStudentCommand;
			}
		}

		public void deleteStudentExecuted()
		{
			using (var service = new ClassAdministrationServiceClient())
			{
				service.DeleteStudents(new int[] { SelectedStudent.Id });
				//MessageBox.Show("Rekord törölve.");
				
				// refresh datagrid
				changeCourseExecuted();
			}
		}

		public bool deleteStudentCanExecuted()
		{
			return (SelectedStudent != null);
		}

		#endregion

		#region move student command members
		private DelegateCommand _moveStudentCommand;
		public ICommand MoveStudentCommand
		{
			get
			{
				if (_moveStudentCommand == null)
					_moveStudentCommand = new DelegateCommand(new Action(moveStudentExecuted), new Func<bool>(moveStudenCanExecuted));
				return _moveStudentCommand;
			}
		}

		public void moveStudentExecuted()
		{
			using (var service = new ClassAdministrationServiceClient())
			{
				service.MoveStudent(SelectedStudent.Id, SelectedTargetCourse.Id);

				// refresh datagrid
				changeCourseExecuted();
			}
		}

		public bool moveStudenCanExecuted()
		{
			return (SelectedStudent != null) && (SelectedTargetCourse != null);
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

		private Group newGroup(ref List<Room>.Enumerator roomEnumerator, ref List<Instructor>.Enumerator instructorEnumerator, Course course)
		{
			//Console.WriteLine("---------> new group");
			Group group = new Group();
			group.Course = course;

			if (!roomEnumerator.MoveNext())
			{
				throw new Exception("Nincs elég terem a beosztáshoz");
			}

			group.Room = roomEnumerator.Current;

			Console.WriteLine(roomEnumerator.Current.Name);

			instructorEnumerator.MoveNext();
			group.Instructor = instructorEnumerator.Current;

			return group;
		}

        public void assignExecuted()
        {
			using (var service = new ClassAdministrationServiceClient())
			{
				List<Course> courses = service.ReadCoursesFromSemester(SelectedSemester.Id).ToList();

				List<Instructor> instructors = service.ReadInstructors().ToList();
				List<Instructor>.Enumerator instructorEnumerator = instructors.GetEnumerator();

				List<Group> groups = new List<Group>();

				try
				{

					foreach (var course in courses)
					{
						Console.WriteLine("################### " + course.Id + " ####################");

						List<Student> students = service.ReadStudentsFromCourse(course.Id).ToList();

						// no group for empty courses --> continue with the other courses
						if (students.Count() == 0) continue;

						List<Room> rooms = service.ReadRoomsFromCourse(course.Id).ToList();
						List<Room>.Enumerator roomEnumerator = rooms.GetEnumerator();

						Console.WriteLine(course.Id);
						Console.WriteLine(rooms.Count());

						// create new group
						groups.Add(newGroup(ref roomEnumerator, ref instructorEnumerator, course));

						foreach (var student in students)
						{
							Group group = groups.Last();

							// if we reached the maximum computer count, add new group
							if (group.Student.Count() == group.Room.Computer_count)
							{
								groups.Add(newGroup(ref roomEnumerator, ref instructorEnumerator, course));
								group = groups.Last();
							}

							// set the students group and add the student to the collection
							student.Group = group;
							group.Student.Add(student);
						}

						Console.WriteLine("Groups in course");
						Console.WriteLine("================");
						foreach (var item in groups)
						{
							Console.WriteLine(item);
							List<Student> groupsStudents = item.Student.ToList();

							Console.WriteLine("Room " + item.Room);
							foreach (var st in groupsStudents)
							{
								Console.WriteLine(st.Name);
							}
						}
					}

				} catch (Exception e) {
					MessageBox.Show(e.ToString());
				}

				// UI				
				AssignmentViewModel assignmentViewModel = new AssignmentViewModel(groups);
			}

        }

        public bool assignCanExecuted()
        {
			return (SelectedSemester != null);
        }

        #endregion

        #region change course command members

        private DelegateCommand _changeCourseCommand;
        public ICommand ChangeCourseCommand
        {
            get
            {
                if (_changeCourseCommand == null)
                    _changeCourseCommand = new DelegateCommand(new Action(changeCourseExecuted), new Func<bool>(changeCourseCanExecuted));
                return _changeCourseCommand;
            }
        }

        public void changeCourseExecuted()
        {
            StudentsForDatagrid.Clear();

			if (SelectedCourse == null) return;

            // load datagrid with students
			using (var service = new ClassAdministrationServiceClient())
            {                
				Student[] students = service.ReadStudentsFromCourse(SelectedCourse.Id);
       
                foreach (var student in students)
                {
                    StudentsForDatagrid.Add(student);
                }
            }

			// load target course combobox
			TargetCoursePairs.Clear();
			foreach (var coursePair in CoursePairs)
			{
				if (((Course)coursePair.CourseObject).Id != SelectedCourse.Id)
				{
					TargetCoursePairs.Add(coursePair);
				}
			}

        }

        public bool changeCourseCanExecuted()
        {
            return (SelectedSemester != null);
        }

        #endregion

    }
}
