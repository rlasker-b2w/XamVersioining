using VersionApp.Common;

namespace VersionApp.v20_1_0.Interfaces
{
    public interface IVersionedService : IService
    {
        string OriginalServiceMessage { get; }
    }
}
