using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Comforthuse.Facade;
using Comforthuse.Models;
using EmployeeGUI.Helpers;
using WPF_GUI.Helpers;

namespace EmployeeGUI.ViewModels
{
    class CaseSelectionViewModel
    {
        private readonly IEmployeeFacade _facade = new DomainFacade();
        private ICommand _updateCommand;
        private ObservableCollection<ICase> _cases;

        public ObservableCollection<ICase> Cases => _cases ?? (_cases = new ObservableCollection<ICase>(_facade.GetAllCases()));

        public ICommand GetCasesCommand => _updateCommand ?? (_updateCommand = new RelayCommand<object>(GetAllCases));

        private void GetAllCases(object obj)
        {
            // Use try-catch
            _cases = new ObservableCollection<ICase>(_facade.GetAllCases());
        }
    }
}
