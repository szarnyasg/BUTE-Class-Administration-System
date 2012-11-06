using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BUTEClassAdministrationTypes;
using System.Windows.Controls;
using System.Globalization;

namespace BUTEClassAdministrationClient
{
    class StudentModelView
    { 
        private string _name, _neptun;
        private string[] _array = new string[] {"A","B","C"};


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
    }
}
