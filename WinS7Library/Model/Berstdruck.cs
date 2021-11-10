using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinS7Library.Model
{
    public class Berstdruck
    {
        public short WerkzeugID { get; set; } = default;
        public string FilePath { get; set; } = default;
        public Level_1 Level1 { get; set; } = new Level_1();
        public Level_2 Level2 { get; set; } = new Level_2();

        public Berstdruck() { }

        public class Level_1
        {
            public string Programmname { get; set; } = default;
            public short Schweissfolge { get; set; } = default;
            public short Schweissanlage { get; set; } = default;
            public string Pruefungsart { get; set; } = default;
            public string BD { get; set; } = default;
            public DateTime TStamp { get; set; } = default;

            public Level_1() { }
        }

        public class Level_2
        {
            public string BauteilDM { get; set; } = default;
            public float Mindestberstdruck { get; set; } = default;
            public float Istberstdruck { get; set; } = default;
            public float Istdruck2 { get; set; } = default;
            public string Ergebnis { get; set; } = default;

            public Level_2() { }
        }
    }
}
