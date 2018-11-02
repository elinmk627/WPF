using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SelectColorFromGrid {
    class Test {
        static void Main() { }
    }

    public class ColorGridBox : ListBox  {
        // 화면에 출력할 칼러 목록.
        string[] strColor =
        {
             "Black", "Brown", "DarkGreen", "MidnightBlue",
             "Navy", "DarkBlue", "Indigo", "DimGray",
             "DarkRed", "OrangeRed", "Olive", "Green",
             "Teal", "Blue", "SlateGray", "Gray",
             "Red", "Orange", "YellowGreen", "SeaGreen",
             "Aqua", "LightBlue", "Violet", "DarkGray",
             "Pink", "Gold", "Yellow", "Lime",
             "Turquoise", "SkyBlue", "Plum", "LightGray",
             "LightPink", "Tan", "LightYellow", "LightGreen",
             "LightCyan", "LightSkyBlue", "Lavender", "White"
        };

        public ColorGridBox() {
            // ItemsPanel template을 정의
            FrameworkElementFactory factoryUnigrid = new FrameworkElementFactory(typeof(UniformGrid));
            factoryUnigrid.SetValue(UniformGrid.ColumnsProperty, 8);    // 그리드박스 컬럼8개지정

            // ListBox의 ItemsPanel 속성에 UniformGrid로 설정
            ItemsPanel = new ItemsPanelTemplate(factoryUnigrid);

            // ListBox에 아이템을 넣는다.
            foreach(string strColor in strColor) {
                // 직사각형(Rectangle)을 생성하고 ListBox에 넣는다.
                Rectangle rect = new Rectangle();
                rect.Width = 12;
                rect.Height = 12;
                rect.Margin = new Thickness(4);

                rect.Fill = (Brush)typeof(Brushes).GetProperty(strColor).GetValue(null, null);
                Items.Add(rect);

                // 직사각형(Rectangle에 툴팁 추가 / 마우스 갖다대면 풍선글에 칼라색깔나오게)
                ToolTip tip = new ToolTip();                tip.Content = strColor;                rect.ToolTip = tip;
            }
            SelectedValuePath = "Fill";
        }
    }
}
