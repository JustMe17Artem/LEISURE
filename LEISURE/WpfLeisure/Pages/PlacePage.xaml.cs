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
        public PlacePage(User user, Place place)
        {
            InitializeComponent();
            currentOwner = DataAccess.GetCurrentOwner(user);
            CBType.ItemsSource = DataAccess.GetPlaceTypes();
            DataContext = this;
            BtnSavePlace.Visibility = Visibility.Hidden;
            BtnClosePlace.Visibility = Visibility.Hidden;
            currentPlace = place;
        }
        public PlacePage(Place place)
        {
            BtnAddPlace.Visibility = Visibility.Hidden;
        }

        private void BtnAddPlace_Click(object sender, RoutedEventArgs e)
        {
            var type = CBType.SelectedItem as Place_Type;
            try
            {
                DataAccess.AddNewPlace(TBName.Text, type.Id, TBAdress.Text, currentOwner.Id, Int32.Parse(TBCapacity.Text), currentPlace.Photo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSavePlace_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClosePlace_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
