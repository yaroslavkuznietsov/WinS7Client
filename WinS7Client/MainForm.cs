﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;                                        // Used for writing to a file
using Sharp7;                                           // Sharp7  Client
using System.Timers;
using System.Threading;
using KellermanSoftware.CompareNetObjects;
using WinS7Client.HelperSerializer;
using WinS7Client.Helper;

namespace WinS7Client
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Fields
        /// </summary>
        #region Fields
        private int _ticks;
        private ServiceForm myServiceForm1;
        private ServiceForm myServiceForm2;

        private S7Client[] S7Clients = new S7Client[11];
        private string[] PlcIpAddress = new string[11];
        private string[] PlcRack = new string[11];
        private string[] PlcSlot = new string[11];
        private S7Client.S7CpuInfo[] S7CpuInfos = new S7Client.S7CpuInfo[11];
        private ServicePcToPlc[] ServicePcToPlcs = new ServicePcToPlc[11];
        private ServicePlcToPc[] ServicePlcToPcs = new ServicePlcToPc[11];

        private string[] appenderName = new string[11];


        private Thread tPlc1;
        private Thread tPlc2;
        private Thread tPlc3;

        private Thread tPlc7;

        // Create a logger
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly log4net.ILog log7 = log4net.LogManager.GetLogger("RollingFileAppender7");

        //Thread Timestamps
        private DateTime[] HeartbeatTimeStamp = new DateTime[11];

        
        private const string PlcInfoToolTip = "IP-Address: IPv4 \nS71200/1500: Rack=0, Slot=0/1 \nS7300: Rack=0, Slot=2 \nS7400/WinAC See HW Config";

        //DB Numbers
        private const int DB_DAT_HE = 7000;
        private const int DB_DAT_Config = 7001;
        private const int DB_DAT_N2 = 7002;
        private const int DB_DAT_Werkzeug = 7003;
        private const int DB_DAT_MWerkzeug = 7004;
        private const int DB_Service_WKZ_Liste = 7005;
        private const int DB_Service_PlcToPc = 7006;
        private const int DB_Service_PcToPlc = 7007;

        //DB Length in bytes
        private const int DB_DAT_HE_Length = 240;
        private const int DB_DAT_Config_Length = 2796;
        private const int DB_DAT_N2_Length = 640;
        private const int DB_DAT_Werkzeug_Length = 240;
        private const int DB_DAT_MWerkzeug_Length = 40;
        private const int DB_Service_WKZ_Liste_Length = 3072;
        private const int DB_Service_PlcToPc_Length = 102;
        private const int DB_Service_PcToPlc_Length = 6;

        #endregion


        /// <summary>
        /// MainForm Construction
        /// </summary>
        #region MainForm Construction
        public MainForm()
        {
            InitializeComponent();
            //TimerForm.Start();

            myServiceForm1 = new ServiceForm();
            myServiceForm2 = new ServiceForm();
        } 
        #endregion


        private void MainForm_Load(object sender, EventArgs e)
        {
            Initialization();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tPlc1.Abort();
            tPlc2.Abort();
            tPlc3.Abort();

            tPlc7.Abort();

            tPlc1.Join();
            tPlc2.Join();
            tPlc3.Join();

            tPlc7.Join();
        }







        /// <summary>
        /// Threads
        /// </summary>
        #region Threads
        private void Plc1()
        {
        }

        private void Plc2()
        {
        }



        public void Plc3()
        {
            int n = 3;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {
                        /// <summary>
                        /// ServicePlcToPc
                        /// </summary>
                        #region ServicePlcToPc
                            S7Client client = S7Clients[n];
                            byte[] buffer = new byte[65536];
                            int sizeRead = 0;
                            int result = 0;
                            string root = @"E:\Recipes";
                            string error = string.Empty;

                            string comparenceinfo = string.Empty;

                            bool heartbeat = ServicePcToPlcs[n].LifeBit;
                            DateTime timestamp = HeartbeatTimeStamp[n];


                            ReadAreaPlc(client, S7Consts.S7AreaDB, DB_Service_PlcToPc, 0, DB_Service_PlcToPc_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                            ServicePlcToPcs[n].LifeBit = S7.GetBitAt(buffer, 0, 0);
                            ServicePlcToPcs[n].ErrorStatus = S7.GetIntAt(buffer, 2);
                            ServicePlcToPcs[n].WKZEinlesen = S7.GetBitAt(buffer, 4, 0);
                            ServicePlcToPcs[n].ParamsLaden = S7.GetBitAt(buffer, 4, 1);
                            ServicePlcToPcs[n].SondernKonfig = S7.GetBitAt(buffer, 4, 2);
                            ServicePlcToPcs[n].ParamsSichern = S7.GetBitAt(buffer, 4, 3);
                            ServicePlcToPcs[n].DatLoeschen = S7.GetBitAt(buffer, 4, 4);
                            ServicePlcToPcs[n].AktAnlage = S7.GetDIntAt(buffer, 6);
                            ServicePlcToPcs[n].AktWerkzeugID = S7.GetIntAt(buffer, 10);
                            ServicePlcToPcs[n].AktWerkzeugName = S7.GetStringAt(buffer, 12);
                            ServicePlcToPcs[n].ParamHE = S7.GetIntAt(buffer, 34);
                            ServicePlcToPcs[n].ParamConfig = S7.GetIntAt(buffer, 36);
                            ServicePlcToPcs[n].ParamN2 = S7.GetIntAt(buffer, 38);
                            ServicePlcToPcs[n].ParamWerkzeug = S7.GetIntAt(buffer, 40);
                            ServicePlcToPcs[n].ParamMWerkzeug = S7.GetIntAt(buffer, 42);
                            ServicePlcToPcs[n].LoeschWerkzeugID = S7.GetIntAt(buffer, 44);
                            ServicePlcToPcs[n].AusweissNr = S7.GetDWordAt(buffer, 46);
                            ServicePlcToPcs[n].AusweissName = S7.GetStringAt(buffer, 50);

                            string machineID = ServicePlcToPcs[n].AktAnlage.ToString();
                            uint ausweissNr = ServicePlcToPcs[n].AusweissNr;
                            string ausweissName = ServicePlcToPcs[n].AusweissName;

                            #endregion



                            //**************************************************
                            //Get all recipe folders --->
                            if (!ServicePlcToPcs[n].WKZEinlesen)
                            {
                                ServicePcToPlcs[n].WKZEinlesenFertig = false;
                            }

                            if (ServicePlcToPcs[n].WKZEinlesen & !ServicePcToPlcs[n].WKZEinlesenFertig)
                            {

                                ToolListClear(ref buffer);

                                WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                                string[] subdirectoryEntries;
                                subdirectoryEntries = GetSubDirectories(root);

                                ToolListFillWithRecipes(subdirectoryEntries, ref buffer);

                                //Log create directory
                                log.Info("ToolListFillWithRecipes");

                                WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                                ServicePcToPlcs[n].WKZEinlesenFertig = true;
                            }
                        //Get all recipe folders <---
                        //**************************************************


                        //**************************************************
                        //Get all recipe params --->
                        if (!ServicePlcToPcs[n].ParamsLaden)
                            {
                                ServicePcToPlcs[n].ParamHEOK = false;
                                ServicePcToPlcs[n].ParamConfigOK = false;
                                ServicePcToPlcs[n].ParamN2OK = false;
                                ServicePcToPlcs[n].ParamWerkzeugOK = false;
                                ServicePcToPlcs[n].ParamMWerkzeugOK = false;
                                ServicePcToPlcs[n].ParamsLadenFertig = false;
                            }

                            if (ServicePlcToPcs[n].ParamsLaden & !ServicePcToPlcs[n].ParamsLadenFertig)
                            {
                                string path = string.Empty;

                            //Case 1. No special Configuration for the tool
                            if (!ServicePlcToPcs[n].SondernKonfig)
                                {
                                    path = GetSubDirectoryById(root, ServicePlcToPcs[n].AktWerkzeugID);

                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        ServicePcToPlcs[n].ParamHEOK = GetFileByName(path, "HE.xml");
                                        if (ServicePcToPlcs[n].ParamHEOK)
                                        {
                                            //deserialize "HE.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatHE(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref result);
                                            if (log.IsDebugEnabled)
                                            {
                                                //var appenderNames = log4net.LogManager.GetRepository().GetAppenders();
                                                //string appenderName = appenderNames[n].Name;

                                                //ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[n].ToString(), path);
                                                log.Debug("Serializer.DeserializeDatHE(path, ref buffer, ref error);");
                                            }
                                        }

                                        ServicePcToPlcs[n].ParamConfigOK = GetFileByName(path, "Config.xml");
                                        if (ServicePcToPlcs[n].ParamConfigOK)
                                        {
                                            //deserialize "Config.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatConfig(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }

                                        ServicePcToPlcs[n].ParamN2OK = GetFileByName(path, "N2.xml");
                                        if (ServicePcToPlcs[n].ParamN2OK)
                                        {
                                            //deserialize "N2.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatN2(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }

                                        ServicePcToPlcs[n].ParamWerkzeugOK = GetFileByName(path, "Werkzeug.xml");
                                        if (ServicePcToPlcs[n].ParamWerkzeugOK)
                                        {
                                            //deserialize "Werkzeug.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatWerkzeug(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }

                                        ServicePcToPlcs[n].ParamMWerkzeugOK = GetFileByName(path, "MWerkzeug_" + machineID + ".xml");
                                        if (ServicePcToPlcs[n].ParamMWerkzeugOK)
                                        {
                                            //deserialize "MWerkzeug_54xxx.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeMWerkzeug(path, machineID, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }

                                        ServicePcToPlcs[n].ParamsLadenFertig = true;
                                    }
                                    else
                                    {
                                        ServicePcToPlcs[n].ParamHEOK = false;
                                        ServicePcToPlcs[n].ParamConfigOK = false;
                                        ServicePcToPlcs[n].ParamN2OK = false;
                                        ServicePcToPlcs[n].ParamWerkzeugOK = false;
                                        ServicePcToPlcs[n].ParamMWerkzeugOK = false;
                                        ServicePcToPlcs[n].ParamsLadenFertig = true;
                                    }
                                }
                            //Case 2. Special Configuration for the tool
                            else
                                {
                                    path = GetSubDirectoryById(root, ServicePlcToPcs[n].ParamHE);
                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        ServicePcToPlcs[n].ParamHEOK = GetFileByName(path, "HE.xml");
                                        if (ServicePcToPlcs[n].ParamHEOK)
                                        {
                                            //deserialize "HE.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatHE(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }
                                    }
                                    else
                                    {
                                        ServicePcToPlcs[n].ParamHEOK = false;
                                    }

                                    path = GetSubDirectoryById(root, ServicePlcToPcs[n].ParamConfig);
                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        ServicePcToPlcs[n].ParamConfigOK = GetFileByName(path, "Config.xml");
                                        if (ServicePcToPlcs[n].ParamConfigOK)
                                        {
                                            //deserialize "Config.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatConfig(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }
                                    }
                                    else
                                    {
                                        ServicePcToPlcs[n].ParamConfigOK = false;
                                    }

                                    path = GetSubDirectoryById(root, ServicePlcToPcs[n].ParamN2);
                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        ServicePcToPlcs[n].ParamN2OK = GetFileByName(path, "N2.xml");
                                        if (ServicePcToPlcs[n].ParamN2OK)
                                        {
                                            //deserialize "N2.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatN2(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref result);

                                        }
                                    }
                                    else
                                    {
                                        ServicePcToPlcs[n].ParamN2OK = false;
                                    }

                                    path = GetSubDirectoryById(root, ServicePlcToPcs[n].ParamWerkzeug);
                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        ServicePcToPlcs[n].ParamWerkzeugOK = GetFileByName(path, "Werkzeug.xml");
                                        if (ServicePcToPlcs[n].ParamWerkzeugOK)
                                        {
                                            //deserialize "Werkzeug.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatWerkzeug(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }
                                    }
                                    else
                                    {
                                        ServicePcToPlcs[n].ParamWerkzeugOK = false;
                                    }

                                    //Machine params allowed only by actual tool to avoid crash!!!
                                    //path = GetSubDirectoryById(root, ServicePlcToPcs[n].ParamMWerkzeug);
                                    path = GetSubDirectoryById(root, ServicePlcToPcs[n].AktWerkzeugID);
                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        ServicePcToPlcs[n].ParamMWerkzeugOK = GetFileByName(path, "MWerkzeug_" + machineID + ".xml");
                                        if (ServicePcToPlcs[n].ParamMWerkzeugOK)
                                        {
                                        //deserialize "MWerkzeug_54xxx.xml"
                                        ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeMWerkzeug(path, machineID, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }
                                    }
                                    else
                                    {
                                        ServicePcToPlcs[n].ParamMWerkzeugOK = false;
                                    }

                                    ServicePcToPlcs[n].ParamsLadenFertig = true;
                                }
                            }
                        //Get all recipe params <---
                        //**************************************************


                        //**************************************************
                        //Save all recipe params --->
                        if (!ServicePlcToPcs[n].ParamsSichern)
                            {
                                ServicePcToPlcs[n].ParamsSichernFertig = false;
                            }

                            if (ServicePlcToPcs[n].ParamsSichern & !ServicePcToPlcs[n].ParamsSichernFertig)
                            {
                                string path = string.Empty;
                                string halfpath1 = string.Empty;
                                string halfpath2 = string.Empty;
                                string path2 = string.Empty;
                                path = GetSubDirectoryById(root, ServicePlcToPcs[n].AktWerkzeugID);

                                if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                {
                                    halfpath1 = path.Substring(0, 15);
                                    halfpath2 = path.Substring(15);
                                    if (halfpath2 == ServicePlcToPcs[n].AktWerkzeugName)
                                    {
                                        //Log save
                                        log.Info("Save parameters in " + path);
                                        //Log actual user + card
                                        log.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                                        //Case 1. Save parameters
                                        //serialize "HE.xml"
                                        DatHE he1 = Serializer.DeserializeDatHE(path, ref buffer, ref error);
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        DatHE he2 = Serializer.SerializeDatHE(path, buffer, ref error);
                                        Comparence.CompareClass(he1, he2, ref comparenceinfo);
                                        log.Info(comparenceinfo);

                                        //serialize "Config.xml"
                                        DatConfig config1 = Serializer.DeserializeDatConfig(path, ref buffer, ref error);
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        DatConfig config2 = Serializer.SerializeDatConfig(path, buffer, ref error);
                                        Comparence.CompareClass(config1, config2, ref comparenceinfo);
                                        log.Info(comparenceinfo);

                                        //serialize "N2.xml"
                                        DatN2 n21 = Serializer.DeserializeDatN2(path, ref buffer, ref error);
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        DatN2 n22 = Serializer.SerializeDatN2(path, buffer, ref error);
                                        Comparence.CompareClass(n21, n22, ref comparenceinfo);
                                        log.Info(comparenceinfo);

                                        //serialize "Werkzeug.xml"
                                        DatWerkzeug werkzeug1 = Serializer.DeserializeDatWerkzeug(path, ref buffer, ref error);
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        DatWerkzeug werkzeug2 = Serializer.SerializeDatWerkzeug(path, buffer, ref error);
                                        Comparence.CompareClass(werkzeug1, werkzeug2, ref comparenceinfo);
                                        log.Info(comparenceinfo);

                                        //serialize "MWerkzeug_54xxx.xml"
                                        DatMWerkzeug mwerkzeug1 = Serializer.DeserializeMWerkzeug(path, machineID, ref buffer, ref error);
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        DatMWerkzeug mwerkzeug2 = Serializer.SerializeDatMWerkzeug(path, machineID, buffer, ref error);
                                        Comparence.CompareClass(mwerkzeug1, mwerkzeug2, ref comparenceinfo);
                                        log.Info(comparenceinfo);

                                        ServicePcToPlcs[n].ParamsSichernFertig = true;
                                    }
                                    else
                                    {
                                        //Case 2. Rename folder and save parameters
                                        halfpath2 = ServicePlcToPcs[n].AktWerkzeugName;
                                        path2 = halfpath1 + halfpath2;
                                        RenameDirectory(path, path2);
                                        log.Info("RenameDirectory " + path + " >>> " + path2);
                                        //Log actual user + card
                                        log.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                                        path = path2;

                                        if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                        {
                                            //Log save
                                            log.Info("Save parameters in " + path);
                                            //Log actual user + card
                                            log.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                                            //serialize "HE.xml"
                                            DatHE he1 = Serializer.DeserializeDatHE(path, ref buffer, ref error);
                                            ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                            DatHE he2 = Serializer.SerializeDatHE(path, buffer, ref error);
                                            Comparence.CompareClass(he1, he2, ref comparenceinfo);
                                            log.Info(comparenceinfo);

                                            //serialize "Config.xml"
                                            DatConfig config1 = Serializer.DeserializeDatConfig(path, ref buffer, ref error);
                                            ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                            DatConfig config2 = Serializer.SerializeDatConfig(path, buffer, ref error);
                                            Comparence.CompareClass(config1, config2, ref comparenceinfo);
                                            log.Info(comparenceinfo);

                                            //serialize "N2.xml"
                                            DatN2 n21 = Serializer.DeserializeDatN2(path, ref buffer, ref error);
                                            ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                            DatN2 n22 = Serializer.SerializeDatN2(path, buffer, ref error);
                                            Comparence.CompareClass(n21, n22, ref comparenceinfo);
                                            log.Info(comparenceinfo);

                                            //serialize "Werkzeug.xml"
                                            DatWerkzeug werkzeug1 = Serializer.DeserializeDatWerkzeug(path, ref buffer, ref error);
                                            ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                            DatWerkzeug werkzeug2 = Serializer.SerializeDatWerkzeug(path, buffer, ref error);
                                            Comparence.CompareClass(werkzeug1, werkzeug2, ref comparenceinfo);
                                            log.Info(comparenceinfo);

                                            //serialize "MWerkzeug_54xxx.xml"
                                            DatMWerkzeug mwerkzeug1 = Serializer.DeserializeMWerkzeug(path, machineID, ref buffer, ref error);
                                            ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                            DatMWerkzeug mwerkzeug2 = Serializer.SerializeDatMWerkzeug(path, machineID, buffer, ref error);
                                            Comparence.CompareClass(mwerkzeug1, mwerkzeug2, ref comparenceinfo);
                                            log.Info(comparenceinfo);
                                        }

                                        ServicePcToPlcs[n].ParamsSichernFertig = true;

                                        //Get all recipe folders
                                        ToolListClear(ref buffer);

                                        WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                                        string[] subdirectoryEntries;
                                        subdirectoryEntries = GetSubDirectories(root);

                                        ToolListFillWithRecipes(subdirectoryEntries, ref buffer);

                                        //Log create directory
                                        log.Info("ToolListFillWithRecipes");

                                        WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);
                                    }
                                }
                                else
                                {
                                    //Case 3. Create folder and save parameters
                                    string folder = string.Empty;
                                    AssembleDirectoryName(ServicePlcToPcs[n].AktWerkzeugID, ServicePlcToPcs[n].AktWerkzeugName, ref folder);
                                    CreateDirectory(root, folder, ref path);

                                    //Log create directory
                                    log.Info("CreateDirectory " + path);
                                    //Log save
                                    log.Info("Save parameters in " + path);
                                    //Log actual user + card
                                    log.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        //serialize "HE.xml"
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        Serializer.SerializeDatHE(path, buffer, ref error);

                                        //serialize "Config.xml"
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        Serializer.SerializeDatConfig(path, buffer, ref error);

                                        //serialize "N2.xml"
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        Serializer.SerializeDatN2(path, buffer, ref error);

                                        //serialize "Werkzeug.xml"
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        Serializer.SerializeDatWerkzeug(path, buffer, ref error);

                                        //serialize "MWerkzeug_54xxx.xml"
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        Serializer.SerializeDatMWerkzeug(path, machineID, buffer, ref error);
                                    }

                                    ServicePcToPlcs[n].ParamsSichernFertig = true;

                                    //Get all recipe folders
                                    ToolListClear(ref buffer);

                                    WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                                    string[] subdirectoryEntries;
                                    subdirectoryEntries = GetSubDirectories(root);

                                    ToolListFillWithRecipes(subdirectoryEntries, ref buffer);

                                    //Log create directory
                                    log.Info("ToolListFillWithRecipes");

                                    WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);
                                }

                            }
                        //Save all recipe params <---
                        //**************************************************


                        //**************************************************
                        //Delete recipe folder --->
                        if (!ServicePlcToPcs[n].DatLoeschen)
                            {
                                ServicePcToPlcs[n].DatLoeschenFertig = false;
                            }

                            if (ServicePlcToPcs[n].DatLoeschen & !ServicePcToPlcs[n].DatLoeschenFertig)
                            {
                                string path = string.Empty;
                                path = GetSubDirectoryById(root, ServicePlcToPcs[n].LoeschWerkzeugID);

                                if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                {
                                    DeleteDirectory(path);
                                }

                                //Log create directory
                                log.Info("DeleteDirectory " + path);
                                //Log actual user + card
                                log.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                                ServicePcToPlcs[n].DatLoeschenFertig = true;

                                //Get all recipe folders
                                ToolListClear(ref buffer);

                                WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                                string[] subdirectoryEntries;
                                subdirectoryEntries = GetSubDirectories(root);

                                ToolListFillWithRecipes(subdirectoryEntries, ref buffer);

                                //Log create directory
                                log.Info("ToolListFillWithRecipes");

                                WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                            }
                            //Delete recipe folder <---
                            //**************************************************



                            SetHeartBeat(ref HeartbeatTimeStamp[n], ref heartbeat, 1);
                            ServicePcToPlcs[n].LifeBit = heartbeat;


                        /// <summary>
                        /// ServicePcToPlc
                        /// </summary>
                            #region ServicePcToPlc
                            Array.Clear(buffer, 0, 65536);
                            S7.SetBitAt(ref buffer, 0, 0, ServicePcToPlcs[n].LifeBit);
                            S7.SetIntAt(buffer, 2, ServicePcToPlcs[n].ErrorStatus);
                            S7.SetBitAt(ref buffer, 4, 0, ServicePcToPlcs[n].WKZEinlesenFertig);
                            S7.SetBitAt(ref buffer, 4, 1, ServicePcToPlcs[n].ParamsLadenFertig);
                            S7.SetBitAt(ref buffer, 4, 3, ServicePcToPlcs[n].ParamsSichernFertig);
                            S7.SetBitAt(ref buffer, 4, 4, ServicePcToPlcs[n].DatLoeschenFertig);
                            S7.SetBitAt(ref buffer, 5, 0, ServicePcToPlcs[n].ParamHEOK);
                            S7.SetBitAt(ref buffer, 5, 1, ServicePcToPlcs[n].ParamConfigOK);
                            S7.SetBitAt(ref buffer, 5, 2, ServicePcToPlcs[n].ParamN2OK);
                            S7.SetBitAt(ref buffer, 5, 3, ServicePcToPlcs[n].ParamWerkzeugOK);
                            S7.SetBitAt(ref buffer, 5, 4, ServicePcToPlcs[n].ParamMWerkzeugOK);

                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_PcToPlc, 0, DB_Service_PcToPlc_Length, S7Consts.S7WLByte, buffer, ref result);

                            

                        #endregion
                    }
                    });


                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
        }

        public void Plc7()
        {
            int n = 7;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {
                            /// <summary>
                            /// ServicePlcToPc
                            /// </summary>
                            #region ServicePlcToPc
                            S7Client client = S7Clients[n];
                            byte[] buffer = new byte[65536];
                            int sizeRead = 0;
                            int result = 0;
                            string root = @"E:\Recipes";
                            string error = string.Empty;

                            string comparenceinfo = string.Empty;

                            bool heartbeat = ServicePcToPlcs[n].LifeBit;
                            DateTime timestamp = HeartbeatTimeStamp[n];


                            ReadAreaPlc(client, S7Consts.S7AreaDB, DB_Service_PlcToPc, 0, DB_Service_PlcToPc_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                            ServicePlcToPcs[n].LifeBit = S7.GetBitAt(buffer, 0, 0);
                            ServicePlcToPcs[n].ErrorStatus = S7.GetIntAt(buffer, 2);
                            ServicePlcToPcs[n].WKZEinlesen = S7.GetBitAt(buffer, 4, 0);
                            ServicePlcToPcs[n].ParamsLaden = S7.GetBitAt(buffer, 4, 1);
                            ServicePlcToPcs[n].SondernKonfig = S7.GetBitAt(buffer, 4, 2);
                            ServicePlcToPcs[n].ParamsSichern = S7.GetBitAt(buffer, 4, 3);
                            ServicePlcToPcs[n].DatLoeschen = S7.GetBitAt(buffer, 4, 4);
                            ServicePlcToPcs[n].AktAnlage = S7.GetDIntAt(buffer, 6);
                            ServicePlcToPcs[n].AktWerkzeugID = S7.GetIntAt(buffer, 10);
                            ServicePlcToPcs[n].AktWerkzeugName = S7.GetStringAt(buffer, 12);
                            ServicePlcToPcs[n].ParamHE = S7.GetIntAt(buffer, 34);
                            ServicePlcToPcs[n].ParamConfig = S7.GetIntAt(buffer, 36);
                            ServicePlcToPcs[n].ParamN2 = S7.GetIntAt(buffer, 38);
                            ServicePlcToPcs[n].ParamWerkzeug = S7.GetIntAt(buffer, 40);
                            ServicePlcToPcs[n].ParamMWerkzeug = S7.GetIntAt(buffer, 42);
                            ServicePlcToPcs[n].LoeschWerkzeugID = S7.GetIntAt(buffer, 44);
                            ServicePlcToPcs[n].AusweissNr = S7.GetDWordAt(buffer, 46);
                            ServicePlcToPcs[n].AusweissName = S7.GetStringAt(buffer, 50);

                            string machineID = ServicePlcToPcs[n].AktAnlage.ToString();
                            uint ausweissNr = ServicePlcToPcs[n].AusweissNr;
                            string ausweissName = ServicePlcToPcs[n].AusweissName;

                            #endregion



                            //**************************************************
                            //Get all recipe folders --->
                            if (!ServicePlcToPcs[n].WKZEinlesen)
                            {
                                ServicePcToPlcs[n].WKZEinlesenFertig = false;
                            }

                            if (ServicePlcToPcs[n].WKZEinlesen & !ServicePcToPlcs[n].WKZEinlesenFertig)
                            {

                                ToolListClear(ref buffer);

                                WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                                string[] subdirectoryEntries;
                                subdirectoryEntries = GetSubDirectories(root);

                                ToolListFillWithRecipes(subdirectoryEntries, ref buffer);

                                //Log save
                                //log.Info("ToolListFillWithRecipes");

                                WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                                ServicePcToPlcs[n].WKZEinlesenFertig = true;
                            }
                            //Get all recipe folders <---
                            //**************************************************


                            //**************************************************
                            //Get all recipe params --->
                            if (!ServicePlcToPcs[n].ParamsLaden)
                            {
                                ServicePcToPlcs[n].ParamHEOK = false;
                                ServicePcToPlcs[n].ParamConfigOK = false;
                                ServicePcToPlcs[n].ParamN2OK = false;
                                ServicePcToPlcs[n].ParamWerkzeugOK = false;
                                ServicePcToPlcs[n].ParamMWerkzeugOK = false;
                                ServicePcToPlcs[n].ParamsLadenFertig = false;
                            }

                            if (ServicePlcToPcs[n].ParamsLaden & !ServicePcToPlcs[n].ParamsLadenFertig)
                            {
                                string path = string.Empty;

                                //Case 1. No special Configuration for the tool
                                if (!ServicePlcToPcs[n].SondernKonfig)
                                {
                                    path = GetSubDirectoryById(root, ServicePlcToPcs[n].AktWerkzeugID);

                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        ServicePcToPlcs[n].ParamHEOK = GetFileByName(path, "HE.xml");
                                        if (ServicePcToPlcs[n].ParamHEOK)
                                        {
                                            //deserialize "HE.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatHE(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref result);
                                            if (log7.IsDebugEnabled)
                                            {
                                                ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[n].ToString(), path + "\\WinS7ClientLogger.log");
                                                log7.Debug("Serializer.DeserializeDatHE(path, ref buffer, ref error);");
                                            }
                                        }

                                        ServicePcToPlcs[n].ParamConfigOK = GetFileByName(path, "Config.xml");
                                        if (ServicePcToPlcs[n].ParamConfigOK)
                                        {
                                            //deserialize "Config.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatConfig(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }

                                        ServicePcToPlcs[n].ParamN2OK = GetFileByName(path, "N2.xml");
                                        if (ServicePcToPlcs[n].ParamN2OK)
                                        {
                                            //deserialize "N2.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatN2(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }

                                        ServicePcToPlcs[n].ParamWerkzeugOK = GetFileByName(path, "Werkzeug.xml");
                                        if (ServicePcToPlcs[n].ParamWerkzeugOK)
                                        {
                                            //deserialize "Werkzeug.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatWerkzeug(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }

                                        ServicePcToPlcs[n].ParamMWerkzeugOK = GetFileByName(path, "MWerkzeug_" + machineID + ".xml");
                                        if (ServicePcToPlcs[n].ParamMWerkzeugOK)
                                        {
                                            //deserialize "MWerkzeug_54xxx.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeMWerkzeug(path, machineID, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }

                                        ServicePcToPlcs[n].ParamsLadenFertig = true;
                                    }
                                    else
                                    {
                                        ServicePcToPlcs[n].ParamHEOK = false;
                                        ServicePcToPlcs[n].ParamConfigOK = false;
                                        ServicePcToPlcs[n].ParamN2OK = false;
                                        ServicePcToPlcs[n].ParamWerkzeugOK = false;
                                        ServicePcToPlcs[n].ParamMWerkzeugOK = false;
                                        ServicePcToPlcs[n].ParamsLadenFertig = true;
                                    }
                                }
                                //Case 2. Special Configuration for the tool
                                else
                                {
                                    path = GetSubDirectoryById(root, ServicePlcToPcs[n].ParamHE);
                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        ServicePcToPlcs[n].ParamHEOK = GetFileByName(path, "HE.xml");
                                        if (ServicePcToPlcs[n].ParamHEOK)
                                        {
                                            //deserialize "HE.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatHE(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }
                                    }
                                    else
                                    {
                                        ServicePcToPlcs[n].ParamHEOK = false;
                                    }

                                    path = GetSubDirectoryById(root, ServicePlcToPcs[n].ParamConfig);
                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        ServicePcToPlcs[n].ParamConfigOK = GetFileByName(path, "Config.xml");
                                        if (ServicePcToPlcs[n].ParamConfigOK)
                                        {
                                            //deserialize "Config.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatConfig(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }
                                    }
                                    else
                                    {
                                        ServicePcToPlcs[n].ParamConfigOK = false;
                                    }

                                    path = GetSubDirectoryById(root, ServicePlcToPcs[n].ParamN2);
                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        ServicePcToPlcs[n].ParamN2OK = GetFileByName(path, "N2.xml");
                                        if (ServicePcToPlcs[n].ParamN2OK)
                                        {
                                            //deserialize "N2.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatN2(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref result);

                                        }
                                    }
                                    else
                                    {
                                        ServicePcToPlcs[n].ParamN2OK = false;
                                    }

                                    path = GetSubDirectoryById(root, ServicePlcToPcs[n].ParamWerkzeug);
                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        ServicePcToPlcs[n].ParamWerkzeugOK = GetFileByName(path, "Werkzeug.xml");
                                        if (ServicePcToPlcs[n].ParamWerkzeugOK)
                                        {
                                            //deserialize "Werkzeug.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeDatWerkzeug(path, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }
                                    }
                                    else
                                    {
                                        ServicePcToPlcs[n].ParamWerkzeugOK = false;
                                    }

                                    //Machine params allowed only by actual tool to avoid crash!!!
                                    //path = GetSubDirectoryById(root, ServicePlcToPcs[n].ParamMWerkzeug);
                                    path = GetSubDirectoryById(root, ServicePlcToPcs[n].AktWerkzeugID);
                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        ServicePcToPlcs[n].ParamMWerkzeugOK = GetFileByName(path, "MWerkzeug_" + machineID + ".xml");
                                        if (ServicePcToPlcs[n].ParamMWerkzeugOK)
                                        {
                                            //deserialize "MWerkzeug_54xxx.xml"
                                            ClearBuffer(ref buffer);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                            Serializer.DeserializeMWerkzeug(path, machineID, ref buffer, ref error);
                                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref result);
                                        }
                                    }
                                    else
                                    {
                                        ServicePcToPlcs[n].ParamMWerkzeugOK = false;
                                    }

                                    ServicePcToPlcs[n].ParamsLadenFertig = true;
                                }
                            }
                            //Get all recipe params <---
                            //**************************************************


                            //**************************************************
                            //Save all recipe params --->
                            if (!ServicePlcToPcs[n].ParamsSichern)
                            {
                                ServicePcToPlcs[n].ParamsSichernFertig = false;
                            }

                            if (ServicePlcToPcs[n].ParamsSichern & !ServicePcToPlcs[n].ParamsSichernFertig)
                            {
                                string path = string.Empty;
                                string halfpath1 = string.Empty;
                                string halfpath2 = string.Empty;
                                string path2 = string.Empty;
                                path = GetSubDirectoryById(root, ServicePlcToPcs[n].AktWerkzeugID);

                                if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                {
                                    halfpath1 = path.Substring(0, 15);
                                    halfpath2 = path.Substring(15);
                                    if (halfpath2 == ServicePlcToPcs[n].AktWerkzeugName)
                                    {
                                        //ChangeLogFileName //@"e:\\dotNet\\WinS7ClientLogger.log"
                                        ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[n].ToString(), path + "\\WinS7ClientLogger.log");
                                        //Log save
                                        log7.Info("Save parameters in " + path);
                                        log7.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                                        richTextBoxPlc7.Text = richTextBoxPlc7.Text + DateTime.Now + "Save parameters in " + path + "\n";


                                        ////Log save
                                        //log.Info("Save parameters in " + path);
                                        ////Log actual user + card
                                        //log.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);


                                        //Case 1. Save parameters
                                        //serialize "HE.xml"
                                        DatHE he1 = Serializer.DeserializeDatHE(path, ref buffer, ref error);
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        DatHE he2 = Serializer.SerializeDatHE(path, buffer, ref error);
                                        Comparence.CompareClass(he1, he2, ref comparenceinfo);
                                        //Log save
                                        log7.Info(comparenceinfo);

                                        //serialize "Config.xml"
                                        DatConfig config1 = Serializer.DeserializeDatConfig(path, ref buffer, ref error);
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        DatConfig config2 = Serializer.SerializeDatConfig(path, buffer, ref error);
                                        Comparence.CompareClass(config1, config2, ref comparenceinfo);
                                        //Log save
                                        log7.Info(comparenceinfo);

                                        //serialize "N2.xml"
                                        DatN2 n21 = Serializer.DeserializeDatN2(path, ref buffer, ref error);
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        DatN2 n22 = Serializer.SerializeDatN2(path, buffer, ref error);
                                        Comparence.CompareClass(n21, n22, ref comparenceinfo);
                                        //Log save
                                        log7.Info(comparenceinfo);

                                        //serialize "Werkzeug.xml"
                                        DatWerkzeug werkzeug1 = Serializer.DeserializeDatWerkzeug(path, ref buffer, ref error);
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        DatWerkzeug werkzeug2 = Serializer.SerializeDatWerkzeug(path, buffer, ref error);
                                        Comparence.CompareClass(werkzeug1, werkzeug2, ref comparenceinfo);
                                        //Log save
                                        log7.Info(comparenceinfo);

                                        //serialize "MWerkzeug_54xxx.xml"
                                        DatMWerkzeug mwerkzeug1 = Serializer.DeserializeMWerkzeug(path, machineID, ref buffer, ref error);
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        DatMWerkzeug mwerkzeug2 = Serializer.SerializeDatMWerkzeug(path, machineID, buffer, ref error);
                                        Comparence.CompareClass(mwerkzeug1, mwerkzeug2, ref comparenceinfo);
                                        //Log save
                                        log7.Info(comparenceinfo);

                                        ServicePcToPlcs[n].ParamsSichernFertig = true;
                                    }
                                    else
                                    {
                                        //Case 2. Rename folder and save parameters

                                        halfpath2 = ServicePlcToPcs[n].AktWerkzeugName;
                                        path2 = halfpath1 + halfpath2;

                                        //ChangeLogFileName YK: 2021_04_12 15:10
                                        ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[n].ToString(), root + "\\WinS7ClientLogger7.log");
                                        log7.Info("RenameDirectory " + path + " >>> " + path2);
                                        log7.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                                        RenameDirectory(path, path2);


                                        //ChangeLogFileName
                                        ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[n].ToString(), path2 + "\\WinS7ClientLogger.log");
                                        //Log save
                                        log7.Info("RenameDirectory " + path + " >>> " + path2);
                                        log7.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                                        path = path2;

                                        if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                        {
                                            //ChangeLogFileName
                                            ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[n].ToString(), path + "\\WinS7ClientLogger.log");
                                            //Log save
                                            log7.Info("Save parameters in " + path);
                                            log7.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                                            //serialize "HE.xml"
                                            DatHE he1 = Serializer.DeserializeDatHE(path, ref buffer, ref error);
                                            ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                            DatHE he2 = Serializer.SerializeDatHE(path, buffer, ref error);
                                            Comparence.CompareClass(he1, he2, ref comparenceinfo);
                                            //Log save
                                            log7.Info(comparenceinfo);

                                            //serialize "Config.xml"
                                            DatConfig config1 = Serializer.DeserializeDatConfig(path, ref buffer, ref error);
                                            ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                            DatConfig config2 = Serializer.SerializeDatConfig(path, buffer, ref error);
                                            Comparence.CompareClass(config1, config2, ref comparenceinfo);
                                            //Log save
                                            log7.Info(comparenceinfo);

                                            //serialize "N2.xml"
                                            DatN2 n21 = Serializer.DeserializeDatN2(path, ref buffer, ref error);
                                            ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                            DatN2 n22 = Serializer.SerializeDatN2(path, buffer, ref error);
                                            Comparence.CompareClass(n21, n22, ref comparenceinfo);
                                            //Log save
                                            log7.Info(comparenceinfo);

                                            //serialize "Werkzeug.xml"
                                            DatWerkzeug werkzeug1 = Serializer.DeserializeDatWerkzeug(path, ref buffer, ref error);
                                            ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                            DatWerkzeug werkzeug2 = Serializer.SerializeDatWerkzeug(path, buffer, ref error);
                                            Comparence.CompareClass(werkzeug1, werkzeug2, ref comparenceinfo);
                                            //Log save
                                            log7.Info(comparenceinfo);

                                            //serialize "MWerkzeug_54xxx.xml"
                                            DatMWerkzeug mwerkzeug1 = Serializer.DeserializeMWerkzeug(path, machineID, ref buffer, ref error);
                                            ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                            DatMWerkzeug mwerkzeug2 = Serializer.SerializeDatMWerkzeug(path, machineID, buffer, ref error);
                                            Comparence.CompareClass(mwerkzeug1, mwerkzeug2, ref comparenceinfo);
                                            //Log save
                                            log7.Info(comparenceinfo);
                                        }

                                        ServicePcToPlcs[n].ParamsSichernFertig = true;

                                        //Get all recipe folders
                                        ToolListClear(ref buffer);

                                        WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                                        string[] subdirectoryEntries;
                                        subdirectoryEntries = GetSubDirectories(root);

                                        ToolListFillWithRecipes(subdirectoryEntries, ref buffer);

                                        //Log save
                                        log7.Info("ToolListFillWithRecipes");

                                        WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);
                                    }
                                }
                                else
                                {
                                    //Case 3. Create folder and save parameters
                                    string folder = string.Empty;
                                    AssembleDirectoryName(ServicePlcToPcs[n].AktWerkzeugID, ServicePlcToPcs[n].AktWerkzeugName, ref folder);
                                    CreateDirectory(root, folder, ref path);

                                    //ChangeLogFileName
                                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[n].ToString(), path + "\\WinS7ClientLogger.log");
                                    //Log save
                                    log7.Info("CreateDirectory " + path);
                                    log7.Info("Save parameters in " + path);
                                    log7.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                                    if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                    {
                                        //serialize "HE.xml"
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_HE, 0, DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        Serializer.SerializeDatHE(path, buffer, ref error);

                                        //serialize "Config.xml"
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Config, 0, DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        Serializer.SerializeDatConfig(path, buffer, ref error);

                                        //serialize "N2.xml"
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_N2, 0, DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        Serializer.SerializeDatN2(path, buffer, ref error);

                                        //serialize "Werkzeug.xml"
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_Werkzeug, 0, DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        Serializer.SerializeDatWerkzeug(path, buffer, ref error);

                                        //serialize "MWerkzeug_54xxx.xml"
                                        ReadAreaPlc(client, S7Consts.S7AreaDB, DB_DAT_MWerkzeug, 0, DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead, ref result);
                                        Serializer.SerializeDatMWerkzeug(path, machineID, buffer, ref error);
                                    }

                                    ServicePcToPlcs[n].ParamsSichernFertig = true;

                                    //Get all recipe folders
                                    ToolListClear(ref buffer);

                                    WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                                    string[] subdirectoryEntries;
                                    subdirectoryEntries = GetSubDirectories(root);

                                    ToolListFillWithRecipes(subdirectoryEntries, ref buffer);

                                    //Log save
                                    log7.Info("ToolListFillWithRecipes");

                                    WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);
                                }

                            }
                            //Save all recipe params <---
                            //**************************************************


                            //**************************************************
                            //Delete recipe folder --->
                            if (!ServicePlcToPcs[n].DatLoeschen)
                            {
                                ServicePcToPlcs[n].DatLoeschenFertig = false;
                            }

                            if (ServicePlcToPcs[n].DatLoeschen & !ServicePcToPlcs[n].DatLoeschenFertig)
                            {
                                string path = string.Empty;
                                path = GetSubDirectoryById(root, ServicePlcToPcs[n].LoeschWerkzeugID);

                                if (!string.IsNullOrEmpty(path) & Directory.Exists(path))
                                {
                                    DeleteDirectory(path);
                                }

                                //ChangeLogFileName
                                ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[n].ToString(), root + "\\WinS7ClientLogger7.log");
                                //Log save
                                log7.Info("DeleteDirectory " + path);
                                log7.Info("Actual user: " + ausweissName + ", actual card: " + ausweissNr);

                                ServicePcToPlcs[n].DatLoeschenFertig = true;

                                //Get all recipe folders
                                ToolListClear(ref buffer);

                                WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                                string[] subdirectoryEntries;
                                subdirectoryEntries = GetSubDirectories(root);

                                ToolListFillWithRecipes(subdirectoryEntries, ref buffer);

                                //Log save
                                log7.Info("ToolListFillWithRecipes");

                                WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_WKZ_Liste, 0, DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref result);

                            }
                            //Delete recipe folder <---
                            //**************************************************



                            SetHeartBeat(ref HeartbeatTimeStamp[n], ref heartbeat, 1);
                            ServicePcToPlcs[n].LifeBit = heartbeat;

                            //btn7 - PLC7 Animation
                            if (heartbeat)
                            {
                                btn7.BackColor = Color.Green;
                            }
                            else
                            {
                                btn7.BackColor = Color.Empty;
                            }


                            /// <summary>
                            /// ServicePcToPlc
                            /// </summary>
                            #region ServicePcToPlc
                            Array.Clear(buffer, 0, 65536);
                            S7.SetBitAt(ref buffer, 0, 0, ServicePcToPlcs[n].LifeBit);
                            S7.SetIntAt(buffer, 2, ServicePcToPlcs[n].ErrorStatus);
                            S7.SetBitAt(ref buffer, 4, 0, ServicePcToPlcs[n].WKZEinlesenFertig);
                            S7.SetBitAt(ref buffer, 4, 1, ServicePcToPlcs[n].ParamsLadenFertig);
                            S7.SetBitAt(ref buffer, 4, 3, ServicePcToPlcs[n].ParamsSichernFertig);
                            S7.SetBitAt(ref buffer, 4, 4, ServicePcToPlcs[n].DatLoeschenFertig);
                            S7.SetBitAt(ref buffer, 5, 0, ServicePcToPlcs[n].ParamHEOK);
                            S7.SetBitAt(ref buffer, 5, 1, ServicePcToPlcs[n].ParamConfigOK);
                            S7.SetBitAt(ref buffer, 5, 2, ServicePcToPlcs[n].ParamN2OK);
                            S7.SetBitAt(ref buffer, 5, 3, ServicePcToPlcs[n].ParamWerkzeugOK);
                            S7.SetBitAt(ref buffer, 5, 4, ServicePcToPlcs[n].ParamMWerkzeugOK);

                            WriteAreaPlc(client, S7Consts.S7AreaDB, DB_Service_PcToPlc, 0, DB_Service_PcToPlc_Length, S7Consts.S7WLByte, buffer, ref result);

                            HexDump(tbDumpPlc7, buffer, DB_Service_PcToPlc_Length);

                            #endregion
                        }
                    });


                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
        }



        #endregion


        /// <summary>
        /// PrivateMethods
        /// </summary>
        #region PrivateMethods

        private void Initialization()
        {
            // Panel Start visibility
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panelService.Visible = false;

            //S7Clients
            for (int i = 0; i < S7Clients.Length; i++)
            {
                S7Clients[i] = new S7Client();

                string cnnVal = "PLC" + i;
                PlcIpAddress[i] = ParseStringHelper.GetServerName(ConnHelper.CnnVal(cnnVal));
                PlcRack[i] = ParseStringHelper.GetRackName(ConnHelper.CnnVal(cnnVal));
                PlcSlot[i] = ParseStringHelper.GetSlotName(ConnHelper.CnnVal(cnnVal));

                S7CpuInfos[i] = new S7Client.S7CpuInfo();
                ServicePcToPlcs[i] = new ServicePcToPlc();
                ServicePlcToPcs[i] = new ServicePlcToPc();

                HeartbeatTimeStamp[i] = DateTime.Now;
            }

            var appenders = log4net.LogManager.GetRepository().GetAppenders();
            appenderName[1] = appenders[1].Name;
            appenderName[2] = appenders[2].Name;
            appenderName[3] = appenders[3].Name;
            appenderName[4] = appenders[4].Name;
            appenderName[5] = appenders[5].Name;
            appenderName[6] = appenders[6].Name;
            appenderName[7] = appenders[7].Name;
            appenderName[8] = appenders[8].Name;
            appenderName[9] = appenders[9].Name;
            appenderName[10] = appenders[10].Name;

            // Threads
            tPlc1 = new Thread(new ThreadStart(Plc1));
            tPlc1.Start();
            tPlc2 = new Thread(new ThreadStart(Plc2));
            tPlc2.Start();
            tPlc3 = new Thread(new ThreadStart(Plc3));
            tPlc3.Start();

            tPlc7 = new Thread(new ThreadStart(Plc7));
            tPlc7.Start();


            // PLC3
            tbIpAddressPlc3.Text = PlcIpAddress[3];
            tbRackPlc3.Text = PlcRack[3];
            tbSlotPlc3.Text = PlcSlot[3];
            
            tbIpAddressPlc3.Enabled = false;
            tbRackPlc3.Enabled = false;
            tbSlotPlc3.Enabled = false;
            
            tbModuleTypeNamePlc3.Text = "";
            tbSerialNumberPlc3.Text = "";
            tbCopyrightPlc3.Text = "";
            tbAsNamePlc3.Text = "";
            tbModuleNamePlc3.Text = "";
            
            tbOrderCodePlc3.Text = "";
            tbVersionPlc3.Text = "";

            // Plc7
            tbIpAddressPlc7.Text = PlcIpAddress[7];
            tbRackPlc7.Text = PlcRack[7];
            tbSlotPlc7.Text = PlcSlot[7];

            tbIpAddressPlc7.Enabled = false;
            tbRackPlc7.Enabled = false;
            tbSlotPlc7.Enabled = false;

            tbModuleTypeNamePlc7.Text = "";
            tbSerialNumberPlc7.Text = "";
            tbCopyrightPlc7.Text = "";
            tbAsNamePlc7.Text = "";
            tbModuleNamePlc7.Text = "";

            tbOrderCodePlc7.Text = "";
            tbVersionPlc7.Text = "";



            TimerForm.Enabled = true;
            TimerForm.Start();
        }

        private void toolTipShow(object sender, string tooltipinfo)
        {
            ToolTipGenerator.ToolTipShow(sender, tooltipinfo);
        }

        private void ShowResult(int result, S7Client client)
        {
            // This function returns a textual explaination of the error code

            S7Client[] tempclient = new S7Client[11];

            //S7Clients
            for (int i = 0; i < tempclient.Length; i++)
            {
                tempclient[i] = new S7Client();

                string cnnVal = "PLC" + i;
                string tempIpAddress = ParseStringHelper.GetServerName(ConnHelper.CnnVal(cnnVal));

                if (client.IpAddress.ToString() != null)
                {
                    if (tempIpAddress == client.IpAddress.ToString())
                    {
                        switch (cnnVal)
                        {
                            case "PLC3":
                                tbTextErrorPlc3.Text = DateTime.Now + " - " + client.ErrorText(result);
                                if (result == 0)
                                {
                                    tbTextErrorPlc3.Text = tbTextErrorPlc3.Text + " (" + client.ExecutionTime.ToString() + " ms)";

                                }
                                break;

                            case "PLC7":
                                tbTextErrorPlc7.Text = DateTime.Now + " - " + client.ErrorText(result);
                                if (result == 0)
                                {
                                    tbTextErrorPlc7.Text = tbTextErrorPlc7.Text + " (" + client.ExecutionTime.ToString() + " ms)";

                                }
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void ReadCPUInfo(S7Client client, ref S7Client.S7CpuInfo info, ref int result)
        {
            result = client.GetCpuInfo(ref info);
            ShowResult(result, client);
        }

        private void ReadOrderCode(S7Client client, ref S7Client.S7OrderCode orderCode, ref int result)
        {
            result = client.GetOrderCode(ref orderCode);
            ShowResult(result, client);
            
        }

        private void ReadAreaPlc(S7Client client, byte area, int dbNumber, int start, int amount, int wordLen, byte[] buffer, ref int sizeRead, ref int result)
        {
            // Declaration separated from the code for readability
            Array.Clear(buffer, 0, buffer.Length);

            result = client.ReadArea(area, dbNumber, start , amount, wordLen, buffer, ref sizeRead);

            ShowResult(result, client);
        }
        
        private void WriteAreaPlc(S7Client client, byte area, int dbNumber, int start, int amount, int wordLen, byte[] buffer, ref int result)
        {

            result = client.WriteArea(area, dbNumber, start, amount, wordLen, buffer);
            
            ShowResult(result, client);
        }

        private void HexDump(TextBox DumpBox, byte[] bytes, int Size)
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



        /// <summary>
        /// Plc3
        /// </summary>
        #region Plc3
        private void btnConnectPlc3_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc3.Text;
            int rack = tbRackPlc3.Text.ParseInt();
            int slot = tbSlotPlc3.Text.ParseInt();

            result = S7Clients[3].ConnectTo(address, rack, slot);
            ShowResult(result, S7Clients[3]);
            if (result == 0)
            {
                tbTextErrorPlc3.Text = tbTextErrorPlc3.Text + " PDU Negotiated : " + S7Clients[3].PduSizeNegotiated.ToString();
                btnConnectPlc3.Enabled = false;
                btnDisconnectPlc3.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                ReadCPUInfo(S7Clients[3], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc3.Text = info.ModuleTypeName;
                    tbSerialNumberPlc3.Text = info.SerialNumber;
                    tbCopyrightPlc3.Text = info.Copyright;
                    tbAsNamePlc3.Text = info.ASName;
                    tbModuleNamePlc3.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                ReadOrderCode(S7Clients[3], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc3.Text = orderCode.Code;
                    tbVersionPlc3.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }
        private void btnDisonnectPlc3_Click(object sender, EventArgs e)
        {
            S7Clients[3].Disconnect();
            tbTextErrorPlc3.Text = "Disconnected";
            tbIpAddressPlc3.Enabled = true;
            tbRackPlc3.Enabled = true;
            tbSlotPlc3.Enabled = true;
            btnConnectPlc3.Enabled = true;
            btnDisconnectPlc3.Enabled = false;
            //tabControl.Enabled = false;
        }


        private void tbIpPlc3_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc3_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc3_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion

        /// <summary>
        /// Plc7
        /// </summary>
        #region Plc7
        private void btnConnectPlc7_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc7.Text;
            int rack = tbRackPlc7.Text.ParseInt();
            int slot = tbSlotPlc7.Text.ParseInt();

            result = S7Clients[7].ConnectTo(address, rack, slot);
            ShowResult(result, S7Clients[7]);
            if (result == 0)
            {
                tbTextErrorPlc7.Text = tbTextErrorPlc7.Text + " PDU Negotiated : " + S7Clients[7].PduSizeNegotiated.ToString();
                btnConnectPlc7.Enabled = false;
                btnDisconnectPlc7.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                ReadCPUInfo(S7Clients[7], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc7.Text = info.ModuleTypeName;
                    tbSerialNumberPlc7.Text = info.SerialNumber;
                    tbCopyrightPlc7.Text = info.Copyright;
                    tbAsNamePlc7.Text = info.ASName;
                    tbModuleNamePlc7.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                ReadOrderCode(S7Clients[7], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc7.Text = orderCode.Code;
                    tbVersionPlc7.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }
        private void btnDisonnectPlc7_Click(object sender, EventArgs e)
        {
            S7Clients[7].Disconnect();
            tbTextErrorPlc7.Text = "Disconnected";
            tbIpAddressPlc7.Enabled = true;
            tbRackPlc7.Enabled = true;
            tbSlotPlc7.Enabled = true;
            btnConnectPlc7.Enabled = true;
            btnDisconnectPlc7.Enabled = false;
            //tabControl.Enabled = false;
        }


        private void tbIpPlc7_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc7_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc7_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion




        #endregion


        /// <summary>
        /// Buttons
        /// </summary>
        #region Buttons

        /// <summary>
        /// Panel_choice
        /// </summary>
        #region Panel_choice
        private void btn1_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panelService.Visible = false;
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panelService.Visible = false;
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panelService.Visible = false;
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel4.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panelService.Visible = false;
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel5.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panelService.Visible = false;
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel6.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panelService.Visible = false;
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel7.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panelService.Visible = false;
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel8.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panelService.Visible = false;
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel9.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;
            panelService.Visible = false;
        }
        private void btn10_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel10.Visible = true;
            panel9.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panelService.Visible = false;
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;
            panel9.Visible = false;
            panelService.Visible = true;
        }

        private void panel10_VisibleChanged(object sender, EventArgs e)
        {
            //var panel10 = (Panel)sender;
            if (panel10.Visible)
            {
                if (!myServiceForm1.IsHandleCreated)
                {
                    myServiceForm1 = new ServiceForm() { Dock = DockStyle.None, TopLevel = false, TopMost = true };
                    myServiceForm1.FormBorderStyle = FormBorderStyle.None;
                    panel10.Controls.Add(myServiceForm1);
                    myServiceForm1.Show();
                }

            }
            else
            {
                if (myServiceForm1.IsHandleCreated)
                {
                    //myServiceForm1.Dispose();
                }
            }
        }

        private void panelService_VisibleChanged(object sender, EventArgs e)
        {
            if (panelService.Visible)
            {
                if (!myServiceForm2.IsHandleCreated)
                {
                    myServiceForm2 = new ServiceForm() { Dock = DockStyle.None, TopLevel = false, TopMost = true };
                    myServiceForm2.FormBorderStyle = FormBorderStyle.None;
                    panelService.Controls.Add(myServiceForm2);
                    myServiceForm2.Show();
                }

            }
            else
            {
                if (myServiceForm2.IsHandleCreated)
                {
                    //myServiceForm2.Dispose();
                }
            }
        }


        #endregion

        #endregion
















        //Timer Form
        private void TimerForm_Tick(object sender, EventArgs e)
        {
            /*TimerForm.Stop();
            TimerForm.Enabled = false;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here

            _ticks++;
            //Show counter
            textBoxTimerForm.Text = _ticks.ToString();

            if (_ticks>=10)
            {
                _ticks = 0;
            }

            TestStrings.Add(DateTime.Now.ToString());

            UpdateBindinglistBoxDboATGStatusView();
            
            // the code that you want to measure ends here
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            textBoxCodeTime54010.Text = elapsedMs.ToString();
            TimerForm.Enabled = true;
            TimerForm.Start();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimerForm.Stop();
            TimerForm.Enabled = false;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here

            _ticks++;
            //Show counter
            //textBoxTimerForm.Text = _ticks.ToString();

            if (_ticks >= 10)
            {
                _ticks = 0;
            }

            // the code that you want to measure ends here
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            //textBoxCodeTime54010.Text = elapsedMs.ToString();
            TimerForm.Enabled = true;
            TimerForm.Start();
        }


        /// <summary>
        /// RecipesServiceMethods
        /// </summary>
        #region RecipesServiceMethods
        private string[] GetSubDirectories(string root)
        {
            //root = @"E:\Recipes";
            // Get all subdirectories
            string[] subdirectoryEntries = Directory.GetDirectories(root);
            return subdirectoryEntries;
        }

        private static void ClearBuffer(ref byte[] buffer)
        {
            Array.Clear(buffer, 0, buffer.Length);
        }

        private void ToolListClear(ref byte[] buffer)
        {
            Array.Clear(buffer, 0, 65536);
            int shiftName = 0;
            int shiftId = 22;
            for (int i = 0; i < 127; i++)
            {
                S7.SetStringAt(buffer, shiftName, 20, string.Empty);
                S7.SetIntAt(buffer, shiftId, 0);

                shiftName += 24;
                shiftId += 24;
            }
        }

        private void ToolListFillWithRecipes(string[] subdirectoryEntries, ref byte[] buffer)
        {
            int shiftName = 0;
            int shiftId = 22;
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
                        S7.SetIntAt(buffer, 3070, (subdirectory.Substring(11, 3)).ParseShort());
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
                        S7.SetStringAt(buffer, shiftName, 20, subdirectory.Substring(15)); 
                    }
                    else
                    {
                        S7.SetStringAt(buffer, 3048, 20, subdirectory.Substring(15));
                    }
                }
                else
                {
                    S7.SetStringAt(buffer, shiftName, 20, string.Empty);
                }

                shiftName += 24;
                shiftId += 24;
            }
        }

        private string GetSubDirectoryById(string root, short id)
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

        private void CreateDirectory(string root, string folder, ref string path)
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

        private string[] GetFilesInDirectory(string root)
        {
            string[] fileEntries = Directory.GetFiles(root);
            return fileEntries;
        }

        private bool GetFileByName(string root, string filename)
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

        private void AssembleDirectoryName(short wkzid, string werkzeugname, ref string folder)
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

        private void RenameDirectory(string path1, string path2)
        {
            if (Directory.Exists(path1))
            {
                Directory.Move(path1, path2);
            }
        }

        private void DeleteDirectory(string path)
        {
            Directory.Delete(path, true);
        }


        private void AssembleId(short wkzid, ref string wkzidString)
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

        private void SetHeartBeat(ref DateTime timestamp, ref bool heartbeat, int difference = 5)
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




        private void LoadSubDirs(string dir)
        {
            Console.WriteLine(dir);
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            foreach (string subdirectory in subdirectoryEntries)
            {
                LoadSubDirs(subdirectory);
            }
        }


        private void btnReadDirs_Click(object sender, EventArgs e)
        {
            string root = @"E:\Recipes";
            GetSubDirectories(root);
        }

        private void CreateDir_Click(object sender, EventArgs e)
        {
            string root = string.Empty;
            string folder = string.Empty;
            string path = string.Empty;
            CreateDirectory(root, folder, ref path);
        }

        private void btnRenameDir_Click(object sender, EventArgs e)
        {
            string root = @"E:\Recipes";
            string path = root + @"\" + "055_BlaBlaBla";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }


            if (Directory.Exists(path))
            {
                string path2 = root + @"\" + "066_BlaBlaBla";

                Directory.Move(path, path2);
            }
        }



        #endregion

    }
}
