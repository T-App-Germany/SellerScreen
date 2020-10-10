using System;
using System.IO;
using System.Xml.Serialization;

namespace SellerScreen
{
    [Serializable]
    public class StaticsTotalData
    {
        public DateTime startDate;
        public int totalCustomers;
        public int totalSoldProducts;
        public double totalGottenCash;
        public int totalLostProducts;
        public double totalLostCash;

        public TimeSpan[] totalPcTime = Array.Empty<TimeSpan>();
        public short[] totalPcUsers = Array.Empty<short>();

        public string[] mostSoldProductsName = new string[5];
        public string[] highestEarningsProductsName = new string[5];
        public short[] mostSoldProductsNumber = new short[5];
        public double[] highestEarningsProductsNumber = new double[5];
        public double[] mostSoldProductsSinglePrice = new double[5];
        public double[] highestEarningsProductsSinglePrice = new double[5];

        public string[] productsNameList = Array.Empty<string>();
        public short[] productsNumberList = Array.Empty<short>();
        public double[] productsCashList = Array.Empty<double>();
        public double[] productsSinglePriceList = Array.Empty<double>();

        public void Save()
        {
            PathName pathN = new PathName();

            using (FileStream stream = new FileStream($"{pathN.settingsFile}TotalStatics.xml", FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(StaticsTotalData));
                XML.Serialize(stream, this);
            }
        }

        public static StaticsTotalData Load()
        {
            PathName pathN = new PathName();

            using (FileStream stream = new FileStream($"{pathN.settingsFile}TotalStatics.xml", FileMode.Open))
            {
                XmlSerializer XML = new XmlSerializer(typeof(StaticsTotalData));
                return (StaticsTotalData)XML.Deserialize(stream);
            }
        }
    }
}