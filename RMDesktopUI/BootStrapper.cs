﻿using Caliburn.Micro;
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
        private SimpleContainer _container = new SimpleContainer();

        public BootStrapper()
        {
            Initialize();
        }

        // Dependency Injection Setup
        protected override void Configure()
        {
            // Instantiate _contianer
            _container.Instance(_container);

            _container 
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            // Reflection - get all assemblies in program
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
