namespace _037_Abstract_Factory_Pattern_DeepDive.StorageProviders.Interfaces
{
    public interface IStorageFactory
    {
        ICloudStorageClient GetStorageClient(string provider);
    }
}
