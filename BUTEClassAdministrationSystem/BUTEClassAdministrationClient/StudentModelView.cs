using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BUTEClassAdministrationTypes;
using System.Windows.Controls;

namespace BUTEClassAdministrationClient
{
    class StudentModelView : ValidationRule
    {
        Student student;

        /*public string Name 
        { 
            get { return student.Name; }
            set { student.Name = value; } 
        }

        public string Neptun
        {
            get { return student.Neptun; }
            set { student.Neptun = value; }
        }*/


        private string _name, _neptun;

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





        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            //value.
            if (((string)value).Length > 0)
            return new ValidationResult(true, "kapd be");
            return new ValidationResult(false, "szopja lovat");
        }
    }
}
