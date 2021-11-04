using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Library.Model
{
    public class ServicePcToPlc
    {
        public bool LifeBit { get; set; }
        public short ErrorStatus { get; set; }
        public bool WKZEinlesenFertig { get; set; }
        public bool ParamsLadenFertig { get; set; }
        public bool ParamsSichernFertig { get; set; }
        public bool DatLoeschenFertig { get; set; }
        public bool BetriebsDLadenFertig { get; set; }
        public bool BetriebsDSichernFertig { get; set; }
        public bool ParamHEOK { get; set; }
        public bool ParamConfigOK { get; set; }
        public bool ParamN2OK { get; set; }
        public bool ParamWerkzeugOK { get; set; }
        public bool ParamMWerkzeugOK { get; set; }
        
    }
}
