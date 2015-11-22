using System;
using System.Collections.Generic;
using System.IO;

namespace MangaCollector
{
    public class WindowsFileSystem : IFileSystem
    {
        public IList<string> GetFilesFromDirectory(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentNullException("Provided directory path is null.");

            if (!Directory.Exists(directoryPath))
                throw new ArgumentException("Provided directory was not found:" + directoryPath);

            return Directory.GetFiles(directoryPath);
        }

        public byte[] GetFileData(string filePath, int bytesToRead)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException("Provided file path is null.");

            if (!File.Exists(filePath))
                throw new ArgumentException("Provided file was not found:" + filePath);
            
            const int READ_START_POSITION = 0;
            byte[] fileContent = new byte[bytesToRead];

            using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
            {
                //reader.BaseStream.Seek(50, SeekOrigin.Begin);
                int bytesRead = reader.Read(fileContent, READ_START_POSITION, bytesToRead);

                if (bytesRead == 0 || bytesRead != bytesToRead)
                {
                    throw new ApplicationException("Could not read file content: " + filePath);
                }
            }

            return fileContent;
        }
    }
}
