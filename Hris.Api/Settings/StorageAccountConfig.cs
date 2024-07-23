using System.Runtime.CompilerServices;

namespace Hris.Api.Settings
{
    public class StorageAccountConfig
    {
        public string? Name { get; set; }
        public string? Key { get; set; }
        public string? ContainerName { get; set; }
    }
}
