using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using testapp.Core.Services.LocationPrompt;
using testapp.Core.Services.Search;

namespace testapp.Core.ViewModels.Properties
{
    public class PropertiesViewModel : BaseViewModel<Tuple<LocationPromptResult, bool>>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ISearchService _searchService;
        private readonly IMvxLog _log;
        private readonly IUserDialogs _useDialogs;
        private LocationPromptResult _locationPrompt;

        private bool _isInitialised;
        private int _currentPage;
        private bool _hasNextPage;
        private int _total;
        private bool _toLet;

        public IMvxAsyncCommand<SearchPropertyResult> ShowPropertyDetailsAsyncCommand { get; private set; }
        public IMvxAsyncCommand<SearchPropertyResult> LoadMorePropertiesAsyncCommand { get; private set; }
        public IMvxAsyncCommand RefreshPropertiesAsyncCommand { get; private set; }

        public PropertiesViewModel(IMvxNavigationService navigationService, ISearchService searchService, IMvxLog log, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _searchService = searchService;
            _log = log;
            _useDialogs = userDialogs;

            ShowPropertyDetailsAsyncCommand = new MvxAsyncCommand<SearchPropertyResult>(ShowPropertyDetailsAsync);
            LoadMorePropertiesAsyncCommand = new MvxAsyncCommand<SearchPropertyResult>(LoadMorePropertiesAsync);
            RefreshPropertiesAsyncCommand = new MvxAsyncCommand(RefreshPropertiesAsync);
        }

        private async Task RefreshPropertiesAsync()
        {
            try
            {
                IsBusy = true;
                var result = await _searchService.FindProperties(_locationPrompt, _toLet);
                _currentPage = result.MetaData.PageNumber;
                _hasNextPage = result.MetaData.HasNextPage;
                _total = result.MetaData.TotalItemCount;

                PropertiesList.Clear();
                foreach (var property in result.Properties)
                {
                    PropertiesList.Add(property);
                }

                UpdateDisplyingDescription();

                if (_isInitialised == false)
                {
                    _isInitialised = true;
                }

            }
            catch (Exception exc)
            {
                _log.ErrorException("An error has occurred while trying to get search results", exc);
                await _useDialogs.AlertAsync("An error has occurred. Please try again.");

            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoadMorePropertiesAsync(SearchPropertyResult searchPropertyResult)
        {
            if (searchPropertyResult == null) return;

            if (PropertiesList[PropertiesList.Count - 1] == searchPropertyResult)
            {
                //Load more properties if any
            }
        }

        private async Task ShowPropertyDetailsAsync(SearchPropertyResult searchPropertyResult)
        {
            if (searchPropertyResult == null) return;
            await _navigationService.Navigate<PropertyDetailsViewModel, int>(searchPropertyResult.Id);

            SelectedProperty = null;
        }

        private void UpdateDisplyingDescription()
        {
            if (PropertiesList.Any())
            {
                DisplayingDescription = $"Showing {PropertiesList.Count} of {_total} results";
            }
            else
            {
                DisplayingDescription = "No results found";
            }
        }

        public async override void ViewAppearing()
        {
            base.ViewAppearing();

            if (_isInitialised == false)
            {
                await RefreshPropertiesAsync();
            }
        }

        public override void Prepare(Tuple<LocationPromptResult, bool> parameter)
        {
            _locationPrompt = parameter.Item1;

            _toLet = parameter.Item2;

            PropertiesList = new ObservableCollection<SearchPropertyResult>();
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private ObservableCollection<SearchPropertyResult> _propertiesList;
        public ObservableCollection<SearchPropertyResult> PropertiesList
        {
            get => _propertiesList;
            set => SetProperty(ref _propertiesList, value);
        }

        private SearchPropertyResult _selectedProperty;
        public SearchPropertyResult SelectedProperty
        {
            get => _selectedProperty;
            set => SetProperty(ref _selectedProperty, value);
        }

        private string _displayingDescription;
        public string DisplayingDescription
        {
            get => _displayingDescription;
            set => SetProperty(ref _displayingDescription, value);
        }
    }
}