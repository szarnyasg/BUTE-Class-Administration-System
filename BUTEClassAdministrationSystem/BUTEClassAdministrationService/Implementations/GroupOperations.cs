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
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext(BUTEClassAdministrationService.Properties.Resources.connectionString))
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
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext(BUTEClassAdministrationService.Properties.Resources.connectionString))
			{
				List<Group> groups = context.GroupSet.Where(group => group.Semester.Id == semesterId).ToList();
				foreach (var group in groups)
				{
					context.LoadProperty(group, "Room");
					context.LoadProperty(group, "Semester");
					context.LoadProperty(group, "Course");
					context.LoadProperty(group, "Instructor");
					context.LoadProperty(group, "Student");
				}
				return groups.ToArray();
			}
		}

		public void DeleteGroups(int semesterId)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext(BUTEClassAdministrationService.Properties.Resources.connectionString))
			{
				var groups = context.GroupSet.Where(group => group.Semester.Id == semesterId);

				foreach (var group in groups)
				{
					foreach (var student in group.Student)
					{
						student.Group = null;
					}					
				}

				foreach (var group in groups)
				{
					foreach (var student in group.Student)
					{
						context.DeleteObject(group);
					}
				}
				context.SaveChanges();
			}
		}
	}
}