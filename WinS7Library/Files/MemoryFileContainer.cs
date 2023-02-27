using System.IO;
using System.Linq;
using WinS7Library.Interfaces;

namespace WinS7Library.Files
{
    public class MemoryFileContainer : IFileContainer
    {
        private readonly byte[] _bytes;

        public MemoryFileContainer(string filename, byte[] bytes)
        {
            _bytes = bytes;
            Filename = filename;
        }

        public string Filename { get; protected set; }
        public byte[] GetBytes()
        {
            return _bytes.ToArray();
        }

        public void SaveTo(string path)
        {
            File.WriteAllBytes(path, _bytes);
        }

        public Stream GetStream()
        {
            return new MemoryStream(_bytes);
        }
    }
}
