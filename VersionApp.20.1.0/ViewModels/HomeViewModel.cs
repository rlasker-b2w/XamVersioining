using System;
using System.Windows.Input;
using VersionApp.Common;
using VersionApp.Common.Interfaces;
using VersionApp.Common.MVVM;
using VersionApp.v20_1_0.Interfaces;
using Xamarin.Forms;

namespace VersionApp.v20_1_0.ViewModels
{
    public class HomeViewModel : ViewModelBase, IViewModel
    {
        protected readonly Lazy<IGlobalService> globalService;
        protected readonly Lazy<IVersionedService> versionedService;
        readonly Lazy<IAuthenticationService> authenticationService;

        public HomeViewModel(IServiceLocator locator) : base(locator) 
        {
            globalService = new Lazy<IGlobalService>(() => Locator.GetService<IGlobalService>());
            versionedService = new Lazy<IVersionedService>(() => Locator.GetService<IVersionedService>());
            authenticationService = new Lazy<IAuthenticationService>(() => Locator.GetService<IAuthenticationService>());
            LogoutCommand = new Command(OnLogoutTapped);
        }

        private void OnLogoutTapped(object obj)
        {
            authenticationService.Value.Logout();
        }

        public ICommand LogoutCommand { get; set; }

        public string Title => "Home 20.1.0";

        public string GlobalMessage => globalService.Value.Message;

        public string OriginalMessage => versionedService.Value.OriginalServiceMessage;
    }
}
