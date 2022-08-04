using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace API.Helpers
{
    public interface IFileStorageHelper
    {
        Task<string> SaveFileAsync(IFormFile file);
        Task DeleteFileAsync(string fileName);
    }
}
