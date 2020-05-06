using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Service
{
    public class Blob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }
        public Blob(IConfiguration configuration)
        {
            var storageCred = new StorageCredentials(configuration["Storage-Account-Name"], configuration["Blob-Key"]);
            CloudStorageAccount = new CloudStorageAccount(storageCred, true);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();

        }
        public async Task<CloudBlobContainer> GetContainer(string ContainerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(ContainerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            return cbc;
        }
        public async Task<CloudBlob> GetBlob(string imageName, string ContainerName)
        {

            var Container = await GetContainer(ContainerName);
            CloudBlob blob = Container.GetBlobReference(imageName);
            return blob;
        }
        public async Task UploadFile(string containerName, string fileName, IFormFile filePath)
        {
            var container = await GetContainer(containerName);
            var blobFile = container.GetBlockBlobReference(fileName);
            await blobFile.UploadFromStreamAsync(filePath.OpenReadStream());
        }
        public async Task DeleteFile(string containerName, string fileName)
        {
            var container = await GetContainer(containerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.DeleteAsync();
            
        }

    }
}
