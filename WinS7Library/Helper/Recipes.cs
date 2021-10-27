using Sharp7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Library.Helper
{
    public static class Recipes
    {
        /// <summary>
        /// RecipesServiceMethods
        /// </summary>
        #region RecipesServiceMethods
        public static string[] GetSubDirectories(string root)
        {
            //root = @"E:\Recipes";
            // Get all subdirectories
            string[] subdirectoryEntries = Directory.GetDirectories(root);
            return subdirectoryEntries;
        }

        public static void ClearBuffer(ref byte[] buffer)
        {
            Array.Clear(buffer, 0, buffer.Length);
        }

        public static void ToolListClear(ref byte[] buffer)
        {
            Array.Clear(buffer, 0, 65536);
            int shiftName = 0;
            //int shiftId = 22;
            int shiftId = 42;   //shiftName += 44;    // v.4 Changes for customer 28.04.2021 -> 40 Signs
            for (int i = 0; i < 127; i++)
            {
                //S7.SetStringAt(buffer, shiftName, 20, string.Empty);
                S7.SetStringAt(buffer, shiftName, 40, string.Empty);  // v.4 Changes for customer 28.04.2021 -> 40 Signs
                S7.SetIntAt(buffer, shiftId, 0);

                //shiftName += 24;
                //shiftId += 24;
                shiftName += 44;    // v.4 Changes for customer 28.04.2021 -> 40 Signs
                shiftId += 44;      // v.4 Changes for customer 28.04.2021 -> 40 Signs
            }
        }

        public static void ToolListFillWithRecipes(string[] subdirectoryEntries, ref byte[] buffer)
        {
            int shiftName = 0;
            //int shiftId = 22;
            int shiftId = 42;   //shiftName += 44;    // v.4 Changes for customer 28.04.2021 -> 40 Signs
            Array.Clear(buffer, 0, 65536);

            foreach (string subdirectory in subdirectoryEntries)
            {
                if (subdirectory.Length >= 14)
                {
                    string s1 = subdirectory.Substring(11, 3);
                    if (s1.ParseShort() != 255) //Critical change for customer 09.04.2021. Should be checked!!!
                    {
                        S7.SetIntAt(buffer, shiftId, (subdirectory.Substring(11, 3)).ParseShort());
                    }
                    else
                    {
                        //S7.SetIntAt(buffer, 3070, (subdirectory.Substring(11, 3)).ParseShort());    //Critical change for customer 09.04.2021. Should be checked!!!
                        S7.SetIntAt(buffer, 5630, (subdirectory.Substring(11, 3)).ParseShort());   // v.4 Changes for customer 28.04.2021 -> 40 Signs
                    }
                }
                else
                {
                    S7.SetIntAt(buffer, shiftId, 0);
                }

                if (subdirectory.Length >= 16)
                {
                    string s2 = subdirectory.Substring(15);
                    string s1 = subdirectory.Substring(11, 3);
                    if (s1.ParseShort() != 255) //Critical change for customer 09.04.2021. Should be checked!!!
                    {
                        //S7.SetStringAt(buffer, shiftName, 20, subdirectory.Substring(15));
                        S7.SetStringAt(buffer, shiftName, 40, subdirectory.Substring(15));  // v.4 Changes for customer 28.04.2021 -> 40 Signs
                    }
                    else
                    {
                        //S7.SetStringAt(buffer, 3048, 20, subdirectory.Substring(15));
                        S7.SetStringAt(buffer, 5588, 40, subdirectory.Substring(15));  // v.4 Changes for customer 28.04.2021 -> 40 Signs
                    }
                }
                else
                {
                    //S7.SetStringAt(buffer, shiftName, 20, string.Empty);
                    S7.SetStringAt(buffer, shiftName, 40, string.Empty);  // v.4 Changes for customer 28.04.2021 -> 40 Signs
                }

                //shiftName += 24;
                //shiftId += 24;
                shiftName += 44;    // v.4 Changes for customer 28.04.2021 -> 40 Signs
                shiftId += 44;      // v.4 Changes for customer 28.04.2021 -> 40 Signs
            }
        }

        public static string GetSubDirectoryById(string root, short id)
        {
            string path = string.Empty;
            int idTemp = 0;
            string[] subdirectoryEntries = GetSubDirectories(root);
            foreach (string subdirectory in subdirectoryEntries)
            {
                if (subdirectory.Length >= 14)
                {
                    idTemp = subdirectory.Substring(11, 3).ParseShort();
                    if (idTemp == id)
                    {
                        path = subdirectory;
                    }
                }
            }
            return path;
        }

        public static void CreateDirectory(string root, string folder, ref string path)
        {
            path = root + @"\" + folder;
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            // Create a sub directory
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static string[] GetFilesInDirectory(string root)
        {
            string[] fileEntries = Directory.GetFiles(root);
            return fileEntries;
        }

        public static bool GetFileByName(string root, string filename)
        {
            bool paramOK = false;
            string[] fileEntries = GetFilesInDirectory(root);
            foreach (string file in fileEntries)
            {
                if (file.Contains(filename))
                {
                    paramOK = true;
                }
            }
            return paramOK;
        }

        public static void AssembleDirectoryName(short wkzid, string werkzeugname, ref string folder)
        {
            if (wkzid < 10)
            {
                folder = "00" + wkzid + "_" + werkzeugname;
            }
            else if (wkzid >= 10 & wkzid < 100)
            {
                folder = "0" + wkzid + "_" + werkzeugname;
            }
            else if (wkzid >= 100 & wkzid < 255)
            {
                folder = wkzid + "_" + werkzeugname;
            }
        }

        public static void RenameDirectory(string path1, string path2)
        {
            if (Directory.Exists(path1))
            {
                Directory.Move(path1, path2);
            }
        }

        public static void DeleteDirectory(string path)
        {
            Directory.Delete(path, true);
        }


        public static void AssembleId(short wkzid, ref string wkzidString)
        {
            if (wkzid < 10)
            {
                wkzidString = "00" + wkzid;
            }
            else if (wkzid >= 10 & wkzid < 100)
            {
                wkzidString = "0" + wkzid;
            }
            else if (wkzid >= 100 & wkzid < 255)
            {
                wkzidString = "" + wkzid;
            }
        }

        public static void SetHeartBeat(ref DateTime timestamp, ref bool heartbeat, int difference = 5)
        {
            // Calculate the Timespan since the Last Update from the Client.
            TimeSpan timeSinceLastHeartbeat = DateTime.Now.ToUniversalTime() - timestamp.ToUniversalTime();

            // Set Lable Text depending of the Timespan
            if (timeSinceLastHeartbeat > TimeSpan.FromSeconds(difference))
            {
                timestamp = DateTime.Now;
                if (heartbeat)
                {
                    heartbeat = false;
                }
                else
                {
                    heartbeat = true;
                }
            }
        }
        #endregion
    }
}
