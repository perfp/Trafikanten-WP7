using System;
using Caliburn.Micro;

namespace TrafikantenApp.ViewModels
{
    public class MainPageViewModel
    {
        private INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Continue()
        {
            _navigationService.Navigate(new Uri("/StopsView.xaml", UriKind.RelativeOrAbsolute));
        }

    }
}
