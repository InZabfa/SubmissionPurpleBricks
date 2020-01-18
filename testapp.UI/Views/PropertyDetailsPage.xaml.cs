using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using testapp.Core.ViewModels.Properties;
using Xamarin.Forms.Xaml;

namespace testapp.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = false)]
    public partial class PropertyDetailsPage : MvxContentPage<PropertyDetailsViewModel>
    {
        public PropertyDetailsPage()
        {
            InitializeComponent();
        }
    }
}
