using Azure.Storage.Blobs.Models;
using Photos.Domain.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Photos.Infrastructure.Service.Interface
{
    public interface IBlobService
    {
        Task<BlobDownloadResult> DownloadContentAsync(string name);
        Task<BlobContentInfo> UploadAsync(string fileName, Stream stream);
        Task<BlobContentInfo> UploadAsync(string fileName, string filPath);
        Task<IEnumerable<BlobDownloadModel>> GetAllFile();
        Task<IEnumerable<string>> GetListFileNameAsync();
        Task<bool> DeleteFileAsync(string fileName);
        Task<BlobDownloadModel> GetFileByNameAsync(string fileName);
    }
}
