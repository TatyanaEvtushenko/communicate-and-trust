namespace CAT.DataLayer.Repositories.PhysicalRepositories.Interfaces
{
    public interface IPhysicalRepository
    {
        string SaveBase64ToTemporaryFile(string strBase64);

        void DeleteFile(string filePath);
    }
}
