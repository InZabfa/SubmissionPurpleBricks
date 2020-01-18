namespace testapp.Core.ViewModels.Menu
{
    public class MenuItemViewModel : BaseViewModel
    {
        private string _icon;
        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        private string _caption;
        public string Caption
        {
            get => _caption;
            set => SetProperty(ref _caption, value);
        }
    }
}
