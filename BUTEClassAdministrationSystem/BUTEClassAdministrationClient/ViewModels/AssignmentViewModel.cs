using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using BUTEClassAdministrationClient.View;
using System.Windows.Input;

namespace BUTEClassAdministrationClient.ViewModels
{
	public class AssignmentViewModel : ViewModelBase
	{
		private AssignmentWindow _assignmentWindow;

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
                }
            }     
        }

        #region GroupsForDataGrid

        private ObservableCollection<ComboBoxGroupPair> _groupsForComboBox;
        public ObservableCollection<ComboBoxGroupPair> GroupsForCombobox
        {
            get { Console.WriteLine(_groupsForComboBox.Count()); return _groupsForComboBox; }
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
			foreach (var group in groups)
			{
				Console.WriteLine(group.Instructor.Name);
			}

            GroupsForCombobox = new ObservableCollection<ComboBoxGroupPair>();
			foreach (var group in groups)
			{
                GroupsForCombobox.Add(new ComboBoxGroupPair() { 
                    GroupObject = group ,
                    GroupString = PrettyFormatter.dayFormatter(Convert.ToInt32(group.Course.Day_of_week)) + ' '
                                            + group.Course.Starting_time + ' '
                                            + PrettyFormatter.parityFormatter(group.Course.Week_parity) + ' '
                                            + group.Room.Name
                });
			}

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

			ExcelTools.ExportToExcel(filename);
		}

		#endregion
		
		#region cmbChange command

        private DelegateCommand _groupChange;
        public ICommand GroupChange
        {
            get
            {
                if (_groupChange == null)
                    _groupChange = new DelegateCommand(new Action(changeExecuted));
                return _groupChange;
            }
        }

        public void changeExecuted()
        {
            // implementálásra vár
        }

        #endregion
    }
}
