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

namespace BUTEClassAdministrationTypes
{
    public partial class ClassAdministrationEntityContext : ObjectContext
    {
        public const string ConnectionString = "name=ClassAdministrationEntityContext";
        public const string ContainerName = "ClassAdministrationEntityContext";
    
        #region Constructors
    
        public ClassAdministrationEntityContext()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
        public ClassAdministrationEntityContext(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public ClassAdministrationEntityContext(EntityConnection connection)
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
    
        public ObjectSet<Student> StudentSet
        {
            get { return _studentSet  ?? (_studentSet = CreateObjectSet<Student>("StudentSet")); }
        }
        private ObjectSet<Student> _studentSet;
    
        public ObjectSet<Room> RoomSet
        {
            get { return _roomSet  ?? (_roomSet = CreateObjectSet<Room>("RoomSet")); }
        }
        private ObjectSet<Room> _roomSet;
    
        public ObjectSet<Instructor> InstructorSet
        {
            get { return _instructorSet  ?? (_instructorSet = CreateObjectSet<Instructor>("InstructorSet")); }
        }
        private ObjectSet<Instructor> _instructorSet;
    
        public ObjectSet<Group> GroupSet
        {
            get { return _groupSet  ?? (_groupSet = CreateObjectSet<Group>("GroupSet")); }
        }
        private ObjectSet<Group> _groupSet;
    
        public ObjectSet<Course> CourseSet
        {
            get { return _courseSet  ?? (_courseSet = CreateObjectSet<Course>("CourseSet")); }
        }
        private ObjectSet<Course> _courseSet;

        #endregion
    }
}
