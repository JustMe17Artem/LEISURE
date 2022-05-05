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
using Core.Classes_Core;
using Core.ado;
using Microsoft.Win32;
using System.IO;

namespace WpfLeisure.Pages
{
    /// <summary>
    /// Interaction logic for ActivityPage.xaml
    /// </summary>
    public partial class ActivityPage : Page
    {
        private static Owner currentOwner;
        private static Client currentClient;
        private static Place currentPlace;
        private static Activity currentActivity;
        private static Request currentRequest;
        public ActivityPage(Client client, Place place, Request request)
        {
            InitializeComponent();
            currentClient = client;
            currentPlace = place;
            currentRequest = request;
            TblVisits.Visibility = Visibility.Hidden;
            TBVisits.Visibility = Visibility.Hidden;
            TBType.Visibility = Visibility.Hidden;
            BtnVisit.Visibility = Visibility.Hidden;
            BtnAcceptRequest.Visibility = Visibility.Hidden;
            BtnDeclineRequest.Visibility = Visibility.Hidden;
            CBType.ItemsSource = DataAccess.GetActivityTypes();
            DataContext = this;
        }
        public ActivityPage(Owner owner, Request request)
        {
            InitializeComponent();
            currentOwner = owner;
            BtnVisit.Visibility = Visibility.Hidden;
            CBType.Visibility = Visibility.Hidden;
            DataContext = this;
        }

        private void BtnVisit_Click(object sender, RoutedEventArgs e)
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
                currentRequest.Photo = File.ReadAllBytes(openFile.FileName);
                ActivityPhoto.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void BtnAddActivity_Click(object sender, RoutedEventArgs e)
        {
            var type = CBType.SelectedItem as Activity_Type;
            try
            {
                DataAccess.AddNewRequest(currentPlace, DPStart.SelectedDate.Value, DPEnd.SelectedDate.Value, float.Parse(TBPrice.Text), TBDescription.Text, currentRequest.Photo, TBName.Text, type.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Заявка отправлена");
        }

        private void BtnDeclinerequest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAcceptRequest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
