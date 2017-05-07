using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeGUI.Helpers
{
    public static class MessageHandling
    {
        public static void DisplayErrorMessage(string msg)
        {
            string caption = "Ok";
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(msg, caption, buttons, icon);
        }
    }   
}
