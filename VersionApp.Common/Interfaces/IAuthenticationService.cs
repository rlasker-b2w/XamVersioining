using System;

namespace VersionApp.Common.Interfaces
{
    public interface IAuthenticationService : IService
    {
        void Login(Version version);
        void Logout();
    }
}
