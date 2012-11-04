using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.Runtime.Serialization;

using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	[ServiceContract]
	interface IClassAdministrationService
	{
		[OperationContract]
		Student GetStudent();

		[OperationContract]
		List<Student> GetStudents();

		[OperationContract]
		Student My();

	}
}
