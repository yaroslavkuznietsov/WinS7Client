using WinS7Library.Files;

namespace WinS7Library.Interfaces
{
    public interface IProcessDataExporter
    {
        void Create(object data, string path, string fileName);
    }
}
