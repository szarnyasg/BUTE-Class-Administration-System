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
		void CreateStudents(Student[] students);

		[OperationContract]
		Student[] ReadStudentsFromSemester(Semester semester);

		[OperationContract]
		void UpdateStudents(Student[] students);

		[OperationContract]
		void DeleteStudent(Student[] students);

		#endregion




		#region Course operations

		[OperationContract]
		void CreateCourse(Course[] courses);

		[OperationContract]
		Course[] ReadCoursesFromSemester(Semester semester);

		[OperationContract]
		void UpdateCourses(Course[] courses);

		[OperationContract]
		void DeleteCourses(Course[] courses);

		#endregion



		
		#region Group operations

		[OperationContract]
		void CreateGroup(Group[] groups);

		[OperationContract]
		Group[] ReadGroupsFromSemester(Semester semester);

		[OperationContract]
		void UpdateGroups(Group[] groups);

		[OperationContract]
		void DeleteGroups(Group[] groups);

		#endregion




		#region Instructor operations

		[OperationContract]
		void CreateInstructor(Instructor[] instructors);

		[OperationContract]
		Instructor[] ReadInstructors();

		[OperationContract]
		void UpdateInstructors(Instructor[] instructors);

		[OperationContract]
		void DeleteInstructors(Instructor[] instructors);

		#endregion




		#region Room operations

		[OperationContract]
		IEnumerable<Room> ReadRooms();

		#endregion
	}
}
