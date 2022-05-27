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
using ToyStoreClientApp.Data;
using ToyStoreClientApp.Pages;

namespace ToyStoreClientApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow(User user)
        {
            InitializeComponent();
            Manager.MainFrame = mainFrame;
            mainFrame.Navigate(new ClientStartPage());
            txtBlockName.Text += user.Client.Name;
            txtBlockSurname.Text += user.Client.Surname;
        }

        private void btnOffer_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new OfferPage());
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new OrderPage(null));
        }

        private void mainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (mainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                btnBack.Visibility = Visibility.Hidden;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
