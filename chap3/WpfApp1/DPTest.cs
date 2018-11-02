using System.Diagnostics;
using System.Windows;

namespace WpfApp1 {
    public class DPTest : DependencyObject  {
        public static readonly DependencyProperty TestProperty = DependencyProperty.Register(
            "Test",
            typeof(string),
            typeof(DPTest),
            new PropertyMetadata("Dependency Property Initial Value",OnTestPropertyChanged));

        // 래퍼프로퍼티
        public string Test {  
            get {
                Debug.WriteLine("Test GetValue");
                return (string)GetValue(TestProperty);
            }
            set  {
                Debug.WriteLine("Text SetValue");
                SetValue(TestProperty, value);
            }
        }

        private static void OnTestPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            Debug.WriteLine("Property Changed : {0}", e.NewValue);
        }
    }
}
