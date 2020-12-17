using VersionApp.Common;
using VersionApp.v20_1_0.Interfaces;

namespace VersionApp.v20_1_0.Services
{
    public class VersionedService : ServiceBase, IVersionedService
    {
        public string OriginalServiceMessage => "Original message from v20.1.0";
    }
}
