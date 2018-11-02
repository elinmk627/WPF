using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HelloWorld2 {
    class MyMain {

        [STAThread]
        public static void Main() {
            Window mainWindow = new Window();
            mainWindow.Title = "WPF Sample(Main)";
            mainWindow.MouseDown += WinMouseDown;   // 메인 윈도우에서 마우스다운 메소드실행

            Application app = new Application();
            app.ShutdownMode = ShutdownMode.OnLastWindowClose;        // 마지막 윈도우 죽으면 셧다운됨
            app.Run(mainWindow);

            for (int i = 0; i < 2; i++) {
                Window win = new Window();
                win.Title = "Extra Window No. " + (i + 1);
                //win.ShowInTaskbar = false;        // 실행하면 하단 태스크바에 위도우 아이콘 하나만 나타나게       
                win.Owner = mainWindow;          // 메인창이 나머지 두개의 창을 소유한 owner가됨
                win.Show();                                   // 서브윈도우창 실행
            }                        
        }    

        static void WinMouseDown(Object sender, MouseEventArgs args) {
            Window win = new Window();
            win.Title = "Modal DialogBox";
            win.Width = 400;
            win.Height = 200;

            Button b = new Button();
            b.Content = "Click Me!";     // 버튼에 보이는 글씨
            b.Click += Button_Click;

            win.Content = b;                // 윈도우에 Content속성에 버튼이벤트 넣기
            win.ShowDialog();              // 모달창(뒤에 건들일수 없는 창)으로 실행
        }

        static void Button_Click(object sender, EventArgs e) {
            MessageBox.Show("Button Click!", sender.ToString());
        }
    }
}
