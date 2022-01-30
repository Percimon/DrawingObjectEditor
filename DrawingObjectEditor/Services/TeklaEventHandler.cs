using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tekla.Structures.Drawing;

namespace DrawingObjectEditor.Services
{
    class TeklaEventHandler
    {
        private IEventAggregator _events;
        private Tekla.Structures.Drawing.UI.Events _drawingEvents = new Tekla.Structures.Drawing.UI.Events();

        public TeklaEventHandler(IEventAggregator events)
        {
            _events = events;
        }
        public void RegisterEventHandler()
        {
            _drawingEvents.SelectionChange += SelectionChangeTeklaEvent;
            _drawingEvents.Register();
        }

        private void SelectionChangeTeklaEvent()
        {
            var drawingObjectEnumerator = new DrawingHandler().GetDrawingObjectSelector().GetSelected();
            if (drawingObjectEnumerator.GetSize() == 0)
            {
                _events.PublishOnBackgroundThreadAsync(new TeklaObjectProvider());
            }
            else
            {
                drawingObjectEnumerator.MoveNext();
                _events.PublishOnUIThreadAsync(new TeklaObjectProvider(drawingObjectEnumerator.Current));
            }
        }
    }
}
