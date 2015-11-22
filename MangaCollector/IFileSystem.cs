using System.Collections.Generic;
using System.IO;

namespace MangaCollector
{
    public interface IFileSystem
    {
        IList<string> GetFilesFromDirectory(string directoryPath);
        byte[] GetFileData(string filePath, int bytesToRead);
    }
}
