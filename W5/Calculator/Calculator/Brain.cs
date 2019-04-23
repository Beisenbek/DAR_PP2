using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    enum CalcState
    {
        Zero,
        AccumulateDigits,
        Compute,
        Result
    }

    class Brain
    {
        MyDelegate myDelegate;
        CalcState curState = CalcState.Zero;
        string firstNumber = "";
        public Brain(MyDelegate myDelegate)
        {
            this.myDelegate = myDelegate;
        }

        public void Process(string text)
        {
            switch (curState)
            {
                case CalcState.Zero:
                    Zero(false, text);
                    break;
                case CalcState.AccumulateDigits:
                    AccumulateDigits(false, text);
                    break;
                case CalcState.Compute:
                    break;
                case CalcState.Result:
                    break;
                default:
                    break;
            }
        }

        void Zero(bool isInput, string msg)
        {
            if (isInput)
            {
                curState = CalcState.Zero;
            }
            else
            {
                if (Rules.IsNonZeroDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
            }
        }

        void AccumulateDigits(bool isInput, string msg)
        {
            if (isInput)
            {
                curState = CalcState.AccumulateDigits;
                firstNumber = firstNumber + msg;
                myDelegate.Invoke(firstNumber);
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
            }
        }
    }

    public delegate void MyDelegate(string msg);

}
