using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using CAT.BusinessLayer.Options;
using CAT.BusinessLayer.Services.FileServices.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace CAT.BusinessLayer.Services.FileServices
{
    public class CloudinaryService : IImageFileService
    {
        private readonly Cloudinary Cloudinary;

        public CloudinaryService(IOptions<CloudinaryOption> option)
        {
            var options = option.Value;
            var account = new Account(options.Cloud, options.ApiKey, options.ApiSecret);
            Cloudinary = new Cloudinary(account);
        }

        public async Task<string> DownloadToStorage(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            if (!fileInfo.Exists) return null;
            var param = new ImageUploadParams
            {
                File = new FileDescription(fileName),
                //Transformation = GetSquareAvatarTransformation(fileName)
            };
            var imageInStorage = await Cloudinary.UploadAsync(param);
            fileInfo.Delete();
            return imageInStorage.Uri.AbsoluteUri;
        }

        public async Task RemoveFromStorage(string fileName)
        {
            var splits = fileName.Split('/', '.');
            var publicId = splits[splits.Length - 2];
            var param = new DelResParams { PublicIds = new List<string> { publicId } };
            await Cloudinary.DeleteResourcesAsync(param);
        }

        //private Transformation GetSquareAvatarTransformation(string fileName)
        //{
        //    using (var fileStream = new FileStream(fileName, FileMode.Open))
        //    {
        //        var image = MediaTypeNames.Image.FromStream(fileStream);
        //        var width = image.Width < image.Height ? image.Width : image.Height;
        //        return new Transformation().Width(width).Height(width).Crop("fill").Gravity("face");
        //    }
        //}
    }
}
