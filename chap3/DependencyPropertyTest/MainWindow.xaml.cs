using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DependencyPropertyTest {
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window  {
        public MainWindow() {
            InitializeComponent();
        }

        public String MyText {
            get { return (String)GetValue(MyProperty); }
            set { SetValue(MyProperty, value); }
        }

        // DependencyProperty 의존프로퍼티정의
        public static readonly DependencyProperty MyProperty = DependencyProperty.Register(
            "MyText",                       //등록할 의존성 속성 이름
            typeof(String),                
            typeof(MainWindow),
            // 값이 바뀌었을때 메소드 호출
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMyPropertyChanged)));

        // 색깔변경
        private static void OnMyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) { 
            MainWindow win = d as MainWindow;
            SolidColorBrush brush = (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewValue.ToString());
            win.Background = brush;
            win.Title = (e.OldValue == null) ? "제목없음" : e.OldValue.ToString();
            win.textBox1.Text = e.NewValue.ToString();
        }

        // 오른쪽버튼 메뉴클릭
        private void ContextMenu_Click(object sender, RoutedEventArgs e) {
            string str = (e.Source as MenuItem).Header as string;  // 색깔문자열 string으로 변경
            MyText = str;   // 색상을 mytext값으로 변경 -> OnMyPropertyChanged 호출됨
        }
    }
}
