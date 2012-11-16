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
	public interface IClassAdministrationService : ISemesterOperations, IStudentOperations, ICourseOperations, IGroupOperations, IInstructorOperations, IRoomOperations
	{

	}
}
