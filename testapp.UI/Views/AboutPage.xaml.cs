using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using testapp.Core.ViewModels.About;
using Xamarin.Forms.Xaml;

namespace testapp.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true)]
    public partial class AboutPage : MvxContentPage<AboutViewModel>
    {
        public AboutPage()
        {
            InitializeComponent();
        }
    }
}