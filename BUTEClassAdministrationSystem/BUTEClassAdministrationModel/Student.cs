//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace BUTEClassAdministrationTypes
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Course))]
    [KnownType(typeof(Group))]
    [KnownType(typeof(Semester))]
    public partial class Student: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'Id' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private int _id;
    
        [DataMember]
        public string Neptun
        {
            get { return _neptun; }
            set
            {
                if (_neptun != value)
                {
                    _neptun = value;
                    OnPropertyChanged("Neptun");
                }
            }
        }
        private string _neptun;
    
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public Course Course
        {
            get { return _course; }
            set
            {
                if (!ReferenceEquals(_course, value))
                {
                    var previousValue = _course;
                    _course = value;
                    FixupCourse(previousValue);
                    OnNavigationPropertyChanged("Course");
                }
            }
        }
        private Course _course;
    
        [DataMember]
        public Group Group
        {
            get { return _group; }
            set
            {
                if (!ReferenceEquals(_group, value))
                {
                    var previousValue = _group;
                    _group = value;
                    FixupGroup(previousValue);
                    OnNavigationPropertyChanged("Group");
                }
            }
        }
        private Group _group;
    
        [DataMember]
        public Semester Semester
        {
            get { return _semester; }
            set
            {
                if (!ReferenceEquals(_semester, value))
                {
                    var previousValue = _semester;
                    _semester = value;
                    FixupSemester(previousValue);
                    OnNavigationPropertyChanged("Semester");
                }
            }
        }
        private Semester _semester;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            Course = null;
            FixupCourseKeys();
            Group = null;
            FixupGroupKeys();
            Semester = null;
            FixupSemesterKeys();
        }

        #endregion
        #region Association Fixup
    
        private void FixupCourse(Course previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Student.Contains(this))
            {
                previousValue.Student.Remove(this);
            }
    
            if (Course != null)
            {
                if (!Course.Student.Contains(this))
                {
                    Course.Student.Add(this);
                }
    
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Course")
                    && (ChangeTracker.OriginalValues["Course"] == Course))
                {
                    ChangeTracker.OriginalValues.Remove("Course");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Course", previousValue);
                }
                if (Course != null && !Course.ChangeTracker.ChangeTrackingEnabled)
                {
                    Course.StartTracking();
                }
                FixupCourseKeys();
            }
        }
    
        private void FixupCourseKeys()
        {
            const string IdKeyName = "Course.Id";
    
            if(ChangeTracker.ExtendedProperties.ContainsKey(IdKeyName))
            {
                if(Course == null ||
                   !Equals(ChangeTracker.ExtendedProperties[IdKeyName], Course.Id))
                {
                    ChangeTracker.RecordOriginalValue(IdKeyName, ChangeTracker.ExtendedProperties[IdKeyName]);
                }
                ChangeTracker.ExtendedProperties.Remove(IdKeyName);
            }
        }
    
        private void FixupGroup(Group previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Student.Contains(this))
            {
                previousValue.Student.Remove(this);
            }
    
            if (Group != null)
            {
                if (!Group.Student.Contains(this))
                {
                    Group.Student.Add(this);
                }
    
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Group")
                    && (ChangeTracker.OriginalValues["Group"] == Group))
                {
                    ChangeTracker.OriginalValues.Remove("Group");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Group", previousValue);
                }
                if (Group != null && !Group.ChangeTracker.ChangeTrackingEnabled)
                {
                    Group.StartTracking();
                }
                FixupGroupKeys();
            }
        }
    
        private void FixupGroupKeys()
        {
            const string IdKeyName = "Group.Id";
    
            if(ChangeTracker.ExtendedProperties.ContainsKey(IdKeyName))
            {
                if(Group == null ||
                   !Equals(ChangeTracker.ExtendedProperties[IdKeyName], Group.Id))
                {
                    ChangeTracker.RecordOriginalValue(IdKeyName, ChangeTracker.ExtendedProperties[IdKeyName]);
                }
                ChangeTracker.ExtendedProperties.Remove(IdKeyName);
            }
        }
    
        private void FixupSemester(Semester previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Student.Contains(this))
            {
                previousValue.Student.Remove(this);
            }
    
            if (Semester != null)
            {
                if (!Semester.Student.Contains(this))
                {
                    Semester.Student.Add(this);
                }
    
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Semester")
                    && (ChangeTracker.OriginalValues["Semester"] == Semester))
                {
                    ChangeTracker.OriginalValues.Remove("Semester");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Semester", previousValue);
                }
                if (Semester != null && !Semester.ChangeTracker.ChangeTrackingEnabled)
                {
                    Semester.StartTracking();
                }
                FixupSemesterKeys();
            }
        }
    
        private void FixupSemesterKeys()
        {
            const string IdKeyName = "Semester.Id";
    
            if(ChangeTracker.ExtendedProperties.ContainsKey(IdKeyName))
            {
                if(Semester == null ||
                   !Equals(ChangeTracker.ExtendedProperties[IdKeyName], Semester.Id))
                {
                    ChangeTracker.RecordOriginalValue(IdKeyName, ChangeTracker.ExtendedProperties[IdKeyName]);
                }
                ChangeTracker.ExtendedProperties.Remove(IdKeyName);
            }
        }

        #endregion
    }
}
