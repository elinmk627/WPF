using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Controls.Primitives;

namespace BindingLabelToScroll2 {
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            Binding bind = new Binding();
            bind.Source = scrollbar;  // scrollbar : xaml에서 선언한것 사용
            bind.Path = new PropertyPath(ScrollBar.ValueProperty);  
            label.SetBinding(Label.ContentProperty, bind);
        }
    }
}
