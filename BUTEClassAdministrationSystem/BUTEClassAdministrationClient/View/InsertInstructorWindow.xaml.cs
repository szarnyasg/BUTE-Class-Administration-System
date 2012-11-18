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
using System.Windows.Shapes;

namespace BUTEClassAdministrationClient.View
{
    /// <summary>
    /// Interaction logic for InsertInstructorWindow.xaml
    /// </summary>
    public partial class InsertInstructorWindow : Window
    {
        public InsertInstructorWindow()
        {
            InitializeComponent();

            // Automatically resize height relative to content 
            this.SizeToContent = SizeToContent.Height;
        }
    }
}
