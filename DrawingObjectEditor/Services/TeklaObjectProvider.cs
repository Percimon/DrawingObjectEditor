using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Drawing;

namespace DrawingObjectEditor.Services
{
    class TeklaObjectProvider
    {
        public ModelObject TeklaModelObject { get; set; }
        public TeklaObjectProvider() { }
        public TeklaObjectProvider(DrawingObject drawingObject)
        {
            if (drawingObject is ModelObject modelObject)
                TeklaModelObject = modelObject;
        }


    }
}
