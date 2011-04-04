using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafikantenApp.ViewModels;

namespace TrafikantenAppTests
{
    [TestClass]
    public class GivenIWantToSearchForRealtimeStops
    {
        [TestMethod]
        public void VerifyRealtimeResponse()
        {
            bool itemChanged = false;

            ItemViewModel itemViewModel = new ItemViewModel();
            itemViewModel.PropertyChanged += (s, e) => itemChanged = true;
            itemViewModel.LineOne = "line1";
            itemViewModel.LineTwo = "line2";
            itemViewModel.LineThree = "line3";

            Assert.IsTrue(itemChanged);
        }

        [TestMethod]
        public void WhenSubmittingStopNameAndPerformingSearch_ShouldReturnListOfStops()
        {
           StopsViewModel stopsViewModel = new StopsViewModel(null);

            stopsViewModel.StopToFind = "Sinsen";
           
            Assert.IsTrue(stopsViewModel.ListOfStops != null);            
        }

        
        [TestMethod]
        public void WhenSubmittingStopNameAndPerformingSearch_ShouldFetchStopsFromService()
        {
            var realtimeService = new RealtimeServiceStub();
            StopsViewModel viewModel = new StopsViewModel(realtimeService);

            viewModel.StopToFind = "Sinsen";
            viewModel.FindStops();

            Assert.AreEqual("Sinsen Kirke", viewModel.ListOfStops.First().Name);
        }


    }
}
