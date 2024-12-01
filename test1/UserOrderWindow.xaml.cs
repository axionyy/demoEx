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
using System.Windows.Shapes;
using test1.Model;

namespace test1
{
    /// <summary>
    /// Логика взаимодействия для UserOrderWindow.xaml
    /// </summary>
    public partial class UserOrderWindow : Window
    {
        private List<Order> _orders = new List<Order>();

        public UserOrderWindow()
        {
            InitializeComponent();

            _orders = new Base().ReadObjectFromFile();

            if(_orders != null)
            {
                dataGrid.ItemsSource = _orders;
            }
            else
            {
                dataGrid.ItemsSource = new Base().GenerateOrders();
                new Base().WriteObjectToFile(new Base().GenerateOrders());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
