using _037_Abstract_Factory_Pattern_DeepDive.StorageProviders.Interfaces;

namespace _037_Abstract_Factory_Pattern_DeepDive.StorageProviders.Clients
{
    public class AwsStorageClient : ICloudStorageClient
    {
        public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
        {
            // AWS S3 upload logic
            await Task.Delay(50); // Simulate async work
            return $"Uploaded {fileName} to AWS S3";
        }

        public async Task<Stream> DownloadFileAsync(string fileName)
        {
            // AWS S3 download logic
            await Task.Delay(50);
            return new MemoryStream();
        }
    }
}
