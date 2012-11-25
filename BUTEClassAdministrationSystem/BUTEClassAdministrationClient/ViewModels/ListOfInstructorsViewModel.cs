using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BUTEClassAdministrationClient.View;
using System.Windows.Input;
using System.Collections.ObjectModel;

using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using System.ServiceModel;

namespace BUTEClassAdministrationClient.ViewModels
{
    class ListOfInstructorsViewModel : ViewModelBase
    {
        ListOfInstructorsWindow listOfInstructorsWindow;

        #region properties

        private ObservableCollection<Instructor> _instructorForDataGrid;
        public ObservableCollection<Instructor> InstructorsForDataGrid 
        {
            get { return _instructorForDataGrid;  } 
            set
            {
                if (_instructorForDataGrid != value)
                {
                    _instructorForDataGrid = value;
                    NotifyPropertyChanged("InstructorsForDataGrid");
                }
            } 
        }

        private Instructor _selectedInstructor;
        public Instructor SelectedInstructor
        {
            get { return _selectedInstructor; }
            set
            {
                if (_selectedInstructor != value)
                {
                    _selectedInstructor = value;
                    NotifyPropertyChanged("SelectedInstructor");
                }
            } 
        }

        #endregion
        
        private void getInstructors()
        {
            InstructorsForDataGrid.Clear();
            using (var service = new ClassAdministrationServiceClient(new BasicHttpBinding(), new EndpointAddress(BUTEClassAdministrationClient.Properties.Resources.endpointAddress)))
            {
                Instructor[] instructors = service.ReadInstructors();
                foreach (var instructor in instructors)
                {
                    InstructorsForDataGrid.Add(instructor);
                }
            }
        }

        #region constructor

        public ListOfInstructorsViewModel()
        {
            _instructorForDataGrid = new ObservableCollection<Instructor>();

            getInstructors();

            listOfInstructorsWindow = new ListOfInstructorsWindow();

            listOfInstructorsWindow.DataContext = this;

            listOfInstructorsWindow.ShowDialog();
        }

        #endregion

        #region close command members

        private DelegateCommand _cloaseCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_cloaseCommand == null)
                    _cloaseCommand = new DelegateCommand(new Action(closeExecuted));
                return _cloaseCommand;
            }
        }

        public void closeExecuted()
        {
            listOfInstructorsWindow.Close();
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
            InstructorViewModel instructorViewModel = new InstructorViewModel();
            getInstructors();
        }

        #endregion

        #region modify Instructor command members

        private DelegateCommand _modifyInstructorCommand;
        public ICommand ModifyInstructorCommand
        {
            get
            {
                if (_modifyInstructorCommand == null)
                    _modifyInstructorCommand = new DelegateCommand(new Action(modifyInstructorExecuted), new Func<bool>(modifyInstructorCanExecuted));
                return _modifyInstructorCommand;
            }
        }

        public void modifyInstructorExecuted()
        {
            InstructorViewModel instructorViewModel = new InstructorViewModel(SelectedInstructor);
            getInstructors();
        }

        public bool modifyInstructorCanExecuted()
        {
            return (SelectedInstructor != null);
        }

        #endregion

        #region delete instructor command members
        private DelegateCommand _deleteInstructorCommand;
        public ICommand DeleteInstructorCommand
        {
            get
            {
                if (_deleteInstructorCommand == null)
                    _deleteInstructorCommand = new DelegateCommand(new Action(deleteInstructorExecuted), new Func<bool>(deleteInstructorCanExecuted));
                return _deleteInstructorCommand;
            }
        }

        public void deleteInstructorExecuted()
        {
            using (var service = new ClassAdministrationServiceClient(new BasicHttpBinding(), new EndpointAddress(BUTEClassAdministrationClient.Properties.Resources.endpointAddress)))
            {
                service.DeleteInstructors(new int[] { SelectedInstructor.Id });
                //MessageBox.Show("Rekord törölve.");

                // refresh datagrid
                getInstructors();
            }
        }

        public bool deleteInstructorCanExecuted()
        {
            return (SelectedInstructor != null);
        }

        #endregion
    }
}
