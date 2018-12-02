using System;
using System.IO;
using CAT.DataLayer.Repositories.PhysicalRepositories.Interfaces;

namespace CAT.DataLayer.Repositories.PhysicalRepositories
{
    public class PhysicalRepository : IPhysicalRepository
    {
        public string SaveBase64ToTemporaryFile(string strBase64)
        {
            var filePath = CreateTemporaryFile();
            SaveBase64ToFile(filePath, strBase64);
            return filePath;
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private static string CreateTemporaryFile()
        {
            var filePath = Path.GetTempFileName();
            File.SetAttributes(filePath, FileAttributes.Temporary);
            return filePath;
        }

        private static void SaveBase64ToFile(string filePath, string strBase64)
        {
            var data = Convert.FromBase64String(strBase64);
            using (var stream = File.OpenWrite(filePath))
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(data);
                }
            }
        }
    }
}
