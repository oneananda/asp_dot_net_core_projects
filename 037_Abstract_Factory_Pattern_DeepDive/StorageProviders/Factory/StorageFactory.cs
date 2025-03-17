using _037_Abstract_Factory_Pattern_DeepDive.StorageProviders.Clients;
using _037_Abstract_Factory_Pattern_DeepDive.StorageProviders.Interfaces;

namespace _037_Abstract_Factory_Pattern_DeepDive.StorageProviders.Factory
{
    public class StorageFactory : IStorageFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public StorageFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICloudStorageClient GetStorageClient(string provider)
        {
            return provider.ToLower() switch
            {
                "aws" => _serviceProvider.GetService<AwsStorageClient>(),
                //"azure" => _serviceProvider.GetService<AzureStorageClient>(),
                //"gcp" => _serviceProvider.GetService<GoogleCloudStorageClient>(),
                _ => throw new NotSupportedException($"Storage provider '{provider}' is not supported.")
            };
        }
    }
}
