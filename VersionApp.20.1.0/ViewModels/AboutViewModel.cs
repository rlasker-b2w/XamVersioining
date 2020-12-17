using VersionApp.Common;
using VersionApp.Common.MVVM;

namespace VersionApp.v20_1_0.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public AboutViewModel(IServiceLocator locator) : base(locator) { }

        public string Title => "About 20.1.0";
    }
}
