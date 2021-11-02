using Sharp7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinS7Library.Helper;

namespace WinS7Library.Model
{
    public class CommPlcInstance
    {
        /// <summary>
        /// Communication PC <-> PLC
        /// </summary>
        public void ConnectionRun(S7Client client, CommData commData, ServicePlcToPc plcToPc, ServicePcToPlc pcToPlc)
        {
            lock (this)
            {
                var appenders = log4net.LogManager.GetRepository().GetAppenders();
                string appenderNameGlobal = appenders[0].Name;
                string appenderNameRecipe = appenders[commData.N].Name;

                //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameGlobal, @".\\WinS7ClientLogger" + commData.N + ".log");


                /// <summary>
                /// ServicePlcToPc
                /// </summary>
                #region ServicePlcToPc
                //S7Client client = S7Clients[n];
                byte[] buffer = new byte[65536];
                int sizeRead = 0;
                int result = 0;
                string root = @"E:\Recipes";
                string error = string.Empty;

                string comparenceinfo = string.Empty;

                bool heartbeat = pcToPlc.LifeBit;
                DateTime timestamp = commData.LifeBitTimeStamp;


                Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_Service_PlcToPc, 0, commData.DB_Service_PlcToPc_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                //ShowResult(result, client);
                plcToPc.LifeBit = S7.GetBitAt(buffer, 0, 0);
                plcToPc.ErrorStatus = S7.GetIntAt(buffer, 2);
                plcToPc.WKZEinlesen = S7.GetBitAt(buffer, 4, 0);
                plcToPc.ParamsLaden = S7.GetBitAt(buffer, 4, 1);
                plcToPc.SondernKonfig = S7.GetBitAt(buffer, 4, 2);
                plcToPc.ParamsSichern = S7.GetBitAt(buffer, 4, 3);
                plcToPc.DatLoeschen = S7.GetBitAt(buffer, 4, 4);
                plcToPc.AktAnlage = S7.GetDIntAt(buffer, 6);
                plcToPc.AktWerkzeugID = S7.GetIntAt(buffer, 10);
                plcToPc.AktWerkzeugName = S7.GetStringAt(buffer, 12);
                plcToPc.ParamHE = S7.GetIntAt(buffer, 54);
                plcToPc.ParamConfig = S7.GetIntAt(buffer, 56);
                plcToPc.ParamN2 = S7.GetIntAt(buffer, 58);
                plcToPc.ParamWerkzeug = S7.GetIntAt(buffer, 60);
                plcToPc.ParamMWerkzeug = S7.GetIntAt(buffer, 62);
                plcToPc.LoeschWerkzeugID = S7.GetIntAt(buffer, 64);
                plcToPc.AusweissNr = S7.GetDWordAt(buffer, 66);
                plcToPc.AusweissName = S7.GetStringAt(buffer, 70);

                //PlcToPc.LifeBit = S7.GetBitAt(buffer, 0, 0);
                //PlcToPc.ErrorStatus = S7.GetIntAt(buffer, 2);
                //PlcToPc.WKZEinlesen = S7.GetBitAt(buffer, 4, 0);
                //PlcToPc.ParamsLaden = S7.GetBitAt(buffer, 4, 1);
                //PlcToPc.SondernKonfig = S7.GetBitAt(buffer, 4, 2);
                //PlcToPc.ParamsSichern = S7.GetBitAt(buffer, 4, 3);
                //PlcToPc.DatLoeschen = S7.GetBitAt(buffer, 4, 4);
                //PlcToPc.AktAnlage = S7.GetDIntAt(buffer, 6);
                //PlcToPc.AktWerkzeugID = S7.GetIntAt(buffer, 10);
                //PlcToPc.AktWerkzeugName = S7.GetStringAt(buffer, 12);
                //PlcToPc.ParamHE = S7.GetIntAt(buffer, 34);
                //PlcToPc.ParamConfig = S7.GetIntAt(buffer, 36);
                //PlcToPc.ParamN2 = S7.GetIntAt(buffer, 38);
                //PlcToPc.ParamWerkzeug = S7.GetIntAt(buffer, 40);
                //PlcToPc.ParamMWerkzeug = S7.GetIntAt(buffer, 42);
                //PlcToPc.LoeschWerkzeugID = S7.GetIntAt(buffer, 44);
                //PlcToPc.AusweissNr = S7.GetDWordAt(buffer, 46);
                //PlcToPc.AusweissName = S7.GetStringAt(buffer, 50);

                string machineID = plcToPc.AktAnlage.ToString();
                uint ausweissNr = plcToPc.AusweissNr;
                string ausweissName = plcToPc.AusweissName;
                short aktWkzID = plcToPc.AktWerkzeugID;

                #endregion

                //**************************************************
                //Get all recipe folders --->
                if (!plcToPc.WKZEinlesen)
                {
                    pcToPlc.WKZEinlesenFertig = false;
                }

                if (plcToPc.WKZEinlesen & !pcToPlc.WKZEinlesenFertig)
                {

                    Recipes.ToolListClear(ref buffer);

                    Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_Service_WKZ_Liste, 0, commData.DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                    string[] subdirectoryEntries;
                    subdirectoryEntries = Recipes.GetSubDirectories(root);

                    Recipes.ToolListFillWithRecipes(subdirectoryEntries, ref buffer);

                    Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_Service_WKZ_Liste, 0, commData.DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                    //Log
                    commData.LogGlobal.Info("ToolListFillWithRecipes" + " result: " + result);

                    pcToPlc.WKZEinlesenFertig = true;
                }
                //Get all recipe folders <---
                //**************************************************


                //**************************************************
                //Get all recipe params --->
                if (!plcToPc.ParamsLaden)
                {
                    pcToPlc.ParamHEOK = false;
                    pcToPlc.ParamConfigOK = false;
                    pcToPlc.ParamN2OK = false;
                    pcToPlc.ParamWerkzeugOK = false;
                    pcToPlc.ParamMWerkzeugOK = false;
                    pcToPlc.ParamsLadenFertig = false;
                }

                if (plcToPc.ParamsLaden & !pcToPlc.ParamsLadenFertig)
                {
                    string path = string.Empty;

                    //Case 1. No special Configuration for the tool
                    if (!plcToPc.SondernKonfig)
                    {
                        path = Recipes.GetSubDirectoryById(root, plcToPc.AktWerkzeugID);

                        if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                        {
                            //ChangeLogFileName @"e:\\path\\WinS7ClientLogger.log"
                            ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameRecipe, path + "\\WinS7ClientLogger.log");

                            pcToPlc.ParamHEOK = Recipes.GetFileByName(path, "HE.xml");
                            if (pcToPlc.ParamHEOK)
                            {
                                //deserialize "HE.xml"
                                Global.ClearBuffer(ref buffer);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_HE, 0, commData.DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref result);
                                Serializer.DeserializeDatHE(path, ref buffer, ref error);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_HE, 0, commData.DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref result);
                                // Log
                                commData.LogRecipe.Info("Serializer.DeserializeDatHE();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogRecipe.Info("Serializer.DeserializeDatHE();" + " " + aktWkzID + " to PLC " + " result: " + result);
                                commData.LogGlobal.Info("Serializer.DeserializeDatHE();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogGlobal.Info("Serializer.DeserializeDatHE();" + " " + aktWkzID + " to PLC " + " result: " + result);
                            }

                            pcToPlc.ParamConfigOK = Recipes.GetFileByName(path, "Config.xml");
                            if (pcToPlc.ParamConfigOK)
                            {
                                //deserialize "Config.xml"
                                Global.ClearBuffer(ref buffer);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Config, 0, commData.DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref result);
                                Serializer.DeserializeDatConfig(path, ref buffer, ref error);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Config, 0, commData.DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref result);
                                // Log
                                commData.LogRecipe.Info("Serializer.DeserializeDatConfig();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogRecipe.Info("Serializer.DeserializeDatConfig();" + " " + aktWkzID + " to PLC " + " result: " + result);
                                commData.LogGlobal.Info("Serializer.DeserializeDatConfig();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogGlobal.Info("Serializer.DeserializeDatConfig();" + " " + aktWkzID + " to PLC " + " result: " + result);
                            }

                            pcToPlc.ParamN2OK = Recipes.GetFileByName(path, "N2.xml");
                            if (pcToPlc.ParamN2OK)
                            {
                                //deserialize "N2.xml"
                                Global.ClearBuffer(ref buffer);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_N2, 0, commData.DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref result);
                                Serializer.DeserializeDatN2(path, ref buffer, ref error);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_N2, 0, commData.DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref result);
                                // Log
                                commData.LogRecipe.Info("Serializer.DeserializeDatN2();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogRecipe.Info("Serializer.DeserializeDatN2();" + " " + aktWkzID + " to PLC " + " result: " + result);
                                commData.LogGlobal.Info("Serializer.DeserializeDatN2();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogGlobal.Info("Serializer.DeserializeDatN2();" + " " + aktWkzID + " to PLC " + " result: " + result);
                            }

                            pcToPlc.ParamWerkzeugOK = Recipes.GetFileByName(path, "Werkzeug.xml");
                            if (pcToPlc.ParamWerkzeugOK)
                            {
                                //deserialize "Werkzeug.xml"
                                Global.ClearBuffer(ref buffer);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Werkzeug, 0, commData.DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                Serializer.DeserializeDatWerkzeug(path, ref buffer, ref error);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Werkzeug, 0, commData.DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                // Log
                                commData.LogRecipe.Info("Serializer.DeserializeDatWerkzeug();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogRecipe.Info("Serializer.DeserializeDatWerkzeug();" + " " + aktWkzID + " to PLC " + " result: " + result);
                                commData.LogGlobal.Info("Serializer.DeserializeDatWerkzeug();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogGlobal.Info("Serializer.DeserializeDatWerkzeug();" + " " + aktWkzID + " to PLC " + " result: " + result);
                            }

                            pcToPlc.ParamMWerkzeugOK = Recipes.GetFileByName(path, "MWerkzeug_" + machineID + ".xml");
                            if (pcToPlc.ParamMWerkzeugOK)
                            {
                                //deserialize "MWerkzeug_54xxx.xml"
                                Global.ClearBuffer(ref buffer);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_MWerkzeug, 0, commData.DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                Serializer.DeserializeMWerkzeug(path, machineID, ref buffer, ref error);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_MWerkzeug, 0, commData.DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                // Log
                                commData.LogRecipe.Info("Serializer.DeserializeMWerkzeug();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogRecipe.Info("Serializer.DeserializeMWerkzeug();" + " " + aktWkzID + " to PLC " + " result: " + result);
                                commData.LogGlobal.Info("Serializer.DeserializeMWerkzeug();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogGlobal.Info("Serializer.DeserializeMWerkzeug();" + " " + aktWkzID + " to PLC " + " result: " + result);
                            }

                            pcToPlc.ParamsLadenFertig = true;
                        }
                        else
                        {
                            pcToPlc.ParamHEOK = false;
                            pcToPlc.ParamConfigOK = false;
                            pcToPlc.ParamN2OK = false;
                            pcToPlc.ParamWerkzeugOK = false;
                            pcToPlc.ParamMWerkzeugOK = false;
                            pcToPlc.ParamsLadenFertig = true;
                        }
                    }
                    //Case 2. Special Configuration for the tool
                    else
                    {
                        path = Recipes.GetSubDirectoryById(root, plcToPc.ParamHE);
                        if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                        {
                            pcToPlc.ParamHEOK = Recipes.GetFileByName(path, "HE.xml");
                            if (pcToPlc.ParamHEOK)
                            {
                                //deserialize "HE.xml"
                                Global.ClearBuffer(ref buffer);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_HE, 0, commData.DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref result);
                                Serializer.DeserializeDatHE(path, ref buffer, ref error);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_HE, 0, commData.DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref result);
                                // Log
                                commData.LogRecipe.Info("Serializer.DeserializeDatHE();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogRecipe.Info("Serializer.DeserializeDatHE();" + " " + aktWkzID + " to PLC " + " result: " + result);
                                commData.LogGlobal.Info("Serializer.DeserializeDatHE();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogGlobal.Info("Serializer.DeserializeDatHE();" + " " + aktWkzID + " to PLC " + " result: " + result);
                            }
                        }
                        else
                        {
                            pcToPlc.ParamHEOK = false;
                        }

                        path = Recipes.GetSubDirectoryById(root, plcToPc.ParamConfig);
                        if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                        {
                            pcToPlc.ParamConfigOK = Recipes.GetFileByName(path, "Config.xml");
                            if (pcToPlc.ParamConfigOK)
                            {
                                //deserialize "Config.xml"
                                Global.ClearBuffer(ref buffer);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Config, 0, commData.DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref result);
                                Serializer.DeserializeDatConfig(path, ref buffer, ref error);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Config, 0, commData.DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref result);
                                // Log
                                commData.LogRecipe.Info("Serializer.DeserializeDatConfig();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogRecipe.Info("Serializer.DeserializeDatConfig();" + " " + aktWkzID + " to PLC " + " result: " + result);
                                commData.LogGlobal.Info("Serializer.DeserializeDatConfig();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogGlobal.Info("Serializer.DeserializeDatConfig();" + " " + aktWkzID + " to PLC " + " result: " + result);
                            }
                        }
                        else
                        {
                            pcToPlc.ParamConfigOK = false;
                        }

                        path = Recipes.GetSubDirectoryById(root, plcToPc.ParamN2);
                        if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                        {
                            pcToPlc.ParamN2OK = Recipes.GetFileByName(path, "N2.xml");
                            if (pcToPlc.ParamN2OK)
                            {
                                //deserialize "N2.xml"
                                Global.ClearBuffer(ref buffer);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_N2, 0, commData.DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref result);
                                Serializer.DeserializeDatN2(path, ref buffer, ref error);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_N2, 0, commData.DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref result);
                                // Log
                                commData.LogRecipe.Info("Serializer.DeserializeDatN2();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogRecipe.Info("Serializer.DeserializeDatN2();" + " " + aktWkzID + " to PLC " + " result: " + result);
                                commData.LogGlobal.Info("Serializer.DeserializeDatN2();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogGlobal.Info("Serializer.DeserializeDatN2();" + " " + aktWkzID + " to PLC " + " result: " + result);
                            }
                        }
                        else
                        {
                            pcToPlc.ParamN2OK = false;
                        }

                        path = Recipes.GetSubDirectoryById(root, plcToPc.ParamWerkzeug);
                        if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                        {
                            pcToPlc.ParamWerkzeugOK = Recipes.GetFileByName(path, "Werkzeug.xml");
                            if (pcToPlc.ParamWerkzeugOK)
                            {
                                //deserialize "Werkzeug.xml"
                                Global.ClearBuffer(ref buffer);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Werkzeug, 0, commData.DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                Serializer.DeserializeDatWerkzeug(path, ref buffer, ref error);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Werkzeug, 0, commData.DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                // Log
                                commData.LogRecipe.Info("Serializer.DeserializeDatWerkzeug();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogRecipe.Info("Serializer.DeserializeDatWerkzeug();" + " " + aktWkzID + " to PLC " + " result: " + result);
                                commData.LogGlobal.Info("Serializer.DeserializeDatWerkzeug();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogGlobal.Info("Serializer.DeserializeDatWerkzeug();" + " " + aktWkzID + " to PLC " + " result: " + result);
                            }
                        }
                        else
                        {
                            pcToPlc.ParamWerkzeugOK = false;
                        }

                        //Machine params allowed only by actual tool to avoid crash!!!
                        //path = GetSubDirectoryById(root, PlcToPc.ParamMWerkzeug);
                        path = Recipes.GetSubDirectoryById(root, plcToPc.AktWerkzeugID);
                        if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                        {
                            pcToPlc.ParamMWerkzeugOK = Recipes.GetFileByName(path, "MWerkzeug_" + machineID + ".xml");
                            if (pcToPlc.ParamMWerkzeugOK)
                            {
                                //deserialize "MWerkzeug_54xxx.xml"
                                Global.ClearBuffer(ref buffer);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_MWerkzeug, 0, commData.DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                Serializer.DeserializeMWerkzeug(path, machineID, ref buffer, ref error);
                                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_MWerkzeug, 0, commData.DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                // Log
                                commData.LogRecipe.Info("Serializer.DeserializeMWerkzeug();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogRecipe.Info("Serializer.DeserializeMWerkzeug();" + " " + aktWkzID + " to PLC " + " result: " + result);
                                commData.LogGlobal.Info("Serializer.DeserializeMWerkzeug();" + " " + aktWkzID + " from " + path + " error: " + error);
                                commData.LogGlobal.Info("Serializer.DeserializeMWerkzeug();" + " " + aktWkzID + " to PLC " + " result: " + result);
                            }
                        }
                        else
                        {
                            pcToPlc.ParamMWerkzeugOK = false;
                        }

                        pcToPlc.ParamsLadenFertig = true;
                    }
                }
                //Get all recipe params <---
                //**************************************************


                //**************************************************
                //Save all recipe params --->
                if (!plcToPc.ParamsSichern)
                {
                    pcToPlc.ParamsSichernFertig = false;
                }

                if (plcToPc.ParamsSichern & !pcToPlc.ParamsSichernFertig)
                {
                    string path = string.Empty;
                    string halfpath1 = string.Empty;
                    string halfpath2 = string.Empty;
                    string path2 = string.Empty;
                    path = Recipes.GetSubDirectoryById(root, plcToPc.AktWerkzeugID);

                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                    {
                        halfpath1 = path.Substring(0, 15);
                        halfpath2 = path.Substring(15);
                        if (halfpath2 == plcToPc.AktWerkzeugName)
                        {
                            //ChangeLogFileName
                            ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameRecipe, path + "\\WinS7ClientLogger.log");
                            //Log
                            commData.LogRecipe.Info("Save parameters in " + path);
                            commData.LogRecipe.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);
                            commData.LogGlobal.Info("Save parameters in " + path);
                            commData.LogGlobal.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);


                            //Case 1. Save parameters

                            //serialize "HE.xml"
                            DatHE he1 = Serializer.DeserializeDatHE(path, ref buffer, ref error);
                            Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_HE, 0, commData.DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                            DatHE he2 = Serializer.SerializeDatHE(path, buffer, ref error);
                            Comparence.CompareClass(he1, he2, ref comparenceinfo);
                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatHE();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogRecipe.Info(comparenceinfo);
                            commData.LogGlobal.Info("Serializer.SerializeDatHE();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info(comparenceinfo);

                            //serialize "Config.xml"
                            DatConfig config1 = Serializer.DeserializeDatConfig(path, ref buffer, ref error);
                            Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Config, 0, commData.DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                            DatConfig config2 = Serializer.SerializeDatConfig(path, buffer, ref error);
                            Comparence.CompareClass(config1, config2, ref comparenceinfo);
                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatConfig();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogRecipe.Info(comparenceinfo);
                            commData.LogGlobal.Info("Serializer.SerializeDatConfig();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info(comparenceinfo);

                            //serialize "N2.xml"
                            DatN2 n21 = Serializer.DeserializeDatN2(path, ref buffer, ref error);
                            Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_N2, 0, commData.DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                            DatN2 n22 = Serializer.SerializeDatN2(path, buffer, ref error);
                            Comparence.CompareClass(n21, n22, ref comparenceinfo);
                            // Log
                            commData.LogRecipe.Info("Serializer.DeserializeDatN2();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogRecipe.Info(comparenceinfo);
                            commData.LogGlobal.Info("Serializer.DeserializeDatN2();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info(comparenceinfo);

                            //serialize "Werkzeug.xml"
                            DatWerkzeug werkzeug1 = Serializer.DeserializeDatWerkzeug(path, ref buffer, ref error);
                            Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Werkzeug, 0, commData.DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                            DatWerkzeug werkzeug2 = Serializer.SerializeDatWerkzeug(path, buffer, ref error);
                            Comparence.CompareClass(werkzeug1, werkzeug2, ref comparenceinfo);
                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogRecipe.Info(comparenceinfo);
                            commData.LogGlobal.Info("Serializer.SerializeDatWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info(comparenceinfo);

                            //serialize "MWerkzeug_54xxx.xml"
                            DatMWerkzeug mwerkzeug1 = Serializer.DeserializeMWerkzeug(path, machineID, ref buffer, ref error);
                            Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_MWerkzeug, 0, commData.DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                            DatMWerkzeug mwerkzeug2 = Serializer.SerializeDatMWerkzeug(path, machineID, buffer, ref error);
                            Comparence.CompareClass(mwerkzeug1, mwerkzeug2, ref comparenceinfo);
                            // Log
                            commData.LogRecipe.Info("Serializer.DeserializeMWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogRecipe.Info(comparenceinfo);
                            commData.LogGlobal.Info("Serializer.DeserializeMWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info(comparenceinfo);

                            pcToPlc.ParamsSichernFertig = true;
                        }
                        else
                        {
                            //Case 2. Rename folder and save parameters

                            halfpath2 = plcToPc.AktWerkzeugName;
                            path2 = halfpath1 + halfpath2;

                            //ChangeLogFileName
                            ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameRecipe, root + "\\WinS7ClientLogger" + commData.N + ".log");
                            // Log
                            commData.LogRecipe.Info("RenameDirectory " + path + " >>> " + path2);
                            commData.LogRecipe.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);
                            commData.LogGlobal.Info("RenameDirectory " + path + " >>> " + path2);
                            commData.LogGlobal.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                            Recipes.RenameDirectory(path, path2);


                            //ChangeLogFileName
                            ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameRecipe, path2 + "\\WinS7ClientLogger.log");
                            //Log
                            commData.LogRecipe.Info("RenameDirectory " + path + " >>> " + path2);
                            commData.LogRecipe.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);
                            commData.LogGlobal.Info("RenameDirectory " + path + " >>> " + path2);
                            commData.LogGlobal.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                            path = path2;

                            if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                            {
                                //ChangeLogFileName
                                ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameRecipe, path + "\\WinS7ClientLogger.log");
                                //Log save
                                commData.LogRecipe.Info("Save parameters in " + path);
                                commData.LogRecipe.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);
                                commData.LogGlobal.Info("Save parameters in " + path);
                                commData.LogGlobal.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                                //serialize "HE.xml"
                                DatHE he1 = Serializer.DeserializeDatHE(path, ref buffer, ref error);
                                Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_HE, 0, commData.DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                DatHE he2 = Serializer.SerializeDatHE(path, buffer, ref error);
                                Comparence.CompareClass(he1, he2, ref comparenceinfo);
                                // Log
                                commData.LogRecipe.Info("Serializer.SerializeDatHE();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogRecipe.Info(comparenceinfo);
                                commData.LogGlobal.Info("Serializer.SerializeDatHE();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogGlobal.Info(comparenceinfo);

                                //serialize "Config.xml"
                                DatConfig config1 = Serializer.DeserializeDatConfig(path, ref buffer, ref error);
                                Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Config, 0, commData.DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                DatConfig config2 = Serializer.SerializeDatConfig(path, buffer, ref error);
                                Comparence.CompareClass(config1, config2, ref comparenceinfo);
                                // Log
                                commData.LogRecipe.Info("Serializer.SerializeDatConfig();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogRecipe.Info(comparenceinfo);
                                commData.LogGlobal.Info("Serializer.SerializeDatConfig();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogGlobal.Info(comparenceinfo);

                                //serialize "N2.xml"
                                DatN2 n21 = Serializer.DeserializeDatN2(path, ref buffer, ref error);
                                Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_N2, 0, commData.DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                DatN2 n22 = Serializer.SerializeDatN2(path, buffer, ref error);
                                Comparence.CompareClass(n21, n22, ref comparenceinfo);
                                // Log
                                commData.LogRecipe.Info("Serializer.SerializeDatN2();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogRecipe.Info(comparenceinfo);
                                commData.LogGlobal.Info("Serializer.SerializeDatN2();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogGlobal.Info(comparenceinfo);

                                //serialize "Werkzeug.xml"
                                DatWerkzeug werkzeug1 = Serializer.DeserializeDatWerkzeug(path, ref buffer, ref error);
                                Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Werkzeug, 0, commData.DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                DatWerkzeug werkzeug2 = Serializer.SerializeDatWerkzeug(path, buffer, ref error);
                                Comparence.CompareClass(werkzeug1, werkzeug2, ref comparenceinfo);
                                // Log
                                commData.LogRecipe.Info("Serializer.SerializeDatWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogRecipe.Info(comparenceinfo);
                                commData.LogGlobal.Info("Serializer.SerializeDatWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogGlobal.Info(comparenceinfo);

                                //serialize "MWerkzeug_54xxx.xml"
                                DatMWerkzeug mwerkzeug1 = Serializer.DeserializeMWerkzeug(path, machineID, ref buffer, ref error);
                                Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_MWerkzeug, 0, commData.DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                DatMWerkzeug mwerkzeug2 = Serializer.SerializeDatMWerkzeug(path, machineID, buffer, ref error);
                                Comparence.CompareClass(mwerkzeug1, mwerkzeug2, ref comparenceinfo);
                                // Log
                                commData.LogRecipe.Info("Serializer.SerializeDatMWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogRecipe.Info(comparenceinfo);
                                commData.LogGlobal.Info("Serializer.SerializeDatMWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogGlobal.Info(comparenceinfo);
                            }

                            pcToPlc.ParamsSichernFertig = true;

                            //Get all recipe folders
                            Recipes.ToolListClear(ref buffer);

                            Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_Service_WKZ_Liste, 0, commData.DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                            string[] subdirectoryEntries;
                            subdirectoryEntries = Recipes.GetSubDirectories(root);

                            Recipes.ToolListFillWithRecipes(subdirectoryEntries, ref buffer);

                            Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_Service_WKZ_Liste, 0, commData.DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);
                            //Log
                            commData.LogRecipe.Info("ToolListFillWithRecipes" + " result: " + result);
                            commData.LogGlobal.Info("ToolListFillWithRecipes" + " result: " + result);
                        }
                    }
                    else
                    {
                        //Case 3. Create folder and save parameters
                        string folder = string.Empty;
                        Recipes.AssembleDirectoryName(plcToPc.AktWerkzeugID, plcToPc.AktWerkzeugName, ref folder);
                        Recipes.CreateDirectory(root, folder, ref path);

                        //ChangeLogFileName
                        ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameRecipe, path + "\\WinS7ClientLogger.log");
                        // Log
                        commData.LogRecipe.Info("CreateDirectory " + path);
                        commData.LogRecipe.Info("Save parameters in " + path);
                        commData.LogRecipe.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);
                        commData.LogGlobal.Info("CreateDirectory " + path);
                        commData.LogGlobal.Info("Save parameters in " + path);
                        commData.LogGlobal.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                        if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                        {
                            //serialize "HE.xml"
                            Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_HE, 0, commData.DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                            Serializer.SerializeDatHE(path, buffer, ref error);
                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatHE();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info("Serializer.SerializeDatHE();" + " " + aktWkzID + " to " + path + " error: " + error);

                            //serialize "Config.xml"
                            Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Config, 0, commData.DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                            Serializer.SerializeDatConfig(path, buffer, ref error);
                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatConfig();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info("Serializer.SerializeDatConfig();" + " " + aktWkzID + " to " + path + " error: " + error);

                            //serialize "N2.xml"
                            Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_N2, 0, commData.DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                            Serializer.SerializeDatN2(path, buffer, ref error);
                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatN2();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info("Serializer.SerializeDatN2();" + " " + aktWkzID + " to " + path + " error: " + error);

                            //serialize "Werkzeug.xml"
                            Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Werkzeug, 0, commData.DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                            Serializer.SerializeDatWerkzeug(path, buffer, ref error);
                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info("Serializer.SerializeDatWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);

                            //serialize "MWerkzeug_54xxx.xml"
                            Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_MWerkzeug, 0, commData.DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                            Serializer.SerializeDatMWerkzeug(path, machineID, buffer, ref error);
                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatMWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info("Serializer.SerializeDatMWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                        }

                        pcToPlc.ParamsSichernFertig = true;

                        //Get all recipe folders
                        Recipes.ToolListClear(ref buffer);

                        Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_Service_WKZ_Liste, 0, commData.DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                        string[] subdirectoryEntries;
                        subdirectoryEntries = Recipes.GetSubDirectories(root);

                        Recipes.ToolListFillWithRecipes(subdirectoryEntries, ref buffer);

                        Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_Service_WKZ_Liste, 0, commData.DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);
                        //Log
                        commData.LogRecipe.Info("ToolListFillWithRecipes" + " result: " + result);
                        commData.LogGlobal.Info("ToolListFillWithRecipes" + " result: " + result);
                    }

                }
                //Save all recipe params <---
                //**************************************************


                //**************************************************
                //Delete recipe folder --->
                if (!plcToPc.DatLoeschen)
                {
                    pcToPlc.DatLoeschenFertig = false;
                }

                if (plcToPc.DatLoeschen & !pcToPlc.DatLoeschenFertig)
                {
                    string path = string.Empty;
                    path = Recipes.GetSubDirectoryById(root, plcToPc.LoeschWerkzeugID);

                    //ChangeLogFileName
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameRecipe, root + "\\WinS7ClientLogger" + commData.N + ".log");
                    //Log
                    commData.LogRecipe.Info("DeleteDirectory " + path);
                    commData.LogRecipe.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);
                    commData.LogGlobal.Info("DeleteDirectory " + path);
                    commData.LogGlobal.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                    {
                        Recipes.DeleteDirectory(path);
                        //Log
                        commData.LogRecipe.Info("Deleted Directory " + path);
                        commData.LogRecipe.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);
                        commData.LogGlobal.Info("Deleted Directory " + path);
                        commData.LogGlobal.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);
                    }

                    pcToPlc.DatLoeschenFertig = true;

                    //Get all recipe folders
                    Recipes.ToolListClear(ref buffer);

                    Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_Service_WKZ_Liste, 0, commData.DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                    string[] subdirectoryEntries;
                    subdirectoryEntries = Recipes.GetSubDirectories(root);

                    Recipes.ToolListFillWithRecipes(subdirectoryEntries, ref buffer);

                    Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_Service_WKZ_Liste, 0, commData.DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);
                    //Log
                    commData.LogRecipe.Info("ToolListFillWithRecipes" + " result: " + result);
                    commData.LogGlobal.Info("ToolListFillWithRecipes" + " result: " + result);

                }
                //Delete recipe folder <---
                //**************************************************

                //Recipes.SetHeartBeat(ref HeartbeatTimeStamp[n], ref heartbeat, 1);

                Recipes.SetHeartBeat(ref timestamp, ref heartbeat, 1);
                commData.LifeBitTimeStamp = timestamp;
                pcToPlc.LifeBit = heartbeat;


                /// <summary>
                /// ServicePcToPlc
                /// </summary>
                #region ServicePcToPlc
                Array.Clear(buffer, 0, 65536);
                S7.SetBitAt(ref buffer, 0, 0, pcToPlc.LifeBit);
                S7.SetIntAt(buffer, 2, pcToPlc.ErrorStatus);
                S7.SetBitAt(ref buffer, 4, 0, pcToPlc.WKZEinlesenFertig);
                S7.SetBitAt(ref buffer, 4, 1, pcToPlc.ParamsLadenFertig);
                S7.SetBitAt(ref buffer, 4, 3, pcToPlc.ParamsSichernFertig);
                S7.SetBitAt(ref buffer, 4, 4, pcToPlc.DatLoeschenFertig);
                S7.SetBitAt(ref buffer, 5, 0, pcToPlc.ParamHEOK);
                S7.SetBitAt(ref buffer, 5, 1, pcToPlc.ParamConfigOK);
                S7.SetBitAt(ref buffer, 5, 2, pcToPlc.ParamN2OK);
                S7.SetBitAt(ref buffer, 5, 3, pcToPlc.ParamWerkzeugOK);
                S7.SetBitAt(ref buffer, 5, 4, pcToPlc.ParamMWerkzeugOK);

                Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_Service_PcToPlc, 0, commData.DB_Service_PcToPlc_Length, S7Consts.S7WLByte, buffer, ref result);
                //ShowResult(result, client);
                //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameGlobal, @".\\WinS7ClientLogger.log");

                #endregion
            }
        }
    }
}
