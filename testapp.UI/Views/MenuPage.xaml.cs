using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using testapp.Core.ViewModels.Menu;
using Xamarin.Forms.Xaml;

namespace testapp.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Master, WrapInNavigationPage = false, Title = "NavigationMenu")]
    public partial class MenuPage : MvxContentPage<MenuViewModel>
    {
        public MenuPage()
        {
            InitializeComponent();
        }
    }
}
