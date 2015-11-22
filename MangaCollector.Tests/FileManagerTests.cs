using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MangaCollector.Tests
{
    [TestFixture]
    public class FileManagerTests
    {
        [Test]
        public void FileManager_WhenProvidingDirectory_ReturnsFileList()
        {
            var mockedFileSystem = new Mock<IFileSystem>();
            var mgr = new FileManager(mockedFileSystem.Object);

            mockedFileSystem.Setup(x => x.GetFilesFromDirectory(It.IsAny<string>()))
                .Returns(new List<string>
                {
                    "file1.zip",
                    "file2.zip",
                    "file3.zip"
                });

            IList<string> files = mgr.EnlistFilesByDirectory("fooPath");

            CollectionAssert.Contains(files,"file1.zip");
            CollectionAssert.Contains(files, "file2.zip");
            CollectionAssert.Contains(files, "file3.zip");

        }
    }
}
