using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi!");

            for (int i = 0; i < args.Length; ++i)
            {
                Console.WriteLine(args[i]);
            }
        }
    }
}
