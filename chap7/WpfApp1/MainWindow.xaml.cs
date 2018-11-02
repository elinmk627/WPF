using System;
using System.Windows;

namespace WpfApp1 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void OnExit(object sender, RoutedEventArgs e) {
            //Application.Current.Shutdown();
            Environment.Exit(0);
        }
    }
}
