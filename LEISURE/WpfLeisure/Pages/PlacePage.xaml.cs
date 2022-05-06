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
using System.Linq;
using Core.Classes_Core;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;

namespace WpfLeisure.Pages
{
    /// <summary>
    /// Interaction logic for PlacePage.xaml
    /// </summary>
    public partial class PlacePage : Page
    {
        private static Owner currentOwner;
        private static Place currentPlace;
        private static User currentUser;
        private static Client currentClient;
        public PlacePage(Client client, Place place)
        {
            InitializeComponent();
            currentClient = client;
            CBType.ItemsSource = DataAccess.GetPlaceTypes();
            TBName.IsReadOnly = true;
            TBAdress.IsReadOnly = true;
            TBCapacity.IsReadOnly = true;
            TBType.IsReadOnly = true;
            TBDescription.IsReadOnly = true;
            currentPlace = place;
            TBName.Text = place.Name;
            TBType.Text = place.Place_Type.Name;
            TBAdress.Text = place.Adress;
            TBCapacity.Text = place.Capacity.ToString();
            TBVisits.Text = place.Visits.ToString();
            BtnAddPhoto.Visibility = Visibility.Hidden;
            BtnNewActivity.Visibility = Visibility.Hidden;
            BtnAddPlace.Visibility = Visibility.Hidden;
            BtnSavePlace.Visibility = Visibility.Hidden;
            BtnClosePlace.Visibility = Visibility.Hidden;
            LVReviews.ItemsSource = DataAccess.GetReviews(currentPlace.Id);
            DataContext = currentPlace;
        }

        public PlacePage(Owner owner, Place place)// новое место
        {
            InitializeComponent();
            currentPlace = place;
            currentOwner = owner;
            BtnClosePlace.Visibility = Visibility.Hidden;
            BtnSavePlace.Visibility = Visibility.Hidden;
            BtnNewActivity.Visibility = Visibility.Hidden;
            TBReview.Visibility = Visibility.Hidden;
            BtnAddReview.Visibility = Visibility.Hidden;
            BtnVisit.Visibility = Visibility.Hidden;
            BtnAddReview.Visibility = Visibility.Hidden;
            LVReviews.Visibility = Visibility.Hidden;
            BtnAddReview.Visibility = Visibility.Hidden;
            TBVisits.Visibility = Visibility.Hidden;
            TBlVisits.Visibility = Visibility.Hidden;
            BtnNewRequest.Visibility = Visibility.Hidden;
            CBType.ItemsSource = DataAccess.GetPlaceTypes();
            DataContext = this;
        }

        public PlacePage(Place place, Owner owner)// место
        {
            InitializeComponent();
            currentPlace = place;
            BtnAddPlace.Visibility = Visibility.Hidden;
            BtnNewRequest.Visibility = Visibility.Hidden;
            currentOwner = owner;
            TBName.Text = place.Name;
            TBAdress.Text = place.Adress;
            TBCapacity.Text = place.Capacity.ToString();
            CBType.SelectedItem = place.Place_Type;
            CBType.ItemsSource = DataAccess.GetPlaceTypes();
            TBType.Visibility = Visibility.Hidden;
            TBVisits.Text = currentPlace.Visits.ToString();
            TBReview.Visibility = Visibility.Hidden;
            BtnVisit.Visibility = Visibility.Hidden;
            BtnAddReview.Visibility = Visibility.Hidden;
            LVReviews.ItemsSource = DataAccess.GetReviews(currentPlace.Id);
            DataContext = currentPlace;
        }

        private void BtnAddPlace_Click(object sender, RoutedEventArgs e)
        {
            var type = CBType.SelectedItem as Place_Type;
            try
            {
                DataAccess.AddNewPlace(TBName.Text, type.Id, TBAdress.Text, currentOwner.Id, Int32.Parse(TBCapacity.Text), currentPlace.Photo, TBDescription.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Новое место добавлено");
            NavigationService.Navigate(new PlacesPage(currentOwner.User));
        }

        private void BtnSavePlace_Click(object sender, RoutedEventArgs e)
        {
            var type = CBType.SelectedItem as Place_Type;
            try
            {
                DataAccess.EditPlace(currentPlace, TBName.Text, type.Id, TBAdress.Text, Int32.Parse(TBCapacity.Text), currentPlace.Photo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Место изменено");
            NavigationService.Navigate(new PlacesPage(currentOwner.User));
        }

        private void BtnClosePlace_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.ClosePlace(currentPlace);
            MessageBox.Show("Объект закрыт");
            NavigationService.Navigate(new PlacesPage(currentOwner.User));
        }

        private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                currentPlace.Photo = File.ReadAllBytes(openFile.FileName);
                PlacePhoto.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void BtnVisit_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddVisitToPlace(currentPlace);
        }

        private void BtnAddReview_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddNewReview(currentClient.Id, currentPlace.Id, TBReview.Text);
        }

        private void BtnNewRequest_Click(object sender, RoutedEventArgs e)
        {
                NavigationService.Navigate(new ActivityPage(currentClient, currentPlace, new Request()));
        }

        private void BtnNewActivity_Click(object sender, RoutedEventArgs e)
        {
            currentUser = DataAccess.GetUserFromOwner(currentOwner);
            NavigationService.Navigate(new ActivityPage(currentUser, new Activity(), currentPlace));
        }
    }
}
