using Comforthuse.Models;

namespace EmployeeGUI.ViewModels
{
    public class CustomerInformationViewModel
    {
        private ICustomer customer;

        public CustomerInformationViewModel(ICustomer customer)
        {
            this.customer = customer;
        }
    }
}
