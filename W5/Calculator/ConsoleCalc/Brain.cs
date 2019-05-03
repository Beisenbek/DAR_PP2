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
        string currentNumber = "";
        string resultNumber = "";
        string operation = "";
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
                    Compute(false, text);
                    break;
                case CalcState.Result:
                    Result(false, text);
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
                currentNumber = currentNumber + msg;
                myDelegate.Invoke(currentNumber);
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }else if (Rules.IsOperation(msg))
                {
                    Compute(true, msg);
                }else if (Rules.IsEqualSign(msg))
                {
                    Result(true, msg);
                }
            }
        }

        void Compute(bool isInput, string msg)
        {
            if (isInput)
            {
                curState = CalcState.Compute;
                operation = msg;
                resultNumber = currentNumber;
                currentNumber = "";
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
            }
        }

        void Result(bool isInput, string msg)
        {
            if (isInput)
            {
                curState = CalcState.Result;

                if (operation == "+")
                {
                    resultNumber = (int.Parse(resultNumber) + int.Parse(currentNumber)).ToString();
                    myDelegate(resultNumber);
                    resultNumber = "";
                    currentNumber = "";
                    operation = "";
                }
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
