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
		Student[] ReadStudentsFromCourse(int courseId);

		[OperationContract]
		void UpdateStudents(Student[] students);

		[OperationContract]
		void DeleteStudents(int[] studentIds);

		[OperationContract]
		void MoveStudent(int studentId, int courseId);
	}
}