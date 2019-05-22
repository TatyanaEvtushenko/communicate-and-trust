using System.IO;

namespace CAT.BusinessLayer.Services.ImageStoreServices
{
    public interface IImageStoreService
    {
        string Save(string fileName, Stream imageData);

        void Remove(string fileName);
    }
}
