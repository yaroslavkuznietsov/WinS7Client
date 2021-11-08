﻿using Sharp7;
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
        public void ConnectionRun(S7Client client, CommData commData, ref ServicePlcToPc plcToPc, ref ServicePcToPlc pcToPlc)
        {
            lock (this)
            {
                var appenders = log4net.LogManager.GetRepository().GetAppenders();
                string appenderNameGlobal = appenders[0].Name;
                string appenderNameRecipe = appenders[commData.N].Name;

                //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameGlobal, @".\\WinS7ClientLogger" + commData.N + ".log");

                CommunicationS7Plc S7Plc = new CommunicationS7Plc(client, commData);

                plcToPc = S7Plc.ReadPlcToPc();


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
                    string[] subdirectoryEntries;
                    subdirectoryEntries = Recipes.GetSubDirectories(root);

                    S7Plc.WriteToolListToPlc(subdirectoryEntries, ref result);

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
                                DatHE datHE = Serializer.DeserializeDatHE(path, ref error);
                                S7Plc.WriteDatHePlc(datHE);

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
                                DatConfig datConfig = Serializer.DeserializeDatConfig(path, ref error);
                                S7Plc.WriteDatConfigPlc(datConfig);

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
                                DatN2 datN2 = Serializer.DeserializeDatN2(path, ref error);
                                S7Plc.WriteDatN2Plc(datN2);

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
                                DatWerkzeug datWerkzeug = Serializer.DeserializeDatWerkzeug(path, ref error);
                                S7Plc.WriteDatWerkzeugPlc(datWerkzeug);

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
                                DatMWerkzeug datMWerkzeug = Serializer.DeserializeMWerkzeug(path, machineID, ref error);
                                S7Plc.WriteDatMWerkzeugPlc(datMWerkzeug);

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
                                DatHE datHE = Serializer.DeserializeDatHE(path, ref error);
                                S7Plc.WriteDatHePlc(datHE);

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
                                DatConfig datConfig = Serializer.DeserializeDatConfig(path, ref error);
                                S7Plc.WriteDatConfigPlc(datConfig);

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
                                DatN2 datN2 = Serializer.DeserializeDatN2(path, ref error);
                                S7Plc.WriteDatN2Plc(datN2);

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
                                DatWerkzeug datWerkzeug = Serializer.DeserializeDatWerkzeug(path, ref error);
                                S7Plc.WriteDatWerkzeugPlc(datWerkzeug);

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
                                DatMWerkzeug datMWerkzeug = Serializer.DeserializeMWerkzeug(path, machineID, ref error);
                                S7Plc.WriteDatMWerkzeugPlc(datMWerkzeug);

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
                            DatHE he1 = Serializer.DeserializeDatHE(path, ref error);
                            DatHE he2 = S7Plc.ReadDatHePlc();
                            Serializer.SerializeDatHE(he2, path, ref error);
                            Comparence.CompareClass(he1, he2, ref comparenceinfo);

                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatHE();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogRecipe.Info(comparenceinfo);
                            commData.LogGlobal.Info("Serializer.SerializeDatHE();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info(comparenceinfo);

                            //serialize "Config.xml"
                            DatConfig config1 = Serializer.DeserializeDatConfig(path, ref error);
                            DatConfig config2 = S7Plc.ReadDatConfigPlc();
                            Serializer.SerializeDatConfig(config2, path, ref error);
                            Comparence.CompareClass(config1, config2, ref comparenceinfo);

                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatConfig();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogRecipe.Info(comparenceinfo);
                            commData.LogGlobal.Info("Serializer.SerializeDatConfig();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info(comparenceinfo);

                            //serialize "N2.xml"
                            DatN2 n21 = Serializer.DeserializeDatN2(path, ref error);
                            DatN2 n22 = S7Plc.ReadDatN2Plc();
                            Serializer.SerializeDatN2(n22, path, ref error);
                            Comparence.CompareClass(n21, n22, ref comparenceinfo);

                            // Log
                            commData.LogRecipe.Info("Serializer.DeserializeDatN2();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogRecipe.Info(comparenceinfo);
                            commData.LogGlobal.Info("Serializer.DeserializeDatN2();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info(comparenceinfo);

                            //serialize "Werkzeug.xml"
                            DatWerkzeug werkzeug1 = Serializer.DeserializeDatWerkzeug(path, ref error);
                            DatWerkzeug werkzeug2 = S7Plc.ReadDatWerkzeugPlc();
                            Serializer.SerializeDatWerkzeug(werkzeug2, path, ref error);
                            Comparence.CompareClass(werkzeug1, werkzeug2, ref comparenceinfo);

                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogRecipe.Info(comparenceinfo);
                            commData.LogGlobal.Info("Serializer.SerializeDatWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info(comparenceinfo);

                            //serialize "MWerkzeug_54xxx.xml"
                            DatMWerkzeug mwerkzeug1 = Serializer.DeserializeMWerkzeug(path, machineID, ref error);
                            DatMWerkzeug mwerkzeug2 = S7Plc.ReadDatMWerkzeugPlc();
                            Serializer.SerializeDatMWerkzeug(mwerkzeug2, path, machineID, ref error);
                            Comparence.CompareClass(mwerkzeug1, mwerkzeug2, ref comparenceinfo);

                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeMWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogRecipe.Info(comparenceinfo);
                            commData.LogGlobal.Info("Serializer.SerializeMWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
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
                                DatHE he1 = Serializer.DeserializeDatHE(path, ref error);
                                DatHE he2 = S7Plc.ReadDatHePlc();
                                Serializer.SerializeDatHE(he2, path, ref error);
                                Comparence.CompareClass(he1, he2, ref comparenceinfo);

                                // Log
                                commData.LogRecipe.Info("Serializer.SerializeDatHE();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogRecipe.Info(comparenceinfo);
                                commData.LogGlobal.Info("Serializer.SerializeDatHE();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogGlobal.Info(comparenceinfo);

                                //serialize "Config.xml"
                                DatConfig config1 = Serializer.DeserializeDatConfig(path, ref error);
                                DatConfig config2 = S7Plc.ReadDatConfigPlc();
                                Serializer.SerializeDatConfig(config2, path, ref error);
                                Comparence.CompareClass(config1, config2, ref comparenceinfo);

                                // Log
                                commData.LogRecipe.Info("Serializer.SerializeDatConfig();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogRecipe.Info(comparenceinfo);
                                commData.LogGlobal.Info("Serializer.SerializeDatConfig();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogGlobal.Info(comparenceinfo);

                                //serialize "N2.xml"
                                DatN2 n21 = Serializer.DeserializeDatN2(path, ref error);
                                DatN2 n22 = S7Plc.ReadDatN2Plc();
                                Serializer.SerializeDatN2(n22, path, ref error);
                                Comparence.CompareClass(n21, n22, ref comparenceinfo);

                                // Log
                                commData.LogRecipe.Info("Serializer.SerializeDatN2();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogRecipe.Info(comparenceinfo);
                                commData.LogGlobal.Info("Serializer.SerializeDatN2();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogGlobal.Info(comparenceinfo);

                                //serialize "Werkzeug.xml"
                                DatWerkzeug werkzeug1 = Serializer.DeserializeDatWerkzeug(path, ref error);
                                DatWerkzeug werkzeug2 = S7Plc.ReadDatWerkzeugPlc();
                                Serializer.SerializeDatWerkzeug(werkzeug2, path, ref error);
                                Comparence.CompareClass(werkzeug1, werkzeug2, ref comparenceinfo);

                                // Log
                                commData.LogRecipe.Info("Serializer.SerializeDatWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogRecipe.Info(comparenceinfo);
                                commData.LogGlobal.Info("Serializer.SerializeDatWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogGlobal.Info(comparenceinfo);

                                //serialize "MWerkzeug_54xxx.xml"
                                DatMWerkzeug mwerkzeug1 = Serializer.DeserializeMWerkzeug(path, machineID, ref error);
                                DatMWerkzeug mwerkzeug2 = S7Plc.ReadDatMWerkzeugPlc();
                                Serializer.SerializeDatMWerkzeug(mwerkzeug2, path, machineID, ref error);
                                Comparence.CompareClass(mwerkzeug1, mwerkzeug2, ref comparenceinfo);

                                // Log
                                commData.LogRecipe.Info("Serializer.SerializeDatMWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogRecipe.Info(comparenceinfo);
                                commData.LogGlobal.Info("Serializer.SerializeDatMWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                                commData.LogGlobal.Info(comparenceinfo);
                            }

                            pcToPlc.ParamsSichernFertig = true;

                            //Get all recipe folders
                            string[] subdirectoryEntries;
                            subdirectoryEntries = Recipes.GetSubDirectories(root);
                            S7Plc.WriteToolListToPlc(subdirectoryEntries, ref result);

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
                            DatHE he = S7Plc.ReadDatHePlc();
                            Serializer.SerializeDatHE(he, path, ref error);

                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatHE();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info("Serializer.SerializeDatHE();" + " " + aktWkzID + " to " + path + " error: " + error);

                            //serialize "Config.xml"
                            DatConfig config = S7Plc.ReadDatConfigPlc();
                            Serializer.SerializeDatConfig(config, path, ref error);

                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatConfig();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info("Serializer.SerializeDatConfig();" + " " + aktWkzID + " to " + path + " error: " + error);

                            //serialize "N2.xml"
                            DatN2 n2 = S7Plc.ReadDatN2Plc();
                            Serializer.SerializeDatN2(n2, path, ref error);

                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatN2();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info("Serializer.SerializeDatN2();" + " " + aktWkzID + " to " + path + " error: " + error);

                            //serialize "Werkzeug.xml"
                            DatWerkzeug datWerkzeug = S7Plc.ReadDatWerkzeugPlc();
                            Serializer.SerializeDatWerkzeug(datWerkzeug, path, ref error);

                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info("Serializer.SerializeDatWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);

                            //serialize "MWerkzeug_54xxx.xml"
                            DatMWerkzeug datMWerkzeug = S7Plc.ReadDatMWerkzeugPlc();
                            Serializer.SerializeDatMWerkzeug(datMWerkzeug, path, machineID, ref error);

                            // Log
                            commData.LogRecipe.Info("Serializer.SerializeDatMWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                            commData.LogGlobal.Info("Serializer.SerializeDatMWerkzeug();" + " " + aktWkzID + " to " + path + " error: " + error);
                        }

                        pcToPlc.ParamsSichernFertig = true;

                        //Get all recipe folders
                        string[] subdirectoryEntries;
                        subdirectoryEntries = Recipes.GetSubDirectories(root);
                        S7Plc.WriteToolListToPlc(subdirectoryEntries, ref result);

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
                    string[] subdirectoryEntries;
                    subdirectoryEntries = Recipes.GetSubDirectories(root);
                    S7Plc.WriteToolListToPlc(subdirectoryEntries, ref result);

                    //Log
                    commData.LogRecipe.Info("ToolListFillWithRecipes" + " result: " + result);
                    commData.LogGlobal.Info("ToolListFillWithRecipes" + " result: " + result);
                }
                //Delete recipe folder <---
                //**************************************************


                //**************************************************
                //Read operational data --->
                if (plcToPc.BetriebsDLaden == false)
                {
                    pcToPlc.BetriebsDLadenFertig = false;
                }

                if (plcToPc.BetriebsDLaden == true & pcToPlc.BetriebsDLadenFertig == false)
                {
                    DatBetrieb datBetriebMain = new DatBetrieb();

                    string path = string.Empty;

                    //Tool HE opeartional data
                    path = Recipes.GetSubDirectoryById(root, plcToPc.AktWerkzeugID);
                    //deserialize "Betrieb.xml"
                    DatBetrieb datBetriebHE = Serializer.DeserializeDatBetrieb(path, ref error);

                    //ChangeLogFileName
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameRecipe, path + "\\WinS7ClientLogger.log");
                    // Log
                    commData.LogRecipe.Info("Serializer.DeserializeDatBetrieb();" + " " + plcToPc.AktWerkzeugID + " from " + path + " error: " + error);
                    commData.LogGlobal.Info("Serializer.DeserializeDatBetrieb();" + " " + plcToPc.AktWerkzeugID + " from " + path + " error: " + error);

                    //Tool OB opeartional data
                    path = Recipes.GetSubDirectoryById(root, plcToPc.AktWerkzeugOB);
                    //deserialize "Betrieb.xml"
                    DatBetrieb datBetriebOB = Serializer.DeserializeDatBetrieb(path, ref error);
                    // Log
                    commData.LogRecipe.Info("Serializer.DeserializeDatBetrieb();" + " " + plcToPc.AktWerkzeugOB + " from " + path + " error: " + error);
                    commData.LogGlobal.Info("Serializer.DeserializeDatBetrieb();" + " " + plcToPc.AktWerkzeugOB + " from " + path + " error: " + error);

                    //Tool UN opeartional data
                    path = Recipes.GetSubDirectoryById(root, plcToPc.AktWerkzeugUN);
                    //deserialize "Betrieb.xml"
                    DatBetrieb datBetriebUN = Serializer.DeserializeDatBetrieb(path, ref error);
                    // Log
                    commData.LogRecipe.Info("Serializer.DeserializeDatBetrieb();" + " " + plcToPc.AktWerkzeugUN + " from " + path + " error: " + error);
                    commData.LogGlobal.Info("Serializer.DeserializeDatBetrieb();" + " " + plcToPc.AktWerkzeugUN + " from " + path + " error: " + error);

                    //Copy operational data to datBetrieb
                    datBetriebMain.StdSollHE = datBetriebHE.StdSollHE;
                    datBetriebMain.StdIstHE = datBetriebHE.StdIstHE;
                    datBetriebMain.StdSollOB = datBetriebOB.StdSollOB;
                    datBetriebMain.StdIstOB = datBetriebOB.StdIstOB;
                    datBetriebMain.StdSollUN = datBetriebUN.StdSollUN;
                    datBetriebMain.StdIstUN = datBetriebUN.StdIstUN;

                    Serializer.DatBetriebToBuffer(datBetriebMain, buffer, ref error);

                    Global.WriteAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Betrieb, 0, commData.DB_DAT_Betrieb_Length, S7Consts.S7WLByte, buffer, ref result);

                    // Log
                    commData.LogRecipe.Info("Serializer.DeserializeDatBetrieb();" + " " + aktWkzID + " to PLC " + " result: " + result);
                    commData.LogGlobal.Info("Serializer.DeserializeDatBetrieb();" + " " + aktWkzID + " to PLC " + " result: " + result);


                    pcToPlc.BetriebsDLadenFertig = true;
                }
                //Read operational data <---
                //**************************************************


                //**************************************************
                //Write operational data --->
                if (plcToPc.BetriebsDSichern == false)
                {
                    pcToPlc.BetriebsDSichernFertig = false;
                }

                if (plcToPc.BetriebsDSichern == true & pcToPlc.BetriebsDSichernFertig == false)
                {
                    Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commData.DB_DAT_Betrieb, 0, commData.DB_DAT_Betrieb_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);

                    // Log
                    commData.LogGlobal.Info("Read operational data from plc" + " result: " + result);

                    DatBetrieb datBetrieb =  Serializer.BufferToDatBetrieb(buffer, ref error);

                    string path = string.Empty;

                    //Tool HE opeartional data
                    path = Recipes.GetSubDirectoryById(root, plcToPc.AktWerkzeugID);

                    //ChangeLogFileName @"e:\\path\\WinS7ClientLogger.log"
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameRecipe, path + "\\WinS7ClientLogger.log");

                    //deserialize "Betrieb.xml"
                    DatBetrieb datBetrieb1 = Serializer.DeserializeDatBetrieb(path, ref error);
                    DatBetrieb datBetrieb2 = Serializer.DeserializeDatBetrieb(path, ref error);

                    datBetrieb2.StdSollHE = datBetrieb.StdSollHE;
                    datBetrieb2.StdIstHE = datBetrieb.StdIstHE;

                    //serialize "Betrieb.xml"
                    Serializer.SerializeDatBetrieb(datBetrieb2, path, ref error);
                    Comparence.CompareClass(datBetrieb1, datBetrieb2, ref comparenceinfo);
                    // Log
                    commData.LogRecipe.Info("Serializer.SerializeDatBetrieb();" + " " + plcToPc.AktWerkzeugID + " to " + path + " error: " + error);
                    commData.LogRecipe.Info(comparenceinfo);
                    commData.LogGlobal.Info("Serializer.SerializeDatBetrieb();" + " " + plcToPc.AktWerkzeugID + " to " + path + " error: " + error);
                    commData.LogGlobal.Info(comparenceinfo);


                    //Tool OB opeartional data
                    path = Recipes.GetSubDirectoryById(root, plcToPc.AktWerkzeugOB);

                    //deserialize "Betrieb.xml"
                    datBetrieb1 = Serializer.DeserializeDatBetrieb(path, ref error);
                    datBetrieb2 = Serializer.DeserializeDatBetrieb(path, ref error);

                    datBetrieb2.StdSollOB = datBetrieb.StdSollOB;
                    datBetrieb2.StdIstOB = datBetrieb.StdIstOB;

                    //serialize "Betrieb.xml"
                    Serializer.SerializeDatBetrieb(datBetrieb2, path, ref error);
                    Comparence.CompareClass(datBetrieb1, datBetrieb2, ref comparenceinfo);
                    // Log
                    commData.LogRecipe.Info("Serializer.SerializeDatBetrieb();" + " " + plcToPc.AktWerkzeugOB + " to " + path + " error: " + error);
                    commData.LogRecipe.Info(comparenceinfo);
                    commData.LogGlobal.Info("Serializer.SerializeDatBetrieb();" + " " + plcToPc.AktWerkzeugOB + " to " + path + " error: " + error);
                    commData.LogGlobal.Info(comparenceinfo);


                    //Tool UN opeartional data
                    path = Recipes.GetSubDirectoryById(root, plcToPc.AktWerkzeugUN);

                    //deserialize "Betrieb.xml"
                    datBetrieb1 = Serializer.DeserializeDatBetrieb(path, ref error);
                    datBetrieb2 = Serializer.DeserializeDatBetrieb(path, ref error);

                    datBetrieb2.StdSollUN = datBetrieb.StdSollUN;
                    datBetrieb2.StdIstUN = datBetrieb.StdIstUN;

                    //serialize "Betrieb.xml"
                    Serializer.SerializeDatBetrieb(datBetrieb2, path, ref error);
                    Comparence.CompareClass(datBetrieb1, datBetrieb2, ref comparenceinfo);
                    // Log
                    commData.LogRecipe.Info("Serializer.SerializeDatBetrieb();" + " " + plcToPc.AktWerkzeugUN + " to " + path + " error: " + error);
                    commData.LogRecipe.Info(comparenceinfo);
                    commData.LogGlobal.Info("Serializer.SerializeDatBetrieb();" + " " + plcToPc.AktWerkzeugUN + " to " + path + " error: " + error);
                    commData.LogGlobal.Info(comparenceinfo);


                    pcToPlc.BetriebsDSichernFertig = true;
                }
                //Write operational data <---
                //**************************************************


                //Recipes.SetHeartBeat(ref HeartbeatTimeStamp[n], ref heartbeat, 1);
                Recipes.SetHeartBeat(ref timestamp, ref heartbeat, 1);
                commData.LifeBitTimeStamp = timestamp;
                pcToPlc.LifeBit = heartbeat;


                /// <summary>
                /// ServicePcToPlc
                /// </summary>
                #region ServicePcToPlc

                S7Plc.WritePcToPlc(pcToPlc);

                //ShowResult(result, client);
                //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderNameGlobal, @".\\WinS7ClientLogger.log");

                #endregion
            }
        }
    }
}
