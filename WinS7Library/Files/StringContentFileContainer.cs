using System.IO;
using System.Text;

namespace WinS7Library.Files
{
    /// <summary>
    /// Represents text file
    /// </summary>
    public class StringContentFileContainer : IFileContainer
    {
        private readonly string _content;

        public StringContentFileContainer(string filename, string content)
        {
            Filename = filename;
            _content = content;
        }

        public string Filename { get; }

        public byte[] GetBytes() => Encoding.UTF8.GetBytes(_content);

        public void SaveTo(string path)
        {
            File.WriteAllText(path, _content, Encoding.UTF8);
        }

        public Stream GetStream() => new MemoryStream(GetBytes());
    }
}
