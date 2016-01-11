using NurseAgenda3.Model;
using NurseAgenda3.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace NurseAgenda3
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ListPatientItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((MainViewModel)DataContext).OnNavigateTo((Patient)e.ClickedItem);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).OnNavigateToDelete();
            Frame.Navigate(typeof(DeletePage));
        }

        private void AttributionButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AttributionPage));
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }
    }
}
