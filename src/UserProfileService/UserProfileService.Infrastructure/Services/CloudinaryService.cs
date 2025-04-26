using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Service;
using Microsoft.Extensions.Options;

namespace UserProfileService.Infrastructure.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        //public CloudinaryService(IOptions<CloudinarySettings> options)
        //{
        //    var settings = options.Value;
        //    var account = new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret);
        //    _cloudinary = new Cloudinary(account);
        //}


        public CloudinaryService(IConfiguration configuration)
        {
            var cloudName = configuration["CLOUDINARY_CLOUD_NAME"];
            var apiKey = configuration["CLOUDINARY_API_KEY"];
            var apiSecret = configuration["CLOUDINARY_API_SECRET"];

            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File cannot be null or empty", nameof(file));
            }
            using var stream = file.OpenReadStream();
            ImageUploadParams uploadParams;
        
                uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = "InterviewReadyProfiles",
                    Transformation = new Transformation().Quality("auto").FetchFormat("auto")
                };
         
            //else
            //{
            //    uploadParams = new ImageUploadParams
            //    {
            //        File = new FileDescription(file.FileName, stream),
            //        Folder = "LabourWorkImages",
            //        Transformation = new Transformation().Quality("auto").FetchFormat("auto")
            //    };
            //}
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            if (uploadResult.Error != null)
            {
                throw new Exception($"Cloudinary upload error: {uploadResult.Error.Message}");
            }
            return uploadResult.SecureUrl.ToString();
        }

        public async Task<bool> DeleteImageAsync(string publicId)
        {
            try
            {
                var deletionParams = new DeletionParams(publicId);
                var result = await _cloudinary.DestroyAsync(deletionParams);
                if (result.Result == "ok")
                {
                    return true;
                }
                if (result.Error != null)
                {
                    throw new Exception($"Cloudinary image deletion failed: {result.Error.Message}");
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete image with public ID: {publicId}. Error: {ex.Message}", ex);
            }
        }

        public string ExtractPublicIdFromUrl(string imageUrl)
        {
            var uri = new Uri(imageUrl);
            var segments = uri.Segments;
            var fileName = segments.Last(); 
            var publicId = fileName.Substring(0, fileName.LastIndexOf(".")); 
            return publicId;
        }
    }
}
