using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Library.Model
{
    public class ServicePlcToPc
    {
        public bool LifeBit { get; set; }
        public short ErrorStatus { get; set; }
        public bool WKZEinlesen { get; set; }
        public bool ParamsLaden { get; set; }
        public bool SondernKonfig { get; set; }
        public bool ParamsSichern { get; set; }
        public bool DatLoeschen { get; set; }
        public bool BetriebsDLaden { get; set; }
        public bool BetriebsDSichern { get; set; }
        public int AktAnlage { get; set; }
        public short AktWerkzeugID { get; set; }
        public string AktWerkzeugName { get; set; }
        public short ParamHE { get; set; }
        public short ParamConfig { get; set; }
        public short ParamN2 { get; set; }
        public short ParamWerkzeug { get; set; }
        public short ParamMWerkzeug { get; set; }
        public short LoeschWerkzeugID { get; set; }
        public uint AusweissNr { get; set; }
        public string AusweissName { get; set; }
        public short AktWerkzeugOB { get; set; }
        public short AktWerkzeugUN { get; set; }
        public short  AktWerkzeugHE { get; set; }
        public bool BerstdruckAuto { get; set; }
        public bool BerstdruckSQLSichern { get; set; }
        public bool BerstdruckSichernFertig { get; set; }
        public bool BerstdruckRestaur { get; set; }
    }
}
