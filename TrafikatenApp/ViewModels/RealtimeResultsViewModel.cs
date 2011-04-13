using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Caliburn.Micro;
using TrafikantenApp.Model;

namespace TrafikantenApp.ViewModels
{
    public class RealtimeResultsViewModel : ViewModelBase, IActivate  {
        private IRealtimeStopVisitsService visitsService;
        private ObservableCollection<StopVisit> stopVisits = new ObservableCollection<StopVisit>();

        public RealtimeResultsViewModel(IRealtimeStopVisitsService visitsService)
        {
            this.visitsService = visitsService;               
        }

        private string stopId;
        public string StopID
        {
            get { return stopId; }
            set { 
                stopId = value;
                FirePropertyChanged(()=>StopID);
            }
        }

        private string stopName;
        public string StopName
        {
            get { return stopName; }
            set { 
                stopName = value; 
                FirePropertyChanged(()=>StopName);
            }
        }

        
        public ObservableCollection<StopVisit> StopVisits
        {
            get { return stopVisits; }
            set { stopVisits = value; }
        }

        private bool isActive;
        public void Activate()
        {
            visitsService.VisitsFound += VisitsFound;
            visitsService.GetRealtimeVisitsForStop(new Stop{ID=StopID});
            if (Activated != null) Activated(this, new ActivationEventArgs());
            isActive = true;
        }

        private void VisitsFound(IEnumerable<StopVisit> visits)
        {
            stopVisits.Clear();
            foreach (var stopVisit in visits)
            {
                stopVisits.Add(stopVisit);
            }
        }

        public bool IsActive
        {
            get { return isActive; }
        }

        public event EventHandler<ActivationEventArgs> Activated;
    }
}
