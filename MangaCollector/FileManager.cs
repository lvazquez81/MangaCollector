﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MangaCollector
{
    public class FileManager
    {
        private readonly IFileSystem _fileSystem;
        private readonly IHashCalculator _hashCalc;

        public FileManager(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
            _hashCalc = new QuickHashCalculator(fileSystem);
        }

        public IList<FileHash> GetFileHash(IList<string> filePaths)
        {
            if (filePaths == null) throw new ArgumentNullException("Provided file list is null.");
            if (filePaths.Count == 0) return new List<FileHash>();

            var hashCollection = new List<FileHash>();

            foreach (string file in filePaths)
            {
                FileHash hash = processHash(file);
                hashCollection.Add(hash);
            }

            return hashCollection;

        }

        public IList<string> EnlistFilesByDirectory(string directoryPath)
        {
            try
            {
                return _fileSystem.GetFilesFromDirectory(directoryPath);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to list files. Error: " + ex.Message, ex);
            }
        }

        private FileHash processHash(string file)
        {
            const int BYTES_TO_READ = 8;
            byte[] fileContent = _fileSystem.GetFileData(file, BYTES_TO_READ);
            string hash = _hashCalc.CalculateHash(file);

            return new FileHash()
            {
                Filename = file,
                Hash = hash,
                HashDate = DateTime.Now,
                HashDepth = BYTES_TO_READ
            };
        }

        private string calculateMD5Hash(byte[] fileContent)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] hash = md5.ComputeHash(fileContent);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private byte[] readFile(string file, int bytesToRead)
        {
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
    }
}
