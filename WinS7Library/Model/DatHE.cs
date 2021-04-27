using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinS7Library.Model
{
    // Defines that you want to serialize this class
    [Serializable()]
    public class DatHE : ISerializable
    {
        //property
        public HK HK01 { get; set; } = new HK();
        public HK HK02 { get; set; } = new HK();
        public HK HK03 { get; set; } = new HK();
        public HK HK04 { get; set; } = new HK();
        public HK HK05 { get; set; } = new HK();
        public HK HK06 { get; set; } = new HK();
        public HK HK07 { get; set; } = new HK();
        public HK HK08 { get; set; } = new HK();
        public HK HK09 { get; set; } = new HK();
        public HK HK10 { get; set; } = new HK();
        public HK HK11 { get; set; } = new HK();
        public HK HK12 { get; set; } = new HK();
        public HK HK13 { get; set; } = new HK();
        public HK HK14 { get; set; } = new HK();
        public HK HK15 { get; set; } = new HK();
        public HK HK16 { get; set; } = new HK();
        public HK HK17 { get; set; } = new HK();
        public HK HK18 { get; set; } = new HK();
        public HK HK19 { get; set; } = new HK();
        public HK HK20 { get; set; } = new HK();
        public HK HK21 { get; set; } = new HK();
        public HK HK22 { get; set; } = new HK();
        public HK HK23 { get; set; } = new HK();
        public HK HK24 { get; set; } = new HK();

        //ctor
        public DatHE() { }


        // Serialization function (Stores Object Data in File)
        // SerializationInfo holds the key value pairs
        // StreamingContext can hold additional info
        // but we aren't using it here
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        // The deserialize function (Removes Object Data from File)
        public DatHE(SerializationInfo info, StreamingContext ctxt)
        {
        }
    }

    // Defines that you want to serialize this class
    [Serializable()]
    public class HK
    {
        //property
        public short TempSoll { get; set; } = 0;
        public short ToleranzPlus { get; set; } = 0;
        public short ToleranzMinus { get; set; } = 0;
        public short TempTaktung { get; set; } = 0;
        public short Impulsdauer { get; set; } = 0;
        public short Pausendauer { get; set; } = 0;
        public short OffsetAT { get; set; } = 0;
        public short PiAT { get; set; } = 0;
        public short TMaxAT { get; set; } = 0;
        public bool Aktiv { get; set; } = false;

        //ctor
        public HK() { }
    }
}
