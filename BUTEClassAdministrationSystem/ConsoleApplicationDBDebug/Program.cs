using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using BUTEClassAdministrationTypes;
using System.Data.EntityClient;
using System.Resources;
using System.Reflection;

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
				
				Group group1 = new Group();

				Room room1 = context.RoomSet.First();
				Instructor instructor1 = context.InstructorSet.First();
				Course course1 = context.CourseSet.First();
				Semester semester = context.SemesterSet.First();

				context.GroupSet.AddObject(group1);
				

				context.SaveChanges();
			}
		}
	}
}
