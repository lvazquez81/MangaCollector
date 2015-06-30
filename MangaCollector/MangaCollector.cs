using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaCollector
{
    public class MangaCollector : IMangaCollector
    {
        public IList<string> ReadDirectory(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("Invalid directory path provided.");
            if (!Directory.Exists(filePath)) throw new ArgumentException("Directory was not found.");
            
            return new List<string>() { "File1.zip", "File2.zip" };
        }
    }
}
