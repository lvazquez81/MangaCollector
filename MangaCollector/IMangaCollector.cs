using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaCollector
{
    public interface IMangaCollector
    {
        IList<string> ReadDirectory(string filePath);
    }
}
