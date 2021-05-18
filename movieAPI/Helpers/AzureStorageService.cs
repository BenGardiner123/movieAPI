using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Helpers
{
    public class AzureStorageService : IFileStorageService
    {
        public AzureStorageService()
        {

        }
     
        public Task DeleteFile(string fileRoute, string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditFile(string containerName, IFormFile file, string fileRoute)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFile(string containerName, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
