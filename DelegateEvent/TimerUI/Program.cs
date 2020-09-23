using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerEvent;

namespace TimerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("An application that demonstrates how the TimerEvent class works\nWaiting time in seconds: ");
            
            var input = Console.ReadLine();
            if(!Int32.TryParse(input, out int time))
            {
                Console.WriteLine("Invalid data");
                return;
            }

            TimerClass timer = new TimerClass(time, "TestTimer");
            timer.TimerStop += Timer_TimerEvent;
            timer.RemainingTime += Timer_RemainingTime;
            timer.TimerStart();

            Console.ReadLine();
        }

        private static void Timer_RemainingTime(object sender, EventArgs e)
        {
            Console.WriteLine($"There are now {((MyEventArgs)e).RemainigTime} seconds until site termination");
        }

        private static void Timer_TimerEvent(object sender, EventArgs e)
        {
            if(sender is TimerClass)
            Console.WriteLine($"Timer {((TimerClass)sender).Name} stopped");
        }
    }
}
