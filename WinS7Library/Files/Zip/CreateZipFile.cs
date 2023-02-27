using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System.Collections.Generic;
using System.IO;

namespace WinS7Library.Files.Zip
{
    /// <inheritdoc />
    public class CreateZipFile : ICreateZipFile
    {
        public MemoryStream CreateZip(IList<ZipFileDto> files)
        {
            MemoryStream memoryStream;
            using (memoryStream = new MemoryStream())
            {
                using (var zipStream = new ZipOutputStream(memoryStream))
                {
                    //Set compression level: 9 means best compression
                    zipStream.SetLevel(9);

                    byte[] buffer = new byte[4096];
                    foreach (ZipFileDto file in files)
                    {
                        if (!File.Exists(file.PathToFile) || !IsFileNameValid(file.NewFileName))
                            continue;

                        var zipEntry = new ZipEntry(file.NewFileName);
                        zipStream.PutNextEntry(zipEntry);

                        using (FileStream fileStream = File.OpenRead(file.PathToFile))
                        {
                            StreamUtils.Copy(fileStream, zipStream, buffer);
                        }
                    }
                }
            }

            return memoryStream;
        }

        public FileStream CreateZip(IList<ZipFileDto> files, string outputPathWithFilename)
        {
            using (FileStream fileStream = File.Create(outputPathWithFilename))
            {
                var zipStream = new ZipOutputStream(fileStream);

                //Set compression level: 9 means best compression
                zipStream.SetLevel(9);

                foreach (ZipFileDto file in files)
                {
                    if (!File.Exists(file.PathToFile) || !IsFileNameValid(file.NewFileName))
                        continue;

                    var zipEntry = new ZipEntry(file.NewFileName);
                    zipStream.PutNextEntry(zipEntry);

                    var buffer = new byte[4096];
                    using (FileStream streamReader = File.OpenRead(file.PathToFile))
                    {
                        StreamUtils.Copy(streamReader, zipStream, buffer);
                    }
                }

                zipStream.IsStreamOwner = true;
                zipStream.Close();
            }

            return File.OpenRead(outputPathWithFilename);
        }

        public void CreateZip(IList<ZipFileDto> files, Stream stream)
        {
            using (var zipStream = new ZipOutputStream(stream))
            {
                //Set compression level: 9 means best compression
                zipStream.SetLevel(9);

                foreach (ZipFileDto file in files)
                {
                    if (!File.Exists(file.PathToFile) || !IsFileNameValid(file.NewFileName))
                        continue;

                    var zipEntry = new ZipEntry(file.NewFileName);
                    zipStream.PutNextEntry(zipEntry);

                    var buffer = new byte[4096];
                    using (FileStream streamReader = File.OpenRead(file.PathToFile))
                    {
                        StreamUtils.Copy(streamReader, zipStream, buffer);
                    }
                }
            }
        }

        private static bool IsFileNameValid(string fileName) =>
            fileName.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;
    }
}
