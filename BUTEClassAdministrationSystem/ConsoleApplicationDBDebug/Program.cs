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
				int[] studentIds = { 14 };

				var students = context.StudentSet.Where(student => studentIds.Contains(student.Id));
				
				foreach (var student in students)
				{
					context.DeleteObject(student);
				}

				context.SaveChanges();
			}

			Console.ReadLine();
		}
	}
}
