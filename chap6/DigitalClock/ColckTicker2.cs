using System;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;

namespace DigitalClock
{
    public class ColckTicker2 : INotifyPropertyChanged  {
        // INotyfyPropertyChanged 인터페이스가 요구하는 이벤트
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime DateTime {
            get { return DateTime.Now; }
        }

        // 생성자에서 Timer를 설정
        public ColckTicker2() {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += TimerOnTick;
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Start();
        }

        // PropertyChanged 이벤트를 발생시키는 타이버 이벤트 핸들러
        void TimerOnTick(object sender, EventArgs args) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
            }
        }
    }
}
