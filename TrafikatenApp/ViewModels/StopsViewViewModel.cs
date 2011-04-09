using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Caliburn.Micro;

namespace TrafikantenApp.ViewModels
{
    public class StopsViewViewModel : INotifyPropertyChanged 
    {
        private INavigationService _navigationService;
        private IRealtimeStopsService _realtimeStopsService;
        public StopsViewViewModel(IRealtimeStopsService realtimeStopsService)
        {
            ListOfStops = new ObservableCollection<Stop>();
            _realtimeStopsService = realtimeStopsService;
            _realtimeStopsService.StopsFound += StopsFound;
            StopToFind = "Skriv inn stoppested...";
        }

        public string StopToFind { get; set; }

        public ObservableCollection<Stop> ListOfStops { get; private set; }

        public void FindStops()
        {
            _realtimeStopsService.FindStops(StopToFind);            
        }

        private void StopsFound(IList<Stop> stops)
        {
            ListOfStops.Clear();
            stops.ToList().ForEach(ListOfStops.Add);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
