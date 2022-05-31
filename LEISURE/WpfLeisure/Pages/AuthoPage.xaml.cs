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

namespace WpfLeisure.Pages
{
    /// <summary>
    /// Interaction logic for AuthoPage.xaml
    /// </summary>
    public partial class AuthoPage : Page
    {
        private static User currentUser;
        public AuthoPage()
        {
            InitializeComponent();
            TBLogin.Text = Properties.Settings.Default.login;
        }

        private void BtnAuthorize_Click(object sender, RoutedEventArgs e)
        {
            if(DataAccess.IsCorrectUser(TBLogin.Text, TBPassword.Text))
            {
                currentUser = DataAccess.GetUser(TBLogin.Text, TBPassword.Text);
                if (CBRememberMe.IsChecked.GetValueOrDefault())
                    Properties.Settings.Default.login = TBLogin.Text;
                else
                    Properties.Settings.Default.login = null;
                Properties.Settings.Default.Save();
                MessageBox.Show("Добро пожаловать");
                if (DataAccess.CurrentUserIsClient(currentUser))
                    NavigationService.Navigate(new ActivitiesPage(currentUser));
                else
                    NavigationService.Navigate(new PlacesPage(currentUser));
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (TBlInvalidName.Text == "")
            {
                DataAccess.AddNewUser(TBLogin.Text, TBPassword.Text);
                DataAccess.AddNewClient(TBName.Text, TBLastName.Text);
                MessageBox.Show("Пользователь создан!");
            }

            else
                MessageBox.Show("Логин занят. Придумайте другой логин");
        }

        private void TBRegLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataAccess.LoginExists(TBRegLogin.Text))
                TBlInvalidName.Text = "Логин уже используется";
            else
                TBlInvalidName.Text = "";
        }
    }
}
