using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Rules
    {
        public static bool IsNonZeroDigit(string msg)
        {
            char[] arr = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return arr.Contains(msg[0]);
        }
        public static bool IsDigit(string msg)
        {
            char[] arr = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return arr.Contains(msg[0]);
        }
        public static bool IsZero(string msg)
        {
            char[] arr = new char[] { '0' };
            return arr.Contains(msg[0]);
        }
        public static bool IsOperation(string msg)
        {
            char[] arr = new char[] { '+','-' };
            return arr.Contains(msg[0]);
        }
    }
}
