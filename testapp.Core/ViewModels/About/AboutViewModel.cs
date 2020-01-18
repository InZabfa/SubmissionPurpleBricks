using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace testapp.Core.ViewModels.About
{
    public class AboutViewModel : BaseViewModel
    {
        //checks for when the button is pressed in the AboutPage.xaml
        public ICommand VisitWebsiteCommand { get; }

        public AboutViewModel()
        {
            //Opens the website once the button on the page is pressed
            VisitWebsiteCommand = new Command(() => Device.OpenUri(new Uri("http://www.purplebricks.com")));
        }
    }
}
