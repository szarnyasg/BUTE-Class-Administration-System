using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using BUTEClassAdministrationClient.View;

namespace BUTEClassAdministrationClient.ViewModels
{
	public class AssignmentViewModel : ViewModelBase
	{
		private AssignmentWindow _assignmentWindow;

		public AssignmentViewModel(List<Group> groups)
        {
			GroupsForDatagrid = new ObservableCollection<Group>();
			foreach (var group in groups)
			{
				GroupsForDatagrid.Add(group);
			}

			_assignmentWindow = new AssignmentWindow();
			_assignmentWindow.DataContext = this;
			_assignmentWindow.ShowDialog();
        }


		#region GroupsForDataGrid

		private ObservableCollection<Group> _groupsForDatagrid;
		public ObservableCollection<Group> GroupsForDatagrid
		{
			get { Console.WriteLine(_groupsForDatagrid.Count()); return _groupsForDatagrid; }
			set
			{
				if (_groupsForDatagrid != value)
				{
					_groupsForDatagrid = value;
					NotifyPropertyChanged("GroupsForDatagrid");
				}
			}
		}

		#endregion

	}
}
