using System;
using System.IO;
using System.Xml.Serialization;

namespace SellerScreen
{
    [Serializable]
    public class ProductsData
    {
        public bool ProductStatus;
        public short ProductNumber;
        public double ProductPrice;
        public string ProductName;

        public void Save(short id)
        {
            PathName path = new PathName();

            using (FileStream stream = new FileStream(path.productsFile + id + ".xml", FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(ProductsData));
                XML.Serialize(stream, this);
            }
        }

        public static ProductsData Load(short id)
        {
            PathName path = new PathName();

            using (FileStream stream = new FileStream(path.productsFile + id + ".xml", FileMode.Open))
            {
                XmlSerializer XML = new XmlSerializer(typeof(ProductsData));
                return (ProductsData)XML.Deserialize(stream);
            }
        }
    }
}