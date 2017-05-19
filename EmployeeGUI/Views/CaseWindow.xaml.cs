﻿using EmployeeGUI.ViewModels;
using System.Windows;

namespace EmployeeGUI
{
    /// <summary>
    /// Interaction logic for CaseWindow.xaml
    /// </summary>
    public partial class CaseWindow : Window
    {
        private CaseViewModel _caseViewModel;

        public CaseWindow()
        {
            InitializeComponent();
            _caseViewModel = (CaseViewModel)this.DataContext;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            _caseViewModel = (CaseViewModel)this.DataContext;
            _caseViewModel.Save();
        }
    }
}
