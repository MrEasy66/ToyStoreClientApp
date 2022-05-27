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
    /// Логика взаимодействия для OfferPage.xaml
    /// </summary>
    public partial class OfferPage : Page
    {
        public OfferPage()
        {
            InitializeComponent();
            offersGrid.ItemsSource = ToyStoreDBEntities.GetContext().PersonalOffer.ToList();
            filterBox.Items.Add("Все");
            filterBox.Items.Add("Предложение");
            filterBox.Items.Add("ID Клиента");
            filterBox.SelectedIndex = 0;
            Update();
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void filterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            List<PersonalOffer> currentOffer = ToyStoreDBEntities.GetContext().PersonalOffer.ToList();
            currentOffer = currentOffer.Where(p => p.Name.ToLower().Contains(searchBox.Text.ToLower())).ToList();

            if (filterBox.SelectedIndex == 0)
                offersGrid.ItemsSource = currentOffer.OrderBy(p => p.ID).ToList();
            if (filterBox.SelectedIndex == 1)
                offersGrid.ItemsSource = currentOffer.OrderBy(p => p.Name);
            if (filterBox.SelectedIndex == 2)
                offersGrid.ItemsSource = currentOffer.OrderBy(p => p.ClientId);
        }
    }
}
