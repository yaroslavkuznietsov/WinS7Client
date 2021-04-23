using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinS7Library
{
    public static class GlobalHelper
    {
        public static async Task<int> ConnectToClientAsync(S7Client client, string address, int rack, int slot)
        {
            int result = await Task.Run(() => client.ConnectTo(address, rack, slot));
            return result;
        }

        public static void ReadCPUInfo(S7Client client, ref S7Client.S7CpuInfo info, ref int result)
        {
            result = client.GetCpuInfo(ref info);
        }

        public static void ReadOrderCode(S7Client client, ref S7Client.S7OrderCode orderCode, ref int result)
        {
            result = client.GetOrderCode(ref orderCode);
        }

        public static void ReadAreaPlc(S7Client client, byte area, int dbNumber, int start, int amount, int wordLen, byte[] buffer, ref int sizeRead, ref int result)
        {
            // Declaration separated from the code for readability
            Array.Clear(buffer, 0, buffer.Length);
            result = client.ReadArea(area, dbNumber, start, amount, wordLen, buffer, ref sizeRead);
        }

        public static void WriteAreaPlc(S7Client client, byte area, int dbNumber, int start, int amount, int wordLen, byte[] buffer, ref int result)
        {
            result = client.WriteArea(area, dbNumber, start, amount, wordLen, buffer);
        }
        public static void WriteAreaPlc(S7Client client, byte area, int dbNumber, int start, int amount, int wordLen, byte[] buffer, ref int result, ref string error)
        {
            result = client.WriteArea(area, dbNumber, start, amount, wordLen, buffer);
            error = ShowResultClient(result, client);
        }

        public static string ShowResultClient(int result, S7Client client)
        {
            // This function returns a textual explaination of the error code
            string error = DateTime.Now + " - " + client.ErrorText(result);
            if (result == 0)
            {
                error = error + " PDU Negotiated : " + client.PduSizeNegotiated.ToString() + " (" + client.ExecutionTime.ToString() + " ms)";
            }
            return error;
        }

        public static void HexDump(TextBox DumpBox, byte[] bytes, int Size)
        {
            if (bytes == null)
                return;
            int bytesLength = Size;
            int bytesPerLine = 16;

            char[] HexChars = "0123456789ABCDEF".ToCharArray();

            int firstHexColumn =
                  8                   // 8 characters for the address
                + 3;                  // 3 spaces

            int firstCharColumn = firstHexColumn
                + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                + 2;                  // 2 spaces 

            int lineLength = firstCharColumn
                + bytesPerLine           // - characters to show the ascii value
                + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', lineLength - 2) + Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >> 8) & 0xF];
                line[6] = HexChars[(i >> 4) & 0xF];
                line[7] = HexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char)b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            DumpBox.Text = result.ToString();
        }

        
    }
}
