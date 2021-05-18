using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Helpers
{
    public class AzureStorageService : IFileStorageService
    {
        private string connectionString;

        public AzureStorageService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorageConnection");
        }
     
        public async Task DeleteFile(string fileRoute, string containerName)
        {
            if (string.IsNullOrEmpty(fileRoute))
            {
                return;
            }

            // create the blob connection instance
            var client = new BlobContainerClient(connectionString, containerName);
            //check if the blob exists and creaete otherwise conenct
            await client.CreateIfNotExistsAsync();
            var filename = Path.GetFileName(fileRoute);
            var blob = client.GetBlobClient(filename);
            await blob.DeleteIfExistsAsync();

        }

        public async Task<string> EditFile(string containerName, IFormFile file, string fileRoute)
        {
            await DeleteFile(fileRoute, containerName);
            return await SaveFile(containerName, file);
        }

        public async Task<string> SaveFile(string containerName, IFormFile file)
        {
            // create the blob connection instance
            var client = new BlobContainerClient(connectionString, containerName);
            //check if the blob exists and creaete otherwise conenct
            await client.CreateIfNotExistsAsync();
            //set access policy
            client.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
            //create a random filename
            var extenstion = Path.GetExtension(file.FileName);

            var fileName = $"{Guid.NewGuid()}{extenstion}";

            //now add the new filename to the connection client
            var blob = client.GetBlobClient(fileName);
            //upload the files async styles and then once completed give us the URL that we can use in the front end
            await blob.UploadAsync(file.OpenReadStream());
            return blob.Uri.ToString();

        }
    }
}
