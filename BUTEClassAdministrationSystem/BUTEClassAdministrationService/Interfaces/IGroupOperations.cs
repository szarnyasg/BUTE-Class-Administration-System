using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	[ServiceContract]
	public interface IGroupOperations
	{
		[OperationContract]
		void CreateGroup(Group[] groups);

		[OperationContract]
		Group[] ReadGroupsFromSemester(int semesterId);

		[OperationContract]
		void DeleteGroups(int semesterId);

	}
}
