using System;
using VersionApp.Common;
using VersionApp.Common.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VersionApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string v = ((Button)sender).CommandParameter.ToString();
            IAuthenticationService service = ServiceLocator.GetLocator().GetService<IAuthenticationService>();
                
            service.Login(new Version(v));
        }
    }
}