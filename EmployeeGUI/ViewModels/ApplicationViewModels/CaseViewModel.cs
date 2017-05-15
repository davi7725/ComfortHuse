﻿using Comforthuse;
using Comforthuse.Interfaces;
using Comforthuse.Models;
using EmployeeGUI.Helpers;
using EmployeeGUI.ViewModels.ExpenseCategoryPages;
using SimpleMVVMExample;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace EmployeeGUI.ViewModels
{
    public class CaseViewModel : ObservableObject
    {
        private ICustomer _caseCustomer;
        private ICommand _changePageCommand;
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;
        private ICase _activeCase;

        public ICase Case
        {
            get
            {
                return _activeCase;
            }
            set
            {
                _activeCase = value;
                InstanciateViewModel();
            }
        }

        private void InstanciateViewModel()
        {
            _caseCustomer = _activeCase.Customer;
        }
        public CaseViewModel()
        {

            // Instanciate and add avaliable pages
            PageViewModels.Add(new HouseTypeExpenseViewModel());
            PageViewModels.Add(new GarageCarportExpenseViewModel());
            PageViewModels.Add(new PlotExpenseViewModel());
            PageViewModels.Add(new MaterialsOutsideExpenseViewModel());
            PageViewModels.Add(new WindowsDoorsExpenseViewModel());
            PageViewModels.Add(new MaterialInsideExpenseViewModel());
            PageViewModels.Add(new InteriorExpenseViewModel());
            PageViewModels.Add(new FloorExpenseViewModel());
            PageViewModels.Add(new PowerExpenseViewModel());
            PageViewModels.Add(new HomeApplianceExpenseViewModel());
            PageViewModels.Add(new TilesExpenseViewModel());
            PageViewModels.Add(new CarpentryExpenseViewModel());
            PageViewModels.Add(new PaintExpenseViewModel());
            PageViewModels.Add(new WallingExpenseViewModel());
            PageViewModels.Add(new PlumbingExpenseViewModel());
            PageViewModels.Add(new VentilationExpenseViewModel());
            PageViewModels.Add(new ExtraContructionViewModel());
            PageViewModels.Add(new OtherExpenseViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                     p => ChangeViewModel((IPageViewModel)p),
                     p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        public string CaseID
        {
            get { return "Case Number: " + _activeCase.DateOfCreation.Year + "-" + _activeCase.CaseNumber.ToString(); }
        }

        public string FirstName
        {
            get { return _caseCustomer.FirstName; }
            set { _caseCustomer.FirstName = value; }
        }

        public string LastName
        {
            get { return _caseCustomer.LastName; }
            set { _caseCustomer.LastName = value; }

        }

        public string Email
        {
            get { return _caseCustomer.FirstName; }
            set { _caseCustomer.FirstName = value; }
        }

        public string City
        {
            get { return _caseCustomer.City; }
            set { _caseCustomer.City = value; }
        }

        public string Address
        {
            get { return _caseCustomer.Address; }
            set { _caseCustomer.Address = value; }
        }
        public string Zipcode
        {
            get { return _caseCustomer.Zipcode; }
            set { _caseCustomer.Zipcode = value; }
        }
        public string PhoneNb1
        {
            get { return _caseCustomer.PhoneNb1; }
            set { _caseCustomer.PhoneNb1 = value; }
        }
        public string PhoneNb2
        {
            get { return _caseCustomer.PhoneNb2; }
            set { _caseCustomer.PhoneNb2 = value; }
        }

        public void InjectExpenseCategories()
        {
            IHouseTypeExpenses hsExpenses = (IHouseTypeExpenses)_activeCase.GetExpenseCategory(Category.HouseType);
            //TechnicalSpecifications = new List<ITechnicalSpecification>() { new TechnicalSpecification() { Description = "LUL", Ticked = true, EditAble = false }, new TechnicalSpecification() }
            PageViewModels[0].TechnicalSpecifications = hsExpenses.TechnicalSpecifications;
            PageViewModels[0].ExtraExpenses = hsExpenses.ExtraExpenses;

        }
    }
}
