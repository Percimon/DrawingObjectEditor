using Caliburn.Micro;
using DrawingObjectEditor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace DrawingObjectEditor.ViewModels
{
    class ObjectGeometryViewModel : Conductor<object>, IHandle<TeklaObjectProvider>
    {
        private IEventAggregator _events;

        public ObjectGeometryViewModel(IEventAggregator events)
        {
            _events = events;
            _events.SubscribeOnUIThread(this);
        }

        public System.Threading.Tasks.Task HandleAsync(TeklaObjectProvider message, CancellationToken cancellationToken)
        {
            if (message.TeklaModelObject != null)
            {
                ModelObject modelObject = new Model().SelectModelObject(message.TeklaModelObject.ModelIdentifier);
                switch (modelObject)
                {
                    case Beam beam:
                    {
                        ActivateItemAsync(new BeamGeometryViewModel(beam));
                        break;
                    }
                    default:
                        ActiveItem = null;
                        break;
                }
            }
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
