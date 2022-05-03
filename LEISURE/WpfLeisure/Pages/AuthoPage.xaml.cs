﻿using System;
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
                if(currentUser.ID_Role == 1)
                {
                    MessageBox.Show("Добро пожаловать");
                    // навигация на страницу мероприятий
                }
                else
                {
                    MessageBox.Show("Добро пожаловать");
                    // навигация на СВОИ объекты

                }
              
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}