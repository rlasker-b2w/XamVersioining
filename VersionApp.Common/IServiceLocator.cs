using System;
using VersionApp.Common.MVVM;

namespace VersionApp.Common
{
    public interface IServiceLocator
    {
        IServiceProvider Provider { get; }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <returns>The repository.</returns>
        /// <typeparam name="TRepository">The 1st type parameter.</typeparam>
        TRepository GetRepository<TRepository>() where TRepository : class, IRepository;

        /// <summary>
        /// Gets the service by service type.
        /// </summary>
        /// <returns>The service.</returns>
        /// <typeparam name="TService">The 1st type parameter.</typeparam>
        TService GetService<TService>() where TService : class, IService;

        TViewModel GetViewModel<TViewModel>() where TViewModel : ViewModelBase;

        //IViewModel GetViewModel(Type type);
    }
}
