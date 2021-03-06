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
    public partial class Room: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public int Computer_count
        {
            get { return _computer_count; }
            set
            {
                if (_computer_count != value)
                {
                    _computer_count = value;
                    OnPropertyChanged("Computer_count");
                }
            }
        }
        private int _computer_count;
    
        [DataMember]
        public int Seating_capacity
        {
            get { return _seating_capacity; }
            set
            {
                if (_seating_capacity != value)
                {
                    _seating_capacity = value;
                    OnPropertyChanged("Seating_capacity");
                }
            }
        }
        private int _seating_capacity;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<Course> Course
        {
            get
            {
                if (_course == null)
                {
                    _course = new TrackableCollection<Course>();
                    _course.CollectionChanged += FixupCourse;
                }
                return _course;
            }
            set
            {
                if (!ReferenceEquals(_course, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_course != null)
                    {
                        _course.CollectionChanged -= FixupCourse;
                    }
                    _course = value;
                    if (_course != null)
                    {
                        _course.CollectionChanged += FixupCourse;
                    }
                    OnNavigationPropertyChanged("Course");
                }
            }
        }
        private TrackableCollection<Course> _course;
    
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
            Course.Clear();
            Group.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupCourse(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Course item in e.NewItems)
                {
                    if (!item.Room.Contains(this))
                    {
                        item.Room.Add(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Course", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Course item in e.OldItems)
                {
                    if (item.Room.Contains(this))
                    {
                        item.Room.Remove(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Course", item);
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
                    item.Room = this;
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
                    if (ReferenceEquals(item.Room, this))
                    {
                        item.Room = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Group", item);
                    }
                }
            }
        }

        #endregion
    }
}
