using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using WinS7Library.Model;

namespace WinS7Library.Helper
{
    public static class XmlHelper
    {
        public static List<Berstdruck> GetBerstdruckList(string root)
        {
            List<Berstdruck> BDruckList = new List<Berstdruck>();

            if (!string.IsNullOrEmpty(root) & Directory.Exists(root))
            {
                try
                {
                    string[] files = GetXmlFiles(root);

                    if (files.Length > 0)
                    {
                        foreach (var file in files)
                        {
                            Berstdruck berstdruck = GetBerstdruck(file);
                            if (berstdruck.FilePath != null)
                            {
                                BDruckList.Add(berstdruck); 
                            }
                        } 
                    }
                }
                catch (Exception)
                {

                    //throw;
                }
            }

            return BDruckList;
        }

        public static string[] GetXmlFiles(string root)
        {
            return Directory.GetFiles(root, "*.xml");
        }

        public static Berstdruck GetBerstdruck(string filepath)
        {
            //Create the XmlDocument.
            XmlDocument doc = new XmlDocument();

            Berstdruck berstdruck = new Berstdruck();

            try
            {
                doc.Load(filepath);

                XmlNodeList elemList = doc.GetElementsByTagName("LEVEL1");

                berstdruck.FilePath = filepath;
                berstdruck.WerkzeugID = (elemList[0].Attributes["Programmname"].Value).Substring(0, 3).ParseShort();

                berstdruck.Level1.Programmname = elemList[0].Attributes["Programmname"].Value;
                berstdruck.Level1.Schweissfolge = Convert.ToInt16(elemList[0].Attributes["Schweissfolge"].Value);
                berstdruck.Level1.Schweissanlage = Convert.ToInt16(elemList[0].Attributes["Schweissanlage"].Value);
                berstdruck.Level1.Pruefungsart = elemList[0].Attributes["Pruefungsart"].Value;
                berstdruck.Level1.BD = elemList[0].Attributes["BD"].Value;
                berstdruck.Level1.TStamp = Convert.ToDateTime(elemList[0].Attributes["TStamp"].Value);

                elemList = doc.GetElementsByTagName("LEVEL2");

                berstdruck.Level2.BauteilDM = elemList[0].Attributes["Bauteil-DM"].Value;
                berstdruck.Level2.Mindestberstdruck = Convert.ToDouble(elemList[0].Attributes["Mindestberstdruck"].Value);
                berstdruck.Level2.Istberstdruck = Convert.ToDouble(elemList[0].Attributes["Ist-Berstdruck"].Value);
                berstdruck.Level2.Istdruck2 = Convert.ToDouble(elemList[0].Attributes["Ist-Druck2"].Value);
                berstdruck.Level2.Ergebnis = elemList[0].Attributes["Ergebnis"].Value;
            }
            catch (Exception)
            {

                //throw;
            }

            return berstdruck;
        }
    }
}
