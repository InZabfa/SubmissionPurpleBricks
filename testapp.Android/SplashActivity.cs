using System.Threading.Tasks;
using Acr.UserDialogs;
using Android.App;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;

namespace testapp.Droid
{
    [Activity(
        NoHistory = true,
        MainLauncher = true,
        Label = "@string/app_name",
        Theme = "@style/AppTheme.Splash",
        Icon = "@mipmap/ic_launcher",
        RoundIcon = "@mipmap/ic_launcher_round")]
    public class SplashActivity : MvxFormsSplashScreenAppCompatActivity<Setup, Core.App, UI.App>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            UserDialogs.Init(this);
        }

        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(MainActivity));
            return Task.CompletedTask;
        }
    }
}
