using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Library.Model
{
    public class CommData
    {
        public string AppenderNameGlobal { get; set; }
        public string AppenderNameRecipe { get; set; }
        public log4net.ILog LogGlobal { get; set; }
        public log4net.ILog LogRecipe { get; set; }
        public DateTime LifeBitTimeStamp { get; set; }
        public int N { get; set; }

        //DB Numbers
        public readonly int DB_DAT_HE = 7000;
        public readonly int DB_DAT_Config = 7001;
        public readonly int DB_DAT_N2 = 7002;
        public readonly int DB_DAT_Werkzeug = 7003;
        public readonly int DB_DAT_MWerkzeug = 7004;
        public readonly int DB_Service_WKZ_Liste = 7005;
        public readonly int DB_Service_PlcToPc = 7006;
        public readonly int DB_Service_PcToPlc = 7007;
        public readonly int DB_DAT_Betrieb = 7008;

        public readonly int DB_100_KVT_zu_ATG = 2000;
        public readonly int DB_DAT_ProcessData = 2099;

        //DB Length in bytes
        public readonly int DB_DAT_HE_Length = 240;
        public readonly int DB_DAT_Config_Length = 2796;
        public readonly int DB_DAT_N2_Length = 640;
        public readonly int DB_DAT_Werkzeug_Length = 260; // v.4 Changes for customer 28.04.2021 -> 40 Signs
        public readonly int DB_DAT_MWerkzeug_Length = 40;
        public readonly int DB_Service_WKZ_Liste_Length = 5632;   // v.4 Changes for customer 28.04.2021 -> 40 Signs
        public readonly int DB_Service_PlcToPc_Length = 130;  // v.4 Changes for customer 28.04.2021 -> 40 Signs
        public readonly int DB_Service_PcToPlc_Length = 12;
        public readonly int DB_DAT_Betrieb_Length = 36;

        /// <summary>
        /// byte 614 - > byte 2842 (real 618 -> 698, string 802 -> 2842)
        /// </summary>
        public readonly int DB_100_KVT_zu_ATG_BDruck_DMX = 2228;
        public readonly int DB_DAT_ProcessData_Length = 1956;
    }
}
