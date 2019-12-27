using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var args = e.Args;
            if (args != null & args.Length == 1)
            {
                if (args[0].ToUpper() == "SHUTDOWN")
                {
                    this.StartupUri = new Uri("ShutDownWindow.xaml", UriKind.Relative);
                }
            }
            base.OnStartup(e);
        }
    }
}
