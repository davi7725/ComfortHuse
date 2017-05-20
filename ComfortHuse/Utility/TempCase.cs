using Comforthuse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comforthuse.Utility
{
    public class TempCase
    {

        public TempCase(Case caseObj, string customerEmail, int? moneyInstituteId, string employeeEmail, int? plotId, int? imageId)
        {
            Case = caseObj;
            CustomerEmail = customerEmail;
            MoneyInstituteId = moneyInstituteId;
            EmployeeEmail = employeeEmail;
            PlotId = plotId;
            ImageId = imageId;
            }

        public Case Case { get; set; }
        public string CustomerEmail { get; set; }
        public string EmployeeEmail { get; set; }
        public int? MoneyInstituteId { get; set; }
        public int? PlotId { get; set; }
        public int? ImageId { get; set; }
    }
}
