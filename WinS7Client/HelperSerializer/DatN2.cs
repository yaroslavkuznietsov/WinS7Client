using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinS7Client
{
    // Defines that you want to serialize this class
    [Serializable()]
    public class DatN2 : ISerializable
    {
        //property
        public Propventil Propventil01 { get; set; } = new Propventil();
        public Propventil Propventil02 { get; set; } = new Propventil();
        public Propventil Propventil03 { get; set; } = new Propventil();
        public Propventil Propventil04 { get; set; } = new Propventil();
        public Propventil Propventil05 { get; set; } = new Propventil();
        public Propventil Propventil06 { get; set; } = new Propventil();
        public Propventil Propventil07 { get; set; } = new Propventil();
        public Propventil Propventil08 { get; set; } = new Propventil();
        public Propventil Propventil09 { get; set; } = new Propventil();
        public Propventil Propventil10 { get; set; } = new Propventil();
        public Propventil Propventil11 { get; set; } = new Propventil();
        public Propventil Propventil12 { get; set; } = new Propventil();
        public Propventil Propventil13 { get; set; } = new Propventil();
        public Propventil Propventil14 { get; set; } = new Propventil();
        public Propventil Propventil15 { get; set; } = new Propventil();
        public Propventil Propventil16 { get; set; } = new Propventil();
        public Propventil Propventil17 { get; set; } = new Propventil();
        public Propventil Propventil18 { get; set; } = new Propventil();
        public Propventil Propventil19 { get; set; } = new Propventil();
        public Propventil Propventil20 { get; set; } = new Propventil();
        public Propventil Propventil21 { get; set; } = new Propventil();
        public Propventil Propventil22 { get; set; } = new Propventil();
        public Propventil Propventil23 { get; set; } = new Propventil();
        public Propventil Propventil24 { get; set; } = new Propventil();
        public Propventil Propventil25 { get; set; } = new Propventil();
        public Propventil Propventil26 { get; set; } = new Propventil();
        public Propventil Propventil27 { get; set; } = new Propventil();
        public Propventil Propventil28 { get; set; } = new Propventil();
        public Propventil Propventil29 { get; set; } = new Propventil();
        public Propventil Propventil30 { get; set; } = new Propventil();
        public Propventil Propventil31 { get; set; } = new Propventil();
        public Propventil Propventil32 { get; set; } = new Propventil();
        public Propventil Propventil33 { get; set; } = new Propventil();
        public Propventil Propventil34 { get; set; } = new Propventil();
        public Propventil Propventil35 { get; set; } = new Propventil();
        public Propventil Propventil36 { get; set; } = new Propventil();
        public Propventil Propventil37 { get; set; } = new Propventil();
        public Propventil Propventil38 { get; set; } = new Propventil();
        public Propventil Propventil39 { get; set; } = new Propventil();
        public Propventil Propventil40 { get; set; } = new Propventil();
        public Propventil Propventil41 { get; set; } = new Propventil();
        public Propventil Propventil42 { get; set; } = new Propventil();
        public Propventil Propventil43 { get; set; } = new Propventil();
        public Propventil Propventil44 { get; set; } = new Propventil();
        public Propventil Propventil45 { get; set; } = new Propventil();
        public Propventil Propventil46 { get; set; } = new Propventil();
        public Propventil Propventil47 { get; set; } = new Propventil();
        public Propventil Propventil48 { get; set; } = new Propventil();
        public Propventil Propventil49 { get; set; } = new Propventil();
        public Propventil Propventil50 { get; set; } = new Propventil();
        public Propventil Propventil51 { get; set; } = new Propventil();
        public Propventil Propventil52 { get; set; } = new Propventil();
        public Propventil Propventil53 { get; set; } = new Propventil();
        public Propventil Propventil54 { get; set; } = new Propventil();
        public Propventil Propventil55 { get; set; } = new Propventil();
        public Propventil Propventil56 { get; set; } = new Propventil();
        public Propventil Propventil57 { get; set; } = new Propventil();
        public Propventil Propventil58 { get; set; } = new Propventil();
        public Propventil Propventil59 { get; set; } = new Propventil();
        public Propventil Propventil60 { get; set; } = new Propventil();

        //ctor
        public DatN2() { }


        // Serialization function (Stores Object Data in File)
        // SerializationInfo holds the key value pairs
        // StreamingContext can hold additional info
        // but we aren't using it here
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        // The deserialize function (Removes Object Data from File)
        public DatN2(SerializationInfo info, StreamingContext ctxt)
        {
        }
    }

    // Defines that you want to serialize this class
    [Serializable()]
    public class Propventil
    {
        //property
        public double Soll { get; set; } = 0.0;
        public double ToleranzPlus { get; set; } = 0.0;
        public double ToleranzMinus { get; set; } = 0.0;
        public double Einschaltverzoegerung { get; set; } = 0.0;

        //ctor
        public Propventil() { }
    }
}
