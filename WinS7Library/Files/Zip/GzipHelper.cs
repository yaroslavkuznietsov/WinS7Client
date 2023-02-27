using System.IO.Compression;
using System.IO;

namespace WinS7Library.Files.Zip
{
    public class GzipHelper
    {
        public static void DecompressFile(string compressedFilePath, string uncompressedFilePath)
        {
            using (FileStream inputStream = new FileStream(compressedFilePath, FileMode.Open, FileAccess.Read))
            {
                using (GZipStream zipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                {
                    using (FileStream outputStream = new FileStream(uncompressedFilePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] tempBytes = new byte[4096];
                        int i;
                        while ((i = zipStream.Read(tempBytes, 0, tempBytes.Length)) != 0)
                        {
                            outputStream.Write(tempBytes, 0, i);
                        }
                    }
                }
            }
        }
    }
}
