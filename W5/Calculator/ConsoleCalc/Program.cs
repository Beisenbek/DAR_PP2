using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            MyDelegate myDelegate = new MyDelegate(DisplayText2);
            Brain brain = new Brain(myDelegate);

            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                brain.Process(consoleKeyInfo.KeyChar.ToString());
            }
        }

        static void DisplayText2(string msg)
        {
            Console.Clear();
            Console.Write(msg);
        }
    }
}
