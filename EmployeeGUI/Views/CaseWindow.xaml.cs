using Comforthuse.Models;
using EmployeeGUI.ViewModels;
using System.Windows;

namespace EmployeeGUI
{
    /// <summary>
    /// Interaction logic for CaseWindow.xaml
    /// </summary>
    public partial class CaseWindow : Window
    {
        private CustomerInformationViewModel _cvm;
        private CustomerInformationViewModel CustomerViewModel
        {
            get { return _cvm; }
        }

        public CaseWindow(ICase c)
        {
            _cvm = new CustomerInformationViewModel(c.Customer);
            InitializeComponent();
        }
    }
}
