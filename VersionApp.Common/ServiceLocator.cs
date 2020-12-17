using System;
using VersionApp.Common.MVVM;

namespace VersionApp.Common
{
    public class ServiceLocator : IServiceLocator
    {
        #region Members

        static IServiceProvider _serviceProvider;

        #endregion

        #region Properties

        public IServiceProvider Provider => _serviceProvider;

        #endregion

        #region Methods

        /// <summary>
        /// Returns the static instance of the ServiceLocator
        /// </summary>
        /// <returns>Service Locator.</returns>
        public static IServiceLocator GetLocator() => new ServiceLocator();

        /// <summary>
        /// Returns the static instance of the Service Provider
        /// </summary>
        /// <returns>Service Provider.</returns>
        public static IServiceProvider GetProvider() => _serviceProvider;

        /// <summary>
        /// Gets the repository by the repository type.
        /// </summary>
        /// <returns>The requested repository.</returns>
        /// <typeparam name="TRepository">The requested repository type.</typeparam>
        public TRepository GetRepository<TRepository>() where TRepository : class, IRepository
            => Provider.GetService(typeof(TRepository)) as TRepository;

        /// <summary>
        /// By providing the interface type the ServiceLocator will attempt to lazily instantiate it if it is currently registered.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns>A service of type IService</returns>
        public TService GetService<TService>() where TService : class, IService
            => Provider.GetService(typeof(TService)) as TService;

        public TViewModel GetViewModel<TViewModel>() where TViewModel : ViewModelBase
            => Provider.GetService(typeof(TViewModel)) as TViewModel;

        public IViewModel GetViewModel(Type type) 
            => Provider.GetService(type) as IViewModel;

        public static IServiceProvider SetProvider(IServiceProvider provider) => _serviceProvider = provider;
        
        #endregion
    }
}
