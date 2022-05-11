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
            LVActivities.ItemsSource = DataAccess.GetActivities();
            var alltypes = DataAccess.GetActivityTypes();
            alltypes.Insert(0, new Activity_Type() { Id = -1, Name = "Все" });
            CBType.ItemsSource = alltypes;
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
            var filterActivities = DataAccess.GetActivities();

            if (CBType.SelectedIndex > 0)
            {
                var type = CBType.SelectedItem as Place_Type;
                filterActivities = DataAccess.GetActivitiesByType(type.Id);
            }
            LVActivities.ItemsSource = filterActivities;
        }

    }
}
