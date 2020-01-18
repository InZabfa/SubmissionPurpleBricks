using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using testapp.Core.Services.Property;

namespace testapp.Core.ViewModels.Properties
{
    public class PropertyDetailsViewModel : BaseViewModel<int>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IPropertyDetailsService _propertyDetailsService;
        private readonly IMvxLog _log;
        private readonly IUserDialogs _useDialogs;

        private int _propertyId;
        private bool _isInitialised;
        private PropertyDetailsResult _propertyDetails;

        public PropertyDetailsViewModel(IMvxNavigationService navigationService, IPropertyDetailsService propertyDetailsService, IMvxLog log, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _propertyDetailsService = propertyDetailsService;
            _log = log;
            _useDialogs = userDialogs;
        }

        public override void Prepare(int parameter)
        {
            _propertyId = parameter;
        }

        public async override void ViewAppearing()
        {
            base.ViewAppearing();

            if (_isInitialised) return;

            try
            {
                IsBusy = true;

                await Task.Delay(500);
                _propertyDetails = await _propertyDetailsService.FetchPropertyDetails(_propertyId);

                _isInitialised = true;

            }
            catch (Exception exc)
            {
                _log.ErrorException("An error has occurred while trying to fetch property details", exc);
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
    }
}
