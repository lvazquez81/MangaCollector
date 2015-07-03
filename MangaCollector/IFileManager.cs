using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaCollector
{
    public interface IFileManager
    {
        IList<string> GetFileList(string directoryPath);
        IList<object> ReadHash(List<string> filePaths);
    }
}
