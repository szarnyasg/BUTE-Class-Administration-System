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

namespace STESchoolModelTypes
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Course))]
    public partial class Department: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int DepartmentID
        {
            get { return _departmentID; }
            set
            {
                if (_departmentID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'DepartmentID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _departmentID = value;
                    OnPropertyChanged("DepartmentID");
                }
            }
        }
        private int _departmentID;
    
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
    
        [DataMember]
        public decimal Budget
        {
            get { return _budget; }
            set
            {
                if (_budget != value)
                {
                    _budget = value;
                    OnPropertyChanged("Budget");
                }
            }
        }
        private decimal _budget;
    
        [DataMember]
        public System.DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged("StartDate");
                }
            }
        }
        private System.DateTime _startDate;
    
        [DataMember]
        public Nullable<int> Administrator
        {
            get { return _administrator; }
            set
            {
                if (_administrator != value)
                {
                    _administrator = value;
                    OnPropertyChanged("Administrator");
                }
            }
        }
        private Nullable<int> _administrator;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<Course> Courses
        {
            get
            {
                if (_courses == null)
                {
                    _courses = new TrackableCollection<Course>();
                    _courses.CollectionChanged += FixupCourses;
                }
                return _courses;
            }
            set
            {
                if (!ReferenceEquals(_courses, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_courses != null)
                    {
                        _courses.CollectionChanged -= FixupCourses;
                    }
                    _courses = value;
                    if (_courses != null)
                    {
                        _courses.CollectionChanged += FixupCourses;
                    }
                    OnNavigationPropertyChanged("Courses");
                }
            }
        }
        private TrackableCollection<Course> _courses;

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
            Courses.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupCourses(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Course item in e.NewItems)
                {
                    item.Department = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Courses", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Course item in e.OldItems)
                {
                    if (ReferenceEquals(item.Department, this))
                    {
                        item.Department = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Courses", item);
                    }
                }
            }
        }

        #endregion
    }
}
