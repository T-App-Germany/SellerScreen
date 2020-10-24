using System;
using System.IO;
using System.Xml.Serialization;

namespace SellerScreen
{
    [Serializable]
    public class StorageData
    {
        public short[] InStorageSlots = Array.Empty<short>();

        public void Save()
        {
            PathName path = new PathName();

            using (FileStream stream = new FileStream(path.settingsFile + "Storage.xml", FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(StorageData));
                XML.Serialize(stream, this);
            }
        }

        public static StorageData Load()
        {
            PathName path = new PathName();

            using (FileStream stream = new FileStream(path.settingsFile + "Storage.xml", FileMode.Open))
            {
                XmlSerializer XML = new XmlSerializer(typeof(StorageData));
                return (StorageData)XML.Deserialize(stream);
            }
        }
    }
}