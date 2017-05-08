using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeGUI.ViewModels.Partial
{
    /// <summary>
    /// Interaction logic for TechnicalExpenses.xaml
    /// </summary>
    public partial class TechnicalExpenses : UserControl
    {
        private string v1;
        private bool v2;

        public TechnicalExpenses()
        {
            InitializeComponent();
        }

        public TechnicalExpenses(string v1, bool v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}
