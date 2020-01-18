using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using testapp.Core.ViewModels.About;
using testapp.Core.ViewModels.Home;
using Xamarin.Forms;

namespace testapp.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public IMvxAsyncCommand<MenuItemViewModel> ShowDetailPageAsyncCommand { get; private set; }

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuItemList = new MvxObservableCollection<MenuItemViewModel>()
            {
                new MenuItemViewModel
                {
                    Icon = "Home",
                    Caption = "Home"
                },
                new MenuItemViewModel
                {
                    Icon = "Information",
                    Caption = "About"
                }
            };

            ShowDetailPageAsyncCommand = new MvxAsyncCommand<MenuItemViewModel>(ShowDetailPageAsync);
        }

        private async Task ShowDetailPageAsync(MenuItemViewModel menuItemViewModel)
        {
            if (menuItemViewModel == null) return;

            // Implement your logic here.
            switch (menuItemViewModel?.Caption)
            {
                case "Home":
                    await _navigationService.Navigate<HomeViewModel>();
                    break;
                case "About":
                    await _navigationService.Navigate<AboutViewModel>();
                    break;
                default:
                    break;
            }

            if (Device.RuntimePlatform == Device.Android)
                await Task.Delay(100);

            SelectedMenuItem = null;

            if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false;
            }
            else if (Application.Current.MainPage is NavigationPage navigationPage
                     && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
            {
                nestedMasterDetail.IsPresented = false;
            }
        }

        private ObservableCollection<MenuItemViewModel> _menuItemList;
        public ObservableCollection<MenuItemViewModel> MenuItemList
        {
            get => _menuItemList;
            set => SetProperty(ref _menuItemList, value);
        }

        private MenuItemViewModel _selectedMenuItem;
        public MenuItemViewModel SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => SetProperty(ref _selectedMenuItem, value);
        }
    }
}
