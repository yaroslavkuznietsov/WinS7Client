using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsComparer;

namespace WinS7Client.HelperSerializer
{
    class Comparence
    {
        public static void CompareClass(object object1, object object2, ref string comparenceinfo)
        {
            //Get type of class
            System.Type type = object1.GetType();
            System.Type type2 = object2.GetType();

            comparenceinfo = String.Empty;

            //Compare DatHE
            if (type == typeof(DatHE))
            {
                //Initialize objects and comparer  
                var comparer = new ObjectsComparer.Comparer<DatHE>();

                //Compare objects
                DatHE obj1 = (DatHE)object1;
                DatHE obj2 = (DatHE)object2;
                IEnumerable<Difference> differences;
                var isEqual = comparer.Compare(obj1, obj2, out differences);

                //Check equality
                if (!isEqual)
                {
                    //Get comparence results
                    comparenceinfo = comparenceinfo + "Difference in " + type.Name + ": ";
                    foreach (var item in differences)
                    {
                        comparenceinfo = comparenceinfo + " \n" + " " + item;
                    }
                    comparenceinfo = comparenceinfo + " \n";
                }
                else
                {
                    comparenceinfo = comparenceinfo + "Difference in " + type.Name + ": No difference";
                }
            }


            //Compare DatConfig
            if (type == typeof(DatConfig))
            {
                //Initialize objects and comparer  
                var comparer = new ObjectsComparer.Comparer<DatConfig>();

                //Compare objects
                DatConfig obj1 = (DatConfig)object1;
                DatConfig obj2 = (DatConfig)object2;
                IEnumerable<Difference> differences;
                var isEqual = comparer.Compare(obj1, obj2, out differences);

                //Check equality
                if (!isEqual)
                {
                    //Get comparence results
                    comparenceinfo = comparenceinfo + "Difference in " + type.Name + ": ";
                    foreach (var item in differences)
                    {
                        comparenceinfo = comparenceinfo + " \n" + " " + item;
                    }
                    comparenceinfo = comparenceinfo + " \n";
                }
                else
                {
                    comparenceinfo = comparenceinfo + "Difference in " + type.Name + ": No difference";
                }
            }


            //Compare DatN2
            if (type == typeof(DatN2))
            {
                //Initialize objects and comparer  
                var comparer = new ObjectsComparer.Comparer<DatN2>();

                //Compare objects
                DatN2 obj1 = (DatN2)object1;
                DatN2 obj2 = (DatN2)object2;
                IEnumerable<Difference> differences;
                var isEqual = comparer.Compare(obj1, obj2, out differences);

                //Check equality
                if (!isEqual)
                {
                    //Get comparence results
                    comparenceinfo = comparenceinfo + "Difference in " + type.Name + ": ";
                    foreach (var item in differences)
                    {
                        comparenceinfo = comparenceinfo + " \n" + " " + item;
                    }
                    comparenceinfo = comparenceinfo + " \n";
                }
                else
                {
                    comparenceinfo = comparenceinfo + "Difference in " + type.Name + ": No difference";
                }
            }


            //Compare DatWerkzeug
            if (type == typeof(DatWerkzeug))
            {
                //Initialize objects and comparer  
                var comparer = new ObjectsComparer.Comparer<DatWerkzeug>();

                //Compare objects
                DatWerkzeug obj1 = (DatWerkzeug)object1;
                DatWerkzeug obj2 = (DatWerkzeug)object2;
                IEnumerable<Difference> differences;
                var isEqual = comparer.Compare(obj1, obj2, out differences);

                //Check equality
                if (!isEqual)
                {
                    //Get comparence results
                    comparenceinfo = comparenceinfo + "Difference in " + type.Name + ": ";
                    foreach (var item in differences)
                    {
                        comparenceinfo = comparenceinfo + " \n" + " " + item;
                    }
                    comparenceinfo = comparenceinfo + " \n";
                }
                else
                {
                    comparenceinfo = comparenceinfo + "Difference in " + type.Name + ": No difference";
                }
            }


            //Compare DatMWerkzeug
            if (type == typeof(DatMWerkzeug))
            {
                //Initialize objects and comparer  
                var comparer = new ObjectsComparer.Comparer<DatMWerkzeug>();

                //Compare objects
                DatMWerkzeug obj1 = (DatMWerkzeug)object1;
                DatMWerkzeug obj2 = (DatMWerkzeug)object2;
                IEnumerable<Difference> differences;
                var isEqual = comparer.Compare(obj1, obj2, out differences);

                //Check equality
                if (!isEqual)
                {
                    //Get comparence results
                    comparenceinfo = comparenceinfo + "Difference in " + type.Name + ": ";
                    foreach (var item in differences)
                    {
                        comparenceinfo = comparenceinfo + " \n" + " " + item;
                    }
                    comparenceinfo = comparenceinfo + " \n";
                }
                else
                {
                    comparenceinfo = comparenceinfo + "Difference in " + type.Name + ": No difference";
                }
            }
        }
    }
}
