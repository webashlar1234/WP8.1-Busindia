using BusIndia_Universal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
//using WebServiceClassLiberary;
//using WebServiceClassLiberary.Model;
using Windows.ApplicationModel;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusSearchDepartureCity : Page
    {
        string parameter = string.Empty;
        TextBlock textBlock1;
        string prevText = "";
        bool LayoutUpdateFlag = true;
        string selecteditem { get; set; }
        List<PlaceList> CityList = new List<PlaceList>();

        public BusSearchDepartureCity()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;
            PlaceList m = new PlaceList();
            if (e.Parameter != null)
            {
                parameter = e.Parameter.ToString();
                if (parameter == "fromlocation" || parameter == "fromlocationsearchreturn")
                {
                    txtBTitle.Text = "Departure City";
                }
                if (parameter == "tolocation" || parameter == "tolocationsearchreturn")
                {
                    txtBTitle.Text = "Arrival City";
                }
                switch (parameter)
                {
                    case "fromlocation":
                        parameter = "fromlocation";
                        break;
                    case "tolocation":
                        parameter = "tolocation";
                        break;
                    case "fromlocationsearchreturn":
                        parameter = "fromlocationsearchreturn";
                        break;
                    case "tolocationsearchreturn":
                        parameter = "tolocationsearchreturn";
                        break;
                }
            }
            postXMLData1();

        }

        public async void postXMLData1()
        {
            try
            {
                //string uri = AppStatic.WebServiceBaseURL;  // some xml string
                //Uri _url = new Uri(uri, UriKind.RelativeOrAbsolute);
                //XMLManager listings = new XMLManager();
                //getPlaceListRequest _objgetPlaceListRequest = listings.GetUserRequestParameters();
                //XDocument element = listings.getList(_objgetPlaceListRequest);
                //string file = element.ToString();
                //var httpClient = new Windows.Web.Http.HttpClient();
                //var info = AppStatic.WebServiceAuthentication;
                //var token = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(info));
                //httpClient.DefaultRequestHeaders.Authorization = new Windows.Web.Http.Headers.HttpCredentialsHeaderValue("Basic", token);
                //httpClient.DefaultRequestHeaders.Add("SOAPAction", "");
                //Windows.Web.Http.HttpRequestMessage httpRequestMessage = new Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Post, _url);
                //httpRequestMessage.Headers.UserAgent.TryParseAdd("Mozilla/4.0");
                //IHttpContent content = new HttpStringContent(file, Windows.Storage.Streams.UnicodeEncoding.Utf8);
                //httpRequestMessage.Content = content;
                //Windows.Web.Http.HttpResponseMessage httpResponseMessage = await httpClient.SendRequestAsync(httpRequestMessage);
                //string strXmlReturned = await httpResponseMessage.Content.ReadAsStringAsync();
                StorageFile sampleFile = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("PlaceNames.xml");
                String timestamp = await FileIO.ReadTextAsync(sampleFile);
                XDocument loadedData = XDocument.Parse(timestamp);
                //XmlDocument xDoc = new XmlDocument();
                //xDoc.LoadXml(strXmlReturned);
                //XDocument loadedData = XDocument.Parse(strXmlReturned);
                var PlaceList = loadedData.Descendants("PlaceList").
                Select(x => new PlaceList
                {
                    PlaceID = x.Element("placeID").Value,
                    PlaceCode = x.Element("placeCode").Value,
                    PlaceName = x.Element("placeName").Value
                });
                foreach (var item in PlaceList)
                {
                    PlaceList pl = new PlaceList();
                    pl.PlaceID = item.PlaceID;
                    pl.PlaceName = item.PlaceName;
                    pl.PlaceCode = item.PlaceCode;
                    CityList.Add(pl);
                }
                ListMenuItems.ItemsSource = PlaceList;
                LoderPopup.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                PopupError.Visibility = Visibility.Visible;
                LoderPopup.Visibility = Visibility.Collapsed;
                ExceptionLog obj = new ExceptionLog();
                Error objError = new Error();
                objError.ErrorEx = ex.Message;
                obj.CreateLogFile(objError);
            }
        }

        private void SearchVisualTree(DependencyObject targetElement)
        {

            var count = VisualTreeHelper.GetChildrenCount(targetElement);//get count targeted dependecnyobject 

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(targetElement, i);//detecting listboxitem child items 
                if (child is TextBlock)
                {
                    textBlock1 = (TextBlock)child;
                    prevText = textBlock1.Text;
                    if ((textBlock1.Name == "PlaceName") && textBlock1.Text.ToUpper().Contains(txtSerchCity.Text.ToUpper()))
                    {
                        HighlightText();//after finding textblock child item call method for highligh color 
                    }
                }
                else
                {
                    SearchVisualTree(child);//repeat method call until targeted dependency found child items 
                }
            }
        }

        /**This method is for highlight the search text**/
        private void HighlightText()
        {
            if (textBlock1 != null)
            {
                string text = textBlock1.Text.ToUpper();
                textBlock1.Text = text;
                textBlock1.Inlines.Clear();

                int index = text.IndexOf(txtSerchCity.Text.ToUpper());//getting index of search text from listboxitem textblock 
                int lenth = txtSerchCity.Text.Length;

                if (!(index < 0))
                {

                    Run run = new Run() { Text = prevText.Substring(index, lenth) };
                    run.Foreground = new SolidColorBrush(Colors.Black);//format search text color with orange 
                    textBlock1.Inlines.Add(new Run() { Text = prevText.Substring(0, index) });
                    textBlock1.Inlines.Add(run);
                    textBlock1.Inlines.Add(new Run() { Text = prevText.Substring(index + lenth) });
                }
            }
        }

        private void imgClose_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(BusSearch));
        }


        private void txtSerchCity_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void ListMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ListMenuItems.SelectedItem != null)
            {

                PlaceList myobject = ListMenuItems.SelectedItem as PlaceList;

                myobject.Label = parameter;

                Frame.Navigate(typeof(BusSearch), myobject);
            }
        }
        private void ListMenuItems_LayoutUpdated(object sender, object e)
        {
            if (LayoutUpdateFlag)
            {
                SearchVisualTree(ListMenuItems);
            }
            LayoutUpdateFlag = false;
        }

        private void txtSerchCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ListMenuItems.ItemsSource = CityList.Where(w => w.PlaceName.ToLower().Contains(txtSerchCity.Text.ToLower()));
            LayoutUpdateFlag = true;
        }
    }

    public class PlaceList : INotifyPropertyChanged
    {
        string _placeCode;
        string _placeID;
        string _placeName;

        public string PlaceCode
        {
            get { return _placeCode; }
            set { _placeCode = value; }
        }

        public string PlaceID
        {
            get { return _placeID; }
            set { _placeID = value; }
        }

        public string PlaceName
        {
            get { return _placeName; }
            set
            {
                _placeName = value;
                OnPropertyChanged("PlaceName");
            }
        }

        private string _Label;

        public string Label
        {
            get { return _Label; }
            set
            {
                _Label = value;

            }
        }
        private string _Cityname;

        public string Cityname
        {
            get { return _Cityname; }
            set
            {
                _Cityname = value;
            }
        }


        private string _message;
        private string _statusCode;


        public string message
        {
            get { return _message; }
            set { _message = value; }
        }
        public string statusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (!String.IsNullOrEmpty(propertyName) && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
