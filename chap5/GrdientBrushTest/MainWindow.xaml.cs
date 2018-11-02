using System.Windows;
using System.Windows.Media;

namespace GrdientBrushTest {
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window  {
        public MainWindow() {
            InitializeComponent();

            Title = "Gradiate the Brush";

            LinearGradientBrush brush = new LinearGradientBrush(Colors.Red, Colors.Blue, 
                new Point(0, 0), new Point(1, 1));
            Background = brush;
        }
    }
}
