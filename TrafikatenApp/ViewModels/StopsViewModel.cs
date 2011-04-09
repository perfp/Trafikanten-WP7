using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TrafikantenApp.ViewModels
{
    public class StopsViewModel : INotifyPropertyChanged 
    {
        private IRealtimeStopsService _realtimeStopsService;
        public StopsViewModel(IRealtimeStopsService realtimeStopsService)
        {
            ListOfStops = new ObservableCollection<Stop>();
            _realtimeStopsService = realtimeStopsService;
        }

        public string StopToFind { get; set; }

        public ObservableCollection<Stop> ListOfStops { get; private set; }

        public void FindStops()
        {
            _realtimeStopsService.StopsFound += StopsFound;

            _realtimeStopsService.FindStops(StopToFind);
            
        }

        private void StopsFound(ObservableCollection<Stop> stops)
        {
            ListOfStops = stops;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
