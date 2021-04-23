using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Library
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
    }
}
