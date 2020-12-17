using System;
using System.IO;
using System.Linq;
using System.Reflection;
using VersionApp.Common;
using VersionApp.Common.Interfaces;
using Xamarin.Forms;
using VersionApp.Pages;

namespace VersionApp
{
    public partial class App : Application
    {
        public const string AUTH_LOGOUT = "AUTH_LOGOUT";
        public const string AUTH_LOGIN = "AUTH_LOGIN";

        public IServiceLocator Locator { get; set; }

        public App(IServiceLocator locator)
        {
            Locator = locator;

            InitializeComponent();

            //string[] assemblies = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.GetFiles().Where(f => f.Name.Contains("VersionApp")).Select(f => f.Name).ToArray();

            SetMainToLoginPage();
        }

        static Page LoadAppShell() =>
            ServiceLocator
                .GetProvider()
                .GetService(VersionSelector.VersionAssembly.GetType($"{ VersionSelector.VersionNameSpace }.AppShell"))
                as Page;

        /// <summary>
        /// The method is called on the application start.
        /// </summary>
        protected override void OnStart()
        {
            SubscribeToMessages();
        }

        /// <summary>
        /// The method is called on the application starts to sleep.
        /// </summary>
        protected override void OnSleep()
        {
            UnsubscribeFromMessages();
        }

        /// <summary>
        /// The method is called on the application is resumed.
        /// </summary>
        protected override void OnResume()
        {
            SubscribeToMessages();
        }

        /// <summary>
        /// Sets the main page to login page.
        /// </summary>
        static void SetMainToLoginPage()
        {
            Current.MainPage = new LoginPage();
        }

        /// <summary>
        /// Sets the main page to main page.
        /// </summary>
        static void SetMainToMainPage(Version version)
        {
            VersionSelector.SetVersion(version);
            StartUp.Reinit();
            Current.MainPage = LoadAppShell();
        }

        /// <summary>
        /// Subscribes the application to receive messages.
        /// </summary>
        void SubscribeToMessages()
        {
            MessagingCenter.Subscribe<IAuthenticationService, Version>(this, AUTH_LOGIN,  (arg, v) => Device.BeginInvokeOnMainThread(() => SetMainToMainPage(v)));
            MessagingCenter.Subscribe<IAuthenticationService>(this, AUTH_LOGOUT, (arg) => Device.BeginInvokeOnMainThread(SetMainToLoginPage));
        }

        /// <summary>
        /// Unsubscribes the application from receiving messages.
        /// </summary>
        void UnsubscribeFromMessages()
        {
            MessagingCenter.Unsubscribe<IAuthenticationService>(this, AUTH_LOGIN);
            MessagingCenter.Unsubscribe<IAuthenticationService>(this, AUTH_LOGOUT);
        }
    }
}
