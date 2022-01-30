using Caliburn.Micro;
using DrawingObjectEditor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Tekla.Structures.Model;

namespace DrawingObjectEditor.ViewModels
{
    class ObjectIdentificationViewModel : PropertyChangedBase, IHandle<TeklaObjectProvider>
    {
        #region Guid

        private string _guid;
        public string Guid
        {
            get => _guid;
            set
            {
                _guid = value;
                NotifyOfPropertyChange(() => Guid);
            }
        }

        #endregion

        #region Type

        private string _type;
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                NotifyOfPropertyChange(() => Type);
            }
        }

        #endregion

        private IEventAggregator _events;
        public ObjectIdentificationViewModel(IEventAggregator events)
        {
            _events = events;
            _events.SubscribeOnUIThread(this);
        }

        public System.Threading.Tasks.Task HandleAsync(TeklaObjectProvider message, CancellationToken cancellationToken)
        {
            if (message.TeklaModelObject != null)
            {
                ModelObject modelObject = new Model().SelectModelObject(message.TeklaModelObject.ModelIdentifier);
                Guid = $"{modelObject.Identifier.GUID}";
                Type = $"{modelObject.GetType()}".Replace("Tekla.Structures.Model.","");
                
            }
            else
            {
                Guid = "";
                Type = "";
            }
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
