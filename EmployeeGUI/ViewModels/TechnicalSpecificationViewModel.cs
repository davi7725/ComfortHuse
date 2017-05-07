using Comforthuse.Models;
using System.Collections.Generic;

namespace EmployeeGUI.ViewModels
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
