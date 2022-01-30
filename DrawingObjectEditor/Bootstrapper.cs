using Caliburn.Micro;
using DrawingObjectEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tekla.Structures.Drawing;
using Tekla.Structures.Model;

namespace DrawingObjectEditor
{
    class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _simpleContainer = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            _simpleContainer.Singleton<IEventAggregator, EventAggregator>();
            _simpleContainer.Singleton<IWindowManager, WindowManager>();
            _simpleContainer.Singleton<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key) => _simpleContainer.GetInstance(service, key);
        protected override IEnumerable<object> GetAllInstances(Type service) => _simpleContainer.GetAllInstances(service);
        protected override void BuildUp(object instance) => _simpleContainer.BuildUp(instance);
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            if (!new Model().GetConnectionStatus())
                MessageBox.Show("not connected");
            DisplayRootViewFor<ShellViewModel>();
        }


    }
}
