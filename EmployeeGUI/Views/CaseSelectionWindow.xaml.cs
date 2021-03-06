﻿using EmployeeGUI.Helpers;
using System.Windows;
using System.Windows.Input;


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

        private void CaseList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ExecuteEditCaseCommand();
        }

        private void MenuItemEdit_OnClick(object sender, RoutedEventArgs e)
        {
            ExecuteEditCaseCommand();
        }



        private void ExecuteEditCaseCommand()
        {
            ICommand cm = vm.EditCaseCommand;
            cm.Execute(CaseList.SelectedItem);
        }


        private void MenuItemPrint_OnClick(object sender, RoutedEventArgs e)
        {
            MessageHandling.DisplayErrorMessage("Not implemented yet.");
            // OpenPrintWindow();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ICommand ic = vm.GetCasesCommand;
            ic.Execute(CaseList);

        }
    }
}
