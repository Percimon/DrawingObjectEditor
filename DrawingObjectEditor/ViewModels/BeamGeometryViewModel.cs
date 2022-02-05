using Caliburn.Micro;
using DrawingObjectEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace DrawingObjectEditor.ViewModels
{
    class BeamGeometryViewModel : PropertyChangedBase
    {
        private Beam _beam;

        #region StartPoint

        private PointWrapper _startPoint;
        public PointWrapper StartPoint
        {
            get => _startPoint;
            set
            {
                _startPoint = value;
                NotifyOfPropertyChange(() => StartPoint);
            }
        }

        #endregion

        #region EndPoint

        private PointWrapper _endPoint;
        public PointWrapper EndPoint
        {
            get => _endPoint;
            set
            {
                _endPoint = value;
                NotifyOfPropertyChange(() => EndPoint);
            }
        }

        #endregion

        public BeamGeometryViewModel(Beam beam)
        {
            _beam = beam;
            StartPoint = new PointWrapper(_beam.StartPoint);
            EndPoint = new PointWrapper(_beam.EndPoint);
        }

        public void ModifyPoints()
        {
            _beam.StartPoint = StartPoint.GetTeklaPoint();
            _beam.EndPoint = EndPoint.GetTeklaPoint();
            _beam.Modify();
            new Model().CommitChanges();
        }

    }
}
