using System.Windows;
using System.Windows.Controls;

namespace SellerScreen
{
    public partial class EditStorageSlot : Window
    {
        public string slotName = "";
        public double slotPrice = 0;
        public bool slotStatus = false;
        public short slotNumber = 0;
        private readonly short id = 0;
        private readonly string task = "";
        private readonly ThemeData themeData = new ThemeData();
        private readonly string AppThemeStr = "System";

        public EditStorageSlot(string windowTask, short idForTask)
        {
            InitializeComponent();
            id = idForTask;
            task = windowTask;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (task == "edit")
            {
                SlotNameTxtBox.Text = slotName;
                NumberLbl.Content = slotNumber.ToString();
                SlotPriceTxtBox.Text = slotPrice.ToString();
                if (slotStatus == false)
                {
                    ActivateBtn.IsChecked = false;
                    DeactivateBtn.IsChecked = true;
                }
                else
                {
                    ActivateBtn.IsChecked = true;
                    DeactivateBtn.IsChecked = false;
                }

                Title = $"Produkt bearbeiten: {id + 1}";
            }
            else if (task == "new")
            {
                SlotNameTxtBox.Text = "";
                NumberLbl.Content = "0";
                SlotPriceTxtBox.Text = "0";
                slotStatus = false;
                ActivateBtn.IsChecked = false;
                DeactivateBtn.IsChecked = false;
                Title = $"Produkt hinzufügen";
            }

            SetAppTheme();
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            slotName = SlotNameTxtBox.Text;
            slotNumber += short.Parse(SlotAddNumberTxtBox.Text);
            slotPrice = double.Parse(SlotPriceTxtBox.Text);

            DialogResult = true;
        }

        private void SlotNameTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = SlotNameTxtBox.Text.Length;
            SlotNameTxtBoxCouterLbl.Content = i + "/32";
        }

        private void DeactivateBtn_Click(object sender, RoutedEventArgs e)
        {
            ActivateBtn.IsChecked = false;
            slotStatus = false;
        }

        private void ActivateBtn_Click(object sender, RoutedEventArgs e)
        {
            DeactivateBtn.IsChecked = false;
            slotStatus = true;
        }

        private void SetAppTheme()
        {
            if (AppThemeStr == "System")
            {
                string initialTheme = themeData.GetWindowsAppTheme().ToString();
                if (initialTheme == "Dark")
                {
                    ApplyDarkTheme();
                }
                else if (initialTheme == "Light")
                {
                    ApplyLightTheme();
                }
            }
            else if (AppThemeStr == "Light")
            {
                ApplyLightTheme();
            }
            else if (AppThemeStr == "Dark")
            {
                ApplyDarkTheme();
            }
        }

        private void ApplyLightTheme()
        {
            TextFontColor.Background = themeData.GetLightTheme("TextFontColor");
            SideBarsColor.Background = themeData.GetLightTheme("SideBarsColor");
            PageBackgroudColor.Background = themeData.GetLightTheme("PageBackgroudColor");
        }

        private void ApplyDarkTheme()
        {
            TextFontColor.Background = themeData.GetDarkTheme("TextFontColor");
            SideBarsColor.Background = themeData.GetDarkTheme("SideBarsColor");
            PageBackgroudColor.Background = themeData.GetDarkTheme("PageBackgroudColor");
        }
    }
}