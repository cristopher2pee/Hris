using Hris.Api.Security;
using Hris.Business.Config;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Hris.Api.Settings
{
    public static class ApplicationSettings
    {
        public static UserClaims? UserClaims { get; set; } = new UserClaims();
        public static SecurityConfig SecurityConfig { get; set; } = new SecurityConfig();

        public static StorageAccountConfig StorageAccountConfig { get; set; } = new StorageAccountConfig();

        public static AzureAdConfig AzureAdConfig { get; set; }=new AzureAdConfig();


        internal static CloudBlobContainer CreateBlobContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse($"DefaultEndpointsProtocol=https;AccountName={StorageAccountConfig.Name};AccountKey={StorageAccountConfig.Key}");
            var blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(StorageAccountConfig.ContainerName);
        }
    }
}
