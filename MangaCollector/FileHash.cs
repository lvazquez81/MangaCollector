using System;

namespace MangaCollector
{
    public class FileHash
    {
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public string Hash { get; set; }
        public DateTime HashDate { get; set; }
        public int HashDepth { get; set; }
    }
}
