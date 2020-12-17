namespace VersionApp.Common
{
    public class ServiceBase : LocatableBase, IService
    {
        public ServiceBase(IServiceLocator locator = null) : base(locator) { }
    }
}
