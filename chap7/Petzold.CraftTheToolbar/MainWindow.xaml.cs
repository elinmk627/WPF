using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Petzold.CraftTheToolbar {
    public class MainWindow : Window {
        [STAThread]
        public static void Main()  {
            Application app = new Application();
            app.Run(new MainWindow());
        }

        public MainWindow()  {
            Title = "Craft the Toolbar";
            // RoutedUICommand는 RoutedCommand를 상속받은 것으로 Text 속성을 갖는다.
            // MenuItem같은 HeaderedItemsControl을 상속받은 객체들이 Command에 RoutedUICommand를 설정하면
        // MenuItem의 Header값으로 RoutedUICommand.Text 값을 사용하게 됩니다.
     RoutedUICommand[] comm =
     {
     ApplicationCommands.New, ApplicationCommands.Open,
     ApplicationCommands.Save, ApplicationCommands.Print,
     ApplicationCommands.Cut, ApplicationCommands.Copy,
     ApplicationCommands.Paste, ApplicationCommands.Delete
     };
            string[] strImages =
            {
 "NewDocumentHS.png", "openHS.png", "saveHS.png",
 "PrintHS.png", "CutHS.png", "CopyHS.png",
 "PasteHS.png", "DeleteHS.png"
 };
            // Window의 Content로 DockPanel을 등록
            DockPanel dock = new DockPanel();
            dock.LastChildFill = false;
            Content = dock;
            // 툴바를 윈도우의 TOP으로 도킹
            ToolBar toolbar = new ToolBar();
            dock.Children.Add(toolbar);
            DockPanel.SetDock(toolbar, Dock.Top);
            // 툴바 버튼들을 생성
            for (int i = 0; i < 8; i++)
            {
                if (i == 4)
                    toolbar.Items.Add(new Separator());
                // 하나의 버튼을 생성해서 툴바에 추가 
            Button btn = new Button();
                btn.Command = comm[i];
                toolbar.Items.Add(btn);

                // 버튼의 Content로써 이미지를 생성
                Image img = new Image();
                img.Source = new BitmapImage(
                new Uri("pack://application:,,/Images/" + strImages[i]));
                // Fill : 공간에 가득채움, 이미지 왜곡
                // Uniform : 가로세로 비율에 맞게 한쪽 끝이 찰때까지 늘임
                // UniformToFill : 가로세로 비율에 맞게 공간에 찰때까지 계속늘임
                // None : 원래 이미지 대로
                img.Stretch = Stretch.None; //원래의 이미지대로
                btn.Content = img;
                // UICommand의 Text를 기반으로 툴팁 생성
                ToolTip tip = new ToolTip();
                tip.Content = comm[i].Text;
                btn.ToolTip = tip;
                // 윈도우의 CommandBindings에 UIComment를 추가
                // 이벤트핸들러 메소드 추가
                CommandBindings.Add(
                new CommandBinding(comm[i], ToolBarButtonOnClick));
            }
        }
        // 버튼의 이벤트 핸들러
        void ToolBarButtonOnClick(object sender, ExecutedRoutedEventArgs args)
        {
            RoutedUICommand comm = args.Command as RoutedUICommand;
            MessageBox.Show(comm.Name +
            " command not yet implemented", Title);
        }
    }
}