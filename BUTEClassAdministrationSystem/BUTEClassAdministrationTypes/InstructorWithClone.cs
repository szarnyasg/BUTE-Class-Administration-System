using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace BUTEClassAdministrationTypes
{
    public partial class Instructor
    {
        public void clone(Instructor src)
        {
            this.Name = src.Name;
            this.Neptun = src.Neptun;
            this.Email = src.Email;
        }
    }
}
