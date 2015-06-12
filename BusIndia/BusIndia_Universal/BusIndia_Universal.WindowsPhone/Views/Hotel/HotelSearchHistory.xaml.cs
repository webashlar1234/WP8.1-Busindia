﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HotelSearchHistory : Page
    {
        public HotelSearchHistory()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        /// 
      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void imgClose_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(HotelSearchPage));
        }

        private void btnClearAll_Tapped(object sender, TappedRoutedEventArgs e)
        {
            gridSearchHistory.Visibility = Visibility.Collapsed;
            Frame.Navigate(typeof(BusSearch));
        }

        private void imgNextArrow_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void ListMenuItems_LayoutUpdated(object sender, object e)
        {

        }

        private void ListMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void gridSearchHistory_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(HotelAvailibility));
        }
    }
}
