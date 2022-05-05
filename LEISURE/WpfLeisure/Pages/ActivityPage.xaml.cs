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
        private static byte[] photo { get; set; }
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
            currentRequest = request;
            photo = request.Photo;
            BtnAddPhoto.Visibility = Visibility.Hidden;
            BtnVisit.Visibility = Visibility.Hidden;
            BtnAddActivity.Visibility = Visibility.Hidden;
            CBType.Visibility = Visibility.Hidden;
            TblVisits.Visibility = Visibility.Hidden;
            TBVisits.Visibility = Visibility.Hidden;
            TBContactInfo.Text = currentRequest.ContactInfo;
            TBName.Text = currentRequest.Name;
            TBPrice.Text = currentRequest.Price.ToString();
            TBType.Text = currentRequest.Activity_Type.Name;
            DPStart.SelectedDate = currentRequest.DateStart;
            DPEnd.SelectedDate = currentRequest.DateEnd;
            TBDescription.Text = currentRequest.Description;
            TBContactInfo.IsEnabled = false;
            TBName.IsEnabled = false;
            TBPrice.IsEnabled = false;
            TBType.IsEnabled = false;
            DPStart.IsEnabled = false;
            DPEnd.IsEnabled = false;
            TBDescription.IsEnabled = false;

            DataContext = request;
        }
        public ActivityPage(Client client, Activity activity)
        {
            InitializeComponent();
            currentActivity = activity;
            currentClient = client;
            DataContext = currentActivity;
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
                DataAccess.AddNewRequest(currentPlace, DPStart.SelectedDate.Value, DPEnd.SelectedDate.Value, float.Parse(TBPrice.Text), TBDescription.Text, currentRequest.Photo, TBName.Text, type.Id, TBContactInfo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Заявка отправлена");
        }

        private void BtnDeclinerequest_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.DeclineRequest(currentRequest);
            MessageBox.Show("Заявка отклонена");
        }

        private void BtnAcceptRequest_Click_1(object sender, RoutedEventArgs e)
        {
            DataAccess.AcceptRequest(currentRequest);
            try
            
                DataAccess.AddActivityByRequest(currentRequest);
                MessageBox.Show("Заявка принята, мероприятие создано");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
        }
    }
}
