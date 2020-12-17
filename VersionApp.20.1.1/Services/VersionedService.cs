using System;
using VersionApp.v20_1_1.Interfaces;

namespace VersionApp.v20_1_1.Services
{
    public class VersionedService : v20_1_0.Services.VersionedService, IVersionedService
    {
        public string NewAddedMessage => "New message in v20.1.1";
    }
}
