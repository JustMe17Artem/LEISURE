using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfLeisure.Pages
{
    /// <summary>
    /// Interaction logic for ActivitiesPage.xaml
    /// </summary>
    public partial class ActivitiesPage : Page
    {
        private static User currentUser;
        public ActivitiesPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            if (DataAccess.CurrentUserIsClient(currentUser))
            {
                LVActivities.ItemsSource = DataAccess.GetActivitiesList();
                var alltypes = DataAccess.GetActivityTypes();
                alltypes.Insert(0, new Activity_Type() { Id = -1, Name = "Все" });
                CBType.ItemsSource = alltypes;
            }
            else
            {
                SearchPanel.Visibility = Visibility.Hidden;
                LVActivities.ItemsSource = DataAccess.GetActivitiesForOwner(DataAccess.GetCurrentOwner(currentUser));
            }
            
        }

        private void BtnWatchPlaces_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlacesPage(currentUser));
        }

        private void LVActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedActivity = LVActivities.SelectedItem as Activity;
            NavigationService.Navigate(new ActivityPage(currentUser,selectedActivity, selectedActivity.Place));
        }

        private void CBType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
        private void Filter()
        {
            var filterActivities = (IEnumerable<Activity>)DB_Connection.connection.Activity.ToList();


            if (CBType.SelectedIndex > 0)
            {
                var type = CBType.SelectedItem as Activity_Type;
                filterActivities = filterActivities.Where(a => a.ID_Type == type.Id);
            }
            if(CBPopularity.SelectedIndex == 0)
            {
                filterActivities = filterActivities.OrderByDescending(a => a.Visits);
            }
            else if (CBPopularity.SelectedIndex == 1)
            {
                filterActivities = filterActivities.OrderBy(a => a.Visits);
            }
            LVActivities.ItemsSource = filterActivities;
        }

        private void CBPopularity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = CBPopularity.SelectedItem as ComboBoxItem;
            CBPopularity.DisplayMemberPath = item.Name;
            Filter();
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void BtnUserInfo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserPage(currentUser));
        }
    }
}
