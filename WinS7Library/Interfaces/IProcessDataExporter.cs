using WinS7Library.Files;

namespace WinS7Library.Interfaces
{
    public interface IProcessDataExporter
    {
        IFileContainer Create(object data, string path, string fileName);
    }
}
