using Comforthuse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeGUI.ViewModels
{
    public class MoneyInstituteViewModel
    {

        private IMoneyInstitute _moneyInstitute;
        public IMoneyInstitute MoneyInstitute { set { _moneyInstitute = value; } }
        public string Name { 
            get { return _moneyInstitute.Name; }
            set {
                _moneyInstitute.Name = value;
            }
        }
        public string Address {
            get { return _moneyInstitute.Address; }
            set {
                _moneyInstitute.Address = value;
            }
        }
        public string Zipcode {
            get { return _moneyInstitute.Zipcode; }
            set
            {
                _moneyInstitute.Zipcode = value;
            }
        }
        public string City
        {
            get { return _moneyInstitute.City; }
            set
            {
                _moneyInstitute.City = value;
            }
        }
        public string PhoneNumber
        {
            get { return _moneyInstitute.PhoneNb; }
            set
            {
                _moneyInstitute.PhoneNb = value;
            }
        }
    }
}
