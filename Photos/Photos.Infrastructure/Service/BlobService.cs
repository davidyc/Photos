using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Photos.Infrastructure.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Photos.Infrastructure.Service
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<BlobDownloadResult> GetBlobAsync(string name)
        {
            var client = _blobServiceClient.GetBlobContainerClient("photocontainer");
            var blobClient = client.GetBlobClient(name);
            var blob = await blobClient.DownloadContentAsync();
            return blob.Value;
        }
    }
}
