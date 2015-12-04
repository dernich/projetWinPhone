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
    public sealed partial class AttributionPage : Page
    {
        public AttributionPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ListPatientItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(InformationPage));
        }

        private void FeuilleRouteButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DeletePage));
        }

        private void AttributionButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AttributionPage));
        }
    }
}
