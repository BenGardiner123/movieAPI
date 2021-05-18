using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Helpers
{
    interface IFileStorageService
    {
        Task DeleteFile(string fileRoute, string containerName);
        Task<String> SaveFile(string containerName, IFormFile file);
        Task<String> EditFile(string containerName, IFormFile file, string fileRoute);

    }
}
