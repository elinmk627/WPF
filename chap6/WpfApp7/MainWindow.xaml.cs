﻿using System.Windows;

namespace WpfApp7 {
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void OnClicked(object sender, RoutedEventArgs args) {
            Emp e = Grid1.DataContext as Emp;
            System.Console.WriteLine(e.Ename);
            System.Console.WriteLine(e.City);
        }
    }
}
