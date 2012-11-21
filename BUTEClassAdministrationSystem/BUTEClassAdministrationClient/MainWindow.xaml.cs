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
        MainWindowViewModel _mainWindowViewModel;

        public MainWindowViewModel MainWindowViewModel 
        {
            get { return _mainWindowViewModel; }
            set { _mainWindowViewModel = value; }
        }

		public MainWindow()
		{
            _mainWindowViewModel = new MainWindowViewModel();

            DataContext = this;

            InitializeComponent();
    	}

    }
}

