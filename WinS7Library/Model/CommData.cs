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
        public int DB_DAT_HE = 7000;
        public int DB_DAT_Config = 7001;
        public int DB_DAT_N2 = 7002;
        public int DB_DAT_Werkzeug = 7003;
        public int DB_DAT_MWerkzeug = 7004;
        public int DB_Service_WKZ_Liste = 7005;
        public int DB_Service_PlcToPc = 7006;
        public int DB_Service_PcToPlc = 7007;

        //DB Length in bytes
        public int DB_DAT_HE_Length = 240;
        public int DB_DAT_Config_Length = 2796;
        public int DB_DAT_N2_Length = 640;
        public int DB_DAT_Werkzeug_Length = 260; // v.4 Changes for customer 28.04.2021 -> 40 Signs
        public int DB_DAT_MWerkzeug_Length = 40;
        public int DB_Service_WKZ_Liste_Length = 5632;   // v.4 Changes for customer 28.04.2021 -> 40 Signs
        public int DB_Service_PlcToPc_Length = 122;  // v.4 Changes for customer 28.04.2021 -> 40 Signs
        public int DB_Service_PcToPlc_Length = 6;
    }
}
