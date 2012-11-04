using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
				Student s = service.GetStudent();
				Console.WriteLine(s.Neptun);
				s.Neptun = "ABC123";

			}
		}
	}
}
