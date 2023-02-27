using System;
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
using WinS7Library.Helper;
using WinS7Library.Model;

namespace WinS7Client
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Fields
        /// </summary>
        #region Fields
        private int _ticks;
        private ServiceForm myServiceForm;

        private S7Client[] S7Clients = new S7Client[15];
        private string[] PlcIpAddress = new string[15];
        private string[] PlcRack = new string[15];
        private string[] PlcSlot = new string[15];
        private S7Client.S7CpuInfo[] S7CpuInfos = new S7Client.S7CpuInfo[15];
        private ServicePcToPlc[] ServicePcToPlcs = new ServicePcToPlc[15];
        private ServicePlcToPc[] ServicePlcToPcs = new ServicePlcToPc[15];
        public CommData[] CommDatas = new CommData[15];

        public string[] appenderName = new string[15];

        private Thread tPlc1;
        private Thread tPlc2;
        private Thread tPlc3;
        private Thread tPlc4;
        private Thread tPlc5;
        private Thread tPlc6;
        private Thread tPlc7;
        private Thread tPlc8;
        private Thread tPlc9;
        private Thread tPlc10;
        private Thread tPlc11;
        private Thread tPlc12;
        private Thread tPlc13;
        private Thread tPlc14;

        // Create a logger
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly log4net.ILog log0 = log4net.LogManager.GetLogger("Logger0");
        private static readonly log4net.ILog log1 = log4net.LogManager.GetLogger("Logger1");
        private static readonly log4net.ILog log2 = log4net.LogManager.GetLogger("Logger2");
        private static readonly log4net.ILog log3 = log4net.LogManager.GetLogger("Logger3");
        private static readonly log4net.ILog log4 = log4net.LogManager.GetLogger("Logger4");
        private static readonly log4net.ILog log5 = log4net.LogManager.GetLogger("Logger5");
        private static readonly log4net.ILog log6 = log4net.LogManager.GetLogger("Logger6");
        private static readonly log4net.ILog log7 = log4net.LogManager.GetLogger("Logger7");
        private static readonly log4net.ILog log8 = log4net.LogManager.GetLogger("Logger8");
        private static readonly log4net.ILog log9 = log4net.LogManager.GetLogger("Logger9");
        private static readonly log4net.ILog log10 = log4net.LogManager.GetLogger("Logger10");
        private static readonly log4net.ILog log11 = log4net.LogManager.GetLogger("Logger11");
        private static readonly log4net.ILog log12 = log4net.LogManager.GetLogger("Logger12");
        private static readonly log4net.ILog log13 = log4net.LogManager.GetLogger("Logger13");
        private static readonly log4net.ILog log14 = log4net.LogManager.GetLogger("Logger14");

        private static readonly log4net.ILog[] log = new log4net.ILog[15];

        //Thread Timestamps
        private DateTime[] HeartbeatTimeStamp = new DateTime[15];
        
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
        private const int DB_DAT_Betrieb = 7008;

        //DB Length in bytes
        private const int DB_DAT_HE_Length = 240;
        private const int DB_DAT_Config_Length = 2796;
        private const int DB_DAT_N2_Length = 640;
        private const int DB_DAT_Werkzeug_Length = 260; // v.4 Changes for customer 28.04.2021 -> 40 Signs
        private const int DB_DAT_MWerkzeug_Length = 40;
        private const int DB_Service_WKZ_Liste_Length = 5632;   // v.4 Changes for customer 28.04.2021 -> 40 Signs
        private const int DB_Service_PlcToPc_Length = 122;  // v.4 Changes for customer 28.04.2021 -> 40 Signs
        private const int DB_Service_PcToPlc_Length = 6;
        private const int DB_DAT_Betrieb_Length = 24;
        #endregion


        /// <summary>
        /// MainForm Construction
        /// </summary>
        #region MainForm Construction
        public MainForm()
        {
            InitializeComponent();
            //TimerForm.Start();

            myServiceForm = new ServiceForm();
        } 

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
            tPlc4.Abort();
            tPlc5.Abort();
            tPlc6.Abort();
            tPlc7.Abort();
            tPlc8.Abort();
            tPlc9.Abort();
            tPlc10.Abort();
            tPlc11.Abort();
            tPlc12.Abort();
            tPlc13.Abort();
            tPlc14.Abort();

            tPlc1.Join();
            tPlc2.Join();
            tPlc3.Join();
            tPlc4.Join();
            tPlc5.Join();
            tPlc6.Join();
            tPlc7.Join();
            tPlc8.Join();
            tPlc9.Join();
            tPlc10.Join();
            tPlc11.Join();
            tPlc12.Join();
            tPlc13.Join();
            tPlc14.Join();
        }
        #endregion


        /// <summary>
        /// Threads
        /// </summary>
        #region Threads

        /// <summary>
        /// PLC communication and burst pressure handling only
        /// </summary>
        private void Plc1()
        {
            int n = 1;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {

                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }

        /// <summary>
        /// PLC communication and burst pressure handling only
        /// </summary>
        private void Plc2()
        {
            int n = 2;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {

                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }

        /// <summary>
        /// PLC communication and recipes handling
        /// </summary>
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
                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                        else
                        {
                            ConnectClient(n);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }


        /// <summary>
        /// PLC communication and recipes handling
        /// </summary>
        public void Plc4()
        {
            int n = 4;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {
                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                        else
                        {
                            ConnectClient(n);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }


        /// <summary>
        /// PLC communication and recipes handling
        /// </summary>
        public void Plc5()
        {
            int n = 5;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {
                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                        else
                        {
                            ConnectClient(n);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }


        /// <summary>
        /// PLC communication and recipes handling
        /// </summary>
        public void Plc6()
        {
            int n = 6;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {
                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                        else
                        {
                            ConnectClient(n);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }


        /// <summary>
        /// PLC communication and recipes handling
        /// </summary>
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
                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                        else
                        {
                            ConnectClient(n);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }


        /// <summary>
        /// PLC communication and recipes handling
        /// </summary>
        public void Plc8()
        {
            int n = 8;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {
                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }


        /// <summary>
        /// PLC communication and recipes handling
        /// </summary>
        public void Plc9()
        {
            int n = 9;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                       if (S7Clients[n].Connected)
                       {
                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }

        public void Plc10()
        {
            int n = 10;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {
                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }

        public void Plc11()
        {
            int n = 11;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {
                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }

        public void Plc12()
        {
            int n = 12;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {
                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }
        public void Plc13()
        {
            int n = 13;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {
                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

                    //throw;
                }
            }
        }

        public void Plc14()
        {
            int n = 14;
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (S7Clients[n].Connected)
                        {
                            CommPlcInstance commPlcInst = new CommPlcInstance();
                            commPlcInst.ConnectionRun(S7Clients[n], CommDatas[n], ref ServicePlcToPcs[n], ref ServicePcToPlcs[n]);
                        }
                    });

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger for PLC-n
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger" + n + ".log");
                    log[0].Error("Exception: " + ex.Message.ToString());

                    //ChangeLogFileName @".\\WinS7ClientLogger.log" for log0 -> logger default file
                    ChangeLogFileNameForLog4Net.ChangeLogFileName(appenderName[0], @".\\WinS7ClientLogger.log");

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
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
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

                // connect client when UI starts
                ConnectClient(i);

                HeartbeatTimeStamp[i] = DateTime.Now;
            }

            // Appender's Names
            var appenders = log4net.LogManager.GetRepository().GetAppenders();
            appenderName[0] = appenders[0].Name;
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
            appenderName[11] = appenders[11].Name;
            appenderName[12] = appenders[12].Name;
            appenderName[13] = appenders[13].Name;
            appenderName[14] = appenders[14].Name;


            // Loggers
            log[0] = log0;
            log[1] = log1;
            log[2] = log2;
            log[3] = log3;
            log[4] = log4;
            log[5] = log5;
            log[6] = log6;
            log[7] = log7;
            log[8] = log8;
            log[9] = log9;
            log[10] = log10;
            log[11] = log11;
            log[12] = log12;
            log[13] = log13;
            log[14] = log14;

            // Loggers Test Start
            log[0].Info("Start0");
            log[1].Info("Start1");
            log[2].Info("Start2");
            log[3].Info("Start3");
            log[4].Info("Start4");
            log[5].Info("Start5");
            log[6].Info("Start6");
            log[7].Info("Start7");
            log[8].Info("Start8");
            log[9].Info("Start9");
            log[10].Info("Start10");
            log[11].Info("Start11");
            log[12].Info("Start12");
            log[13].Info("Start13");
            log[14].Info("Start14");


            // CommServices
            for (int i = 0; i < CommDatas.Length; i++)
            {
                CommDatas[i] = new CommData();
                CommDatas[i].AppenderNameGlobal = appenderName[0];
                CommDatas[i].AppenderNameRecipe = appenderName[i];
                CommDatas[i].LogGlobal = log[0];
                CommDatas[i].LogRecipe = log[i];
                CommDatas[i].N = i;
                CommDatas[i].LifeBitTimeStamp = HeartbeatTimeStamp[i];
            }


            // Threads
            tPlc1 = new Thread(new ThreadStart(Plc1));
            tPlc1.Start();
            tPlc2 = new Thread(new ThreadStart(Plc2));
            tPlc2.Start();
            tPlc3 = new Thread(new ThreadStart(Plc3));
            tPlc3.Start();
            tPlc4 = new Thread(new ThreadStart(Plc4));
            tPlc4.Start();
            tPlc5 = new Thread(new ThreadStart(Plc5));
            tPlc5.Start();
            tPlc6 = new Thread(new ThreadStart(Plc6));
            tPlc6.Start();
            tPlc7 = new Thread(new ThreadStart(Plc7));
            tPlc7.Start();
            tPlc8 = new Thread(new ThreadStart(Plc8));
            tPlc8.Start();
            tPlc9 = new Thread(new ThreadStart(Plc9));
            tPlc9.Start();
            tPlc10 = new Thread(new ThreadStart(Plc10));
            tPlc10.Start();
            tPlc11 = new Thread(new ThreadStart(Plc11));
            tPlc11.Start();
            tPlc12 = new Thread(new ThreadStart(Plc12));
            tPlc12.Start();
            tPlc13 = new Thread(new ThreadStart(Plc13));
            tPlc13.Start();
            tPlc14 = new Thread(new ThreadStart(Plc14));
            tPlc14.Start();

            // PLC1
            tbIpAddressPlc1.Text = PlcIpAddress[1];
            tbRackPlc1.Text = PlcRack[1];
            tbSlotPlc1.Text = PlcSlot[1];

            tbIpAddressPlc1.Enabled = false;
            tbRackPlc1.Enabled = false;
            tbSlotPlc1.Enabled = false;

            tbModuleTypeNamePlc1.Text = "";
            tbSerialNumberPlc1.Text = "";
            tbCopyrightPlc1.Text = "";
            tbAsNamePlc1.Text = "";
            tbModuleNamePlc1.Text = "";

            tbOrderCodePlc1.Text = "";
            tbVersionPlc1.Text = "";

            // PLC2
            tbIpAddressPlc2.Text = PlcIpAddress[2];
            tbRackPlc2.Text = PlcRack[2];
            tbSlotPlc2.Text = PlcSlot[2];

            tbIpAddressPlc2.Enabled = false;
            tbRackPlc2.Enabled = false;
            tbSlotPlc2.Enabled = false;

            tbModuleTypeNamePlc2.Text = "";
            tbSerialNumberPlc2.Text = "";
            tbCopyrightPlc2.Text = "";
            tbAsNamePlc2.Text = "";
            tbModuleNamePlc2.Text = "";

            tbOrderCodePlc2.Text = "";
            tbVersionPlc2.Text = "";

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

            // PLC4
            tbIpAddressPlc4.Text = PlcIpAddress[4];
            tbRackPlc4.Text = PlcRack[4];
            tbSlotPlc4.Text = PlcSlot[4];

            tbIpAddressPlc4.Enabled = false;
            tbRackPlc4.Enabled = false;
            tbSlotPlc4.Enabled = false;

            tbModuleTypeNamePlc4.Text = "";
            tbSerialNumberPlc4.Text = "";
            tbCopyrightPlc4.Text = "";
            tbAsNamePlc4.Text = "";
            tbModuleNamePlc4.Text = "";

            tbOrderCodePlc4.Text = "";
            tbVersionPlc4.Text = "";

            // PLC5
            tbIpAddressPlc5.Text = PlcIpAddress[5];
            tbRackPlc5.Text = PlcRack[5];
            tbSlotPlc5.Text = PlcSlot[5];

            tbIpAddressPlc5.Enabled = false;
            tbRackPlc5.Enabled = false;
            tbSlotPlc5.Enabled = false;

            tbModuleTypeNamePlc5.Text = "";
            tbSerialNumberPlc5.Text = "";
            tbCopyrightPlc5.Text = "";
            tbAsNamePlc5.Text = "";
            tbModuleNamePlc5.Text = "";

            tbOrderCodePlc5.Text = "";
            tbVersionPlc5.Text = "";

            // PLC6
            tbIpAddressPlc6.Text = PlcIpAddress[6];
            tbRackPlc6.Text = PlcRack[6];
            tbSlotPlc6.Text = PlcSlot[6];

            tbIpAddressPlc6.Enabled = false;
            tbRackPlc6.Enabled = false;
            tbSlotPlc6.Enabled = false;

            tbModuleTypeNamePlc6.Text = "";
            tbSerialNumberPlc6.Text = "";
            tbCopyrightPlc6.Text = "";
            tbAsNamePlc6.Text = "";
            tbModuleNamePlc6.Text = "";

            tbOrderCodePlc6.Text = "";
            tbVersionPlc6.Text = "";

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

            // Plc8
            tbIpAddressPlc8.Text = PlcIpAddress[8];
            tbRackPlc8.Text = PlcRack[8];
            tbSlotPlc8.Text = PlcSlot[8];

            tbIpAddressPlc8.Enabled = false;
            tbRackPlc8.Enabled = false;
            tbSlotPlc8.Enabled = false;

            tbModuleTypeNamePlc8.Text = "";
            tbSerialNumberPlc8.Text = "";
            tbCopyrightPlc8.Text = "";
            tbAsNamePlc8.Text = "";
            tbModuleNamePlc8.Text = "";

            tbOrderCodePlc8.Text = "";
            tbVersionPlc8.Text = "";

            // Plc9
            tbIpAddressPlc9.Text = PlcIpAddress[9];
            tbRackPlc9.Text = PlcRack[9];
            tbSlotPlc9.Text = PlcSlot[9];

            tbIpAddressPlc9.Enabled = false;
            tbRackPlc9.Enabled = false;
            tbSlotPlc9.Enabled = false;

            tbModuleTypeNamePlc9.Text = "";
            tbSerialNumberPlc9.Text = "";
            tbCopyrightPlc9.Text = "";
            tbAsNamePlc9.Text = "";
            tbModuleNamePlc9.Text = "";

            tbOrderCodePlc9.Text = "";
            tbVersionPlc9.Text = "";

            // Plc10
            tbIpAddressPlc10.Text = PlcIpAddress[10];
            tbRackPlc10.Text = PlcRack[10];
            tbSlotPlc10.Text = PlcSlot[10];

            tbIpAddressPlc10.Enabled = false;
            tbRackPlc10.Enabled = false;
            tbSlotPlc10.Enabled = false;

            tbModuleTypeNamePlc10.Text = "";
            tbSerialNumberPlc10.Text = "";
            tbCopyrightPlc10.Text = "";
            tbAsNamePlc10.Text = "";
            tbModuleNamePlc10.Text = "";

            tbOrderCodePlc10.Text = "";
            tbVersionPlc10.Text = "";

            // Plc11
            tbIpAddressPlc11.Text = PlcIpAddress[11];
            tbRackPlc11.Text = PlcRack[11];
            tbSlotPlc11.Text = PlcSlot[11];

            tbIpAddressPlc11.Enabled = false;
            tbRackPlc11.Enabled = false;
            tbSlotPlc11.Enabled = false;

            tbModuleTypeNamePlc11.Text = "";
            tbSerialNumberPlc11.Text = "";
            tbCopyrightPlc11.Text = "";
            tbAsNamePlc11.Text = "";
            tbModuleNamePlc11.Text = "";

            tbOrderCodePlc11.Text = "";
            tbVersionPlc11.Text = "";

            // Plc12
            tbIpAddressPlc12.Text = PlcIpAddress[12];
            tbRackPlc12.Text = PlcRack[12];
            tbSlotPlc12.Text = PlcSlot[12];

            tbIpAddressPlc12.Enabled = false;
            tbRackPlc12.Enabled = false;
            tbSlotPlc12.Enabled = false;

            tbModuleTypeNamePlc12.Text = "";
            tbSerialNumberPlc12.Text = "";
            tbCopyrightPlc12.Text = "";
            tbAsNamePlc12.Text = "";
            tbModuleNamePlc12.Text = "";

            tbOrderCodePlc12.Text = "";
            tbVersionPlc12.Text = "";

            // Plc13
            tbIpAddressPlc13.Text = PlcIpAddress[13];
            tbRackPlc13.Text = PlcRack[13];
            tbSlotPlc13.Text = PlcSlot[13];

            tbIpAddressPlc13.Enabled = false;
            tbRackPlc13.Enabled = false;
            tbSlotPlc13.Enabled = false;

            tbModuleTypeNamePlc13.Text = "";
            tbSerialNumberPlc13.Text = "";
            tbCopyrightPlc13.Text = "";
            tbAsNamePlc13.Text = "";
            tbModuleNamePlc13.Text = "";

            tbOrderCodePlc13.Text = "";
            tbVersionPlc13.Text = "";

            // Plc14
            tbIpAddressPlc14.Text = PlcIpAddress[14];
            tbRackPlc14.Text = PlcRack[14];
            tbSlotPlc14.Text = PlcSlot[14];

            tbIpAddressPlc14.Enabled = false;
            tbRackPlc14.Enabled = false;
            tbSlotPlc14.Enabled = false;

            tbModuleTypeNamePlc14.Text = "";
            tbSerialNumberPlc14.Text = "";
            tbCopyrightPlc14.Text = "";
            tbAsNamePlc14.Text = "";
            tbModuleNamePlc14.Text = "";

            tbOrderCodePlc14.Text = "";
            tbVersionPlc14.Text = "";

            TimerForm.Enabled = true;
            TimerForm.Start();
        }


        /// <summary>
        /// Plc1
        /// </summary>
        #region Plc1
        private async void btnConnectPlc1_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc1.Text;
            int rack = tbRackPlc1.Text.ParseInt();
            int slot = tbSlotPlc1.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[1], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[1]);
            tbTextErrorPlc1.Text = error;

            if (result == 0)
            {
                btnConnectPlc1.Enabled = false;
                btnDisconnectPlc1.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[1], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc1.Text = info.ModuleTypeName;
                    tbSerialNumberPlc1.Text = info.SerialNumber;
                    tbCopyrightPlc1.Text = info.Copyright;
                    tbAsNamePlc1.Text = info.ASName;
                    tbModuleNamePlc1.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[1], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc1.Text = orderCode.Code;
                    tbVersionPlc1.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }
        private void btnDisonnectPlc1_Click(object sender, EventArgs e)
        {
            S7Clients[1].Disconnect();
            tbTextErrorPlc1.Text = "Disconnected";
            tbIpAddressPlc1.Enabled = false;
            tbRackPlc1.Enabled = false;
            tbSlotPlc1.Enabled = false;
            btnConnectPlc1.Enabled = true;
            btnDisconnectPlc1.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc1_Click(object sender, EventArgs e)
        {
            richTextBoxPlc1.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc1.Text = richTextBoxPlc1.Text + dir + "\n";
            }
        }

        private void tbIpPlc1_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc1_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc1_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion

        /// <summary>
        /// Plc2
        /// </summary>
        #region Plc2
        private async void btnConnectPlc2_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc2.Text;
            int rack = tbRackPlc2.Text.ParseInt();
            int slot = tbSlotPlc2.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[2], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[2]);
            tbTextErrorPlc2.Text = error;

            if (result == 0)
            {
                btnConnectPlc2.Enabled = false;
                btnDisconnectPlc2.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[2], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc2.Text = info.ModuleTypeName;
                    tbSerialNumberPlc2.Text = info.SerialNumber;
                    tbCopyrightPlc2.Text = info.Copyright;
                    tbAsNamePlc2.Text = info.ASName;
                    tbModuleNamePlc2.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[2], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc2.Text = orderCode.Code;
                    tbVersionPlc2.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }
        private void btnDisonnectPlc2_Click(object sender, EventArgs e)
        {
            S7Clients[2].Disconnect();
            tbTextErrorPlc2.Text = "Disconnected";
            tbIpAddressPlc2.Enabled = false;
            tbRackPlc2.Enabled = false;
            tbSlotPlc2.Enabled = false;
            btnConnectPlc2.Enabled = true;
            btnDisconnectPlc2.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc2_Click(object sender, EventArgs e)
        {
            richTextBoxPlc2.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc2.Text = richTextBoxPlc2.Text + dir + "\n";
            }
        }

        private void tbIpPlc2_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc2_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc2_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion

        /// <summary>
        /// Plc3
        /// </summary>
        #region Plc3
        private async void btnConnectPlc3_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc3.Text;
            int rack = tbRackPlc3.Text.ParseInt();
            int slot = tbSlotPlc3.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[3], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[3]);
            tbTextErrorPlc3.Text = error;

            if (result == 0)
            {
                btnConnectPlc3.Enabled = false;
                btnDisconnectPlc3.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[3], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc3.Text = info.ModuleTypeName;
                    tbSerialNumberPlc3.Text = info.SerialNumber;
                    tbCopyrightPlc3.Text = info.Copyright;
                    tbAsNamePlc3.Text = info.ASName;
                    tbModuleNamePlc3.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[3], ref orderCode, ref result);
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
            tbIpAddressPlc3.Enabled = false;
            tbRackPlc3.Enabled = false;
            tbSlotPlc3.Enabled = false;
            btnConnectPlc3.Enabled = true;
            btnDisconnectPlc3.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc3_Click(object sender, EventArgs e)
        {
            richTextBoxPlc3.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc3.Text = richTextBoxPlc3.Text + dir + "\n";
            }
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
        /// Plc4
        /// </summary>
        #region Plc4
        private async void btnConnectPlc4_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc4.Text;
            int rack = tbRackPlc4.Text.ParseInt();
            int slot = tbSlotPlc4.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[4], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[4]);
            tbTextErrorPlc4.Text = error;

            if (result == 0)
            {
                btnConnectPlc4.Enabled = false;
                btnDisconnectPlc4.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[4], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc4.Text = info.ModuleTypeName;
                    tbSerialNumberPlc4.Text = info.SerialNumber;
                    tbCopyrightPlc4.Text = info.Copyright;
                    tbAsNamePlc4.Text = info.ASName;
                    tbModuleNamePlc4.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[4], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc4.Text = orderCode.Code;
                    tbVersionPlc4.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }
        private void btnDisonnectPlc4_Click(object sender, EventArgs e)
        {
            S7Clients[4].Disconnect();
            tbTextErrorPlc4.Text = "Disconnected";
            tbIpAddressPlc4.Enabled = false;
            tbRackPlc4.Enabled = false;
            tbSlotPlc4.Enabled = false;
            btnConnectPlc4.Enabled = true;
            btnDisconnectPlc4.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc4_Click(object sender, EventArgs e)
        {
            richTextBoxPlc4.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc4.Text = richTextBoxPlc4.Text + dir + "\n";
            }
        }

        private void tbIpPlc4_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc4_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc4_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion

        /// <summary>
        /// Plc5
        /// </summary>
        #region Plc5
        private async void btnConnectPlc5_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc5.Text;
            int rack = tbRackPlc5.Text.ParseInt();
            int slot = tbSlotPlc5.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[5], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[5]);
            tbTextErrorPlc5.Text = error;

            if (result == 0)
            {
                btnConnectPlc5.Enabled = false;
                btnDisconnectPlc5.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[5], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc5.Text = info.ModuleTypeName;
                    tbSerialNumberPlc5.Text = info.SerialNumber;
                    tbCopyrightPlc5.Text = info.Copyright;
                    tbAsNamePlc5.Text = info.ASName;
                    tbModuleNamePlc5.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[5], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc5.Text = orderCode.Code;
                    tbVersionPlc5.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }
        private void btnDisonnectPlc5_Click(object sender, EventArgs e)
        {
            S7Clients[5].Disconnect();
            tbTextErrorPlc5.Text = "Disconnected";
            tbIpAddressPlc5.Enabled = false;
            tbRackPlc5.Enabled = false;
            tbSlotPlc5.Enabled = false;
            btnConnectPlc5.Enabled = true;
            btnDisconnectPlc5.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc5_Click(object sender, EventArgs e)
        {
            richTextBoxPlc5.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc5.Text = richTextBoxPlc5.Text + dir + "\n";
            }
        }

        private void tbIpPlc5_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc5_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc5_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion

        /// <summary>
        /// Plc6
        /// </summary>
        #region Plc6
        private async void btnConnectPlc6_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc6.Text;
            int rack = tbRackPlc6.Text.ParseInt();
            int slot = tbSlotPlc6.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[6], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[6]);
            tbTextErrorPlc6.Text = error;

            if (result == 0)
            {
                btnConnectPlc6.Enabled = false;
                btnDisconnectPlc6.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[6], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc6.Text = info.ModuleTypeName;
                    tbSerialNumberPlc6.Text = info.SerialNumber;
                    tbCopyrightPlc6.Text = info.Copyright;
                    tbAsNamePlc6.Text = info.ASName;
                    tbModuleNamePlc6.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[6], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc6.Text = orderCode.Code;
                    tbVersionPlc6.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }
        private void btnDisonnectPlc6_Click(object sender, EventArgs e)
        {
            S7Clients[6].Disconnect();
            tbTextErrorPlc6.Text = "Disconnected";
            tbIpAddressPlc6.Enabled = false;
            tbRackPlc6.Enabled = false;
            tbSlotPlc6.Enabled = false;
            btnConnectPlc6.Enabled = true;
            btnDisconnectPlc6.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc6_Click(object sender, EventArgs e)
        {
            richTextBoxPlc6.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc6.Text = richTextBoxPlc6.Text + dir + "\n";
            }
        }

        private void tbIpPlc6_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc6_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc6_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion

        /// <summary>
        /// Plc7
        /// </summary>
        #region Plc7
        private async void btnConnectPlc7_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc7.Text;
            int rack = tbRackPlc7.Text.ParseInt();
            int slot = tbSlotPlc7.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[7], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[7]);
            tbTextErrorPlc7.Text = error;

            if (result == 0)
            {
                btnConnectPlc7.Enabled = false;
                btnDisconnectPlc7.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[7], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc7.Text = info.ModuleTypeName;
                    tbSerialNumberPlc7.Text = info.SerialNumber;
                    tbCopyrightPlc7.Text = info.Copyright;
                    tbAsNamePlc7.Text = info.ASName;
                    tbModuleNamePlc7.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[7], ref orderCode, ref result);
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
            tbIpAddressPlc7.Enabled = false;
            tbRackPlc7.Enabled = false;
            tbSlotPlc7.Enabled = false;
            btnConnectPlc7.Enabled = true;
            btnDisconnectPlc7.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc7_Click(object sender, EventArgs e)
        {
            richTextBoxPlc7.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc7.Text = richTextBoxPlc7.Text + dir + "\n";
            }
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

        /// <summary>
        /// Plc8
        /// </summary>
        #region Plc8
        private async void btnConnectPlc8_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc8.Text;
            int rack = tbRackPlc8.Text.ParseInt();
            int slot = tbSlotPlc8.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[8], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[8]);
            tbTextErrorPlc8.Text = error;

            if (result == 0)
            {
                btnConnectPlc8.Enabled = false;
                btnDisconnectPlc8.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[8], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc8.Text = info.ModuleTypeName;
                    tbSerialNumberPlc8.Text = info.SerialNumber;
                    tbCopyrightPlc8.Text = info.Copyright;
                    tbAsNamePlc8.Text = info.ASName;
                    tbModuleNamePlc8.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[8], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc8.Text = orderCode.Code;
                    tbVersionPlc8.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }

        private void btnDisonnectPlc8_Click(object sender, EventArgs e)
        {
            S7Clients[8].Disconnect();
            tbTextErrorPlc8.Text = "Disconnected";
            tbIpAddressPlc8.Enabled = false;
            tbRackPlc8.Enabled = false;
            tbSlotPlc8.Enabled = false;
            btnConnectPlc8.Enabled = true;
            btnDisconnectPlc8.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc8_Click(object sender, EventArgs e)
        {
            richTextBoxPlc8.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc8.Text = richTextBoxPlc8.Text + dir + "\n";
            }
        }

        private void tbIpPlc8_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc8_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc8_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion

        /// <summary>
        /// Plc9
        /// </summary>
        #region Plc9
        private async void btnConnectPlc9_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc9.Text;
            int rack = tbRackPlc9.Text.ParseInt();
            int slot = tbSlotPlc9.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[9], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[9]);
            tbTextErrorPlc9.Text = error;

            if (result == 0)
            {
                btnConnectPlc9.Enabled = false;
                btnDisconnectPlc9.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[9], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc9.Text = info.ModuleTypeName;
                    tbSerialNumberPlc9.Text = info.SerialNumber;
                    tbCopyrightPlc9.Text = info.Copyright;
                    tbAsNamePlc9.Text = info.ASName;
                    tbModuleNamePlc9.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[9], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc9.Text = orderCode.Code;
                    tbVersionPlc9.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }

        private void btnDisonnectPlc9_Click(object sender, EventArgs e)
        {
            S7Clients[9].Disconnect();
            tbTextErrorPlc9.Text = "Disconnected";
            tbIpAddressPlc9.Enabled = false;
            tbRackPlc9.Enabled = false;
            tbSlotPlc9.Enabled = false;
            btnConnectPlc9.Enabled = true;
            btnDisconnectPlc9.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc9_Click(object sender, EventArgs e)
        {
            richTextBoxPlc9.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc9.Text = richTextBoxPlc9.Text + dir + "\n";
            }
        }

        private void tbIpPlc9_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc9_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc9_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion

        /// <summary>
        /// Plc10
        /// </summary>
        #region Plc10
        private async void btnConnectPlc10_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc10.Text;
            int rack = tbRackPlc10.Text.ParseInt();
            int slot = tbSlotPlc10.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[10], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[10]);
            tbTextErrorPlc10.Text = error;

            if (result == 0)
            {
                btnConnectPlc10.Enabled = false;
                btnDisconnectPlc10.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[10], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc10.Text = info.ModuleTypeName;
                    tbSerialNumberPlc10.Text = info.SerialNumber;
                    tbCopyrightPlc10.Text = info.Copyright;
                    tbAsNamePlc10.Text = info.ASName;
                    tbModuleNamePlc10.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[10], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc10.Text = orderCode.Code;
                    tbVersionPlc10.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }

        private void btnDisonnectPlc10_Click(object sender, EventArgs e)
        {
            S7Clients[10].Disconnect();
            tbTextErrorPlc10.Text = "Disconnected";
            tbIpAddressPlc10.Enabled = false;
            tbRackPlc10.Enabled = false;
            tbSlotPlc10.Enabled = false;
            btnConnectPlc10.Enabled = true;
            btnDisconnectPlc10.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc10_Click(object sender, EventArgs e)
        {
            richTextBoxPlc10.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc10.Text = richTextBoxPlc10.Text + dir + "\n";
            }
        }

        private void tbIpPlc10_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc10_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc10_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion

        /// <summary>
        /// Plc11
        /// </summary>
        #region Plc11
        private async void btnConnectPlc11_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc11.Text;
            int rack = tbRackPlc11.Text.ParseInt();
            int slot = tbSlotPlc11.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[11], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[11]);
            tbTextErrorPlc11.Text = error;

            if (result == 0)
            {
                btnConnectPlc11.Enabled = false;
                btnDisconnectPlc11.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[11], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc11.Text = info.ModuleTypeName;
                    tbSerialNumberPlc11.Text = info.SerialNumber;
                    tbCopyrightPlc11.Text = info.Copyright;
                    tbAsNamePlc11.Text = info.ASName;
                    tbModuleNamePlc11.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[11], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc11.Text = orderCode.Code;
                    tbVersionPlc11.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }

        private void btnDisonnectPlc11_Click(object sender, EventArgs e)
        {
            S7Clients[11].Disconnect();
            tbTextErrorPlc11.Text = "Disconnected";
            tbIpAddressPlc11.Enabled = false;
            tbRackPlc11.Enabled = false;
            tbSlotPlc11.Enabled = false;
            btnConnectPlc11.Enabled = true;
            btnDisconnectPlc11.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc11_Click(object sender, EventArgs e)
        {
            richTextBoxPlc11.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc11.Text = richTextBoxPlc11.Text + dir + "\n";
            }
        }

        private void tbIpPlc11_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc11_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc11_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion

        /// <summary>
        /// Plc12
        /// </summary>
        #region Plc12
        private async void btnConnectPlc12_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc12.Text;
            int rack = tbRackPlc12.Text.ParseInt();
            int slot = tbSlotPlc12.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[12], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[12]);
            tbTextErrorPlc12.Text = error;

            if (result == 0)
            {
                btnConnectPlc12.Enabled = false;
                btnDisconnectPlc12.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[12], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc12.Text = info.ModuleTypeName;
                    tbSerialNumberPlc12.Text = info.SerialNumber;
                    tbCopyrightPlc12.Text = info.Copyright;
                    tbAsNamePlc12.Text = info.ASName;
                    tbModuleNamePlc12.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[12], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc12.Text = orderCode.Code;
                    tbVersionPlc12.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }

        private void btnDisonnectPlc12_Click(object sender, EventArgs e)
        {
            S7Clients[12].Disconnect();
            tbTextErrorPlc12.Text = "Disconnected";
            tbIpAddressPlc12.Enabled = false;
            tbRackPlc12.Enabled = false;
            tbSlotPlc12.Enabled = false;
            btnConnectPlc12.Enabled = true;
            btnDisconnectPlc12.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc12_Click(object sender, EventArgs e)
        {
            richTextBoxPlc12.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc12.Text = richTextBoxPlc12.Text + dir + "\n";
            }
        }

        private void tbIpPlc12_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc12_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc12_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion

        /// <summary>
        /// Plc13
        /// </summary>
        #region Plc13
        private async void btnConnectPlc13_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc13.Text;
            int rack = tbRackPlc13.Text.ParseInt();
            int slot = tbSlotPlc13.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[13], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[13]);
            tbTextErrorPlc13.Text = error;

            if (result == 0)
            {
                btnConnectPlc13.Enabled = false;
                btnDisconnectPlc13.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[13], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc13.Text = info.ModuleTypeName;
                    tbSerialNumberPlc13.Text = info.SerialNumber;
                    tbCopyrightPlc13.Text = info.Copyright;
                    tbAsNamePlc13.Text = info.ASName;
                    tbModuleNamePlc13.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[13], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc13.Text = orderCode.Code;
                    tbVersionPlc13.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }

        private void btnDisonnectPlc13_Click(object sender, EventArgs e)
        {
            S7Clients[13].Disconnect();
            tbTextErrorPlc13.Text = "Disconnected";
            tbIpAddressPlc13.Enabled = false;
            tbRackPlc13.Enabled = false;
            tbSlotPlc13.Enabled = false;
            btnConnectPlc13.Enabled = true;
            btnDisconnectPlc13.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc13_Click(object sender, EventArgs e)
        {
            richTextBoxPlc13.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc13.Text = richTextBoxPlc13.Text + dir + "\n";
            }
        }

        private void tbIpPlc13_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc13_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc13_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        #endregion

        /// <summary>
        /// Plc14
        /// </summary>
        #region Plc14
        private async void btnConnectPlc14_Click(object sender, EventArgs e)
        {
            int result;
            string address = tbIpAddressPlc14.Text;
            int rack = tbRackPlc14.Text.ParseInt();
            int slot = tbSlotPlc14.Text.ParseInt();
            string error;

            result = await Global.ConnectToClientAsync(S7Clients[14], address, rack, slot);

            error = Global.ShowResultClient(result, S7Clients[14]);
            tbTextErrorPlc14.Text = error;

            if (result == 0)
            {
                btnConnectPlc14.Enabled = false;
                btnDisconnectPlc14.Enabled = true;
                //tabControl.Enabled = true;

                S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                Global.ReadCPUInfo(S7Clients[14], ref info, ref result);
                if (result == 0)
                {
                    tbModuleTypeNamePlc14.Text = info.ModuleTypeName;
                    tbSerialNumberPlc14.Text = info.SerialNumber;
                    tbCopyrightPlc14.Text = info.Copyright;
                    tbAsNamePlc14.Text = info.ASName;
                    tbModuleNamePlc14.Text = info.ModuleName;
                }

                S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                Global.ReadOrderCode(S7Clients[14], ref orderCode, ref result);
                if (result == 0)
                {
                    tbOrderCodePlc14.Text = orderCode.Code;
                    tbVersionPlc14.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                }
            }
        }

        private void btnDisonnectPlc14_Click(object sender, EventArgs e)
        {
            S7Clients[14].Disconnect();
            tbTextErrorPlc14.Text = "Disconnected";
            tbIpAddressPlc14.Enabled = false;
            tbRackPlc14.Enabled = false;
            tbSlotPlc14.Enabled = false;
            btnConnectPlc14.Enabled = true;
            btnDisconnectPlc14.Enabled = false;
            //tabControl.Enabled = false;
        }

        private void btnReadDirsPlc14_Click(object sender, EventArgs e)
        {
            richTextBoxPlc14.Text = string.Empty;
            string root = @"E:\Recipes";
            //Recipes.GetSubDirectories(root);
            foreach (string dir in Recipes.GetSubDirectories(root))
            {
                richTextBoxPlc14.Text = richTextBoxPlc14.Text + dir + "\n";
            }
        }

        private void tbIpPlc14_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbRackPlc14_MouseEnter(object sender, EventArgs e)
        {
            toolTipShow(sender, PlcInfoToolTip);
        }
        private void tbSlotPlc14_MouseEnter(object sender, EventArgs e)
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
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
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
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
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
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
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
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
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
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
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
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
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
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
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
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
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
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panelService.Visible = false;
        }
        private void btn10_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel10.Visible = true;           
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panelService.Visible = false;
        }
        private void btn11_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel11.Visible = true; 
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
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panelService.Visible = false;
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel12.Visible = true;
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
            panel11.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panelService.Visible = false;
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel13.Visible = true;
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
            panel11.Visible = false;
            panel12.Visible = false;            
            panel14.Visible = false;
            panelService.Visible = false;
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            panelMain.BackgroundImage = null;
            panel14.Visible = true;
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
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
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
            panel9.Visible = false;
            panel10.Visible = false;
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panelService.Visible = true;
        }
        private void panelService_VisibleChanged(object sender, EventArgs e)
        {
            if (panelService.Visible)
            {
                if (!myServiceForm.IsHandleCreated)
                {
                    myServiceForm = new ServiceForm() { Dock = DockStyle.None, TopLevel = false, TopMost = true };
                    myServiceForm.FormBorderStyle = FormBorderStyle.None;
                    panelService.Controls.Add(myServiceForm);
                    myServiceForm.Show();
                }
            }
            else
            {
                if (myServiceForm.IsHandleCreated)
                {
                    //myServiceForm.Dispose();
                }
            }
        }
        #endregion
        #endregion





        //Timer Form
        private void TimerForm_Tick(object sender, EventArgs e)
        {
            TimerForm.Stop();
            TimerForm.Enabled = false;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here

            _ticks++;
            //Show counter
            //textBoxTimerForm.Text = _ticks.ToString();

            if (_ticks >= 14)
            {
                _ticks = 0;
            }

            //btn1 - PLC1 Animation
            if (S7Clients[1].Connected)
            {
                btnConnectPlc1.Enabled = false;
                btnDisconnectPlc1.Enabled = true;
            }
            else
            {
                btnConnectPlc1.Enabled = true;
                btnDisconnectPlc1.Enabled = false;
            }
            if (S7Clients[1].Connected & ServicePlcToPcs[1].LifeBit)
            {
                btn1.BackColor = Color.Green;
            }
            else
            {
                btn1.BackColor = Color.LightGray;
            }
            //btn2 - PLC2 Animation
            if (S7Clients[2].Connected)
            {
                btnConnectPlc2.Enabled = false;
                btnDisconnectPlc2.Enabled = true;
            }
            else
            {
                btnConnectPlc2.Enabled = true;
                btnDisconnectPlc2.Enabled = false;
            }
            if (S7Clients[2].Connected & ServicePlcToPcs[2].LifeBit)
            {
                btn2.BackColor = Color.Green;
            }
            else
            {
                btn2.BackColor = Color.LightGray;
            }
            //btn3 - PLC3 Animation
            if (S7Clients[3].Connected)
            {
                btnConnectPlc3.Enabled = false;
                btnDisconnectPlc3.Enabled = true;
            }
            else
            {
                btnConnectPlc3.Enabled = true;
                btnDisconnectPlc3.Enabled = false;
            }
            if (S7Clients[3].Connected & ServicePlcToPcs[3].LifeBit)
            {
                btn3.BackColor = Color.Green;
            }
            else
            {
                btn3.BackColor = Color.LightGray;
            }
            //btn4 - PLC4 Animation
            if (S7Clients[4].Connected)
            {
                btnConnectPlc4.Enabled = false;
                btnDisconnectPlc4.Enabled = true;
            }
            else
            {
                btnConnectPlc4.Enabled = true;
                btnDisconnectPlc4.Enabled = false;
            }
            if (S7Clients[4].Connected & ServicePlcToPcs[4].LifeBit)
            {
                btn4.BackColor = Color.Green;
            }
            else
            {
                btn4.BackColor = Color.LightGray;
            }
            //btn5 - PLC5 Animation
            if (S7Clients[5].Connected)
            {
                btnConnectPlc5.Enabled = false;
                btnDisconnectPlc5.Enabled = true;
            }
            else
            {
                btnConnectPlc5.Enabled = true;
                btnDisconnectPlc5.Enabled = false;
            }
            if (S7Clients[5].Connected & ServicePlcToPcs[5].LifeBit)
            {
                btn5.BackColor = Color.Green;
            }
            else
            {
                btn5.BackColor = Color.LightGray;
            }
            //btn6 - PLC6 Animation
            if (S7Clients[6].Connected)
            {
                btnConnectPlc6.Enabled = false;
                btnDisconnectPlc6.Enabled = true;
            }
            else
            {
                btnConnectPlc6.Enabled = true;
                btnDisconnectPlc6.Enabled = false;
            }
            if (S7Clients[6].Connected & ServicePlcToPcs[6].LifeBit)
            {
                btn6.BackColor = Color.Green;
            }
            else
            {
                btn6.BackColor = Color.LightGray;
            }
            //btn7 - PLC7 Animation
            if (S7Clients[7].Connected)
            {
                btnConnectPlc7.Enabled = false;
                btnDisconnectPlc7.Enabled = true;
            }
            else
            {
                btnConnectPlc7.Enabled = true;
                btnDisconnectPlc7.Enabled = false;
            }
            if (S7Clients[7].Connected & ServicePlcToPcs[7].LifeBit)
            {
                btn7.BackColor = Color.Green;
            }
            else
            {
                btn7.BackColor = Color.LightGray;
            }
            //btn8 - PLC8 Animation
            if (S7Clients[8].Connected)
            {
                btnConnectPlc8.Enabled = false;
                btnDisconnectPlc8.Enabled = true;
            }
            else
            {
                btnConnectPlc8.Enabled = true;
                btnDisconnectPlc8.Enabled = false;
            }
            if (S7Clients[8].Connected & ServicePlcToPcs[8].LifeBit)
            {
                btn8.BackColor = Color.Green;
            }
            else
            {
                btn8.BackColor = Color.LightGray;
            }
            //btn9 - PLC9 Animation
            if (S7Clients[9].Connected)
            {
                btnConnectPlc9.Enabled = false;
                btnDisconnectPlc9.Enabled = true;
            }
            else
            {
                btnConnectPlc9.Enabled = true;
                btnDisconnectPlc9.Enabled = false;
            }
            if (S7Clients[9].Connected & ServicePlcToPcs[9].LifeBit)
            {
                btn9.BackColor = Color.Green;
            }
            else
            {
                btn9.BackColor = Color.LightGray;
            }

            //btn10 - PLC10 Animation
            if (S7Clients[10].Connected)
            {
                btnConnectPlc10.Enabled = false;
                btnDisconnectPlc10.Enabled = true;
            }
            else
            {
                btnConnectPlc10.Enabled = true;
                btnDisconnectPlc10.Enabled = false;
            }
            if (S7Clients[10].Connected & ServicePlcToPcs[10].LifeBit)
            {
                btn10.BackColor = Color.Green;
            }
            else
            {
                btn10.BackColor = Color.LightGray;
            }

            //btn11 - PLC11 Animation
            if (S7Clients[11].Connected)
            {
                btnConnectPlc11.Enabled = false;
                btnDisconnectPlc11.Enabled = true;
            }
            else
            {
                btnConnectPlc11.Enabled = true;
                btnDisconnectPlc11.Enabled = false;
            }
            if (S7Clients[11].Connected & ServicePlcToPcs[11].LifeBit)
            {
                btn11.BackColor = Color.Green;
            }
            else
            {
                btn11.BackColor = Color.LightGray;
            }

            //btn12 - PLC12 Animation
            if (S7Clients[12].Connected)
            {
                btnConnectPlc12.Enabled = false;
                btnDisconnectPlc12.Enabled = true;
            }
            else
            {
                btnConnectPlc12.Enabled = true;
                btnDisconnectPlc12.Enabled = false;
            }
            if (S7Clients[12].Connected & ServicePlcToPcs[12].LifeBit)
            {
                btn12.BackColor = Color.Green;
            }
            else
            {
                btn12.BackColor = Color.LightGray;
            }

            //btn13 - PLC13 Animation
            if (S7Clients[13].Connected)
            {
                btnConnectPlc13.Enabled = false;
                btnDisconnectPlc13.Enabled = true;
            }
            else
            {
                btnConnectPlc13.Enabled = true;
                btnDisconnectPlc13.Enabled = false;
            }
            if (S7Clients[13].Connected & ServicePlcToPcs[13].LifeBit)
            {
                btn13.BackColor = Color.Green;
            }
            else
            {
                btn13.BackColor = Color.LightGray;
            }

            //btn14 - PLC14 Animation
            if (S7Clients[14].Connected)
            {
                btnConnectPlc14.Enabled = false;
                btnDisconnectPlc14.Enabled = true;
            }
            else
            {
                btnConnectPlc14.Enabled = true;
                btnDisconnectPlc14.Enabled = false;
            }
            if (S7Clients[14].Connected & ServicePlcToPcs[14].LifeBit)
            {
                btn14.BackColor = Color.Green;
            }
            else
            {
                btn14.BackColor = Color.LightGray;
            }

            // the code that you want to measure ends here
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            //elapsedMs.ToString();
            TimerForm.Enabled = true;
            TimerForm.Start();
        }


        /// <summary>
        /// RecipesServiceMethods moved to WinS7Library.Recipes.cs static class
        /// </summary>
        #region RecipesServiceMethods
        
        #endregion


        /// <summary>
        /// Service methods form
        /// </summary>
        #region Service methods

        private async void ConnectClient(S7Client client, string address, int rack, int slot)
        {
            await Global.ConnectToClientAsync(client, address, rack, slot);
        }

        private async void ConnectClient(int plcnumber)
        {
            int result;
            switch (plcnumber)
            {
                case 1:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc1.Enabled = false;
                        btnDisconnectPlc1.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[1], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc1.Text = info.ModuleTypeName;
                            tbSerialNumberPlc1.Text = info.SerialNumber;
                            tbCopyrightPlc1.Text = info.Copyright;
                            tbAsNamePlc1.Text = info.ASName;
                            tbModuleNamePlc1.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[1], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc1.Text = orderCode.Code;
                            tbVersionPlc1.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 2:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc2.Enabled = false;
                        btnDisconnectPlc2.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[2], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc2.Text = info.ModuleTypeName;
                            tbSerialNumberPlc2.Text = info.SerialNumber;
                            tbCopyrightPlc2.Text = info.Copyright;
                            tbAsNamePlc2.Text = info.ASName;
                            tbModuleNamePlc2.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[2], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc2.Text = orderCode.Code;
                            tbVersionPlc2.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 3:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc3.Enabled = false;
                        btnDisconnectPlc3.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[3], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc3.Text = info.ModuleTypeName;
                            tbSerialNumberPlc3.Text = info.SerialNumber;
                            tbCopyrightPlc3.Text = info.Copyright;
                            tbAsNamePlc3.Text = info.ASName;
                            tbModuleNamePlc3.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[3], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc3.Text = orderCode.Code;
                            tbVersionPlc3.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 4:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc4.Enabled = false;
                        btnDisconnectPlc4.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[4], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc4.Text = info.ModuleTypeName;
                            tbSerialNumberPlc4.Text = info.SerialNumber;
                            tbCopyrightPlc4.Text = info.Copyright;
                            tbAsNamePlc4.Text = info.ASName;
                            tbModuleNamePlc4.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[4], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc4.Text = orderCode.Code;
                            tbVersionPlc4.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 5:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc5.Enabled = false;
                        btnDisconnectPlc5.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[5], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc5.Text = info.ModuleTypeName;
                            tbSerialNumberPlc5.Text = info.SerialNumber;
                            tbCopyrightPlc5.Text = info.Copyright;
                            tbAsNamePlc5.Text = info.ASName;
                            tbModuleNamePlc5.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[5], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc5.Text = orderCode.Code;
                            tbVersionPlc5.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 6:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc6.Enabled = false;
                        btnDisconnectPlc6.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[6], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc6.Text = info.ModuleTypeName;
                            tbSerialNumberPlc6.Text = info.SerialNumber;
                            tbCopyrightPlc6.Text = info.Copyright;
                            tbAsNamePlc6.Text = info.ASName;
                            tbModuleNamePlc6.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[6], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc6.Text = orderCode.Code;
                            tbVersionPlc6.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 7:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc7.Enabled = false;
                        btnDisconnectPlc7.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[7], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc7.Text = info.ModuleTypeName;
                            tbSerialNumberPlc7.Text = info.SerialNumber;
                            tbCopyrightPlc7.Text = info.Copyright;
                            tbAsNamePlc7.Text = info.ASName;
                            tbModuleNamePlc7.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[7], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc7.Text = orderCode.Code;
                            tbVersionPlc7.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                        break;
                case 8:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc8.Enabled = false;
                        btnDisconnectPlc8.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[8], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc8.Text = info.ModuleTypeName;
                            tbSerialNumberPlc8.Text = info.SerialNumber;
                            tbCopyrightPlc8.Text = info.Copyright;
                            tbAsNamePlc8.Text = info.ASName;
                            tbModuleNamePlc8.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[8], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc8.Text = orderCode.Code;
                            tbVersionPlc8.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 9:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc9.Enabled = false;
                        btnDisconnectPlc9.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[9], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc9.Text = info.ModuleTypeName;
                            tbSerialNumberPlc9.Text = info.SerialNumber;
                            tbCopyrightPlc9.Text = info.Copyright;
                            tbAsNamePlc9.Text = info.ASName;
                            tbModuleNamePlc9.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[9], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc9.Text = orderCode.Code;
                            tbVersionPlc9.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 10:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc10.Enabled = false;
                        btnDisconnectPlc10.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[10], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc10.Text = info.ModuleTypeName;
                            tbSerialNumberPlc10.Text = info.SerialNumber;
                            tbCopyrightPlc10.Text = info.Copyright;
                            tbAsNamePlc10.Text = info.ASName;
                            tbModuleNamePlc10.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[10], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc10.Text = orderCode.Code;
                            tbVersionPlc10.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 11:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc11.Enabled = false;
                        btnDisconnectPlc11.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[11], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc11.Text = info.ModuleTypeName;
                            tbSerialNumberPlc11.Text = info.SerialNumber;
                            tbCopyrightPlc11.Text = info.Copyright;
                            tbAsNamePlc11.Text = info.ASName;
                            tbModuleNamePlc11.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[11], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc11.Text = orderCode.Code;
                            tbVersionPlc11.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 12:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc12.Enabled = false;
                        btnDisconnectPlc12.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[12], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc12.Text = info.ModuleTypeName;
                            tbSerialNumberPlc12.Text = info.SerialNumber;
                            tbCopyrightPlc12.Text = info.Copyright;
                            tbAsNamePlc12.Text = info.ASName;
                            tbModuleNamePlc12.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[12], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc12.Text = orderCode.Code;
                            tbVersionPlc12.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 13:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc13.Enabled = false;
                        btnDisconnectPlc13.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[13], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc13.Text = info.ModuleTypeName;
                            tbSerialNumberPlc13.Text = info.SerialNumber;
                            tbCopyrightPlc13.Text = info.Copyright;
                            tbAsNamePlc13.Text = info.ASName;
                            tbModuleNamePlc13.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[13], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc13.Text = orderCode.Code;
                            tbVersionPlc13.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 14:
                    result = await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    if (result == 0)
                    {
                        btnConnectPlc14.Enabled = false;
                        btnDisconnectPlc14.Enabled = true;
                        //tabControl.Enabled = true;

                        S7Client.S7CpuInfo info = new S7Client.S7CpuInfo();
                        Global.ReadCPUInfo(S7Clients[14], ref info, ref result);
                        if (result == 0)
                        {
                            tbModuleTypeNamePlc14.Text = info.ModuleTypeName;
                            tbSerialNumberPlc14.Text = info.SerialNumber;
                            tbCopyrightPlc14.Text = info.Copyright;
                            tbAsNamePlc14.Text = info.ASName;
                            tbModuleNamePlc14.Text = info.ModuleName;
                        }

                        S7Client.S7OrderCode orderCode = new S7Client.S7OrderCode();
                        Global.ReadOrderCode(S7Clients[14], ref orderCode, ref result);
                        if (result == 0)
                        {
                            tbOrderCodePlc14.Text = orderCode.Code;
                            tbVersionPlc14.Text = orderCode.V1.ToString() + "." + orderCode.V2.ToString() + "." + orderCode.V3.ToString();
                        }
                    }
                    break;
                case 15:
                    await Global.ConnectToClientAsync(S7Clients[plcnumber], PlcIpAddress[plcnumber], PlcRack[plcnumber].ParseInt(), PlcSlot[plcnumber].ParseInt());
                    break;
                default:
                    break;
            }
        }

        private void toolTipShow(object sender, string tooltipinfo)
        {
            ToolTipGenerator.ToolTipShow(sender, tooltipinfo);
        }

        private void ShowResult(int result, S7Client client)
        {
            // This function returns a textual explaination of the error code

            string error = Global.ShowResultClient(result, client);

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
                                tbTextErrorPlc3.Text = error;
                                break;
                            case "PLC4":
                                tbTextErrorPlc4.Text = error;
                                break;
                            case "PLC5":
                                tbTextErrorPlc5.Text = error;
                                break;
                            case "PLC6":
                                tbTextErrorPlc6.Text = error;
                                break;
                            case "PLC7":
                                tbTextErrorPlc7.Text = error;
                                break;
                            case "PLC8":
                                tbTextErrorPlc7.Text = error;
                                break;
                            case "PLC9":
                                tbTextErrorPlc7.Text = error;
                                break;
                            case "PLC10":
                                tbTextErrorPlc7.Text = error;
                                break;
                            case "PLC11":
                                tbTextErrorPlc7.Text = error;
                                break;
                            case "PLC12":
                                tbTextErrorPlc7.Text = error;
                                break;
                            case "PLC13":
                                tbTextErrorPlc7.Text = error;
                                break;
                            case "PLC14":
                                tbTextErrorPlc7.Text = error;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        #endregion

    }
}
