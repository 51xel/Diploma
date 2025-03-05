using Azure.Storage.Blobs;
using Diploma.Application.Models.Interfaces;
using Diploma.Dal.Storage.Common.Settings;
using Microsoft.Extensions.Options;

namespace Diploma.Dal.Storage.Models
{
    internal class ModelFileRepository : IModelFileRepository
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly StorageAccountSettings _storageAccountSettings;

        public ModelFileRepository(
            BlobServiceClient blobServiceClient, 
            IOptions<StorageAccountSettings> storageAccountSettings)
        {
            _blobServiceClient = blobServiceClient;
            _storageAccountSettings = storageAccountSettings.Value;
        }

        public async Task<MemoryStream?> GetAsync(string modelName, CancellationToken cancellationToken)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_storageAccountSettings.ModelsContainerName);
            var blobClient = blobContainerClient.GetBlobClient(modelName);

            if (!await blobClient.ExistsAsync(cancellationToken))
            {
                return null;
            }

            var contentFromStorage = await blobClient.DownloadStreamingAsync(cancellationToken: cancellationToken);

            var memoryStream = new MemoryStream();
            await contentFromStorage.Value.Content.CopyToAsync(memoryStream, cancellationToken);
            return memoryStream;
        }
    }
}
