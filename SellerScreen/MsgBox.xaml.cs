using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace SellerScreen
{
    public partial class MsgBox : Window
    {
        public enum MsgButtons
        {
            Ok,
            OkCancel,
            YesNo,
        }
        public enum MsgIcon
        {
            Info,
            Warning,
            Error,
            Question,
            No,
            Ok,
        }

        public MsgBox(string text, string header, MsgButtons buttons, MsgIcon icon)
        {
            InitializeComponent();
            TextBlock.Text = text;
            Title = header;
            ButtonPanel.Children.Clear();
            IconVbox.Visibility = Visibility.Collapsed;

            if (buttons == MsgButtons.YesNo)
            {
                Button btn = new Button
                {
                    Content = "Ja",
                    Margin = new Thickness(10),
                    Width = 104,
                    IsDefault = true
                };
                btn.Click += new RoutedEventHandler(DefaulBtn_Click);

                Button btn2 = new Button
                {
                    Content = "Nein",
                    Width = 104,
                    Margin = new Thickness(10),
                    IsCancel = true
                };

                ButtonPanel.Children.Add(btn);
                ButtonPanel.Children.Add(btn2);
            }
            else if (buttons == MsgButtons.OkCancel)
            {
                Button btn = new Button
                {
                    Content = "Ok",
                    Margin = new Thickness(10),
                    Width = 104,
                    IsDefault = true
                };

                Button btn2 = new Button
                {
                    Content = "Abbrechen",
                    Margin = new Thickness(10),
                    Width = 104,
                    IsCancel = true
                };

                ButtonPanel.Children.Add(btn);
                ButtonPanel.Children.Add(btn2);
            }
            else
            {
                Button btn = new Button
                {
                    Content = "Ok",
                    Margin = new Thickness(10),
                    Width = 104,
                    IsDefault = true
                };
                btn.Click += new RoutedEventHandler(DefaulBtn_Click);
            }

            string xamlString = "";
            if (icon == MsgIcon.Error)
            {
                xamlString = XamlWriter.Save(ErrorVbox);
            }
            else if (icon == MsgIcon.Info)
            {
                xamlString = XamlWriter.Save(InfoVbox);
            }
            else if (icon == MsgIcon.Warning)
            {
                xamlString = XamlWriter.Save(WarningVbox);
            }
            else if (icon == MsgIcon.Question)
            {
                xamlString = XamlWriter.Save(QuestionVbox);
            }
            else if (icon == MsgIcon.No)
            {
                xamlString = XamlWriter.Save(NoVbox);
            }
            else if (icon == MsgIcon.Ok)
            {
                xamlString = XamlWriter.Save(OkVbox);
            }

            StringReader stringReader = new StringReader(xamlString);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            Viewbox vBox = (Viewbox)XamlReader.Load(xmlReader);
            ContentGrid.Children.Add(vBox);
        }

        private void DefaulBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
