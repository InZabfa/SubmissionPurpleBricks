using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using testapp.Core.Services.LocationPrompt;
using testapp.Core.ViewModels.Properties;
using Xamarin.Forms;

namespace testapp.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ILocationPromptService _locationPromptService;
        private readonly IMvxLog _log;
        private readonly IUserDialogs _useDialogs;

        public IMvxAsyncCommand SearchCommandAsync { get; private set; }

        public HomeViewModel(IMvxNavigationService navigationService, ILocationPromptService locationPromptService, IMvxLog log, IUserDialogs userDialogs)
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


                bool toLet = PickerSelectedIndex == 1;

                var parameters = new Tuple<LocationPromptResult, bool>(locationDetails.First(), toLet);
                await _navigationService.Navigate<PropertiesViewModel, Tuple<LocationPromptResult, bool>>(parameters);
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

        private int _pickerSelectedIndex;
        public int PickerSelectedIndex
        {
            get => _pickerSelectedIndex;
            set => SetProperty(ref _pickerSelectedIndex, value);
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
