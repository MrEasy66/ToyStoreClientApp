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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void pwdChBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                pwdBox.Text = passwordBox.Password;
                pwdBox.Visibility = Visibility.Visible;
                passwordBox.Visibility = Visibility.Hidden;
            }
            else
            {
                passwordBox.Password = pwdBox.Text;
                pwdBox.Visibility = Visibility.Hidden;
                passwordBox.Visibility = Visibility.Visible;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int userId = 0;
            foreach (var user in ToyStoreDBEntities.GetContext().User)
            {
                if (loginBox.Text == user.Login && passwordBox.Password == user.Password)
                {
                    count++;
                    userId = user.ID;
                    ClientWindow clientWindow = new ClientWindow(user);
                    clientWindow.Show();
                    this.Close();
                    break;
                }
            }

            try
            {
                if (count == 0 && userId != 0)
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
                else if (count == 1 && userId != 0)
                {
                    MessageBox.Show("Добро пожаловать");
                }
            }
            catch
            {
                MessageBox.Show("Невозможно подключиться к базе данных");
            }
        }
    }
}
