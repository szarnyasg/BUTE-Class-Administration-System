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
		#region Student operations

		[OperationContract]
		void CreateStudents(IEnumerable<Student> students);

		[OperationContract]
		IEnumerable<Student> ReadStudentsFromSemester(string semester);

		[OperationContract]
		void UpdateStudents(IEnumerable<Student> students);

		[OperationContract]
		void DeleteStudent(IEnumerable<Student> students);

		#endregion
		/*
		#region Student operations

		[OperationContract]
		void CreateStudents(IEnumerable<Student> students);

		[OperationContract]
		IEnumerable<Student> ReadStudentsFromSemester(string semester);

		[OperationContract]
		void UpdateStudents(IEnumerable<Student> students);

		[OperationContract]
		void DeleteStudent(IEnumerable<Student> students);

		#endregion	
		*/
	}
}
