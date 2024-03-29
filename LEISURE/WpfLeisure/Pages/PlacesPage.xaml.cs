﻿using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Navigation;
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
            currentOwner = DataAccess.GetCurrentOwner(currentUser);
            currentClient = DataAccess.GetCurrentClient(currentUser);
            var alltypes = DataAccess.GetPlaceTypes();
            alltypes.Insert(0, new Place_Type() { Id = -1, Name = "Все" });
            CBType.ItemsSource = alltypes;

            if (DataAccess.CurrentUserIsClient(currentUser))
            {
                BtnNewPlace.Visibility = Visibility.Hidden;
                LVPlaces.ItemsSource = DataAccess.GetPlacesList();
                BtnRequests.Visibility = Visibility.Hidden;
                CBOpen.Visibility = Visibility.Hidden;
                TblOpen.Visibility = Visibility.Hidden;
            }
            else
            {
                Title.Text = "Мои объекты";
                LVPlaces.ItemsSource = DataAccess.GetPlacesByOwner(currentOwner);
            }
        }

        private void LVPlaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Place selectedPlace = LVPlaces.SelectedItem as Place;
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
            if (DataAccess.CurrentUserIsClient(currentUser))
            {
                FilterForClient();
            }
            else
            {
                FilterForOwner();
            }
        }

        private void FilterForClient()
        {
            var filterPlace = DataAccess.GetPlacesList();

            if (CBType.SelectedIndex > 0)
            {
                Place_Type type = CBType.SelectedItem as Place_Type;
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



        private void FilterForOwner()
        {
            var filterPlace = DataAccess.GetPlacesByOwner(currentOwner);

            if (CBType.SelectedIndex > 0)
            {
                Place_Type type = CBType.SelectedItem as Place_Type;
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
            if(CBOpen.SelectedIndex == 0)
            {
                filterPlace = filterPlace.Where(p => p.IsOpen == true);
            }
            else if (CBOpen.SelectedIndex == 1)
            {
                filterPlace = filterPlace.Where(p => p.IsOpen == true);
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

        private void BtnWatchActivities_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActivitiesPage(currentUser));
        }

        private void CBOpen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
