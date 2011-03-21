using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using Microsoft.Phone.Controls;
using WindowsPhonePivotApplication1.ViewModels;

namespace WindowsPhonePivotApplication1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            Loaded += MainPage_Loaded;

            // Silverlight UT Runner
            //const bool runUnitTests = false;

            //if (runUnitTests)
            //{
            //    Content = UnitTestSystem.CreateTestPage();
            //    IMobileTestPage imtp = Content as IMobileTestPage;

            //    if (imtp != null)
            //    {
            //        BackKeyPress += (x, xe) => xe.Cancel = imtp.NavigateBack();
            //    }
            //}
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void RetrieveStops()
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += StopReceived;
            client.DownloadStringAsync(new Uri("http://reis.trafikanten.no/siri/checkrealtimestop.aspx?name=" + Stoppested.Text));
        }

        void StopReceived(object sender, DownloadStringCompletedEventArgs e)
        {
            var items = App.ViewModel.Items;
            items.Clear();

            var result = XElement.Parse(e.Result);

            var stops = from stop in result.Descendants("Place")
                        select
                            new ItemViewModel {LineOne = stop.Element("Name").Value, LineTwo = stop.Element("ID").Value};
            foreach (var stop in stops)
            {
                items.Add(stop);
            }
            

        }

        private void Stoppested_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Stoppested.Text == "Navn på stoppested...") Stoppested.Text = "";
        }

        private void Stoppested_LostFocus(object sender, RoutedEventArgs e)
        {
            RetrieveStops();
        }

        private void Stoppested_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Focus();
                RetrieveStops();
            }
            
        }
    }
}