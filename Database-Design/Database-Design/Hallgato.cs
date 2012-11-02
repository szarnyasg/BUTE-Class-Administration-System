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
    public partial class Hallgato: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string Felev
        {
            get { return _felev; }
            set
            {
                if (_felev != value)
                {
                    _felev = value;
                    OnPropertyChanged("Felev");
                }
            }
        }
        private string _felev;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public Kurzus Kurzus
        {
            get { return _kurzus; }
            set
            {
                if (!ReferenceEquals(_kurzus, value))
                {
                    var previousValue = _kurzus;
                    _kurzus = value;
                    FixupKurzus(previousValue);
                    OnNavigationPropertyChanged("Kurzus");
                }
            }
        }
        private Kurzus _kurzus;
    
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
            Kurzus = null;
            FixupKurzusKeys();
            Csoport = null;
            FixupCsoportKeys();
        }

        #endregion
        #region Association Fixup
    
        private void FixupKurzus(Kurzus previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Hallgato.Contains(this))
            {
                previousValue.Hallgato.Remove(this);
            }
    
            if (Kurzus != null)
            {
                if (!Kurzus.Hallgato.Contains(this))
                {
                    Kurzus.Hallgato.Add(this);
                }
    
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Kurzus")
                    && (ChangeTracker.OriginalValues["Kurzus"] == Kurzus))
                {
                    ChangeTracker.OriginalValues.Remove("Kurzus");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Kurzus", previousValue);
                }
                if (Kurzus != null && !Kurzus.ChangeTracker.ChangeTrackingEnabled)
                {
                    Kurzus.StartTracking();
                }
                FixupKurzusKeys();
            }
        }
    
        private void FixupKurzusKeys()
        {
            const string IdKeyName = "Kurzus.Id";
    
            if(ChangeTracker.ExtendedProperties.ContainsKey(IdKeyName))
            {
                if(Kurzus == null ||
                   !Equals(ChangeTracker.ExtendedProperties[IdKeyName], Kurzus.Id))
                {
                    ChangeTracker.RecordOriginalValue(IdKeyName, ChangeTracker.ExtendedProperties[IdKeyName]);
                }
                ChangeTracker.ExtendedProperties.Remove(IdKeyName);
            }
        }
    
        private void FixupCsoport(Csoport previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Hallgato.Contains(this))
            {
                previousValue.Hallgato.Remove(this);
            }
    
            if (Csoport != null)
            {
                if (!Csoport.Hallgato.Contains(this))
                {
                    Csoport.Hallgato.Add(this);
                }
    
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
                FixupCsoportKeys();
            }
        }
    
        private void FixupCsoportKeys()
        {
            const string IdKeyName = "Csoport.Id";
    
            if(ChangeTracker.ExtendedProperties.ContainsKey(IdKeyName))
            {
                if(Csoport == null ||
                   !Equals(ChangeTracker.ExtendedProperties[IdKeyName], Csoport.Id))
                {
                    ChangeTracker.RecordOriginalValue(IdKeyName, ChangeTracker.ExtendedProperties[IdKeyName]);
                }
                ChangeTracker.ExtendedProperties.Remove(IdKeyName);
            }
        }

        #endregion
    }
}
