using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace MangaCollector.Tests
{
    [TestFixture]
    public class MangaCollectorTests
    {
        [Test]
        public void WhenInitializing_WithCurrentDirectory_ReturnsFileList()
        {
            IMangaCollector m = new MangaCollector();
            IList<string> files = m.ReadDirectory(@"C:\Users\LuisAlberto\Desktop");

            Assert.IsNotNull(files);
            CollectionAssert.AllItemsAreNotNull(files.ToList());
        }

        [Test]
        public void WhenReadingDirectory_WithMangaFiles_ReturnsMetaTags()
        {
            IMangaCollector m = new MangaCollector();
            IList<string> files = m.ReadDirectory(@"C:\Users\LuisAlberto\Desktop");

            Assert.IsNotNull(files);
            CollectionAssert.AllItemsAreNotNull(files.ToList());
        }
    }
}
