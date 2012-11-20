using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	[ServiceContract]
	public interface IRoomOperations
	{
		[OperationContract]
		Room[] ReadRooms();

		[OperationContract]
		Room[] ReadRoomsFromCourse(int courseId);
	}
}
