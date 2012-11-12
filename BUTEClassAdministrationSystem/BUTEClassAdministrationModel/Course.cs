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
    [KnownType(typeof(Student))]
    [KnownType(typeof(Group))]
    [KnownType(typeof(Room))]
    [KnownType(typeof(Semester))]
    public partial class Course: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public decimal Day_of_week
        {
            get { return _day_of_week; }
            set
            {
                if (_day_of_week != value)
                {
                    _day_of_week = value;
                    OnPropertyChanged("Day_of_week");
                }
            }
        }
        private decimal _day_of_week;
    
        [DataMember]
        public bool Week_parity
        {
            get { return _week_parity; }
            set
            {
                if (_week_parity != value)
                {
                    _week_parity = value;
                    OnPropertyChanged("Week_parity");
                }
            }
        }
        private bool _week_parity;
    
        [DataMember]
        public System.TimeSpan Starting_time
        {
            get { return _starting_time; }
            set
            {
                if (_starting_time != value)
                {
                    _starting_time = value;
                    OnPropertyChanged("Starting_time");
                }
            }
        }
        private System.TimeSpan _starting_time;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<Student> Student
        {
            get
            {
                if (_student == null)
                {
                    _student = new TrackableCollection<Student>();
                    _student.CollectionChanged += FixupStudent;
                }
                return _student;
            }
            set
            {
                if (!ReferenceEquals(_student, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_student != null)
                    {
                        _student.CollectionChanged -= FixupStudent;
                    }
                    _student = value;
                    if (_student != null)
                    {
                        _student.CollectionChanged += FixupStudent;
                    }
                    OnNavigationPropertyChanged("Student");
                }
            }
        }
        private TrackableCollection<Student> _student;
    
        [DataMember]
        public TrackableCollection<Group> Group
        {
            get
            {
                if (_group == null)
                {
                    _group = new TrackableCollection<Group>();
                    _group.CollectionChanged += FixupGroup;
                }
                return _group;
            }
            set
            {
                if (!ReferenceEquals(_group, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_group != null)
                    {
                        _group.CollectionChanged -= FixupGroup;
                    }
                    _group = value;
                    if (_group != null)
                    {
                        _group.CollectionChanged += FixupGroup;
                    }
                    OnNavigationPropertyChanged("Group");
                }
            }
        }
        private TrackableCollection<Group> _group;
    
        [DataMember]
        public TrackableCollection<Room> Room
        {
            get
            {
                if (_room == null)
                {
                    _room = new TrackableCollection<Room>();
                    _room.CollectionChanged += FixupRoom;
                }
                return _room;
            }
            set
            {
                if (!ReferenceEquals(_room, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_room != null)
                    {
                        _room.CollectionChanged -= FixupRoom;
                    }
                    _room = value;
                    if (_room != null)
                    {
                        _room.CollectionChanged += FixupRoom;
                    }
                    OnNavigationPropertyChanged("Room");
                }
            }
        }
        private TrackableCollection<Room> _room;
    
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
            Student.Clear();
            Group.Clear();
            Room.Clear();
            Semester = null;
            FixupSemesterKeys();
        }

        #endregion
        #region Association Fixup
    
        private void FixupSemester(Semester previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Course.Contains(this))
            {
                previousValue.Course.Remove(this);
            }
    
            if (Semester != null)
            {
                if (!Semester.Course.Contains(this))
                {
                    Semester.Course.Add(this);
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
    
        private void FixupStudent(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Student item in e.NewItems)
                {
                    item.Course = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Student", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Student item in e.OldItems)
                {
                    if (ReferenceEquals(item.Course, this))
                    {
                        item.Course = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Student", item);
                    }
                }
            }
        }
    
        private void FixupGroup(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Group item in e.NewItems)
                {
                    item.Course = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Group", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Group item in e.OldItems)
                {
                    if (ReferenceEquals(item.Course, this))
                    {
                        item.Course = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Group", item);
                    }
                }
            }
        }
    
        private void FixupRoom(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Room item in e.NewItems)
                {
                    if (!item.Course.Contains(this))
                    {
                        item.Course.Add(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Room", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Room item in e.OldItems)
                {
                    if (item.Course.Contains(this))
                    {
                        item.Course.Remove(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Room", item);
                    }
                }
            }
        }

        #endregion
    }
}
