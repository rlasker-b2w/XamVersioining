using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VersionApp.Common;
using VersionApp.Common.Interfaces;
using VersionApp.Services;
using Xamarin.Essentials;

namespace VersionApp
{
    public static class StartUp
    {
        static Action<HostBuilderContext, IServiceCollection> NativeConfigureServices;

        #region Methods

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            if (ctx.HostingEnvironment.IsDevelopment())
            {
                //load alternate configuration file
            }

            if(!string.IsNullOrWhiteSpace(VersionSelector.Version))
                RegisterVersionServices(services);
            RegisterServices(services);
        }

        static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IGlobalService, GlobalService>();
            services.AddSingleton<IServiceLocator, ServiceLocator>();
        }

        public static void RegisterVersionServices(IServiceCollection services)
        {
            Type startUpType = VersionSelector
                            .VersionAssembly
                            .GetType($"{ VersionSelector.VersionNameSpace }.StartUp");

            MethodInfo startUpMethod = startUpType
                .GetMethod("ConfigureServices");

            startUpMethod.Invoke(Activator.CreateInstance(startUpType), new object[] { services });
        }

        public static App Init(Action<HostBuilderContext, IServiceCollection> nativeConfigureServices)
        {
            NativeConfigureServices = nativeConfigureServices;
            InitServiceProvider(nativeConfigureServices, FileSystem.CacheDirectory);
            return new App(ServiceLocator.GetLocator());
        }

        public static void Reinit() =>
            InitServiceProvider(NativeConfigureServices, FileSystem.CacheDirectory);

        public static IServiceProvider InitServiceProvider(Action<HostBuilderContext, IServiceCollection> nativeConfigureServices, string systemDir)
        {
            IServiceProvider provider = new HostBuilder()
                .ConfigureHostConfiguration(c =>
                {
                    //Tell the configuration host where the root directory is
                    c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                })
                .ConfigureServices((c, x) =>
                {
                    nativeConfigureServices(c, x);
                    ConfigureServices(c, x);
                })
                .Build().Services;
            return ServiceLocator.SetProvider(provider);
        }

        #endregion
    }
}
