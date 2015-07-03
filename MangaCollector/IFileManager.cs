﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaCollector
{
    public interface IFileManager
    {
        IList<string> GetFileList(string directoryPath);
        IList<FileHash> ReadHash(IList<string> filePaths);
    }

    public class FileHash
    {
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public string Hash { get; set; }
        public DateTime HashDate { get; set; }
        public int HashDepth { get; set; }
    }
}
