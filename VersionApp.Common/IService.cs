namespace VersionApp.Common
{
    public interface IService
    {
        /// <summary>
        /// Gets or sets the service locator.
        /// </summary>
        /// <value>The service locator.</value>
        IServiceLocator Locator { get; set; }
    }
}
