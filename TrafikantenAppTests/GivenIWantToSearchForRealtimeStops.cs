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
            StopsViewViewModel  viewModel = new StopsViewViewModel(new RealtimeServiceStub());
            viewModel.PropertyChanged += (sender, ea) => itemChanged = true;
            viewModel.StopToFind = "test";
            Assert.IsTrue(itemChanged);
        }

        [TestMethod]
        public void WhenSubmittingStopNameAndPerformingSearch_ShouldReturnListOfStops()
        {
           StopsViewViewModel stopsViewViewModel = new StopsViewViewModel(new RealtimeServiceStub());

            stopsViewViewModel.StopToFind = "Sinsen";
           
            Assert.IsTrue(stopsViewViewModel.ListOfStops != null);            
        }

        
        [TestMethod]
        public void WhenSubmittingStopNameAndPerformingSearch_ShouldFetchStopsFromService()
        {
            var realtimeService = new RealtimeServiceStub();
            StopsViewViewModel viewModel = new StopsViewViewModel(realtimeService);

            viewModel.StopToFind = "Sinsen";
            viewModel.FindStops();

            Assert.AreEqual("Sinsen Kirke", viewModel.ListOfStops.First().Name);
        }


    }
}
