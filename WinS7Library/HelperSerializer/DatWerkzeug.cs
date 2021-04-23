using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinS7Library.HelperSerializer
{
    // Defines that you want to serialize this class
    [Serializable()]
    public class DatWerkzeug : ISerializable
    {
        //property
        public KennungClass Kennung { get; set; } = new KennungClass();
        public AktivierungSchritteClass AktivierungSchritte { get; set; } = new AktivierungSchritteClass();
        public ParameterSchritteClass ParameterSchritte { get; set; } = new ParameterSchritteClass();
        public AchsenStromClass AchsenStrom { get; set; } = new AchsenStromClass();
        public ZaehlerClass Zaehler { get; set; } = new ZaehlerClass();
        public AktivierungN2GasClass AktivierungN2Gas { get; set; } = new AktivierungN2GasClass();
        public AktivierungSontigesClass AktivierungSontiges { get; set; } = new AktivierungSontigesClass();
        public BursterDigiforceKraftWegClass BursterDigiforceKraftWeg { get; set; } = new BursterDigiforceKraftWegClass();
        public BursterDigiforceMinsdestkraftClass BursterDigiforceMinsdestkraft { get; set; } = new BursterDigiforceMinsdestkraftClass();
        public IRCameraClass IRCamera { get; set; } = new IRCameraClass();
        public DMXCheckClass DMXCheck { get; set; } = new DMXCheckClass();
        public Ausgleichshub Ausgleichshub { get; set; } = new Ausgleichshub();

        //ctor
        public DatWerkzeug() { }


        // Serialization function (Stores Object Data in File)
        // SerializationInfo holds the key value pairs
        // StreamingContext can hold additional info
        // but we aren't using it here
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        // The deserialize function (Removes Object Data from File)
        public DatWerkzeug(SerializationInfo info, StreamingContext ctxt)
        {
        }
    }





    //**************************************************
    //Kennung --->
    #region //Kennung

    // Defines that you want to serialize this class
    [Serializable()]
    public class KennungClass
    {
        //property
        public string ProgrammName { get; set; } = String.Empty;
        public byte RFIDHE { get; set; } = 0;
        public byte RFIDOB { get; set; } = 0;
        public byte RFIDUN { get; set; } = 0;

        //ctor
        public KennungClass() { }
    }
    #endregion
    //Kennung <---
    //**************************************************


    //**************************************************
    //AktivierungSchritte --->
    #region //AktivierungSchritte

    // Defines that you want to serialize this class
    [Serializable()]
    public class AktivierungSchritteClass
    {
        //property
        public bool SpannenT1 { get; set; } = false;
        public bool SpannenT2 { get; set; } = false;
        public bool Abholtakt { get; set; } = false;
        public bool Prueftakt { get; set; } = false;
        public bool WarmVor { get; set; } = false;
        public bool WarmEnde { get; set; } = false;
        public bool Auswerfer { get; set; } = false;
        public bool Roboter { get; set; } = false;
        public bool Reserve4 { get; set; } = false;
        public bool Reserve5 { get; set; } = false;
        public bool Reserve6 { get; set; } = false;
        public bool Reserve7 { get; set; } = false;
        public bool Reserve8 { get; set; } = false;
        public bool Reserve9 { get; set; } = false;
        public bool StopNachFuegen { get; set; } = false;
        public bool OeffnenNachFuegen { get; set; } = false;

        //ctor
        public AktivierungSchritteClass() { }
    } 
    #endregion
    //AktivierungSchritte <---
    //**************************************************


    //**************************************************
    //ParameterSchritte --->
    #region //ParameterSchritte

    // Defines that you want to serialize this class
    [Serializable()]
    public class ParameterSchritteClass
    {
        //property
        public AbholSchrittClass Abhol { get; set; } = new AbholSchrittClass();
        public HEVorpositionSchrittClass HEVorposition { get; set; } = new HEVorpositionSchrittClass();
        public Warm1SchrittClass Warm1 { get; set; } = new Warm1SchrittClass();
        public Warm2SchrittClass Warm2 { get; set; } = new Warm2SchrittClass();
        public FuegeSchrittClass Fuege { get; set; } = new FuegeSchrittClass();
        public SchmelzbildSchrittClass Schmelzbild { get; set; } = new SchmelzbildSchrittClass();

        //ctor
        public ParameterSchritteClass() { }

    }


    //**************************************************
    //ParameterSchritte.Abhol --->
    #region //ParameterSchritte.Abhol
    // Defines that you want to serialize this class
    [Serializable()]
    public class AbholSchrittClass
    {
        //property
        public AbholAchseA1A2Class A1 { get; set; } = new AbholAchseA1A2Class();
        public AbholAchseA1A2Class A2 { get; set; } = new AbholAchseA1A2Class();

        //ctor
        public AbholSchrittClass() { }
    }
    // Defines that you want to serialize this class
    [Serializable()]
    public class AbholAchseA1A2Class
    {
        //property
        public int VorPosition { get; set; } = 0;
        public int EndPosition { get; set; } = 0;
        public int Geschwindigkeit { get; set; } = 0;

        //ctor
        public AbholAchseA1A2Class() { }
    }
    #endregion
    //ParameterSchritte.Abhol <---
    //**************************************************


    //**************************************************
    //ParameterSchritte.HEVorposition --->
    #region //ParameterSchritte.HEVorposition
    // Defines that you want to serialize this class
    [Serializable()]
    public class HEVorpositionSchrittClass
    {
        //property
        public HEVorpositionAchseA1A2Class A1 { get; set; } = new HEVorpositionAchseA1A2Class();
        public HEVorpositionAchseA1A2Class A2 { get; set; } = new HEVorpositionAchseA1A2Class();

        //ctor
        public HEVorpositionSchrittClass() { }
    }
    // Defines that you want to serialize this class
    [Serializable()]
    public class HEVorpositionAchseA1A2Class
    {
        //property
        public int Position { get; set; } = 0;
        public int Geschwindigkeit { get; set; } = 0;

        //ctor
        public HEVorpositionAchseA1A2Class() { }
    }
    #endregion
    //ParameterSchritte.HEVorposition <---
    //**************************************************


    //**************************************************
    //ParameterSchritte.Warm1 --->
    #region //ParameterSchritte.Warm1
    // Defines that you want to serialize this class
    [Serializable()]
    public class Warm1SchrittClass
    {
        //property
        public Warm1AchseA1A2Class A1 { get; set; } = new Warm1AchseA1A2Class();
        public Warm1AchseA1A2Class A2 { get; set; } = new Warm1AchseA1A2Class();
        public Warm1AchseA3Class A3 { get; set; } = new Warm1AchseA3Class();
        public int Zeit { get; set; } = 0;
        //ctor
        public Warm1SchrittClass() { }
    }
    // Defines that you want to serialize this class
    [Serializable()]
    public class Warm1AchseA1A2Class
    {
        //property
        public int Position { get; set; } = 0;
        public int Geschwindigkeit { get; set; } = 0;

        //ctor
        public Warm1AchseA1A2Class() { }
    }
    // Defines that you want to serialize this class
    [Serializable()]
    public class Warm1AchseA3Class
    {
        //property
        public int Position { get; set; } = 0;

        //ctor
        public Warm1AchseA3Class() { }
    }
    #endregion
    //ParameterSchritte.Warm1 <---
    //**************************************************


    //**************************************************
    //ParameterSchritte.Warm2 --->
    #region //ParameterSchritte.Warm2
    // Defines that you want to serialize this class
    [Serializable()]
    public class Warm2SchrittClass
    {
        //property
        public Warm2AchseA1A2Class A1 { get; set; } = new Warm2AchseA1A2Class();
        public Warm2AchseA1A2Class A2 { get; set; } = new Warm2AchseA1A2Class();
        public int Zeit { get; set; } = 0;
        //ctor
        public Warm2SchrittClass() { }
    }
    // Defines that you want to serialize this class
    [Serializable()]
    public class Warm2AchseA1A2Class
    {
        //property
        public int Position { get; set; } = 0;
        public int Geschwindigkeit { get; set; } = 0;

        //ctor
        public Warm2AchseA1A2Class() { }
    }
    #endregion
    //ParameterSchritte.Warm2 <---
    //**************************************************


    //**************************************************
    //ParameterSchritte.Fuege --->
    #region //ParameterSchritte.Fuege
    // Defines that you want to serialize this class
    [Serializable()]
    public class FuegeSchrittClass
    {
        //property
        public FuegeAchseA1Class A1 { get; set; } = new FuegeAchseA1Class();
        public FuegeAchseA2Class A2 { get; set; } = new FuegeAchseA2Class();
        public int Kuehlzeit { get; set; } = 0;
        //ctor
        public FuegeSchrittClass() { }
    }
    // Defines that you want to serialize this class
    [Serializable()]
    public class FuegeAchseA1Class
    {
        //property
        public int VorPosition { get; set; } = 0;
        public int EndPosition { get; set; } = 0;
        public int Geschwindigkeit { get; set; } = 0;
        public int OeffnungswegNachFuegen { get; set; } = 0;
        public int RueckhubGeschwingkeitFuegen { get; set; } = 0;

        //ctor
        public FuegeAchseA1Class() { }
    }
    // Defines that you want to serialize this class
    [Serializable()]
    public class FuegeAchseA2Class
    {
        //property
        public int VorPosition { get; set; } = 0;
        public int EndPosition { get; set; } = 0;
        public int Geschwindigkeit { get; set; } = 0;

        //ctor
        public FuegeAchseA2Class() { }
    }
    #endregion
    //ParameterSchritte.Fuege <---
    //**************************************************


    //**************************************************
    //ParameterSchritte.Schmelzbild --->
    #region //ParameterSchritte.Schmelzbild
    // Defines that you want to serialize this class
    [Serializable()]
    public class SchmelzbildSchrittClass
    {
        //property
        public SchmelzbildAchseA1Class A1 { get; set; } = new SchmelzbildAchseA1Class();

        //ctor
        public SchmelzbildSchrittClass() { }
    }
    // Defines that you want to serialize this class
    [Serializable()]
    public class SchmelzbildAchseA1Class
    {
        //property
        public int Position { get; set; } = 0;
        public int Geschwindigkeit { get; set; } = 0;

        //ctor
        public SchmelzbildAchseA1Class() { }
    }
    #endregion
    //ParameterSchritte.Schmelzbild <---
    //**************************************************

    #endregion
    //ParameterSchritte <---
    //**************************************************


    //**************************************************
    //AchsenStrom --->
    #region //AchsenStrom

    // Defines that you want to serialize this class
    [Serializable()]
    public class AchsenStromClass
    {
        //property
        public short FuegekraftMaxA1 { get; set; } = 0;
        public short FuegekraftMinA1 { get; set; } = 0;
        public short FuegekraftMaxA2 { get; set; } = 0;
        public short FuegekraftMinA2 { get; set; } = 0;
        public byte Strommessung { get; set; } = 0;
        public short FuegenStart { get; set; } = 0;

        //ctor
        public AchsenStromClass() { }
    }
    #endregion
    //AchsenStrom <---
    //**************************************************


    //**************************************************
    //Zaehler --->
    #region //Zaehler

    // Defines that you want to serialize this class
    [Serializable()]
    public class ZaehlerClass
    {
        //property
        public short NIONF { get; set; } = 0;
        public short NIOVF { get; set; } = 0;
        public short Stueckzaehler { get; set; } = 0;

        //ctor
        public ZaehlerClass() { }
    }
    #endregion
    //Zaehler <---
    //**************************************************

    //**************************************************
    //AktivierungN2Gas --->
    #region //AktivierungN2Gas

    // Defines that you want to serialize this class
    [Serializable()]
    public class AktivierungN2GasClass
    {
        //property
        public bool N2G1 { get; set; } = false;
        public bool N2G2 { get; set; } = false;
        public bool N2G3 { get; set; } = false;
        public bool N2G4 { get; set; } = false;
        public bool Reserve5 { get; set; } = false;
        public bool Reserve6 { get; set; } = false;
        public bool Reserve7 { get; set; } = false;
        public bool Reserve8 { get; set; } = false;

        //ctor
        public AktivierungN2GasClass() { }
    }
    #endregion
    //AktivierungN2Gas <---
    //**************************************************


    //**************************************************
    //AktiverungSontiges --->
    #region //AktiverungSontiges

    // Defines that you want to serialize this class
    [Serializable()]
    public class AktivierungSontigesClass
    {
        //property
        public bool ExternerE1 { get; set; } = false;
        public bool ExternerE2 { get; set; } = false;
        public bool ExternePruefung1 { get; set; } = false;
        public bool ExternePruefung2 { get; set; } = false;
        public bool OptionUmschaltung1 { get; set; } = false;
        public bool Reserve6 { get; set; } = false;
        public bool Reserve7 { get; set; } = false;
        public bool Reserve8 { get; set; } = false;
        public bool Reserve9 { get; set; } = false;
        public bool Reserve10 { get; set; } = false;
        public bool Reserve11 { get; set; } = false;
        public bool Reserve12 { get; set; } = false;
        public bool Reserve13 { get; set; } = false;
        public bool Reserve14 { get; set; } = false;
        public bool Reserve15 { get; set; } = false;
        public bool Reserve16 { get; set; } = false;

        //ctor
        public AktivierungSontigesClass() { }
    }
    #endregion
    //AktiverungSontiges <---
    //**************************************************


    //**************************************************
    //BuersterDigiforceKraftWeg --->
    #region //BuersterDigiforceKraftWeg

    // Defines that you want to serialize this class
    [Serializable()]
    public class BursterDigiforceKraftWegClass
    {
        //property
        public byte FuegewegKraftNest1 { get; set; } = 0;
        public byte FuegewegKraftNest2 { get; set; } = 0;
        public short BursterProgrammNest1 { get; set; } = 0;
        public short BursterProgrammNest2 { get; set; } = 0;

        //ctor
        public BursterDigiforceKraftWegClass() { }
    }
    #endregion
    //BuersterDigiforceKraftWeg <---
    //**************************************************


    //**************************************************
    //BursterDigiforceMinsdestkraft --->
    #region //BursterDigiforceMinsdestkraft

    // Defines that you want to serialize this class
    [Serializable()]
    public class BursterDigiforceMinsdestkraftClass
    {
        //property
        public bool BursterMindestKraftAktiv { get; set; } = false;
        public float MindestkraftSollNest1 { get; set; } = 0;
        public float MindestkraftToleranzPlusNest1 { get; set; } = 0;
        public float MindestkraftToleranzMinusNest1 { get; set; } = 0;
        public float MindestkraftSollNest2 { get; set; } = 0;
        public float MindestkraftToleranzPlusNest2 { get; set; } = 0;
        public float MindestkraftToleranzMinusNest2 { get; set; } = 0;

        //ctor
        public BursterDigiforceMinsdestkraftClass() { }
    }
    #endregion
    //BursterDigiforceMinsdestkraft <---
    //**************************************************


    //**************************************************
    //IRCamera --->
    #region //IRCamera

    // Defines that you want to serialize this class
    [Serializable()]
    public class IRCameraClass
    {
        //property
        public ushort KameraProgramm { get; set; } = 0;
        public byte KameraSchalter { get; set; } = 0;
        public int KameraLuftschleier { get; set; } = 0;
        public int KameraStartFuegenNachIR { get; set; } = 0;
        public int KameraFehlerVrzNachIR { get; set; } = 0;

        //ctor
        public IRCameraClass() { }
    }
    #endregion
    //IRCamera <---
    //**************************************************


    //**************************************************
    //DMXCheck --->
    #region //DMXCheck

    // Defines that you want to serialize this class
    [Serializable()]
    public class DMXCheckClass
    {
        //property
        public int DayDifferenceSet { get; set; } = 0;
        public bool ActiveDMXCheck { get; set; } = false;

        //ctor
        public DMXCheckClass() { }
    }
    #endregion
    //DMXCheck <---
    //**************************************************

    //**************************************************
    //Ausgleichshub --->
    #region //Ausgleichshub

    // Defines that you want to serialize this class
    [Serializable()]
    public class Ausgleichshub
    {
        //property
        public double Links { get; set; } = 0.0;
        public double Rechts { get; set; } = 0.0;

        //ctor
        public Ausgleichshub() { }
    }
    #endregion
    //DMXCheck <---
    //**************************************************

}
