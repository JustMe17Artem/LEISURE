using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
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
        private static User currentUser;
        private static Client currentClient;
        private static Place currentPlace;
        private static Activity currentActivity;
        private static Request currentRequest;
        public ActivityPage(Client client, Place place, Request request)
        {
            InitializeComponent();
            currentClient = client;
            TBInfo.Text = $"{place.Owner.Email} \n {place.Owner.Phone}";
            TBlDate.Visibility = Visibility.Hidden;
            TBlTime.Visibility = Visibility.Hidden;
            currentUser = DataAccess.GetUserFromClient(currentClient);
            currentPlace = place;
            BtnCloseActivity.Visibility = Visibility.Hidden;
            currentRequest = request;
            TBlName.Visibility = Visibility.Hidden;
            TBlPrice.Visibility = Visibility.Hidden;
            TBlType.Visibility = Visibility.Hidden;
            TBlDescription.Visibility = Visibility.Hidden;
            TblVisits.Visibility = Visibility.Hidden;
            TBlVisits.Visibility = Visibility.Hidden;
            BtnAddNewActivity.Visibility = Visibility.Hidden;
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
            TBlInfo.Visibility = Visibility.Hidden;
            TBInfo.Visibility = Visibility.Hidden;
            TBlTime.Visibility = Visibility.Hidden;
            TBlDate.Visibility = Visibility.Hidden;
            BtnCloseActivity.Visibility = Visibility.Hidden;
            currentUser = DataAccess.GetUserFromOwner(currentOwner);
            TBlType.Visibility = Visibility.Hidden;
            currentRequest = request;
            TBlName.Visibility = Visibility.Hidden;
            TBlDescription.Visibility = Visibility.Hidden;
            TblPrice.Visibility = Visibility.Hidden;
            TBlPrice.Visibility = Visibility.Hidden;
            BtnVisit.Visibility = Visibility.Hidden;
            BtnAddRequest.Visibility = Visibility.Hidden;
            TblVisits.Visibility = Visibility.Hidden;
            TBlVisits.Visibility = Visibility.Hidden;
            BtnAddNewActivity.Visibility = Visibility.Hidden;
            DPStart.SelectedDate = currentRequest.DateStart;
            TBDescription.Text = currentRequest.Description;
            TBComment.IsReadOnly = true;
            TBContactInfo.IsReadOnly = true;
            CBType.ItemsSource = DataAccess.GetActivityTypes();
            CBType.SelectedItem = currentRequest.Activity_Type;
            DataContext = request;
        }

        public ActivityPage(Place place, Activity activity, User user)// создание
        {
            InitializeComponent();
            currentPlace = place;
            currentActivity = activity;
            currentUser = user;
            TBlInfo.Visibility = Visibility.Hidden;
            TBInfo.Visibility = Visibility.Hidden;
            TBlDate.Visibility = Visibility.Hidden;
            TBlTime.Visibility = Visibility.Hidden;
            BtnCloseActivity.Visibility = Visibility.Hidden;
            TBlName.Visibility = Visibility.Hidden;
            BtnAddRequest.Visibility = Visibility.Hidden;
            TBlPrice.Visibility = Visibility.Hidden;
            TBContactInfo.Visibility = Visibility.Hidden;
            TblInfo.Visibility = Visibility.Hidden;
            TblVisits.Visibility = Visibility.Hidden;
            TblComment.Visibility = Visibility.Hidden;
            TBlType.Visibility = Visibility.Hidden;
            CBType.ItemsSource = DataAccess.GetActivityTypes();
            TBComment.Visibility = Visibility.Hidden;
            TBlDescription.Visibility = Visibility.Hidden;
            BtnAcceptRequest.Visibility = Visibility.Hidden;
            BtnDeclineRequest.Visibility = Visibility.Hidden;
            BtnVisit.Visibility = Visibility.Hidden;
        }

        public ActivityPage(User user, Activity activity, Place place)// просмотр + закрытие активити. для создания - отдельнеый конструктор
        {
            InitializeComponent();
            currentActivity = activity;
            TBInfo.Visibility = Visibility.Hidden;
            currentUser = user;
            TBlInfo.Visibility = Visibility.Hidden;
            TblComment.Visibility = Visibility.Hidden;
            DPStart.Visibility = Visibility.Hidden;
            TBComment.Visibility = Visibility.Hidden;
            TblInfo.Visibility = Visibility.Hidden;
            TblPrice.Visibility = Visibility.Hidden;
            TPTime.Visibility = Visibility.Hidden;
            BtnAddPhoto.Visibility = Visibility.Hidden;
            CBType.Visibility = Visibility.Hidden;
            BtnAddRequest.Visibility = Visibility.Hidden;
            BtnDeclineRequest.Visibility = Visibility.Hidden;
            BtnAcceptRequest.Visibility = Visibility.Hidden;
            TBContactInfo.Visibility = Visibility.Hidden;
            BtnAddNewActivity.Visibility = Visibility.Hidden;
            TBName.Visibility = Visibility.Hidden;
            TBDescription.Visibility = Visibility.Hidden;
            TBPrice.Visibility = Visibility.Hidden;
            if (DataAccess.CurrentUserIsClient(user))
            {
                currentClient = DataAccess.GetCurrentClient(user);
                BtnCloseActivity.Visibility = Visibility.Hidden;
                DPStart.IsEnabled= false;
                TBName.Visibility = Visibility.Hidden;
                DataContext = currentActivity;
            }
            else
            {
                currentPlace = place;
                BtnVisit.Visibility = Visibility.Hidden;
                DPStart.IsEnabled = false;
                DataContext = currentActivity;
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

        public bool ActivityIsValid()
        {
            if (TBName.Text.Length != 0 && TBPrice.Text.Length != 0 && CBType.SelectedItem != null && DPStart.SelectedDate != null && DPStart.SelectedDate >= DateTime.Now.Date  && TPTime.SelectedTime != null)
                return true;
            else
                return false;
        }
        private void BtnDeclinerequest_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.DeclineRequest(currentRequest);
            MessageBox.Show("Заявка отклонена");
            NavigationService.Navigate(new RequestsPage(currentOwner));
        }

        private void BtnAcceptRequest_Click_1(object sender, RoutedEventArgs e)
        {
            Activity_Type type = CBType.SelectedItem as Activity_Type;

            if (ActivityIsValid())
            {
                try
                {
                    DataAccess.AcceptRequest(currentRequest);
                    DataAccess.AddNewActivity(currentRequest.Place, DPStart.SelectedDate.Value, TPTime.SelectedTime.Value.TimeOfDay, float.Parse(TBPrice.Text), TBDescription.Text, currentRequest.Photo, TBName.Text, type.Id);
                    MessageBox.Show("Заявка принята, мероприятие создано");
                    NavigationService.Navigate(new RequestsPage(currentOwner));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Мероприятие не может проходить в прошлом времени\nПоля : Название,\nСтоимость,\nТип мероприятия,\nа также дата и время начала - обязательны к заполнению");
            }
        }
        private void BtnVisit_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddVisitToActivity(currentActivity);
            MessageBox.Show("Ура! мероприятие стало популярнее");
        }

        private void BtnAddNewActivity_Click(object sender, RoutedEventArgs e)
        {
            Activity_Type type = CBType.SelectedItem as Activity_Type;

            if (ActivityIsValid())
            {
                try
                {
                    DataAccess.AddNewActivity(currentPlace, DPStart.SelectedDate.Value, TPTime.SelectedTime.Value.TimeOfDay, float.Parse(TBPrice.Text), TBDescription.Text, currentActivity.Photo, TBName.Text, type.Id);
                    MessageBox.Show("Мероприятие создано");
                    NavigationService.Navigate(new PlacesPage(currentUser));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Мероприятие не может проходить в прошлом времени\nПоля : Название,\nСтоимость,\nТип мероприятия,\nа также дата и время начала - обязательны к заполнению");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if(currentRequest != null && currentOwner !=null)
                NavigationService.Navigate(new RequestsPage(currentOwner));
            else
                NavigationService.Navigate(new ActivitiesPage(currentUser));
        }

        private void BtnCloseActivity_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.CloseActivity(currentActivity);
            MessageBox.Show("Мероприятие приостановлено");
        }

        private void BtnAddRequest_Click(object sender, RoutedEventArgs e)
        {
            Activity_Type type = CBType.SelectedItem as Activity_Type;
            if (ActivityIsValid())
            {
                try
                {
                    DataAccess.AddNewRequest(currentPlace, DPStart.SelectedDate.Value, TPTime.SelectedTime.Value.TimeOfDay, float.Parse(TBPrice.Text), TBDescription.Text, TBName.Text, type.Id, TBContactInfo.Text, TBComment.Text, currentRequest.Photo);
                    MessageBox.Show("Заявка отправлена");
                    NavigationService.Navigate(new PlacePage(currentClient, currentPlace));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Мероприятие не может проходить в прошлом времени\nПоля : Название,\nСтоимость,\nТип мероприятия,\nа также дата и время начала - обязательны к заполнению");
            }
        }
    }
}
