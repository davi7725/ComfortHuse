using System;
using System.Collections.Generic;
using System.Windows;


namespace EmployeeGUI.Views
{
    /// <summary>
    /// Interaction logic for CaseSelectionWindow.xaml
    /// </summary>
    public partial class CaseSelectionWindow : Window
    {

        private ViewModels.CaseSelectionViewModel vm;

        public CaseSelectionWindow()
        {
            InitializeComponent();
            vm = new ViewModels.CaseSelectionViewModel();
            this.DataContext = vm;
        }

    }
}
