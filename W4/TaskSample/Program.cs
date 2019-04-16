using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Action action = new Action(DoIt);
            Task task = new Task(action);
            task.Start();
            task.Wait(3000);
            //task.RunSynchronously();
            //Thread.CurrentThread.Join();
        }

        static void DoIt()
        {
            Thread.Sleep(2000);
            Console.WriteLine("ok" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
