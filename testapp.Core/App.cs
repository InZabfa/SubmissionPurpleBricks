using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using testapp.Core.Services.LocationPrompt;
using testapp.Core.Services.Property;
using testapp.Core.Services.Search;
using testapp.Core.ViewModels.Root;

namespace testapp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<RootViewModel>();

            Mvx.IoCProvider.RegisterSingleton(UserDialogs.Instance);
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ILocationPromptService, LocationPromptService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ISearchService, SearchService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IPropertyDetailsService, PropertyDetailsService>();
        }
    }
}
