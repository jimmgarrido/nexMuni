﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace nexMuni
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!NearbyModel.IsDataLoaded)
            {
                
                NearbyModel.LoadData();
                nearbyListView.ItemsSource = NearbyModel.nearbyStops;
                favoritesListView.ItemsSource = NearbyModel.favoritesStops;
            }

            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void UpdateButton(object sender, RoutedEventArgs e)
        {
            //if (NearbyModel.nearbyStops != null) 
            NearbyModel.nearbyStops.Clear();

            LocationHelper.UpdateNearbyList();
        }

        private void StopClicked(object sender, ItemClickEventArgs e)
        {
            StopData selected = e.ClickedItem as StopData;
            this.Frame.Navigate(typeof(StopDetail), e.ClickedItem);
        }
    }
}