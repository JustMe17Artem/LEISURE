using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Core.Classes_Core;
using Core.ado;

namespace WpfLeisure.Pages
{
    /// <summary>
    /// Interaction logic for RequestsPage.xaml
    /// </summary>
    public partial class RequestsPage : Page
    {
        private static Owner currentOwner;
        public RequestsPage(Owner owner)
        {
            InitializeComponent();
            currentOwner = owner;
            LVRequests.ItemsSource = DataAccess.GetRequestsForOwner(currentOwner.Id);
            DataContext = this;
        }

        private void BtnWatchRequest_Click(object sender, RoutedEventArgs e)
        {
            Request selectedRequest = LVRequests.SelectedItem as Request;
            if(selectedRequest != null)
            {
                NavigationService.Navigate(new ActivityPage(currentOwner, selectedRequest));
            }
            else
            {
                MessageBox.Show("Выберите заявку");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlacesPage(currentOwner.User));
        }
    }
}
