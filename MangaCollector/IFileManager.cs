using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaCollector
{
    public interface IFileReader
    {
        IList<string> GetFileList(string directoryPath);
        byte[] ReadFile(string filePath, int bytesToRead);
        FileInfo GetFileInfo(string filePath);
    }

    public class FileReader : IFileReader
    {
        public IList<string> GetFileList(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentNullException("Provided directory path is null.");

            if (!Directory.Exists(directoryPath))
                throw new ArgumentException("Provided directory was not found:" + directoryPath);

            return Directory.GetFiles(directoryPath);
        }

        public byte[] ReadFile(string file, int bytesToRead)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException("Provided file path is null.");

            if (!File.Exists(file))
                throw new ArgumentException("Provided file was not found:" + file);
            
            const int READ_START_POSITION = 0;
            byte[] fileContent = new byte[bytesToRead];

            using (BinaryReader reader = new BinaryReader(new FileStream(file, FileMode.Open)))
            {
                //reader.BaseStream.Seek(50, SeekOrigin.Begin);
                int bytesRead = reader.Read(fileContent, READ_START_POSITION, bytesToRead);

                if (bytesRead == 0 || bytesRead != bytesToRead)
                {
                    throw new ApplicationException("Could not read file content: " + file);
                }
            }

            return fileContent;
        }

        public FileInfo GetFileInfo(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException("Provided file path is null.");

            if (!File.Exists(filePath))
                throw new ArgumentException("Provided file was not found:" + filePath);

            return new FileInfo(filePath);
        }
    }


}
