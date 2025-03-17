namespace _037_Abstract_Factory_Pattern_DeepDive.StorageProviders.Interfaces
{
    public interface ICloudStorageClient
    {
        Task<string> UploadFileAsync(Stream fileStream, string fileName);
        Task<Stream> DownloadFileAsync(string fileName);
    }
}
