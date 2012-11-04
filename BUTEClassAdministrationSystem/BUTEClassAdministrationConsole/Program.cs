using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using BUTEClassAdministrationTypes;
using BUTEClassAdministrationConsole.ClassAdministrationServiceReference;
using BUTEClassAdministrationTypes;

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
				Student s = service.GetStudent();

				Console.WriteLine(s.Name);

				s.Name = "Cuppa";
				s.Neptun = "ZL2V8F";

				service.SetStudent(s);
				s.AcceptChanges();

			}
		}
	}
}
