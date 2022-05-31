using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Core.ado;
using Core.Classes_Core;
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
            currentPlace = place;
            currentUser = DataAccess.GetUserFromClient(currentClient);
            TBName.Visibility = Visibility.Hidden;
            TBAdress.Visibility = Visibility.Hidden;
            TBCapacity.Visibility = Visibility.Hidden;
            TBType.Visibility = Visibility.Hidden;
            TBVisits.Visibility = Visibility.Hidden;
            TBDescription.Visibility = Visibility.Hidden;
            CBType.Visibility = Visibility.Hidden;
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
            currentUser = DataAccess.GetUserFromOwner(currentOwner);
            BtnClosePlace.Visibility = Visibility.Hidden;
            BtnSavePlace.Visibility = Visibility.Hidden;
            TBlName.Visibility = Visibility.Hidden;
            TBlAdress.Visibility = Visibility.Hidden;
            TBlCapacity.Visibility = Visibility.Hidden;
            TBlType.Visibility = Visibility.Hidden;
            TBLVisits.Visibility = Visibility.Hidden;
            TBlDescription.Visibility = Visibility.Hidden;
            BtnNewActivity.Visibility = Visibility.Hidden;
            TBReview.Visibility = Visibility.Hidden;
            BtnAddReview.Visibility = Visibility.Hidden;
            BtnAddReview.Visibility = Visibility.Hidden;
            LVReviews.Visibility = Visibility.Hidden;
            TBType.Visibility = Visibility.Hidden;
            BtnAddReview.Visibility = Visibility.Hidden;
            TBVisits.Visibility = Visibility.Hidden;
            TBlVisits.Visibility = Visibility.Hidden;
            BtnNewRequest.Visibility = Visibility.Hidden;
            CBType.ItemsSource = DataAccess.GetPlaceTypes();
            DataContext = this;
        }

        public PlacePage(Place place, Owner owner)
        {
            InitializeComponent();
            currentPlace = place;
            TBVisits.Visibility = Visibility.Hidden;
            currentOwner = owner;
            currentUser = DataAccess.GetUserFromOwner(currentOwner);
            BtnAddPlace.Visibility = Visibility.Hidden;
            BtnNewRequest.Visibility = Visibility.Hidden;
            TBlName.Visibility = Visibility.Hidden;
            TBlAdress.Visibility = Visibility.Hidden;
            TBlCapacity.Visibility = Visibility.Hidden;
            TBlType.Visibility = Visibility.Hidden;
            TBlDescription.Visibility = Visibility.Hidden;
            currentOwner = owner;
            TBType.Visibility = Visibility.Hidden;
            CBType.ItemsSource = DataAccess.GetPlaceTypes();
            TBReview.Visibility = Visibility.Hidden;
            BtnAddReview.Visibility = Visibility.Hidden;
            LVReviews.ItemsSource = DataAccess.GetReviews(currentPlace.Id);
            DataContext = currentPlace;
        }
        public bool PlaceIsValid()
        {
            if (TBName.Text.Length != 0 && TBAdress.Text.Length !=0 && TBDescription.Text.Length != 0 &&  CBType.SelectedItem != null && PlacePhoto.Source != null)
                return true;
            else
                return false;
        }

        private void BtnAddPlace_Click(object sender, RoutedEventArgs e)
        {
            Place_Type type = CBType.SelectedItem as Place_Type;
            if (PlaceIsValid())
            {
                try
                {
                    DataAccess.AddNewPlace(TBName.Text, type.Id, TBAdress.Text, currentOwner.Id, TBCapacity.Text, currentPlace.Photo, TBDescription.Text);
                    MessageBox.Show("Новое место добавлено");
                    NavigationService.Navigate(new PlacesPage(currentOwner.User));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Поля: Название,\nОписание,\nТип объекта,\nа также фото - обязательны к заполнению");
            }
        }
        private void BtnSavePlace_Click(object sender, RoutedEventArgs e)
        {
            Place_Type type = CBType.SelectedItem as Place_Type;
            if (PlaceIsValid())
            {
                try
                {
                    DataAccess.EditPlace(currentPlace, TBName.Text, type.Id, TBAdress.Text, TBCapacity.Text, currentPlace.Photo, TBDescription.Text);
                    MessageBox.Show("Место изменено");
                    NavigationService.Navigate(new PlacesPage(currentOwner.User));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Поля: Название,\nОписание,\nТип объекта,\nа также фото - обязательны к заполнению");
            }
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
        private void BtnAddReview_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddNewReview(currentClient.Id, currentPlace.Id, TBReview.Text);
            MessageBox.Show("Отзыв добавлен");
        }
        private void BtnNewRequest_Click(object sender, RoutedEventArgs e)
        {
             NavigationService.Navigate(new ActivityPage(currentClient, currentPlace, new Request()));
        }
        private void BtnNewActivity_Click(object sender, RoutedEventArgs e)
        {
            currentUser = DataAccess.GetUserFromOwner(currentOwner);
            NavigationService.Navigate(new ActivityPage(currentPlace, new Activity(), currentUser));
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlacesPage(currentUser));
        }
    }
}
