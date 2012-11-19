using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace BUTEClassAdministrationTypes
{

    public partial class Student
    {
        public void clone(Student source)
        {
            this.Name = source.Name;
            this.Neptun = source.Neptun;
        }
    }
}
