using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BUTEClassAdministrationTypes;
using System.Windows.Controls;
using System.Globalization;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;


namespace BUTEClassAdministrationClient
{
    class StudentModelView
    { 
        private string _name, _neptun;
        private string[] _array = new string[] {"A","B","C"};

        private string[] _semesters;

        public StudentModelView()
        {
            using (var service = new ClassAdministrationServiceClient())
            {
                Semester[] semesters = service.ReadSemesters();
                IList<String> semestersToCombobox = new List<string>();
                foreach (var semester in semesters)
                {
                    string s = semester.Semester_name;
                    semestersToCombobox.Add(s);
                }

                Semesters = semestersToCombobox.ToArray();
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Neptun
        {
            get { return _neptun; }
            set { _neptun = value; }
        }

        public string[] Array 
        {
            get { return _array ;} 
            set { _array = value;}
        }

        public string[] Semesters
        {
            get { return _semesters; }
            set { _semesters = value; }
        }


    }
}
