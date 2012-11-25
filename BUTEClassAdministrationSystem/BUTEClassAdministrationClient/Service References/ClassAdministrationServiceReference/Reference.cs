﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BUTEClassAdministrationClient.ClassAdministrationServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ExtendedPropertiesDictionary", Namespace="http://schemas.datacontract.org/2004/07/BUTEClassAdministrationTypes", ItemName="ExtendedProperties", KeyName="Name", ValueName="ExtendedProperty")]
    [System.SerializableAttribute()]
    public class ExtendedPropertiesDictionary : System.Collections.Generic.Dictionary<string, object> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectsAddedToCollectionProperties", Namespace="http://schemas.datacontract.org/2004/07/BUTEClassAdministrationTypes", ItemName="AddedObjectsForProperty", KeyName="CollectionPropertyName", ValueName="AddedObjects")]
    [System.SerializableAttribute()]
    public class ObjectsAddedToCollectionProperties : System.Collections.Generic.Dictionary<string, BUTEClassAdministrationClient.ClassAdministrationServiceReference.ObjectList> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectList", Namespace="http://schemas.datacontract.org/2004/07/BUTEClassAdministrationTypes", ItemName="ObjectValue")]
    [System.SerializableAttribute()]
    public class ObjectList : System.Collections.Generic.List<object> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectsRemovedFromCollectionProperties", Namespace="http://schemas.datacontract.org/2004/07/BUTEClassAdministrationTypes", ItemName="DeletedObjectsForProperty", KeyName="CollectionPropertyName", ValueName="DeletedObjects")]
    [System.SerializableAttribute()]
    public class ObjectsRemovedFromCollectionProperties : System.Collections.Generic.Dictionary<string, BUTEClassAdministrationClient.ClassAdministrationServiceReference.ObjectList> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="OriginalValuesDictionary", Namespace="http://schemas.datacontract.org/2004/07/BUTEClassAdministrationTypes", ItemName="OriginalValues", KeyName="Name", ValueName="OriginalValue")]
    [System.SerializableAttribute()]
    public class OriginalValuesDictionary : System.Collections.Generic.Dictionary<string, object> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ClassAdministrationServiceReference.IClassAdministrationService")]
    public interface IClassAdministrationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISemesterOperations/ReadSemesters", ReplyAction="http://tempuri.org/ISemesterOperations/ReadSemestersResponse")]
        BUTEClassAdministrationTypes.Semester[] ReadSemesters();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentOperations/CreateStudents", ReplyAction="http://tempuri.org/IStudentOperations/CreateStudentsResponse")]
        void CreateStudents(BUTEClassAdministrationTypes.Student[] students);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentOperations/ReadStudentsFromSemester", ReplyAction="http://tempuri.org/IStudentOperations/ReadStudentsFromSemesterResponse")]
        BUTEClassAdministrationTypes.Student[] ReadStudentsFromSemester(int semesterId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentOperations/ReadStudentsFromCourse", ReplyAction="http://tempuri.org/IStudentOperations/ReadStudentsFromCourseResponse")]
        BUTEClassAdministrationTypes.Student[] ReadStudentsFromCourse(int courseId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentOperations/UpdateStudents", ReplyAction="http://tempuri.org/IStudentOperations/UpdateStudentsResponse")]
        void UpdateStudents(BUTEClassAdministrationTypes.Student[] students);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentOperations/DeleteStudents", ReplyAction="http://tempuri.org/IStudentOperations/DeleteStudentsResponse")]
        void DeleteStudents(int[] studentIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentOperations/MoveStudent", ReplyAction="http://tempuri.org/IStudentOperations/MoveStudentResponse")]
        void MoveStudent(int studentId, int courseId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseOperations/CreateCourse", ReplyAction="http://tempuri.org/ICourseOperations/CreateCourseResponse")]
        void CreateCourse(BUTEClassAdministrationTypes.Course[] courses);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseOperations/ReadCoursesFromSemester", ReplyAction="http://tempuri.org/ICourseOperations/ReadCoursesFromSemesterResponse")]
        BUTEClassAdministrationTypes.Course[] ReadCoursesFromSemester(int semesterId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseOperations/UpdateCourses", ReplyAction="http://tempuri.org/ICourseOperations/UpdateCoursesResponse")]
        void UpdateCourses(BUTEClassAdministrationTypes.Course[] courses);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseOperations/DeleteCourses", ReplyAction="http://tempuri.org/ICourseOperations/DeleteCoursesResponse")]
        void DeleteCourses(int courseIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupOperations/CreateGroup", ReplyAction="http://tempuri.org/IGroupOperations/CreateGroupResponse")]
        void CreateGroup(BUTEClassAdministrationTypes.Group[] groups);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupOperations/ReadGroupsFromSemester", ReplyAction="http://tempuri.org/IGroupOperations/ReadGroupsFromSemesterResponse")]
        BUTEClassAdministrationTypes.Group[] ReadGroupsFromSemester(int semesterId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGroupOperations/DeleteGroups", ReplyAction="http://tempuri.org/IGroupOperations/DeleteGroupsResponse")]
        void DeleteGroups(int semesterId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstructorOperations/CreateInstructor", ReplyAction="http://tempuri.org/IInstructorOperations/CreateInstructorResponse")]
        void CreateInstructor(BUTEClassAdministrationTypes.Instructor[] instructors);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstructorOperations/ReadInstructors", ReplyAction="http://tempuri.org/IInstructorOperations/ReadInstructorsResponse")]
        BUTEClassAdministrationTypes.Instructor[] ReadInstructors();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstructorOperations/UpdateInstructors", ReplyAction="http://tempuri.org/IInstructorOperations/UpdateInstructorsResponse")]
        void UpdateInstructors(BUTEClassAdministrationTypes.Instructor[] instructors);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInstructorOperations/DeleteInstructors", ReplyAction="http://tempuri.org/IInstructorOperations/DeleteInstructorsResponse")]
        void DeleteInstructors(int[] instructorIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomOperations/ReadRooms", ReplyAction="http://tempuri.org/IRoomOperations/ReadRoomsResponse")]
        BUTEClassAdministrationTypes.Room[] ReadRooms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomOperations/ReadRoomsFromCourse", ReplyAction="http://tempuri.org/IRoomOperations/ReadRoomsFromCourseResponse")]
        BUTEClassAdministrationTypes.Room[] ReadRoomsFromCourse(int courseId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IClassAdministrationServiceChannel : BUTEClassAdministrationClient.ClassAdministrationServiceReference.IClassAdministrationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClassAdministrationServiceClient : System.ServiceModel.ClientBase<BUTEClassAdministrationClient.ClassAdministrationServiceReference.IClassAdministrationService>, BUTEClassAdministrationClient.ClassAdministrationServiceReference.IClassAdministrationService {
        
        public ClassAdministrationServiceClient() {
        }
        
        public ClassAdministrationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClassAdministrationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClassAdministrationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClassAdministrationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public BUTEClassAdministrationTypes.Semester[] ReadSemesters() {
            return base.Channel.ReadSemesters();
        }
        
        public void CreateStudents(BUTEClassAdministrationTypes.Student[] students) {
            base.Channel.CreateStudents(students);
        }
        
        public BUTEClassAdministrationTypes.Student[] ReadStudentsFromSemester(int semesterId) {
            return base.Channel.ReadStudentsFromSemester(semesterId);
        }
        
        public BUTEClassAdministrationTypes.Student[] ReadStudentsFromCourse(int courseId) {
            return base.Channel.ReadStudentsFromCourse(courseId);
        }
        
        public void UpdateStudents(BUTEClassAdministrationTypes.Student[] students) {
            base.Channel.UpdateStudents(students);
        }
        
        public void DeleteStudents(int[] studentIds) {
            base.Channel.DeleteStudents(studentIds);
        }
        
        public void MoveStudent(int studentId, int courseId) {
            base.Channel.MoveStudent(studentId, courseId);
        }
        
        public void CreateCourse(BUTEClassAdministrationTypes.Course[] courses) {
            base.Channel.CreateCourse(courses);
        }
        
        public BUTEClassAdministrationTypes.Course[] ReadCoursesFromSemester(int semesterId) {
            return base.Channel.ReadCoursesFromSemester(semesterId);
        }
        
        public void UpdateCourses(BUTEClassAdministrationTypes.Course[] courses) {
            base.Channel.UpdateCourses(courses);
        }
        
        public void DeleteCourses(int courseIds) {
            base.Channel.DeleteCourses(courseIds);
        }
        
        public void CreateGroup(BUTEClassAdministrationTypes.Group[] groups) {
            base.Channel.CreateGroup(groups);
        }
        
        public BUTEClassAdministrationTypes.Group[] ReadGroupsFromSemester(int semesterId) {
            return base.Channel.ReadGroupsFromSemester(semesterId);
        }
        
        public void DeleteGroups(int semesterId) {
            base.Channel.DeleteGroups(semesterId);
        }
        
        public void CreateInstructor(BUTEClassAdministrationTypes.Instructor[] instructors) {
            base.Channel.CreateInstructor(instructors);
        }
        
        public BUTEClassAdministrationTypes.Instructor[] ReadInstructors() {
            return base.Channel.ReadInstructors();
        }
        
        public void UpdateInstructors(BUTEClassAdministrationTypes.Instructor[] instructors) {
            base.Channel.UpdateInstructors(instructors);
        }
        
        public void DeleteInstructors(int[] instructorIds) {
            base.Channel.DeleteInstructors(instructorIds);
        }
        
        public BUTEClassAdministrationTypes.Room[] ReadRooms() {
            return base.Channel.ReadRooms();
        }
        
        public BUTEClassAdministrationTypes.Room[] ReadRoomsFromCourse(int courseId) {
            return base.Channel.ReadRoomsFromCourse(courseId);
        }
    }
}
