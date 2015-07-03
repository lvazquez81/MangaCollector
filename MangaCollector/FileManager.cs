using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaCollector
{
    public class FileManager : IFileManager
    {
        public IList<string> GetFileList(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentNullException("Provided directory path is null.");
            
            if (!Directory.Exists(directoryPath))
                throw new ArgumentException("Provided directory was not found:" + directoryPath);

            return Directory.GetFiles(directoryPath);
        }

        public IList<object> ReadHash(List<string> filePaths)
        {
            if (filePaths == null) throw new ArgumentNullException("Provided file list is null.");
            if (filePaths.Count == 0) return new List<object>();


            return new List<object>();
        }
    }
}
