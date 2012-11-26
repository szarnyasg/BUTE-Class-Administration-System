using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Markup;

namespace BUTEClassAdministrationClient
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
	  private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
	  {
		  if (e.Exception is BUTEClassAdministrationException)
		  {
			  MessageBox.Show(e.Exception.Message, "Belső hiba.", MessageBoxButton.OK, MessageBoxImage.Error);
			  e.Handled = true;
		  }
		  else if (e.Exception is XamlParseException)
		  {
			  if ((e.Exception as XamlParseException).InnerException is System.ServiceModel.EndpointNotFoundException)
			  {
				  MessageBox.Show("A webszolgáltatás nem érhető el a " + BUTEClassAdministrationClient.Properties.Resources.endpointAddress + " címen. Az alkalmazás leáll.", "Hiba");
				  e.Handled = false;
			  }
		  } 
		  else
		  {
			  MessageBox.Show("Belső hiba. Az alkalmazás leáll.", "Hiba");
			  e.Handled = false;
		  }
	  }

	  private void Application_Startup(object sender, StartupEventArgs e)
	  {
		  AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
	  }

	  void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	  {
		  Exception ex = e.ExceptionObject as Exception;
		  MessageBox.Show(ex.Message, "Kivételkezelésen túli hiba.", MessageBoxButton.OK, MessageBoxImage.Error);
	  }
  }
}
