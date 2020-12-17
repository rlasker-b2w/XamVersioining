using Xamarin.Forms;

namespace VersionApp.Common
{
    public class LocatableBase : BindableObject
    {
        public LocatableBase(IServiceLocator locator = null) => Locator = locator ?? Locator;

        public IServiceLocator Locator { get; set; } = ServiceLocator.GetLocator(); 
    }
}
