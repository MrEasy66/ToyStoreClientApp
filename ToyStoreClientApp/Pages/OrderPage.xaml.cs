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
using ToyStoreClientApp.Data;

namespace ToyStoreClientApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        private OrderRequest _currentOrderRequest = new OrderRequest();
        public OrderPage(OrderRequest orderRequest)
        {
            InitializeComponent();
            if (orderRequest != null)
                _currentOrderRequest = orderRequest;
            DataContext = _currentOrderRequest;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            ToyStoreDBEntities.GetContext().OrderRequest.Add(_currentOrderRequest);
            try
            {
                ToyStoreDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        }
    }
}
