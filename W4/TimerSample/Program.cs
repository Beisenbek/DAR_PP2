using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TimerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += DoIt;
            timer.Start();
            for (int i = 0; i < 10000; ++i)
            {
                Console.WriteLine("ok");
                Thread.Sleep(500);
            }
        }

        private static void DoIt(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }
    }
}
