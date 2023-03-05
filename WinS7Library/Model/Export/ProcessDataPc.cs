using CsvHelper.Configuration.Attributes;
using System;

namespace WinS7Library.Model.Export
{
    /// <summary>
    /// Attributes based on CsvHelper NuGet Package
    /// https://joshclose.github.io/CsvHelper/examples/configuration/attributes/
    /// </summary>
    public class ProcessDataPc
    {
        protected ProcessDataPc(ProcessData state)
        {
            State = state;
        }

        [Ignore]
        public ProcessData State { get; protected set; }


        [Name("Datum/Uhrzeit")]
        public string DatumUhrzeit { get; set; } = $"{DateTime.Now:yyyy-MM-dd+HH:mm:ss}";  //A Feld 0 2023-02-27+10:09:29

        [Name("Produktname")]
        public string Produktname => State.Produktname; //B Feld 1

        #region DMXCode
        [Name("DMX-Code 1")]
        public string DmxCode1 => State.DmxCode1; //C Feld 2

        [Name("DMX-Code 2")]
        public string DmxCode2 => State.DmxCode2; //D Feld 3

        [Name("DMX-Code 3")]
        public string DmxCode3 => State.DmxCode3; //E Feld 4

        [Name("DMX-Code 4")]
        public string DmxCode4 => State.DmxCode4; //F Feld 5

        [Name("DMX-Code 5")]
        public string DmxCode5 => State.DmxCode5; //G Feld 6

        [Name("DMX-Code 6")]
        public string DmxCode6 => State.DmxCode6; //H Feld 7

        [Name("DMX-Code 7")]
        public string DmxCode7 => State.DmxCode7; //I Feld 8

        [Name("DMX-Code 8")]
        public string DmxCode8 => State.DmxCode8; //J Feld 9

        #endregion

        [Name(" I.O./N.I.O. Schweissung")]
        public string Schweissungsergebnis => State.SchweissungsergebnisNio == 1 ? "NOK" : "OK"; //K Feld 10
                
        [Name("Warmzeit_1[s]")]
        public int WarmZeit1Wert => State.WarmZeit1Wert; //L WARMZEIT_1 WERT in [s] Feld 11
        
        [Name("Warmzeit_2[s]")]
        public int WarmZei2Wert => State.WarmZei2Wert; //M WARMZEIT_2 WERT [s]   Feld 12
        
        [Name("Kühlzeit[s]")]
        public int KuehlZeitWert => State.KuehlZeitWert; //N KUEHLZEIT WERT in [s] Feld 13
        
        [Name("Umstellzeit[s]")]
        public int UmstellZeitWert => State.UmstellZeitWert; //O UMSTELLZEIT WERT in [s] Feld 14
        
        [Name("Zykluszeit[s]")]
        public int ZyklusZeitWert => State.ZyklusZeitWert; //P ZYKLUSZEIT WERT in [s] Feld 15
        
        [Name("Warmposition_1 A1[mm]")]
        public int WarmPosition1ObenWert => State.WarmPosition1ObenWert; //Q WARMPOSITION_1 OBEN WERT in [mm]   Feld 16
           
        [Name("Warmposition_1 A2[mm]")]
        public int WarmPosition1UntenWert => State.WarmPosition1UntenWert; //R WARMPOSITION_1 UNTEN WERT in [mm]   Feld 17
                  
        [Name("Warmposition_2 A1[mm]")]
        public int WarmPosition2ObenWert => State.WarmPosition2ObenWert; //S WARMPOSITION_2 OBEN WERT in [mm]   Feld 18
                
        [Name("Warmposition_2 A2[mm]")]
        public int WarmPosition2UntenWert => State.WarmPosition2UntenWert; //T WARMPOSITION_2 UNTEN WERT in [mm]   Feld 19
            
        [Name("Warmposition A3[mm]")]
        public int WarmPositionA3 => State.WarmPositionA3; //U WARMPOSITION HEIZELEMENT WERT in [mm]   Feld 20
           
        [Name("Fügeposition A1[mm]")]
        public int FuegePositionObenWert => State.FuegePositionObenWert; //V FUEGEPOSITION OBEN WERT [mm]   Feld 21
          
        [Name("Fügeposition A2[mm]")]
        public int FuegePositionUntenWert => State.FuegePositionUntenWert; //W FUEGEPOSITION UNTEN WERT [mm]   Feld 22
           
        [Name("Fügestrom A1(OB) [A]")]
        public int FuegeStromA1 => State.FuegeStromA1; //X Fügestrom A1(OB) [A]  Feld 23

        [Name("Fügestrom A2(UN) [A]")]
        public int FuegeStromA2 => State.FuegeStromA2; //W Fügestrom A2(UN) [A]  Feld 24


        #region Temperaturen Heizelement
        [Name("Temperatur HK1 Soll/Ist[°C]")]
        public string TempHeizelement1WertSollIst => $"{State.TempHeizelement1WertSoll}/{State.TempHeizelement1WertIst}";
        //public int TempHeizelement1WertSoll { get; set; } = default; //Z TEMP_HEIZELEMENT_1 WERTSOLL in [°C]   Feld 25
        //public int TempHeizelement1WertIst { get; set; } = default; //Z TEMP_HEIZELEMENT_1 WERTIST in [°C]   Feld 25

        [Name("Temperatur HK2 Soll/Ist [°C]")]
        public string TempHeizelement2WertSollIst => $"{State.TempHeizelement2WertSoll}/{State.TempHeizelement2WertIst}";
        //public int TempHeizelement2WertSoll { get; set; } = default; //AA TEMP_HEIZELEMENT_2 WERTSOLL in [°C]   Feld 26
        //public int TempHeizelement2WertIst { get; set; } = default; //AA TEMP_HEIZELEMENT_2 WERTIST in [°C]   Feld 26

        [Name("Temperatur HK3 Soll/Ist [°C]")]
        public string TempHeizelement3WertSollIst => $"{State.TempHeizelement3WertSoll}/{State.TempHeizelement3WertIst}";
        //public int TempHeizelement3WertSoll { get; set; } = default; //AB TEMP_HEIZELEMENT_3 WERTSOLL in [°C]   Feld 27
        //public int TempHeizelement3WertIst { get; set; } = default; //AB TEMP_HEIZELEMENT_3 WERTIST in [°C]   Feld 27

        [Name("Temperatur HK4 Soll/Ist [°C]")]
        public string TempHeizelement4WertSollIst => $"{State.TempHeizelement4WertSoll}/{State.TempHeizelement4WertSoll}";
        //public int TempHeizelement4WertSoll { get; set; } = default; //AC TEMP_HEIZELEMENT_4 WERTSOLL in [°C]   Feld 28
        //public int TempHeizelement4WertIst { get; set; } = default; //AC TEMP_HEIZELEMENT_4 WERTIST in [°C]   Feld 28

        [Name("Temperatur HK5 Soll/Ist [°C]")]
        public string TempHeizelement5WertSollIst => $"{State.TempHeizelement5WertSoll}/{State.TempHeizelement5WertIst}";
        //public int TempHeizelement5WertSoll { get; set; } = default; //AD TEMP_HEIZELEMENT_5 WERTSOLL in [°C]   Feld 29
        //public int TempHeizelement5WertIst { get; set; } = default; //AD TEMP_HEIZELEMENT_5 WERTIST in [°C]   Feld 29

        [Name("Temperatur HK6 Soll/Ist [°C]")]
        public string TempHeizelement6WertSollIst => $"{State.TempHeizelement6WertSoll}/{State.TempHeizelement6WertIst}";
        //public int TempHeizelement6WertSoll { get; set; } = default; //AE TEMP_HEIZELEMENT_6 WERTSOLL in [°C]   Feld 30
        //public int TempHeizelement6WertIst { get; set; } = default; //AE TEMP_HEIZELEMENT_6 WERTIST in [°C]   Feld 30

        [Name("Temperatur HK7 Soll/Ist [°C]")]
        public string TempHeizelement7WertSollIst => $"{State.TempHeizelement7WertSoll}/{State.TempHeizelement7WertIst}";
        //public int TempHeizelement7WertSoll { get; set; } = default; //AF TEMP_HEIZELEMENT_7 WERTSOLL in [°C]   Feld 31
        //public int TempHeizelement7WertIst { get; set; } = default; //AF TEMP_HEIZELEMENT_7 WERTIST in [°C]   Feld 31

        [Name("Temperatur HK8 Soll/Ist [°C]")]
        public string TempHeizelement8WertSollIst => $"{State.TempHeizelement8WertSoll}/{State.TempHeizelement8WertIst}";
        //public int TempHeizelement8WertSoll { get; set; } = default; //AG TEMP_HEIZELEMENT_8 WERTSOLL in [°C]   Feld 32
        //public int TempHeizelement8WertIst { get; set; } = default; //AG TEMP_HEIZELEMENT_8 WERTIST in [°C]   Feld 32

        [Name("Temperatur HK9 Soll/Ist [°C]")]
        public string TempHeizelement9WertSollIst => $"{State.TempHeizelement9WertSoll}/{State.TempHeizelement9WertIst}";
        //public int TempHeizelement9WertSoll { get; set; } = default; //AH TEMP_HEIZELEMENT_9 WERTSOLL in [°C]   Feld 33
        //public int TempHeizelement9WertIst { get; set; } = default; //AH TEMP_HEIZELEMENT_9 WERTIST in [°C]   Feld 33

        [Name("Temperatur HK10 Soll/Ist [°C]")]
        public string TempHeizelement10WertSollIst => $"{State.TempHeizelement10WertSoll}/{State.TempHeizelement10WertIst}";
        //public int TempHeizelement10WertSoll { get; set; } = default; //AI TEMP_HEIZELEMENT_10 WERTSOLL in [°C]   Feld 34
        //public int TempHeizelement10WertIst { get; set; } = default; //AI TEMP_HEIZELEMENT_10 WERTIST in [°C]   Feld 34

        [Name("Temperatur HK11 Soll/Ist [°C]")]
        public string TempHeizelement11WertSollIst => $"{State.TempHeizelement11WertSoll}/{State.TempHeizelement11WertIst}";
        //public int TempHeizelement11WertSoll { get; set; } = default; //AJ TEMP_HEIZELEMENT_11 WERTSOLL in [°C]   Feld 35
        //public int TempHeizelement11WertIst { get; set; } = default; //AJ TEMP_HEIZELEMENT_11 WERTIST in [°C]   Feld 35

        [Name("Temperatur HK12 Soll/Ist [°C]")]
        public string TempHeizelement12WertSollIst => $"{State.TempHeizelement12WertSoll}/{State.TempHeizelement12WertIst}";
        //public int TempHeizelement12WertSoll { get; set; } = default; //AK TEMP_HEIZELEMENT_12 WERTSOLL in [°C]   Feld 36
        //public int TempHeizelement12WertIst { get; set; } = default; //AK TEMP_HEIZELEMENT_12 WERTIST in [°C]   Feld 36
        #endregion


        #region N2 Durchfluss
        [Name("Durchfluss N2 1 Soll/Ist [l/min]")]
        public string TempDurchflussKreis1WertSollIst => $"{State.TempDurchflussKreis1WertSoll}/{State.TempDurchflussKreis1WertIst}";
        //public double TempDurchflussKreis1WertSoll { get; set; } = default; //AL DURCHFLUSS_KREIS_1 WERTSOLL in [1/min]   Feld 37
        //public double TempDurchflussKreis1WertIst { get; set; } = default; //AL DURCHFLUSS_KREIS_1 WERTIST in [1/min]   Feld 37

        [Name("Durchfluss N2 2 Soll/Ist [l/min]")]
        public string TempDurchflussKreis2WertSollIst => $"{State.TempDurchflussKreis2WertSoll}/{State.TempDurchflussKreis2WertIst}";
        //public double TempDurchflussKreis2WertSoll { get; set; } = default; //AM DURCHFLUSS_KREIS_2 WERTSOLL in [1/min]   Feld 38
        //public double TempDurchflussKreis2WertIst { get; set; } = default; //AM DURCHFLUSS_KREIS_2 WERTIST in [1/min]   Feld 38

        [Name("Durchfluss N2 3 Soll/Ist [l/min]")]
        public string TempDurchflussKreis3WertSollIst => $"{State.TempDurchflussKreis3WertSoll}/{State.TempDurchflussKreis3WertIst}";
        //public double TempDurchflussKreis3WertSoll { get; set; } = default; //AN DURCHFLUSS_KREIS_3 WERTSOLL in [1/min]   Feld 39
        //public double TempDurchflussKreis3WertIst { get; set; } = default; //AN DURCHFLUSS_KREIS_3 WERTIST in [1/min]   Feld 39

        [Name("Durchfluss N2 4 Soll/Ist [l/min]")]
        public string TempDurchflussKreis4WertSollIst => $"{State.TempDurchflussKreis4WertSoll}/{State.TempDurchflussKreis4WertIst}";
        //public double TempDurchflussKreis4WertSoll { get; set; } = default; //AO DURCHFLUSS_KREIS_4 WERTSOLL in [1/min]   Feld 40
        //public double TempDurchflussKreis4WertIst { get; set; } = default; //AO DURCHFLUSS_KREIS_4 WERTIST in [1/min]   Feld 40

        [Name("Durchfluss N2 5 Soll/Ist [l/min]")]
        public string TempDurchflussKreis5WertSollIst => $"{State.TempDurchflussKreis5WertSoll}/{State.TempDurchflussKreis5WertIst}";
        //public double TempDurchflussKreis5WertSoll { get; set; } = default; //AP DURCHFLUSS_KREIS_5 WERTSOLL in [1/min]   Feld 41
        //public double TempDurchflussKreis5WertIst { get; set; } = default; //AP DURCHFLUSS_KREIS_5 WERTIST in [1/min]   Feld 41

        [Name("Durchfluss N2 6 Soll/Ist [l/min]")]
        public string TempDurchflussKreis6WertSollIst => $"{State.TempDurchflussKreis6WertSoll}/{State.TempDurchflussKreis6WertIst}";
        //public double TempDurchflussKreis6WertSoll { get; set; } = default; //AQ DURCHFLUSS_KREIS_6 WERTSOLL in [1/min]   Feld 42
        //public double TempDurchflussKreis6WertIst { get; set; } = default; //AQ DURCHFLUSS_KREIS_6 WERTIST in [1/min]   Feld 42

        [Name("Durchfluss N2 7 Soll/Ist [l/min]")]
        public string TempDurchflussKreis7WertSollIst => $"{State.TempDurchflussKreis7WertSoll}/{State.TempDurchflussKreis7WertIst}";
        //public double TempDurchflussKreis7WertSoll { get; set; } = default; //AR DURCHFLUSS_KREIS_7 WERTSOLL in [1/min]   Feld 43
        //public double TempDurchflussKreis7WertIst { get; set; } = default; //AR DURCHFLUSS_KREIS_7 WERTIST in [1/min]   Feld 43

        [Name("Durchfluss N2 8 Soll/Ist [l/min]")]
        public string TempDurchflussKreis8WertSollIst => $"{State.TempDurchflussKreis8WertSoll}/{State.TempDurchflussKreis8WertIst}";
        //public double TempDurchflussKreis8WertSoll { get; set; } = default; //AS DURCHFLUSS_KREIS_8 WERTSOLL in [1/min]   Feld 44
        //public double TempDurchflussKreis8WertIst { get; set; } = default; //AS DURCHFLUSS_KREIS_8 WERTIST in [1/min]   Feld 44

        [Name("Durchfluss N2 9 Soll/Ist [l/min]")]
        public string TempDurchflussKreis9WertSollIst => $"{State.TempDurchflussKreis9WertSoll}/{State.TempDurchflussKreis9WertIst}";
        //public double TempDurchflussKreis9WertSoll { get; set; } = default; //AT DURCHFLUSS_KREIS_9 WERTSOLL in [1/min]   Feld 45
        //public double TempDurchflussKreis9WertIst { get; set; } = default; //AT DURCHFLUSS_KREIS_9 WERTIST in [1/min]   Feld 45

        [Name("Durchfluss N2 10 Soll/Ist [l/min]")]
        public string TempDurchflussKreis10WertSollIst => $"{State.TempDurchflussKreis10WertSoll}/{State.TempDurchflussKreis10WertIst}";
        //public double TempDurchflussKreis10WertSoll { get; set; } = default; //AU DURCHFLUSS_KREIS_10 WERTSOLL in [1/min]   Feld 46
        //public double TempDurchflussKreis10WertIst { get; set; } = default; //AU DURCHFLUSS_KREIS_10 WERTIST in [1/min]   Feld 46


        [Name("Durchfluss N2 11 Soll/Ist [l/min]")]
        public string TempDurchflussKreis11WertSollIst => $"{State.TempDurchflussKreis11WertSoll}/{State.TempDurchflussKreis11WertIst}";
        //public double TempDurchflussKreis11WertSoll { get; set; } = default; //AV DURCHFLUSS_KREIS_11 WERTSOLL in [1/min]   Feld 47
        //public double TempDurchflussKreis11WertIst { get; set; } = default; //AV DURCHFLUSS_KREIS_11 WERTIST in [1/min]   Feld 47

        [Name("Durchfluss N2 12 Soll/Ist [l/min]")]
        public string TempDurchflussKreis12WertSollIst => $"{State.TempDurchflussKreis12WertSoll}/{State.TempDurchflussKreis12WertIst}";
        //public double TempDurchflussKreis12WertSoll { get; set; } = default; //AW DURCHFLUSS_KREIS_12 WERTSOLL in [1/min]   Feld 48 
        //public double TempDurchflussKreis12WertIst { get; set; } = default; //AW DURCHFLUSS_KREIS_12 WERTIST in [1/min]   Feld 48

        [Name("Durchfluss N2 13 Soll/Ist [l/min]")]
        public string TempDurchflussKreis13WertSollIst => $"{State.TempDurchflussKreis13WertSoll}/{State.TempDurchflussKreis13WertIst}";
        //public double TempDurchflussKreis13WertSoll { get; set; } = default; //AX DURCHFLUSS_KREIS_13 WERTSOLL in [1/min]   Feld 49  
        //public double TempDurchflussKreis13WertIst { get; set; } = default; //AX DURCHFLUSS_KREIS_13 WERTIST in [1/min]   Feld 49

        [Name("Durchfluss N2 14 Soll/Ist [l/min]")]
        public string TempDurchflussKreis14WertSollIst => $"{State.TempDurchflussKreis14WertSoll}/{State.TempDurchflussKreis14WertIst}";
        //public double TempDurchflussKreis14WertSoll { get; set; } = default; //AY DURCHFLUSS_KREIS_14 WERTSOLL in [1/min]   Feld 50
        //public double TempDurchflussKreis14WertIst { get; set; } = default; //AY DURCHFLUSS_KREIS_14 WERTIST in [1/min]   Feld 50

        [Name("Durchfluss N2 15 Soll/Ist [l/min]")]
        public string TempDurchflussKreis15WertSollIst => $"{State.TempDurchflussKreis15WertSoll}/{State.TempDurchflussKreis15WertIst}";
        //public double TempDurchflussKreis15WertSoll { get; set; } = default; //AZ DURCHFLUSS_KREIS_15 WERTSOLL in [1/min]   Feld 51
        //public double TempDurchflussKreis15WertIst { get; set; } = default; //AZ DURCHFLUSS_KREIS_15 WERTIST in [1/min]   Feld 51

        [Name("Durchfluss N2 16 Soll/Ist [l/min]")]
        public string TempDurchflussKreis16WertSollIst => $"{State.TempDurchflussKreis16WertSoll}/{State.TempDurchflussKreis16WertIst}";
        //public double TempDurchflussKreis16WertSoll { get; set; } = default; //BA DURCHFLUSS_KREIS_16 WERTSOLL in [1/min]   Feld 52
        //public double TempDurchflussKreis16WertIst { get; set; } = default; //BA DURCHFLUSS_KREIS_16 WERTIST in [1/min]   Feld 52

        [Name("Durchfluss N2 17 Soll/Ist [l/min]")]
        public string TempDurchflussKreis17WertSollIst => $"{State.TempDurchflussKreis17WertSoll}/{State.TempDurchflussKreis17WertIst}";
        //public double TempDurchflussKreis17WertSoll { get; set; } = default; //BB DURCHFLUSS_KREIS_17 WERTSOLL in [1/min]   Feld 53
        //public double TempDurchflussKreis17WertIst { get; set; } = default; //BB DURCHFLUSS_KREIS_17 WERTIST in [1/min]   Feld 53

        [Name("Durchfluss N2 18 Soll/Ist [l/min]")]
        public string TempDurchflussKreis18WertSollIst => $"{State.TempDurchflussKreis18WertSoll}/{State.TempDurchflussKreis18WertIst}";
        //public double TempDurchflussKreis18WertSoll { get; set; } = default; //BC DURCHFLUSS_KREIS_18 WERTSOLL in [1/min]   Feld 54
        //public double TempDurchflussKreis18WertIst { get; set; } = default; //BC DURCHFLUSS_KREIS_18 WERTIST in [1/min]   Feld 54

        [Name("Durchfluss N2 19 Soll/Ist [l/min]")]
        public string TempDurchflussKreis19WertSollIst => $"{State.TempDurchflussKreis19WertSoll}/{State.TempDurchflussKreis19WertIst}";
        //public double TempDurchflussKreis19WertSoll { get; set; } = default; //BD DURCHFLUSS_KREIS_19 WERTSOLL in [1/min]   Feld 55
        //public double TempDurchflussKreis19WertIst { get; set; } = default; //BD DURCHFLUSS_KREIS_19 WERTIST in [1/min]   Feld 55

        [Name("Durchfluss N2 20 Soll/Ist [l/min]")]
        public string TempDurchflussKreis20WertSollIst => $"{State.TempDurchflussKreis20WertSoll}/{State.TempDurchflussKreis20WertIst}";
        //public double TempDurchflussKreis20WertSoll { get; set; } = default; //BE DURCHFLUSS_KREIS_20 WERTSOLL in [1/min]   Feld 56
        //public double TempDurchflussKreis20WertIst { get; set; } = default; //BE DURCHFLUSS_KREIS_20 WERTIST in [1/min]   Feld 56


        [Name("Durchfluss N2 21 Soll/Ist [l/min]")]
        public string TempDurchflussKreis21WertSollIst => $"{State.TempDurchflussKreis21WertSoll}/{State.TempDurchflussKreis21WertIst}";
        //public double TempDurchflussKreis21WertSoll { get; set; } = default; //BF DURCHFLUSS_KREIS_21 WERTSOLL in [1/min]   Feld 57
        //public double TempDurchflussKreis21WertIst { get; set; } = default; //BF DURCHFLUSS_KREIS_21 WERTIST in [1/min]   Feld 57

        [Name("Durchfluss N2 22 Soll/Ist [l/min]")]
        public string TempDurchflussKreis22WertSollIst => $"{State.TempDurchflussKreis22WertSoll}/{State.TempDurchflussKreis22WertIst}";
        //public double TempDurchflussKreis22WertSoll { get; set; } = default; //BG DURCHFLUSS_KREIS_22 WERTSOLL in [1/min]   Feld 58
        //public double TempDurchflussKreis22WertIst { get; set; } = default; //BG DURCHFLUSS_KREIS_22 WERTIST in [1/min]   Feld 58

        [Name("Durchfluss N2 23 Soll/Ist [l/min]")]
        public string TempDurchflussKreis23WertSollIst => $"{State.TempDurchflussKreis23WertSoll}/{State.TempDurchflussKreis23WertIst}";
        //public double TempDurchflussKreis23WertSoll { get; set; } = default; //BH DURCHFLUSS_KREIS_23 WERTSOLL in [1/min]   Feld 59
        //public double TempDurchflussKreis23WertIst { get; set; } = default; //BH DURCHFLUSS_KREIS_23 WERTIST in [1/min]   Feld 59

        [Name("Durchfluss N2 24 Soll/Ist [l/min]")]
        public string TempDurchflussKreis24WertSollIst => $"{State.TempDurchflussKreis24WertSoll}/{State.TempDurchflussKreis24WertIst}";
        //public double TempDurchflussKreis24WertSoll { get; set; } = default; //BI DURCHFLUSS_KREIS_24 WERTSOLL in [1/min]   Feld 60
        //public double TempDurchflussKreis24WertIst { get; set; } = default; //BI DURCHFLUSS_KREIS_24 WERTIST in [1/min]   Feld 60

        [Name("Durchfluss N2 25 Soll/Ist [l/min]")]
        public string TempDurchflussKreis25WertSollIst => $"{State.TempDurchflussKreis25WertSoll}/{State.TempDurchflussKreis25WertIst}";
        //public double TempDurchflussKreis25WertSoll { get; set; } = default; //BJ DURCHFLUSS_KREIS_25 WERTSOLL in [1/min]   Feld 61
        //public double TempDurchflussKreis25WertIst { get; set; } = default; //BJ DURCHFLUSS_KREIS_25 WERTIST in [1/min]   Feld 61

        [Name("Durchfluss N2 26 Soll/Ist [l/min]")]
        public string TempDurchflussKreis26WertSollIst => $"{State.TempDurchflussKreis26WertSoll}/{State.TempDurchflussKreis26WertIst}";
        //public double TempDurchflussKreis26WertSoll { get; set; } = default; //BK DURCHFLUSS_KREIS_26 WERTSOLL in [1/min]   Feld 62
        //public double TempDurchflussKreis26WertIst { get; set; } = default; //BK DURCHFLUSS_KREIS_26 WERTIST in [1/min]   Feld 62

        [Name("Durchfluss N2 27 Soll/Ist [l/min]")]
        public string TempDurchflussKreis27WertSollIst => $"{State.TempDurchflussKreis27WertSoll}/{State.TempDurchflussKreis27WertIst}";
        //public double TempDurchflussKreis27WertSoll { get; set; } = default; //BL DURCHFLUSS_KREIS_27 WERTSOLL in [1/min]   Feld 63
        //public double TempDurchflussKreis27WertIst { get; set; } = default; //BL DURCHFLUSS_KREIS_27 WERTIST in [1/min]   Feld 63

        [Name("Durchfluss N2 28 Soll/Ist [l/min]")]
        public string TempDurchflussKreis28WertSollIst => $"{State.TempDurchflussKreis28WertSoll}/{State.TempDurchflussKreis28WertIst}";
        //public double TempDurchflussKreis28WertSoll { get; set; } = default; //BM DURCHFLUSS_KREIS_28 WERTSOLL in [1/min]   Feld 64
        //public double TempDurchflussKreis28WertIst { get; set; } = default; //BM DURCHFLUSS_KREIS_28 WERTIST in [1/min]   Feld 64

        [Name("Durchfluss N2 29 Soll/Ist [l/min]")]
        public string TempDurchflussKreis29WertSollIst => $"{State.TempDurchflussKreis29WertSoll}/{State.TempDurchflussKreis29WertIst}";
        //public double TempDurchflussKreis29WertSoll { get; set; } = default; //BN DURCHFLUSS_KREIS_29 WERTSOLL in [1/min]   Feld 65
        //public double TempDurchflussKreis29WertIst { get; set; } = default; //BN DURCHFLUSS_KREIS_29 WERTIST in [1/min]   Feld 65

        [Name("Durchfluss N2 30 Soll/Ist [l/min]")]
        public string TempDurchflussKreis30WertSollIst => $"{State.TempDurchflussKreis30WertSoll}/{State.TempDurchflussKreis30WertIst}";
        //public double TempDurchflussKreis30WertSoll { get; set; } = default; //BO DURCHFLUSS_KREIS_30 WERTSOLL in [1/min]   Feld 66
        //public double TempDurchflussKreis30WertIst { get; set; } = default; //BO DURCHFLUSS_KREIS_30 WERTIST in [1/min]   Feld 66


        [Name("Durchfluss N2 31 Soll/Ist [l/min]")]
        public string TempDurchflussKreis31WertSollIst => $"{State.TempDurchflussKreis31WertSoll}/{State.TempDurchflussKreis31WertIst}";
        //public double TempDurchflussKreis31WertSoll { get; set; } = default; //BP DURCHFLUSS_KREIS_31 WERTSOLL in [1/min]   Feld 67
        //public double TempDurchflussKreis31WertIst { get; set; } = default; //BP DURCHFLUSS_KREIS_31 WERTIST in [1/min]   Feld 67

        [Name("Durchfluss N2 32 Soll/Ist [l/min]")]
        public string TempDurchflussKreis32WertSollIst => $"{State.TempDurchflussKreis32WertSoll}/{State.TempDurchflussKreis32WertIst}";
        //public double TempDurchflussKreis32WertSoll { get; set; } = default; //BQ DURCHFLUSS_KREIS_32 WERTSOLL in [1/min]   Feld 68
        //public double TempDurchflussKreis32WertIst { get; set; } = default; //BQ DURCHFLUSS_KREIS_32 WERTIST in [1/min]   Feld 68

        [Name("Durchfluss N2 33 Soll/Ist [l/min]")]
        public string TempDurchflussKreis33WertSollIst => $"{State.TempDurchflussKreis33WertSoll}/{State.TempDurchflussKreis33WertIst}";
        //public double TempDurchflussKreis33WertSoll { get; set; } = default; //BR DURCHFLUSS_KREIS_33 WERTSOLL in [1/min]   Feld 69
        //public double TempDurchflussKreis33WertIst { get; set; } = default; //BR DURCHFLUSS_KREIS_33 WERTIST in [1/min]   Feld 69

        [Name("Durchfluss N2 34 Soll/Ist [l/min]")]
        public string TempDurchflussKreis34WertSollIst => $"{State.TempDurchflussKreis34WertSoll}/{State.TempDurchflussKreis34WertIst}";
        //public double TempDurchflussKreis34WertSoll { get; set; } = default; //BS DURCHFLUSS_KREIS_34 WERTSOLL in [1/min]   Feld 70
        //public double TempDurchflussKreis34WertIst { get; set; } = default; //BS DURCHFLUSS_KREIS_34 WERTIST in [1/min]   Feld 70

        [Name("Durchfluss N2 35 Soll/Ist [l/min]")]
        public string TempDurchflussKreis35WertSollIst => $"{State.TempDurchflussKreis35WertSoll}/{State.TempDurchflussKreis35WertIst}";
        //public double TempDurchflussKreis35WertSoll { get; set; } = default; //BT DURCHFLUSS_KREIS_35 WERTSOLL in [1/min]   Feld 71
        //public double TempDurchflussKreis35WertIst { get; set; } = default; //BT DURCHFLUSS_KREIS_35 WERTIST in [1/min]   Feld 71

        [Name("Durchfluss N2 36 Soll/Ist [l/min]")]
        public string TempDurchflussKreis36WertSollIst => $"{State.TempDurchflussKreis36WertSoll}/{State.TempDurchflussKreis36WertIst}";
        //public double TempDurchflussKreis36WertSoll { get; set; } = default; //BU DURCHFLUSS_KREIS_36 WERTSOLL in [1/min]   Feld 72
        //public double TempDurchflussKreis36WertIst { get; set; } = default; //BU DURCHFLUSS_KREIS_36 WERTIST in [1/min]   Feld 72

        [Name("Durchfluss N2 37 Soll/Ist [l/min]")]
        public string TempDurchflussKreis37WertSollIst => $"{State.TempDurchflussKreis37WertSoll}/{State.TempDurchflussKreis37WertIst}";
        //public double TempDurchflussKreis37WertSoll { get; set; } = default; //BV DURCHFLUSS_KREIS_37 WERTSOLL in [1/min]   Feld 73
        //public double TempDurchflussKreis37WertIst { get; set; } = default; //BV DURCHFLUSS_KREIS_37 WERTIST in [1/min]   Feld 73

        [Name("Durchfluss N2 38 Soll/Ist [l/min]")]
        public string TempDurchflussKreis38WertSollIst => $"{State.TempDurchflussKreis38WertSoll}/{State.TempDurchflussKreis38WertIst}";
        //public double TempDurchflussKreis38WertSoll { get; set; } = default; //BW DURCHFLUSS_KREIS_38 WERTSOLL in [1/min]   Feld 74
        //public double TempDurchflussKreis38WertIst { get; set; } = default; //BW DURCHFLUSS_KREIS_38 WERTIST in [1/min]   Feld 74

        [Name("Durchfluss N2 39 Soll/Ist [l/min]")]
        public string TempDurchflussKreis39WertSollIst => $"{State.TempDurchflussKreis39WertSoll}/{State.TempDurchflussKreis39WertIst}";
        //public double TempDurchflussKreis39WertSoll { get; set; } = default; //BX DURCHFLUSS_KREIS_39 WERTSOLL in [1/min]   Feld 75
        //public double TempDurchflussKreis39WertIst { get; set; } = default; //BX DURCHFLUSS_KREIS_39 WERTIST in [1/min]   Feld 75

        [Name("Durchfluss N2 40 Soll/Ist [l/min]")]
        public string TempDurchflussKreis40WertSollIst => $"{State.TempDurchflussKreis40WertSoll}/{State.TempDurchflussKreis40WertIst}";
        //public double TempDurchflussKreis40WertSoll { get; set; } = default; //BY DURCHFLUSS_KREIS_40 WERTSOLL in [1/min]   Feld 76
        //public double TempDurchflussKreis40WertIst { get; set; } = default; //BY DURCHFLUSS_KREIS_40 WERTIST in [1/min]   Feld 76
        #endregion           
            

        [Name("Burster 1. Kraft(left) [N]")]
        public double Kraft1Wert => State.Kraft1Wert; //BZ Kraft1Wert in [N]  Feld 77 

        [Name("Burster 1. Weg (left) [mm]")]
        public double Weg1Wert => State.Weg1Wert; //CA Weg1Wert in [mm] Feld 78

        [Name("Burster 1. Ergebnis (left)")]
        public int Kraft1Result => State.Kraft1Result; //CB Feld 79 // public int Weg1Result => State.; // Feld 79 ??????????????????????????

        [Name("Burster 2. Kraft (right)[N]")]
        public double Kraft2Wert => State.Kraft2Wert; //CC Kraft2Wert in [N]  Feld 80

        [Name("Burster 2. Weg (right) [mm]")]
        public double Weg2Wert => State.Weg2Wert; //CD Weg2Wert in [mm] Feld 81

        [Name("Burster 2. Ergebnis (right)")]
        public int Kraft2Result => State.Kraft2Result; //CE Feld 82  //public int Weg2Result { get; set; } = default; // Feld 82 ????????????????????????????


        [Name("MES aktiv")]
        public bool MesAktiv => State.MesAktiv; //CF MES aktiv Feld 83


        [Name("Ausgleichshub 1 WERTSOLL")]
        public double Ausgleichhub1WertSoll => State.Ausgleichhub1WertSoll; //CG Ausgleichshub 1 WERTSOLL in [bar]   Feld 84
        [Name("Ausgleichshub 1 WERTIST")]
        public double Ausgleichhub1WertIst => State.Ausgleichhub1WertIst; //CH Ausgleichshub 1 WERTIST in [bar]   Feld 85
        [Name("Ausgleichshub 2 WERTSOLL")]
        public double Ausgleichhub2WertSoll => State.Ausgleichhub2WertSoll; //CI Ausgleichshub 2 WERTSOLL in [bar]   Feld 86
        [Name("Ausgleichshub 2 WERTIST")]
        public double Ausgleichhub2WertIst => State.Ausgleichhub2WertIst; //CJ Ausgleichshub 2 WERTIST in [bar]   Feld 87


        #region N2 Einschaltverzögerung
        [Name("Einschaltverz DURCHFLUSS_KREIS_1")]
        public double EinschaltverzDurchflussKreis1 => State.EinschaltverzDurchflussKreis1; // Einschaltverz DURCHFLUSS_KREIS_1 in [ms]   Feld 88

        [Name("Einschaltverz DURCHFLUSS_KREIS_2")]
        public double EinschaltverzDurchflussKreis2 => State.EinschaltverzDurchflussKreis2; // Einschaltverz DURCHFLUSS_KREIS_2 in [ms]   Feld 89

        [Name("Einschaltverz DURCHFLUSS_KREIS_3")]
        public double EinschaltverzDurchflussKreis3 => State.EinschaltverzDurchflussKreis3; // Einschaltverz DURCHFLUSS_KREIS_3 in [ms]   Feld 90

        [Name("Einschaltverz DURCHFLUSS_KREIS_4")]
        public double EinschaltverzDurchflussKreis4 => State.EinschaltverzDurchflussKreis4; // Einschaltverz DURCHFLUSS_KREIS_4 in [ms]   Feld 91

        [Name("Einschaltverz DURCHFLUSS_KREIS_5")]
        public double EinschaltverzDurchflussKreis5 => State.EinschaltverzDurchflussKreis5; // Einschaltverz DURCHFLUSS_KREIS_5 in [ms]   Feld 92

        [Name("Einschaltverz DURCHFLUSS_KREIS_6")]
        public double EinschaltverzDurchflussKreis6 => State.EinschaltverzDurchflussKreis6; // Einschaltverz DURCHFLUSS_KREIS_6 in [ms]   Feld 93

        [Name("Einschaltverz DURCHFLUSS_KREIS_7")]
        public double EinschaltverzDurchflussKreis7 => State.EinschaltverzDurchflussKreis7; // Einschaltverz DURCHFLUSS_KREIS_7 in [ms]   Feld 94

        [Name("Einschaltverz DURCHFLUSS_KREIS_8")]
        public double EinschaltverzDurchflussKreis8 => State.EinschaltverzDurchflussKreis8; // Einschaltverz DURCHFLUSS_KREIS_8 in [ms]   Feld 95

        [Name("Einschaltverz DURCHFLUSS_KREIS_9")]
        public double EinschaltverzDurchflussKreis9 => State.EinschaltverzDurchflussKreis9; // Einschaltverz DURCHFLUSS_KREIS_9 in [ms]   Feld 96

        [Name("Einschaltverz DURCHFLUSS_KREIS_10")]
        public double EinschaltverzDurchflussKreis10 => State.EinschaltverzDurchflussKreis10; // Einschaltverz DURCHFLUSS_KREIS_10 in [ms]   Feld 97

        [Name("Einschaltverz DURCHFLUSS_KREIS_11")]

        public double EinschaltverzDurchflussKreis11 => State.EinschaltverzDurchflussKreis11; // Einschaltverz DURCHFLUSS_KREIS_11 in [ms]   Feld 98

        [Name("Einschaltverz DURCHFLUSS_KREIS_12")]
        public double EinschaltverzDurchflussKreis12 => State.EinschaltverzDurchflussKreis12; // Einschaltverz DURCHFLUSS_KREIS_12 in [ms]   Feld 99

        [Name("Einschaltverz DURCHFLUSS_KREIS_13")]
        public double EinschaltverzDurchflussKreis13 => State.EinschaltverzDurchflussKreis13; // Einschaltverz DURCHFLUSS_KREIS_13 in [ms]   Feld 100

        [Name("Einschaltverz DURCHFLUSS_KREIS_14")]
        public double EinschaltverzDurchflussKreis14 => State.EinschaltverzDurchflussKreis14; // Einschaltverz DURCHFLUSS_KREIS_14 in [ms]   Feld 101

        [Name("Einschaltverz DURCHFLUSS_KREIS_15")]
        public double EinschaltverzDurchflussKreis15 => State.EinschaltverzDurchflussKreis15; // Einschaltverz DURCHFLUSS_KREIS_15 in [ms]   Feld 102

        [Name("Einschaltverz DURCHFLUSS_KREIS_16")]
        public double EinschaltverzDurchflussKreis16 => State.EinschaltverzDurchflussKreis16; // Einschaltverz DURCHFLUSS_KREIS_16 in [ms]   Feld 103

        [Name("Einschaltverz DURCHFLUSS_KREIS_17")]
        public double EinschaltverzDurchflussKreis17 => State.EinschaltverzDurchflussKreis17; // Einschaltverz DURCHFLUSS_KREIS_17 in [ms]   Feld 104

        [Name("Einschaltverz DURCHFLUSS_KREIS_18")]
        public double EinschaltverzDurchflussKreis18 => State.EinschaltverzDurchflussKreis18; // Einschaltverz DURCHFLUSS_KREIS_18 in [ms]   Feld 105

        [Name("Einschaltverz DURCHFLUSS_KREIS_19")]
        public double EinschaltverzDurchflussKreis19 => State.EinschaltverzDurchflussKreis19; // Einschaltverz DURCHFLUSS_KREIS_19 in [ms]   Feld 106

        [Name("Einschaltverz DURCHFLUSS_KREIS_20")]
        public double EinschaltverzDurchflussKreis20 => State.EinschaltverzDurchflussKreis20; // Einschaltverz DURCHFLUSS_KREIS_20 in [ms]   Feld 107


        [Name("Einschaltverz DURCHFLUSS_KREIS_21")]
        public double EinschaltverzDurchflussKreis21 => State.EinschaltverzDurchflussKreis21; // Einschaltverz DURCHFLUSS_KREIS_21 in [ms]   Feld 108

        [Name("Einschaltverz DURCHFLUSS_KREIS_22")]
        public double EinschaltverzDurchflussKreis22 => State.EinschaltverzDurchflussKreis22; // Einschaltverz DURCHFLUSS_KREIS_22 in [ms]   Feld 109

        [Name("Einschaltverz DURCHFLUSS_KREIS_23")]
        public double EinschaltverzDurchflussKreis23 => State.EinschaltverzDurchflussKreis23; // Einschaltverz DURCHFLUSS_KREIS_23 in [ms]   Feld 110

        [Name("Einschaltverz DURCHFLUSS_KREIS_24")]
        public double EinschaltverzDurchflussKreis24 => State.EinschaltverzDurchflussKreis24; // Einschaltverz DURCHFLUSS_KREIS_24 in [ms]   Feld 111

        [Name("Einschaltverz DURCHFLUSS_KREIS_25")]
        public double EinschaltverzDurchflussKreis25 => State.EinschaltverzDurchflussKreis25; // Einschaltverz DURCHFLUSS_KREIS_25 in [ms]   Feld 112

        [Name("Einschaltverz DURCHFLUSS_KREIS_26")]
        public double EinschaltverzDurchflussKreis26 => State.EinschaltverzDurchflussKreis26; // Einschaltverz DURCHFLUSS_KREIS_26 in [ms]   Feld 113

        [Name("Einschaltverz DURCHFLUSS_KREIS_27")]
        public double EinschaltverzDurchflussKreis27 => State.EinschaltverzDurchflussKreis27; // Einschaltverz DURCHFLUSS_KREIS_27 in [ms]   Feld 114

        [Name("Einschaltverz DURCHFLUSS_KREIS_28")]
        public double EinschaltverzDurchflussKreis28 => State.EinschaltverzDurchflussKreis28; // Einschaltverz DURCHFLUSS_KREIS_28 in [ms]   Feld 115

        [Name("Einschaltverz DURCHFLUSS_KREIS_29")]
        public double EinschaltverzDurchflussKreis29 => State.EinschaltverzDurchflussKreis29; // Einschaltverz DURCHFLUSS_KREIS_29 in [ms]   Feld 116

        [Name("Einschaltverz DURCHFLUSS_KREIS_30")]
        public double EinschaltverzDurchflussKreis30 => State.EinschaltverzDurchflussKreis30; // Einschaltverz DURCHFLUSS_KREIS_30 in [ms]   Feld 117

        [Name("Einschaltverz DURCHFLUSS_KREIS_31")]

        public double EinschaltverzDurchflussKreis31 => State.EinschaltverzDurchflussKreis31; // Einschaltverz DURCHFLUSS_KREIS_31 in [ms]   Feld 118

        [Name("Einschaltverz DURCHFLUSS_KREIS_32")]
        public double EinschaltverzDurchflussKreis32 => State.EinschaltverzDurchflussKreis32; // Einschaltverz DURCHFLUSS_KREIS_32 in [ms]   Feld 119

        [Name("Einschaltverz DURCHFLUSS_KREIS_33")]
        public double EinschaltverzDurchflussKreis33 => State.EinschaltverzDurchflussKreis33; // Einschaltverz DURCHFLUSS_KREIS_33 in [ms]   Feld 120

        [Name("Einschaltverz DURCHFLUSS_KREIS_34")]
        public double EinschaltverzDurchflussKreis34 => State.EinschaltverzDurchflussKreis34; // Einschaltverz DURCHFLUSS_KREIS_34 in [ms]   Feld 121

        [Name("Einschaltverz DURCHFLUSS_KREIS_35")]
        public double EinschaltverzDurchflussKreis35 => State.EinschaltverzDurchflussKreis35; // Einschaltverz DURCHFLUSS_KREIS_35 in [ms]   Feld 122

        [Name("Einschaltverz DURCHFLUSS_KREIS_36")]
        public double EinschaltverzDurchflussKreis36 => State.EinschaltverzDurchflussKreis36; // Einschaltverz DURCHFLUSS_KREIS_36 in [ms]   Feld 123

        [Name("Einschaltverz DURCHFLUSS_KREIS_37")]
        public double EinschaltverzDurchflussKreis37 => State.EinschaltverzDurchflussKreis37; // Einschaltverz DURCHFLUSS_KREIS_37 in [ms]   Feld 124

        [Name("Einschaltverz DURCHFLUSS_KREIS_38")]
        public double EinschaltverzDurchflussKreis38 => State.EinschaltverzDurchflussKreis38; // Einschaltverz DURCHFLUSS_KREIS_38 in [ms]   Feld 125

        [Name("Einschaltverz DURCHFLUSS_KREIS_39")]
        public double EinschaltverzDurchflussKreis39 => State.EinschaltverzDurchflussKreis39; // Einschaltverz DURCHFLUSS_KREIS_39 in [ms]   Feld 126

        [Name("Einschaltverz DURCHFLUSS_KREIS_40")]
        public double EinschaltverzDurchflussKreis40 => State.EinschaltverzDurchflussKreis40; //DX Einschaltverz DURCHFLUSS_KREIS_40 in [ms]   Feld 127
        #endregion

        public static ProcessDataPc CreateFromState(ProcessData state)
        {
            return new ProcessDataPc(state);
        }  
    }
}
