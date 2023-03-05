using System;


namespace WinS7Library.Model.Export
{
    public class ProcessData
    {
        #region DMXCode
        public string DmxCode1 { get; set; } = default;
        public string DmxCode2 { get; set; } = default;
        public string DmxCode3 { get; set; } = default;
        public string DmxCode4 { get; set; } = default;
        public string DmxCode5 { get; set; } = default;
        public string DmxCode6 { get; set; } = default;
        public string DmxCode7 { get; set; } = default;
        public string DmxCode8 { get; set; } = default;
        #endregion

        public int WarmPositionA3 { get; set; } = default;
        public int FuegeStromA1 { get; set; } = default;
        public int FuegeStromA2 { get; set; } = default;

        public DateTime DatumUhrzeit { get; set; } = default; // Feld 0
                                                            
        public string Produktname { get; set; } = default; // Feld 1
        public int SchweissungsergebnisNio { get; set; } = default; // Feld 2
        public double Kraft1Wert { get; set; } = default; // Kraft1Wert in [N]  Feld 3  
        public int Kraft1Result { get; set; } = default; // Feld 4
        public double Weg1Wert { get; set; } = default; // Weg1Wert in [mm] Feld 5
        public int Weg1Result { get; set; } = default; // Feld 6
        public double Kraft2Wert { get; set; } = default; // Kraft2Wert in [N]  Feld 7  
        public int Kraft2Result { get; set; } = default; // Feld 8
        public double Weg2Wert { get; set; } = default; // Weg2Wert in [mm] Feld 9
        public int Weg2Result { get; set; } = default; // Feld 10   
        public int WarmZeit1Wert { get; set; } = default; // WARMZEIT_1 WERT in [s] Feld 11
        public int WarmPosition1ObenWert { get; set; } = default; // WARMPOSITION_1 OBEN WERT in [mm]   Feld 12
        public int WarmPosition1UntenWert { get; set; } = default; // WARMPOSITION_1 UNTEN WERT in [mm]   Feld 13
        public int WarmZei2Wert { get; set; } = default; // WARMZEIT_2 WERT [s]   Feld 14
        public int WarmPosition2ObenWert { get; set; } = default; // WARMPOSITION_2 OBEN WERT in [mm]   Feld 15
        public int WarmPosition2UntenWert { get; set; } = default; // WARMPOSITION_2 UNTEN WERT in [mm]   Feld 16
        public int FuegeVObenWert { get; set; } = default; // FUEGE_V OBEN WERT in [mm/s]   Feld 17
        public int FuegeVUntenWert { get; set; } = default; // FUEGE_V OBEN WERT in [mm/s]   Feld 18
        public int FuegePositionObenWert { get; set; } = default; // FUEGEPOSITION OBEN WERT [mm]   Feld 19
        public int FuegePositionUntenWert { get; set; } = default; // FUEGEPOSITION UNTEN WERT [mm]   Feld 20
        public int KuehlZeitWert { get; set; } = default; // KUEHLZEIT WERT in [s] Feld 21
        public int UmstellZeitWert { get; set; } = default; // UMSTELLZEIT WERT in [s] Feld 22
        public int ZyklusZeitWert { get; set; } = default; // ZYKLUSZEIT WERT in [s] Feld 23

        #region Temperaturen Heizelement
        public int TempHeizelement1WertSoll { get; set; } = default; // TEMP_HEIZELEMENT_1 WERTSOLL in [°C]   Feld 24
        public int TempHeizelement1WertIst { get; set; } = default; // TEMP_HEIZELEMENT_1 WERTIST in [°C]   Feld 25
        public int TempHeizelement2WertSoll { get; set; } = default; // TEMP_HEIZELEMENT_2 WERTSOLL in [°C]   Feld 26
        public int TempHeizelement2WertIst { get; set; } = default; // TEMP_HEIZELEMENT_2 WERTIST in [°C]   Feld 27
        public int TempHeizelement3WertSoll { get; set; } = default; // TEMP_HEIZELEMENT_3 WERTSOLL in [°C]   Feld 28
        public int TempHeizelement3WertIst { get; set; } = default; // TEMP_HEIZELEMENT_3 WERTIST in [°C]   Feld 29
        public int TempHeizelement4WertSoll { get; set; } = default; // TEMP_HEIZELEMENT_4 WERTSOLL in [°C]   Feld 30
        public int TempHeizelement4WertIst { get; set; } = default; // TEMP_HEIZELEMENT_4 WERTIST in [°C]   Feld 31
        public int TempHeizelement5WertSoll { get; set; } = default; // TEMP_HEIZELEMENT_5 WERTSOLL in [°C]   Feld 32
        public int TempHeizelement5WertIst { get; set; } = default; // TEMP_HEIZELEMENT_5 WERTIST in [°C]   Feld 33
        public int TempHeizelement6WertSoll { get; set; } = default; // TEMP_HEIZELEMENT_6 WERTSOLL in [°C]   Feld 34
        public int TempHeizelement6WertIst { get; set; } = default; // TEMP_HEIZELEMENT_6 WERTIST in [°C]   Feld 35
        public int TempHeizelement7WertSoll { get; set; } = default; // TEMP_HEIZELEMENT_7 WERTSOLL in [°C]   Feld 36
        public int TempHeizelement7WertIst { get; set; } = default; // TEMP_HEIZELEMENT_7 WERTIST in [°C]   Feld 37
        public int TempHeizelement8WertSoll { get; set; } = default; // TEMP_HEIZELEMENT_8 WERTSOLL in [°C]   Feld 38
        public int TempHeizelement8WertIst { get; set; } = default; // TEMP_HEIZELEMENT_8 WERTIST in [°C]   Feld 39
        public int TempHeizelement9WertSoll { get; set; } = default; // TEMP_HEIZELEMENT_9 WERTSOLL in [°C]   Feld 40
        public int TempHeizelement9WertIst { get; set; } = default; // TEMP_HEIZELEMENT_9 WERTIST in [°C]   Feld 41
        public int TempHeizelement10WertSoll { get; set; } = default; // TEMP_HEIZELEMENT_10 WERTSOLL in [°C]   Feld 42
        public int TempHeizelement10WertIst { get; set; } = default; // TEMP_HEIZELEMENT_10 WERTIST in [°C]   Feld 43
        public int TempHeizelement11WertSoll { get; set; } = default; // TEMP_HEIZELEMENT_11 WERTSOLL in [°C]   Feld 44
        public int TempHeizelement11WertIst { get; set; } = default; // TEMP_HEIZELEMENT_11 WERTIST in [°C]   Feld 45
        public int TempHeizelement12WertSoll { get; set; } = default; // TEMP_HEIZELEMENT_12 WERTSOLL in [°C]   Feld 46
        public int TempHeizelement12WertIst { get; set; } = default; // TEMP_HEIZELEMENT_12 WERTIST in [°C]   Feld 47
        #endregion

        #region N2 Durchfluss
        public double TempDurchflussKreis1WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_1 WERTSOLL in [1/min]   Feld 48
        public double TempDurchflussKreis1WertIst { get; set; } = default; // DURCHFLUSS_KREIS_1 WERTIST in [1/min]   Feld 49
        public double TempDurchflussKreis2WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_2 WERTSOLL in [1/min]   Feld 50
        public double TempDurchflussKreis2WertIst { get; set; } = default; // DURCHFLUSS_KREIS_2 WERTIST in [1/min]   Feld 51
        public double TempDurchflussKreis3WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_3 WERTSOLL in [1/min]   Feld 52
        public double TempDurchflussKreis3WertIst { get; set; } = default; // DURCHFLUSS_KREIS_3 WERTIST in [1/min]   Feld 53
        public double TempDurchflussKreis4WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_4 WERTSOLL in [1/min]   Feld 54
        public double TempDurchflussKreis4WertIst { get; set; } = default; // DURCHFLUSS_KREIS_4 WERTIST in [1/min]   Feld 55
        public double TempDurchflussKreis5WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_5 WERTSOLL in [1/min]   Feld 56
        public double TempDurchflussKreis5WertIst { get; set; } = default; // DURCHFLUSS_KREIS_5 WERTIST in [1/min]   Feld 57
        public double TempDurchflussKreis6WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_6 WERTSOLL in [1/min]   Feld 58
        public double TempDurchflussKreis6WertIst { get; set; } = default; // DURCHFLUSS_KREIS_6 WERTIST in [1/min]   Feld 59
        public double TempDurchflussKreis7WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_7 WERTSOLL in [1/min]   Feld 60
        public double TempDurchflussKreis7WertIst { get; set; } = default; // DURCHFLUSS_KREIS_7 WERTIST in [1/min]   Feld 61
        public double TempDurchflussKreis8WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_8 WERTSOLL in [1/min]   Feld 62
        public double TempDurchflussKreis8WertIst { get; set; } = default; // DURCHFLUSS_KREIS_8 WERTIST in [1/min]   Feld 63
        public double TempDurchflussKreis9WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_9 WERTSOLL in [1/min]   Feld 64
        public double TempDurchflussKreis9WertIst { get; set; } = default; // DURCHFLUSS_KREIS_9 WERTIST in [1/min]   Feld 65
        public double TempDurchflussKreis10WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_10 WERTSOLL in [1/min]   Feld 66
        public double TempDurchflussKreis10WertIst { get; set; } = default; // DURCHFLUSS_KREIS_10 WERTIST in [1/min]   Feld 67

        public double TempDurchflussKreis11WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_11 WERTSOLL in [1/min]   Feld 68
        public double TempDurchflussKreis11WertIst { get; set; } = default; // DURCHFLUSS_KREIS_11 WERTIST in [1/min]   Feld 69
        public double TempDurchflussKreis12WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_12 WERTSOLL in [1/min]   Feld 70
        public double TempDurchflussKreis12WertIst { get; set; } = default; // DURCHFLUSS_KREIS_12 WERTIST in [1/min]   Feld 71
        public double TempDurchflussKreis13WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_13 WERTSOLL in [1/min]   Feld 72
        public double TempDurchflussKreis13WertIst { get; set; } = default; // DURCHFLUSS_KREIS_13 WERTIST in [1/min]   Feld 73
        public double TempDurchflussKreis14WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_14 WERTSOLL in [1/min]   Feld 74
        public double TempDurchflussKreis14WertIst { get; set; } = default; // DURCHFLUSS_KREIS_14 WERTIST in [1/min]   Feld 75
        public double TempDurchflussKreis15WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_15 WERTSOLL in [1/min]   Feld 76
        public double TempDurchflussKreis15WertIst { get; set; } = default; // DURCHFLUSS_KREIS_15 WERTIST in [1/min]   Feld 77
        public double TempDurchflussKreis16WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_16 WERTSOLL in [1/min]   Feld 78
        public double TempDurchflussKreis16WertIst { get; set; } = default; // DURCHFLUSS_KREIS_16 WERTIST in [1/min]   Feld 79
        public double TempDurchflussKreis17WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_17 WERTSOLL in [1/min]   Feld 80
        public double TempDurchflussKreis17WertIst { get; set; } = default; // DURCHFLUSS_KREIS_17 WERTIST in [1/min]   Feld 81
        public double TempDurchflussKreis18WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_18 WERTSOLL in [1/min]   Feld 82
        public double TempDurchflussKreis18WertIst { get; set; } = default; // DURCHFLUSS_KREIS_18 WERTIST in [1/min]   Feld 83
        public double TempDurchflussKreis19WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_19 WERTSOLL in [1/min]   Feld 84
        public double TempDurchflussKreis19WertIst { get; set; } = default; // DURCHFLUSS_KREIS_19 WERTIST in [1/min]   Feld 85
        public double TempDurchflussKreis20WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_20 WERTSOLL in [1/min]   Feld 86
        public double TempDurchflussKreis20WertIst { get; set; } = default; // DURCHFLUSS_KREIS_20 WERTIST in [1/min]   Feld 87

        public double TempDurchflussKreis21WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_21 WERTSOLL in [1/min]   Feld 88
        public double TempDurchflussKreis21WertIst { get; set; } = default; // DURCHFLUSS_KREIS_21 WERTIST in [1/min]   Feld 89
        public double TempDurchflussKreis22WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_22 WERTSOLL in [1/min]   Feld 90
        public double TempDurchflussKreis22WertIst { get; set; } = default; // DURCHFLUSS_KREIS_22 WERTIST in [1/min]   Feld 91
        public double TempDurchflussKreis23WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_23 WERTSOLL in [1/min]   Feld 92
        public double TempDurchflussKreis23WertIst { get; set; } = default; // DURCHFLUSS_KREIS_23 WERTIST in [1/min]   Feld 93
        public double TempDurchflussKreis24WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_24 WERTSOLL in [1/min]   Feld 94
        public double TempDurchflussKreis24WertIst { get; set; } = default; // DURCHFLUSS_KREIS_24 WERTIST in [1/min]   Feld 95
        public double TempDurchflussKreis25WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_25 WERTSOLL in [1/min]   Feld 96
        public double TempDurchflussKreis25WertIst { get; set; } = default; // DURCHFLUSS_KREIS_25 WERTIST in [1/min]   Feld 97
        public double TempDurchflussKreis26WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_26 WERTSOLL in [1/min]   Feld 98
        public double TempDurchflussKreis26WertIst { get; set; } = default; // DURCHFLUSS_KREIS_26 WERTIST in [1/min]   Feld 99
        public double TempDurchflussKreis27WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_27 WERTSOLL in [1/min]   Feld 100
        public double TempDurchflussKreis27WertIst { get; set; } = default; // DURCHFLUSS_KREIS_27 WERTIST in [1/min]   Feld 101
        public double TempDurchflussKreis28WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_28 WERTSOLL in [1/min]   Feld 102
        public double TempDurchflussKreis28WertIst { get; set; } = default; // DURCHFLUSS_KREIS_28 WERTIST in [1/min]   Feld 103
        public double TempDurchflussKreis29WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_29 WERTSOLL in [1/min]   Feld 104
        public double TempDurchflussKreis29WertIst { get; set; } = default; // DURCHFLUSS_KREIS_29 WERTIST in [1/min]   Feld 105
        public double TempDurchflussKreis30WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_30 WERTSOLL in [1/min]   Feld 106
        public double TempDurchflussKreis30WertIst { get; set; } = default; // DURCHFLUSS_KREIS_30 WERTIST in [1/min]   Feld 107

        public double TempDurchflussKreis31WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_31 WERTSOLL in [1/min]   Feld 108
        public double TempDurchflussKreis31WertIst { get; set; } = default; // DURCHFLUSS_KREIS_31 WERTIST in [1/min]   Feld 109
        public double TempDurchflussKreis32WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_32 WERTSOLL in [1/min]   Feld 110
        public double TempDurchflussKreis32WertIst { get; set; } = default; // DURCHFLUSS_KREIS_32 WERTIST in [1/min]   Feld 111
        public double TempDurchflussKreis33WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_33 WERTSOLL in [1/min]   Feld 112
        public double TempDurchflussKreis33WertIst { get; set; } = default; // DURCHFLUSS_KREIS_33 WERTIST in [1/min]   Feld 113
        public double TempDurchflussKreis34WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_34 WERTSOLL in [1/min]   Feld 114
        public double TempDurchflussKreis34WertIst { get; set; } = default; // DURCHFLUSS_KREIS_34 WERTIST in [1/min]   Feld 115
        public double TempDurchflussKreis35WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_35 WERTSOLL in [1/min]   Feld 116
        public double TempDurchflussKreis35WertIst { get; set; } = default; // DURCHFLUSS_KREIS_35 WERTIST in [1/min]   Feld 117
        public double TempDurchflussKreis36WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_36 WERTSOLL in [1/min]   Feld 118
        public double TempDurchflussKreis36WertIst { get; set; } = default; // DURCHFLUSS_KREIS_36 WERTIST in [1/min]   Feld 119
        public double TempDurchflussKreis37WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_37 WERTSOLL in [1/min]   Feld 120
        public double TempDurchflussKreis37WertIst { get; set; } = default; // DURCHFLUSS_KREIS_37 WERTIST in [1/min]   Feld 121
        public double TempDurchflussKreis38WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_38 WERTSOLL in [1/min]   Feld 122
        public double TempDurchflussKreis38WertIst { get; set; } = default; // DURCHFLUSS_KREIS_38 WERTIST in [1/min]   Feld 123
        public double TempDurchflussKreis39WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_39 WERTSOLL in [1/min]   Feld 124
        public double TempDurchflussKreis39WertIst { get; set; } = default; // DURCHFLUSS_KREIS_39 WERTIST in [1/min]   Feld 125
        public double TempDurchflussKreis40WertSoll { get; set; } = default; // DURCHFLUSS_KREIS_40 WERTSOLL in [1/min]   Feld 126
        public double TempDurchflussKreis40WertIst { get; set; } = default; // DURCHFLUSS_KREIS_40 WERTIST in [1/min]   Feld 127
        #endregion

        public bool MesAktiv { get; set; } = default; // MES aktiv Feld 128

        public double Ausgleichhub1WertSoll { get; set; } = default; // Ausgleichshub 1 WERTSOLL in [bar]   Feld 129
        public double Ausgleichhub1WertIst { get; set; } = default; // Ausgleichshub 1 WERTIST in [bar]   Feld 130
        public double Ausgleichhub2WertSoll { get; set; } = default; // Ausgleichshub 2 WERTSOLL in [bar]   Feld 131
        public double Ausgleichhub2WertIst { get; set; } = default; // Ausgleichshub 2 WERTIST in [bar]   Feld 132

        #region N2 Einschaltverzögerung
        public double EinschaltverzDurchflussKreis1 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_1 in [ms]   Feld 133
        public double EinschaltverzDurchflussKreis2 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_2 in [ms]   Feld 134
        public double EinschaltverzDurchflussKreis3 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_3 in [ms]   Feld 135
        public double EinschaltverzDurchflussKreis4 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_4 in [ms]   Feld 136
        public double EinschaltverzDurchflussKreis5 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_5 in [ms]   Feld 137
        public double EinschaltverzDurchflussKreis6 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_6 in [ms]   Feld 138
        public double EinschaltverzDurchflussKreis7 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_7 in [ms]   Feld 139
        public double EinschaltverzDurchflussKreis8 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_8 in [ms]   Feld 140
        public double EinschaltverzDurchflussKreis9 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_9 in [ms]   Feld 141
        public double EinschaltverzDurchflussKreis10 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_10 in [ms]   Feld 142

        public double EinschaltverzDurchflussKreis11 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_11 in [ms]   Feld 143
        public double EinschaltverzDurchflussKreis12 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_12 in [ms]   Feld 144
        public double EinschaltverzDurchflussKreis13 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_13 in [ms]   Feld 145
        public double EinschaltverzDurchflussKreis14 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_14 in [ms]   Feld 146
        public double EinschaltverzDurchflussKreis15 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_15 in [ms]   Feld 147
        public double EinschaltverzDurchflussKreis16 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_16 in [ms]   Feld 148
        public double EinschaltverzDurchflussKreis17 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_17 in [ms]   Feld 149
        public double EinschaltverzDurchflussKreis18 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_18 in [ms]   Feld 150
        public double EinschaltverzDurchflussKreis19 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_19 in [ms]   Feld 151
        public double EinschaltverzDurchflussKreis20 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_20 in [ms]   Feld 152

        public double EinschaltverzDurchflussKreis21 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_21 in [ms]   Feld 153
        public double EinschaltverzDurchflussKreis22 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_22 in [ms]   Feld 154
        public double EinschaltverzDurchflussKreis23 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_23 in [ms]   Feld 155
        public double EinschaltverzDurchflussKreis24 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_24 in [ms]   Feld 156
        public double EinschaltverzDurchflussKreis25 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_25 in [ms]   Feld 157
        public double EinschaltverzDurchflussKreis26 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_26 in [ms]   Feld 158
        public double EinschaltverzDurchflussKreis27 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_27 in [ms]   Feld 159
        public double EinschaltverzDurchflussKreis28 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_28 in [ms]   Feld 160
        public double EinschaltverzDurchflussKreis29 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_29 in [ms]   Feld 161
        public double EinschaltverzDurchflussKreis30 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_30 in [ms]   Feld 162

        public double EinschaltverzDurchflussKreis31 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_31 in [ms]   Feld 163
        public double EinschaltverzDurchflussKreis32 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_32 in [ms]   Feld 164
        public double EinschaltverzDurchflussKreis33 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_33 in [ms]   Feld 165
        public double EinschaltverzDurchflussKreis34 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_34 in [ms]   Feld 166
        public double EinschaltverzDurchflussKreis35 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_35 in [ms]   Feld 167
        public double EinschaltverzDurchflussKreis36 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_36 in [ms]   Feld 168
        public double EinschaltverzDurchflussKreis37 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_37 in [ms]   Feld 169
        public double EinschaltverzDurchflussKreis38 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_38 in [ms]   Feld 170
        public double EinschaltverzDurchflussKreis39 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_39 in [ms]   Feld 171
        public double EinschaltverzDurchflussKreis40 { get; set; } = default; // Einschaltverz DURCHFLUSS_KREIS_40 in [ms]   Feld 172
        #endregion
    }


}
