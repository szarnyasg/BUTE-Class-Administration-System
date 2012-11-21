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
		public AssignmentWindow AssignmentWindow { get; set; }

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

			AssignmentWindow = new AssignmentWindow();
			AssignmentWindow.DataContext = this;
			AssignmentWindow.ShowDialog();
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
            AssignmentWindow.Close();
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
