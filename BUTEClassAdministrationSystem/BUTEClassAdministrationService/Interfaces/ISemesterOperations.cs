using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	[ServiceContract]
	public interface ISemesterOperations
	{
		[OperationContract]
		Semester[] ReadSemesters();
	}
}
