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
using System.Diagnostics;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            int i = 2;

            TabControl itemsTab = (TabControl)this.FindName("asd");
            Debug.Assert(itemsTab != null, "can't find ItemsTab");


            for (int j = 3; j < i+3; j++)
            {
                TabItem tab = new TabItem();
                tab.Header = "Tab" + j;
                itemsTab.Items.Add(tab);
            }

            TabItem tabtab = (TabItem)this.FindName("Tab1");
            Debug.Assert(tabtab != null, "can't find ItemsTab");

            tabtab.ContentTemplate = TryFindResource("tabItemContent") as DataTemplate;

            TabItem item2 = new TabItem();
            item2.ContentTemplate = TryFindResource("tabItemContent") as DataTemplate;
            itemsTab.Items.Add(item2);
        }
    }
}
