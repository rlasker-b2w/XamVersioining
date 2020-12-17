using VersionApp.Common;
using VersionApp.Common.MVVM;
using Xamarin.Forms.Xaml;

namespace VersionApp.v20_1_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutView : ViewBase
    {
        public AboutView(IServiceLocator locator) : base(locator)
        {
            InitializeComponent();
        }
    }
}