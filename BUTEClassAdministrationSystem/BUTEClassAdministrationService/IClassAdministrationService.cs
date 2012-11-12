using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	[ServiceContract]
	public interface IClassAdministrationService
	{
		#region Semester operations
		[OperationContract]
		IEnumerable <Semester> ReadSemesters();

		#endregion




		#region Student operations

		[OperationContract]
		void CreateStudents(IEnumerable<Student> students);

		[OperationContract]
		IEnumerable<Student> ReadStudentsFromSemester(Semester semester);

		[OperationContract]
		void UpdateStudents(IEnumerable<Student> students);

		[OperationContract]
		void DeleteStudent(IEnumerable<Student> students);

		#endregion




		#region Course operations

		[OperationContract]
		void CreateCourse(IEnumerable<Course> courses);

		[OperationContract]
		IEnumerable<Course> ReadCoursesFromSemester(Semester semester);

		[OperationContract]
		void UpdateCourses(IEnumerable<Course> courses);

		[OperationContract]
		void DeleteCourses(IEnumerable<Course> courses);

		#endregion



		
		#region Group operations

		[OperationContract]
		void CreateGroup(IEnumerable<Group> groups);

		[OperationContract]
		IEnumerable<Group> ReadGroupsFromSemester(Semester semester);

		[OperationContract]
		void UpdateGroups(IEnumerable<Group> groups);

		[OperationContract]
		void DeleteGroups(IEnumerable<Group> groups);

		#endregion




		#region Instructor operations

		[OperationContract]
		void CreateInstructor(IEnumerable<Instructor> instructors);

		[OperationContract]
		IEnumerable<Instructor> ReadInstructors();

		[OperationContract]
		void UpdateInstructors(IEnumerable<Instructor> instructors);

		[OperationContract]
		void DeleteInstructors(IEnumerable<Instructor> instructors);

		#endregion




		#region Room operations

		[OperationContract]
		IEnumerable<Room> ReadRooms();

		#endregion
	}
}
