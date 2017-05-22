using Comforthuse;
using EmployeeGUI.ViewModels;
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
            MessageBox.Show(_caseViewModel.Save().ToString());
        }

        private void plotAddressTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void AssignEmployeeCombobox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            IEmployee emp = (IEmployee)AssignEmployeeCombobox.SelectedItem;
            if (emp != null)
            {
                CaseViewModel caseViewModel = (CaseViewModel)this.DataContext;
                caseViewModel.Employee = emp;
            }
            else
            {
                MessageBox.Show("Is null");
            }
        }
    }
}
