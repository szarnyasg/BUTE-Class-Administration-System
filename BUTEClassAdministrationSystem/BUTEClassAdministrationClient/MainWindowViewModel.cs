using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationClient
{
    public class MainWindowViewModel
    {
        /*private DelegateCommand _openInsertStudentWindow;
        ICommand OpenInsertStudentWindow
        {
            get
            {
                if (_openInsertStudentWindow == null)
                    _openInsertStudentWindow = new DelegateCommand(new Action(Save));
                return _openInsertStudentWindow;
            }
        }

        public void Save()
        {

        }*/

        private void Insert()
        {
            using (var service = new ClassAdministrationServiceClient())
            {
                Semester[] semesters = service.ReadSemesters();
            }
        }

        public string ASD { 
            get { return "asd"; } 
            set{} 
        }
        
    }
}
