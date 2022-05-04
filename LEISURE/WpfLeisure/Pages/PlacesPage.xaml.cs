using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
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
using System.Linq;

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
                LVPlaces.ItemsSource = DataAccess.GetPlaces();
                CBType.ItemsSource = DataAccess.GetPlaceTypes();
                var alltypes = DataAccess.GetPlaceTypes();
                alltypes.Insert(0, new Place_Type() { Id = -1, Name = "Все" });
                CBType.ItemsSource = alltypes;
            }
            else
            {
                PlaceData.Visibility = Visibility.Hidden;
                SearchPanel.Visibility = Visibility.Hidden;
                LVPlaces.ItemsSource = DataAccess.GetPlacesByOwner(currentOwner);
            }
        }

        private void LVPlaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPlace = LVPlaces.SelectedItem as Place;
            DataContext = selectedPlace;
            if (DataAccess.CurrentUserIsClient(currentUser))
            {
               
                TBName.Text = selectedPlace.Name;
                TBType.Text = selectedPlace.Place_Type.Name;
                TBAdress.Text = selectedPlace.Adress;
                TBCapacity.Text = selectedPlace.Capacity.ToString();
                if (selectedPlace.IsOpen == true)
                    TBOpen.Text = "Открыто";
                else
                    TBOpen.Text = "Закрыто";
                TBVisits.Text = selectedPlace.Visits.ToString();
            }
            else
            {
                NavigationService.Navigate(new PlacePage(selectedPlace, currentOwner));
            }
        }

        private void BtnNewPlace_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlacePage(currentOwner.User, new Place()));
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void Filter()
        {
            var filterPlace = DataAccess.GetPlacesList();

            if (TBSearch.Text != "")
            {
                filterPlace = DataAccess.GetPlacesByNameOrAdress(TBSearch.Text);
            }
            if (CBType.SelectedIndex == 0)
            {
                filterPlace = DataAccess.GetPlacesByNameOrAdress(TBSearch.Text);
            }

            else if (CBType.SelectedIndex > 0)
            {
                var type = CBType.SelectedItem as Place_Type;
                filterPlace = DataAccess.GetPlacesByType(type.Id);
            }
            LVPlaces.ItemsSource = filterPlace;
        }

        private void CBType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
