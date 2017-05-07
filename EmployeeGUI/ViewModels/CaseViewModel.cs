using Comforthuse.Models;
using EmployeeGUI.Helpers;
using SimpleMVVMExample;
using System.Collections.Generic;
using System.Windows.Input;
using EmployeeGUI.ViewModels.ExpenseCategoryPages;

namespace EmployeeGUI.ViewModels
{
    public partial class CaseViewModel : ObservableObject
    {

        private ICommand _changePageCommand;
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;
        private ICase _activeCase;

        public CaseViewModel(ICase activeCase)
        {
            _activeCase = activeCase;
            // Add available pages

            //PageViewModels.Add(new HouseTypeViewModel());



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

        private void ChangeViewModel(IPageViewModel pageViewModel)
        {

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
    }

}
