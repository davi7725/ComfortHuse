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

namespace EmployeeGUI
{
    /// <summary>
    /// Interaction logic for CaseWindow.xaml
    /// </summary>
    public partial class CaseWindow : Window
    {
        public CaseWindow()
        {
            InitializeComponent();
            List<ProductCategories> items = new List<ProductCategories>();
            items.Add(new ProductCategories() { Title = "Housetype", Price = 0 });
            items.Add(new ProductCategories() { Title = "Carport/garage", Price = 0 });
            items.Add(new ProductCategories() { Title = "Plot", Price = 0 });
            items.Add(new ProductCategories() { Title = "Material(outside)", Price = 0 });
            items.Add(new ProductCategories() { Title = "Windows and doors", Price = 0 });
            items.Add(new ProductCategories() { Title = "Material(outside)", Price = 0 });
            items.Add(new ProductCategories() { Title = "Interior", Price = 0 });
            items.Add(new ProductCategories() { Title = "Floors", Price = 0 });
            items.Add(new ProductCategories() { Title = "Power", Price = 0 });
            items.Add(new ProductCategories() { Title = "Household appliances", Price = 0 });
            items.Add(new ProductCategories() { Title = "Tile", Price = 0 });
            items.Add(new ProductCategories() { Title = "Carpenter", Price = 0 });
            items.Add(new ProductCategories() { Title = "Builder", Price = 0 });
            items.Add(new ProductCategories() { Title = "Painter", Price = 0 });
            items.Add(new ProductCategories() { Title = "Plumbing", Price = 0 });
            items.Add(new ProductCategories() { Title = "Ventilation", Price = 0 });
            items.Add(new ProductCategories() { Title = "Plot expenses", Price = 0 });
            items.Add(new ProductCategories() { Title = "Additional construction expenses", Price = 0 });
            items.Add(new ProductCategories() { Title = "Extra Construction", Price = 0 });
            items.Add(new ProductCategories() { Title = "Other", Price = 0 });
            items.Add(new ProductCategories() { Title = "Statement", Price = 0 });

            ListBoxProductCatergories.ItemsSource = items;
        }

        public class ProductCategories
        {
            public string Title { get; set; }
            public int Price { get; set; }
        }

    }
}
