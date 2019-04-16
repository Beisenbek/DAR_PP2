using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(DoIt);
            Thread thread = new Thread(threadStart);
            thread.Start();

            for(int i = 0; i < 10000000; ++i)
            {
                Console.WriteLine("hello!");
            }
        }
        static void DoIt()
        {
            for (int i = 0; i < 10000000; ++i)
            {
                Console.WriteLine("hi!");
            }
        }
    }
}
