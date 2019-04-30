using System.Threading.Tasks;

namespace CAT.BusinessLayer.Services.FileServices.Interfaces
{
    public interface IImageFileService
    {
        Task<string> DownloadToStorage(string fileName);

        Task RemoveFromStorage(string fileName);
    }
}
