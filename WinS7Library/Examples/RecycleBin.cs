using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Library.Examples
{
    static class RecycleBin
    {
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    log0.Info("Serializer.DeserializeMWerkzeug();" + " " + "ServicePlcToPcs[n].AktWerkzeugID" + " to PLC50 " + " result: " + "result");
        //    log1.Info("Serializer.DeserializeMWerkzeug();" + " " + "ServicePlcToPcs[n].AktWerkzeugID" + " to PLC70 " + " result: " + "result");
        //    //@"e:\\path\\WinS7ClientLogger.log"
        //    ChangeLogFileName("RollingFileAppender0", @"e:\\dotnet\\WinS7ClientLogger51.log");
        //    log0.Info("Serializer.DeserializeMWerkzeug();" + " " + "ServicePlcToPcs[n].AktWerkzeugID" + " to PLC51 " + " result: " + "result");
        //    ChangeLogFileName("RollingFileAppender1", @"e:\\dotnet\\WinS7ClientLogger71.log");
        //    log1.Info("Serializer.DeserializeMWerkzeug();" + " " + "ServicePlcToPcs[n].AktWerkzeugID" + " to PLC71 " + " result: " + "result");

        //    ChangeLogFileName("RollingFileAppender0", @"e:\\dotnet\\WinS7ClientLogger52.log");
        //    log0.Info("Serializer.DeserializeMWerkzeug();" + " " + "ServicePlcToPcs[n].AktWerkzeugID" + " to PLC52 " + " result: " + "result");
        //    ChangeLogFileName("RollingFileAppender1", @"e:\\dotnet\\WinS7ClientLogger72.log");
        //    log1.Info("Serializer.DeserializeMWerkzeug();" + " " + "ServicePlcToPcs[n].AktWerkzeugID" + " to PLC72 " + " result: " + "result");
        //}


        //private void CreateDir_Click(object sender, EventArgs e)
        //{
        //    string root = string.Empty;
        //    string folder = string.Empty;
        //    string path = string.Empty;
        //    CreateDirectory(root, folder, ref path);
        //}

        //private void btnRenameDir_Click(object sender, EventArgs e)
        //{
        //    string root = @"E:\Recipes";
        //    string path = root + @"\" + "055_BlaBlaBla";
        //    // If directory does not exist, create it. 
        //    if (!Directory.Exists(root))
        //    {
        //        Directory.CreateDirectory(root);
        //    }

        //    if (Directory.Exists(path))
        //    {
        //        string path2 = root + @"\" + "066_BlaBlaBla";

        //        Directory.Move(path, path2);
        //    }
        //}



        //private void button1_Click(object sender, EventArgs e)
        //{
        //    TimerForm.Stop();
        //    TimerForm.Enabled = false;

        //    var watch = System.Diagnostics.Stopwatch.StartNew();
        //    // the code that you want to measure comes here

        //    _ticks++;
        //    //Show counter
        //    //textBoxTimerForm.Text = _ticks.ToString();

        //    if (_ticks >= 10)
        //    {
        //        _ticks = 0;
        //    }

        //TestStrings.Add(DateTime.Now.ToString());

        //UpdateBindinglistBoxDboATGStatusView();

        //    // the code that you want to measure ends here
        //    watch.Stop();
        //    var elapsedMs = watch.ElapsedMilliseconds;
        //    //textBoxCodeTime54010.Text = elapsedMs.ToString();
        //    TimerForm.Enabled = true;
        //    TimerForm.Start();
        //}



        //private void ReadCPUInfo(S7Client client, ref S7Client.S7CpuInfo info, ref int result)
        //{
        //    result = client.GetCpuInfo(ref info);
        //}

        //private void ReadOrderCode(S7Client client, ref S7Client.S7OrderCode orderCode, ref int result)
        //{
        //    result = client.GetOrderCode(ref orderCode);
        //}

        //private void ReadAreaPlc(S7Client client, byte area, int dbNumber, int start, int amount, int wordLen, byte[] buffer, ref int sizeRead, ref int result)
        //{
        //    // Declaration separated from the code for readability
        //    Array.Clear(buffer, 0, buffer.Length);

        //    result = client.ReadArea(area, dbNumber, start , amount, wordLen, buffer, ref sizeRead);

        //    ShowResult(result, client);
        //}

        //private void WriteAreaPlc(S7Client client, byte area, int dbNumber, int start, int amount, int wordLen, byte[] buffer, ref int result)
        //{

        //    result = client.WriteArea(area, dbNumber, start, amount, wordLen, buffer);

        //    ShowResult(result, client);
        //}

        //private void HexDump(TextBox DumpBox, byte[] bytes, int Size)
        //{
        //    if (bytes == null)
        //        return;
        //    int bytesLength = Size;
        //    int bytesPerLine = 16;

        //    char[] HexChars = "0123456789ABCDEF".ToCharArray();

        //    int firstHexColumn =
        //          8                   // 8 characters for the address
        //        + 3;                  // 3 spaces

        //    int firstCharColumn = firstHexColumn
        //        + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
        //        + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
        //        + 2;                  // 2 spaces 

        //    int lineLength = firstCharColumn
        //        + bytesPerLine           // - characters to show the ascii value
        //        + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

        //    char[] line = (new String(' ', lineLength - 2) + Environment.NewLine).ToCharArray();
        //    int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
        //    StringBuilder result = new StringBuilder(expectedLines * lineLength);

        //    for (int i = 0; i < bytesLength; i += bytesPerLine)
        //    {
        //        line[0] = HexChars[(i >> 28) & 0xF];
        //        line[1] = HexChars[(i >> 24) & 0xF];
        //        line[2] = HexChars[(i >> 20) & 0xF];
        //        line[3] = HexChars[(i >> 16) & 0xF];
        //        line[4] = HexChars[(i >> 12) & 0xF];
        //        line[5] = HexChars[(i >> 8) & 0xF];
        //        line[6] = HexChars[(i >> 4) & 0xF];
        //        line[7] = HexChars[(i >> 0) & 0xF];

        //        int hexColumn = firstHexColumn;
        //        int charColumn = firstCharColumn;

        //        for (int j = 0; j < bytesPerLine; j++)
        //        {
        //            if (j > 0 && (j & 7) == 0) hexColumn++;
        //            if (i + j >= bytesLength)
        //            {
        //                line[hexColumn] = ' ';
        //                line[hexColumn + 1] = ' ';
        //                line[charColumn] = ' ';
        //            }
        //            else
        //            {
        //                byte b = bytes[i + j];
        //                line[hexColumn] = HexChars[(b >> 4) & 0xF];
        //                line[hexColumn + 1] = HexChars[b & 0xF];
        //                line[charColumn] = (b < 32 ? '·' : (char)b);
        //            }
        //            hexColumn += 3;
        //            charColumn++;
        //        }
        //        result.Append(line);
        //    }
        //    DumpBox.Text = result.ToString();

        //private static async Task<int> ConnectToClientAsync(S7Client client, string address, int rack, int slot)
        //{
        //    int result = await Task.Run(() => client.ConnectTo(address, rack, slot));
        //    //ShowResult(result, S7Clients[7]);
        //    return result;
        //}
        //}


        //for (int i = 0; i < log.Length; i++)
        //{
        //    log[i] = log4net.LogManager.GetLogger("RollingFileAppender" + i);
        //}


        //public void Plc3()
        //{
        //    int n = 3;
        //    while (true)
        //    {
        //        try
        //        {
        //            this.Invoke((MethodInvoker)delegate
        //            {
        //                log0.Info("Test0x");
        //                ChangeLogFileName("RollingFileAppender0", @"e:\\recipes\\WinS7ClientLogger0.log");
        //                log0.Info("Test0");
        //                if (S7Clients[n].Connected)
        //                {

        //                }
        //            });


        //            Thread.Sleep(500);
        //        }
        //        catch (Exception ex)
        //        {

        //            throw;
        //        }
        //    }
        //}

        //public void Plc4()
        //{
        //    int n = 4;
        //    while (true)
        //    {
        //        try
        //        {
        //            this.Invoke((MethodInvoker)delegate
        //            {
        //                ChangeLogFileName("RollingFileAppender0", @"e:\\recipes\\WinS7ClientLogger000.log");
        //                log0.Info("Test000");

        //                log[1].Info("Test1");
        //                ChangeLogFileName("RollingFileAppender1", @"e:\\recipes\\WinS7ClientLogger1.log");
        //                log[1].Info("Test1");

        //                log[2].Info("Test2");
        //                ChangeLogFileName("RollingFileAppender2", @"e:\\recipes\\WinS7ClientLogger2.log");
        //                log[2].Info("Test2");

        //                log[3].Info("Test3");
        //                ChangeLogFileName("RollingFileAppender3", @"e:\\recipes\\WinS7ClientLogger3.log");
        //                log[3].Info("Test3");

        //                log[4].Info("Test4");
        //                ChangeLogFileName("RollingFileAppender4", @"e:\\recipes\\WinS7ClientLogger4.log");
        //                log[4].Info("Test4");

        //                //ChangeLogFileName("RollingFileAppender4", @".\\WinS7ClientLogger.log");
        //                //log[4].Info("Test44");

        //                log[5].Info("Test5");
        //                ChangeLogFileName("RollingFileAppender5", @"e:\\recipes\\WinS7ClientLogger5.log");
        //                log[5].Info("Test5");

        //                log[6].Info("Test6");
        //                ChangeLogFileName("RollingFileAppender6", @"e:\\recipes\\WinS7ClientLogger6.log");
        //                log[6].Info("Test6");

        //                log[7].Info("Test7");
        //                ChangeLogFileName("RollingFileAppender7", @"e:\\recipes\\WinS7ClientLogger7.log");
        //                log[7].Info("Test7");

        //                log[8].Info("Test8");
        //                ChangeLogFileName("RollingFileAppender8", @"e:\\recipes\\WinS7ClientLogger8.log");
        //                log[8].Info("Test8");

        //                log[9].Info("Test9");
        //                ChangeLogFileName("RollingFileAppender9", @"e:\\recipes\\WinS7ClientLogger9.log");
        //                log[9].Info("Test9");

        //                log[10].Info("Test10");
        //                ChangeLogFileName("RollingFileAppender10", @"e:\\recipes\\WinS7ClientLogger10.log");
        //                log[10].Info("Test10");

        //                if (S7Clients[n].Connected)
        //                {

        //                }
        //            });


        //            Thread.Sleep(500);
        //        }
        //        catch (Exception ex)
        //        {

        //            throw;
        //        }
        //    }
        //}
    }
}
