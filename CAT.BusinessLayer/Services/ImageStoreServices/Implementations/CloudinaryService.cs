using System.IO;
using CAT.BusinessLayer.Options;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace CAT.BusinessLayer.Services.ImageStoreServices.Implementations
{
    public class CloudinaryService : IImageStoreService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(IOptions<CloudinarySettings> options)
        {
            var settings = options.Value;
            var account = CreateAccount(settings);
            cloudinary = new Cloudinary(account);
        }

        private Account CreateAccount(CloudinarySettings settings)
        {
            return new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret);
        }

        public string Save(string fileName, Stream imageData)
        {
            var param = new ImageUploadParams
            {
                File = new FileDescription(fileName, imageData)
            };
            var imageInStorage = cloudinary.Upload(param);
            return imageInStorage.Uri.AbsoluteUri;
        }

        public void Remove(string fileName)
        {

        }
    }
}
