using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace DrawingObjectEditor.ViewModels
{
    class PartAttributeViewModel
    {
        private Part _part;
        private Model _model;

        #region Name
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }

        }
        #endregion

        #region Class
        private string _class;
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
            }

        }
        #endregion

        public PartAttributeViewModel(Part part)
        {
            _part = part;
            _model = new Model();

            Name = part.Name;
            Class = part.Class;
        }

        public void ModifyPart()
        {
            _part.Name = Name;
            _part.Class = Class;
            _part.Modify();
            _model.CommitChanges();
        }

    }
}
