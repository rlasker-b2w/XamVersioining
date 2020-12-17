using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace VersionApp.Common.MVVM
{
    public class PageBase : ContentPage
    {
        public PageBase(string title) : base()
        {
            Title = title;
            LoadContentView();
            On<iOS>().SetUseSafeArea(true);
        }

        public void LoadContentView()
        {
            Type pageType = GetType();
            string typeName = $"{ pageType.Assembly.GetName().Name }.Views.{ pageType.Name.Replace("Page", "View") }";
            Type viewType = pageType.Assembly.GetType(typeName);
            ContentView view = ServiceLocator
                .GetProvider()
                .GetService(viewType) as ContentView;
            Content = view;
        }
    }
}