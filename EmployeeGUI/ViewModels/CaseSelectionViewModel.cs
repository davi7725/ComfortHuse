using Comforthuse.Facade;
using Comforthuse.Models;
using EmployeeGUI.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace EmployeeGUI.ViewModels
{
    class CaseSelectionViewModel
    {
        private ICommand _getCasesCommand;
        private ICommand _createCaseCommand;

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

        private void GetAllCases(object obj)
        {
            // Use try-catch
            try
            {
                _cases = new ObservableCollection<ICase>(_facade.GetAllCases());
            }
            catch (Exception e)
            {
                DisplayError(e);
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
                DisplayError(e);
            }

        }

        private void DisplayError(Exception e)
        {
            string message = e.Message;
            string caption = "Ok";
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(message, caption, buttons, icon);
        }

        private void EditCase()
        {
            //_facade.GetCase()
            //OpenCase();
        }

        private void OpenCase(ICase c)
        {
            CaseWindow win = new CaseWindow();
            win.Content = new CaseViewModel(c);
            win.Show();
        }

    }
}
