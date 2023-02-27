using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Library.Model
{
    // Defines that you want to serialize this class
    [Serializable()]
    public class DatBetrieb : ISerializable
    {
        public int StdSollHE { get; set; }
        public int StdIstHE { get; set; }
        public int StdIntervalHE { get; set; }
        public int StdSollOB { get; set; }
        public int StdIstOB { get; set; }
        public int StdIntervalOB { get; set; }
        public int StdSollUN { get; set; }
        public int StdIstUN { get; set; }
        public int StdIntervalUN { get; set; }


        //ctor
        public DatBetrieb() { }


        // Serialization function (Stores Object Data in File)
        // SerializationInfo holds the key value pairs
        // StreamingContext can hold additional info
        // but we aren't using it here
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        // The deserialize function (Removes Object Data from File)
        public DatBetrieb(SerializationInfo info, StreamingContext ctxt)
        {
        }
    }
}
