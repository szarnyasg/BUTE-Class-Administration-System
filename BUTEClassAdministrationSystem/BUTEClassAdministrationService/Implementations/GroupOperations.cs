using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	public partial class ClassAdministrationService
	{
		public void CreateGroup(Group[] groups)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var group in groups)
				{
					context.GroupSet.ApplyChanges(group);
				}
				context.SaveChanges();
			}
		}

		public Group[] ReadGroupsFromSemester(int semesterId)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				throw new NotImplementedException();
			}
		}

		public Group[] ReadGroupsFromCourse(int courseId)
		{
			throw new NotImplementedException();
		}

		public void UpdateGroups(Group[] groups)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var group in groups)
				{
					context.GroupSet.ApplyChanges(group);
				}
				context.SaveChanges();
			}
		}

		public void DeleteGroups(int[] groupIds)
		{
			throw new NotImplementedException();
		}
	}
}