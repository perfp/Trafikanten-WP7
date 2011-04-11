using System.ComponentModel;
using System.Diagnostics;
using Caliburn.Micro;

namespace TrafikantenApp.ViewModels
{
    public class RealtimeResultsViewModel : ViewModelBase {
        
        public RealtimeResultsViewModel()
        {
            Debug.WriteLine("ViewModel resolved...");        
        }

        private string stopId = "#¤%";
        

        public string StopID
        {
            get { return stopId; }
            set { 
                stopId = value;
                FirePropertyChanged(()=>StopID);
            }
        }

        public string PageTitle
        {
            get { return "test"; }
        }
    }
}
