using Microsoft.Extensions.DependencyInjection;
using VersionApp.v20_1_0.Pages;
using VersionApp.v20_1_0.ViewModels;
using VersionApp.v20_1_0.Views;
using VersionApp.Common;
using VersionApp.v20_1_0.Interfaces;
using VersionApp.v20_1_0.Services;

namespace VersionApp.v20_1_0
{
    public class StartUp : IStartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //About Page
            services.AddTransient<AboutPage>();
            services.AddTransient<AboutView>();
            services.AddTransient<AboutViewModel>();

            //Home Page
            services.AddTransient<HomePage>();
            services.AddTransient<HomeView>();
            services.AddTransient<HomeViewModel>();

            RegisterServices(services);

            services.AddSingleton<AppShell>();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            //Services
            services.AddTransient<IVersionedService, VersionedService>();
        }
    }
}
