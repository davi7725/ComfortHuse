using Comforthuse.Models.SpecificationDerivatives;
using System.Collections.Generic;

namespace EmployeeGUI.ViewModels.Partial
{
    public class TechnicalSpecificationViewModel
    {
        private List<TechnicalSpecification> _tslist;

        public TechnicalSpecificationViewModel(List<TechnicalSpecification> tslist)
        {
            this._tslist = tslist;
        }

        public List<TechnicalSpecification> TechnicalSpecifications
        {
            get
            {
                return _tslist;
            }
        }
    }
}
