using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Photos.Domain.Blob;
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
            var blobClient = GetBlobClient($"{Guid.NewGuid()}_{fileName}");
            var blob = await blobClient.UploadAsync(stream);
            return blob;
        }

        public async Task<BlobContentInfo> UploadAsync(string fileName, string filPath)
        {
            var blobClient = GetBlobClient($"{Guid.NewGuid()}_{fileName}");
            var blob = await blobClient.UploadAsync(filPath);
            return blob;
        }

        public async Task<bool> DeleteFileAsync(string fileName)
        {
            var blobClient = GetBlobClient(fileName);
            var deleted = await blobClient.DeleteIfExistsAsync();
            return deleted;
        }

        public async Task<IEnumerable<string>> GetListFileNameAsync()
        {
            var fileNamesList = new List<string>();
            var client = _blobServiceClient.GetBlobContainerClient(_containerName);
            var allBlobs = client.GetBlobs().AsPages();
            foreach (var blob in allBlobs)
            {
                foreach (var file in blob.Values)
                {
                    fileNamesList.Add(file.Name);
                }
            }
            return fileNamesList;           
        }

        public async Task<IEnumerable<BlobDownloadModel>> GetAllFile()
        {
            var list = await GetListFileNameAsync();
            var resultList = new List<BlobDownloadModel>();
            foreach (var item in list)
            {
                var blobFile = await DownloadContentAsync(item);
                resultList.Add(new BlobDownloadModel { Name = item, BytesArray = blobFile.Content.ToArray() });
            }

           return resultList;
        }

        public async Task<BlobDownloadModel> GetFileByNameAsync(string fileName)
        {
            var blobFile = await DownloadContentAsync(fileName);
            return new BlobDownloadModel { Name = fileName , BytesArray = blobFile.Content.ToArray()};
        }

        private BlobClient GetBlobClient(string fileName)
        {
            var client = _blobServiceClient.GetBlobContainerClient(_containerName);
            return client.GetBlobClient(fileName);
        }
    }
}
