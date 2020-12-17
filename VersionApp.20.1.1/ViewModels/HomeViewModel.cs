using System;
using VersionApp.Common;
using VersionApp.Common.MVVM;
using VersionApp.v20_1_1.Interfaces;

namespace VersionApp.v20_1_1.ViewModels
{
    public class HomeViewModel : v20_1_0.ViewModels.HomeViewModel, IViewModel
    {
        new readonly Lazy<IVersionedService> versionedService;

        public HomeViewModel(IServiceLocator locator) : base(locator)
        {
            versionedService = new Lazy<IVersionedService>(() => Locator.GetService<IVersionedService>());
        }

        public new string Title => "Home 20.1.1";

        public string NewMessage => versionedService.Value.NewAddedMessage;
    }
}
