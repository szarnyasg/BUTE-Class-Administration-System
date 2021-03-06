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

namespace Database_Design
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Kurzus))]
    [KnownType(typeof(Csoport))]
    public partial class Terem: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string Nev
        {
            get { return _nev; }
            set
            {
                if (_nev != value)
                {
                    _nev = value;
                    OnPropertyChanged("Nev");
                }
            }
        }
        private string _nev;
    
        [DataMember]
        public int Gepek_szama
        {
            get { return _gepek_szama; }
            set
            {
                if (_gepek_szama != value)
                {
                    _gepek_szama = value;
                    OnPropertyChanged("Gepek_szama");
                }
            }
        }
        private int _gepek_szama;
    
        [DataMember]
        public decimal Ulohelyek_szama
        {
            get { return _ulohelyek_szama; }
            set
            {
                if (_ulohelyek_szama != value)
                {
                    _ulohelyek_szama = value;
                    OnPropertyChanged("Ulohelyek_szama");
                }
            }
        }
        private decimal _ulohelyek_szama;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<Kurzus> Kurzus
        {
            get
            {
                if (_kurzus == null)
                {
                    _kurzus = new TrackableCollection<Kurzus>();
                    _kurzus.CollectionChanged += FixupKurzus;
                }
                return _kurzus;
            }
            set
            {
                if (!ReferenceEquals(_kurzus, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_kurzus != null)
                    {
                        _kurzus.CollectionChanged -= FixupKurzus;
                    }
                    _kurzus = value;
                    if (_kurzus != null)
                    {
                        _kurzus.CollectionChanged += FixupKurzus;
                    }
                    OnNavigationPropertyChanged("Kurzus");
                }
            }
        }
        private TrackableCollection<Kurzus> _kurzus;
    
        [DataMember]
        public Csoport Csoport
        {
            get { return _csoport; }
            set
            {
                if (!ReferenceEquals(_csoport, value))
                {
                    var previousValue = _csoport;
                    _csoport = value;
                    FixupCsoport(previousValue);
                    OnNavigationPropertyChanged("Csoport");
                }
            }
        }
        private Csoport _csoport;

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
            Kurzus.Clear();
            Csoport = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupCsoport(Csoport previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && ReferenceEquals(previousValue.Terem, this))
            {
                previousValue.Terem = null;
            }
    
            if (Csoport != null)
            {
                Csoport.Terem = this;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Csoport")
                    && (ChangeTracker.OriginalValues["Csoport"] == Csoport))
                {
                    ChangeTracker.OriginalValues.Remove("Csoport");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Csoport", previousValue);
                }
                if (Csoport != null && !Csoport.ChangeTracker.ChangeTrackingEnabled)
                {
                    Csoport.StartTracking();
                }
            }
        }
    
        private void FixupKurzus(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Kurzus item in e.NewItems)
                {
                    if (!item.Terem.Contains(this))
                    {
                        item.Terem.Add(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Kurzus", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Kurzus item in e.OldItems)
                {
                    if (item.Terem.Contains(this))
                    {
                        item.Terem.Remove(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Kurzus", item);
                    }
                }
            }
        }

        #endregion
    }
}
