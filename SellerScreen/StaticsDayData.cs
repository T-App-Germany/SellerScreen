using System;
using System.IO;
using System.Xml.Serialization;

namespace SellerScreen
{
    [Serializable]
    public class StaticsDayData
    {
        public string[] StaticsDaySoldSlotName = Array.Empty<string>();
        public short[] StaticsDaySoldSlotNumber = Array.Empty<short>();
        public double[] StaticsDaySoldSlotCash = Array.Empty<double>();
        public double[] StaticsDaySoldSlotSinglePrice = Array.Empty<double>();
        public short StaticsDayLostProducts;
        public double StaticsDayLostCash;

        public TimeSpan[] StaticsDayPcUsage = Array.Empty<TimeSpan>();
        public short[] StaticsDayPcUsers = Array.Empty<short>();
        public string[] StaticsDayPcName = Array.Empty<string>();

        public void Save()
        {
            PathName pathN = new PathName();

            using (FileStream stream = new FileStream(path: $"{pathN.staticsFile}{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}.xml", FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(StaticsDayData));
                XML.Serialize(stream, this);
            }
        }

        public static StaticsDayData Load(DateTime date)
        {
            string day = date.Day.ToString();
            string month = date.Month.ToString();
            string year = date.Year.ToString();

            PathName pathN = new PathName();

            using (FileStream stream = new FileStream($"{pathN.staticsFile}{day}_{month}_{year}.xml", FileMode.Open))
            {
                XmlSerializer XML = new XmlSerializer(typeof(StaticsDayData));
                return (StaticsDayData)XML.Deserialize(stream);
            }
        }
    }
}