using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Application.Interfaces.Service
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(IFormFile file);
        Task<bool> DeleteImageAsync(string publicId);
        string ExtractPublicIdFromUrl(string imageUrl);
    }
}
