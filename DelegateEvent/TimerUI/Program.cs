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
            Console.WriteLine(String.Empty);

            TimerClass timer = new TimerClass(time, "TestTimer");
            var user = new UserClassMethod(timer);
            user.Init();
            user.Run();
            Console.ReadLine();
        }
    }
}
