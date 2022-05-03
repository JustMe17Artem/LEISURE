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

namespace WpfLeisure.Pages
{
    /// <summary>
    /// Interaction logic for RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void TBLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataAccess.LoginExists(TBLogin.Text))
                TBlInvalidName.Text = "Логин уже используется";
            else
                TBlInvalidName.Text = "";
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (TBlInvalidName.Text == "")
            {
                DataAccess.AddNewUser(TBLogin.Text, TBPassword.Text);
                DataAccess.AddNewClient(TBName.Text, TBLastName.Text);
                MessageBox.Show("user added");
            }
               
            else
                MessageBox.Show("Invalid user name");
        }
    }
}
