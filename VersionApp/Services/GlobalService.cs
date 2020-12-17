using VersionApp.Common;
using VersionApp.Common.Interfaces;

namespace VersionApp.Services
{
    public class GlobalService : ServiceBase, IGlobalService
    {
        public GlobalService(IServiceLocator locator) : base(locator) { }

        public string Message => "Message from the global service";
    }
}
