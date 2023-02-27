using System.IO;
using WinS7Library.Interfaces;

namespace WinS7Library.Files
{
    public class StreamFileContainer : IFileContainer
    {
        private readonly Stream _stream;

        public StreamFileContainer(string filename, Stream stream)
        {
            _stream = stream;
            Filename = filename;
        }

        public string Filename { get; protected set; }

        public byte[] GetBytes()
        {
            using (var memoryStream = new MemoryStream())
            {
                _stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public void SaveTo(string path)
        {
            using (FileStream fileStream = File.Create(path))
            {
                _stream.Seek(0, SeekOrigin.Begin);
                _stream.CopyTo(fileStream);
            }
        }

        public Stream GetStream() => _stream;
    }
}
