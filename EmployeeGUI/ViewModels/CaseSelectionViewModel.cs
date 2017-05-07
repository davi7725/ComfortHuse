using Comforthuse.Facade;
using Comforthuse.Models;
using EmployeeGUI.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace EmployeeGUI.ViewModels
{
    class CaseSelectionViewModel
    {
        private ICommand _updateCommand;
        private ICommand _createCaseCommand;

        private readonly IEmployeeFacade _facade = new DomainFacade();

        private ObservableCollection<ICase> _cases;

        public ObservableCollection<ICase> Cases => _cases ?? (_cases = new ObservableCollection<ICase>(_facade.GetAllCases()));

        public ICommand GetCasesCommand => _updateCommand ?? (_updateCommand = new RelayCommand(GetAllCases));
        public ICommand CreateCaseCommand => _createCaseCommand ?? (_createCaseCommand = new RelayCommand(CreateCase));

        private void GetAllCases(object obj)
        {
            // Use try-catch
            _cases = new ObservableCollection<ICase>(_facade.GetAllCases());
        }

        private void CreateCase(object obj)
        {
            try
            {
                ICase newCase = _facade.CreateCase();
                OpenNewWindow(newCase);
            }
            catch (Exception e)
            {
                MessageHandling.DisplayErrorMessage(e.Message);
                throw;
            }
        }

        private void OpenNewWindow(ICase c)
        {
            var win = new CaseWindow();
            win.DataContext = new CaseViewModel(c);
            win.Show();
        }
    }
}
