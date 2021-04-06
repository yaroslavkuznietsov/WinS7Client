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
    public class DatConfig : ISerializable
    {
        //property
        public Schritt GS { get; set; } = new Schritt();
        public Schritt ZYA { get; set; } = new Schritt();
        public Schritt T1 { get; set; } = new Schritt();
        public Schritt T2 { get; set; } = new Schritt();
        public Schritt PN { get; set; } = new Schritt();
        public Schritt AV { get; set; } = new Schritt();
        public Schritt AP { get; set; } = new Schritt();
        public Schritt PT { get; set; } = new Schritt();
        public Schritt WV { get; set; } = new Schritt();
        public Schritt WE { get; set; } = new Schritt();
        public Schritt KU { get; set; } = new Schritt();
        public Schritt AU { get; set; } = new Schritt();
        public Schritt ZYE { get; set; } = new Schritt();
        public Schritt RO { get; set; } = new Schritt();
        public Schritt Reserve { get; set; } = new Schritt();
        public Teilekontrolle TK { get; set; } = new Teilekontrolle();
        public WerkzeugConfig WKZOB { get; set; } = new WerkzeugConfig();
        public WerkzeugConfig WKZUN { get; set; } = new WerkzeugConfig();

        //ctor
        public DatConfig() { }


        // Serialization function (Stores Object Data in File)
        // SerializationInfo holds the key value pairs
        // StreamingContext can hold additional info
        // but we aren't using it here
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        // The deserialize function (Removes Object Data from File)
        public DatConfig(SerializationInfo info, StreamingContext ctxt)
        {
        }
    }



    #region Schritt
    // Defines that you want to serialize this class
    [Serializable()]
    public class UDTConfigSchritt
    {
        //property
        public short E_01_16 { get; set; } = 0;
        public short E_17_32 { get; set; } = 0;
        public short E_Vakuum { get; set; } = 0;
        public short A_Vakuum { get; set; } = 0;
        public short A_Ventile_1_8 { get; set; } = 0;

        //ctor
        public UDTConfigSchritt() { }
    }

    // Defines that you want to serialize this class
    [Serializable()]
    public class Schritt
    {
        //property
        public UDTConfigSchritt OB { get; set; } = new UDTConfigSchritt();
        public UDTConfigSchritt OB_IG { get; set; } = new UDTConfigSchritt();
        public UDTConfigSchritt UN { get; set; } = new UDTConfigSchritt();
        public UDTConfigSchritt UN_IG { get; set; } = new UDTConfigSchritt();

        //ctor
        public Schritt() { }
    }

    // Defines that you want to serialize this class
    [Serializable()]
    public class Teilekontrolle
    {
        //property
        public UDTConfigSchritt OB { get; set; } = new UDTConfigSchritt();
        public UDTConfigSchritt UN { get; set; } = new UDTConfigSchritt();

        //ctor
        public Teilekontrolle() { }
    }
    #endregion



    #region WerkzeugConfig
    // Defines that you want to serialize this class
    [Serializable()]
    public class NameOfInput
    {
        //property
        public string EO01 { get; set; } = String.Empty;
        public string EO02 { get; set; } = String.Empty;
        public string EO03 { get; set; } = String.Empty;
        public string EO04 { get; set; } = String.Empty;
        public string EO05 { get; set; } = String.Empty;
        public string EO06 { get; set; } = String.Empty;
        public string EO07 { get; set; } = String.Empty;
        public string EO08 { get; set; } = String.Empty;
        public string EO09 { get; set; } = String.Empty;
        public string EO10 { get; set; } = String.Empty;
        public string EO11 { get; set; } = String.Empty;
        public string EO12 { get; set; } = String.Empty;
        public string EO13 { get; set; } = String.Empty;
        public string EO14 { get; set; } = String.Empty;
        public string EO15 { get; set; } = String.Empty;
        public string EO16 { get; set; } = String.Empty;
        public string EO17 { get; set; } = String.Empty;
        public string EO18 { get; set; } = String.Empty;
        public string EO19 { get; set; } = String.Empty;
        public string EO20 { get; set; } = String.Empty;
        public string EO21 { get; set; } = String.Empty;
        public string EO22 { get; set; } = String.Empty;
        public string EO23 { get; set; } = String.Empty;
        public string EO24 { get; set; } = String.Empty;
        public string EO25 { get; set; } = String.Empty;
        public string EO26 { get; set; } = String.Empty;
        public string EO27 { get; set; } = String.Empty;
        public string EO28 { get; set; } = String.Empty;
        public string EO29 { get; set; } = String.Empty;
        public string EO30 { get; set; } = String.Empty;
        public string EO31 { get; set; } = String.Empty;
        public string EO32 { get; set; } = String.Empty;
        public string VO121 { get; set; } = String.Empty;
        public string VO141 { get; set; } = String.Empty;
        public string VO122 { get; set; } = String.Empty;
        public string VO142 { get; set; } = String.Empty;
        public string VO123 { get; set; } = String.Empty;
        public string VO143 { get; set; } = String.Empty;
        public string VO124 { get; set; } = String.Empty;
        public string VO144 { get; set; } = String.Empty;
        public string VO125 { get; set; } = String.Empty;
        public string VO145 { get; set; } = String.Empty;
        public string VO126 { get; set; } = String.Empty;
        public string VO146 { get; set; } = String.Empty;
        public string VO127 { get; set; } = String.Empty;
        public string VO147 { get; set; } = String.Empty;
        public string VO128 { get; set; } = String.Empty;
        public string VO148 { get; set; } = String.Empty;

        //ctor
        public NameOfInput() { }
    }

    // Defines that you want to serialize this class
    [Serializable()]
    public class TimeOfVentil
    {
        //property
        public short TVO121 { get; set; } = 0;
        public short TVO141 { get; set; } = 0;
        public short TVO122 { get; set; } = 0;
        public short TVO142 { get; set; } = 0;
        public short TVO123 { get; set; } = 0;
        public short TVO143 { get; set; } = 0;
        public short TVO124 { get; set; } = 0;
        public short TVO144 { get; set; } = 0;
        public short TVO125 { get; set; } = 0;
        public short TVO145 { get; set; } = 0;
        public short TVO126 { get; set; } = 0;
        public short TVO146 { get; set; } = 0;
        public short TVO127 { get; set; } = 0;
        public short TVO147 { get; set; } = 0;
        public short TVO128 { get; set; } = 0;
        public short TVO148 { get; set; } = 0;

        //ctor
        public TimeOfVentil() { }
    }

    // Defines that you want to serialize this class
    [Serializable()]
    public class WerkzeugConfig
    {
        //property
        public NameOfInput Name { get; set; } = new NameOfInput();
        public TimeOfVentil Time { get; set; } = new TimeOfVentil();

        //ctor
        public WerkzeugConfig() { }
    } 
    #endregion
}

