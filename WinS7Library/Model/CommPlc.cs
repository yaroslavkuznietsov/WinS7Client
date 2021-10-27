using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinS7Library.Helper;

namespace WinS7Library.Model
{
    public static class CommPlc
    {
        public static void ReadPlcState(S7Client client, ref CommService commService, ref ServicePlcToPc servicePlcToPc)
        {
            byte[] buffer = new byte[65536];
            int sizeRead = 0;
            int result = 0;
            string root = @"E:\Recipes";
            string error = string.Empty;

            Global.ReadAreaPlc(client, S7Consts.S7AreaDB, commService.DB_PlcToPc, 0, commService.DB_PlcToPc_Length,
                               S7Consts.S7WLByte, buffer, ref sizeRead, ref result);

            servicePlcToPc.LifeBit = S7.GetBitAt(buffer, 0, 0);
            servicePlcToPc.ErrorStatus = S7.GetIntAt(buffer, 2);
            servicePlcToPc.WKZEinlesen = S7.GetBitAt(buffer, 4, 0);
            servicePlcToPc.ParamsLaden = S7.GetBitAt(buffer, 4, 1);
            servicePlcToPc.SondernKonfig = S7.GetBitAt(buffer, 4, 2);
            servicePlcToPc.ParamsSichern = S7.GetBitAt(buffer, 4, 3);
            servicePlcToPc.DatLoeschen = S7.GetBitAt(buffer, 4, 4);
            servicePlcToPc.AktAnlage = S7.GetDIntAt(buffer, 6);
            servicePlcToPc.AktWerkzeugID = S7.GetIntAt(buffer, 10);
            servicePlcToPc.AktWerkzeugName = S7.GetStringAt(buffer, 12);
            servicePlcToPc.ParamHE = S7.GetIntAt(buffer, 54);
            servicePlcToPc.ParamConfig = S7.GetIntAt(buffer, 56);
            servicePlcToPc.ParamN2 = S7.GetIntAt(buffer, 58);
            servicePlcToPc.ParamWerkzeug = S7.GetIntAt(buffer, 60);
            servicePlcToPc.ParamMWerkzeug = S7.GetIntAt(buffer, 62);
            servicePlcToPc.LoeschWerkzeugID = S7.GetIntAt(buffer, 64);
            servicePlcToPc.AusweissNr = S7.GetDWordAt(buffer, 66);
            servicePlcToPc.AusweissName = S7.GetStringAt(buffer, 70);


        }
    }
}
