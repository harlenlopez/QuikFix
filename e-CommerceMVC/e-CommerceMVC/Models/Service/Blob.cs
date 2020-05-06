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
        //Cloud storage account object
        public CloudStorageAccount CloudStorageAccount { get; set; }

        //Setting client
        public CloudBlobClient CloudBlobClient { get; set; }

        //Constructor that will get inconfiguration and implement keys and name from secret json file
        public Blob(IConfiguration configuration)
        {
            var storageCred = new StorageCredentials(configuration["Storage-Account-Name"], configuration["Blob-Key"]);
            CloudStorageAccount = new CloudStorageAccount(storageCred, true);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// Getting the container that we are using
        /// </summary>
        /// <param name="ContainerName">container name</param>
        /// <returns>container</returns>
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

        /// <summary>
        /// Getting the file that is is the container
        /// </summary>
        /// <param name="imageName">image name</param>
        /// <param name="ContainerName">container name</param>
        /// <returns>the file that has been gotten</returns>
        public async Task<CloudBlob> GetBlob(string imageName, string ContainerName)
        {

            var Container = await GetContainer(ContainerName);
            CloudBlob blob = Container.GetBlobReference(imageName);
            return blob;
        }

        /// <summary>
        /// Uploading the file to the storage
        /// </summary>
        /// <param name="containerName">container that will carry this file</param>
        /// <param name="fileName">file name</param>
        /// <param name="filePath">Image file</param>
        /// <returns></returns>
        public async Task UploadFile(string containerName, string fileName, string filePath)
        {
            var container = await GetContainer(containerName);
            var blobFile = container.GetBlockBlobReference(fileName);
            await blobFile.UploadFromFileAsync(filePath);
        }

        /// <summary>
        /// Deleting this file
        /// </summary>
        /// <param name="containerName">container</param>
        /// <param name="fileName">file name</param>
        public async Task DeleteFile(string containerName, string fileName)
        {
            var container = await GetContainer(containerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.DeleteAsync();
        }
    }
}
