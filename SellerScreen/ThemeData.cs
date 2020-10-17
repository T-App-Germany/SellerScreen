using Microsoft.Win32;
using System.Windows.Media;

namespace SellerScreen
{
    public class ThemeData
    {
        public enum WindowsTheme
        {
            Light,
            Dark
        }

        public readonly string RegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        public readonly string RegistryValueName = "AppsUseLightTheme";

        public WindowsTheme GetWindowsAppTheme()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                object registryValueObject = key?.GetValue(RegistryValueName);
                if (registryValueObject == null)
                {
                    return WindowsTheme.Light;
                }

                int registryValue = (int)registryValueObject;

                return registryValue > 0 ? WindowsTheme.Light : WindowsTheme.Dark;
            }
        }

        public Brush GetLightTheme(string control)
        {
            Brush TextFontColor = (Brush)new BrushConverter().ConvertFrom("#F000");
            Brush SideBarsColor = (Brush)new BrushConverter().ConvertFrom("#FF9ABBD8");
            Brush MainMenuGrid = (Brush)new BrushConverter().ConvertFrom("#FF6C91E2");
            Brush PageBackgroudColor = (Brush)new BrushConverter().ConvertFrom("#FFFFFFFF");
            Brush SeperatorColor = (Brush)new BrushConverter().ConvertFrom("#FFA0A0A0");
            Brush ChromeBtnColor = (Brush)new BrushConverter().ConvertFrom("#FF212121");

            if (control == "TextFontColor") return TextFontColor;
            if (control == "SideBarsColor") return SideBarsColor;
            if (control == "MainMenuGrid") return MainMenuGrid;
            if (control == "PageBackgroudColor") return PageBackgroudColor;
            if (control == "SeperatorColor") return SeperatorColor;
            if (control == "ChromeBtnColor") return ChromeBtnColor;
            else return null;
        }

        public Brush GetDarkTheme(string control)
        {
            Brush TextFontColor = (Brush)new BrushConverter().ConvertFrom("#FFFFFFFF");
            Brush SideBarsColor = (Brush)new BrushConverter().ConvertFrom("#48484A");
            Brush MainMenuGrid = (Brush)new BrushConverter().ConvertFrom("#FF6B6E80");
            Brush PageBackgroudColor = (Brush)new BrushConverter().ConvertFrom("#FF323232");
            Brush SeperatorColor = (Brush)new BrushConverter().ConvertFrom("#FFFFFFFF");
            Brush ChromeBtnColor = (Brush)new BrushConverter().ConvertFrom("#FFF6F6F6");

            if (control == "TextFontColor") return TextFontColor;
            if (control == "SideBarsColor") return SideBarsColor;
            if (control == "MainMenuGrid") return MainMenuGrid;
            if (control == "PageBackgroudColor") return PageBackgroudColor;
            if (control == "SeperatorColor") return SeperatorColor;
            if (control == "ChromeBtnColor") return ChromeBtnColor;
            else return null;
        }
    }
}
