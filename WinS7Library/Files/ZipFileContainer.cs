using System.Collections.Generic;
using System.IO;
using WinS7Library.Files.Zip;

namespace WinS7Library.Files
{
    public class ZipFileContainer
    {
        private readonly IList<ZipFileDto> _zipFiles;
        private readonly ICreateZipFile _createZipFile;

        public ZipFileContainer(string filename, IList<ZipFileDto> zipFiles, ICreateZipFile createZipFile)
        {
            Filename = filename;
            _zipFiles = zipFiles;
            _createZipFile = createZipFile;
        }

        public string Filename { get; }

        public byte[] GetBytes() => GetMemoryStream().ToArray();

        public void SaveTo(string path)
        {
            using (FileStream stream = File.Create(path))
            {
                _createZipFile.CreateZip(_zipFiles, stream);
            }
        }

        public Stream GetStream() => GetMemoryStream();

        private MemoryStream GetMemoryStream()
        {
            var stream = new MemoryStream();
            _createZipFile.CreateZip(_zipFiles, stream);
            return stream;
        }
    }
}
