using Comforthuse.Facade;
using Comforthuse.Models;
using EmployeeGUI.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Comforthuse;
using Comforthuse.Interfaces;

namespace EmployeeGUI.ViewModels
{
    public class CaseSelectionViewModel
    {
        private ICommand _getCasesCommand;
        private ICommand _createCaseCommand;
        private ICommand _editCaseCommand;

        private readonly IEmployeeFacade _facade = new DomainFacade();

        private ObservableCollection<ICase> _cases;

        public ObservableCollection<ICase> Cases
        {
            get
            {
                if (_cases == null)
                {
                    _cases = new ObservableCollection<ICase>(_facade.GetAllCases());
                }
                return _cases;
            }
        }

        public ICommand GetCasesCommand
        {
            get
            {
                if (_getCasesCommand == null) _getCasesCommand = new RelayCommand(GetAllCases);
                return _getCasesCommand;
            }
        }

        public ICommand CreateCaseCommand
        {
            get
            {
                if (_createCaseCommand == null)
                {

                    _createCaseCommand = new RelayCommand(CreateCase);
                }
                return _createCaseCommand;
            }
        }

        public ICommand EditCaseCommand
        {
            get
            {
                if (_editCaseCommand == null)
                {

                    _editCaseCommand = new RelayCommand(EditCase);
                }
                return _editCaseCommand;
            }
        }

        private void GetAllCases(object obj)
        {
            try
            {
                _cases = new ObservableCollection<ICase>(_facade.GetAllCases());
            }
            catch (Exception e)
            {
                MessageHandling.DisplayErrorMessage(e.Message);
            }
        }

        private void CreateCase(object obj)
        {
            try
            {
                ICase newCase = _facade.CreateCase();
                OpenCase(newCase);
            }
            catch (Exception e)
            {
                MessageHandling.DisplayErrorMessage(e.Message);
                throw;
            }
        }

        private void EditCase(object obj)
        {
            try
            {
                ICase c = (ICase)obj;
                OpenCase(c);
            }
            catch (Exception e)
            {
                MessageHandling.DisplayErrorMessage(e.Message);
                throw;
            }
        }

        private void OpenCase(ICase c)
        {
            CaseWindow win = new CaseWindow();
            CaseViewModel vm = new CaseViewModel() {Case = c};
            vm.InjectExpenseCategories();
            win.DataContext = vm;
            win.Show();

        }



    }
}
