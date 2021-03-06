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

namespace STESchoolModelTypes
{
    public partial class SchoolEntities : ObjectContext
    {
        public const string ConnectionString = "name=SchoolEntities";
        public const string ContainerName = "SchoolEntities";
    
        #region Constructors
    
        public SchoolEntities()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
        public SchoolEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public SchoolEntities(EntityConnection connection)
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
    
        public ObjectSet<Course> Courses
        {
            get { return _courses  ?? (_courses = CreateObjectSet<Course>("Courses")); }
        }
        private ObjectSet<Course> _courses;
    
        public ObjectSet<Department> Departments
        {
            get { return _departments  ?? (_departments = CreateObjectSet<Department>("Departments")); }
        }
        private ObjectSet<Department> _departments;

        #endregion
    }
}
