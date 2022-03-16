using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryTracker
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message +
                 "\n" + e.Exception.Source, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true; //true: indicates that we are done dealing with this exception and nothing else should be done about it.
        }
    }
}
