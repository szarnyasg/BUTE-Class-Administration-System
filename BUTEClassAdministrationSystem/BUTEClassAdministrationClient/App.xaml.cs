using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

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
			  //Handling the exception within the UnhandledExcpeiton handler.
			  MessageBox.Show(e.Exception.Message, "Exception Caught", MessageBoxButton.OK, MessageBoxImage.Error);
			  e.Handled = true;
		  }
		  else
		  {
			  //If you do not set e.Handled to true, the application will close due to crash.
			  MessageBox.Show("Belső hiba! Az alkalmazás leáll! ", "Uncaught Exception");
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
		  MessageBox.Show(ex.Message, "Uncaught Thread Exception", MessageBoxButton.OK, MessageBoxImage.Error);
	  }
  }
}
