using System;

namespace TimerEvent
{
    public interface ICutDownNotifier
    {
        void Init();
        void Run();
    }

    public class UserClassMethod : ICutDownNotifier
    {
        private readonly TimerClass timer;

        public UserClassMethod(TimerClass timer)
        {
            this.timer = timer ?? throw new ArgumentNullException();
        }
        public void Init()
        {
            timer.TimerStop += Timer_TimerStop;
            timer.RemainingTime += Timer_RemainingTime;
        }

        private void Timer_RemainingTime(object sender, MyEventArgs e)
        {
            if (sender is TimerClass sendTimer)
            {
                Console.WriteLine($"Message from \"{sendTimer.Name}\": {e.RemainigTime} seconds left");
            }
            else
                throw new ArgumentException("Incorrect type", "sender");
        }

        private void Timer_TimerStop(object sender, EventArgs e)
        {
            if (sender is TimerClass sendTimer)
            {
                Console.WriteLine($"The \"{sendTimer.Name}\" timer has completed the countdown.");
            }
            else
                throw new ArgumentException("Incorrect type", "sender");
        }

        public void Run()
        {
            Console.WriteLine($"The {timer.Name} timer started counting down.");
            timer.TimerStart();
        }
    }
}
