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
	public class ClassAdministrationService : IClassAdministrationService
	{
		public Student GetStudent()
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.StudentSet.First();
			}
		}

		public void SetStudent(Student s)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				context.StudentSet.ApplyChanges(s);
				context.SaveChanges();
			}
		}
	}
}
