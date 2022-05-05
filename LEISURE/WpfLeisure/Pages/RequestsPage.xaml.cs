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

        private void LVRequests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnWatchRequest_Click(object sender, RoutedEventArgs e)
        {
            var selectedRequest = LVRequests.SelectedItem as Request;
            NavigationService.Navigate(new ActivityPage(currentOwner, selectedRequest));
        }
    }
}
