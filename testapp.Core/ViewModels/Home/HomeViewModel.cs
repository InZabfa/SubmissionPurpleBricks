using System;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using testapp.Core.Services.LocationPrompt;
using testapp.Core.ViewModels.Properties;

namespace testapp.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ILocationPromptService _locationPromptService;
        private readonly IMvxLog _log;
        private readonly IUserDialogs _useDialogs;

        public IMvxAsyncCommand SearchCommandAsync { get; private set; }

        public HomeViewModel (IMvxNavigationService navigationService, ILocationPromptService locationPromptService, IMvxLog log, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _locationPromptService = locationPromptService;
            _log = log;
            _useDialogs = userDialogs;

            SearchCommandAsync = new MvxAsyncCommand(SearchPropertiesAsync);
        }

        private async Task SearchPropertiesAsync()
        {
            if (string.IsNullOrWhiteSpace(Location))
            {
                await _useDialogs.AlertAsync("Please specify location");
                return;
            }

            try
            {
                IsBusy = true;

                var locationDetails = await _locationPromptService.GetLocationDetails(Location);

                if (locationDetails.Any() == false)
                {
                    await _useDialogs.AlertAsync("No results found. Please try a different location");
                    return;
                }

                await _navigationService.Navigate<PropertiesViewModel, LocationPromptResult>(locationDetails.First());
            }
            catch (Exception exc)
            {
                _log.ErrorException("An error has occurred while trying to get location prompt details", exc);
                await _useDialogs.AlertAsync("An error has occurred. Please try again.");
            }
            finally
            {
                IsBusy = false;
            }


        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private string _location;
        public string Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }
    }
}
