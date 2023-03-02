using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinS7Library.Model;
using WinS7Library.Model.Export;

namespace WinS7Library.Interfaces
{
    public interface ICommunicationPlc
    {
        ServicePlcToPc ReadPlcToPc();
        void WritePcToPlc(ServicePcToPlc servicePcToPlc);
        void WriteToolListToPlc(string[] subdirectoryEntries, ref int result);

        DatHE ReadDatHePlc();
        void WriteDatHePlc(DatHE datHE);
        DatConfig ReadDatConfigPlc();
        void WriteDatConfigPlc(DatConfig datConfig);
        DatN2 ReadDatN2Plc();
        void WriteDatN2Plc(DatN2 datN2);
        DatWerkzeug ReadDatWerkzeugPlc();
        void WriteDatWerkzeugPlc(DatWerkzeug datWerkzeug);
        DatMWerkzeug ReadDatMWerkzeugPlc();
        void WriteDatMWerkzeugPlc(DatMWerkzeug datMWerkzeug);


        void WriteBerstdruckListPlc(List<Berstdruck> berstdruckList);
        ProcessData ReadProcessDataPlc();
    }
}
