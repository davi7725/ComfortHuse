using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comforthuse.Models;

namespace EmployeeGUI.ViewModels.Partial
{
    public class TechnicalExpensesViewModel
    {
        private List<TechnicalSpecification> _TExpenses;

        List<TechnicalSpecification> TExpenses
        {
            get
            {
                if (_TExpenses == null)
                {
                    _TExpenses = new List<TechnicalSpecification>()
                    {
                        new TechnicalSpecification("Extraexpense1", false),
                        new TechnicalSpecification("Extraexpense1", false)
                }
                }
                return ;
            }

        }



}
}
