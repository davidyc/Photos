using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Photos.Infrastructure.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Photos.Infrastructure.Service
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "photocontainer";

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<BlobDownloadResult> DownloadContentAsync(string fileName)
        {
            var blobClient = GetBlobClient(fileName);
            var blob = await blobClient.DownloadContentAsync();
            return blob;
        }

        public async Task<BlobContentInfo> UploadAsync(string fileName, Stream stream)
        {   
            var blobClient = GetBlobClient(fileName);
            var blob = await blobClient.UploadAsync(stream);
            return blob;
        }

        public async Task<BlobContentInfo> UploadAsync(string fileName, string filPath)
        {
            var blobClient = GetBlobClient(fileName);
            var blob = await blobClient.UploadAsync(filPath);
            return blob;
        }

        private BlobClient GetBlobClient(string fileName)
        {
            var client = _blobServiceClient.GetBlobContainerClient(_containerName);
            return client.GetBlobClient(fileName);
        }
    }
}
