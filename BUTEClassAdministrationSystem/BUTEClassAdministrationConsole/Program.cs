using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BUTEClassAdministrationTypes;
using BUTEClassAdministrationConsole.ClassAdministrationServiceReference;

namespace BUTEClassAdministrationConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Work();
		}

		static void Work()
		{
			using (var service = new ClassAdministrationServiceClient())
			{
				//List<Student> list = service.GetStudents();
				
				
				Console.WriteLine(service.My().Name);
				
			}
		}
	}
}
