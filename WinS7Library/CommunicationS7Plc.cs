using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinS7Library.Helper;
using WinS7Library.Interfaces;
using WinS7Library.Model;

namespace WinS7Library
{
    public class CommunicationS7Plc : ICommunicationPlc
    {
        private readonly S7Client client;
        private readonly CommData commData;

        public CommunicationS7Plc(S7Client client, CommData commData)
        {
            this.client = client;
            this.commData = commData;
        }






        public ServicePlcToPc ReadPlcToPc()
        {
            byte[] buffer = new byte[65536];
            int sizeRead = default;
            int result;
            result = client.ReadArea(S7Consts.S7AreaDB, commData.DB_Service_PlcToPc, 0, commData.DB_Service_PlcToPc_Length, S7Consts.S7WLByte, buffer, ref sizeRead);

            ServicePlcToPc plcToPc = BufferToPlcToPc(buffer);

            return plcToPc;
        }
        private ServicePlcToPc BufferToPlcToPc(byte[] buffer)
        {
            ServicePlcToPc plcToPc = new ServicePlcToPc();

            plcToPc.LifeBit = S7.GetBitAt(buffer, 0, 0);
            plcToPc.ErrorStatus = S7.GetIntAt(buffer, 2);
            plcToPc.WKZEinlesen = S7.GetBitAt(buffer, 4, 0);
            plcToPc.ParamsLaden = S7.GetBitAt(buffer, 4, 1);
            plcToPc.SondernKonfig = S7.GetBitAt(buffer, 4, 2);
            plcToPc.ParamsSichern = S7.GetBitAt(buffer, 4, 3);
            plcToPc.DatLoeschen = S7.GetBitAt(buffer, 4, 4);
            plcToPc.BetriebsDLaden = S7.GetBitAt(buffer, 4, 5);
            plcToPc.BetriebsDSichern = S7.GetBitAt(buffer, 4, 6);
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
            plcToPc.AktWerkzeugOB = S7.GetIntAt(buffer, 122);
            plcToPc.AktWerkzeugUN = S7.GetIntAt(buffer, 124);

            return plcToPc;
        }

        public void WritePcToPlc(ServicePcToPlc servicePcToPlc)
        {
            byte[] buffer = new byte[65536];
            buffer = PcToPlcToBuffer(servicePcToPlc);

            int sizeRead = default;
            int result;
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_Service_PcToPlc, 0, commData.DB_Service_PcToPlc_Length, S7Consts.S7WLByte, buffer, ref sizeRead);
        }
        private byte[] PcToPlcToBuffer(ServicePcToPlc pcToPlc)
        {
            byte[] buffer = new byte[65536];

            S7.SetBitAt(ref buffer, 0, 0, pcToPlc.LifeBit);
            S7.SetIntAt(buffer, 2, pcToPlc.ErrorStatus);
            S7.SetBitAt(ref buffer, 4, 0, pcToPlc.WKZEinlesenFertig);
            S7.SetBitAt(ref buffer, 4, 1, pcToPlc.ParamsLadenFertig);
            S7.SetBitAt(ref buffer, 4, 3, pcToPlc.ParamsSichernFertig);
            S7.SetBitAt(ref buffer, 4, 4, pcToPlc.DatLoeschenFertig);
            S7.SetBitAt(ref buffer, 4, 5, pcToPlc.BetriebsDLadenFertig);
            S7.SetBitAt(ref buffer, 4, 6, pcToPlc.BetriebsDSichernFertig);
            S7.SetBitAt(ref buffer, 5, 0, pcToPlc.ParamHEOK);
            S7.SetBitAt(ref buffer, 5, 1, pcToPlc.ParamConfigOK);
            S7.SetBitAt(ref buffer, 5, 2, pcToPlc.ParamN2OK);
            S7.SetBitAt(ref buffer, 5, 3, pcToPlc.ParamWerkzeugOK);
            S7.SetBitAt(ref buffer, 5, 4, pcToPlc.ParamMWerkzeugOK);

            return buffer;
        }


        public void WriteToolListToPlc(string[] subdirectoryEntries, ref int result)
        {
            byte[] buffer = new byte[65536];
            int sizeRead = default;
            //int result;
            Recipes.ToolListClear(ref buffer);
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_Service_WKZ_Liste, 0, commData.DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref sizeRead);

            Recipes.ToolListFillWithRecipes(subdirectoryEntries, ref buffer);
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_Service_WKZ_Liste, 0, commData.DB_Service_WKZ_Liste_Length, S7Consts.S7WLByte, buffer, ref sizeRead);
        }


        public DatHE ReadDatHePlc()
        {
            byte[] buffer = new byte[65536];
            int sizeRead = default;
            int result;
            string error = default;

            result = client.ReadArea(S7Consts.S7AreaDB, commData.DB_DAT_HE, 0, commData.DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref sizeRead);
            DatHE datHE = Serializer.BufferToDatHE(buffer, ref error);

            return datHE;
        }
        public void WriteDatHePlc(DatHE datHE)
        {
            byte[] buffer = new byte[65536];
            int sizeRead = default;
            int result;
            string error = default;

            Global.ClearBuffer(ref buffer);
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_DAT_HE, 0, commData.DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref sizeRead);

            Serializer.DatHEToBuffer(datHE, buffer, ref error);
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_DAT_HE, 0, commData.DB_DAT_HE_Length, S7Consts.S7WLByte, buffer, ref sizeRead);
        }


        public DatConfig ReadDatConfigPlc()
        {
            byte[] buffer = new byte[65536];
            int sizeRead = default;
            int result;
            string error = default;

            result = client.ReadArea(S7Consts.S7AreaDB, commData.DB_DAT_Config, 0, commData.DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref sizeRead);
            DatConfig datConfig = Serializer.BufferToDatConfig(buffer, ref error);

            return datConfig;
        }
        public void WriteDatConfigPlc(DatConfig datConfig)
        {
            byte[] buffer = new byte[65536];
            int sizeRead = default;
            int result;
            string error = default;

            Global.ClearBuffer(ref buffer);
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_DAT_Config, 0, commData.DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref sizeRead);

            Serializer.DatConfigToBuffer(datConfig, buffer, ref error);
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_DAT_Config, 0, commData.DB_DAT_Config_Length, S7Consts.S7WLByte, buffer, ref sizeRead);
        }


        public DatN2 ReadDatN2Plc()
        {
            byte[] buffer = new byte[65536];
            int sizeRead = default;
            int result;
            string error = default;

            result = client.ReadArea(S7Consts.S7AreaDB, commData.DB_DAT_N2, 0, commData.DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref sizeRead);
            DatN2 datN2 = Serializer.BufferToDatN2(buffer, ref error);

            return datN2;
        }
        public void WriteDatN2Plc(DatN2 datN2)
        {
            byte[] buffer = new byte[65536];
            int sizeRead = default;
            int result;
            string error = default;

            Global.ClearBuffer(ref buffer);
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_DAT_N2, 0, commData.DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref sizeRead);

            Serializer.DatN2ToBuffer(datN2, buffer, ref error);
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_DAT_N2, 0, commData.DB_DAT_N2_Length, S7Consts.S7WLByte, buffer, ref sizeRead);
        }


        public DatWerkzeug ReadDatWerkzeugPlc()
        {
            byte[] buffer = new byte[65536];
            int sizeRead = default;
            int result;
            string error = default;

            result = client.ReadArea(S7Consts.S7AreaDB, commData.DB_DAT_Werkzeug, 0, commData.DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead);
            DatWerkzeug datWerkzeug = Serializer.BufferToDatWerkzeug(buffer, ref error);

            return datWerkzeug;
        }
        public void WriteDatWerkzeugPlc(DatWerkzeug datWerkzeug)
        {
            byte[] buffer = new byte[65536];
            int sizeRead = default;
            int result;
            string error = default;

            Global.ClearBuffer(ref buffer);
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_DAT_Werkzeug, 0, commData.DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead);

            Serializer.DatWerkzeugToBuffer(datWerkzeug, buffer, ref error);
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_DAT_Werkzeug, 0, commData.DB_DAT_Werkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead);
        }


        public DatMWerkzeug ReadDatMWerkzeugPlc()
        {
            byte[] buffer = new byte[65536];
            int sizeRead = default;
            int result;
            string error = default;

            result = client.ReadArea(S7Consts.S7AreaDB, commData.DB_DAT_MWerkzeug, 0, commData.DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead);
            DatMWerkzeug datMWerkzeug = Serializer.BufferToDatMWerkzeug(buffer, ref error);

            return datMWerkzeug;
        }
        public void WriteDatMWerkzeugPlc(DatMWerkzeug datMWerkzeug)
        {
            byte[] buffer = new byte[65536];
            int sizeRead = default;
            int result;
            string error = default;

            Global.ClearBuffer(ref buffer);
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_DAT_MWerkzeug, 0, commData.DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead);

            Serializer.DatMWerkzeugToBuffer(datMWerkzeug, buffer, ref error);
            result = client.WriteArea(S7Consts.S7AreaDB, commData.DB_DAT_MWerkzeug, 0, commData.DB_DAT_MWerkzeug_Length, S7Consts.S7WLByte, buffer, ref sizeRead);
        }

        
    }
}
