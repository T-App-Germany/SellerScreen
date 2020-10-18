using System;

namespace SellerScreen
{
    public class PathName
    {
        public readonly string settingsFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\T-App Germany\\SellerScreen\\Settings\\";
        public readonly string productsFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\T-App Germany\\SellerScreen\\Products\\";
        public readonly string staticsTotalFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\T-App Germany\\SellerScreen\\Statics\\Total\\";
        public readonly string staticsDayFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\T-App Germany\\SellerScreen\\Statics\\Day\\";
        public readonly string graphicsFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures) + "\\T-App Germany\\SellerScreen\\Graphics\\";
        public readonly string tempFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\T-App Germany\\SellerScreen\\temp\\";
        public readonly string logFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\T-App Germany\\SellerScreen\\log\\";
    }
}