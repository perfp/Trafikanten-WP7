using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Caliburn.Micro;

namespace TrafikantenApp.ViewModels
{
    [SurviveTombstone]
    public class StopsViewViewModel : INotifyPropertyChanged
    {        
        private readonly IRealtimeStopsService realtimeStopsService;

        public StopsViewViewModel(IRealtimeStopsService realtimeStopsService)
        {
            ListOfStops = new ObservableCollection<Stop>();
            this.realtimeStopsService = realtimeStopsService;
            this.realtimeStopsService.StopsFound += StopsFound;
            StopToFind = "Skriv inn stoppested...";
        }

        private string stopToFind;
        public string StopToFind
        {
            get { return stopToFind; }
            set
            {
                stopToFind = value;
                FirePropertyChanged(x=>StopToFind);
            }
        }

        public ObservableCollection<Stop> ListOfStops { get; private set; }

        public void FindStops()
        {
            realtimeStopsService.FindStops(StopToFind);            
        }

        private void StopsFound(IList<Stop> stops)
        {
            ListOfStops.Clear();
            stops.ToList().ForEach(ListOfStops.Add);
        }

        private void FirePropertyChanged(string property)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        private void FirePropertyChanged(Func<object, string> func)
        {
            FirePropertyChanged(func.Method.Name);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
