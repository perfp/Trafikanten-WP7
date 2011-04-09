using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using Microsoft.Phone.Controls;
using TrafikantenApp.ViewModels;

namespace TrafikantenApp
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

           
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

      

        private void Stoppested_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Stoppested.Text == "Navn på stoppested...") Stoppested.Text = "";
        }

        private void Stoppested_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void Stoppested_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Focus();
               App.ViewModel.FindStops();
            }
            
        }
    }
}