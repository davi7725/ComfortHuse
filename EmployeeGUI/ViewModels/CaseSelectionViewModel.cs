﻿using Comforthuse.Facade;
using Comforthuse.Models;
using EmployeeGUI.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EmployeeGUI.ViewModels
{
    class CaseSelectionViewModel
    {
        private readonly IEmployeeFacade _facade = new DomainFacade();
        private ICommand _updateCommand;
        private ICommand _createCaseCommand;
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
            // Use try-catch
            _cases = new ObservableCollection<ICase>(_facade.GetAllCases());

        }
    }
}