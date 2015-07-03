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

        #region Reading file list
        [TestMethod]
        public void FileManager_WhenProvidingDirectory_ReturnsFileList()
        {
            IFileReader mgr = new FileReader();
            IList<string> files = mgr.GetFileList(DIRECTORY_SIMPLE);

            Assert.IsNotNull(files);
            CollectionAssert.AllItemsAreNotNull(files.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FileManager_WhenUsingInvalidDirectory_ThrowsError()
        {
            IFileReader mgr = new FileReader();
            IList<string> files = mgr.GetFileList(DIRECTORY_INVALID);

            Assert.IsNotNull(files);
            CollectionAssert.AllItemsAreNotNull(files.ToList());
        }

        [TestMethod]
        public void FileManager_WhenUsingEmptyDirectory_ReturnsEmptyList()
        {
            IFileReader mgr = new FileReader();
            IList<string> files = mgr.GetFileList(DIRECTORY_EMPTY);

            Assert.IsNotNull(files);
            Assert.AreEqual(0, files.Count);
        }
        #endregion



    }
}
