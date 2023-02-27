using System.Collections.Generic;
using System.IO;

namespace WinS7Library.Files.Zip
{
    /// <summary>
    /// Create zip-file from input file
    /// </summary>
    public interface ICreateZipFile
    {
        MemoryStream CreateZip(IList<ZipFileDto> files);
        FileStream CreateZip(IList<ZipFileDto> files, string outputPathWithFilename);
        void CreateZip(IList<ZipFileDto> files, Stream stream);
    }
}
