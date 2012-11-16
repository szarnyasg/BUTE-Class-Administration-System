using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	[ServiceContract]
	public interface IStudentOperations
	{
		[OperationContract]
		void CreateStudents(Student[] students);

		[OperationContract]
		Student[] ReadStudentsFromSemester(int semesterId);

		[OperationContract]
		Student[] ReadStudentsFromSemesterAndCourse(int semesterId, int courseId);

		[OperationContract]
		void UpdateStudents(Student[] students);

		[OperationContract]
		void DeleteStudent(int[] studentIds);
	}
}