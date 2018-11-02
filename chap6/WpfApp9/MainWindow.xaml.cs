using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp9
{
    public partial class MainWindow : Window
    {
        internal static Duties duties = new Duties();
        public MainWindow()
        {
            InitializeComponent();
        }

        // 상단 ListBox의 항목(직무타입)을 선택했을 때
        private void OnSelected(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem != null)
            {
                string dutyType = ((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString();
                DataContext = from duty in duties
                              where duty.DutyType.ToString() == dutyType                              select duty;
            }
        }

        //하단 ListBox의 항목(직무)를 선택했을 때
        private void OnSelected2(object sender, SelectionChangedEventArgs e)
        {
            var duty = (Duty)myListBox2.SelectedItem;
            string value = duty == null ? "No selection" : duty.ToString();
            MessageBox.Show(duty.DutyName + "::" + duty.DutyType, "선택한 직무");
        }

        // 직무추가 버튼을 클릭 했을 때 새창을 띄움.
        private void OpenNewWindow(object sender, RoutedEventArgs e)
        {
            SubWindow subWindow = new SubWindow();            RefreshListEvent += new RefreshList(RefreshListBox); //event initialization
            subWindow.UpdateActor = RefreshListEvent; // assigningevent to the Delegate
            subWindow.Show();
        }

        // 아래쪽 ListBox를 Refresh 하기위한 델리게이트 및 이벤트
        public delegate void RefreshList(DutyType dutyType);
        public event RefreshList RefreshListEvent;

        // RefreshListEvent 이벤트가 발생했 을 때 호출되는 메소드
        private void RefreshListBox(DutyType dutyType)
        {
            myListBox1.SelectedItem = null;
            myListBox1.SelectedIndex = (dutyType == DutyType.Inner) ? 0 : 1;
        }
    }
}
