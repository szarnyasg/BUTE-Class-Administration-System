using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	[ServiceContract]
	public interface IInstructorOperations
	{
		[OperationContract]
		void CreateInstructor(Instructor[] instructors);

		[OperationContract]
		Instructor[] ReadInstructors();

		[OperationContract]
		void UpdateInstructors(Instructor[] instructors);

		[OperationContract]
		void DeleteInstructors(int[] instructorIds);
	}
}
