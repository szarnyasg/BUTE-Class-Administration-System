using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	public partial class ClassAdministrationService
	{
		public Semester[] ReadSemesters()
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext(BUTEClassAdministrationService.Properties.Resources.connectionString))
			{
				return context.SemesterSet.ToArray();
			}
		}
	}
}