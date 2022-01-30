using Caliburn.Micro;
using DrawingObjectEditor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingObjectEditor.ViewModels
{
    class ShellViewModel : Conductor<object>
    {
        public ObjectIdentificationViewModel IdentificationViewModel { get; set; }
        public ObjectAttributesViewModel AttributesViewModel { get; set; }

        public ShellViewModel()
        {
            IEventAggregator events = new EventAggregator();
            TeklaEventHandler teklaEventHandler = new TeklaEventHandler(events);
            teklaEventHandler.RegisterEventHandler();

            IdentificationViewModel = new ObjectIdentificationViewModel(events);
            AttributesViewModel = new ObjectAttributesViewModel(events);
           
        }
    }
}
