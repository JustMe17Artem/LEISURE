using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
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
            var alltypes = DataAccess.GetActivityTypes();
            alltypes.Insert(0, new Activity_Type() { Id = -1, Name = "Все" });
            CBType.ItemsSource = alltypes;
            if (DataAccess.CurrentUserIsClient(currentUser))
            {
                LVActivities.ItemsSource = DataAccess.GetActivitiesList();
            }
            else
            {
                LVActivities.ItemsSource = DataAccess.GetActivitiesForOwner(DataAccess.GetCurrentOwner(currentUser));
            }
        }

        private void BtnWatchPlaces_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlacesPage(currentUser));
        }

        private void LVActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity selectedActivity = LVActivities.SelectedItem as Activity;
            NavigationService.Navigate(new ActivityPage(currentUser,selectedActivity, selectedActivity.Place));
        }

        private void Filter()
        {
            if (DataAccess.CurrentUserIsClient(currentUser))
            {
                FilterForClient();
            }
            else
            {
                FilterForOwner();
            }
        }

        private void CBType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
        private void FilterForClient()
        {
            var filterActivities = DataAccess.GetActivitiesList();


            if (CBType.SelectedIndex > 0)
            {
                Activity_Type type = CBType.SelectedItem as Activity_Type;
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
            if(CBDate.SelectedIndex == 1)
            {
                filterActivities = filterActivities.OrderBy(a => a.DateStart);
            }
            else if (CBDate.SelectedIndex == 0)
            {
                filterActivities = filterActivities.OrderByDescending(a => a.DateStart);
            }
            LVActivities.ItemsSource = filterActivities;
        }

        private void FilterForOwner()
        {
            var filterActivities = DataAccess.GetActivitiesForOwner(DataAccess.GetCurrentOwner(currentUser));


            if (CBType.SelectedIndex > 0)
            {
                Activity_Type type = CBType.SelectedItem as Activity_Type;
                filterActivities = filterActivities.Where(a => a.ID_Type == type.Id);
            }
            if (CBPopularity.SelectedIndex == 0)
            {
                filterActivities = filterActivities.OrderByDescending(a => a.Visits);
            }
            else if (CBPopularity.SelectedIndex == 1)
            {
                filterActivities = filterActivities.OrderBy(a => a.Visits);
            }
            if (CBDate.SelectedIndex == 1)
            {
                filterActivities = filterActivities.OrderBy(a => a.DateStart);
            }
            else if (CBDate.SelectedIndex == 0)
            {
                filterActivities = filterActivities.OrderByDescending(a => a.DateStart);
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
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthoPage());
        }

        private void CBDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
