using Comforthuse.Models;
using EmployeeGUI.ViewModels;
using System.Windows;

namespace EmployeeGUI
{
    /// <summary>
    /// Interaction logic for CaseWindow.xaml
    /// </summary>
    public partial class CaseWindow : Window
    {
        public CaseWindow(ICase theCase)
        {
            InitializeComponent();

            this.Content = new CaseViewModel(theCase);
        }

    }
}
