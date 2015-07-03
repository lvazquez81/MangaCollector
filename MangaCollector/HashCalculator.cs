﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MangaCollector
{
    public interface IHashCalculator
    {
        string CalculateHash(string filePath);
    }

    public class QuickHashCalculator : IHashCalculator
    {
        private const int BYTES_TO_READ = 8;
        private readonly IFileReader _fileReader;

        public QuickHashCalculator(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public string CalculateHash(string filePath)
        {
            byte[] fileContent = _fileReader.ReadFile(filePath, BYTES_TO_READ);
            return calculateMD5Hash(fileContent);
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

      
    }
}
