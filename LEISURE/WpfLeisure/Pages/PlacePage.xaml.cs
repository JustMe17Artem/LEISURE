﻿using System;
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
            TBName.IsReadOnly = true;
            TBAdress.IsReadOnly = true;
            TBCapacity.IsReadOnly = true;
            TBType.IsReadOnly = true;
            TBVisits.IsReadOnly = true;
            currentPlace = place;
            TBName.Text = place.Name;
            TBType.Text = place.Place_Type.Name;
            TBAdress.Text = place.Adress;
            TBCapacity.Text = place.Capacity.ToString();
            TBVisits.Text = place.Visits.ToString();
            BtnAddPhoto.Visibility = Visibility.Hidden;
            BtnAddPlace.Visibility = Visibility.Hidden;
            BtnSavePlace.Visibility = Visibility.Hidden;
            BtnClosePlace.Visibility = Visibility.Hidden;
            DataContext = currentPlace;
            
        }
        public PlacePage(Place place, Owner owner)
        {
            InitializeComponent();
            currentPlace = place;
            currentOwner = owner;
            TBName.Text = place.Name;
            TBAdress.Text = place.Adress;
            TBCapacity.Text = place.Capacity.ToString();
            CBType.SelectedItem = place.Place_Type;
            CBType.ItemsSource = DataAccess.GetPlaceTypes();
            BtnAddPlace.Visibility = Visibility.Hidden;
            TBType.Visibility = Visibility.Hidden;
            TBVisits.IsReadOnly = true;
            TBVisits.Text = currentPlace.Visits.ToString();
            BtnSavePlace.Visibility = Visibility.Visible;
            BtnClosePlace.Visibility = Visibility.Visible;
            BtnVisit.Visibility = Visibility.Hidden;
            DataContext = currentPlace;

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
    }
}
