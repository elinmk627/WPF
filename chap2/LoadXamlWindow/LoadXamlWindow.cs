using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace LoadXamlWindow {
    class LoadXamlWindow  {

        [STAThread]
        public static void Main() {
            Application app = new Application();
            // 'Pack Uri 체계'를 통한 리소스 파일을 식별하여 로딩
            Uri uri = new Uri("pack://application:,,,/XamlWindow.xml");
            Stream stream = Application.GetResourceStream(uri).Stream;
            Window win = XamlReader.Load(stream) as Window;

            win.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click1));
            Button b = (Button)win.FindName("XamlButton");
            b.Click += Button_Click2;
            app.Run(win);
        }

        static void Button_Click1(object sender, RoutedEventArgs args) {
            MessageBox.Show((args.Source as Button).Content.ToString()+"1");
        }

        static void Button_Click2(object sender, RoutedEventArgs args) {
            MessageBox.Show(((Button)sender).Content.ToString() + "2");
        }
    }
}
