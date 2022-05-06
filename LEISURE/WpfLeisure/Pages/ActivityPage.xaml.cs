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
            BtnAddNewActivity.Visibility = Visibility.Hidden;
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
            BtnVisit.Visibility = Visibility.Hidden;
            BtnAddActivity.Visibility = Visibility.Hidden;
            CBType.Visibility = Visibility.Hidden;
            TblVisits.Visibility = Visibility.Hidden;
            TBVisits.Visibility = Visibility.Hidden;
            TBContactInfo.Text = currentRequest.ContactInfo;
            TBName.Text = currentRequest.Name;
            TBComment.Text = currentRequest.Comment;
            BtnAddNewActivity.Visibility = Visibility.Hidden;
            TBPrice.Text = currentRequest.Price.ToString();
            TBType.Text = currentRequest.Activity_Type.Name;
            DPStart.SelectedDate = currentRequest.DateStart;
            DPEnd.SelectedDate = currentRequest.DateEnd;
            TBDescription.Text = currentRequest.Description;
            TBComment.IsReadOnly = true;
            TBContactInfo.IsReadOnly = true;
            TBName.IsReadOnly = true;
            TBPrice.IsReadOnly = true;
            TBType.IsReadOnly = true;
            DPStart.IsEnabled = false;
            DPEnd.IsEnabled = false;
            TBDescription.IsReadOnly = true;
            DataContext = request;
        }
        public ActivityPage(User user, Activity activity, Place place)
        {
            InitializeComponent();
            currentActivity = activity;
            TblComment.Visibility = Visibility.Hidden;
            TBComment.Visibility = Visibility.Hidden;
            if (DataAccess.CurrentUserIsClient(user))
            {
                currentClient = DataAccess.GetCurrentClient(user);
                BtnVisit.Visibility = Visibility.Visible;
                BtnAddPhoto.Visibility = Visibility.Hidden;
                BtnAddActivity.Visibility = Visibility.Hidden;
                CBType.Visibility = Visibility.Hidden;
                BtnAddActivity.Visibility = Visibility.Hidden;
                BtnAddNewActivity.Visibility = Visibility.Hidden;
                BtnDeclineRequest.Visibility = Visibility.Hidden;
                TblInfo.Visibility = Visibility.Hidden;
                TBContactInfo.Visibility = Visibility.Hidden;
                TBName.IsReadOnly = true;
                TBPrice.IsReadOnly = true;
                TBType.IsReadOnly = true;
                DPEnd.IsEnabled = false;
                DPEnd.IsEnabled = false;
                DataContext = currentActivity;
            }
            else
            {
                currentPlace = place;
                BtnVisit.Visibility = Visibility.Hidden;
                TBContactInfo.Visibility = Visibility.Hidden;
                TblInfo.Visibility = Visibility.Hidden;
                TblVisits.Visibility = Visibility.Hidden;
                TBVisits.Visibility = Visibility.Hidden;
                TBType.Visibility = Visibility.Hidden;
                BtnAcceptRequest.Visibility = Visibility.Hidden;
                BtnAddActivity.Visibility = Visibility.Hidden;
                BtnDeclineRequest.Visibility = Visibility.Hidden;
                CBType.ItemsSource = DataAccess.GetActivityTypes();
                DataContext = this;
            }
            
        }


        private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                if(currentRequest != null)
                {
                    currentRequest.Photo = File.ReadAllBytes(openFile.FileName);
                    ActivityPhoto.Source = new BitmapImage(new Uri(openFile.FileName));
                }
                else
                {
                    currentActivity.Photo = File.ReadAllBytes(openFile.FileName);
                    ActivityPhoto.Source = new BitmapImage(new Uri(openFile.FileName));
                }
                
            }
        }

        private void BtnAddActivity_Click(object sender, RoutedEventArgs e)
        {
            var type = CBType.SelectedItem as Activity_Type;
            if(TBName.Text.Length != 0 && TBPrice.Text.Length !=0 && CBType.SelectedItem != null && DPStart.SelectedDate != null && DPEnd.SelectedDate != null /*&& ActivityPhoto.Source != null*/)
            {
                try
                {
                    DataAccess.AddNewRequest(currentPlace, DPStart.SelectedDate.Value, DPEnd.SelectedDate.Value, float.Parse(TBPrice.Text), TBDescription.Text,  TBName.Text, type.Id, TBContactInfo.Text, TBComment.Text, currentRequest.Photo);
                    MessageBox.Show("Заявка отправлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Поля : Название,\nСтоимость,\nТип мероприятия,\nа также даты начала и окончания - обязательны к заполнению");
            }
            
            
        }

        private void BtnDeclinerequest_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.DeclineRequest(currentRequest);
            MessageBox.Show("Заявка отклонена");
        }

        private void BtnAcceptRequest_Click_1(object sender, RoutedEventArgs e)
        {
            
            DataAccess.AcceptRequest(currentRequest);
            DataAccess.AddActivityByRequest(currentRequest);
            MessageBox.Show("Заявка принята, мероприятие создано");
        }

        private void BtnVisit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddNewActivity_Click(object sender, RoutedEventArgs e)
        {
            var type = CBType.SelectedItem as Activity_Type;
            try
            {
                DataAccess.AddNewActivity(currentPlace, DPStart.SelectedDate.Value, DPEnd.SelectedDate.Value, float.Parse(TBPrice.Text), TBDescription.Text, currentActivity.Photo, TBName.Text, type.Id, TBContactInfo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Мероприятие создано");
        }
    }
}
