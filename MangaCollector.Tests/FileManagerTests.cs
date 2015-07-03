using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaCollector.Tests
{
    [TestClass]
    public class FileManagerTests
    {
        private const string DIRECTORY_SIMPLE = @"C:\Users\LuisAlberto\Documents\Proyects\MangaCollector\MangaCollector.SampleFiles\SimpleDirectory";
        private const string DIRECTORY_EMPTY = @"C:\Users\LuisAlberto\Documents\Proyects\MangaCollector\MangaCollector.SampleFiles\EmptyDirectory";
        private const string DIRECTORY_INVALID = @"foo";

        [TestMethod]
        public void FileManager_WhenProvidingDirectory_ReturnsFileList()
        {
            IFileManager mgr = new FileManager();
            IList<string> files = mgr.GetFileList(DIRECTORY_SIMPLE);

            Assert.IsNotNull(files);
            CollectionAssert.AllItemsAreNotNull(files.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FileManager_WhenUsingInvalidDirectory_ThrowsError()
        {
            IFileManager mgr = new FileManager();
            IList<string> files = mgr.GetFileList(DIRECTORY_INVALID);

            Assert.IsNotNull(files);
            CollectionAssert.AllItemsAreNotNull(files.ToList());
        }

        [TestMethod]
        public void FileManager_WhenUsingEmptyDirectory_ReturnsEmptyList()
        {
            IFileManager mgr = new FileManager();
            IList<string> files = mgr.GetFileList(DIRECTORY_EMPTY);

            Assert.IsNotNull(files);
            Assert.AreEqual(0, files.Count);
        }

        [TestMethod]
        public void FileManager_WhenProvidingFiles_ReturnsHashCollection()
        {
            IFileManager mgr = new FileManager();
            IList<string> files = mgr.GetFileList(DIRECTORY_SIMPLE);
            IList<FileHash> hashCollection = mgr.ReadHash(files);

            Assert.IsNotNull(hashCollection);
            Assert.IsTrue(hashCollection.Count > 0);
            CollectionAssert.AllItemsAreNotNull(hashCollection.ToList());

        }
    }
}
