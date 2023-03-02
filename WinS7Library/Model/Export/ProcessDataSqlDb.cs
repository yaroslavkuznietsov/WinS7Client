using CsvHelper.Configuration.Attributes;
using System;

namespace WinS7Library.Model.Export
{
    /// <summary>
    /// Attributes based on CsvHelper NuGet Package
    /// https://joshclose.github.io/CsvHelper/examples/configuration/attributes/
    /// </summary>
    public class ProcessDataSqlDb     // Datenstrucktur für AT  
    {
        protected ProcessDataSqlDb(ProcessData state)
        {
            State = state;
        }

        [Ignore]
        public ProcessData State { get; protected set; }


        [Name("DATUM/UHRZEIT")]
        public string DatumUhrzeit { get; set; } = $"{DateTime.Now:yyyy-MM-dd+HH:mm:ss}";  // Feld 0

        [Name("PRODUKTNAME")]
        public string Produktname => State.Produktname; // Feld 1

        [Name("SCHWEISSUNGSERGEBNIS")]
        public int Schweissungsergebnis => State.Schweissungsergebnis; // Feld 2

        [Name("KRAFT1 WERT")]
        public double Kraft1Wert => State.Kraft1Wert; // Kraft1Wert in [N]  Feld 3  

        [Name("KRAFT1 RESULT")]
        public int Kraft1Result => State.Kraft1Result ; // Feld 4

        [Name("WEG1 WERT")]
        public double Weg1Wert => State.Weg1Wert; // Weg1Wert in [mm] Feld 5

        [Name("WEG1 RESULT")]
        public int Weg1Result => State.Weg1Result;  // Feld 6

        [Name("KRAFT2 WERT")]
        public double Kraft2Wert => State.Kraft2Wert; // Kraft2Wert in [N]  Feld 7

        [Name("KRAFT2 RESULT")]
        public int Kraft2Result => State.Kraft2Result; // Feld 8

        [Name("WEG2 WERT")]
        public double Weg2Wert => State.Weg2Wert; // Weg2Wert in [mm] Feld 9

        [Name("WEG2 RESULT")]
        public int Weg2Result => State.Weg2Result; // Feld 10
                                                       // 
        [Name("WARMZEIT_1 WERT")]
        public int WarmZeit1Wert => State.WarmZeit1Wert; // WARMZEIT_1 WERT in [s] Feld 11

        [Name("WARMPOSITION_1 OBEN WERT")]
        public int WarmPosition1ObenWert => State.WarmPosition1ObenWert; // WARMPOSITION_1 OBEN WERT in [mm]   Feld 12

        [Name("WARMPOSITION_1 UNTEN WERT")]
        public int WarmPosition1UntenWert => State.WarmPosition1UntenWert; // WARMPOSITION_1 UNTEN WERT in [mm]   Feld 13

        [Name("WARMZEIT_2 WERT")]
        public int WarmZei2Wert => State.WarmZei2Wert; // WARMZEIT_2 WERT [s]   Feld 14

        [Name("WARMPOSITION_2 OBEN WERT")]
        public int WarmPosition2ObenWert => State.WarmPosition2ObenWert; // WARMPOSITION_2 OBEN WERT in [mm]   Feld 15

        [Name("WARMPOSITION_2 UNTEN WERT")]
        public int WarmPosition2UntenWert => State.WarmPosition2UntenWert; // WARMPOSITION_2 UNTEN WERT in [mm]   Feld 16

        [Name("FUEGE_V OBEN WERT")]
        public int FuegeVObenWert => State.FuegeVObenWert; // FUEGE_V OBEN WERT in [mm/s]   Feld 17

        [Name("FUEGE_V UNTEN WERT")]
        public int FuegeVUntenWert => State.FuegeVUntenWert; // FUEGE_V OBEN WERT in [mm/s]   Feld 18

        [Name("FUEGEPOSITION OBEN WERT")]
        public int FuegePositionObenWert => State.FuegePositionObenWert; // FUEGEPOSITION OBEN WERT [mm]   Feld 19

        [Name("FUEGEPOSITION UNTEN WERT")]
        public int FuegePositionUntenWert => State.FuegePositionUntenWert; // FUEGEPOSITION UNTEN WERT [mm]   Feld 20

        [Name("KUEHLZEIT WERT")]
        public int KuehlZeitWert => State.KuehlZeitWert; // KUEHLZEIT WERT in [s] Feld 21

        [Name("UMSTELLZEIT WERT")]
        public int UmstellZeitWert => State.UmstellZeitWert; // UMSTELLZEIT WERT in [s] Feld 22

        [Name("ZYKLUSZEIT WERT")]
        public int ZyklusZeitWert => State.ZyklusZeitWert; // ZYKLUSZEIT WERT in [s] Feld 23


        #region Temperaturen Heizelement
        [Name("TEMP_HEIZELEMENT_1 WERTSOLL")]
        public int TempHeizelement1WertSoll => State.TempHeizelement1WertSoll; // TEMP_HEIZELEMENT_1 WERTSOLL in [°C]   Feld 24

        [Name("TEMP_HEIZELEMENT_1 WERTIST")]
        public int TempHeizelement1WertIst => State.TempHeizelement1WertIst; // TEMP_HEIZELEMENT_1 WERTIST in [°C]   Feld 25

        [Name("TEMP_HEIZELEMENT_2 WERTSOLL")]
        public int TempHeizelement2WertSoll => State.TempHeizelement2WertSoll; // TEMP_HEIZELEMENT_2 WERTSOLL in [°C]   Feld 26

        [Name("TEMP_HEIZELEMENT_2 WERTIST")]
        public int TempHeizelement2WertIst => State.TempHeizelement2WertIst; // TEMP_HEIZELEMENT_2 WERTIST in [°C]   Feld 27

        [Name("TEMP_HEIZELEMENT_3 WERTSOLL")]
        public int TempHeizelement3WertSoll => State.TempHeizelement3WertSoll; // TEMP_HEIZELEMENT_3 WERTSOLL in [°C]   Feld 28

        [Name("TEMP_HEIZELEMENT_3 WERTIST")]
        public int TempHeizelement3WertIst => State.TempHeizelement3WertIst; // TEMP_HEIZELEMENT_3 WERTIST in [°C]   Feld 29

        [Name("TEMP_HEIZELEMENT_4 WERTSOLL")]
        public int TempHeizelement4WertSoll => State.TempHeizelement4WertSoll; // TEMP_HEIZELEMENT_4 WERTSOLL in [°C]   Feld 30

        [Name("TEMP_HEIZELEMENT_4 WERTIST")]
        public int TempHeizelement4WertIst => State.TempHeizelement4WertIst; // TEMP_HEIZELEMENT_4 WERTIST in [°C]   Feld 31

        [Name("TEMP_HEIZELEMENT_5 WERTSOLL")]
        public int TempHeizelement5WertSoll => State.TempHeizelement5WertSoll; // TEMP_HEIZELEMENT_5 WERTSOLL in [°C]   Feld 32

        [Name("TEMP_HEIZELEMENT_5 WERTIST")]
        public int TempHeizelement5WertIst => State.TempHeizelement5WertIst; // TEMP_HEIZELEMENT_5 WERTIST in [°C]   Feld 33

        [Name("TEMP_HEIZELEMENT_6 WERTSOLL")]
        public int TempHeizelement6WertSoll => State.TempHeizelement6WertSoll; // TEMP_HEIZELEMENT_6 WERTSOLL in [°C]   Feld 34

        [Name("TEMP_HEIZELEMENT_6 WERTIST")]
        public int TempHeizelement6WertIst => State.TempHeizelement6WertIst; // TEMP_HEIZELEMENT_6 WERTIST in [°C]   Feld 35

        [Name("TEMP_HEIZELEMENT_7 WERTSOLL")]
        public int TempHeizelement7WertSoll => State.TempHeizelement7WertSoll; // TEMP_HEIZELEMENT_7 WERTSOLL in [°C]   Feld 36

        [Name("TEMP_HEIZELEMENT_7 WERTIST")]
        public int TempHeizelement7WertIst => State.TempHeizelement7WertIst; // TEMP_HEIZELEMENT_7 WERTIST in [°C]   Feld 37

        [Name("TEMP_HEIZELEMENT_8 WERTSOLL")]
        public int TempHeizelement8WertSoll => State.TempHeizelement8WertSoll; // TEMP_HEIZELEMENT_8 WERTSOLL in [°C]   Feld 38

        [Name("TEMP_HEIZELEMENT_8 WERTIST")]
        public int TempHeizelement8WertIst => State.TempHeizelement8WertIst; // TEMP_HEIZELEMENT_8 WERTIST in [°C]   Feld 39

        [Name("TEMP_HEIZELEMENT_9 WERTSOLL")]
        public int TempHeizelement9WertSoll => State.TempHeizelement9WertSoll; // TEMP_HEIZELEMENT_9 WERTSOLL in [°C]   Feld 40

        [Name("TEMP_HEIZELEMENT_9 WERTIST")]
        public int TempHeizelement9WertIst => State.TempHeizelement9WertIst; // TEMP_HEIZELEMENT_9 WERTIST in [°C]   Feld 41

        [Name("TEMP_HEIZELEMENT_10 WERTSOLL")]
        public int TempHeizelement10WertSoll => State.TempHeizelement10WertSoll; // TEMP_HEIZELEMENT_10 WERTSOLL in [°C]   Feld 42

        [Name("TEMP_HEIZELEMENT_10 WERTIST")]
        public int TempHeizelement10WertIst => State.TempHeizelement10WertIst; // TEMP_HEIZELEMENT_10 WERTIST in [°C]   Feld 43

        [Name("TEMP_HEIZELEMENT_11 WERTSOLL")]
        public int TempHeizelement11WertSoll => State.TempHeizelement11WertSoll; // TEMP_HEIZELEMENT_11 WERTSOLL in [°C]   Feld 44

        [Name("TEMP_HEIZELEMENT_11 WERTIST")]
        public int TempHeizelement11WertIst => State.TempHeizelement11WertIst; // TEMP_HEIZELEMENT_11 WERTIST in [°C]   Feld 45

        [Name("TEMP_HEIZELEMENT_12 WERTSOLL")]
        public int TempHeizelement12WertSoll => State.TempHeizelement12WertSoll; // TEMP_HEIZELEMENT_12 WERTSOLL in [°C]   Feld 46

        [Name("TEMP_HEIZELEMENT_12 WERTIST")]
        public int TempHeizelement12WertIst => State.TempHeizelement12WertIst; // TEMP_HEIZELEMENT_12 WERTIST in [°C]   Feld 47
        #endregion

        #region N2 Durchfluss
        [Name("DURCHFLUSS_KREIS_1 WERTSOLL")]
        public double TempDurchflussKreis1WertSoll => State.TempDurchflussKreis1WertSoll; // DURCHFLUSS_KREIS_1 WERTSOLL in [1/min]   Feld 48

        [Name("DURCHFLUSS_KREIS_1 WERTIST")]
        public double TempDurchflussKreis1WertIst => State.TempDurchflussKreis1WertIst; // DURCHFLUSS_KREIS_1 WERTIST in [1/min]   Feld 49

        [Name("DURCHFLUSS_KREIS_2 WERTSOLL")]
        public double TempDurchflussKreis2WertSoll => State.TempDurchflussKreis2WertSoll; // DURCHFLUSS_KREIS_2 WERTSOLL in [1/min]   Feld 50

        [Name("DURCHFLUSS_KREIS_2 WERTIST")]
        public double TempDurchflussKreis2WertIst => State.TempDurchflussKreis2WertIst; // DURCHFLUSS_KREIS_2 WERTIST in [1/min]   Feld 51

        [Name("DURCHFLUSS_KREIS_3 WERTSOLL")]
        public double TempDurchflussKreis3WertSoll => State.TempDurchflussKreis3WertSoll; // DURCHFLUSS_KREIS_3 WERTSOLL in [1/min]   Feld 52

        [Name("DURCHFLUSS_KREIS_3 WERTIST")]
        public double TempDurchflussKreis3WertIst => State.TempDurchflussKreis3WertIst; // DURCHFLUSS_KREIS_3 WERTIST in [1/min]   Feld 53

        [Name("DURCHFLUSS_KREIS_4 WERTSOLL")]
        public double TempDurchflussKreis4WertSoll => State.TempDurchflussKreis4WertSoll; // DURCHFLUSS_KREIS_4 WERTSOLL in [1/min]   Feld 54

        [Name("DURCHFLUSS_KREIS_4 WERTIST")]
        public double TempDurchflussKreis4WertIst => State.TempDurchflussKreis4WertIst; // DURCHFLUSS_KREIS_4 WERTIST in [1/min]   Feld 55

        [Name("DURCHFLUSS_KREIS_5 WERTSOLL")]
        public double TempDurchflussKreis5WertSoll => State.TempDurchflussKreis5WertSoll; // DURCHFLUSS_KREIS_5 WERTSOLL in [1/min]   Feld 56

        [Name("DURCHFLUSS_KREIS_5 WERTIST")]
        public double TempDurchflussKreis5WertIst => State.TempDurchflussKreis5WertIst; // DURCHFLUSS_KREIS_5 WERTIST in [1/min]   Feld 57

        [Name("DURCHFLUSS_KREIS_6 WERTSOLL")]
        public double TempDurchflussKreis6WertSoll => State.TempDurchflussKreis6WertSoll; // DURCHFLUSS_KREIS_6 WERTSOLL in [1/min]   Feld 58

        [Name("DURCHFLUSS_KREIS_6 WERTIST")]
        public double TempDurchflussKreis6WertIst => State.TempDurchflussKreis6WertIst; // DURCHFLUSS_KREIS_6 WERTIST in [1/min]   Feld 59

        [Name("DURCHFLUSS_KREIS_7 WERTSOLL")]
        public double TempDurchflussKreis7WertSoll => State.TempDurchflussKreis7WertSoll; // DURCHFLUSS_KREIS_7 WERTSOLL in [1/min]   Feld 60

        [Name("DURCHFLUSS_KREIS_7 WERTIST")]
        public double TempDurchflussKreis7WertIst => State.TempDurchflussKreis7WertIst; // DURCHFLUSS_KREIS_7 WERTIST in [1/min]   Feld 61

        [Name("DURCHFLUSS_KREIS_8 WERTSOLL")]
        public double TempDurchflussKreis8WertSoll => State.TempDurchflussKreis8WertSoll; // DURCHFLUSS_KREIS_8 WERTSOLL in [1/min]   Feld 62

        [Name("DURCHFLUSS_KREIS_8 WERTIST")]
        public double TempDurchflussKreis8WertIst => State.TempDurchflussKreis8WertIst; // DURCHFLUSS_KREIS_8 WERTIST in [1/min]   Feld 63

        [Name("DURCHFLUSS_KREIS_9 WERTSOLL")]
        public double TempDurchflussKreis9WertSoll => State.TempDurchflussKreis9WertSoll; // DURCHFLUSS_KREIS_9 WERTSOLL in [1/min]   Feld 64

        [Name("DURCHFLUSS_KREIS_9 WERTIST")]
        public double TempDurchflussKreis9WertIst => State.TempDurchflussKreis9WertIst; // DURCHFLUSS_KREIS_9 WERTIST in [1/min]   Feld 65

        [Name("DURCHFLUSS_KREIS_10 WERTSOLL")]
        public double TempDurchflussKreis10WertSoll => State.TempDurchflussKreis10WertSoll; // DURCHFLUSS_KREIS_10 WERTSOLL in [1/min]   Feld 66

        [Name("DURCHFLUSS_KREIS_10 WERTIST")]
        public double TempDurchflussKreis10WertIst => State.TempDurchflussKreis10WertIst; // DURCHFLUSS_KREIS_10 WERTIST in [1/min]   Feld 67


        [Name("DURCHFLUSS_KREIS_11 WERTSOLL")]
        public double TempDurchflussKreis11WertSoll => State.TempDurchflussKreis11WertSoll; // DURCHFLUSS_KREIS_11 WERTSOLL in [1/min]   Feld 68

        [Name("DURCHFLUSS_KREIS_11 WERTIST")]
        public double TempDurchflussKreis11WertIst => State.TempDurchflussKreis11WertIst; // DURCHFLUSS_KREIS_11 WERTIST in [1/min]   Feld 69

        [Name("DURCHFLUSS_KREIS_12 WERTSOLL")]
        public double TempDurchflussKreis12WertSoll => State.TempDurchflussKreis12WertSoll; // DURCHFLUSS_KREIS_12 WERTSOLL in [1/min]   Feld 70

        [Name("DURCHFLUSS_KREIS_12 WERTIST")]
        public double TempDurchflussKreis12WertIst => State.TempDurchflussKreis12WertIst; // DURCHFLUSS_KREIS_12 WERTIST in [1/min]   Feld 71

        [Name("DURCHFLUSS_KREIS_13 WERTSOLL")]
        public double TempDurchflussKreis13WertSoll => State.TempDurchflussKreis13WertSoll; // DURCHFLUSS_KREIS_13 WERTSOLL in [1/min]   Feld 72

        [Name("DURCHFLUSS_KREIS_13 WERTIST")]
        public double TempDurchflussKreis13WertIst => State.TempDurchflussKreis13WertIst; // DURCHFLUSS_KREIS_13 WERTIST in [1/min]   Feld 73

        [Name("DURCHFLUSS_KREIS_14 WERTSOLL")]
        public double TempDurchflussKreis14WertSoll => State.TempDurchflussKreis14WertSoll; // DURCHFLUSS_KREIS_14 WERTSOLL in [1/min]   Feld 74

        [Name("DURCHFLUSS_KREIS_14 WERTIST")]
        public double TempDurchflussKreis14WertIst => State.TempDurchflussKreis14WertIst; // DURCHFLUSS_KREIS_14 WERTIST in [1/min]   Feld 75

        [Name("DURCHFLUSS_KREIS_15 WERTSOLL")]
        public double TempDurchflussKreis15WertSoll => State.TempDurchflussKreis15WertSoll; // DURCHFLUSS_KREIS_15 WERTSOLL in [1/min]   Feld 76

        [Name("DURCHFLUSS_KREIS_15 WERTIST")]
        public double TempDurchflussKreis15WertIst => State.TempDurchflussKreis15WertIst; // DURCHFLUSS_KREIS_15 WERTIST in [1/min]   Feld 77

        [Name("DURCHFLUSS_KREIS_16 WERTSOLL")]
        public double TempDurchflussKreis16WertSoll => State.TempDurchflussKreis16WertSoll; // DURCHFLUSS_KREIS_16 WERTSOLL in [1/min]   Feld 78

        [Name("DURCHFLUSS_KREIS_16 WERTIST")]
        public double TempDurchflussKreis16WertIst => State.TempDurchflussKreis16WertIst; // DURCHFLUSS_KREIS_16 WERTIST in [1/min]   Feld 79

        [Name("DURCHFLUSS_KREIS_17 WERTSOLL")]
        public double TempDurchflussKreis17WertSoll => State.TempDurchflussKreis17WertSoll; // DURCHFLUSS_KREIS_17 WERTSOLL in [1/min]   Feld 80

        [Name("DURCHFLUSS_KREIS_17 WERTIST")]
        public double TempDurchflussKreis17WertIst => State.TempDurchflussKreis17WertIst; // DURCHFLUSS_KREIS_17 WERTIST in [1/min]   Feld 81

        [Name("DURCHFLUSS_KREIS_18 WERTSOLL")]
        public double TempDurchflussKreis18WertSoll => State.TempDurchflussKreis18WertSoll; // DURCHFLUSS_KREIS_18 WERTSOLL in [1/min]   Feld 82

        [Name("DURCHFLUSS_KREIS_18 WERTIST")]
        public double TempDurchflussKreis18WertIst => State.TempDurchflussKreis18WertIst; // DURCHFLUSS_KREIS_18 WERTIST in [1/min]   Feld 83

        [Name("DURCHFLUSS_KREIS_19 WERTSOLL")]
        public double TempDurchflussKreis19WertSoll => State.TempDurchflussKreis19WertSoll; // DURCHFLUSS_KREIS_19 WERTSOLL in [1/min]   Feld 84

        [Name("DURCHFLUSS_KREIS_19 WERTIST")]
        public double TempDurchflussKreis19WertIst => State.TempDurchflussKreis19WertIst; // DURCHFLUSS_KREIS_19 WERTIST in [1/min]   Feld 85

        [Name("DURCHFLUSS_KREIS_20 WERTSOLL")]
        public double TempDurchflussKreis20WertSoll => State.TempDurchflussKreis20WertSoll; // DURCHFLUSS_KREIS_20 WERTSOLL in [1/min]   Feld 86

        [Name("DURCHFLUSS_KREIS_20 WERTIST")]
        public double TempDurchflussKreis20WertIst => State.TempDurchflussKreis20WertIst; // DURCHFLUSS_KREIS_20 WERTIST in [1/min]   Feld 87


        [Name("DURCHFLUSS_KREIS_21 WERTSOLL")]
        public double TempDurchflussKreis21WertSoll => State.TempDurchflussKreis21WertSoll; // DURCHFLUSS_KREIS_21 WERTSOLL in [1/min]   Feld 88

        [Name("DURCHFLUSS_KREIS_21 WERTIST")]
        public double TempDurchflussKreis21WertIst => State.TempDurchflussKreis21WertIst; // DURCHFLUSS_KREIS_21 WERTIST in [1/min]   Feld 89

        [Name("DURCHFLUSS_KREIS_22 WERTSOLL")]
        public double TempDurchflussKreis22WertSoll => State.TempDurchflussKreis22WertSoll; // DURCHFLUSS_KREIS_22 WERTSOLL in [1/min]   Feld 90

        [Name("DURCHFLUSS_KREIS_22 WERTIST")]
        public double TempDurchflussKreis22WertIst => State.TempDurchflussKreis22WertIst; // DURCHFLUSS_KREIS_22 WERTIST in [1/min]   Feld 91

        [Name("DURCHFLUSS_KREIS_23 WERTSOLL")]
        public double TempDurchflussKreis23WertSoll => State.TempDurchflussKreis23WertSoll; // DURCHFLUSS_KREIS_23 WERTSOLL in [1/min]   Feld 92

        [Name("DURCHFLUSS_KREIS_23 WERTIST")]
        public double TempDurchflussKreis23WertIst => State.TempDurchflussKreis23WertIst; // DURCHFLUSS_KREIS_23 WERTIST in [1/min]   Feld 93

        [Name("DURCHFLUSS_KREIS_24 WERTSOLL")]
        public double TempDurchflussKreis24WertSoll => State.TempDurchflussKreis24WertSoll; // DURCHFLUSS_KREIS_24 WERTSOLL in [1/min]   Feld 94

        [Name("DURCHFLUSS_KREIS_24 WERTIST")]
        public double TempDurchflussKreis24WertIst => State.TempDurchflussKreis24WertIst; // DURCHFLUSS_KREIS_24 WERTIST in [1/min]   Feld 95

        [Name("DURCHFLUSS_KREIS_25 WERTSOLL")]
        public double TempDurchflussKreis25WertSoll => State.TempDurchflussKreis25WertSoll; // DURCHFLUSS_KREIS_25 WERTSOLL in [1/min]   Feld 96

        [Name("DURCHFLUSS_KREIS_25 WERTIST")]
        public double TempDurchflussKreis25WertIst => State.TempDurchflussKreis25WertIst; // DURCHFLUSS_KREIS_25 WERTIST in [1/min]   Feld 97

        [Name("DURCHFLUSS_KREIS_26 WERTSOLL")]
        public double TempDurchflussKreis26WertSoll => State.TempDurchflussKreis26WertSoll; // DURCHFLUSS_KREIS_26 WERTSOLL in [1/min]   Feld 98

        [Name("DURCHFLUSS_KREIS_26 WERTIST")]
        public double TempDurchflussKreis26WertIst => State.TempDurchflussKreis26WertIst; // DURCHFLUSS_KREIS_26 WERTIST in [1/min]   Feld 99

        [Name("DURCHFLUSS_KREIS_27 WERTSOLL")]
        public double TempDurchflussKreis27WertSoll => State.TempDurchflussKreis27WertSoll; // DURCHFLUSS_KREIS_27 WERTSOLL in [1/min]   Feld 100

        [Name("DURCHFLUSS_KREIS_27 WERTIST")]
        public double TempDurchflussKreis27WertIst => State.TempDurchflussKreis27WertIst; // DURCHFLUSS_KREIS_27 WERTIST in [1/min]   Feld 101

        [Name("DURCHFLUSS_KREIS_28 WERTSOLL")]
        public double TempDurchflussKreis28WertSoll => State.TempDurchflussKreis28WertSoll; // DURCHFLUSS_KREIS_28 WERTSOLL in [1/min]   Feld 102

        [Name("DURCHFLUSS_KREIS_28 WERTIST")]
        public double TempDurchflussKreis28WertIst => State.TempDurchflussKreis28WertIst; // DURCHFLUSS_KREIS_28 WERTIST in [1/min]   Feld 103

        [Name("DURCHFLUSS_KREIS_29 WERTSOLL")]
        public double TempDurchflussKreis29WertSoll => State.TempDurchflussKreis29WertSoll; // DURCHFLUSS_KREIS_29 WERTSOLL in [1/min]   Feld 104

        [Name("DURCHFLUSS_KREIS_29 WERTIST")]
        public double TempDurchflussKreis29WertIst => State.TempDurchflussKreis29WertIst; // DURCHFLUSS_KREIS_29 WERTIST in [1/min]   Feld 105

        [Name("DURCHFLUSS_KREIS_30 WERTSOLL")]
        public double TempDurchflussKreis30WertSoll => State.TempDurchflussKreis30WertSoll; // DURCHFLUSS_KREIS_30 WERTSOLL in [1/min]   Feld 106

        [Name("DURCHFLUSS_KREIS_30 WERTIST")]
        public double TempDurchflussKreis30WertIst => State.TempDurchflussKreis30WertIst; // DURCHFLUSS_KREIS_30 WERTIST in [1/min]   Feld 107


        [Name("DURCHFLUSS_KREIS_31 WERTSOLL")]
        public double TempDurchflussKreis31WertSoll => State.TempDurchflussKreis31WertSoll; // DURCHFLUSS_KREIS_31 WERTSOLL in [1/min]   Feld 108

        [Name("DURCHFLUSS_KREIS_31 WERTIST")]
        public double TempDurchflussKreis31WertIst => State.TempDurchflussKreis31WertIst; // DURCHFLUSS_KREIS_31 WERTIST in [1/min]   Feld 109

        [Name("DURCHFLUSS_KREIS_32 WERTSOLL")]
        public double TempDurchflussKreis32WertSoll => State.TempDurchflussKreis32WertSoll; // DURCHFLUSS_KREIS_32 WERTSOLL in [1/min]   Feld 110

        [Name("DURCHFLUSS_KREIS_32 WERTIST")]
        public double TempDurchflussKreis32WertIst => State.TempDurchflussKreis32WertIst; // DURCHFLUSS_KREIS_32 WERTIST in [1/min]   Feld 111

        [Name("DURCHFLUSS_KREIS_33 WERTSOLL")]
        public double TempDurchflussKreis33WertSoll => State.TempDurchflussKreis33WertSoll; // DURCHFLUSS_KREIS_33 WERTSOLL in [1/min]   Feld 112

        [Name("DURCHFLUSS_KREIS_33 WERTIST")]
        public double TempDurchflussKreis33WertIst => State.TempDurchflussKreis33WertIst; // DURCHFLUSS_KREIS_33 WERTIST in [1/min]   Feld 113

        [Name("DURCHFLUSS_KREIS_34 WERTSOLL")]
        public double TempDurchflussKreis34WertSoll => State.TempDurchflussKreis34WertSoll; // DURCHFLUSS_KREIS_34 WERTSOLL in [1/min]   Feld 114

        [Name("DURCHFLUSS_KREIS_34 WERTIST")]
        public double TempDurchflussKreis34WertIst => State.TempDurchflussKreis34WertIst; // DURCHFLUSS_KREIS_34 WERTIST in [1/min]   Feld 115

        [Name("DURCHFLUSS_KREIS_35 WERTSOLL")]
        public double TempDurchflussKreis35WertSoll => State.TempDurchflussKreis35WertSoll; // DURCHFLUSS_KREIS_35 WERTSOLL in [1/min]   Feld 116

        [Name("DURCHFLUSS_KREIS_35 WERTIST")]
        public double TempDurchflussKreis35WertIst => State.TempDurchflussKreis35WertIst; // DURCHFLUSS_KREIS_35 WERTIST in [1/min]   Feld 117

        [Name("DURCHFLUSS_KREIS_36 WERTSOLL")]
        public double TempDurchflussKreis36WertSoll => State.TempDurchflussKreis36WertSoll; // DURCHFLUSS_KREIS_36 WERTSOLL in [1/min]   Feld 118

        [Name("DURCHFLUSS_KREIS_36 WERTIST")]
        public double TempDurchflussKreis36WertIst => State.TempDurchflussKreis36WertIst; // DURCHFLUSS_KREIS_36 WERTIST in [1/min]   Feld 119

        [Name("DURCHFLUSS_KREIS_37 WERTSOLL")]
        public double TempDurchflussKreis37WertSoll => State.TempDurchflussKreis37WertSoll; // DURCHFLUSS_KREIS_37 WERTSOLL in [1/min]   Feld 120

        [Name("DURCHFLUSS_KREIS_37 WERTIST")]
        public double TempDurchflussKreis37WertIst => State.TempDurchflussKreis37WertIst; // DURCHFLUSS_KREIS_37 WERTIST in [1/min]   Feld 121

        [Name("DURCHFLUSS_KREIS_38 WERTSOLL")]
        public double TempDurchflussKreis38WertSoll => State.TempDurchflussKreis38WertSoll; // DURCHFLUSS_KREIS_38 WERTSOLL in [1/min]   Feld 122

        [Name("DURCHFLUSS_KREIS_38 WERTIST")]
        public double TempDurchflussKreis38WertIst => State.TempDurchflussKreis38WertIst; // DURCHFLUSS_KREIS_38 WERTIST in [1/min]   Feld 123

        [Name("DURCHFLUSS_KREIS_39 WERTSOLL")]
        public double TempDurchflussKreis39WertSoll => State.TempDurchflussKreis39WertSoll; // DURCHFLUSS_KREIS_39 WERTSOLL in [1/min]   Feld 124

        [Name("DURCHFLUSS_KREIS_39 WERTIST")]
        public double TempDurchflussKreis39WertIst => State.TempDurchflussKreis39WertIst; // DURCHFLUSS_KREIS_39 WERTIST in [1/min]   Feld 125

        [Name("DURCHFLUSS_KREIS_40 WERTSOLL")]
        public double TempDurchflussKreis40WertSoll => State.TempDurchflussKreis40WertSoll; // DURCHFLUSS_KREIS_40 WERTSOLL in [1/min]   Feld 126

        [Name("DURCHFLUSS_KREIS_40 WERTIST")]
        public double TempDurchflussKreis40WertIst => State.TempDurchflussKreis40WertIst; // DURCHFLUSS_KREIS_40 WERTIST in [1/min]   Feld 127
        #endregion

        [Name("MES aktiv")]
        public bool MesAktiv => State.MesAktiv; // MES aktiv Feld 128


        [Name("Ausgleichshub 1 WERTSOLL")]
        public double Ausgleichhub1WertSoll => State.Ausgleichhub1WertSoll; // Ausgleichshub 1 WERTSOLL in [bar]   Feld 129
        [Name("Ausgleichshub 1 WERTIST")]
        public double Ausgleichhub1WertIst => State.Ausgleichhub1WertIst; // Ausgleichshub 1 WERTIST in [bar]   Feld 130
        [Name("Ausgleichshub 2 WERTSOLL")]
        public double Ausgleichhub2WertSoll => State.Ausgleichhub2WertSoll; // Ausgleichshub 2 WERTSOLL in [bar]   Feld 131
        [Name("Ausgleichshub 2 WERTIST")]
        public double Ausgleichhub2WertIst => State.Ausgleichhub2WertIst; // Ausgleichshub 2 WERTIST in [bar]   Feld 132


        #region N2 Einschaltverzögerung
        [Name("Einschaltverz DURCHFLUSS_KREIS_1")]
        public double EinschaltverzDurchflussKreis1 => State.EinschaltverzDurchflussKreis1; // Einschaltverz DURCHFLUSS_KREIS_1 in [ms]   Feld 133

        [Name("Einschaltverz DURCHFLUSS_KREIS_2")]
        public double EinschaltverzDurchflussKreis2 => State.EinschaltverzDurchflussKreis2; // Einschaltverz DURCHFLUSS_KREIS_2 in [ms]   Feld 134

        [Name("Einschaltverz DURCHFLUSS_KREIS_3")]
        public double EinschaltverzDurchflussKreis3 => State.EinschaltverzDurchflussKreis3; // Einschaltverz DURCHFLUSS_KREIS_3 in [ms]   Feld 135

        [Name("Einschaltverz DURCHFLUSS_KREIS_4")]
        public double EinschaltverzDurchflussKreis4 => State.EinschaltverzDurchflussKreis4; // Einschaltverz DURCHFLUSS_KREIS_4 in [ms]   Feld 136

        [Name("Einschaltverz DURCHFLUSS_KREIS_5")]
        public double EinschaltverzDurchflussKreis5 => State.EinschaltverzDurchflussKreis5; // Einschaltverz DURCHFLUSS_KREIS_5 in [ms]   Feld 137

        [Name("Einschaltverz DURCHFLUSS_KREIS_6")]
        public double EinschaltverzDurchflussKreis6 => State.EinschaltverzDurchflussKreis6; // Einschaltverz DURCHFLUSS_KREIS_6 in [ms]   Feld 138

        [Name("Einschaltverz DURCHFLUSS_KREIS_7")]
        public double EinschaltverzDurchflussKreis7 => State.EinschaltverzDurchflussKreis7; // Einschaltverz DURCHFLUSS_KREIS_7 in [ms]   Feld 139

        [Name("Einschaltverz DURCHFLUSS_KREIS_8")]
        public double EinschaltverzDurchflussKreis8 => State.EinschaltverzDurchflussKreis8; // Einschaltverz DURCHFLUSS_KREIS_8 in [ms]   Feld 140

        [Name("Einschaltverz DURCHFLUSS_KREIS_9")]
        public double EinschaltverzDurchflussKreis9 => State.EinschaltverzDurchflussKreis9; // Einschaltverz DURCHFLUSS_KREIS_9 in [ms]   Feld 141

        [Name("Einschaltverz DURCHFLUSS_KREIS_10")]
        public double EinschaltverzDurchflussKreis10 => State.EinschaltverzDurchflussKreis10; // Einschaltverz DURCHFLUSS_KREIS_10 in [ms]   Feld 142

        [Name("Einschaltverz DURCHFLUSS_KREIS_11")]

        public double EinschaltverzDurchflussKreis11 => State.EinschaltverzDurchflussKreis11; // Einschaltverz DURCHFLUSS_KREIS_11 in [ms]   Feld 143

        [Name("Einschaltverz DURCHFLUSS_KREIS_12")]
        public double EinschaltverzDurchflussKreis12 => State.EinschaltverzDurchflussKreis12; // Einschaltverz DURCHFLUSS_KREIS_12 in [ms]   Feld 144

        [Name("Einschaltverz DURCHFLUSS_KREIS_13")]
        public double EinschaltverzDurchflussKreis13 => State.EinschaltverzDurchflussKreis13; // Einschaltverz DURCHFLUSS_KREIS_13 in [ms]   Feld 145

        [Name("Einschaltverz DURCHFLUSS_KREIS_14")]
        public double EinschaltverzDurchflussKreis14 => State.EinschaltverzDurchflussKreis14; // Einschaltverz DURCHFLUSS_KREIS_14 in [ms]   Feld 146

        [Name("Einschaltverz DURCHFLUSS_KREIS_15")]
        public double EinschaltverzDurchflussKreis15 => State.EinschaltverzDurchflussKreis15; // Einschaltverz DURCHFLUSS_KREIS_15 in [ms]   Feld 147

        [Name("Einschaltverz DURCHFLUSS_KREIS_16")]
        public double EinschaltverzDurchflussKreis16 => State.EinschaltverzDurchflussKreis16; // Einschaltverz DURCHFLUSS_KREIS_16 in [ms]   Feld 148

        [Name("Einschaltverz DURCHFLUSS_KREIS_17")]
        public double EinschaltverzDurchflussKreis17 => State.EinschaltverzDurchflussKreis17; // Einschaltverz DURCHFLUSS_KREIS_17 in [ms]   Feld 149

        [Name("Einschaltverz DURCHFLUSS_KREIS_18")]
        public double EinschaltverzDurchflussKreis18 => State.EinschaltverzDurchflussKreis18; // Einschaltverz DURCHFLUSS_KREIS_18 in [ms]   Feld 150

        [Name("Einschaltverz DURCHFLUSS_KREIS_19")]
        public double EinschaltverzDurchflussKreis19 => State.EinschaltverzDurchflussKreis19; // Einschaltverz DURCHFLUSS_KREIS_19 in [ms]   Feld 151

        [Name("Einschaltverz DURCHFLUSS_KREIS_20")]
        public double EinschaltverzDurchflussKreis20 => State.EinschaltverzDurchflussKreis20; // Einschaltverz DURCHFLUSS_KREIS_20 in [ms]   Feld 152

        [Name("Einschaltverz DURCHFLUSS_KREIS_21")]

        public double EinschaltverzDurchflussKreis21 => State.EinschaltverzDurchflussKreis21; // Einschaltverz DURCHFLUSS_KREIS_21 in [ms]   Feld 153

        [Name("Einschaltverz DURCHFLUSS_KREIS_22")]
        public double EinschaltverzDurchflussKreis22 => State.EinschaltverzDurchflussKreis22; // Einschaltverz DURCHFLUSS_KREIS_22 in [ms]   Feld 154

        [Name("Einschaltverz DURCHFLUSS_KREIS_23")]
        public double EinschaltverzDurchflussKreis23 => State.EinschaltverzDurchflussKreis23; // Einschaltverz DURCHFLUSS_KREIS_23 in [ms]   Feld 155

        [Name("Einschaltverz DURCHFLUSS_KREIS_24")]
        public double EinschaltverzDurchflussKreis24 => State.EinschaltverzDurchflussKreis24; // Einschaltverz DURCHFLUSS_KREIS_24 in [ms]   Feld 156

        [Name("Einschaltverz DURCHFLUSS_KREIS_25")]
        public double EinschaltverzDurchflussKreis25 => State.EinschaltverzDurchflussKreis25; // Einschaltverz DURCHFLUSS_KREIS_25 in [ms]   Feld 157

        [Name("Einschaltverz DURCHFLUSS_KREIS_26")]
        public double EinschaltverzDurchflussKreis26 => State.EinschaltverzDurchflussKreis26; // Einschaltverz DURCHFLUSS_KREIS_26 in [ms]   Feld 158

        [Name("Einschaltverz DURCHFLUSS_KREIS_27")]
        public double EinschaltverzDurchflussKreis27 => State.EinschaltverzDurchflussKreis27; // Einschaltverz DURCHFLUSS_KREIS_27 in [ms]   Feld 159

        [Name("Einschaltverz DURCHFLUSS_KREIS_28")]
        public double EinschaltverzDurchflussKreis28 => State.EinschaltverzDurchflussKreis28; // Einschaltverz DURCHFLUSS_KREIS_28 in [ms]   Feld 160

        [Name("Einschaltverz DURCHFLUSS_KREIS_29")]
        public double EinschaltverzDurchflussKreis29 => State.EinschaltverzDurchflussKreis29; // Einschaltverz DURCHFLUSS_KREIS_29 in [ms]   Feld 161

        [Name("Einschaltverz DURCHFLUSS_KREIS_30")]
        public double EinschaltverzDurchflussKreis30 => State.EinschaltverzDurchflussKreis30; // Einschaltverz DURCHFLUSS_KREIS_30 in [ms]   Feld 162

        [Name("Einschaltverz DURCHFLUSS_KREIS_31")]

        public double EinschaltverzDurchflussKreis31 => State.EinschaltverzDurchflussKreis31; // Einschaltverz DURCHFLUSS_KREIS_31 in [ms]   Feld 163

        [Name("Einschaltverz DURCHFLUSS_KREIS_32")]
        public double EinschaltverzDurchflussKreis32 => State.EinschaltverzDurchflussKreis32; // Einschaltverz DURCHFLUSS_KREIS_32 in [ms]   Feld 164

        [Name("Einschaltverz DURCHFLUSS_KREIS_33")]
        public double EinschaltverzDurchflussKreis33 => State.EinschaltverzDurchflussKreis33; // Einschaltverz DURCHFLUSS_KREIS_33 in [ms]   Feld 165

        [Name("Einschaltverz DURCHFLUSS_KREIS_34")]
        public double EinschaltverzDurchflussKreis34 => State.EinschaltverzDurchflussKreis34; // Einschaltverz DURCHFLUSS_KREIS_34 in [ms]   Feld 166

        [Name("Einschaltverz DURCHFLUSS_KREIS_35")]
        public double EinschaltverzDurchflussKreis35 => State.EinschaltverzDurchflussKreis35; // Einschaltverz DURCHFLUSS_KREIS_35 in [ms]   Feld 167

        [Name("Einschaltverz DURCHFLUSS_KREIS_36")]
        public double EinschaltverzDurchflussKreis36 => State.EinschaltverzDurchflussKreis36; // Einschaltverz DURCHFLUSS_KREIS_36 in [ms]   Feld 168

        [Name("Einschaltverz DURCHFLUSS_KREIS_37")]
        public double EinschaltverzDurchflussKreis37 => State.EinschaltverzDurchflussKreis37; // Einschaltverz DURCHFLUSS_KREIS_37 in [ms]   Feld 169

        [Name("Einschaltverz DURCHFLUSS_KREIS_38")]
        public double EinschaltverzDurchflussKreis38 => State.EinschaltverzDurchflussKreis38; // Einschaltverz DURCHFLUSS_KREIS_38 in [ms]   Feld 170

        [Name("Einschaltverz DURCHFLUSS_KREIS_39")]
        public double EinschaltverzDurchflussKreis39 => State.EinschaltverzDurchflussKreis39; // Einschaltverz DURCHFLUSS_KREIS_39 in [ms]   Feld 171

        [Name("Einschaltverz DURCHFLUSS_KREIS_40")]
        public double EinschaltverzDurchflussKreis40 => State.EinschaltverzDurchflussKreis40; // Einschaltverz DURCHFLUSS_KREIS_40 in [ms]   Feld 172
        #endregion

        public static ProcessDataSqlDb CreateFromState(ProcessData state)
        {
            return new ProcessDataSqlDb(state);
        }
    }

}

