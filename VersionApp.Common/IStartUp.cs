using Microsoft.Extensions.DependencyInjection;

namespace VersionApp.Common
{
    public interface IStartUp
    {
        void ConfigureServices(IServiceCollection services);
    }
}
