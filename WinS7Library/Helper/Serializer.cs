using Sharp7;
using System;
using System.IO;
using System.Xml.Serialization;
using WinS7Library.Model;
using WinS7Library.Model.Export;

namespace WinS7Library.Helper
{
    public static class Serializer
    {
        #region DatHE

        public static void DatHEToBuffer(DatHE HE, byte[] buffer, ref string error)
        {
            try
            {
                //clear buffer before use
                Array.Clear(buffer, 0, buffer.Length);

                S7.SetIntAt(buffer, 0, HE.HK01.TempSoll);
                S7.SetIntAt(buffer, 2, HE.HK01.ToleranzPlus);
                S7.SetIntAt(buffer, 4, HE.HK01.ToleranzMinus);
                S7.SetIntAt(buffer, 6, HE.HK01.TempTaktung);
                S7.SetIntAt(buffer, 8, HE.HK01.Impulsdauer);
                S7.SetIntAt(buffer, 10, HE.HK01.Pausendauer);
                S7.SetIntAt(buffer, 12, HE.HK01.OffsetAT);
                S7.SetIntAt(buffer, 14, HE.HK01.PiAT);
                S7.SetIntAt(buffer, 16, HE.HK01.TMaxAT);
                S7.SetBitAt(ref buffer, 18, 0, HE.HK01.Aktiv);
                S7.SetIntAt(buffer, 20, HE.HK02.TempSoll);
                S7.SetIntAt(buffer, 22, HE.HK02.ToleranzPlus);
                S7.SetIntAt(buffer, 24, HE.HK02.ToleranzMinus);
                S7.SetIntAt(buffer, 26, HE.HK02.TempTaktung);
                S7.SetIntAt(buffer, 28, HE.HK02.Impulsdauer);
                S7.SetIntAt(buffer, 30, HE.HK02.Pausendauer);
                S7.SetIntAt(buffer, 32, HE.HK02.OffsetAT);
                S7.SetIntAt(buffer, 34, HE.HK02.PiAT);
                S7.SetIntAt(buffer, 36, HE.HK02.TMaxAT);
                S7.SetBitAt(ref buffer, 38, 0, HE.HK02.Aktiv);
                S7.SetIntAt(buffer, 40, HE.HK03.TempSoll);
                S7.SetIntAt(buffer, 42, HE.HK03.ToleranzPlus);
                S7.SetIntAt(buffer, 44, HE.HK03.ToleranzMinus);
                S7.SetIntAt(buffer, 46, HE.HK03.TempTaktung);
                S7.SetIntAt(buffer, 48, HE.HK03.Impulsdauer);
                S7.SetIntAt(buffer, 50, HE.HK03.Pausendauer);
                S7.SetIntAt(buffer, 52, HE.HK03.OffsetAT);
                S7.SetIntAt(buffer, 54, HE.HK03.PiAT);
                S7.SetIntAt(buffer, 56, HE.HK03.TMaxAT);
                S7.SetBitAt(ref buffer, 58, 0, HE.HK03.Aktiv);
                S7.SetIntAt(buffer, 60, HE.HK04.TempSoll);
                S7.SetIntAt(buffer, 62, HE.HK04.ToleranzPlus);
                S7.SetIntAt(buffer, 64, HE.HK04.ToleranzMinus);
                S7.SetIntAt(buffer, 66, HE.HK04.TempTaktung);
                S7.SetIntAt(buffer, 68, HE.HK04.Impulsdauer);
                S7.SetIntAt(buffer, 70, HE.HK04.Pausendauer);
                S7.SetIntAt(buffer, 72, HE.HK04.OffsetAT);
                S7.SetIntAt(buffer, 74, HE.HK04.PiAT);
                S7.SetIntAt(buffer, 76, HE.HK04.TMaxAT);
                S7.SetBitAt(ref buffer, 78, 0, HE.HK04.Aktiv);
                S7.SetIntAt(buffer, 80, HE.HK05.TempSoll);
                S7.SetIntAt(buffer, 82, HE.HK05.ToleranzPlus);
                S7.SetIntAt(buffer, 84, HE.HK05.ToleranzMinus);
                S7.SetIntAt(buffer, 86, HE.HK05.TempTaktung);
                S7.SetIntAt(buffer, 88, HE.HK05.Impulsdauer);
                S7.SetIntAt(buffer, 90, HE.HK05.Pausendauer);
                S7.SetIntAt(buffer, 92, HE.HK05.OffsetAT);
                S7.SetIntAt(buffer, 94, HE.HK05.PiAT);
                S7.SetIntAt(buffer, 96, HE.HK05.TMaxAT);
                S7.SetBitAt(ref buffer, 98, 0, HE.HK05.Aktiv);
                S7.SetIntAt(buffer, 100, HE.HK06.TempSoll);
                S7.SetIntAt(buffer, 102, HE.HK06.ToleranzPlus);
                S7.SetIntAt(buffer, 104, HE.HK06.ToleranzMinus);
                S7.SetIntAt(buffer, 106, HE.HK06.TempTaktung);
                S7.SetIntAt(buffer, 108, HE.HK06.Impulsdauer);
                S7.SetIntAt(buffer, 110, HE.HK06.Pausendauer);
                S7.SetIntAt(buffer, 112, HE.HK06.OffsetAT);
                S7.SetIntAt(buffer, 114, HE.HK06.PiAT);
                S7.SetIntAt(buffer, 116, HE.HK06.TMaxAT);
                S7.SetBitAt(ref buffer, 118, 0, HE.HK06.Aktiv);
                S7.SetIntAt(buffer, 120, HE.HK07.TempSoll);
                S7.SetIntAt(buffer, 122, HE.HK07.ToleranzPlus);
                S7.SetIntAt(buffer, 124, HE.HK07.ToleranzMinus);
                S7.SetIntAt(buffer, 126, HE.HK07.TempTaktung);
                S7.SetIntAt(buffer, 128, HE.HK07.Impulsdauer);
                S7.SetIntAt(buffer, 130, HE.HK07.Pausendauer);
                S7.SetIntAt(buffer, 132, HE.HK07.OffsetAT);
                S7.SetIntAt(buffer, 134, HE.HK07.PiAT);
                S7.SetIntAt(buffer, 136, HE.HK07.TMaxAT);
                S7.SetBitAt(ref buffer, 138, 0, HE.HK07.Aktiv);
                S7.SetIntAt(buffer, 140, HE.HK08.TempSoll);
                S7.SetIntAt(buffer, 142, HE.HK08.ToleranzPlus);
                S7.SetIntAt(buffer, 144, HE.HK08.ToleranzMinus);
                S7.SetIntAt(buffer, 146, HE.HK08.TempTaktung);
                S7.SetIntAt(buffer, 148, HE.HK08.Impulsdauer);
                S7.SetIntAt(buffer, 150, HE.HK08.Pausendauer);
                S7.SetIntAt(buffer, 152, HE.HK08.OffsetAT);
                S7.SetIntAt(buffer, 154, HE.HK08.PiAT);
                S7.SetIntAt(buffer, 156, HE.HK08.TMaxAT);
                S7.SetBitAt(ref buffer, 158, 0, HE.HK08.Aktiv);
                S7.SetIntAt(buffer, 160, HE.HK09.TempSoll);
                S7.SetIntAt(buffer, 162, HE.HK09.ToleranzPlus);
                S7.SetIntAt(buffer, 164, HE.HK09.ToleranzMinus);
                S7.SetIntAt(buffer, 166, HE.HK09.TempTaktung);
                S7.SetIntAt(buffer, 168, HE.HK09.Impulsdauer);
                S7.SetIntAt(buffer, 170, HE.HK09.Pausendauer);
                S7.SetIntAt(buffer, 172, HE.HK09.OffsetAT);
                S7.SetIntAt(buffer, 174, HE.HK09.PiAT);
                S7.SetIntAt(buffer, 176, HE.HK09.TMaxAT);
                S7.SetBitAt(ref buffer, 178, 0, HE.HK09.Aktiv);
                S7.SetIntAt(buffer, 180, HE.HK10.TempSoll);
                S7.SetIntAt(buffer, 182, HE.HK10.ToleranzPlus);
                S7.SetIntAt(buffer, 184, HE.HK10.ToleranzMinus);
                S7.SetIntAt(buffer, 186, HE.HK10.TempTaktung);
                S7.SetIntAt(buffer, 188, HE.HK10.Impulsdauer);
                S7.SetIntAt(buffer, 190, HE.HK10.Pausendauer);
                S7.SetIntAt(buffer, 192, HE.HK10.OffsetAT);
                S7.SetIntAt(buffer, 194, HE.HK10.PiAT);
                S7.SetIntAt(buffer, 196, HE.HK10.TMaxAT);
                S7.SetBitAt(ref buffer, 198, 0, HE.HK10.Aktiv);
                S7.SetIntAt(buffer, 200, HE.HK11.TempSoll);
                S7.SetIntAt(buffer, 202, HE.HK11.ToleranzPlus);
                S7.SetIntAt(buffer, 204, HE.HK11.ToleranzMinus);
                S7.SetIntAt(buffer, 206, HE.HK11.TempTaktung);
                S7.SetIntAt(buffer, 208, HE.HK11.Impulsdauer);
                S7.SetIntAt(buffer, 210, HE.HK11.Pausendauer);
                S7.SetIntAt(buffer, 212, HE.HK11.OffsetAT);
                S7.SetIntAt(buffer, 214, HE.HK11.PiAT);
                S7.SetIntAt(buffer, 216, HE.HK11.TMaxAT);
                S7.SetBitAt(ref buffer, 218, 0, HE.HK11.Aktiv);
                S7.SetIntAt(buffer, 220, HE.HK12.TempSoll);
                S7.SetIntAt(buffer, 222, HE.HK12.ToleranzPlus);
                S7.SetIntAt(buffer, 224, HE.HK12.ToleranzMinus);
                S7.SetIntAt(buffer, 226, HE.HK12.TempTaktung);
                S7.SetIntAt(buffer, 228, HE.HK12.Impulsdauer);
                S7.SetIntAt(buffer, 230, HE.HK12.Pausendauer);
                S7.SetIntAt(buffer, 232, HE.HK12.OffsetAT);
                S7.SetIntAt(buffer, 234, HE.HK12.PiAT);
                S7.SetIntAt(buffer, 236, HE.HK12.TMaxAT);
                S7.SetBitAt(ref buffer, 238, 0, HE.HK12.Aktiv);
                S7.SetIntAt(buffer, 240, HE.HK13.TempSoll);
                S7.SetIntAt(buffer, 242, HE.HK13.ToleranzPlus);
                S7.SetIntAt(buffer, 244, HE.HK13.ToleranzMinus);
                S7.SetIntAt(buffer, 246, HE.HK13.TempTaktung);
                S7.SetIntAt(buffer, 248, HE.HK13.Impulsdauer);
                S7.SetIntAt(buffer, 250, HE.HK13.Pausendauer);
                S7.SetIntAt(buffer, 252, HE.HK13.OffsetAT);
                S7.SetIntAt(buffer, 254, HE.HK13.PiAT);
                S7.SetIntAt(buffer, 256, HE.HK13.TMaxAT);
                S7.SetBitAt(ref buffer, 258, 0, HE.HK13.Aktiv);
                S7.SetIntAt(buffer, 260, HE.HK14.TempSoll);
                S7.SetIntAt(buffer, 262, HE.HK14.ToleranzPlus);
                S7.SetIntAt(buffer, 264, HE.HK14.ToleranzMinus);
                S7.SetIntAt(buffer, 266, HE.HK14.TempTaktung);
                S7.SetIntAt(buffer, 268, HE.HK14.Impulsdauer);
                S7.SetIntAt(buffer, 270, HE.HK14.Pausendauer);
                S7.SetIntAt(buffer, 272, HE.HK14.OffsetAT);
                S7.SetIntAt(buffer, 274, HE.HK14.PiAT);
                S7.SetIntAt(buffer, 276, HE.HK14.TMaxAT);
                S7.SetBitAt(ref buffer, 278, 0, HE.HK14.Aktiv);
                S7.SetIntAt(buffer, 280, HE.HK15.TempSoll);
                S7.SetIntAt(buffer, 282, HE.HK15.ToleranzPlus);
                S7.SetIntAt(buffer, 284, HE.HK15.ToleranzMinus);
                S7.SetIntAt(buffer, 286, HE.HK15.TempTaktung);
                S7.SetIntAt(buffer, 288, HE.HK15.Impulsdauer);
                S7.SetIntAt(buffer, 290, HE.HK15.Pausendauer);
                S7.SetIntAt(buffer, 292, HE.HK15.OffsetAT);
                S7.SetIntAt(buffer, 294, HE.HK15.PiAT);
                S7.SetIntAt(buffer, 296, HE.HK15.TMaxAT);
                S7.SetBitAt(ref buffer, 298, 0, HE.HK15.Aktiv);
                S7.SetIntAt(buffer, 300, HE.HK16.TempSoll);
                S7.SetIntAt(buffer, 302, HE.HK16.ToleranzPlus);
                S7.SetIntAt(buffer, 304, HE.HK16.ToleranzMinus);
                S7.SetIntAt(buffer, 306, HE.HK16.TempTaktung);
                S7.SetIntAt(buffer, 308, HE.HK16.Impulsdauer);
                S7.SetIntAt(buffer, 310, HE.HK16.Pausendauer);
                S7.SetIntAt(buffer, 312, HE.HK16.OffsetAT);
                S7.SetIntAt(buffer, 314, HE.HK16.PiAT);
                S7.SetIntAt(buffer, 316, HE.HK16.TMaxAT);
                S7.SetBitAt(ref buffer, 318, 0, HE.HK16.Aktiv);
                S7.SetIntAt(buffer, 320, HE.HK17.TempSoll);
                S7.SetIntAt(buffer, 322, HE.HK17.ToleranzPlus);
                S7.SetIntAt(buffer, 324, HE.HK17.ToleranzMinus);
                S7.SetIntAt(buffer, 326, HE.HK17.TempTaktung);
                S7.SetIntAt(buffer, 328, HE.HK17.Impulsdauer);
                S7.SetIntAt(buffer, 330, HE.HK17.Pausendauer);
                S7.SetIntAt(buffer, 332, HE.HK17.OffsetAT);
                S7.SetIntAt(buffer, 334, HE.HK17.PiAT);
                S7.SetIntAt(buffer, 336, HE.HK17.TMaxAT);
                S7.SetBitAt(ref buffer, 338, 0, HE.HK17.Aktiv);
                S7.SetIntAt(buffer, 340, HE.HK18.TempSoll);
                S7.SetIntAt(buffer, 342, HE.HK18.ToleranzPlus);
                S7.SetIntAt(buffer, 344, HE.HK18.ToleranzMinus);
                S7.SetIntAt(buffer, 346, HE.HK18.TempTaktung);
                S7.SetIntAt(buffer, 348, HE.HK18.Impulsdauer);
                S7.SetIntAt(buffer, 350, HE.HK18.Pausendauer);
                S7.SetIntAt(buffer, 352, HE.HK18.OffsetAT);
                S7.SetIntAt(buffer, 354, HE.HK18.PiAT);
                S7.SetIntAt(buffer, 356, HE.HK18.TMaxAT);
                S7.SetBitAt(ref buffer, 358, 0, HE.HK18.Aktiv);
                S7.SetIntAt(buffer, 360, HE.HK19.TempSoll);
                S7.SetIntAt(buffer, 362, HE.HK19.ToleranzPlus);
                S7.SetIntAt(buffer, 364, HE.HK19.ToleranzMinus);
                S7.SetIntAt(buffer, 366, HE.HK19.TempTaktung);
                S7.SetIntAt(buffer, 368, HE.HK19.Impulsdauer);
                S7.SetIntAt(buffer, 370, HE.HK19.Pausendauer);
                S7.SetIntAt(buffer, 372, HE.HK19.OffsetAT);
                S7.SetIntAt(buffer, 374, HE.HK19.PiAT);
                S7.SetIntAt(buffer, 376, HE.HK19.TMaxAT);
                S7.SetBitAt(ref buffer, 378, 0, HE.HK19.Aktiv);
                S7.SetIntAt(buffer, 380, HE.HK20.TempSoll);
                S7.SetIntAt(buffer, 382, HE.HK20.ToleranzPlus);
                S7.SetIntAt(buffer, 384, HE.HK20.ToleranzMinus);
                S7.SetIntAt(buffer, 386, HE.HK20.TempTaktung);
                S7.SetIntAt(buffer, 388, HE.HK20.Impulsdauer);
                S7.SetIntAt(buffer, 390, HE.HK20.Pausendauer);
                S7.SetIntAt(buffer, 392, HE.HK20.OffsetAT);
                S7.SetIntAt(buffer, 394, HE.HK20.PiAT);
                S7.SetIntAt(buffer, 396, HE.HK20.TMaxAT);
                S7.SetBitAt(ref buffer, 398, 0, HE.HK20.Aktiv);
                S7.SetIntAt(buffer, 400, HE.HK21.TempSoll);
                S7.SetIntAt(buffer, 402, HE.HK21.ToleranzPlus);
                S7.SetIntAt(buffer, 404, HE.HK21.ToleranzMinus);
                S7.SetIntAt(buffer, 406, HE.HK21.TempTaktung);
                S7.SetIntAt(buffer, 408, HE.HK21.Impulsdauer);
                S7.SetIntAt(buffer, 410, HE.HK21.Pausendauer);
                S7.SetIntAt(buffer, 412, HE.HK21.OffsetAT);
                S7.SetIntAt(buffer, 414, HE.HK21.PiAT);
                S7.SetIntAt(buffer, 416, HE.HK21.TMaxAT);
                S7.SetBitAt(ref buffer, 418, 0, HE.HK21.Aktiv);
                S7.SetIntAt(buffer, 420, HE.HK22.TempSoll);
                S7.SetIntAt(buffer, 422, HE.HK22.ToleranzPlus);
                S7.SetIntAt(buffer, 424, HE.HK22.ToleranzMinus);
                S7.SetIntAt(buffer, 426, HE.HK22.TempTaktung);
                S7.SetIntAt(buffer, 428, HE.HK22.Impulsdauer);
                S7.SetIntAt(buffer, 430, HE.HK22.Pausendauer);
                S7.SetIntAt(buffer, 432, HE.HK22.OffsetAT);
                S7.SetIntAt(buffer, 434, HE.HK22.PiAT);
                S7.SetIntAt(buffer, 436, HE.HK22.TMaxAT);
                S7.SetBitAt(ref buffer, 438, 0, HE.HK22.Aktiv);
                S7.SetIntAt(buffer, 440, HE.HK23.TempSoll);
                S7.SetIntAt(buffer, 442, HE.HK23.ToleranzPlus);
                S7.SetIntAt(buffer, 444, HE.HK23.ToleranzMinus);
                S7.SetIntAt(buffer, 446, HE.HK23.TempTaktung);
                S7.SetIntAt(buffer, 448, HE.HK23.Impulsdauer);
                S7.SetIntAt(buffer, 450, HE.HK23.Pausendauer);
                S7.SetIntAt(buffer, 452, HE.HK23.OffsetAT);
                S7.SetIntAt(buffer, 454, HE.HK23.PiAT);
                S7.SetIntAt(buffer, 456, HE.HK23.TMaxAT);
                S7.SetBitAt(ref buffer, 458, 0, HE.HK23.Aktiv);
                S7.SetIntAt(buffer, 460, HE.HK24.TempSoll);
                S7.SetIntAt(buffer, 462, HE.HK24.ToleranzPlus);
                S7.SetIntAt(buffer, 464, HE.HK24.ToleranzMinus);
                S7.SetIntAt(buffer, 466, HE.HK24.TempTaktung);
                S7.SetIntAt(buffer, 468, HE.HK24.Impulsdauer);
                S7.SetIntAt(buffer, 470, HE.HK24.Pausendauer);
                S7.SetIntAt(buffer, 472, HE.HK24.OffsetAT);
                S7.SetIntAt(buffer, 474, HE.HK24.PiAT);
                S7.SetIntAt(buffer, 476, HE.HK24.TMaxAT);
                S7.SetBitAt(ref buffer, 478, 0, HE.HK24.Aktiv);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
                //throw;
            }
        }
        public static DatHE BufferToDatHE(byte[] buffer, ref string error)
        {
            error = string.Empty;
            //create instance
            DatHE HE = new DatHE();

            try
            {
                HE.HK01.TempSoll = S7.GetIntAt(buffer, 0);
                HE.HK01.ToleranzPlus = S7.GetIntAt(buffer, 2);
                HE.HK01.ToleranzMinus = S7.GetIntAt(buffer, 4);
                HE.HK01.TempTaktung = S7.GetIntAt(buffer, 6);
                HE.HK01.Impulsdauer = S7.GetIntAt(buffer, 8);
                HE.HK01.Pausendauer = S7.GetIntAt(buffer, 10);
                HE.HK01.OffsetAT = S7.GetIntAt(buffer, 12);
                HE.HK01.PiAT = S7.GetIntAt(buffer, 14);
                HE.HK01.TMaxAT = S7.GetIntAt(buffer, 16);
                HE.HK01.Aktiv = S7.GetBitAt(buffer, 18, 0);
                HE.HK02.TempSoll = S7.GetIntAt(buffer, 20);
                HE.HK02.ToleranzPlus = S7.GetIntAt(buffer, 22);
                HE.HK02.ToleranzMinus = S7.GetIntAt(buffer, 24);
                HE.HK02.TempTaktung = S7.GetIntAt(buffer, 26);
                HE.HK02.Impulsdauer = S7.GetIntAt(buffer, 28);
                HE.HK02.Pausendauer = S7.GetIntAt(buffer, 30);
                HE.HK02.OffsetAT = S7.GetIntAt(buffer, 32);
                HE.HK02.PiAT = S7.GetIntAt(buffer, 34);
                HE.HK02.TMaxAT = S7.GetIntAt(buffer, 36);
                HE.HK02.Aktiv = S7.GetBitAt(buffer, 38, 0);
                HE.HK03.TempSoll = S7.GetIntAt(buffer, 40);
                HE.HK03.ToleranzPlus = S7.GetIntAt(buffer, 42);
                HE.HK03.ToleranzMinus = S7.GetIntAt(buffer, 44);
                HE.HK03.TempTaktung = S7.GetIntAt(buffer, 46);
                HE.HK03.Impulsdauer = S7.GetIntAt(buffer, 48);
                HE.HK03.Pausendauer = S7.GetIntAt(buffer, 50);
                HE.HK03.OffsetAT = S7.GetIntAt(buffer, 52);
                HE.HK03.PiAT = S7.GetIntAt(buffer, 54);
                HE.HK03.TMaxAT = S7.GetIntAt(buffer, 56);
                HE.HK03.Aktiv = S7.GetBitAt(buffer, 58, 0);
                HE.HK04.TempSoll = S7.GetIntAt(buffer, 60);
                HE.HK04.ToleranzPlus = S7.GetIntAt(buffer, 62);
                HE.HK04.ToleranzMinus = S7.GetIntAt(buffer, 64);
                HE.HK04.TempTaktung = S7.GetIntAt(buffer, 66);
                HE.HK04.Impulsdauer = S7.GetIntAt(buffer, 68);
                HE.HK04.Pausendauer = S7.GetIntAt(buffer, 70);
                HE.HK04.OffsetAT = S7.GetIntAt(buffer, 72);
                HE.HK04.PiAT = S7.GetIntAt(buffer, 74);
                HE.HK04.TMaxAT = S7.GetIntAt(buffer, 76);
                HE.HK04.Aktiv = S7.GetBitAt(buffer, 78, 0);
                HE.HK05.TempSoll = S7.GetIntAt(buffer, 80);
                HE.HK05.ToleranzPlus = S7.GetIntAt(buffer, 82);
                HE.HK05.ToleranzMinus = S7.GetIntAt(buffer, 84);
                HE.HK05.TempTaktung = S7.GetIntAt(buffer, 86);
                HE.HK05.Impulsdauer = S7.GetIntAt(buffer, 88);
                HE.HK05.Pausendauer = S7.GetIntAt(buffer, 90);
                HE.HK05.OffsetAT = S7.GetIntAt(buffer, 92);
                HE.HK05.PiAT = S7.GetIntAt(buffer, 94);
                HE.HK05.TMaxAT = S7.GetIntAt(buffer, 96);
                HE.HK05.Aktiv = S7.GetBitAt(buffer, 98, 0);
                HE.HK06.TempSoll = S7.GetIntAt(buffer, 100);
                HE.HK06.ToleranzPlus = S7.GetIntAt(buffer, 102);
                HE.HK06.ToleranzMinus = S7.GetIntAt(buffer, 104);
                HE.HK06.TempTaktung = S7.GetIntAt(buffer, 106);
                HE.HK06.Impulsdauer = S7.GetIntAt(buffer, 108);
                HE.HK06.Pausendauer = S7.GetIntAt(buffer, 110);
                HE.HK06.OffsetAT = S7.GetIntAt(buffer, 112);
                HE.HK06.PiAT = S7.GetIntAt(buffer, 114);
                HE.HK06.TMaxAT = S7.GetIntAt(buffer, 116);
                HE.HK06.Aktiv = S7.GetBitAt(buffer, 118, 0);
                HE.HK07.TempSoll = S7.GetIntAt(buffer, 120);
                HE.HK07.ToleranzPlus = S7.GetIntAt(buffer, 122);
                HE.HK07.ToleranzMinus = S7.GetIntAt(buffer, 124);
                HE.HK07.TempTaktung = S7.GetIntAt(buffer, 126);
                HE.HK07.Impulsdauer = S7.GetIntAt(buffer, 128);
                HE.HK07.Pausendauer = S7.GetIntAt(buffer, 130);
                HE.HK07.OffsetAT = S7.GetIntAt(buffer, 132);
                HE.HK07.PiAT = S7.GetIntAt(buffer, 134);
                HE.HK07.TMaxAT = S7.GetIntAt(buffer, 136);
                HE.HK07.Aktiv = S7.GetBitAt(buffer, 138, 0);
                HE.HK08.TempSoll = S7.GetIntAt(buffer, 140);
                HE.HK08.ToleranzPlus = S7.GetIntAt(buffer, 142);
                HE.HK08.ToleranzMinus = S7.GetIntAt(buffer, 144);
                HE.HK08.TempTaktung = S7.GetIntAt(buffer, 146);
                HE.HK08.Impulsdauer = S7.GetIntAt(buffer, 148);
                HE.HK08.Pausendauer = S7.GetIntAt(buffer, 150);
                HE.HK08.OffsetAT = S7.GetIntAt(buffer, 152);
                HE.HK08.PiAT = S7.GetIntAt(buffer, 154);
                HE.HK08.TMaxAT = S7.GetIntAt(buffer, 156);
                HE.HK08.Aktiv = S7.GetBitAt(buffer, 158, 0);
                HE.HK09.TempSoll = S7.GetIntAt(buffer, 160);
                HE.HK09.ToleranzPlus = S7.GetIntAt(buffer, 162);
                HE.HK09.ToleranzMinus = S7.GetIntAt(buffer, 164);
                HE.HK09.TempTaktung = S7.GetIntAt(buffer, 166);
                HE.HK09.Impulsdauer = S7.GetIntAt(buffer, 168);
                HE.HK09.Pausendauer = S7.GetIntAt(buffer, 170);
                HE.HK09.OffsetAT = S7.GetIntAt(buffer, 172);
                HE.HK09.PiAT = S7.GetIntAt(buffer, 174);
                HE.HK09.TMaxAT = S7.GetIntAt(buffer, 176);
                HE.HK09.Aktiv = S7.GetBitAt(buffer, 178, 0);
                HE.HK10.TempSoll = S7.GetIntAt(buffer, 180);
                HE.HK10.ToleranzPlus = S7.GetIntAt(buffer, 182);
                HE.HK10.ToleranzMinus = S7.GetIntAt(buffer, 184);
                HE.HK10.TempTaktung = S7.GetIntAt(buffer, 186);
                HE.HK10.Impulsdauer = S7.GetIntAt(buffer, 188);
                HE.HK10.Pausendauer = S7.GetIntAt(buffer, 190);
                HE.HK10.OffsetAT = S7.GetIntAt(buffer, 192);
                HE.HK10.PiAT = S7.GetIntAt(buffer, 194);
                HE.HK10.TMaxAT = S7.GetIntAt(buffer, 196);
                HE.HK10.Aktiv = S7.GetBitAt(buffer, 198, 0);
                HE.HK11.TempSoll = S7.GetIntAt(buffer, 200);
                HE.HK11.ToleranzPlus = S7.GetIntAt(buffer, 202);
                HE.HK11.ToleranzMinus = S7.GetIntAt(buffer, 204);
                HE.HK11.TempTaktung = S7.GetIntAt(buffer, 206);
                HE.HK11.Impulsdauer = S7.GetIntAt(buffer, 208);
                HE.HK11.Pausendauer = S7.GetIntAt(buffer, 210);
                HE.HK11.OffsetAT = S7.GetIntAt(buffer, 212);
                HE.HK11.PiAT = S7.GetIntAt(buffer, 214);
                HE.HK11.TMaxAT = S7.GetIntAt(buffer, 216);
                HE.HK11.Aktiv = S7.GetBitAt(buffer, 218, 0);
                HE.HK12.TempSoll = S7.GetIntAt(buffer, 220);
                HE.HK12.ToleranzPlus = S7.GetIntAt(buffer, 222);
                HE.HK12.ToleranzMinus = S7.GetIntAt(buffer, 224);
                HE.HK12.TempTaktung = S7.GetIntAt(buffer, 226);
                HE.HK12.Impulsdauer = S7.GetIntAt(buffer, 228);
                HE.HK12.Pausendauer = S7.GetIntAt(buffer, 230);
                HE.HK12.OffsetAT = S7.GetIntAt(buffer, 232);
                HE.HK12.PiAT = S7.GetIntAt(buffer, 234);
                HE.HK12.TMaxAT = S7.GetIntAt(buffer, 236);
                HE.HK12.Aktiv = S7.GetBitAt(buffer, 238, 0);
                HE.HK13.TempSoll = S7.GetIntAt(buffer, 240);
                HE.HK13.ToleranzPlus = S7.GetIntAt(buffer, 242);
                HE.HK13.ToleranzMinus = S7.GetIntAt(buffer, 244);
                HE.HK13.TempTaktung = S7.GetIntAt(buffer, 246);
                HE.HK13.Impulsdauer = S7.GetIntAt(buffer, 248);
                HE.HK13.Pausendauer = S7.GetIntAt(buffer, 250);
                HE.HK13.OffsetAT = S7.GetIntAt(buffer, 252);
                HE.HK13.PiAT = S7.GetIntAt(buffer, 254);
                HE.HK13.TMaxAT = S7.GetIntAt(buffer, 256);
                HE.HK13.Aktiv = S7.GetBitAt(buffer, 258, 0);
                HE.HK14.TempSoll = S7.GetIntAt(buffer, 260);
                HE.HK14.ToleranzPlus = S7.GetIntAt(buffer, 262);
                HE.HK14.ToleranzMinus = S7.GetIntAt(buffer, 264);
                HE.HK14.TempTaktung = S7.GetIntAt(buffer, 266);
                HE.HK14.Impulsdauer = S7.GetIntAt(buffer, 268);
                HE.HK14.Pausendauer = S7.GetIntAt(buffer, 270);
                HE.HK14.OffsetAT = S7.GetIntAt(buffer, 272);
                HE.HK14.PiAT = S7.GetIntAt(buffer, 274);
                HE.HK14.TMaxAT = S7.GetIntAt(buffer, 276);
                HE.HK14.Aktiv = S7.GetBitAt(buffer, 278, 0);
                HE.HK15.TempSoll = S7.GetIntAt(buffer, 280);
                HE.HK15.ToleranzPlus = S7.GetIntAt(buffer, 282);
                HE.HK15.ToleranzMinus = S7.GetIntAt(buffer, 284);
                HE.HK15.TempTaktung = S7.GetIntAt(buffer, 286);
                HE.HK15.Impulsdauer = S7.GetIntAt(buffer, 288);
                HE.HK15.Pausendauer = S7.GetIntAt(buffer, 290);
                HE.HK15.OffsetAT = S7.GetIntAt(buffer, 292);
                HE.HK15.PiAT = S7.GetIntAt(buffer, 294);
                HE.HK15.TMaxAT = S7.GetIntAt(buffer, 296);
                HE.HK15.Aktiv = S7.GetBitAt(buffer, 298, 0);
                HE.HK16.TempSoll = S7.GetIntAt(buffer, 300);
                HE.HK16.ToleranzPlus = S7.GetIntAt(buffer, 302);
                HE.HK16.ToleranzMinus = S7.GetIntAt(buffer, 304);
                HE.HK16.TempTaktung = S7.GetIntAt(buffer, 306);
                HE.HK16.Impulsdauer = S7.GetIntAt(buffer, 308);
                HE.HK16.Pausendauer = S7.GetIntAt(buffer, 310);
                HE.HK16.OffsetAT = S7.GetIntAt(buffer, 312);
                HE.HK16.PiAT = S7.GetIntAt(buffer, 314);
                HE.HK16.TMaxAT = S7.GetIntAt(buffer, 316);
                HE.HK16.Aktiv = S7.GetBitAt(buffer, 318, 0);
                HE.HK17.TempSoll = S7.GetIntAt(buffer, 320);
                HE.HK17.ToleranzPlus = S7.GetIntAt(buffer, 322);
                HE.HK17.ToleranzMinus = S7.GetIntAt(buffer, 324);
                HE.HK17.TempTaktung = S7.GetIntAt(buffer, 326);
                HE.HK17.Impulsdauer = S7.GetIntAt(buffer, 328);
                HE.HK17.Pausendauer = S7.GetIntAt(buffer, 330);
                HE.HK17.OffsetAT = S7.GetIntAt(buffer, 332);
                HE.HK17.PiAT = S7.GetIntAt(buffer, 334);
                HE.HK17.TMaxAT = S7.GetIntAt(buffer, 336);
                HE.HK17.Aktiv = S7.GetBitAt(buffer, 338, 0);
                HE.HK18.TempSoll = S7.GetIntAt(buffer, 340);
                HE.HK18.ToleranzPlus = S7.GetIntAt(buffer, 342);
                HE.HK18.ToleranzMinus = S7.GetIntAt(buffer, 344);
                HE.HK18.TempTaktung = S7.GetIntAt(buffer, 346);
                HE.HK18.Impulsdauer = S7.GetIntAt(buffer, 348);
                HE.HK18.Pausendauer = S7.GetIntAt(buffer, 350);
                HE.HK18.OffsetAT = S7.GetIntAt(buffer, 352);
                HE.HK18.PiAT = S7.GetIntAt(buffer, 354);
                HE.HK18.TMaxAT = S7.GetIntAt(buffer, 356);
                HE.HK18.Aktiv = S7.GetBitAt(buffer, 358, 0);
                HE.HK19.TempSoll = S7.GetIntAt(buffer, 360);
                HE.HK19.ToleranzPlus = S7.GetIntAt(buffer, 362);
                HE.HK19.ToleranzMinus = S7.GetIntAt(buffer, 364);
                HE.HK19.TempTaktung = S7.GetIntAt(buffer, 366);
                HE.HK19.Impulsdauer = S7.GetIntAt(buffer, 368);
                HE.HK19.Pausendauer = S7.GetIntAt(buffer, 370);
                HE.HK19.OffsetAT = S7.GetIntAt(buffer, 372);
                HE.HK19.PiAT = S7.GetIntAt(buffer, 374);
                HE.HK19.TMaxAT = S7.GetIntAt(buffer, 376);
                HE.HK19.Aktiv = S7.GetBitAt(buffer, 378, 0);
                HE.HK20.TempSoll = S7.GetIntAt(buffer, 380);
                HE.HK20.ToleranzPlus = S7.GetIntAt(buffer, 382);
                HE.HK20.ToleranzMinus = S7.GetIntAt(buffer, 384);
                HE.HK20.TempTaktung = S7.GetIntAt(buffer, 386);
                HE.HK20.Impulsdauer = S7.GetIntAt(buffer, 388);
                HE.HK20.Pausendauer = S7.GetIntAt(buffer, 390);
                HE.HK20.OffsetAT = S7.GetIntAt(buffer, 392);
                HE.HK20.PiAT = S7.GetIntAt(buffer, 394);
                HE.HK20.TMaxAT = S7.GetIntAt(buffer, 396);
                HE.HK20.Aktiv = S7.GetBitAt(buffer, 398, 0);
                HE.HK21.TempSoll = S7.GetIntAt(buffer, 400);
                HE.HK21.ToleranzPlus = S7.GetIntAt(buffer, 402);
                HE.HK21.ToleranzMinus = S7.GetIntAt(buffer, 404);
                HE.HK21.TempTaktung = S7.GetIntAt(buffer, 406);
                HE.HK21.Impulsdauer = S7.GetIntAt(buffer, 408);
                HE.HK21.Pausendauer = S7.GetIntAt(buffer, 410);
                HE.HK21.OffsetAT = S7.GetIntAt(buffer, 412);
                HE.HK21.PiAT = S7.GetIntAt(buffer, 414);
                HE.HK21.TMaxAT = S7.GetIntAt(buffer, 416);
                HE.HK21.Aktiv = S7.GetBitAt(buffer, 418, 0);
                HE.HK22.TempSoll = S7.GetIntAt(buffer, 420);
                HE.HK22.ToleranzPlus = S7.GetIntAt(buffer, 422);
                HE.HK22.ToleranzMinus = S7.GetIntAt(buffer, 424);
                HE.HK22.TempTaktung = S7.GetIntAt(buffer, 426);
                HE.HK22.Impulsdauer = S7.GetIntAt(buffer, 428);
                HE.HK22.Pausendauer = S7.GetIntAt(buffer, 430);
                HE.HK22.OffsetAT = S7.GetIntAt(buffer, 432);
                HE.HK22.PiAT = S7.GetIntAt(buffer, 434);
                HE.HK22.TMaxAT = S7.GetIntAt(buffer, 436);
                HE.HK22.Aktiv = S7.GetBitAt(buffer, 438, 0);
                HE.HK23.TempSoll = S7.GetIntAt(buffer, 440);
                HE.HK23.ToleranzPlus = S7.GetIntAt(buffer, 442);
                HE.HK23.ToleranzMinus = S7.GetIntAt(buffer, 444);
                HE.HK23.TempTaktung = S7.GetIntAt(buffer, 446);
                HE.HK23.Impulsdauer = S7.GetIntAt(buffer, 448);
                HE.HK23.Pausendauer = S7.GetIntAt(buffer, 450);
                HE.HK23.OffsetAT = S7.GetIntAt(buffer, 452);
                HE.HK23.PiAT = S7.GetIntAt(buffer, 454);
                HE.HK23.TMaxAT = S7.GetIntAt(buffer, 456);
                HE.HK23.Aktiv = S7.GetBitAt(buffer, 458, 0);
                HE.HK24.TempSoll = S7.GetIntAt(buffer, 460);
                HE.HK24.ToleranzPlus = S7.GetIntAt(buffer, 462);
                HE.HK24.ToleranzMinus = S7.GetIntAt(buffer, 464);
                HE.HK24.TempTaktung = S7.GetIntAt(buffer, 466);
                HE.HK24.Impulsdauer = S7.GetIntAt(buffer, 468);
                HE.HK24.Pausendauer = S7.GetIntAt(buffer, 470);
                HE.HK24.OffsetAT = S7.GetIntAt(buffer, 472);
                HE.HK24.PiAT = S7.GetIntAt(buffer, 474);
                HE.HK24.TMaxAT = S7.GetIntAt(buffer, 476);
                HE.HK24.Aktiv = S7.GetBitAt(buffer, 478, 0);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
                //throw;
            }

            return HE;
        }
        public static void SerializeDatHE(DatHE HE, string path, ref string error)
        {
            error = string.Empty;
            //create instance
            //DatHE HE = new DatHE();
            try
            {
                // XmlSerializer writes object data as XML
                XmlSerializer serializer = new XmlSerializer(typeof(DatHE));
                using (TextWriter writer = new StreamWriter(path + "\\HE.xml"))
                {
                    serializer.Serialize(writer, HE);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString() + " " + path + "\\HE.xml";
                //throw;
            }
            //return value
            //return HE;
        }
        public static DatHE DeserializeDatHE(string path, ref string error)
        {
            //create instance
            DatHE HE = new DatHE();
            try
            {
                // Deserialize from XML to the object
                XmlSerializer deserializer = new XmlSerializer(typeof(DatHE));
                TextReader reader = new StreamReader(path + "\\HE.xml");
                object obj = deserializer.Deserialize(reader);
                HE = (DatHE)obj;
                reader.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString() + " " + path + "\\HE.xml";
                //throw;
            }
            //return value
            return HE;
        }
        #endregion



        #region DatConfig
        public static void DatConfigToBuffer(DatConfig Config, byte[] buffer, ref string error)
        {
            try
            {
                //clear buffer before use
                Array.Clear(buffer, 0, buffer.Length);

                S7.SetIntAt(buffer, 0, Config.GS.OB.E_01_16);
                S7.SetIntAt(buffer, 2, Config.GS.OB.E_17_32);
                S7.SetIntAt(buffer, 4, Config.GS.OB.E_Vakuum);
                S7.SetIntAt(buffer, 6, Config.GS.OB.A_Vakuum);
                S7.SetIntAt(buffer, 8, Config.GS.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 10, Config.GS.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 12, Config.GS.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 14, Config.GS.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 16, Config.GS.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 18, Config.GS.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 20, Config.GS.UN.E_01_16);
                S7.SetIntAt(buffer, 22, Config.GS.UN.E_17_32);
                S7.SetIntAt(buffer, 24, Config.GS.UN.E_Vakuum);
                S7.SetIntAt(buffer, 26, Config.GS.UN.A_Vakuum);
                S7.SetIntAt(buffer, 28, Config.GS.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 30, Config.GS.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 32, Config.GS.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 34, Config.GS.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 36, Config.GS.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 38, Config.GS.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 40, Config.ZYA.OB.E_01_16);
                S7.SetIntAt(buffer, 42, Config.ZYA.OB.E_17_32);
                S7.SetIntAt(buffer, 44, Config.ZYA.OB.E_Vakuum);
                S7.SetIntAt(buffer, 46, Config.ZYA.OB.A_Vakuum);
                S7.SetIntAt(buffer, 48, Config.ZYA.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 50, Config.ZYA.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 52, Config.ZYA.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 54, Config.ZYA.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 56, Config.ZYA.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 58, Config.ZYA.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 60, Config.ZYA.UN.E_01_16);
                S7.SetIntAt(buffer, 62, Config.ZYA.UN.E_17_32);
                S7.SetIntAt(buffer, 64, Config.ZYA.UN.E_Vakuum);
                S7.SetIntAt(buffer, 66, Config.ZYA.UN.A_Vakuum);
                S7.SetIntAt(buffer, 68, Config.ZYA.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 70, Config.ZYA.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 72, Config.ZYA.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 74, Config.ZYA.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 76, Config.ZYA.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 78, Config.ZYA.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 80, Config.T1.OB.E_01_16);
                S7.SetIntAt(buffer, 82, Config.T1.OB.E_17_32);
                S7.SetIntAt(buffer, 84, Config.T1.OB.E_Vakuum);
                S7.SetIntAt(buffer, 86, Config.T1.OB.A_Vakuum);
                S7.SetIntAt(buffer, 88, Config.T1.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 90, Config.T1.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 92, Config.T1.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 94, Config.T1.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 96, Config.T1.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 98, Config.T1.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 100, Config.T1.UN.E_01_16);
                S7.SetIntAt(buffer, 102, Config.T1.UN.E_17_32);
                S7.SetIntAt(buffer, 104, Config.T1.UN.E_Vakuum);
                S7.SetIntAt(buffer, 106, Config.T1.UN.A_Vakuum);
                S7.SetIntAt(buffer, 108, Config.T1.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 110, Config.T1.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 112, Config.T1.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 114, Config.T1.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 116, Config.T1.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 118, Config.T1.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 120, Config.T2.OB.E_01_16);
                S7.SetIntAt(buffer, 122, Config.T2.OB.E_17_32);
                S7.SetIntAt(buffer, 124, Config.T2.OB.E_Vakuum);
                S7.SetIntAt(buffer, 126, Config.T2.OB.A_Vakuum);
                S7.SetIntAt(buffer, 128, Config.T2.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 130, Config.T2.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 132, Config.T2.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 134, Config.T2.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 136, Config.T2.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 138, Config.T2.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 140, Config.T2.UN.E_01_16);
                S7.SetIntAt(buffer, 142, Config.T2.UN.E_17_32);
                S7.SetIntAt(buffer, 144, Config.T2.UN.E_Vakuum);
                S7.SetIntAt(buffer, 146, Config.T2.UN.A_Vakuum);
                S7.SetIntAt(buffer, 148, Config.T2.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 150, Config.T2.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 152, Config.T2.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 154, Config.T2.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 156, Config.T2.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 158, Config.T2.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 160, Config.PN.OB.E_01_16);
                S7.SetIntAt(buffer, 162, Config.PN.OB.E_17_32);
                S7.SetIntAt(buffer, 164, Config.PN.OB.E_Vakuum);
                S7.SetIntAt(buffer, 166, Config.PN.OB.A_Vakuum);
                S7.SetIntAt(buffer, 168, Config.PN.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 170, Config.PN.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 172, Config.PN.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 174, Config.PN.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 176, Config.PN.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 178, Config.PN.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 180, Config.PN.UN.E_01_16);
                S7.SetIntAt(buffer, 182, Config.PN.UN.E_17_32);
                S7.SetIntAt(buffer, 184, Config.PN.UN.E_Vakuum);
                S7.SetIntAt(buffer, 186, Config.PN.UN.A_Vakuum);
                S7.SetIntAt(buffer, 188, Config.PN.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 190, Config.PN.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 192, Config.PN.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 194, Config.PN.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 196, Config.PN.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 198, Config.PN.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 200, Config.AV.OB.E_01_16);
                S7.SetIntAt(buffer, 202, Config.AV.OB.E_17_32);
                S7.SetIntAt(buffer, 204, Config.AV.OB.E_Vakuum);
                S7.SetIntAt(buffer, 206, Config.AV.OB.A_Vakuum);
                S7.SetIntAt(buffer, 208, Config.AV.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 210, Config.AV.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 212, Config.AV.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 214, Config.AV.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 216, Config.AV.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 218, Config.AV.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 220, Config.AV.UN.E_01_16);
                S7.SetIntAt(buffer, 222, Config.AV.UN.E_17_32);
                S7.SetIntAt(buffer, 224, Config.AV.UN.E_Vakuum);
                S7.SetIntAt(buffer, 226, Config.AV.UN.A_Vakuum);
                S7.SetIntAt(buffer, 228, Config.AV.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 230, Config.AV.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 232, Config.AV.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 234, Config.AV.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 236, Config.AV.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 238, Config.AV.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 240, Config.AP.OB.E_01_16);
                S7.SetIntAt(buffer, 242, Config.AP.OB.E_17_32);
                S7.SetIntAt(buffer, 244, Config.AP.OB.E_Vakuum);
                S7.SetIntAt(buffer, 246, Config.AP.OB.A_Vakuum);
                S7.SetIntAt(buffer, 248, Config.AP.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 250, Config.AP.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 252, Config.AP.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 254, Config.AP.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 256, Config.AP.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 258, Config.AP.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 260, Config.AP.UN.E_01_16);
                S7.SetIntAt(buffer, 262, Config.AP.UN.E_17_32);
                S7.SetIntAt(buffer, 264, Config.AP.UN.E_Vakuum);
                S7.SetIntAt(buffer, 266, Config.AP.UN.A_Vakuum);
                S7.SetIntAt(buffer, 268, Config.AP.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 270, Config.AP.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 272, Config.AP.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 274, Config.AP.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 276, Config.AP.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 278, Config.AP.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 280, Config.PT.OB.E_01_16);
                S7.SetIntAt(buffer, 282, Config.PT.OB.E_17_32);
                S7.SetIntAt(buffer, 284, Config.PT.OB.E_Vakuum);
                S7.SetIntAt(buffer, 286, Config.PT.OB.A_Vakuum);
                S7.SetIntAt(buffer, 288, Config.PT.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 290, Config.PT.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 292, Config.PT.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 294, Config.PT.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 296, Config.PT.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 298, Config.PT.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 300, Config.PT.UN.E_01_16);
                S7.SetIntAt(buffer, 302, Config.PT.UN.E_17_32);
                S7.SetIntAt(buffer, 304, Config.PT.UN.E_Vakuum);
                S7.SetIntAt(buffer, 306, Config.PT.UN.A_Vakuum);
                S7.SetIntAt(buffer, 308, Config.PT.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 310, Config.PT.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 312, Config.PT.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 314, Config.PT.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 316, Config.PT.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 318, Config.PT.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 320, Config.WV.OB.E_01_16);
                S7.SetIntAt(buffer, 322, Config.WV.OB.E_17_32);
                S7.SetIntAt(buffer, 324, Config.WV.OB.E_Vakuum);
                S7.SetIntAt(buffer, 326, Config.WV.OB.A_Vakuum);
                S7.SetIntAt(buffer, 328, Config.WV.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 330, Config.WV.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 332, Config.WV.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 334, Config.WV.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 336, Config.WV.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 338, Config.WV.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 340, Config.WV.UN.E_01_16);
                S7.SetIntAt(buffer, 342, Config.WV.UN.E_17_32);
                S7.SetIntAt(buffer, 344, Config.WV.UN.E_Vakuum);
                S7.SetIntAt(buffer, 346, Config.WV.UN.A_Vakuum);
                S7.SetIntAt(buffer, 348, Config.WV.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 350, Config.WV.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 352, Config.WV.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 354, Config.WV.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 356, Config.WV.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 358, Config.WV.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 360, Config.WE.OB.E_01_16);
                S7.SetIntAt(buffer, 362, Config.WE.OB.E_17_32);
                S7.SetIntAt(buffer, 364, Config.WE.OB.E_Vakuum);
                S7.SetIntAt(buffer, 366, Config.WE.OB.A_Vakuum);
                S7.SetIntAt(buffer, 368, Config.WE.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 370, Config.WE.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 372, Config.WE.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 374, Config.WE.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 376, Config.WE.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 378, Config.WE.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 380, Config.WE.UN.E_01_16);
                S7.SetIntAt(buffer, 382, Config.WE.UN.E_17_32);
                S7.SetIntAt(buffer, 384, Config.WE.UN.E_Vakuum);
                S7.SetIntAt(buffer, 386, Config.WE.UN.A_Vakuum);
                S7.SetIntAt(buffer, 388, Config.WE.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 390, Config.WE.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 392, Config.WE.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 394, Config.WE.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 396, Config.WE.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 398, Config.WE.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 400, Config.KU.OB.E_01_16);
                S7.SetIntAt(buffer, 402, Config.KU.OB.E_17_32);
                S7.SetIntAt(buffer, 404, Config.KU.OB.E_Vakuum);
                S7.SetIntAt(buffer, 406, Config.KU.OB.A_Vakuum);
                S7.SetIntAt(buffer, 408, Config.KU.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 410, Config.KU.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 412, Config.KU.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 414, Config.KU.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 416, Config.KU.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 418, Config.KU.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 420, Config.KU.UN.E_01_16);
                S7.SetIntAt(buffer, 422, Config.KU.UN.E_17_32);
                S7.SetIntAt(buffer, 424, Config.KU.UN.E_Vakuum);
                S7.SetIntAt(buffer, 426, Config.KU.UN.A_Vakuum);
                S7.SetIntAt(buffer, 428, Config.KU.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 430, Config.KU.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 432, Config.KU.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 434, Config.KU.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 436, Config.KU.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 438, Config.KU.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 440, Config.AU.OB.E_01_16);
                S7.SetIntAt(buffer, 442, Config.AU.OB.E_17_32);
                S7.SetIntAt(buffer, 444, Config.AU.OB.E_Vakuum);
                S7.SetIntAt(buffer, 446, Config.AU.OB.A_Vakuum);
                S7.SetIntAt(buffer, 448, Config.AU.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 450, Config.AU.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 452, Config.AU.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 454, Config.AU.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 456, Config.AU.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 458, Config.AU.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 460, Config.AU.UN.E_01_16);
                S7.SetIntAt(buffer, 462, Config.AU.UN.E_17_32);
                S7.SetIntAt(buffer, 464, Config.AU.UN.E_Vakuum);
                S7.SetIntAt(buffer, 466, Config.AU.UN.A_Vakuum);
                S7.SetIntAt(buffer, 468, Config.AU.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 470, Config.AU.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 472, Config.AU.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 474, Config.AU.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 476, Config.AU.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 478, Config.AU.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 480, Config.ZYE.OB.E_01_16);
                S7.SetIntAt(buffer, 482, Config.ZYE.OB.E_17_32);
                S7.SetIntAt(buffer, 484, Config.ZYE.OB.E_Vakuum);
                S7.SetIntAt(buffer, 486, Config.ZYE.OB.A_Vakuum);
                S7.SetIntAt(buffer, 488, Config.ZYE.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 490, Config.ZYE.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 492, Config.ZYE.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 494, Config.ZYE.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 496, Config.ZYE.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 498, Config.ZYE.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 500, Config.ZYE.UN.E_01_16);
                S7.SetIntAt(buffer, 502, Config.ZYE.UN.E_17_32);
                S7.SetIntAt(buffer, 504, Config.ZYE.UN.E_Vakuum);
                S7.SetIntAt(buffer, 506, Config.ZYE.UN.A_Vakuum);
                S7.SetIntAt(buffer, 508, Config.ZYE.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 510, Config.ZYE.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 512, Config.ZYE.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 514, Config.ZYE.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 516, Config.ZYE.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 518, Config.ZYE.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 520, Config.RO.OB.E_01_16);
                S7.SetIntAt(buffer, 522, Config.RO.OB.E_17_32);
                S7.SetIntAt(buffer, 524, Config.RO.OB.E_Vakuum);
                S7.SetIntAt(buffer, 526, Config.RO.OB.A_Vakuum);
                S7.SetIntAt(buffer, 528, Config.RO.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 530, Config.RO.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 532, Config.RO.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 534, Config.RO.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 536, Config.RO.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 538, Config.RO.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 540, Config.RO.UN.E_01_16);
                S7.SetIntAt(buffer, 542, Config.RO.UN.E_17_32);
                S7.SetIntAt(buffer, 544, Config.RO.UN.E_Vakuum);
                S7.SetIntAt(buffer, 546, Config.RO.UN.A_Vakuum);
                S7.SetIntAt(buffer, 548, Config.RO.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 550, Config.RO.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 552, Config.RO.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 554, Config.RO.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 556, Config.RO.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 558, Config.RO.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 560, Config.Reserve.OB.E_01_16);
                S7.SetIntAt(buffer, 562, Config.Reserve.OB.E_17_32);
                S7.SetIntAt(buffer, 564, Config.Reserve.OB.E_Vakuum);
                S7.SetIntAt(buffer, 566, Config.Reserve.OB.A_Vakuum);
                S7.SetIntAt(buffer, 568, Config.Reserve.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 570, Config.Reserve.OB_IG.E_01_16);
                S7.SetIntAt(buffer, 572, Config.Reserve.OB_IG.E_17_32);
                S7.SetIntAt(buffer, 574, Config.Reserve.OB_IG.E_Vakuum);
                S7.SetIntAt(buffer, 576, Config.Reserve.OB_IG.A_Vakuum);
                S7.SetIntAt(buffer, 578, Config.Reserve.OB_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 580, Config.Reserve.UN.E_01_16);
                S7.SetIntAt(buffer, 582, Config.Reserve.UN.E_17_32);
                S7.SetIntAt(buffer, 584, Config.Reserve.UN.E_Vakuum);
                S7.SetIntAt(buffer, 586, Config.Reserve.UN.A_Vakuum);
                S7.SetIntAt(buffer, 588, Config.Reserve.UN.A_Ventile_1_8);
                S7.SetIntAt(buffer, 590, Config.Reserve.UN_IG.E_01_16);
                S7.SetIntAt(buffer, 592, Config.Reserve.UN_IG.E_17_32);
                S7.SetIntAt(buffer, 594, Config.Reserve.UN_IG.E_Vakuum);
                S7.SetIntAt(buffer, 596, Config.Reserve.UN_IG.A_Vakuum);
                S7.SetIntAt(buffer, 598, Config.Reserve.UN_IG.A_Ventile_1_8);
                S7.SetIntAt(buffer, 600, Config.TK.OB.E_01_16);
                S7.SetIntAt(buffer, 602, Config.TK.OB.E_17_32);
                S7.SetIntAt(buffer, 604, Config.TK.OB.E_Vakuum);
                S7.SetIntAt(buffer, 606, Config.TK.OB.A_Vakuum);
                S7.SetIntAt(buffer, 608, Config.TK.OB.A_Ventile_1_8);
                S7.SetIntAt(buffer, 610, Config.TK.UN.E_01_16);
                S7.SetIntAt(buffer, 612, Config.TK.UN.E_17_32);
                S7.SetIntAt(buffer, 614, Config.TK.UN.E_Vakuum);
                S7.SetIntAt(buffer, 616, Config.TK.UN.A_Vakuum);
                S7.SetIntAt(buffer, 618, Config.TK.UN.A_Ventile_1_8);
                S7.SetStringAt(buffer, 620, 20, Config.WKZOB.Name.EO01);
                S7.SetStringAt(buffer, 642, 20, Config.WKZOB.Name.EO02);
                S7.SetStringAt(buffer, 664, 20, Config.WKZOB.Name.EO03);
                S7.SetStringAt(buffer, 686, 20, Config.WKZOB.Name.EO04);
                S7.SetStringAt(buffer, 708, 20, Config.WKZOB.Name.EO05);
                S7.SetStringAt(buffer, 730, 20, Config.WKZOB.Name.EO06);
                S7.SetStringAt(buffer, 752, 20, Config.WKZOB.Name.EO07);
                S7.SetStringAt(buffer, 774, 20, Config.WKZOB.Name.EO08);
                S7.SetStringAt(buffer, 796, 20, Config.WKZOB.Name.EO09);
                S7.SetStringAt(buffer, 818, 20, Config.WKZOB.Name.EO10);
                S7.SetStringAt(buffer, 840, 20, Config.WKZOB.Name.EO11);
                S7.SetStringAt(buffer, 862, 20, Config.WKZOB.Name.EO12);
                S7.SetStringAt(buffer, 884, 20, Config.WKZOB.Name.EO13);
                S7.SetStringAt(buffer, 906, 20, Config.WKZOB.Name.EO14);
                S7.SetStringAt(buffer, 928, 20, Config.WKZOB.Name.EO15);
                S7.SetStringAt(buffer, 950, 20, Config.WKZOB.Name.EO16);
                S7.SetStringAt(buffer, 972, 20, Config.WKZOB.Name.EO17);
                S7.SetStringAt(buffer, 994, 20, Config.WKZOB.Name.EO18);
                S7.SetStringAt(buffer, 1016, 20, Config.WKZOB.Name.EO19);
                S7.SetStringAt(buffer, 1038, 20, Config.WKZOB.Name.EO20);
                S7.SetStringAt(buffer, 1060, 20, Config.WKZOB.Name.EO21);
                S7.SetStringAt(buffer, 1082, 20, Config.WKZOB.Name.EO22);
                S7.SetStringAt(buffer, 1104, 20, Config.WKZOB.Name.EO23);
                S7.SetStringAt(buffer, 1126, 20, Config.WKZOB.Name.EO24);
                S7.SetStringAt(buffer, 1148, 20, Config.WKZOB.Name.EO25);
                S7.SetStringAt(buffer, 1170, 20, Config.WKZOB.Name.EO26);
                S7.SetStringAt(buffer, 1192, 20, Config.WKZOB.Name.EO27);
                S7.SetStringAt(buffer, 1214, 20, Config.WKZOB.Name.EO28);
                S7.SetStringAt(buffer, 1236, 20, Config.WKZOB.Name.EO29);
                S7.SetStringAt(buffer, 1258, 20, Config.WKZOB.Name.EO30);
                S7.SetStringAt(buffer, 1280, 20, Config.WKZOB.Name.EO31);
                S7.SetStringAt(buffer, 1302, 20, Config.WKZOB.Name.EO32);
                S7.SetStringAt(buffer, 1324, 20, Config.WKZOB.Name.VO121);
                S7.SetStringAt(buffer, 1346, 20, Config.WKZOB.Name.VO141);
                S7.SetStringAt(buffer, 1368, 20, Config.WKZOB.Name.VO122);
                S7.SetStringAt(buffer, 1390, 20, Config.WKZOB.Name.VO142);
                S7.SetStringAt(buffer, 1412, 20, Config.WKZOB.Name.VO123);
                S7.SetStringAt(buffer, 1434, 20, Config.WKZOB.Name.VO143);
                S7.SetStringAt(buffer, 1456, 20, Config.WKZOB.Name.VO124);
                S7.SetStringAt(buffer, 1478, 20, Config.WKZOB.Name.VO144);
                S7.SetStringAt(buffer, 1500, 20, Config.WKZOB.Name.VO125);
                S7.SetStringAt(buffer, 1522, 20, Config.WKZOB.Name.VO145);
                S7.SetStringAt(buffer, 1544, 20, Config.WKZOB.Name.VO126);
                S7.SetStringAt(buffer, 1566, 20, Config.WKZOB.Name.VO146);
                S7.SetStringAt(buffer, 1588, 20, Config.WKZOB.Name.VO127);
                S7.SetStringAt(buffer, 1610, 20, Config.WKZOB.Name.VO147);
                S7.SetStringAt(buffer, 1632, 20, Config.WKZOB.Name.VO128);
                S7.SetStringAt(buffer, 1654, 20, Config.WKZOB.Name.VO148);
                S7.SetIntAt(buffer, 1676, Config.WKZOB.Time.TVO121);
                S7.SetIntAt(buffer, 1678, Config.WKZOB.Time.TVO141);
                S7.SetIntAt(buffer, 1680, Config.WKZOB.Time.TVO122);
                S7.SetIntAt(buffer, 1682, Config.WKZOB.Time.TVO142);
                S7.SetIntAt(buffer, 1684, Config.WKZOB.Time.TVO123);
                S7.SetIntAt(buffer, 1686, Config.WKZOB.Time.TVO143);
                S7.SetIntAt(buffer, 1688, Config.WKZOB.Time.TVO124);
                S7.SetIntAt(buffer, 1690, Config.WKZOB.Time.TVO144);
                S7.SetIntAt(buffer, 1692, Config.WKZOB.Time.TVO125);
                S7.SetIntAt(buffer, 1694, Config.WKZOB.Time.TVO145);
                S7.SetIntAt(buffer, 1696, Config.WKZOB.Time.TVO126);
                S7.SetIntAt(buffer, 1698, Config.WKZOB.Time.TVO146);
                S7.SetIntAt(buffer, 1700, Config.WKZOB.Time.TVO127);
                S7.SetIntAt(buffer, 1702, Config.WKZOB.Time.TVO147);
                S7.SetIntAt(buffer, 1704, Config.WKZOB.Time.TVO128);
                S7.SetIntAt(buffer, 1706, Config.WKZOB.Time.TVO148);
                S7.SetStringAt(buffer, 1708, 20, Config.WKZUN.Name.EO01);
                S7.SetStringAt(buffer, 1730, 20, Config.WKZUN.Name.EO02);
                S7.SetStringAt(buffer, 1752, 20, Config.WKZUN.Name.EO03);
                S7.SetStringAt(buffer, 1774, 20, Config.WKZUN.Name.EO04);
                S7.SetStringAt(buffer, 1796, 20, Config.WKZUN.Name.EO05);
                S7.SetStringAt(buffer, 1818, 20, Config.WKZUN.Name.EO06);
                S7.SetStringAt(buffer, 1840, 20, Config.WKZUN.Name.EO07);
                S7.SetStringAt(buffer, 1862, 20, Config.WKZUN.Name.EO08);
                S7.SetStringAt(buffer, 1884, 20, Config.WKZUN.Name.EO09);
                S7.SetStringAt(buffer, 1906, 20, Config.WKZUN.Name.EO10);
                S7.SetStringAt(buffer, 1928, 20, Config.WKZUN.Name.EO11);
                S7.SetStringAt(buffer, 1950, 20, Config.WKZUN.Name.EO12);
                S7.SetStringAt(buffer, 1972, 20, Config.WKZUN.Name.EO13);
                S7.SetStringAt(buffer, 1994, 20, Config.WKZUN.Name.EO14);
                S7.SetStringAt(buffer, 2016, 20, Config.WKZUN.Name.EO15);
                S7.SetStringAt(buffer, 2038, 20, Config.WKZUN.Name.EO16);
                S7.SetStringAt(buffer, 2060, 20, Config.WKZUN.Name.EO17);
                S7.SetStringAt(buffer, 2082, 20, Config.WKZUN.Name.EO18);
                S7.SetStringAt(buffer, 2104, 20, Config.WKZUN.Name.EO19);
                S7.SetStringAt(buffer, 2126, 20, Config.WKZUN.Name.EO20);
                S7.SetStringAt(buffer, 2148, 20, Config.WKZUN.Name.EO21);
                S7.SetStringAt(buffer, 2170, 20, Config.WKZUN.Name.EO22);
                S7.SetStringAt(buffer, 2192, 20, Config.WKZUN.Name.EO23);
                S7.SetStringAt(buffer, 2214, 20, Config.WKZUN.Name.EO24);
                S7.SetStringAt(buffer, 2236, 20, Config.WKZUN.Name.EO25);
                S7.SetStringAt(buffer, 2258, 20, Config.WKZUN.Name.EO26);
                S7.SetStringAt(buffer, 2280, 20, Config.WKZUN.Name.EO27);
                S7.SetStringAt(buffer, 2302, 20, Config.WKZUN.Name.EO28);
                S7.SetStringAt(buffer, 2324, 20, Config.WKZUN.Name.EO29);
                S7.SetStringAt(buffer, 2346, 20, Config.WKZUN.Name.EO30);
                S7.SetStringAt(buffer, 2368, 20, Config.WKZUN.Name.EO31);
                S7.SetStringAt(buffer, 2390, 20, Config.WKZUN.Name.EO32);
                S7.SetStringAt(buffer, 2412, 20, Config.WKZUN.Name.VO121);
                S7.SetStringAt(buffer, 2434, 20, Config.WKZUN.Name.VO141);
                S7.SetStringAt(buffer, 2456, 20, Config.WKZUN.Name.VO122);
                S7.SetStringAt(buffer, 2478, 20, Config.WKZUN.Name.VO142);
                S7.SetStringAt(buffer, 2500, 20, Config.WKZUN.Name.VO123);
                S7.SetStringAt(buffer, 2522, 20, Config.WKZUN.Name.VO143);
                S7.SetStringAt(buffer, 2544, 20, Config.WKZUN.Name.VO124);
                S7.SetStringAt(buffer, 2566, 20, Config.WKZUN.Name.VO144);
                S7.SetStringAt(buffer, 2588, 20, Config.WKZUN.Name.VO125);
                S7.SetStringAt(buffer, 2610, 20, Config.WKZUN.Name.VO145);
                S7.SetStringAt(buffer, 2632, 20, Config.WKZUN.Name.VO126);
                S7.SetStringAt(buffer, 2654, 20, Config.WKZUN.Name.VO146);
                S7.SetStringAt(buffer, 2676, 20, Config.WKZUN.Name.VO127);
                S7.SetStringAt(buffer, 2698, 20, Config.WKZUN.Name.VO147);
                S7.SetStringAt(buffer, 2720, 20, Config.WKZUN.Name.VO128);
                S7.SetStringAt(buffer, 2742, 20, Config.WKZUN.Name.VO148);
                S7.SetIntAt(buffer, 2764, Config.WKZUN.Time.TVO121);
                S7.SetIntAt(buffer, 2766, Config.WKZUN.Time.TVO141);
                S7.SetIntAt(buffer, 2768, Config.WKZUN.Time.TVO122);
                S7.SetIntAt(buffer, 2770, Config.WKZUN.Time.TVO142);
                S7.SetIntAt(buffer, 2772, Config.WKZUN.Time.TVO123);
                S7.SetIntAt(buffer, 2774, Config.WKZUN.Time.TVO143);
                S7.SetIntAt(buffer, 2776, Config.WKZUN.Time.TVO124);
                S7.SetIntAt(buffer, 2778, Config.WKZUN.Time.TVO144);
                S7.SetIntAt(buffer, 2780, Config.WKZUN.Time.TVO125);
                S7.SetIntAt(buffer, 2782, Config.WKZUN.Time.TVO145);
                S7.SetIntAt(buffer, 2784, Config.WKZUN.Time.TVO126);
                S7.SetIntAt(buffer, 2786, Config.WKZUN.Time.TVO146);
                S7.SetIntAt(buffer, 2788, Config.WKZUN.Time.TVO127);
                S7.SetIntAt(buffer, 2790, Config.WKZUN.Time.TVO147);
                S7.SetIntAt(buffer, 2792, Config.WKZUN.Time.TVO128);
                S7.SetIntAt(buffer, 2794, Config.WKZUN.Time.TVO148);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
                //throw;
            }
        }
        public static DatConfig BufferToDatConfig(byte[] buffer, ref string error)
        {
            error = string.Empty;
            //create instance
            DatConfig Config = new DatConfig();

            try
            {
                Config.GS.OB.E_01_16 = S7.GetIntAt(buffer, 0);
                Config.GS.OB.E_17_32 = S7.GetIntAt(buffer, 2);
                Config.GS.OB.E_Vakuum = S7.GetIntAt(buffer, 4);
                Config.GS.OB.A_Vakuum = S7.GetIntAt(buffer, 6);
                Config.GS.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 8);
                Config.GS.OB_IG.E_01_16 = S7.GetIntAt(buffer, 10);
                Config.GS.OB_IG.E_17_32 = S7.GetIntAt(buffer, 12);
                Config.GS.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 14);
                Config.GS.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 16);
                Config.GS.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 18);
                Config.GS.UN.E_01_16 = S7.GetIntAt(buffer, 20);
                Config.GS.UN.E_17_32 = S7.GetIntAt(buffer, 22);
                Config.GS.UN.E_Vakuum = S7.GetIntAt(buffer, 24);
                Config.GS.UN.A_Vakuum = S7.GetIntAt(buffer, 26);
                Config.GS.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 28);
                Config.GS.UN_IG.E_01_16 = S7.GetIntAt(buffer, 30);
                Config.GS.UN_IG.E_17_32 = S7.GetIntAt(buffer, 32);
                Config.GS.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 34);
                Config.GS.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 36);
                Config.GS.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 38);
                Config.ZYA.OB.E_01_16 = S7.GetIntAt(buffer, 40);
                Config.ZYA.OB.E_17_32 = S7.GetIntAt(buffer, 42);
                Config.ZYA.OB.E_Vakuum = S7.GetIntAt(buffer, 44);
                Config.ZYA.OB.A_Vakuum = S7.GetIntAt(buffer, 46);
                Config.ZYA.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 48);
                Config.ZYA.OB_IG.E_01_16 = S7.GetIntAt(buffer, 50);
                Config.ZYA.OB_IG.E_17_32 = S7.GetIntAt(buffer, 52);
                Config.ZYA.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 54);
                Config.ZYA.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 56);
                Config.ZYA.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 58);
                Config.ZYA.UN.E_01_16 = S7.GetIntAt(buffer, 60);
                Config.ZYA.UN.E_17_32 = S7.GetIntAt(buffer, 62);
                Config.ZYA.UN.E_Vakuum = S7.GetIntAt(buffer, 64);
                Config.ZYA.UN.A_Vakuum = S7.GetIntAt(buffer, 66);
                Config.ZYA.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 68);
                Config.ZYA.UN_IG.E_01_16 = S7.GetIntAt(buffer, 70);
                Config.ZYA.UN_IG.E_17_32 = S7.GetIntAt(buffer, 72);
                Config.ZYA.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 74);
                Config.ZYA.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 76);
                Config.ZYA.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 78);
                Config.T1.OB.E_01_16 = S7.GetIntAt(buffer, 80);
                Config.T1.OB.E_17_32 = S7.GetIntAt(buffer, 82);
                Config.T1.OB.E_Vakuum = S7.GetIntAt(buffer, 84);
                Config.T1.OB.A_Vakuum = S7.GetIntAt(buffer, 86);
                Config.T1.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 88);
                Config.T1.OB_IG.E_01_16 = S7.GetIntAt(buffer, 90);
                Config.T1.OB_IG.E_17_32 = S7.GetIntAt(buffer, 92);
                Config.T1.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 94);
                Config.T1.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 96);
                Config.T1.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 98);
                Config.T1.UN.E_01_16 = S7.GetIntAt(buffer, 100);
                Config.T1.UN.E_17_32 = S7.GetIntAt(buffer, 102);
                Config.T1.UN.E_Vakuum = S7.GetIntAt(buffer, 104);
                Config.T1.UN.A_Vakuum = S7.GetIntAt(buffer, 106);
                Config.T1.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 108);
                Config.T1.UN_IG.E_01_16 = S7.GetIntAt(buffer, 110);
                Config.T1.UN_IG.E_17_32 = S7.GetIntAt(buffer, 112);
                Config.T1.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 114);
                Config.T1.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 116);
                Config.T1.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 118);
                Config.T2.OB.E_01_16 = S7.GetIntAt(buffer, 120);
                Config.T2.OB.E_17_32 = S7.GetIntAt(buffer, 122);
                Config.T2.OB.E_Vakuum = S7.GetIntAt(buffer, 124);
                Config.T2.OB.A_Vakuum = S7.GetIntAt(buffer, 126);
                Config.T2.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 128);
                Config.T2.OB_IG.E_01_16 = S7.GetIntAt(buffer, 130);
                Config.T2.OB_IG.E_17_32 = S7.GetIntAt(buffer, 132);
                Config.T2.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 134);
                Config.T2.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 136);
                Config.T2.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 138);
                Config.T2.UN.E_01_16 = S7.GetIntAt(buffer, 140);
                Config.T2.UN.E_17_32 = S7.GetIntAt(buffer, 142);
                Config.T2.UN.E_Vakuum = S7.GetIntAt(buffer, 144);
                Config.T2.UN.A_Vakuum = S7.GetIntAt(buffer, 146);
                Config.T2.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 148);
                Config.T2.UN_IG.E_01_16 = S7.GetIntAt(buffer, 150);
                Config.T2.UN_IG.E_17_32 = S7.GetIntAt(buffer, 152);
                Config.T2.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 154);
                Config.T2.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 156);
                Config.T2.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 158);
                Config.PN.OB.E_01_16 = S7.GetIntAt(buffer, 160);
                Config.PN.OB.E_17_32 = S7.GetIntAt(buffer, 162);
                Config.PN.OB.E_Vakuum = S7.GetIntAt(buffer, 164);
                Config.PN.OB.A_Vakuum = S7.GetIntAt(buffer, 166);
                Config.PN.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 168);
                Config.PN.OB_IG.E_01_16 = S7.GetIntAt(buffer, 170);
                Config.PN.OB_IG.E_17_32 = S7.GetIntAt(buffer, 172);
                Config.PN.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 174);
                Config.PN.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 176);
                Config.PN.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 178);
                Config.PN.UN.E_01_16 = S7.GetIntAt(buffer, 180);
                Config.PN.UN.E_17_32 = S7.GetIntAt(buffer, 182);
                Config.PN.UN.E_Vakuum = S7.GetIntAt(buffer, 184);
                Config.PN.UN.A_Vakuum = S7.GetIntAt(buffer, 186);
                Config.PN.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 188);
                Config.PN.UN_IG.E_01_16 = S7.GetIntAt(buffer, 190);
                Config.PN.UN_IG.E_17_32 = S7.GetIntAt(buffer, 192);
                Config.PN.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 194);
                Config.PN.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 196);
                Config.PN.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 198);
                Config.AV.OB.E_01_16 = S7.GetIntAt(buffer, 200);
                Config.AV.OB.E_17_32 = S7.GetIntAt(buffer, 202);
                Config.AV.OB.E_Vakuum = S7.GetIntAt(buffer, 204);
                Config.AV.OB.A_Vakuum = S7.GetIntAt(buffer, 206);
                Config.AV.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 208);
                Config.AV.OB_IG.E_01_16 = S7.GetIntAt(buffer, 210);
                Config.AV.OB_IG.E_17_32 = S7.GetIntAt(buffer, 212);
                Config.AV.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 214);
                Config.AV.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 216);
                Config.AV.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 218);
                Config.AV.UN.E_01_16 = S7.GetIntAt(buffer, 220);
                Config.AV.UN.E_17_32 = S7.GetIntAt(buffer, 222);
                Config.AV.UN.E_Vakuum = S7.GetIntAt(buffer, 224);
                Config.AV.UN.A_Vakuum = S7.GetIntAt(buffer, 226);
                Config.AV.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 228);
                Config.AV.UN_IG.E_01_16 = S7.GetIntAt(buffer, 230);
                Config.AV.UN_IG.E_17_32 = S7.GetIntAt(buffer, 232);
                Config.AV.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 234);
                Config.AV.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 236);
                Config.AV.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 238);
                Config.AP.OB.E_01_16 = S7.GetIntAt(buffer, 240);
                Config.AP.OB.E_17_32 = S7.GetIntAt(buffer, 242);
                Config.AP.OB.E_Vakuum = S7.GetIntAt(buffer, 244);
                Config.AP.OB.A_Vakuum = S7.GetIntAt(buffer, 246);
                Config.AP.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 248);
                Config.AP.OB_IG.E_01_16 = S7.GetIntAt(buffer, 250);
                Config.AP.OB_IG.E_17_32 = S7.GetIntAt(buffer, 252);
                Config.AP.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 254);
                Config.AP.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 256);
                Config.AP.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 258);
                Config.AP.UN.E_01_16 = S7.GetIntAt(buffer, 260);
                Config.AP.UN.E_17_32 = S7.GetIntAt(buffer, 262);
                Config.AP.UN.E_Vakuum = S7.GetIntAt(buffer, 264);
                Config.AP.UN.A_Vakuum = S7.GetIntAt(buffer, 266);
                Config.AP.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 268);
                Config.AP.UN_IG.E_01_16 = S7.GetIntAt(buffer, 270);
                Config.AP.UN_IG.E_17_32 = S7.GetIntAt(buffer, 272);
                Config.AP.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 274);
                Config.AP.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 276);
                Config.AP.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 278);
                Config.PT.OB.E_01_16 = S7.GetIntAt(buffer, 280);
                Config.PT.OB.E_17_32 = S7.GetIntAt(buffer, 282);
                Config.PT.OB.E_Vakuum = S7.GetIntAt(buffer, 284);
                Config.PT.OB.A_Vakuum = S7.GetIntAt(buffer, 286);
                Config.PT.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 288);
                Config.PT.OB_IG.E_01_16 = S7.GetIntAt(buffer, 290);
                Config.PT.OB_IG.E_17_32 = S7.GetIntAt(buffer, 292);
                Config.PT.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 294);
                Config.PT.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 296);
                Config.PT.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 298);
                Config.PT.UN.E_01_16 = S7.GetIntAt(buffer, 300);
                Config.PT.UN.E_17_32 = S7.GetIntAt(buffer, 302);
                Config.PT.UN.E_Vakuum = S7.GetIntAt(buffer, 304);
                Config.PT.UN.A_Vakuum = S7.GetIntAt(buffer, 306);
                Config.PT.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 308);
                Config.PT.UN_IG.E_01_16 = S7.GetIntAt(buffer, 310);
                Config.PT.UN_IG.E_17_32 = S7.GetIntAt(buffer, 312);
                Config.PT.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 314);
                Config.PT.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 316);
                Config.PT.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 318);
                Config.WV.OB.E_01_16 = S7.GetIntAt(buffer, 320);
                Config.WV.OB.E_17_32 = S7.GetIntAt(buffer, 322);
                Config.WV.OB.E_Vakuum = S7.GetIntAt(buffer, 324);
                Config.WV.OB.A_Vakuum = S7.GetIntAt(buffer, 326);
                Config.WV.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 328);
                Config.WV.OB_IG.E_01_16 = S7.GetIntAt(buffer, 330);
                Config.WV.OB_IG.E_17_32 = S7.GetIntAt(buffer, 332);
                Config.WV.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 334);
                Config.WV.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 336);
                Config.WV.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 338);
                Config.WV.UN.E_01_16 = S7.GetIntAt(buffer, 340);
                Config.WV.UN.E_17_32 = S7.GetIntAt(buffer, 342);
                Config.WV.UN.E_Vakuum = S7.GetIntAt(buffer, 344);
                Config.WV.UN.A_Vakuum = S7.GetIntAt(buffer, 346);
                Config.WV.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 348);
                Config.WV.UN_IG.E_01_16 = S7.GetIntAt(buffer, 350);
                Config.WV.UN_IG.E_17_32 = S7.GetIntAt(buffer, 352);
                Config.WV.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 354);
                Config.WV.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 356);
                Config.WV.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 358);
                Config.WE.OB.E_01_16 = S7.GetIntAt(buffer, 360);
                Config.WE.OB.E_17_32 = S7.GetIntAt(buffer, 362);
                Config.WE.OB.E_Vakuum = S7.GetIntAt(buffer, 364);
                Config.WE.OB.A_Vakuum = S7.GetIntAt(buffer, 366);
                Config.WE.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 368);
                Config.WE.OB_IG.E_01_16 = S7.GetIntAt(buffer, 370);
                Config.WE.OB_IG.E_17_32 = S7.GetIntAt(buffer, 372);
                Config.WE.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 374);
                Config.WE.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 376);
                Config.WE.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 378);
                Config.WE.UN.E_01_16 = S7.GetIntAt(buffer, 380);
                Config.WE.UN.E_17_32 = S7.GetIntAt(buffer, 382);
                Config.WE.UN.E_Vakuum = S7.GetIntAt(buffer, 384);
                Config.WE.UN.A_Vakuum = S7.GetIntAt(buffer, 386);
                Config.WE.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 388);
                Config.WE.UN_IG.E_01_16 = S7.GetIntAt(buffer, 390);
                Config.WE.UN_IG.E_17_32 = S7.GetIntAt(buffer, 392);
                Config.WE.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 394);
                Config.WE.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 396);
                Config.WE.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 398);
                Config.KU.OB.E_01_16 = S7.GetIntAt(buffer, 400);
                Config.KU.OB.E_17_32 = S7.GetIntAt(buffer, 402);
                Config.KU.OB.E_Vakuum = S7.GetIntAt(buffer, 404);
                Config.KU.OB.A_Vakuum = S7.GetIntAt(buffer, 406);
                Config.KU.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 408);
                Config.KU.OB_IG.E_01_16 = S7.GetIntAt(buffer, 410);
                Config.KU.OB_IG.E_17_32 = S7.GetIntAt(buffer, 412);
                Config.KU.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 414);
                Config.KU.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 416);
                Config.KU.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 418);
                Config.KU.UN.E_01_16 = S7.GetIntAt(buffer, 420);
                Config.KU.UN.E_17_32 = S7.GetIntAt(buffer, 422);
                Config.KU.UN.E_Vakuum = S7.GetIntAt(buffer, 424);
                Config.KU.UN.A_Vakuum = S7.GetIntAt(buffer, 426);
                Config.KU.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 428);
                Config.KU.UN_IG.E_01_16 = S7.GetIntAt(buffer, 430);
                Config.KU.UN_IG.E_17_32 = S7.GetIntAt(buffer, 432);
                Config.KU.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 434);
                Config.KU.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 436);
                Config.KU.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 438);
                Config.AU.OB.E_01_16 = S7.GetIntAt(buffer, 440);
                Config.AU.OB.E_17_32 = S7.GetIntAt(buffer, 442);
                Config.AU.OB.E_Vakuum = S7.GetIntAt(buffer, 444);
                Config.AU.OB.A_Vakuum = S7.GetIntAt(buffer, 446);
                Config.AU.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 448);
                Config.AU.OB_IG.E_01_16 = S7.GetIntAt(buffer, 450);
                Config.AU.OB_IG.E_17_32 = S7.GetIntAt(buffer, 452);
                Config.AU.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 454);
                Config.AU.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 456);
                Config.AU.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 458);
                Config.AU.UN.E_01_16 = S7.GetIntAt(buffer, 460);
                Config.AU.UN.E_17_32 = S7.GetIntAt(buffer, 462);
                Config.AU.UN.E_Vakuum = S7.GetIntAt(buffer, 464);
                Config.AU.UN.A_Vakuum = S7.GetIntAt(buffer, 466);
                Config.AU.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 468);
                Config.AU.UN_IG.E_01_16 = S7.GetIntAt(buffer, 470);
                Config.AU.UN_IG.E_17_32 = S7.GetIntAt(buffer, 472);
                Config.AU.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 474);
                Config.AU.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 476);
                Config.AU.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 478);
                Config.ZYE.OB.E_01_16 = S7.GetIntAt(buffer, 480);
                Config.ZYE.OB.E_17_32 = S7.GetIntAt(buffer, 482);
                Config.ZYE.OB.E_Vakuum = S7.GetIntAt(buffer, 484);
                Config.ZYE.OB.A_Vakuum = S7.GetIntAt(buffer, 486);
                Config.ZYE.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 488);
                Config.ZYE.OB_IG.E_01_16 = S7.GetIntAt(buffer, 490);
                Config.ZYE.OB_IG.E_17_32 = S7.GetIntAt(buffer, 492);
                Config.ZYE.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 494);
                Config.ZYE.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 496);
                Config.ZYE.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 498);
                Config.ZYE.UN.E_01_16 = S7.GetIntAt(buffer, 500);
                Config.ZYE.UN.E_17_32 = S7.GetIntAt(buffer, 502);
                Config.ZYE.UN.E_Vakuum = S7.GetIntAt(buffer, 504);
                Config.ZYE.UN.A_Vakuum = S7.GetIntAt(buffer, 506);
                Config.ZYE.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 508);
                Config.ZYE.UN_IG.E_01_16 = S7.GetIntAt(buffer, 510);
                Config.ZYE.UN_IG.E_17_32 = S7.GetIntAt(buffer, 512);
                Config.ZYE.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 514);
                Config.ZYE.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 516);
                Config.ZYE.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 518);
                Config.RO.OB.E_01_16 = S7.GetIntAt(buffer, 520);
                Config.RO.OB.E_17_32 = S7.GetIntAt(buffer, 522);
                Config.RO.OB.E_Vakuum = S7.GetIntAt(buffer, 524);
                Config.RO.OB.A_Vakuum = S7.GetIntAt(buffer, 526);
                Config.RO.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 528);
                Config.RO.OB_IG.E_01_16 = S7.GetIntAt(buffer, 530);
                Config.RO.OB_IG.E_17_32 = S7.GetIntAt(buffer, 532);
                Config.RO.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 534);
                Config.RO.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 536);
                Config.RO.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 538);
                Config.RO.UN.E_01_16 = S7.GetIntAt(buffer, 540);
                Config.RO.UN.E_17_32 = S7.GetIntAt(buffer, 542);
                Config.RO.UN.E_Vakuum = S7.GetIntAt(buffer, 544);
                Config.RO.UN.A_Vakuum = S7.GetIntAt(buffer, 546);
                Config.RO.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 548);
                Config.RO.UN_IG.E_01_16 = S7.GetIntAt(buffer, 550);
                Config.RO.UN_IG.E_17_32 = S7.GetIntAt(buffer, 552);
                Config.RO.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 554);
                Config.RO.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 556);
                Config.RO.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 558);
                Config.Reserve.OB.E_01_16 = S7.GetIntAt(buffer, 560);
                Config.Reserve.OB.E_17_32 = S7.GetIntAt(buffer, 562);
                Config.Reserve.OB.E_Vakuum = S7.GetIntAt(buffer, 564);
                Config.Reserve.OB.A_Vakuum = S7.GetIntAt(buffer, 566);
                Config.Reserve.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 568);
                Config.Reserve.OB_IG.E_01_16 = S7.GetIntAt(buffer, 570);
                Config.Reserve.OB_IG.E_17_32 = S7.GetIntAt(buffer, 572);
                Config.Reserve.OB_IG.E_Vakuum = S7.GetIntAt(buffer, 574);
                Config.Reserve.OB_IG.A_Vakuum = S7.GetIntAt(buffer, 576);
                Config.Reserve.OB_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 578);
                Config.Reserve.UN.E_01_16 = S7.GetIntAt(buffer, 580);
                Config.Reserve.UN.E_17_32 = S7.GetIntAt(buffer, 582);
                Config.Reserve.UN.E_Vakuum = S7.GetIntAt(buffer, 584);
                Config.Reserve.UN.A_Vakuum = S7.GetIntAt(buffer, 586);
                Config.Reserve.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 588);
                Config.Reserve.UN_IG.E_01_16 = S7.GetIntAt(buffer, 590);
                Config.Reserve.UN_IG.E_17_32 = S7.GetIntAt(buffer, 592);
                Config.Reserve.UN_IG.E_Vakuum = S7.GetIntAt(buffer, 594);
                Config.Reserve.UN_IG.A_Vakuum = S7.GetIntAt(buffer, 596);
                Config.Reserve.UN_IG.A_Ventile_1_8 = S7.GetIntAt(buffer, 598);
                Config.TK.OB.E_01_16 = S7.GetIntAt(buffer, 600);
                Config.TK.OB.E_17_32 = S7.GetIntAt(buffer, 602);
                Config.TK.OB.E_Vakuum = S7.GetIntAt(buffer, 604);
                Config.TK.OB.A_Vakuum = S7.GetIntAt(buffer, 606);
                Config.TK.OB.A_Ventile_1_8 = S7.GetIntAt(buffer, 608);
                Config.TK.UN.E_01_16 = S7.GetIntAt(buffer, 610);
                Config.TK.UN.E_17_32 = S7.GetIntAt(buffer, 612);
                Config.TK.UN.E_Vakuum = S7.GetIntAt(buffer, 614);
                Config.TK.UN.A_Vakuum = S7.GetIntAt(buffer, 616);
                Config.TK.UN.A_Ventile_1_8 = S7.GetIntAt(buffer, 618);
                Config.WKZOB.Name.EO01 = S7.GetStringAt(buffer, 620);
                Config.WKZOB.Name.EO02 = S7.GetStringAt(buffer, 642);
                Config.WKZOB.Name.EO03 = S7.GetStringAt(buffer, 664);
                Config.WKZOB.Name.EO04 = S7.GetStringAt(buffer, 686);
                Config.WKZOB.Name.EO05 = S7.GetStringAt(buffer, 708);
                Config.WKZOB.Name.EO06 = S7.GetStringAt(buffer, 730);
                Config.WKZOB.Name.EO07 = S7.GetStringAt(buffer, 752);
                Config.WKZOB.Name.EO08 = S7.GetStringAt(buffer, 774);
                Config.WKZOB.Name.EO09 = S7.GetStringAt(buffer, 796);
                Config.WKZOB.Name.EO10 = S7.GetStringAt(buffer, 818);
                Config.WKZOB.Name.EO11 = S7.GetStringAt(buffer, 840);
                Config.WKZOB.Name.EO12 = S7.GetStringAt(buffer, 862);
                Config.WKZOB.Name.EO13 = S7.GetStringAt(buffer, 884);
                Config.WKZOB.Name.EO14 = S7.GetStringAt(buffer, 906);
                Config.WKZOB.Name.EO15 = S7.GetStringAt(buffer, 928);
                Config.WKZOB.Name.EO16 = S7.GetStringAt(buffer, 950);
                Config.WKZOB.Name.EO17 = S7.GetStringAt(buffer, 972);
                Config.WKZOB.Name.EO18 = S7.GetStringAt(buffer, 994);
                Config.WKZOB.Name.EO19 = S7.GetStringAt(buffer, 1016);
                Config.WKZOB.Name.EO20 = S7.GetStringAt(buffer, 1038);
                Config.WKZOB.Name.EO21 = S7.GetStringAt(buffer, 1060);
                Config.WKZOB.Name.EO22 = S7.GetStringAt(buffer, 1082);
                Config.WKZOB.Name.EO23 = S7.GetStringAt(buffer, 1104);
                Config.WKZOB.Name.EO24 = S7.GetStringAt(buffer, 1126);
                Config.WKZOB.Name.EO25 = S7.GetStringAt(buffer, 1148);
                Config.WKZOB.Name.EO26 = S7.GetStringAt(buffer, 1170);
                Config.WKZOB.Name.EO27 = S7.GetStringAt(buffer, 1192);
                Config.WKZOB.Name.EO28 = S7.GetStringAt(buffer, 1214);
                Config.WKZOB.Name.EO29 = S7.GetStringAt(buffer, 1236);
                Config.WKZOB.Name.EO30 = S7.GetStringAt(buffer, 1258);
                Config.WKZOB.Name.EO31 = S7.GetStringAt(buffer, 1280);
                Config.WKZOB.Name.EO32 = S7.GetStringAt(buffer, 1302);
                Config.WKZOB.Name.VO121 = S7.GetStringAt(buffer, 1324);
                Config.WKZOB.Name.VO141 = S7.GetStringAt(buffer, 1346);
                Config.WKZOB.Name.VO122 = S7.GetStringAt(buffer, 1368);
                Config.WKZOB.Name.VO142 = S7.GetStringAt(buffer, 1390);
                Config.WKZOB.Name.VO123 = S7.GetStringAt(buffer, 1412);
                Config.WKZOB.Name.VO143 = S7.GetStringAt(buffer, 1434);
                Config.WKZOB.Name.VO124 = S7.GetStringAt(buffer, 1456);
                Config.WKZOB.Name.VO144 = S7.GetStringAt(buffer, 1478);
                Config.WKZOB.Name.VO125 = S7.GetStringAt(buffer, 1500);
                Config.WKZOB.Name.VO145 = S7.GetStringAt(buffer, 1522);
                Config.WKZOB.Name.VO126 = S7.GetStringAt(buffer, 1544);
                Config.WKZOB.Name.VO146 = S7.GetStringAt(buffer, 1566);
                Config.WKZOB.Name.VO127 = S7.GetStringAt(buffer, 1588);
                Config.WKZOB.Name.VO147 = S7.GetStringAt(buffer, 1610);
                Config.WKZOB.Name.VO128 = S7.GetStringAt(buffer, 1632);
                Config.WKZOB.Name.VO148 = S7.GetStringAt(buffer, 1654);
                Config.WKZOB.Time.TVO121 = S7.GetIntAt(buffer, 1676);
                Config.WKZOB.Time.TVO141 = S7.GetIntAt(buffer, 1678);
                Config.WKZOB.Time.TVO122 = S7.GetIntAt(buffer, 1680);
                Config.WKZOB.Time.TVO142 = S7.GetIntAt(buffer, 1682);
                Config.WKZOB.Time.TVO123 = S7.GetIntAt(buffer, 1684);
                Config.WKZOB.Time.TVO143 = S7.GetIntAt(buffer, 1686);
                Config.WKZOB.Time.TVO124 = S7.GetIntAt(buffer, 1688);
                Config.WKZOB.Time.TVO144 = S7.GetIntAt(buffer, 1690);
                Config.WKZOB.Time.TVO125 = S7.GetIntAt(buffer, 1692);
                Config.WKZOB.Time.TVO145 = S7.GetIntAt(buffer, 1694);
                Config.WKZOB.Time.TVO126 = S7.GetIntAt(buffer, 1696);
                Config.WKZOB.Time.TVO146 = S7.GetIntAt(buffer, 1698);
                Config.WKZOB.Time.TVO127 = S7.GetIntAt(buffer, 1700);
                Config.WKZOB.Time.TVO147 = S7.GetIntAt(buffer, 1702);
                Config.WKZOB.Time.TVO128 = S7.GetIntAt(buffer, 1704);
                Config.WKZOB.Time.TVO148 = S7.GetIntAt(buffer, 1706);
                Config.WKZUN.Name.EO01 = S7.GetStringAt(buffer, 1708);
                Config.WKZUN.Name.EO02 = S7.GetStringAt(buffer, 1730);
                Config.WKZUN.Name.EO03 = S7.GetStringAt(buffer, 1752);
                Config.WKZUN.Name.EO04 = S7.GetStringAt(buffer, 1774);
                Config.WKZUN.Name.EO05 = S7.GetStringAt(buffer, 1796);
                Config.WKZUN.Name.EO06 = S7.GetStringAt(buffer, 1818);
                Config.WKZUN.Name.EO07 = S7.GetStringAt(buffer, 1840);
                Config.WKZUN.Name.EO08 = S7.GetStringAt(buffer, 1862);
                Config.WKZUN.Name.EO09 = S7.GetStringAt(buffer, 1884);
                Config.WKZUN.Name.EO10 = S7.GetStringAt(buffer, 1906);
                Config.WKZUN.Name.EO11 = S7.GetStringAt(buffer, 1928);
                Config.WKZUN.Name.EO12 = S7.GetStringAt(buffer, 1950);
                Config.WKZUN.Name.EO13 = S7.GetStringAt(buffer, 1972);
                Config.WKZUN.Name.EO14 = S7.GetStringAt(buffer, 1994);
                Config.WKZUN.Name.EO15 = S7.GetStringAt(buffer, 2016);
                Config.WKZUN.Name.EO16 = S7.GetStringAt(buffer, 2038);
                Config.WKZUN.Name.EO17 = S7.GetStringAt(buffer, 2060);
                Config.WKZUN.Name.EO18 = S7.GetStringAt(buffer, 2082);
                Config.WKZUN.Name.EO19 = S7.GetStringAt(buffer, 2104);
                Config.WKZUN.Name.EO20 = S7.GetStringAt(buffer, 2126);
                Config.WKZUN.Name.EO21 = S7.GetStringAt(buffer, 2148);
                Config.WKZUN.Name.EO22 = S7.GetStringAt(buffer, 2170);
                Config.WKZUN.Name.EO23 = S7.GetStringAt(buffer, 2192);
                Config.WKZUN.Name.EO24 = S7.GetStringAt(buffer, 2214);
                Config.WKZUN.Name.EO25 = S7.GetStringAt(buffer, 2236);
                Config.WKZUN.Name.EO26 = S7.GetStringAt(buffer, 2258);
                Config.WKZUN.Name.EO27 = S7.GetStringAt(buffer, 2280);
                Config.WKZUN.Name.EO28 = S7.GetStringAt(buffer, 2302);
                Config.WKZUN.Name.EO29 = S7.GetStringAt(buffer, 2324);
                Config.WKZUN.Name.EO30 = S7.GetStringAt(buffer, 2346);
                Config.WKZUN.Name.EO31 = S7.GetStringAt(buffer, 2368);
                Config.WKZUN.Name.EO32 = S7.GetStringAt(buffer, 2390);
                Config.WKZUN.Name.VO121 = S7.GetStringAt(buffer, 2412);
                Config.WKZUN.Name.VO141 = S7.GetStringAt(buffer, 2434);
                Config.WKZUN.Name.VO122 = S7.GetStringAt(buffer, 2456);
                Config.WKZUN.Name.VO142 = S7.GetStringAt(buffer, 2478);
                Config.WKZUN.Name.VO123 = S7.GetStringAt(buffer, 2500);
                Config.WKZUN.Name.VO143 = S7.GetStringAt(buffer, 2522);
                Config.WKZUN.Name.VO124 = S7.GetStringAt(buffer, 2544);
                Config.WKZUN.Name.VO144 = S7.GetStringAt(buffer, 2566);
                Config.WKZUN.Name.VO125 = S7.GetStringAt(buffer, 2588);
                Config.WKZUN.Name.VO145 = S7.GetStringAt(buffer, 2610);
                Config.WKZUN.Name.VO126 = S7.GetStringAt(buffer, 2632);
                Config.WKZUN.Name.VO146 = S7.GetStringAt(buffer, 2654);
                Config.WKZUN.Name.VO127 = S7.GetStringAt(buffer, 2676);
                Config.WKZUN.Name.VO147 = S7.GetStringAt(buffer, 2698);
                Config.WKZUN.Name.VO128 = S7.GetStringAt(buffer, 2720);
                Config.WKZUN.Name.VO148 = S7.GetStringAt(buffer, 2742);
                Config.WKZUN.Time.TVO121 = S7.GetIntAt(buffer, 2764);
                Config.WKZUN.Time.TVO141 = S7.GetIntAt(buffer, 2766);
                Config.WKZUN.Time.TVO122 = S7.GetIntAt(buffer, 2768);
                Config.WKZUN.Time.TVO142 = S7.GetIntAt(buffer, 2770);
                Config.WKZUN.Time.TVO123 = S7.GetIntAt(buffer, 2772);
                Config.WKZUN.Time.TVO143 = S7.GetIntAt(buffer, 2774);
                Config.WKZUN.Time.TVO124 = S7.GetIntAt(buffer, 2776);
                Config.WKZUN.Time.TVO144 = S7.GetIntAt(buffer, 2778);
                Config.WKZUN.Time.TVO125 = S7.GetIntAt(buffer, 2780);
                Config.WKZUN.Time.TVO145 = S7.GetIntAt(buffer, 2782);
                Config.WKZUN.Time.TVO126 = S7.GetIntAt(buffer, 2784);
                Config.WKZUN.Time.TVO146 = S7.GetIntAt(buffer, 2786);
                Config.WKZUN.Time.TVO127 = S7.GetIntAt(buffer, 2788);
                Config.WKZUN.Time.TVO147 = S7.GetIntAt(buffer, 2790);
                Config.WKZUN.Time.TVO128 = S7.GetIntAt(buffer, 2792);
                Config.WKZUN.Time.TVO148 = S7.GetIntAt(buffer, 2794);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
                //throw;
            }

            return Config;
        }
        public static void SerializeDatConfig(DatConfig Config, string path, ref string error)
        {
            error = string.Empty;
            //create instance
            //DatConfig Config = new DatConfig();

            try
            {
                // XmlSerializer writes object data as XML
                XmlSerializer serializer = new XmlSerializer(typeof(DatConfig));
                using (TextWriter writer = new StreamWriter(path + "\\Config.xml"))
                {
                    serializer.Serialize(writer, Config);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString() + " " + path + "\\Config.xml";
                //throw;
            }
            //return value
            //return Config;
        }
        public static DatConfig DeserializeDatConfig(string path, ref string error)
        {
            //create instance
            DatConfig Config = new DatConfig();
            try
            {
                // Deserialize from XML to the object
                XmlSerializer deserializer = new XmlSerializer(typeof(DatConfig));
                TextReader reader = new StreamReader(path + "\\Config.xml");
                object obj = deserializer.Deserialize(reader);
                Config = (DatConfig)obj;
                reader.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString() + " " + path + "\\Config.xml";
                //throw;
            }
            //return value
            return Config;
        }
        #endregion



        #region DatN2
        public static void DatN2ToBuffer(DatN2 N2, byte[] buffer, ref string error)
        {
            try
            {
                //clear buffer before use
                Array.Clear(buffer, 0, buffer.Length);

                S7.SetRealAt(buffer, 0, (float)N2.Propventil01.Soll);
                S7.SetRealAt(buffer, 4, (float)N2.Propventil01.ToleranzPlus);
                S7.SetRealAt(buffer, 8, (float)N2.Propventil01.ToleranzMinus);
                S7.SetRealAt(buffer, 12, (float)N2.Propventil01.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 16, (float)N2.Propventil02.Soll);
                S7.SetRealAt(buffer, 20, (float)N2.Propventil02.ToleranzPlus);
                S7.SetRealAt(buffer, 24, (float)N2.Propventil02.ToleranzMinus);
                S7.SetRealAt(buffer, 28, (float)N2.Propventil02.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 32, (float)N2.Propventil03.Soll);
                S7.SetRealAt(buffer, 36, (float)N2.Propventil03.ToleranzPlus);
                S7.SetRealAt(buffer, 40, (float)N2.Propventil03.ToleranzMinus);
                S7.SetRealAt(buffer, 44, (float)N2.Propventil03.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 48, (float)N2.Propventil04.Soll);
                S7.SetRealAt(buffer, 52, (float)N2.Propventil04.ToleranzPlus);
                S7.SetRealAt(buffer, 56, (float)N2.Propventil04.ToleranzMinus);
                S7.SetRealAt(buffer, 60, (float)N2.Propventil04.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 64, (float)N2.Propventil05.Soll);
                S7.SetRealAt(buffer, 68, (float)N2.Propventil05.ToleranzPlus);
                S7.SetRealAt(buffer, 72, (float)N2.Propventil05.ToleranzMinus);
                S7.SetRealAt(buffer, 76, (float)N2.Propventil05.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 80, (float)N2.Propventil06.Soll);
                S7.SetRealAt(buffer, 84, (float)N2.Propventil06.ToleranzPlus);
                S7.SetRealAt(buffer, 88, (float)N2.Propventil06.ToleranzMinus);
                S7.SetRealAt(buffer, 92, (float)N2.Propventil06.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 96, (float)N2.Propventil07.Soll);
                S7.SetRealAt(buffer, 100, (float)N2.Propventil07.ToleranzPlus);
                S7.SetRealAt(buffer, 104, (float)N2.Propventil07.ToleranzMinus);
                S7.SetRealAt(buffer, 108, (float)N2.Propventil07.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 112, (float)N2.Propventil08.Soll);
                S7.SetRealAt(buffer, 116, (float)N2.Propventil08.ToleranzPlus);
                S7.SetRealAt(buffer, 120, (float)N2.Propventil08.ToleranzMinus);
                S7.SetRealAt(buffer, 124, (float)N2.Propventil08.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 128, (float)N2.Propventil09.Soll);
                S7.SetRealAt(buffer, 132, (float)N2.Propventil09.ToleranzPlus);
                S7.SetRealAt(buffer, 136, (float)N2.Propventil09.ToleranzMinus);
                S7.SetRealAt(buffer, 140, (float)N2.Propventil09.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 144, (float)N2.Propventil10.Soll);
                S7.SetRealAt(buffer, 148, (float)N2.Propventil10.ToleranzPlus);
                S7.SetRealAt(buffer, 152, (float)N2.Propventil10.ToleranzMinus);
                S7.SetRealAt(buffer, 156, (float)N2.Propventil10.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 160, (float)N2.Propventil11.Soll);
                S7.SetRealAt(buffer, 164, (float)N2.Propventil11.ToleranzPlus);
                S7.SetRealAt(buffer, 168, (float)N2.Propventil11.ToleranzMinus);
                S7.SetRealAt(buffer, 172, (float)N2.Propventil11.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 176, (float)N2.Propventil12.Soll);
                S7.SetRealAt(buffer, 180, (float)N2.Propventil12.ToleranzPlus);
                S7.SetRealAt(buffer, 184, (float)N2.Propventil12.ToleranzMinus);
                S7.SetRealAt(buffer, 188, (float)N2.Propventil12.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 192, (float)N2.Propventil13.Soll);
                S7.SetRealAt(buffer, 196, (float)N2.Propventil13.ToleranzPlus);
                S7.SetRealAt(buffer, 200, (float)N2.Propventil13.ToleranzMinus);
                S7.SetRealAt(buffer, 204, (float)N2.Propventil13.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 208, (float)N2.Propventil14.Soll);
                S7.SetRealAt(buffer, 212, (float)N2.Propventil14.ToleranzPlus);
                S7.SetRealAt(buffer, 216, (float)N2.Propventil14.ToleranzMinus);
                S7.SetRealAt(buffer, 220, (float)N2.Propventil14.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 224, (float)N2.Propventil15.Soll);
                S7.SetRealAt(buffer, 228, (float)N2.Propventil15.ToleranzPlus);
                S7.SetRealAt(buffer, 232, (float)N2.Propventil15.ToleranzMinus);
                S7.SetRealAt(buffer, 236, (float)N2.Propventil15.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 240, (float)N2.Propventil16.Soll);
                S7.SetRealAt(buffer, 244, (float)N2.Propventil16.ToleranzPlus);
                S7.SetRealAt(buffer, 248, (float)N2.Propventil16.ToleranzMinus);
                S7.SetRealAt(buffer, 252, (float)N2.Propventil16.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 256, (float)N2.Propventil17.Soll);
                S7.SetRealAt(buffer, 260, (float)N2.Propventil17.ToleranzPlus);
                S7.SetRealAt(buffer, 264, (float)N2.Propventil17.ToleranzMinus);
                S7.SetRealAt(buffer, 268, (float)N2.Propventil17.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 272, (float)N2.Propventil18.Soll);
                S7.SetRealAt(buffer, 276, (float)N2.Propventil18.ToleranzPlus);
                S7.SetRealAt(buffer, 280, (float)N2.Propventil18.ToleranzMinus);
                S7.SetRealAt(buffer, 284, (float)N2.Propventil18.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 288, (float)N2.Propventil19.Soll);
                S7.SetRealAt(buffer, 292, (float)N2.Propventil19.ToleranzPlus);
                S7.SetRealAt(buffer, 296, (float)N2.Propventil19.ToleranzMinus);
                S7.SetRealAt(buffer, 300, (float)N2.Propventil19.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 304, (float)N2.Propventil20.Soll);
                S7.SetRealAt(buffer, 308, (float)N2.Propventil20.ToleranzPlus);
                S7.SetRealAt(buffer, 312, (float)N2.Propventil20.ToleranzMinus);
                S7.SetRealAt(buffer, 316, (float)N2.Propventil20.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 320, (float)N2.Propventil21.Soll);
                S7.SetRealAt(buffer, 324, (float)N2.Propventil21.ToleranzPlus);
                S7.SetRealAt(buffer, 328, (float)N2.Propventil21.ToleranzMinus);
                S7.SetRealAt(buffer, 332, (float)N2.Propventil21.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 336, (float)N2.Propventil22.Soll);
                S7.SetRealAt(buffer, 340, (float)N2.Propventil22.ToleranzPlus);
                S7.SetRealAt(buffer, 344, (float)N2.Propventil22.ToleranzMinus);
                S7.SetRealAt(buffer, 348, (float)N2.Propventil22.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 352, (float)N2.Propventil23.Soll);
                S7.SetRealAt(buffer, 356, (float)N2.Propventil23.ToleranzPlus);
                S7.SetRealAt(buffer, 360, (float)N2.Propventil23.ToleranzMinus);
                S7.SetRealAt(buffer, 364, (float)N2.Propventil23.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 368, (float)N2.Propventil24.Soll);
                S7.SetRealAt(buffer, 372, (float)N2.Propventil24.ToleranzPlus);
                S7.SetRealAt(buffer, 376, (float)N2.Propventil24.ToleranzMinus);
                S7.SetRealAt(buffer, 380, (float)N2.Propventil24.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 384, (float)N2.Propventil25.Soll);
                S7.SetRealAt(buffer, 388, (float)N2.Propventil25.ToleranzPlus);
                S7.SetRealAt(buffer, 392, (float)N2.Propventil25.ToleranzMinus);
                S7.SetRealAt(buffer, 396, (float)N2.Propventil25.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 400, (float)N2.Propventil26.Soll);
                S7.SetRealAt(buffer, 404, (float)N2.Propventil26.ToleranzPlus);
                S7.SetRealAt(buffer, 408, (float)N2.Propventil26.ToleranzMinus);
                S7.SetRealAt(buffer, 412, (float)N2.Propventil26.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 416, (float)N2.Propventil27.Soll);
                S7.SetRealAt(buffer, 420, (float)N2.Propventil27.ToleranzPlus);
                S7.SetRealAt(buffer, 424, (float)N2.Propventil27.ToleranzMinus);
                S7.SetRealAt(buffer, 428, (float)N2.Propventil27.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 432, (float)N2.Propventil28.Soll);
                S7.SetRealAt(buffer, 436, (float)N2.Propventil28.ToleranzPlus);
                S7.SetRealAt(buffer, 440, (float)N2.Propventil28.ToleranzMinus);
                S7.SetRealAt(buffer, 444, (float)N2.Propventil28.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 448, (float)N2.Propventil29.Soll);
                S7.SetRealAt(buffer, 452, (float)N2.Propventil29.ToleranzPlus);
                S7.SetRealAt(buffer, 456, (float)N2.Propventil29.ToleranzMinus);
                S7.SetRealAt(buffer, 460, (float)N2.Propventil29.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 464, (float)N2.Propventil30.Soll);
                S7.SetRealAt(buffer, 468, (float)N2.Propventil30.ToleranzPlus);
                S7.SetRealAt(buffer, 472, (float)N2.Propventil30.ToleranzMinus);
                S7.SetRealAt(buffer, 476, (float)N2.Propventil30.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 480, (float)N2.Propventil31.Soll);
                S7.SetRealAt(buffer, 484, (float)N2.Propventil31.ToleranzPlus);
                S7.SetRealAt(buffer, 488, (float)N2.Propventil31.ToleranzMinus);
                S7.SetRealAt(buffer, 492, (float)N2.Propventil31.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 496, (float)N2.Propventil32.Soll);
                S7.SetRealAt(buffer, 500, (float)N2.Propventil32.ToleranzPlus);
                S7.SetRealAt(buffer, 504, (float)N2.Propventil32.ToleranzMinus);
                S7.SetRealAt(buffer, 508, (float)N2.Propventil32.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 512, (float)N2.Propventil33.Soll);
                S7.SetRealAt(buffer, 516, (float)N2.Propventil33.ToleranzPlus);
                S7.SetRealAt(buffer, 520, (float)N2.Propventil33.ToleranzMinus);
                S7.SetRealAt(buffer, 524, (float)N2.Propventil33.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 528, (float)N2.Propventil34.Soll);
                S7.SetRealAt(buffer, 532, (float)N2.Propventil34.ToleranzPlus);
                S7.SetRealAt(buffer, 536, (float)N2.Propventil34.ToleranzMinus);
                S7.SetRealAt(buffer, 540, (float)N2.Propventil34.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 544, (float)N2.Propventil35.Soll);
                S7.SetRealAt(buffer, 548, (float)N2.Propventil35.ToleranzPlus);
                S7.SetRealAt(buffer, 552, (float)N2.Propventil35.ToleranzMinus);
                S7.SetRealAt(buffer, 556, (float)N2.Propventil35.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 560, (float)N2.Propventil36.Soll);
                S7.SetRealAt(buffer, 564, (float)N2.Propventil36.ToleranzPlus);
                S7.SetRealAt(buffer, 568, (float)N2.Propventil36.ToleranzMinus);
                S7.SetRealAt(buffer, 572, (float)N2.Propventil36.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 576, (float)N2.Propventil37.Soll);
                S7.SetRealAt(buffer, 580, (float)N2.Propventil37.ToleranzPlus);
                S7.SetRealAt(buffer, 584, (float)N2.Propventil37.ToleranzMinus);
                S7.SetRealAt(buffer, 588, (float)N2.Propventil37.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 592, (float)N2.Propventil38.Soll);
                S7.SetRealAt(buffer, 596, (float)N2.Propventil38.ToleranzPlus);
                S7.SetRealAt(buffer, 600, (float)N2.Propventil38.ToleranzMinus);
                S7.SetRealAt(buffer, 604, (float)N2.Propventil38.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 608, (float)N2.Propventil39.Soll);
                S7.SetRealAt(buffer, 612, (float)N2.Propventil39.ToleranzPlus);
                S7.SetRealAt(buffer, 616, (float)N2.Propventil39.ToleranzMinus);
                S7.SetRealAt(buffer, 620, (float)N2.Propventil39.Einschaltverzoegerung);
                S7.SetRealAt(buffer, 624, (float)N2.Propventil40.Soll);
                S7.SetRealAt(buffer, 628, (float)N2.Propventil40.ToleranzPlus);
                S7.SetRealAt(buffer, 632, (float)N2.Propventil40.ToleranzMinus);
                S7.SetRealAt(buffer, 636, (float)N2.Propventil40.Einschaltverzoegerung);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
                //throw;
            }
        }
        public static DatN2 BufferToDatN2(byte[] buffer, ref string error)
        {
            error = string.Empty;
            //create instance
            DatN2 N2 = new DatN2();

            try
            {
                N2.Propventil01.Soll = S7.GetRealAt(buffer, 0);
                N2.Propventil01.ToleranzPlus = S7.GetRealAt(buffer, 4);
                N2.Propventil01.ToleranzMinus = S7.GetRealAt(buffer, 8);
                N2.Propventil01.Einschaltverzoegerung = S7.GetRealAt(buffer, 12);
                N2.Propventil02.Soll = S7.GetRealAt(buffer, 16);
                N2.Propventil02.ToleranzPlus = S7.GetRealAt(buffer, 20);
                N2.Propventil02.ToleranzMinus = S7.GetRealAt(buffer, 24);
                N2.Propventil02.Einschaltverzoegerung = S7.GetRealAt(buffer, 28);
                N2.Propventil03.Soll = S7.GetRealAt(buffer, 32);
                N2.Propventil03.ToleranzPlus = S7.GetRealAt(buffer, 36);
                N2.Propventil03.ToleranzMinus = S7.GetRealAt(buffer, 40);
                N2.Propventil03.Einschaltverzoegerung = S7.GetRealAt(buffer, 44);
                N2.Propventil04.Soll = S7.GetRealAt(buffer, 48);
                N2.Propventil04.ToleranzPlus = S7.GetRealAt(buffer, 52);
                N2.Propventil04.ToleranzMinus = S7.GetRealAt(buffer, 56);
                N2.Propventil04.Einschaltverzoegerung = S7.GetRealAt(buffer, 60);
                N2.Propventil05.Soll = S7.GetRealAt(buffer, 64);
                N2.Propventil05.ToleranzPlus = S7.GetRealAt(buffer, 68);
                N2.Propventil05.ToleranzMinus = S7.GetRealAt(buffer, 72);
                N2.Propventil05.Einschaltverzoegerung = S7.GetRealAt(buffer, 76);
                N2.Propventil06.Soll = S7.GetRealAt(buffer, 80);
                N2.Propventil06.ToleranzPlus = S7.GetRealAt(buffer, 84);
                N2.Propventil06.ToleranzMinus = S7.GetRealAt(buffer, 88);
                N2.Propventil06.Einschaltverzoegerung = S7.GetRealAt(buffer, 92);
                N2.Propventil07.Soll = S7.GetRealAt(buffer, 96);
                N2.Propventil07.ToleranzPlus = S7.GetRealAt(buffer, 100);
                N2.Propventil07.ToleranzMinus = S7.GetRealAt(buffer, 104);
                N2.Propventil07.Einschaltverzoegerung = S7.GetRealAt(buffer, 108);
                N2.Propventil08.Soll = S7.GetRealAt(buffer, 112);
                N2.Propventil08.ToleranzPlus = S7.GetRealAt(buffer, 116);
                N2.Propventil08.ToleranzMinus = S7.GetRealAt(buffer, 120);
                N2.Propventil08.Einschaltverzoegerung = S7.GetRealAt(buffer, 124);
                N2.Propventil09.Soll = S7.GetRealAt(buffer, 128);
                N2.Propventil09.ToleranzPlus = S7.GetRealAt(buffer, 132);
                N2.Propventil09.ToleranzMinus = S7.GetRealAt(buffer, 136);
                N2.Propventil09.Einschaltverzoegerung = S7.GetRealAt(buffer, 140);
                N2.Propventil10.Soll = S7.GetRealAt(buffer, 144);
                N2.Propventil10.ToleranzPlus = S7.GetRealAt(buffer, 148);
                N2.Propventil10.ToleranzMinus = S7.GetRealAt(buffer, 152);
                N2.Propventil10.Einschaltverzoegerung = S7.GetRealAt(buffer, 156);
                N2.Propventil11.Soll = S7.GetRealAt(buffer, 160);
                N2.Propventil11.ToleranzPlus = S7.GetRealAt(buffer, 164);
                N2.Propventil11.ToleranzMinus = S7.GetRealAt(buffer, 168);
                N2.Propventil11.Einschaltverzoegerung = S7.GetRealAt(buffer, 172);
                N2.Propventil12.Soll = S7.GetRealAt(buffer, 176);
                N2.Propventil12.ToleranzPlus = S7.GetRealAt(buffer, 180);
                N2.Propventil12.ToleranzMinus = S7.GetRealAt(buffer, 184);
                N2.Propventil12.Einschaltverzoegerung = S7.GetRealAt(buffer, 188);
                N2.Propventil13.Soll = S7.GetRealAt(buffer, 192);
                N2.Propventil13.ToleranzPlus = S7.GetRealAt(buffer, 196);
                N2.Propventil13.ToleranzMinus = S7.GetRealAt(buffer, 200);
                N2.Propventil13.Einschaltverzoegerung = S7.GetRealAt(buffer, 204);
                N2.Propventil14.Soll = S7.GetRealAt(buffer, 208);
                N2.Propventil14.ToleranzPlus = S7.GetRealAt(buffer, 212);
                N2.Propventil14.ToleranzMinus = S7.GetRealAt(buffer, 216);
                N2.Propventil14.Einschaltverzoegerung = S7.GetRealAt(buffer, 220);
                N2.Propventil15.Soll = S7.GetRealAt(buffer, 224);
                N2.Propventil15.ToleranzPlus = S7.GetRealAt(buffer, 228);
                N2.Propventil15.ToleranzMinus = S7.GetRealAt(buffer, 232);
                N2.Propventil15.Einschaltverzoegerung = S7.GetRealAt(buffer, 236);
                N2.Propventil16.Soll = S7.GetRealAt(buffer, 240);
                N2.Propventil16.ToleranzPlus = S7.GetRealAt(buffer, 244);
                N2.Propventil16.ToleranzMinus = S7.GetRealAt(buffer, 248);
                N2.Propventil16.Einschaltverzoegerung = S7.GetRealAt(buffer, 252);
                N2.Propventil17.Soll = S7.GetRealAt(buffer, 256);
                N2.Propventil17.ToleranzPlus = S7.GetRealAt(buffer, 260);
                N2.Propventil17.ToleranzMinus = S7.GetRealAt(buffer, 264);
                N2.Propventil17.Einschaltverzoegerung = S7.GetRealAt(buffer, 268);
                N2.Propventil18.Soll = S7.GetRealAt(buffer, 272);
                N2.Propventil18.ToleranzPlus = S7.GetRealAt(buffer, 276);
                N2.Propventil18.ToleranzMinus = S7.GetRealAt(buffer, 280);
                N2.Propventil18.Einschaltverzoegerung = S7.GetRealAt(buffer, 284);
                N2.Propventil19.Soll = S7.GetRealAt(buffer, 288);
                N2.Propventil19.ToleranzPlus = S7.GetRealAt(buffer, 292);
                N2.Propventil19.ToleranzMinus = S7.GetRealAt(buffer, 296);
                N2.Propventil19.Einschaltverzoegerung = S7.GetRealAt(buffer, 300);
                N2.Propventil20.Soll = S7.GetRealAt(buffer, 304);
                N2.Propventil20.ToleranzPlus = S7.GetRealAt(buffer, 308);
                N2.Propventil20.ToleranzMinus = S7.GetRealAt(buffer, 312);
                N2.Propventil20.Einschaltverzoegerung = S7.GetRealAt(buffer, 316);
                N2.Propventil21.Soll = S7.GetRealAt(buffer, 320);
                N2.Propventil21.ToleranzPlus = S7.GetRealAt(buffer, 324);
                N2.Propventil21.ToleranzMinus = S7.GetRealAt(buffer, 328);
                N2.Propventil21.Einschaltverzoegerung = S7.GetRealAt(buffer, 332);
                N2.Propventil22.Soll = S7.GetRealAt(buffer, 336);
                N2.Propventil22.ToleranzPlus = S7.GetRealAt(buffer, 340);
                N2.Propventil22.ToleranzMinus = S7.GetRealAt(buffer, 344);
                N2.Propventil22.Einschaltverzoegerung = S7.GetRealAt(buffer, 348);
                N2.Propventil23.Soll = S7.GetRealAt(buffer, 352);
                N2.Propventil23.ToleranzPlus = S7.GetRealAt(buffer, 356);
                N2.Propventil23.ToleranzMinus = S7.GetRealAt(buffer, 360);
                N2.Propventil23.Einschaltverzoegerung = S7.GetRealAt(buffer, 364);
                N2.Propventil24.Soll = S7.GetRealAt(buffer, 368);
                N2.Propventil24.ToleranzPlus = S7.GetRealAt(buffer, 372);
                N2.Propventil24.ToleranzMinus = S7.GetRealAt(buffer, 376);
                N2.Propventil24.Einschaltverzoegerung = S7.GetRealAt(buffer, 380);
                N2.Propventil25.Soll = S7.GetRealAt(buffer, 384);
                N2.Propventil25.ToleranzPlus = S7.GetRealAt(buffer, 388);
                N2.Propventil25.ToleranzMinus = S7.GetRealAt(buffer, 392);
                N2.Propventil25.Einschaltverzoegerung = S7.GetRealAt(buffer, 396);
                N2.Propventil26.Soll = S7.GetRealAt(buffer, 400);
                N2.Propventil26.ToleranzPlus = S7.GetRealAt(buffer, 404);
                N2.Propventil26.ToleranzMinus = S7.GetRealAt(buffer, 408);
                N2.Propventil26.Einschaltverzoegerung = S7.GetRealAt(buffer, 412);
                N2.Propventil27.Soll = S7.GetRealAt(buffer, 416);
                N2.Propventil27.ToleranzPlus = S7.GetRealAt(buffer, 420);
                N2.Propventil27.ToleranzMinus = S7.GetRealAt(buffer, 424);
                N2.Propventil27.Einschaltverzoegerung = S7.GetRealAt(buffer, 428);
                N2.Propventil28.Soll = S7.GetRealAt(buffer, 432);
                N2.Propventil28.ToleranzPlus = S7.GetRealAt(buffer, 436);
                N2.Propventil28.ToleranzMinus = S7.GetRealAt(buffer, 440);
                N2.Propventil28.Einschaltverzoegerung = S7.GetRealAt(buffer, 444);
                N2.Propventil29.Soll = S7.GetRealAt(buffer, 448);
                N2.Propventil29.ToleranzPlus = S7.GetRealAt(buffer, 452);
                N2.Propventil29.ToleranzMinus = S7.GetRealAt(buffer, 456);
                N2.Propventil29.Einschaltverzoegerung = S7.GetRealAt(buffer, 460);
                N2.Propventil30.Soll = S7.GetRealAt(buffer, 464);
                N2.Propventil30.ToleranzPlus = S7.GetRealAt(buffer, 468);
                N2.Propventil30.ToleranzMinus = S7.GetRealAt(buffer, 472);
                N2.Propventil30.Einschaltverzoegerung = S7.GetRealAt(buffer, 476);
                N2.Propventil31.Soll = S7.GetRealAt(buffer, 480);
                N2.Propventil31.ToleranzPlus = S7.GetRealAt(buffer, 484);
                N2.Propventil31.ToleranzMinus = S7.GetRealAt(buffer, 488);
                N2.Propventil31.Einschaltverzoegerung = S7.GetRealAt(buffer, 492);
                N2.Propventil32.Soll = S7.GetRealAt(buffer, 496);
                N2.Propventil32.ToleranzPlus = S7.GetRealAt(buffer, 500);
                N2.Propventil32.ToleranzMinus = S7.GetRealAt(buffer, 504);
                N2.Propventil32.Einschaltverzoegerung = S7.GetRealAt(buffer, 508);
                N2.Propventil33.Soll = S7.GetRealAt(buffer, 512);
                N2.Propventil33.ToleranzPlus = S7.GetRealAt(buffer, 516);
                N2.Propventil33.ToleranzMinus = S7.GetRealAt(buffer, 520);
                N2.Propventil33.Einschaltverzoegerung = S7.GetRealAt(buffer, 524);
                N2.Propventil34.Soll = S7.GetRealAt(buffer, 528);
                N2.Propventil34.ToleranzPlus = S7.GetRealAt(buffer, 532);
                N2.Propventil34.ToleranzMinus = S7.GetRealAt(buffer, 536);
                N2.Propventil34.Einschaltverzoegerung = S7.GetRealAt(buffer, 540);
                N2.Propventil35.Soll = S7.GetRealAt(buffer, 544);
                N2.Propventil35.ToleranzPlus = S7.GetRealAt(buffer, 548);
                N2.Propventil35.ToleranzMinus = S7.GetRealAt(buffer, 552);
                N2.Propventil35.Einschaltverzoegerung = S7.GetRealAt(buffer, 556);
                N2.Propventil36.Soll = S7.GetRealAt(buffer, 560);
                N2.Propventil36.ToleranzPlus = S7.GetRealAt(buffer, 564);
                N2.Propventil36.ToleranzMinus = S7.GetRealAt(buffer, 568);
                N2.Propventil36.Einschaltverzoegerung = S7.GetRealAt(buffer, 572);
                N2.Propventil37.Soll = S7.GetRealAt(buffer, 576);
                N2.Propventil37.ToleranzPlus = S7.GetRealAt(buffer, 580);
                N2.Propventil37.ToleranzMinus = S7.GetRealAt(buffer, 584);
                N2.Propventil37.Einschaltverzoegerung = S7.GetRealAt(buffer, 588);
                N2.Propventil38.Soll = S7.GetRealAt(buffer, 592);
                N2.Propventil38.ToleranzPlus = S7.GetRealAt(buffer, 596);
                N2.Propventil38.ToleranzMinus = S7.GetRealAt(buffer, 600);
                N2.Propventil38.Einschaltverzoegerung = S7.GetRealAt(buffer, 604);
                N2.Propventil39.Soll = S7.GetRealAt(buffer, 608);
                N2.Propventil39.ToleranzPlus = S7.GetRealAt(buffer, 612);
                N2.Propventil39.ToleranzMinus = S7.GetRealAt(buffer, 616);
                N2.Propventil39.Einschaltverzoegerung = S7.GetRealAt(buffer, 620);
                N2.Propventil40.Soll = S7.GetRealAt(buffer, 624);
                N2.Propventil40.ToleranzPlus = S7.GetRealAt(buffer, 628);
                N2.Propventil40.ToleranzMinus = S7.GetRealAt(buffer, 632);
                N2.Propventil40.Einschaltverzoegerung = S7.GetRealAt(buffer, 636);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
                //throw;
            }

            return N2;
        }
        public static void SerializeDatN2(DatN2 N2, string path, ref string error)
        {
            error = string.Empty;
            //create instance
            //DatN2 N2 = new DatN2();

            try
            {
                // XmlSerializer writes object data as XML
                XmlSerializer serializer = new XmlSerializer(typeof(DatN2));
                using (TextWriter writer = new StreamWriter(path + "\\N2.xml"))
                {
                    serializer.Serialize(writer, N2);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString() + " " + path + "\\N2.xml";
                //throw;
            }
            //return value
            //return N2;
        }
        public static DatN2 DeserializeDatN2(string path, ref string error)
        {
            //create instance
            DatN2 N2 = new DatN2();
            try
            {
                // Deserialize from XML to the object
                XmlSerializer deserializer = new XmlSerializer(typeof(DatN2));
                TextReader reader = new StreamReader(path + "\\N2.xml");
                object obj = deserializer.Deserialize(reader);
                N2 = (DatN2)obj;
                reader.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString() + " " + path + "\\N2.xml";
                //throw;
            }
            //return value
            return N2;
        }
        #endregion



        #region Werkzeug
        public static void DatWerkzeugToBuffer(DatWerkzeug Werkzeug, byte[] buffer, ref string error)
        {
            try
            {
                //clear buffer before use
                Array.Clear(buffer, 0, buffer.Length);

                S7.SetStringAt(buffer, 0, 40, Werkzeug.Kennung.ProgrammName);
                S7.SetByteAt(buffer, 42, Werkzeug.Kennung.RFIDHE);
                S7.SetByteAt(buffer, 43, Werkzeug.Kennung.RFIDOB);
                S7.SetByteAt(buffer, 44, Werkzeug.Kennung.RFIDUN);
                S7.SetBitAt(ref buffer, 46, 0, Werkzeug.AktivierungSchritte.SpannenT1);
                S7.SetBitAt(ref buffer, 46, 1, Werkzeug.AktivierungSchritte.SpannenT2);
                S7.SetBitAt(ref buffer, 46, 2, Werkzeug.AktivierungSchritte.Abholtakt);
                S7.SetBitAt(ref buffer, 46, 3, Werkzeug.AktivierungSchritte.Prueftakt);
                S7.SetBitAt(ref buffer, 46, 4, Werkzeug.AktivierungSchritte.WarmVor);
                S7.SetBitAt(ref buffer, 46, 5, Werkzeug.AktivierungSchritte.WarmEnde);
                S7.SetBitAt(ref buffer, 46, 6, Werkzeug.AktivierungSchritte.Auswerfer);
                S7.SetBitAt(ref buffer, 46, 7, Werkzeug.AktivierungSchritte.Roboter);
                S7.SetBitAt(ref buffer, 47, 0, Werkzeug.AktivierungSchritte.Reserve4);
                S7.SetBitAt(ref buffer, 47, 1, Werkzeug.AktivierungSchritte.Reserve5);
                S7.SetBitAt(ref buffer, 47, 2, Werkzeug.AktivierungSchritte.Reserve6);
                S7.SetBitAt(ref buffer, 47, 3, Werkzeug.AktivierungSchritte.Reserve7);
                S7.SetBitAt(ref buffer, 47, 4, Werkzeug.AktivierungSchritte.Reserve8);
                S7.SetBitAt(ref buffer, 47, 5, Werkzeug.AktivierungSchritte.Reserve9);
                S7.SetBitAt(ref buffer, 47, 6, Werkzeug.AktivierungSchritte.StopNachFuegen);
                S7.SetBitAt(ref buffer, 47, 7, Werkzeug.AktivierungSchritte.OeffnenNachFuegen);
                S7.SetDIntAt(buffer, 48, Werkzeug.ParameterSchritte.Abhol.A1.VorPosition);
                S7.SetDIntAt(buffer, 52, Werkzeug.ParameterSchritte.Abhol.A1.EndPosition);
                S7.SetDIntAt(buffer, 56, Werkzeug.ParameterSchritte.Abhol.A1.Geschwindigkeit);
                S7.SetDIntAt(buffer, 60, Werkzeug.ParameterSchritte.Abhol.A2.VorPosition);
                S7.SetDIntAt(buffer, 64, Werkzeug.ParameterSchritte.Abhol.A2.EndPosition);
                S7.SetDIntAt(buffer, 68, Werkzeug.ParameterSchritte.Abhol.A2.Geschwindigkeit);
                S7.SetDIntAt(buffer, 72, Werkzeug.ParameterSchritte.HEVorposition.A1.Position);
                S7.SetDIntAt(buffer, 76, Werkzeug.ParameterSchritte.HEVorposition.A1.Geschwindigkeit);
                S7.SetDIntAt(buffer, 80, Werkzeug.ParameterSchritte.HEVorposition.A2.Position);
                S7.SetDIntAt(buffer, 84, Werkzeug.ParameterSchritte.HEVorposition.A2.Geschwindigkeit);
                S7.SetDIntAt(buffer, 88, Werkzeug.ParameterSchritte.Warm1.A1.Position);
                S7.SetDIntAt(buffer, 92, Werkzeug.ParameterSchritte.Warm1.A1.Geschwindigkeit);
                S7.SetDIntAt(buffer, 96, Werkzeug.ParameterSchritte.Warm1.A2.Position);
                S7.SetDIntAt(buffer, 100, Werkzeug.ParameterSchritte.Warm1.A2.Geschwindigkeit);
                S7.SetDIntAt(buffer, 104, Werkzeug.ParameterSchritte.Warm1.A3.Position);
                S7.SetDIntAt(buffer, 108, Werkzeug.ParameterSchritte.Warm1.Zeit);
                S7.SetDIntAt(buffer, 112, Werkzeug.ParameterSchritte.Warm2.A1.Position);
                S7.SetDIntAt(buffer, 116, Werkzeug.ParameterSchritte.Warm2.A1.Geschwindigkeit);
                S7.SetDIntAt(buffer, 120, Werkzeug.ParameterSchritte.Warm2.A2.Position);
                S7.SetDIntAt(buffer, 124, Werkzeug.ParameterSchritte.Warm2.A2.Geschwindigkeit);
                S7.SetDIntAt(buffer, 128, Werkzeug.ParameterSchritte.Warm2.Zeit);
                S7.SetDIntAt(buffer, 132, Werkzeug.ParameterSchritte.Fuege.A1.VorPosition);
                S7.SetDIntAt(buffer, 136, Werkzeug.ParameterSchritte.Fuege.A1.EndPosition);
                S7.SetDIntAt(buffer, 140, Werkzeug.ParameterSchritte.Fuege.A1.Geschwindigkeit);
                S7.SetDIntAt(buffer, 144, Werkzeug.ParameterSchritte.Fuege.A1.OeffnungswegNachFuegen);
                S7.SetDIntAt(buffer, 148, Werkzeug.ParameterSchritte.Fuege.A1.RueckhubGeschwingkeitFuegen);
                S7.SetDIntAt(buffer, 152, Werkzeug.ParameterSchritte.Fuege.A2.VorPosition);
                S7.SetDIntAt(buffer, 156, Werkzeug.ParameterSchritte.Fuege.A2.EndPosition);
                S7.SetDIntAt(buffer, 160, Werkzeug.ParameterSchritte.Fuege.A2.Geschwindigkeit);
                S7.SetDIntAt(buffer, 164, Werkzeug.ParameterSchritte.Fuege.Kuehlzeit);
                S7.SetDIntAt(buffer, 168, Werkzeug.ParameterSchritte.Schmelzbild.A1.Position);
                S7.SetDIntAt(buffer, 172, Werkzeug.ParameterSchritte.Schmelzbild.A1.Geschwindigkeit);
                S7.SetIntAt(buffer, 176, Werkzeug.AchsenStrom.FuegekraftMaxA1);
                S7.SetIntAt(buffer, 178, Werkzeug.AchsenStrom.FuegekraftMinA1);
                S7.SetIntAt(buffer, 180, Werkzeug.AchsenStrom.FuegekraftMaxA2);
                S7.SetIntAt(buffer, 182, Werkzeug.AchsenStrom.FuegekraftMinA2);
                S7.SetByteAt(buffer, 184, Werkzeug.AchsenStrom.Strommessung);
                S7.SetIntAt(buffer, 186, Werkzeug.AchsenStrom.FuegenStart);
                S7.SetIntAt(buffer, 188, Werkzeug.Zaehler.NIONF);
                S7.SetIntAt(buffer, 190, Werkzeug.Zaehler.NIOVF);
                S7.SetIntAt(buffer, 192, Werkzeug.Zaehler.Stueckzaehler);
                S7.SetBitAt(ref buffer, 194, 0, Werkzeug.AktivierungN2Gas.N2G1);
                S7.SetBitAt(ref buffer, 194, 1, Werkzeug.AktivierungN2Gas.N2G2);
                S7.SetBitAt(ref buffer, 194, 2, Werkzeug.AktivierungN2Gas.N2G3);
                S7.SetBitAt(ref buffer, 194, 3, Werkzeug.AktivierungN2Gas.N2G4);
                S7.SetBitAt(ref buffer, 194, 4, Werkzeug.AktivierungN2Gas.Reserve5);
                S7.SetBitAt(ref buffer, 194, 5, Werkzeug.AktivierungN2Gas.Reserve6);
                S7.SetBitAt(ref buffer, 194, 6, Werkzeug.AktivierungN2Gas.Reserve7);
                S7.SetBitAt(ref buffer, 194, 7, Werkzeug.AktivierungN2Gas.Reserve8);
                S7.SetBitAt(ref buffer, 196, 0, Werkzeug.AktivierungSontiges.ExternerE1);
                S7.SetBitAt(ref buffer, 196, 1, Werkzeug.AktivierungSontiges.ExternerE2);
                S7.SetBitAt(ref buffer, 196, 2, Werkzeug.AktivierungSontiges.ExternePruefung1);
                S7.SetBitAt(ref buffer, 196, 3, Werkzeug.AktivierungSontiges.ExternePruefung2);
                S7.SetBitAt(ref buffer, 196, 4, Werkzeug.AktivierungSontiges.OptionUmschaltung1);
                S7.SetBitAt(ref buffer, 196, 5, Werkzeug.AktivierungSontiges.Reserve6);
                S7.SetBitAt(ref buffer, 196, 6, Werkzeug.AktivierungSontiges.Reserve7);
                S7.SetBitAt(ref buffer, 196, 7, Werkzeug.AktivierungSontiges.Reserve8);
                S7.SetBitAt(ref buffer, 197, 0, Werkzeug.AktivierungSontiges.Reserve9);
                S7.SetBitAt(ref buffer, 197, 1, Werkzeug.AktivierungSontiges.Reserve10);
                S7.SetBitAt(ref buffer, 197, 2, Werkzeug.AktivierungSontiges.Reserve11);
                S7.SetBitAt(ref buffer, 197, 3, Werkzeug.AktivierungSontiges.Reserve12);
                S7.SetBitAt(ref buffer, 197, 4, Werkzeug.AktivierungSontiges.Reserve13);
                S7.SetBitAt(ref buffer, 197, 5, Werkzeug.AktivierungSontiges.Reserve14);
                S7.SetBitAt(ref buffer, 197, 6, Werkzeug.AktivierungSontiges.Reserve15);
                S7.SetBitAt(ref buffer, 197, 7, Werkzeug.AktivierungSontiges.Reserve16);
                S7.SetByteAt(buffer, 198, Werkzeug.BursterDigiforceKraftWeg.FuegewegKraftNest1);
                S7.SetByteAt(buffer, 199, Werkzeug.BursterDigiforceKraftWeg.FuegewegKraftNest2);
                S7.SetIntAt(buffer, 200, Werkzeug.BursterDigiforceKraftWeg.BursterProgrammNest1);
                S7.SetIntAt(buffer, 202, Werkzeug.BursterDigiforceKraftWeg.BursterProgrammNest2);
                S7.SetBitAt(ref buffer, 204, 0, Werkzeug.BursterDigiforceMinsdestkraft.BursterMindestKraftAktiv);
                S7.SetRealAt(buffer, 206, Werkzeug.BursterDigiforceMinsdestkraft.MindestkraftSollNest1);
                S7.SetRealAt(buffer, 210, Werkzeug.BursterDigiforceMinsdestkraft.MindestkraftToleranzPlusNest1);
                S7.SetRealAt(buffer, 214, Werkzeug.BursterDigiforceMinsdestkraft.MindestkraftToleranzMinusNest1);
                S7.SetRealAt(buffer, 218, Werkzeug.BursterDigiforceMinsdestkraft.MindestkraftSollNest2);
                S7.SetRealAt(buffer, 222, Werkzeug.BursterDigiforceMinsdestkraft.MindestkraftToleranzPlusNest2);
                S7.SetRealAt(buffer, 226, Werkzeug.BursterDigiforceMinsdestkraft.MindestkraftToleranzMinusNest2);
                S7.SetWordAt(buffer, 230, Werkzeug.IRCamera.KameraProgramm);
                S7.SetByteAt(buffer, 232, Werkzeug.IRCamera.KameraSchalter);
                S7.SetDIntAt(buffer, 234, Werkzeug.IRCamera.KameraLuftschleier);
                S7.SetDIntAt(buffer, 238, Werkzeug.IRCamera.KameraStartFuegenNachIR);
                S7.SetDIntAt(buffer, 242, Werkzeug.IRCamera.KameraFehlerVrzNachIR);
                S7.SetDIntAt(buffer, 246, Werkzeug.DMXCheck.DayDifferenceSet);
                S7.SetBitAt(ref buffer, 250, 0, Werkzeug.DMXCheck.ActiveDMXCheck);
                S7.SetRealAt(buffer, 252, Werkzeug.Ausgleichshub.Links);
                S7.SetRealAt(buffer, 256, Werkzeug.Ausgleichshub.Rechts);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
                //throw;
            }
        }
        public static DatWerkzeug BufferToDatWerkzeug(byte[] buffer, ref string error)
        {
            error = string.Empty;
            //create instance
            DatWerkzeug Werkzeug = new DatWerkzeug();

            try
            {
                Werkzeug.Kennung.ProgrammName = S7.GetStringAt(buffer, 0);
                Werkzeug.Kennung.RFIDHE = S7.GetByteAt(buffer, 42);
                Werkzeug.Kennung.RFIDOB = S7.GetByteAt(buffer, 43);
                Werkzeug.Kennung.RFIDUN = S7.GetByteAt(buffer, 44);
                Werkzeug.AktivierungSchritte.SpannenT1 = S7.GetBitAt(buffer, 46, 0);
                Werkzeug.AktivierungSchritte.SpannenT2 = S7.GetBitAt(buffer, 46, 1);
                Werkzeug.AktivierungSchritte.Abholtakt = S7.GetBitAt(buffer, 46, 2);
                Werkzeug.AktivierungSchritte.Prueftakt = S7.GetBitAt(buffer, 46, 3);
                Werkzeug.AktivierungSchritte.WarmVor = S7.GetBitAt(buffer, 46, 4);
                Werkzeug.AktivierungSchritte.WarmEnde = S7.GetBitAt(buffer, 46, 5);
                Werkzeug.AktivierungSchritte.Auswerfer = S7.GetBitAt(buffer, 46, 6);
                Werkzeug.AktivierungSchritte.Roboter = S7.GetBitAt(buffer, 46, 7);
                Werkzeug.AktivierungSchritte.Reserve4 = S7.GetBitAt(buffer, 47, 0);
                Werkzeug.AktivierungSchritte.Reserve5 = S7.GetBitAt(buffer, 47, 1);
                Werkzeug.AktivierungSchritte.Reserve6 = S7.GetBitAt(buffer, 47, 2);
                Werkzeug.AktivierungSchritte.Reserve7 = S7.GetBitAt(buffer, 47, 3);
                Werkzeug.AktivierungSchritte.Reserve8 = S7.GetBitAt(buffer, 47, 4);
                Werkzeug.AktivierungSchritte.Reserve9 = S7.GetBitAt(buffer, 47, 5);
                Werkzeug.AktivierungSchritte.StopNachFuegen = S7.GetBitAt(buffer, 47, 6);
                Werkzeug.AktivierungSchritte.OeffnenNachFuegen = S7.GetBitAt(buffer, 47, 7);
                Werkzeug.ParameterSchritte.Abhol.A1.VorPosition = S7.GetDIntAt(buffer, 48);
                Werkzeug.ParameterSchritte.Abhol.A1.EndPosition = S7.GetDIntAt(buffer, 52);
                Werkzeug.ParameterSchritte.Abhol.A1.Geschwindigkeit = S7.GetDIntAt(buffer, 56);
                Werkzeug.ParameterSchritte.Abhol.A2.VorPosition = S7.GetDIntAt(buffer, 60);
                Werkzeug.ParameterSchritte.Abhol.A2.EndPosition = S7.GetDIntAt(buffer, 64);
                Werkzeug.ParameterSchritte.Abhol.A2.Geschwindigkeit = S7.GetDIntAt(buffer, 68);
                Werkzeug.ParameterSchritte.HEVorposition.A1.Position = S7.GetDIntAt(buffer, 72);
                Werkzeug.ParameterSchritte.HEVorposition.A1.Geschwindigkeit = S7.GetDIntAt(buffer, 76);
                Werkzeug.ParameterSchritte.HEVorposition.A2.Position = S7.GetDIntAt(buffer, 80);
                Werkzeug.ParameterSchritte.HEVorposition.A2.Geschwindigkeit = S7.GetDIntAt(buffer, 84);
                Werkzeug.ParameterSchritte.Warm1.A1.Position = S7.GetDIntAt(buffer, 88);
                Werkzeug.ParameterSchritte.Warm1.A1.Geschwindigkeit = S7.GetDIntAt(buffer, 92);
                Werkzeug.ParameterSchritte.Warm1.A2.Position = S7.GetDIntAt(buffer, 96);
                Werkzeug.ParameterSchritte.Warm1.A2.Geschwindigkeit = S7.GetDIntAt(buffer, 100);
                Werkzeug.ParameterSchritte.Warm1.A3.Position = S7.GetDIntAt(buffer, 104);
                Werkzeug.ParameterSchritte.Warm1.Zeit = S7.GetDIntAt(buffer, 108);
                Werkzeug.ParameterSchritte.Warm2.A1.Position = S7.GetDIntAt(buffer, 112);
                Werkzeug.ParameterSchritte.Warm2.A1.Geschwindigkeit = S7.GetDIntAt(buffer, 116);
                Werkzeug.ParameterSchritte.Warm2.A2.Position = S7.GetDIntAt(buffer, 120);
                Werkzeug.ParameterSchritte.Warm2.A2.Geschwindigkeit = S7.GetDIntAt(buffer, 124);
                Werkzeug.ParameterSchritte.Warm2.Zeit = S7.GetDIntAt(buffer, 128);
                Werkzeug.ParameterSchritte.Fuege.A1.VorPosition = S7.GetDIntAt(buffer, 132);
                Werkzeug.ParameterSchritte.Fuege.A1.EndPosition = S7.GetDIntAt(buffer, 136);
                Werkzeug.ParameterSchritte.Fuege.A1.Geschwindigkeit = S7.GetDIntAt(buffer, 140);
                Werkzeug.ParameterSchritte.Fuege.A1.OeffnungswegNachFuegen = S7.GetDIntAt(buffer, 144);
                Werkzeug.ParameterSchritte.Fuege.A1.RueckhubGeschwingkeitFuegen = S7.GetDIntAt(buffer, 148);
                Werkzeug.ParameterSchritte.Fuege.A2.VorPosition = S7.GetDIntAt(buffer, 152);
                Werkzeug.ParameterSchritte.Fuege.A2.EndPosition = S7.GetDIntAt(buffer, 156);
                Werkzeug.ParameterSchritte.Fuege.A2.Geschwindigkeit = S7.GetDIntAt(buffer, 160);
                Werkzeug.ParameterSchritte.Fuege.Kuehlzeit = S7.GetDIntAt(buffer, 164);
                Werkzeug.ParameterSchritte.Schmelzbild.A1.Position = S7.GetDIntAt(buffer, 168);
                Werkzeug.ParameterSchritte.Schmelzbild.A1.Geschwindigkeit = S7.GetDIntAt(buffer, 172);
                Werkzeug.AchsenStrom.FuegekraftMaxA1 = S7.GetIntAt(buffer, 176);
                Werkzeug.AchsenStrom.FuegekraftMinA1 = S7.GetIntAt(buffer, 178);
                Werkzeug.AchsenStrom.FuegekraftMaxA2 = S7.GetIntAt(buffer, 180);
                Werkzeug.AchsenStrom.FuegekraftMinA2 = S7.GetIntAt(buffer, 182);
                Werkzeug.AchsenStrom.Strommessung = S7.GetByteAt(buffer, 184);
                Werkzeug.AchsenStrom.FuegenStart = S7.GetIntAt(buffer, 186);
                Werkzeug.Zaehler.NIONF = S7.GetIntAt(buffer, 188);
                Werkzeug.Zaehler.NIOVF = S7.GetIntAt(buffer, 190);
                Werkzeug.Zaehler.Stueckzaehler = S7.GetIntAt(buffer, 192);
                Werkzeug.AktivierungN2Gas.N2G1 = S7.GetBitAt(buffer, 194, 0);
                Werkzeug.AktivierungN2Gas.N2G2 = S7.GetBitAt(buffer, 194, 1);
                Werkzeug.AktivierungN2Gas.N2G3 = S7.GetBitAt(buffer, 194, 2);
                Werkzeug.AktivierungN2Gas.N2G4 = S7.GetBitAt(buffer, 194, 3);
                Werkzeug.AktivierungN2Gas.Reserve5 = S7.GetBitAt(buffer, 194, 4);
                Werkzeug.AktivierungN2Gas.Reserve6 = S7.GetBitAt(buffer, 194, 5);
                Werkzeug.AktivierungN2Gas.Reserve7 = S7.GetBitAt(buffer, 194, 6);
                Werkzeug.AktivierungN2Gas.Reserve8 = S7.GetBitAt(buffer, 194, 7);
                Werkzeug.AktivierungSontiges.ExternerE1 = S7.GetBitAt(buffer, 196, 0);
                Werkzeug.AktivierungSontiges.ExternerE2 = S7.GetBitAt(buffer, 196, 1);
                Werkzeug.AktivierungSontiges.ExternePruefung1 = S7.GetBitAt(buffer, 196, 2);
                Werkzeug.AktivierungSontiges.ExternePruefung2 = S7.GetBitAt(buffer, 196, 3);
                Werkzeug.AktivierungSontiges.OptionUmschaltung1 = S7.GetBitAt(buffer, 196, 4);
                Werkzeug.AktivierungSontiges.Reserve6 = S7.GetBitAt(buffer, 196, 5);
                Werkzeug.AktivierungSontiges.Reserve7 = S7.GetBitAt(buffer, 196, 6);
                Werkzeug.AktivierungSontiges.Reserve8 = S7.GetBitAt(buffer, 196, 7);
                Werkzeug.AktivierungSontiges.Reserve9 = S7.GetBitAt(buffer, 197, 0);
                Werkzeug.AktivierungSontiges.Reserve10 = S7.GetBitAt(buffer, 197, 1);
                Werkzeug.AktivierungSontiges.Reserve11 = S7.GetBitAt(buffer, 197, 2);
                Werkzeug.AktivierungSontiges.Reserve12 = S7.GetBitAt(buffer, 197, 3);
                Werkzeug.AktivierungSontiges.Reserve13 = S7.GetBitAt(buffer, 197, 4);
                Werkzeug.AktivierungSontiges.Reserve14 = S7.GetBitAt(buffer, 197, 5);
                Werkzeug.AktivierungSontiges.Reserve15 = S7.GetBitAt(buffer, 197, 6);
                Werkzeug.AktivierungSontiges.Reserve16 = S7.GetBitAt(buffer, 197, 7);
                Werkzeug.BursterDigiforceKraftWeg.FuegewegKraftNest1 = S7.GetByteAt(buffer, 198);
                Werkzeug.BursterDigiforceKraftWeg.FuegewegKraftNest2 = S7.GetByteAt(buffer, 199);
                Werkzeug.BursterDigiforceKraftWeg.BursterProgrammNest1 = S7.GetIntAt(buffer, 200);
                Werkzeug.BursterDigiforceKraftWeg.BursterProgrammNest2 = S7.GetIntAt(buffer, 202);
                Werkzeug.BursterDigiforceMinsdestkraft.BursterMindestKraftAktiv = S7.GetBitAt(buffer, 204, 0);
                Werkzeug.BursterDigiforceMinsdestkraft.MindestkraftSollNest1 = S7.GetRealAt(buffer, 206);
                Werkzeug.BursterDigiforceMinsdestkraft.MindestkraftToleranzPlusNest1 = S7.GetRealAt(buffer, 210);
                Werkzeug.BursterDigiforceMinsdestkraft.MindestkraftToleranzMinusNest1 = S7.GetRealAt(buffer, 214);
                Werkzeug.BursterDigiforceMinsdestkraft.MindestkraftSollNest2 = S7.GetRealAt(buffer, 218);
                Werkzeug.BursterDigiforceMinsdestkraft.MindestkraftToleranzPlusNest2 = S7.GetRealAt(buffer, 222);
                Werkzeug.BursterDigiforceMinsdestkraft.MindestkraftToleranzMinusNest2 = S7.GetRealAt(buffer, 226);
                Werkzeug.IRCamera.KameraProgramm = S7.GetWordAt(buffer, 230);
                Werkzeug.IRCamera.KameraSchalter = S7.GetByteAt(buffer, 232);
                Werkzeug.IRCamera.KameraLuftschleier = S7.GetDIntAt(buffer, 234);
                Werkzeug.IRCamera.KameraStartFuegenNachIR = S7.GetDIntAt(buffer, 238);
                Werkzeug.IRCamera.KameraFehlerVrzNachIR = S7.GetDIntAt(buffer, 242);
                Werkzeug.DMXCheck.DayDifferenceSet = S7.GetDIntAt(buffer, 246);
                Werkzeug.DMXCheck.ActiveDMXCheck = S7.GetBitAt(buffer, 250, 0);
                Werkzeug.Ausgleichshub.Links = S7.GetRealAt(buffer, 252);
                Werkzeug.Ausgleichshub.Rechts = S7.GetRealAt(buffer, 256);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
                //throw;
            }

            return Werkzeug;
        }
        public static void SerializeDatWerkzeug(DatWerkzeug Werkzeug, string path, ref string error)
        {
            error = string.Empty;
            //create instance
            //DatWerkzeug Werkzeug = new DatWerkzeug();

            try
            {
                // XmlSerializer writes object data as XML
                XmlSerializer serializer = new XmlSerializer(typeof(DatWerkzeug));
                using (TextWriter writer = new StreamWriter(path + "\\Werkzeug.xml"))
                {
                    serializer.Serialize(writer, Werkzeug);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString() + " " + path + "\\Werkzeug.xml";
                //throw;
            }
            //return value
            //return Werkzeug;
        }
        public static DatWerkzeug DeserializeDatWerkzeug(string path, ref string error)
        {
            //create instance
            DatWerkzeug Werkzeug = new DatWerkzeug();
            try
            {
                // Deserialize from XML to the object
                XmlSerializer deserializer = new XmlSerializer(typeof(DatWerkzeug));
                TextReader reader = new StreamReader(path + "\\Werkzeug.xml");
                object obj = deserializer.Deserialize(reader);
                Werkzeug = (DatWerkzeug)obj;
                reader.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString() + " " + path + "\\Werkzeug.xml";
                //throw;
            }
            //return value
            return Werkzeug;
        }
        #endregion



        #region DatMWerkzeug
        public static void DatMWerkzeugToBuffer(DatMWerkzeug MWerkzeug, byte[] buffer, ref string error)
        {
            try
            {
                //clear buffer before use
                Array.Clear(buffer, 0, buffer.Length);

                S7.SetDIntAt(buffer, 0, MWerkzeug.WerkzeughoeheA1);
                S7.SetDIntAt(buffer, 4, MWerkzeug.WerkzeughoeheA2);
                S7.SetDIntAt(buffer, 8, MWerkzeug.HeizelementhoeheObenA3);
                S7.SetDIntAt(buffer, 12, MWerkzeug.HeizelementhoeheUntenA3);
                S7.SetDIntAt(buffer, 16, MWerkzeug.WarmpositionA3);
                S7.SetDIntAt(buffer, 20, MWerkzeug.BestueckungspositionA1);
                S7.SetDIntAt(buffer, 24, MWerkzeug.BestueckungspositionA2);
                S7.SetDIntAt(buffer, 28, MWerkzeug.PruefpositionA1);
                S7.SetDIntAt(buffer, 32, MWerkzeug.PruefpositionA2);
                S7.SetDIntAt(buffer, 36, MWerkzeug.IRKameraTriggerpositionA3);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
                //throw;
            }
        }
        public static DatMWerkzeug BufferToDatMWerkzeug(byte[] buffer, ref string error)
        {
            error = string.Empty;
            //create instance
            DatMWerkzeug MWerkzeug = new DatMWerkzeug();

            try
            {
                MWerkzeug.WerkzeughoeheA1 = S7.GetDIntAt(buffer, 0);
                MWerkzeug.WerkzeughoeheA2 = S7.GetDIntAt(buffer, 4);
                MWerkzeug.HeizelementhoeheObenA3 = S7.GetDIntAt(buffer, 8);
                MWerkzeug.HeizelementhoeheUntenA3 = S7.GetDIntAt(buffer, 12);
                MWerkzeug.WarmpositionA3 = S7.GetDIntAt(buffer, 16);
                MWerkzeug.BestueckungspositionA1 = S7.GetDIntAt(buffer, 20);
                MWerkzeug.BestueckungspositionA2 = S7.GetDIntAt(buffer, 24);
                MWerkzeug.PruefpositionA1 = S7.GetDIntAt(buffer, 28);
                MWerkzeug.PruefpositionA2 = S7.GetDIntAt(buffer, 32);
                MWerkzeug.IRKameraTriggerpositionA3 = S7.GetDIntAt(buffer, 36);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
                //throw;
            }

            return MWerkzeug;
        }
        public static void SerializeDatMWerkzeug(DatMWerkzeug MWerkzeug, string path, string machineID, ref string error)
        {
            error = string.Empty;
            //create instance
            //DatMWerkzeug MWerkzeug = new DatMWerkzeug();

            try
            {
                // XmlSerializer writes object data as XML
                XmlSerializer serializer = new XmlSerializer(typeof(DatMWerkzeug));
                using (TextWriter writer = new StreamWriter(path + "\\MWerkzeug_" + machineID + ".xml"))
                {
                    serializer.Serialize(writer, MWerkzeug);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString() + " " + path + "\\MWerkzeug_" + machineID + ".xml";
                //throw;
            }
            //return value
            //return MWerkzeug;
        }
        public static DatMWerkzeug DeserializeMWerkzeug(string path, string machineID, ref string error)
        {
            //create instance
            DatMWerkzeug MWerkzeug = new DatMWerkzeug();
            try
            {
                // Deserialize from XML to the object
                XmlSerializer deserializer = new XmlSerializer(typeof(DatMWerkzeug));
                TextReader reader = new StreamReader(path + "\\MWerkzeug_" + machineID + ".xml");
                object obj = deserializer.Deserialize(reader);
                MWerkzeug = (DatMWerkzeug)obj;
                reader.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString() + " " + path + "\\MWerkzeug_" + machineID + ".xml";
                //throw;
            }
            //return value
            return MWerkzeug;
        }
        #endregion



        #region DatBetrieb
        public static void DatBetriebToBuffer(DatBetrieb datBetrieb, byte[] buffer, ref string error)
        {
            try
            {
                //clear buffer before use
                Array.Clear(buffer, 0, buffer.Length);

                S7.SetDIntAt(buffer, 0, datBetrieb.StdSollHE);
                S7.SetDIntAt(buffer, 4, datBetrieb.StdIstHE);
                S7.SetDIntAt(buffer, 8, datBetrieb.StdIntervalHE);
                S7.SetDIntAt(buffer, 12, datBetrieb.StdSollOB);
                S7.SetDIntAt(buffer, 16, datBetrieb.StdIstOB);
                S7.SetDIntAt(buffer, 20, datBetrieb.StdIntervalOB);
                S7.SetDIntAt(buffer, 24, datBetrieb.StdSollUN);
                S7.SetDIntAt(buffer, 28, datBetrieb.StdIstUN);
                S7.SetDIntAt(buffer, 32, datBetrieb.StdIntervalUN);

            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
                //throw;
            }
        }
        public static DatBetrieb BufferToDatBetrieb (byte[] buffer, ref string error)
        {
            error = string.Empty;
            //create instance
            DatBetrieb datBetrieb = new DatBetrieb();

            try
            {
                datBetrieb.StdSollHE = S7.GetDIntAt(buffer, 0);
                datBetrieb.StdIstHE = S7.GetDIntAt(buffer, 4);
                datBetrieb.StdIntervalHE = S7.GetDIntAt(buffer, 8);
                datBetrieb.StdSollOB = S7.GetDIntAt(buffer, 12);
                datBetrieb.StdIstOB = S7.GetDIntAt(buffer, 16);
                datBetrieb.StdIntervalOB = S7.GetDIntAt(buffer, 20);
                datBetrieb.StdSollUN = S7.GetDIntAt(buffer, 24);
                datBetrieb.StdIstUN = S7.GetDIntAt(buffer, 28);
                datBetrieb.StdIntervalUN = S7.GetDIntAt(buffer, 32);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
                //throw;
            }

            return datBetrieb;
        }
        public static DatBetrieb SerializeDatBetrieb(DatBetrieb datBetrieb, string path, ref string error)
        {
            error = string.Empty;
            //create instance
            //DatBetrieb datBetrieb = new DatBetrieb();

            try
            {
                // XmlSerializer writes object data as XML
                XmlSerializer serializer = new XmlSerializer(typeof(DatBetrieb));
                using (TextWriter writer = new StreamWriter(path + "\\Betrieb.xml"))
                {
                    serializer.Serialize(writer, datBetrieb);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString() + " " + path + "\\Betrieb.xml";
                //throw;
            }
            //return value
            return datBetrieb;
        }
        public static DatBetrieb DeserializeDatBetrieb(string path, ref string error)
        {
            //create instance
            DatBetrieb datBetrieb = new DatBetrieb();
            try
            {
                // Deserialize from XML to the object
                XmlSerializer deserializer = new XmlSerializer(typeof(DatBetrieb));
                TextReader reader = new StreamReader(path + "\\Betrieb.xml");
                object obj = deserializer.Deserialize(reader);
                datBetrieb = (DatBetrieb)obj;
                reader.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString() + " " + path + "\\Betrieb.xml";
                //throw;
            }
            //return value
            return datBetrieb;
        }
        #endregion



        #region ProcessData
        public static ProcessData BufferToProcessData(byte[] buffer, ref string error)
        {
            ProcessData processData = new ProcessData();

            processData.Produktname = S7.GetStringAt(buffer, 0);
            processData.DmxCode1 = S7.GetStringAt(buffer, 42);
            processData.DmxCode2 = S7.GetStringAt(buffer, 144);
            processData.DmxCode3 = S7.GetStringAt(buffer, 246);
            processData.DmxCode4 = S7.GetStringAt(buffer, 348);
            processData.DmxCode5 = S7.GetStringAt(buffer, 450);
            processData.DmxCode6 = S7.GetStringAt(buffer, 552);
            processData.DmxCode7 = S7.GetStringAt(buffer, 654);
            processData.DmxCode8 = S7.GetStringAt(buffer, 756);
            //processData.DmxCode9 = S7.GetStringAt(buffer, 858);
            //processData.DmxCode10 = S7.GetStringAt(buffer, 960);
            //processData.DmxCode11 = S7.GetStringAt(buffer, 1062);
            //processData.DmxCode12 = S7.GetStringAt(buffer, 1164);
            processData.SchweissungsergebnisNio = S7.GetIntAt(buffer, 1266);
            processData.WarmZeit1Wert = S7.GetDIntAt(buffer, 1268);
            processData.WarmZei2Wert = S7.GetDIntAt(buffer, 1272);
            processData.KuehlZeitWert = S7.GetDIntAt(buffer, 1276);
            processData.UmstellZeitWert = S7.GetDIntAt(buffer, 1280);
            processData.ZyklusZeitWert = S7.GetDIntAt(buffer, 1284);
            processData.WarmPosition1ObenWert = S7.GetDIntAt(buffer, 1288);
            processData.WarmPosition1UntenWert = S7.GetDIntAt(buffer, 1292);
            processData.WarmPosition2ObenWert = S7.GetDIntAt(buffer, 1296);
            processData.WarmPosition2UntenWert = S7.GetDIntAt(buffer, 1300);
            processData.WarmPositionA3 = S7.GetDIntAt(buffer, 1304);
            processData.FuegePositionObenWert = S7.GetDIntAt(buffer, 1308);
            processData.FuegePositionUntenWert = S7.GetDIntAt(buffer, 1312);
            processData.FuegeVObenWert = S7.GetDIntAt(buffer, 1316);
            processData.FuegeVUntenWert = S7.GetDIntAt(buffer, 1320);
            processData.FuegeStromA1 = S7.GetIntAt(buffer, 1324);
            processData.FuegeStromA2 = S7.GetIntAt(buffer, 1326);
            processData.TempHeizelement1WertSoll = S7.GetIntAt(buffer, 1328);
            processData.TempHeizelement1WertIst = S7.GetIntAt(buffer, 1330);
            processData.TempHeizelement2WertSoll = S7.GetIntAt(buffer, 1332);
            processData.TempHeizelement2WertIst = S7.GetIntAt(buffer, 1334);
            processData.TempHeizelement3WertSoll = S7.GetIntAt(buffer, 1336);
            processData.TempHeizelement3WertIst = S7.GetIntAt(buffer, 1338);
            processData.TempHeizelement4WertSoll = S7.GetIntAt(buffer, 1340);
            processData.TempHeizelement4WertIst = S7.GetIntAt(buffer, 1342);
            processData.TempHeizelement5WertSoll = S7.GetIntAt(buffer, 1344);
            processData.TempHeizelement5WertIst = S7.GetIntAt(buffer, 1346);
            processData.TempHeizelement6WertSoll = S7.GetIntAt(buffer, 1348);
            processData.TempHeizelement6WertIst = S7.GetIntAt(buffer, 1350);
            processData.TempHeizelement7WertSoll = S7.GetIntAt(buffer, 1352);
            processData.TempHeizelement7WertIst = S7.GetIntAt(buffer, 1354);
            processData.TempHeizelement8WertSoll = S7.GetIntAt(buffer, 1356);
            processData.TempHeizelement8WertIst = S7.GetIntAt(buffer, 1358);
            processData.TempHeizelement9WertSoll = S7.GetIntAt(buffer, 1360);
            processData.TempHeizelement9WertIst = S7.GetIntAt(buffer, 1362);
            processData.TempHeizelement10WertSoll = S7.GetIntAt(buffer, 1364);
            processData.TempHeizelement10WertIst = S7.GetIntAt(buffer, 1366);
            processData.TempHeizelement11WertSoll = S7.GetIntAt(buffer, 1368);
            processData.TempHeizelement11WertIst = S7.GetIntAt(buffer, 1370);
            processData.TempHeizelement12WertSoll = S7.GetIntAt(buffer, 1372);
            processData.TempHeizelement12WertIst = S7.GetIntAt(buffer, 1374);
            //processData.TempHeizelement13WertSoll = S7.GetIntAt(buffer, 1376);
            //processData.TempHeizelement13WertIst = S7.GetIntAt(buffer, 1378);
            //processData.TempHeizelement14WertSoll = S7.GetIntAt(buffer, 1380);
            //processData.TempHeizelement14WertIst = S7.GetIntAt(buffer, 1382);
            //processData.TempHeizelement15WertSoll = S7.GetIntAt(buffer, 1384);
            //processData.TempHeizelement15WertIst = S7.GetIntAt(buffer, 1386);
            processData.TempDurchflussKreis1WertSoll = S7.GetRealAt(buffer, 1388);
            processData.TempDurchflussKreis1WertIst = S7.GetRealAt(buffer, 1392);
            processData.TempDurchflussKreis2WertSoll = S7.GetRealAt(buffer, 1396);
            processData.TempDurchflussKreis2WertIst = S7.GetRealAt(buffer, 1400);
            processData.TempDurchflussKreis3WertSoll = S7.GetRealAt(buffer, 1404);
            processData.TempDurchflussKreis3WertIst = S7.GetRealAt(buffer, 1408);
            processData.TempDurchflussKreis4WertSoll = S7.GetRealAt(buffer, 1412);
            processData.TempDurchflussKreis4WertIst = S7.GetRealAt(buffer, 1416);
            processData.TempDurchflussKreis5WertSoll = S7.GetRealAt(buffer, 1420);
            processData.TempDurchflussKreis5WertIst = S7.GetRealAt(buffer, 1424);
            processData.TempDurchflussKreis6WertSoll = S7.GetRealAt(buffer, 1428);
            processData.TempDurchflussKreis6WertIst = S7.GetRealAt(buffer, 1432);
            processData.TempDurchflussKreis7WertSoll = S7.GetRealAt(buffer, 1436);
            processData.TempDurchflussKreis7WertIst = S7.GetRealAt(buffer, 1440);
            processData.TempDurchflussKreis8WertSoll = S7.GetRealAt(buffer, 1444);
            processData.TempDurchflussKreis8WertIst = S7.GetRealAt(buffer, 1448);
            processData.TempDurchflussKreis9WertSoll = S7.GetRealAt(buffer, 1452);
            processData.TempDurchflussKreis9WertIst = S7.GetRealAt(buffer, 1456);
            processData.TempDurchflussKreis10WertSoll = S7.GetRealAt(buffer, 1460);
            processData.TempDurchflussKreis10WertIst = S7.GetRealAt(buffer, 1464);
            processData.TempDurchflussKreis11WertSoll = S7.GetRealAt(buffer, 1468);
            processData.TempDurchflussKreis11WertIst = S7.GetRealAt(buffer, 1472);
            processData.TempDurchflussKreis12WertSoll = S7.GetRealAt(buffer, 1476);
            processData.TempDurchflussKreis12WertIst = S7.GetRealAt(buffer, 1480);
            processData.TempDurchflussKreis13WertSoll = S7.GetRealAt(buffer, 1484);
            processData.TempDurchflussKreis13WertIst = S7.GetRealAt(buffer, 1488);
            processData.TempDurchflussKreis14WertSoll = S7.GetRealAt(buffer, 1492);
            processData.TempDurchflussKreis14WertIst = S7.GetRealAt(buffer, 1496);
            processData.TempDurchflussKreis15WertSoll = S7.GetRealAt(buffer, 1500);
            processData.TempDurchflussKreis15WertIst = S7.GetRealAt(buffer, 1504);
            processData.TempDurchflussKreis16WertSoll = S7.GetRealAt(buffer, 1508);
            processData.TempDurchflussKreis16WertIst = S7.GetRealAt(buffer, 1512);
            processData.TempDurchflussKreis17WertSoll = S7.GetRealAt(buffer, 1516);
            processData.TempDurchflussKreis17WertIst = S7.GetRealAt(buffer, 1520);
            processData.TempDurchflussKreis18WertSoll = S7.GetRealAt(buffer, 1524);
            processData.TempDurchflussKreis18WertIst = S7.GetRealAt(buffer, 1528);
            processData.TempDurchflussKreis19WertSoll = S7.GetRealAt(buffer, 1532);
            processData.TempDurchflussKreis19WertIst = S7.GetRealAt(buffer, 1536);
            processData.TempDurchflussKreis20WertSoll = S7.GetRealAt(buffer, 1540);
            processData.TempDurchflussKreis20WertIst = S7.GetRealAt(buffer, 1544);
            processData.TempDurchflussKreis21WertSoll = S7.GetRealAt(buffer, 1548);
            processData.TempDurchflussKreis21WertIst = S7.GetRealAt(buffer, 1552);
            processData.TempDurchflussKreis22WertSoll = S7.GetRealAt(buffer, 1556);
            processData.TempDurchflussKreis22WertIst = S7.GetRealAt(buffer, 1560);
            processData.TempDurchflussKreis23WertSoll = S7.GetRealAt(buffer, 1564);
            processData.TempDurchflussKreis23WertIst = S7.GetRealAt(buffer, 1568);
            processData.TempDurchflussKreis24WertSoll = S7.GetRealAt(buffer, 1572);
            processData.TempDurchflussKreis24WertIst = S7.GetRealAt(buffer, 1576);
            processData.TempDurchflussKreis25WertSoll = S7.GetRealAt(buffer, 1580);
            processData.TempDurchflussKreis25WertIst = S7.GetRealAt(buffer, 1584);
            processData.TempDurchflussKreis26WertSoll = S7.GetRealAt(buffer, 1588);
            processData.TempDurchflussKreis26WertIst = S7.GetRealAt(buffer, 1592);
            processData.TempDurchflussKreis27WertSoll = S7.GetRealAt(buffer, 1596);
            processData.TempDurchflussKreis27WertIst = S7.GetRealAt(buffer, 1600);
            processData.TempDurchflussKreis28WertSoll = S7.GetRealAt(buffer, 1604);
            processData.TempDurchflussKreis28WertIst = S7.GetRealAt(buffer, 1608);
            processData.TempDurchflussKreis29WertSoll = S7.GetRealAt(buffer, 1612);
            processData.TempDurchflussKreis29WertIst = S7.GetRealAt(buffer, 1616);
            processData.TempDurchflussKreis30WertSoll = S7.GetRealAt(buffer, 1620);
            processData.TempDurchflussKreis30WertIst = S7.GetRealAt(buffer, 1624);
            processData.TempDurchflussKreis31WertSoll = S7.GetRealAt(buffer, 1628);
            processData.TempDurchflussKreis31WertIst = S7.GetRealAt(buffer, 1632);
            processData.TempDurchflussKreis32WertSoll = S7.GetRealAt(buffer, 1636);
            processData.TempDurchflussKreis32WertIst = S7.GetRealAt(buffer, 1640);
            processData.TempDurchflussKreis33WertSoll = S7.GetRealAt(buffer, 1644);
            processData.TempDurchflussKreis33WertIst = S7.GetRealAt(buffer, 1648);
            processData.TempDurchflussKreis34WertSoll = S7.GetRealAt(buffer, 1652);
            processData.TempDurchflussKreis34WertIst = S7.GetRealAt(buffer, 1656);
            processData.TempDurchflussKreis35WertSoll = S7.GetRealAt(buffer, 1660);
            processData.TempDurchflussKreis35WertIst = S7.GetRealAt(buffer, 1664);
            processData.TempDurchflussKreis36WertSoll = S7.GetRealAt(buffer, 1668);
            processData.TempDurchflussKreis36WertIst = S7.GetRealAt(buffer, 1672);
            processData.TempDurchflussKreis37WertSoll = S7.GetRealAt(buffer, 1676);
            processData.TempDurchflussKreis37WertIst = S7.GetRealAt(buffer, 1680);
            processData.TempDurchflussKreis38WertSoll = S7.GetRealAt(buffer, 1684);
            processData.TempDurchflussKreis38WertIst = S7.GetRealAt(buffer, 1688);
            processData.TempDurchflussKreis39WertSoll = S7.GetRealAt(buffer, 1692);
            processData.TempDurchflussKreis39WertIst = S7.GetRealAt(buffer, 1696);
            processData.TempDurchflussKreis40WertSoll = S7.GetRealAt(buffer, 1700);
            processData.TempDurchflussKreis40WertIst = S7.GetRealAt(buffer, 1704);
            processData.Kraft1Wert = S7.GetRealAt(buffer, 1708);
            processData.Kraft1Result = S7.GetIntAt(buffer, 1712);
            processData.Kraft2Wert = S7.GetRealAt(buffer, 1714);
            processData.Kraft2Result = S7.GetIntAt(buffer, 1718);
            processData.Weg1Wert = S7.GetRealAt(buffer, 1720);
            processData.Weg1Result = S7.GetIntAt(buffer, 1724);
            processData.Weg2Wert = S7.GetRealAt(buffer, 1726);
            processData.Weg2Result = S7.GetIntAt(buffer, 1730);
            //processData.IstwertBerstdruck1 = S7.GetRealAt(buffer, 1732);
            //processData.ResultBerstdruck1 = S7.GetIntAt(buffer, 1736);
            //processData.IstwertBerstdruck2 = S7.GetRealAt(buffer, 1738);
            //processData.ResultBerstdruck2 = S7.GetIntAt(buffer, 1742);
            //processData.IstwertBerstdruck3 = S7.GetRealAt(buffer, 1744);
            //processData.ResultBerstdruck3 = S7.GetIntAt(buffer, 1748);
            //processData.IstwertBerstdruck4 = S7.GetRealAt(buffer, 1750);
            //processData.ResultBerstdruck4 = S7.GetIntAt(buffer, 1754);
            //processData.IstwertBerstdruck5 = S7.GetRealAt(buffer, 1756);
            //processData.ResultBerstdruck5 = S7.GetIntAt(buffer, 1760);
            //processData.IstwertBerstdruck6 = S7.GetRealAt(buffer, 1762);
            //processData.ResultBerstdruck6 = S7.GetIntAt(buffer, 1766);
            //processData.IstwertBerstdruck7 = S7.GetRealAt(buffer, 1768);
            //processData.ResultBerstdruck7 = S7.GetIntAt(buffer, 1772);
            //processData.IstwertBerstdruck8 = S7.GetRealAt(buffer, 1774);
            //processData.ResultBerstdruck8 = S7.GetIntAt(buffer, 1778);
            processData.Ausgleichhub1WertSoll = S7.GetRealAt(buffer, 1780);
            processData.Ausgleichhub1WertIst = S7.GetRealAt(buffer, 1784);
            processData.Ausgleichhub2WertSoll = S7.GetRealAt(buffer, 1788);
            processData.Ausgleichhub2WertIst = S7.GetRealAt(buffer, 1792);
            processData.EinschaltverzDurchflussKreis1 = (float)S7.GetDWordAt(buffer, 1796) / 1000.0;
            processData.EinschaltverzDurchflussKreis2 = (float)S7.GetDWordAt(buffer, 1800) / 1000.0;
            processData.EinschaltverzDurchflussKreis3 = (float)S7.GetDWordAt(buffer, 1804) / 1000.0;
            processData.EinschaltverzDurchflussKreis4 = (float)S7.GetDWordAt(buffer, 1808) / 1000.0;
            processData.EinschaltverzDurchflussKreis5 = (float)S7.GetDWordAt(buffer, 1812) / 1000.0;
            processData.EinschaltverzDurchflussKreis6 = (float)S7.GetDWordAt(buffer, 1816) / 1000.0;
            processData.EinschaltverzDurchflussKreis7 = (float)S7.GetDWordAt(buffer, 1820) / 1000.0;
            processData.EinschaltverzDurchflussKreis8 = (float)S7.GetDWordAt(buffer, 1824) / 1000.0;
            processData.EinschaltverzDurchflussKreis9 = (float)S7.GetDWordAt(buffer, 1828) / 1000.0;
            processData.EinschaltverzDurchflussKreis10 = (float)S7.GetDWordAt(buffer, 1832) / 1000.0;
            processData.EinschaltverzDurchflussKreis11 = (float)S7.GetDWordAt(buffer, 1836) / 1000.0;
            processData.EinschaltverzDurchflussKreis12 = (float)S7.GetDWordAt(buffer, 1840) / 1000.0;
            processData.EinschaltverzDurchflussKreis13 = (float)S7.GetDWordAt(buffer, 1844) / 1000.0;
            processData.EinschaltverzDurchflussKreis14 = (float)S7.GetDWordAt(buffer, 1848) / 1000.0;
            processData.EinschaltverzDurchflussKreis15 = (float)S7.GetDWordAt(buffer, 1852) / 1000.0;
            processData.EinschaltverzDurchflussKreis16 = (float)S7.GetDWordAt(buffer, 1856) / 1000.0;
            processData.EinschaltverzDurchflussKreis17 = (float)S7.GetDWordAt(buffer, 1860) / 1000.0;
            processData.EinschaltverzDurchflussKreis18 = (float)S7.GetDWordAt(buffer, 1864) / 1000.0;
            processData.EinschaltverzDurchflussKreis19 = (float)S7.GetDWordAt(buffer, 1868) / 1000.0;
            processData.EinschaltverzDurchflussKreis20 = (float)S7.GetDWordAt(buffer, 1872) / 1000.0;
            processData.EinschaltverzDurchflussKreis21 = (float)S7.GetDWordAt(buffer, 1876) / 1000.0;
            processData.EinschaltverzDurchflussKreis22 = (float)S7.GetDWordAt(buffer, 1880) / 1000.0;
            processData.EinschaltverzDurchflussKreis23 = (float)S7.GetDWordAt(buffer, 1884) / 1000.0;
            processData.EinschaltverzDurchflussKreis24 = (float)S7.GetDWordAt(buffer, 1888) / 1000.0;
            processData.EinschaltverzDurchflussKreis25 = (float)S7.GetDWordAt(buffer, 1892) / 1000.0;
            processData.EinschaltverzDurchflussKreis26 = (float)S7.GetDWordAt(buffer, 1896) / 1000.0;
            processData.EinschaltverzDurchflussKreis27 = (float)S7.GetDWordAt(buffer, 1900) / 1000.0;
            processData.EinschaltverzDurchflussKreis28 = (float)S7.GetDWordAt(buffer, 1904) / 1000.0;
            processData.EinschaltverzDurchflussKreis29 = (float)S7.GetDWordAt(buffer, 1908) / 1000.0;
            processData.EinschaltverzDurchflussKreis30 = (float)S7.GetDWordAt(buffer, 1912) / 1000.0;
            processData.EinschaltverzDurchflussKreis31 = (float)S7.GetDWordAt(buffer, 1916) / 1000.0;
            processData.EinschaltverzDurchflussKreis32 = (float)S7.GetDWordAt(buffer, 1920) / 1000.0;
            processData.EinschaltverzDurchflussKreis33 = (float)S7.GetDWordAt(buffer, 1924) / 1000.0;
            processData.EinschaltverzDurchflussKreis34 = (float)S7.GetDWordAt(buffer, 1928) / 1000.0;
            processData.EinschaltverzDurchflussKreis35 = (float)S7.GetDWordAt(buffer, 1932) / 1000.0;
            processData.EinschaltverzDurchflussKreis36 = (float)S7.GetDWordAt(buffer, 1936) / 1000.0;
            processData.EinschaltverzDurchflussKreis37 = (float)S7.GetDWordAt(buffer, 1940) / 1000.0;
            processData.EinschaltverzDurchflussKreis38 = (float)S7.GetDWordAt(buffer, 1944) / 1000.0;
            processData.EinschaltverzDurchflussKreis39 = (float)S7.GetDWordAt(buffer, 1948) / 1000.0;
            processData.EinschaltverzDurchflussKreis40 = (float)S7.GetDWordAt(buffer, 1952) / 1000.0;

            return processData;
        }
        #endregion
    }
}
