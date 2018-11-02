using System;
using System.Windows;

namespace WpfApp2
{
    class MyMain
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new MainWindow());
        }
    }
}
