using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core.ado;
using Core.Classes_Core;

namespace WpfLeisure.Pages
{
    /// <summary>
    /// Interaction logic for PlacesPage.xaml
    /// </summary>
    public partial class PlacesPage : Page
    {
        private static Owner currentOwner;
        private static Client currentClient;
        private static User currentUser;
        public PlacesPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            currentOwner = DataAccess.GetCurrentOwner(user);
            currentClient = DataAccess.GetCurrentClient(user);
            
            if(DataAccess.CurrentUserIsClient(currentUser))
            {
                BtnNewPlace.Visibility = Visibility.Hidden;
                LVPlaces.ItemsSource = DataAccess.GetPlacesList();
                BtnRequests.Visibility = Visibility.Hidden;
                var alltypes = DataAccess.GetPlaceTypes();
                alltypes.Insert(0, new Place_Type() { Id = -1, Name = "Все" });
                CBType.ItemsSource = alltypes;
            }
            else
            {
                SearchPanel.Visibility = Visibility.Hidden;
                LVPlaces.ItemsSource = DataAccess.GetPlacesByOwner(currentOwner);
            }
        }

        private void LVPlaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPlace = LVPlaces.SelectedItem as Place;
            if (DataAccess.CurrentUserIsClient(currentUser))
            {
                NavigationService.Navigate(new PlacePage(currentClient, selectedPlace));
                DataAccess.AddVisitToPlace(selectedPlace);
            }
            else
            {
                NavigationService.Navigate(new PlacePage(selectedPlace, currentOwner));
            }
        }

        private void BtnNewPlace_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlacePage(currentOwner, new Place()));
        }

        private void Filter()
        {
            var filterPlace = DataAccess.GetPlacesList();

            if (CBType.SelectedIndex > 0)
            {
                var type = CBType.SelectedItem as Place_Type;
                filterPlace = DataAccess.GetPlacesByType(type.Id);
            }
            if (CBPopularity.SelectedIndex == 0)
            {
                filterPlace = filterPlace.OrderByDescending(a => a.Visits);
            }
            else if (CBPopularity.SelectedIndex == 1)
            {
                filterPlace = filterPlace.OrderBy(a => a.Visits);
            }
            LVPlaces.ItemsSource = filterPlace;
        }

        private void CBType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void BtnRequests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RequestsPage(currentOwner));
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void CBPopularity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = CBPopularity.SelectedItem as ComboBoxItem;
            CBPopularity.DisplayMemberPath = item.Name;
            Filter();
        }
    }
}
