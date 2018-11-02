using System;
using System.Windows;
using System.Windows.Threading;
namespace DigitalClock {
    public class ClockTicker1 : DependencyObject {

        // 의존 프로퍼티 선언
        public static DependencyProperty DateTimeProperty =
        DependencyProperty.Register("DateTime", typeof(DateTime),
        typeof(ClockTicker1));

        // CLR property로 의존 프로퍼티를 노출
        public DateTime DateTime {
            set { SetValue(DateTimeProperty, value); }
            get { return (DateTime)GetValue(DateTimeProperty); }
        }

        // 생성자.
        public ClockTicker1() {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += TimerOnTick;
            timer.Interval = TimeSpan.FromSeconds(0.1); //1초에 한번씩
            timer.Start();
        }

        // DateTime property 값을 설정하기 위한 Timer 이벤트 핸들러
        void TimerOnTick(object sender, EventArgs args) {
            DateTime = DateTime.Now;
        }
    }
}