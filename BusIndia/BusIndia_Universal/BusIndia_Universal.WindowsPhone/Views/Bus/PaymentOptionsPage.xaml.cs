using BusIndia_Universal.Views.Payment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PaymentOptionsPage : Page
    {
        public PaymentOptionsPage()
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
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;
            switch (PageNavigationMode.Mode)
            {
                case "Top":
                    {
                        Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Top } };
                        break;
                    }
                case "Bottom":
                    {
                        Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Bottom } };
                        break;
                    }
                case "Left":
                    {
                        Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Left } };
                        break;
                    }
                case "Right":
                    {
                        Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Right } };
                        break;
                    }
                default:
                    {
                        Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Top } };
                        break;
                    }
            }
        }

        private void btnPayuOption_Click(object sender, RoutedEventArgs e)
        {
            //PageNavigationMode.Mode = PageTransmission.Bottom;
            //this.Frame.Navigate(typeof(BusConfirmation));
        }

        private void btnMobikwik_Click(object sender, RoutedEventArgs e)
        {
            //PageNavigationMode.Mode = PageTransmission.Bottom;
            //this.Frame.Navigate(typeof(CreditCardDetails));
          
        }

        private void BillDesk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void imgClose_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Left;
            this.Frame.Navigate(typeof(BusBookingSummary));
        }
             

        private async void chkMail_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
            //Windows.ApplicationModel.Email.EmailMessage mail = new Windows.ApplicationModel.Email.EmailMessage();
            //mail.Subject = "This is Subject";
            //mail.Body = "This is body of demo mail";
            //mail.To.Add(new Windows.ApplicationModel.Email.EmailRecipient("webashlar.developers@gmail.com", "shaomeng"));
            //await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(mail);
           // await Launcher.LaunchUriAsync(new Uri("mailto:webashlar.developers@gmail.com?subject=SomeSubject&body=mail content"));
        }

        private void btnMobikwikOption_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //PageNavigationMode.Mode = PageTransmission.Bottom;
            //this.Frame.Navigate(typeof(CreditCardDetails));
        }

        private void btnPayuOption_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void btnBilDiskOption_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
