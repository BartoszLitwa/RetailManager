using Caliburn.Micro;
using RMDesktopUI.Helpers;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Api.Endpoints;
using RMDesktopUI.Library.Api.Endpoints.Interface;
using RMDesktopUI.Library.Api.Interface;
using RMDesktopUI.Library.Helpers;
using RMDesktopUI.Library.Models;
using RMDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RMDesktopUI
{
    class BootStrapper : BootstrapperBase
    {
        // DI container
        private SimpleContainer _container = new SimpleContainer();

        public BootStrapper()
        {
            Initialize();

            // Fix for passwordBox - Caliburn.micro
            ConventionManager.AddElementConvention<PasswordBox>(
                PasswordBoxHelper.BoundPasswordProperty,
                "Password",
                "PasswordChanged");
        }

        // Dependency Injection Setup
        protected override void Configure()
        {
            // Instantiate _contianer
            _container.Instance(_container)
                .PerRequest<ISaleEndpoint, SaleEndpoint>()
                .PerRequest<IProductEndpoint, ProductEndpoint>();

            // Adding all the Singletons - almost like static classes  
            _container 
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IAPIHelper, APIHelper>()
                .Singleton<IConfigHelper, ConfigHelper>()
                .Singleton<ILoggedInUserModel, LoggedInUserModel>();

            // Reflection - get all assemblies in program
            // Adding all the ViewModels Automatically
            GetType().Assembly.GetTypes()
                // Only classes
                .Where(type => type.IsClass)
                // Only that ends with ViewModel
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                // Regsiter Per Request - when asked it gives new instance and then throw away
                .ForEach(viewModel => _container.RegisterPerRequest(
                    viewModel, viewModel.ToString(), viewModel));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // Replace default MainWindow view with ShellWindow
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
