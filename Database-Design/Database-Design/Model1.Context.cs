﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Database_Design
{
    public partial class TerembeosztoEntitasok : ObjectContext
    {
        public const string ConnectionString = "name=TerembeosztoEntitasok";
        public const string ContainerName = "TerembeosztoEntitasok";
    
        #region Constructors
    
        public TerembeosztoEntitasok()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
        public TerembeosztoEntitasok(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public TerembeosztoEntitasok(EntityConnection connection)
            : base(connection, ContainerName)
        {
            Initialize();
        }
    
        private void Initialize()
        {
            // Creating proxies requires the use of the ProxyDataContractResolver and
            // may allow lazy loading which can expand the loaded graph during serialization.
            ContextOptions.ProxyCreationEnabled = false;
            ObjectMaterialized += new ObjectMaterializedEventHandler(HandleObjectMaterialized);
        }
    
        private void HandleObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity != null)
            {
                bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
                try
                {
                    entity.MarkAsUnchanged();
                }
                finally
                {
                    entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
                }
                this.StoreReferenceKeyValues(entity);
            }
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Hallgato> HallgatoSet
        {
            get { return _hallgatoSet  ?? (_hallgatoSet = CreateObjectSet<Hallgato>("HallgatoSet")); }
        }
        private ObjectSet<Hallgato> _hallgatoSet;
    
        public ObjectSet<Terem> TeremSet
        {
            get { return _teremSet  ?? (_teremSet = CreateObjectSet<Terem>("TeremSet")); }
        }
        private ObjectSet<Terem> _teremSet;
    
        public ObjectSet<Gyakorlatvezeto> GyakorlatvezetoSet
        {
            get { return _gyakorlatvezetoSet  ?? (_gyakorlatvezetoSet = CreateObjectSet<Gyakorlatvezeto>("GyakorlatvezetoSet")); }
        }
        private ObjectSet<Gyakorlatvezeto> _gyakorlatvezetoSet;
    
        public ObjectSet<Csoport> CsoportSet
        {
            get { return _csoportSet  ?? (_csoportSet = CreateObjectSet<Csoport>("CsoportSet")); }
        }
        private ObjectSet<Csoport> _csoportSet;
    
        public ObjectSet<Kurzus> KurzusSet
        {
            get { return _kurzusSet  ?? (_kurzusSet = CreateObjectSet<Kurzus>("KurzusSet")); }
        }
        private ObjectSet<Kurzus> _kurzusSet;

        #endregion
    }
}