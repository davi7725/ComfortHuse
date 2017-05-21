using Comforthuse;
using Comforthuse.Models;
using EmployeeGUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeGUI.ViewModels
{
    public class EmployeeViewModel : ObservableObject
    {

        private IEmployee _employee;
        public IEmployee Employee { set { _employee = value; } }

        public string DisplayName { 
            get { return _employee.FirstName + "" + _employee.LastName; }
        }
        
        public string FirstName {
            get { return _employee.FirstName; }
            set {
                _employee.FirstName = value;
            }
        }
        public string LastName {
            get { return _employee.LastName; }
            set
            {
                _employee.LastName = value;
            }
        }
        public string Email
        {
            get { return _employee.Email; }
            set
            {
                _employee.Email = value;
            }
        }
        public string PhoneNumber
        {
            get { return _employee.PhoneNumber; }
            set
            {
                _employee.PhoneNumber = value;
            }
        }
    }
}
