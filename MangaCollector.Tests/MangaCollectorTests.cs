using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MangaCollector.Tests
{
    [TestClass]
    public class MangaCollectorTests
    {
        [TestMethod]
        public void WhenInitializing_WithCurrentDirectory_ReturnsFileList()
        {
            IMangaCollector m = new MangaCollector();
            IList<string> files = m.ReadDirectory(@"C:\Users\LuisAlberto\Desktop");

            Assert.IsNotNull(files);
            CollectionAssert.AllItemsAreNotNull(files.ToList());
        }

        [TestMethod]
        public void WhenReadingDirectory_WithMangaFiles_ReturnsMetaTags()
        {
            IMangaCollector m = new MangaCollector();
            IList<string> files = m.ReadDirectory(@"C:\Users\LuisAlberto\Desktop");

            Assert.IsNotNull(files);
            CollectionAssert.AllItemsAreNotNull(files.ToList());
        }
    }
}
