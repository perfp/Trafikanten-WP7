using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Caliburn.Micro;

namespace TrafikantenApp.ViewModels
{
    public class StopsViewViewModel : ViewModelBase 
    {        
        private readonly IRealtimeStopsService realtimeStopsService;
        private readonly INavigationService navigationService;

        public StopsViewViewModel(IRealtimeStopsService realtimeStopsService, INavigationService navigationService)
        {
            ListOfStops = new ObservableCollection<Stop>();
            this.realtimeStopsService = realtimeStopsService;
            this.realtimeStopsService.StopsFound += StopsFound;
            StopToFind = "";
            this.navigationService = navigationService;
        }

        private string stopToFind;
        public string StopToFind
        {
            get { return stopToFind; }
            set
            {
                stopToFind = value;
                FirePropertyChanged(()=>StopToFind);
            }
        }

        public ObservableCollection<Stop> ListOfStops { get; private set; }

        public void FindStops()
        {
            Debug.WriteLine("Find stops...");
            realtimeStopsService.FindStops(StopToFind); 
           
        }

        private void StopsFound(IList<Stop> stops)
        {
            ListOfStops.Clear();
            stops.ToList().ForEach(ListOfStops.Add);
        }

        public Stop SelectedStop { get; set; }
        public void StopSelected()
        {
            if (SelectedStop != null)
            {
                navigationService.Navigate(new Uri("/RealtimeResultsView.xaml?StopID=" + SelectedStop.ID + "&StopName=" + SelectedStop.Name,
                                                   UriKind.RelativeOrAbsolute));
            }
        }

      
    }
}
