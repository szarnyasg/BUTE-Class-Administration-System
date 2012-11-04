using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using BUTEClassAdministrationTypes;
using BUTEClassAdministrationClient.ClassAdministrationServiceReference;

namespace BUTEClassAdministrationClient
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();

			Work();
		}

		void Work()
		{
			using (var service = new ClassAdministrationServiceClient())
			{
				Student s = service.GetStudent();

				Console.WriteLine(s.Name);

				s.Name = "Móricz";
				s.Neptun = "ZL2V8F";

				service.SetStudent(s);

				s.AcceptChanges();
			}
		}

	}
}
