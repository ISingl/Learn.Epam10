using System;
using System.Threading;

namespace TimerEvent
{
    public class MyEventArgs:EventArgs
    {
        public int RemainigTime { get; private set; }

        public void SetRemainigTime(int seconds)
        {
            RemainigTime = seconds;
        }
    }
    public class TimerClass
    {
        public event EventHandler TimerStop;
        public event EventHandler<MyEventArgs> RemainingTime;

        public string Name { get; set; }
        public int TimerTime { get; private set; }

        /// <summary>
        /// Timer class instance
        /// </summary>
        /// <param name="timerTime">Time in seconds</param>
        public TimerClass(int timerTime)
        {
            TimerTime = timerTime;
        }
        /// <summary>
        /// Timer class instance
        /// </summary>
        /// <param name="timerTime">Time in seconds</param>
        /// <param name="name">Name timer</param>
        public TimerClass(int timerTime, string name)
        {
            TimerTime = timerTime;
            Name = name;
        }

        public void TimerStart()
        {

            MyEventArgs eventArgs = new MyEventArgs();
            for (int i = 0; i < TimerTime; i++)
            {
                eventArgs.SetRemainigTime(TimerTime - i);
                RemainingTime?.Invoke(this, eventArgs);

                Thread.Sleep(1000);
            }
            TimerStop?.Invoke(this, null);
        }
    }
}
