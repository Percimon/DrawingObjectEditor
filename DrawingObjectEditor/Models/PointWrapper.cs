using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Geometry3d;

namespace DrawingObjectEditor.Models
{
    class PointWrapper : PropertyChangedBase
    {

        private double _x;
        public double X { get => _x; set { _x = value; NotifyOfPropertyChange(() => X); }}

        private double _y;
        public double Y { get => _y; set { _y = value; NotifyOfPropertyChange(() => Y); } }

        private double _z;
        public double Z { get => _z; set { _z = value; NotifyOfPropertyChange(() => Z); } }

        public PointWrapper(Point point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }

        public Point GetTeklaPoint() => new Point(X, Y, Z);
      
       
    }
}
