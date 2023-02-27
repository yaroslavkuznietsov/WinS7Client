using System.IO;

namespace WinS7Library.Files
{
    public interface IFileContainer
    {
        string Filename { get; }
        byte[] GetBytes();
        void SaveTo(string path);
        Stream GetStream();
    }
}
