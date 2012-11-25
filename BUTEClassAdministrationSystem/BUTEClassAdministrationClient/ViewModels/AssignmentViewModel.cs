using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using BUTEClassAdministrationClient.View;
using System.Windows.Input;
using System.ComponentModel;

namespace BUTEClassAdministrationClient.ViewModels
{
	public class AssignmentViewModel : ViewModelBase, IDataErrorInfo
	{
		private AssignmentWindow _assignmentWindow;

		#region SelectedGroup

		private Group _selectedGroup;
        public Group SelectedGroup 
        { 
            get{ return _selectedGroup; } 
            set
            {
                if (_selectedGroup != value)
                {
                    _selectedGroup = value;
					NotifyPropertyChanged("SelectedGroup");
					NotifyPropertyChanged("Time");
					NotifyPropertyChanged("Room");
					NotifyPropertyChanged("Instructor");
					NotifyPropertyChanged("ComputerCount");
					NotifyPropertyChanged("SeatingCapacity");
                }
            }     
        }

		#endregion

		#region StudentsForDatagrid

		private ObservableCollection<Student> _studentsForDatagrid;
		public ObservableCollection<Student> StudentsForDatagrid
		{
			get { return _studentsForDatagrid; }
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

		#region group properties

		public String Time
		{
			get
			{
				return SelectedGroup != null ? SelectedGroup.Course.Starting_time.ToString() : "";
			}
		}

		public String Room
		{
			get
			{
				return SelectedGroup != null ? SelectedGroup.Room.Name : "";
			}
		}

		public String Instructor
		{
			get
			{
				return SelectedGroup != null ? SelectedGroup.Instructor.Name : "";
			}
		}

		public String SeatingCapacity
		{
			get
			{
				return SelectedGroup != null ? SelectedGroup.Room.Seating_capacity.ToString() : "";
			}
		}

		public String ComputerCount
		{
			get
			{
				return SelectedGroup != null ? SelectedGroup.Room.Computer_count.ToString() : "";
			}
		}


		#endregion
		
		#region Students property

		public ObservableCollection<Student> Students
		{
			get
			{
				return SelectedGroup == null ? new ObservableCollection<Student>() : SelectedGroup.Student;
			}
		}

		#endregion

		#region GroupsForComboBox

		private ObservableCollection<ComboBoxGroupPair> _groupsForComboBox;
        public ObservableCollection<ComboBoxGroupPair> GroupsForCombobox
        {
            get { return _groupsForComboBox; }
            set
            {
                if (_groupsForComboBox != value)
                {
                    _groupsForComboBox = value;
                    NotifyPropertyChanged("GroupsForCombobox");
                }
            }
        }

        #endregion

        #region constructor

        public AssignmentViewModel(List<Group> groups)
        {
			_groups = groups;

            GroupsForCombobox = new ObservableCollection<ComboBoxGroupPair>();
			foreach (var group in groups)
			{
                GroupsForCombobox.Add(new ComboBoxGroupPair() { 
                    GroupObject = group ,
                    GroupString =
						group.Index + ". " +
						PrettyFormatter.dayFormatter(Convert.ToInt32(group.Course.Day_of_week)) + " " +
                        group.Course.Starting_time + " " +
						PrettyFormatter.parityFormatter(group.Course.Week_parity) + " " +
                        "(" + group.Room.Name + ")"
				});
			}

			StudentsForDatagrid = new ObservableCollection<Student>();
			TargetGroupPairs = new ObservableCollection<ComboBoxGroupPair>();

			_student = new Student();
			_student.Name = "x";

			_assignmentWindow = new AssignmentWindow();
			_assignmentWindow.DataContext = this;
			_assignmentWindow.ShowDialog();
        }

        #endregion

        #region close command

        private DelegateCommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new DelegateCommand(new Action(closeExecuted));
                return _closeCommand;
            }
        }

        public void closeExecuted()
        {
			using (var service = new ClassAdministrationServiceClient())
			{
				if (_groups.Count > 0)
				{
					service.DeleteGroups(_groups[0].Semester.Id);
					service.CreateGroup(_groups.ToArray());
				}
			}

            _assignmentWindow.Close();
        }

        #endregion

		#region export to Excel command

		private DelegateCommand _exportToExcelCommand;
		public ICommand ExportToExcelCommand
		{
			get
			{
				if (_exportToExcelCommand == null)
					_exportToExcelCommand = new DelegateCommand(new Action(exportToExcelExecuted));
				return _exportToExcelCommand;
			}
		}

		public void exportToExcelExecuted()
		{
			Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
			dlg.FileName = "";
			dlg.DefaultExt = ".xlsx";
			dlg.Filter = "Excel-fájl | *.xls; *.xlsx";

			bool? result = dlg.ShowDialog();

			if (result == false)
			{
				return;
			}

			string filename = dlg.FileName;
			
			ExcelTools.ExportToExcel(filename, _groups);
		}

		#endregion
		
		#region cmbChange command

        private DelegateCommand _groupChange;
        public ICommand GroupChange
        {
            get
            {
                if (_groupChange == null)
                    _groupChange = new DelegateCommand(new Action(changeGroupExecuted));
                return _groupChange;
            }
        }

        public void changeGroupExecuted()
        {
			StudentsForDatagrid.Clear();
			if (SelectedGroup == null) return;

			// load datagrid with students
			foreach (var student in SelectedGroup.Student)
			{
				StudentsForDatagrid.Add(student);
			}

			// load target group combobox
			TargetGroupPairs.Clear();
			foreach (var groupPair in GroupsForCombobox)
			{
				if (((Group)groupPair.GroupObject).Index != SelectedGroup.Index)
				{
					TargetGroupPairs.Add(groupPair);
				}
			}
        }

        #endregion

		#region TargetGroupPairs

		private ObservableCollection<ComboBoxGroupPair> _targetGroupPairs;
		public ObservableCollection<ComboBoxGroupPair> TargetGroupPairs
		{
			get { return _targetGroupPairs; }
			set
			{
				if (_targetGroupPairs != value)
				{
					_targetGroupPairs = value;
					NotifyPropertyChanged("TargetGroupPairs");
				}
			}
		}

		#endregion

		#region SelectedTargetGroup property

		private Group _selectedTargetGroup;
		public Group SelectedTargetGroup
		{
			get { return _selectedTargetGroup; }
			set
			{
				if (_selectedTargetGroup != value)
				{
					_selectedTargetGroup = value;
					NotifyPropertyChanged("SelectedTargetGroup");
				}
			}
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
			SelectedGroup.Student.Remove(SelectedStudent);
			
			SelectedTargetGroup.Student.Add(SelectedStudent);
			
			// modify the students course accordingly
			SelectedStudent.Course = SelectedGroup.Course;

			changeGroupExecuted();
		}

		public bool moveStudenCanExecuted()
		{
			return (SelectedStudent != null) && (SelectedTargetGroup != null);
		}

		#endregion

		#region SelectedStudent

		private Student _selectedStudent;
		private List<Group> _groups;

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


		private Student _student;
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
				default:
					return "";
			}

		}

		public bool nameIsValid(string value)
		{
			return (value.Length > 0);
		}
    }
}
