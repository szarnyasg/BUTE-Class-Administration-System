using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	class ClassAdministrationService : IClassAdministrationService
	{

		public Student GetStudent()
		{
			return new Student()
			{
				Name = "G",
				Neptun = "U944EQ"
			};
		}


		public List<Student> GetStudents()
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext()) 
			{
				Console.WriteLine("call");
				return context.StudentSet.ToList();
			}
		}

		public Student My()
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.StudentSet.First();
			}
		}
	}
}
