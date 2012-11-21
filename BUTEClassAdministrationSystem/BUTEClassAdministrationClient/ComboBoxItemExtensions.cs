using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationClient
{

    public class ComboBoxSemesterString
    {
        public string ValueString 
        { 
            get; 
            set;
        }
    }

    public class ComboBoxSemesterPair
    {
        public Semester SemesterObject { get; set; } 
        
        public string SemesterString { get; set; }
    }

    public class ComboBoxCoursePair
    {
        public Course CourseObject { get; set; }

        public string CourseString { get; set; }
    }

    public class ComboBoxGroupPair
    {
        public Group GroupObject { get; set; }

        public string GroupString { get; set; }
    }

}
