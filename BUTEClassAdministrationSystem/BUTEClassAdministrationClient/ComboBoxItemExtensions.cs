using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationClient
{
    /// <summary>
    /// This class provides us with an object to fill a ComboBox with
    /// that can be bound to string fields in the binding object.
    /// </summary>
    public class ComboBoxSemesterString
    {
        public string ValueString 
        { 
            get; 
            set;
        }
    }

    /// <summary>
    /// This class provides us with an object to fill a ComboBox with
    /// that can be bound to 'ViewModelEnum.Colors' enum fields in the binding
    ///  object while displaying a string values in the to user in the ComboBox.
    /// </summary>
    public class ComboBoxSemesterPair
    {
        public Semester SemesterObject 
        { 
            get; 
            set; 
        }
        public string SemesterString 
        { 
            get; 
            set; 
        }
    }
}
