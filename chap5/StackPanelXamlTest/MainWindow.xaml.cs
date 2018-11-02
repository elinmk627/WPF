using System.Windows;
using System.Windows.Controls;

namespace StackPanelXamlTest {
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnAddMore_Click(object sender, RoutedEventArgs e) {
            Button newBtn = new Button();
            newBtn.Content = "A New Button";
            newBtn.Click += new RoutedEventHandler(newBtn_Click);
            stackPanel.Children.Add(newBtn);
        }

        private void newBtn_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("New Button Clicked!", "I got pressed");

            Label newLbl = new Label();
            newLbl.Content = "Hi~!";
            stackPanel.Children.Add(newLbl);
        }
    }
}
