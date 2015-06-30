using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaCollector
{
    public class IFileManager
    {
        IEnumerator<string> GetFiles(string directoryPath);
    }
}
