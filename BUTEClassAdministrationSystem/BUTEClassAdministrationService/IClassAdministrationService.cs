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
		[OperationContract]
		Student GetStudent();

		[OperationContract]
		void SetStudent(Student s);
	}
}
