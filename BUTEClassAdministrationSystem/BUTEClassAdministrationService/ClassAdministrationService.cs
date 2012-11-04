using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	class ClassAdministrationService : IClassAdministrationService
	{

		public BUTEClassAdministrationTypes.Student GetStudent()
		{
			return new Student()
			{
				Name = "G",
				Neptun = "U944EQ"
			};
		}


		public List<Student> GetStudents()
		{
			/*
						 using (SchoolEntities context = new SchoolEntities())
						{
							// Use System.Data.Objects.ObjectQuery(T).Include to eagrly load the related courses.
							return context.Departments.Include("Courses").OrderBy(d => d.Name).ToList();
						}
			 */
			using (ClassAdministrationEntityContainer context = new ClassAdministrationEntityContainer()) 
			{
				return context.StudentSet.ToList();
			}
		}
	}
}
