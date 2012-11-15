using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using BUTEClassAdministrationTypes;
using System.Data.EntityClient;

namespace ConsoleApplicationDBDebug
{
	class Program
	{
		static void Main(string[] args)
		{
			string connectionString = 
				"metadata=res://*/ClassAdministrationDatabase.csdl|res://*/ClassAdministrationDatabase.ssdl|res://*/" +
				"ClassAdministrationDatabase.msl;provider=System.Data.SqlClient;provider connection string=\"Data Source=SZARNYASG-PC\\SQLEXPRESS;Initial Catalog=ClassAdministration;Integrated Security=True\"";

			EntityConnection ec = new EntityConnection();
			ec.ConnectionString = connectionString;


			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext(ec))
			{
				Console.WriteLine("hello");

				context.ContextOptions.LazyLoadingEnabled = false;
				context.ContextOptions.ProxyCreationEnabled = false;

				/*
				List<Semester> semesters = context.SemesterSet.ToList();
				*/
				List<Course> courses = new List<Course>();				
				
				foreach (var course in context.CourseSet.ToList<Course>())
				{
					context.LoadProperty(course, "Semester");
					if (course.Semester == null)
					{
						Console.WriteLine("null");
					}
				}
			}
		}
	}
}
