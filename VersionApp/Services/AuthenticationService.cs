using System;
using VersionApp.Common;
using VersionApp.Common.Interfaces;
using Xamarin.Forms;

namespace VersionApp.Services
{
    public class AuthenticationService : ServiceBase, IAuthenticationService
    {
        public AuthenticationService(IServiceLocator locator) : base(locator) { }

        public void Login(Version version) => MessagingCenter.Send<IAuthenticationService, Version>(this, App.AUTH_LOGIN, version);

        public void Logout() => MessagingCenter.Send<IAuthenticationService>(this, App.AUTH_LOGOUT);
    }
}
