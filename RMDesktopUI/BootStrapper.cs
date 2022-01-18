using Caliburn.Micro;
using RMDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RMDesktopUI
{
    class BootStrapper : BootstrapperBase
    {
        public BootStrapper()
        {
            Initialize();
        }
        
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // Replace default MainWindow view with ShellWindow
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
