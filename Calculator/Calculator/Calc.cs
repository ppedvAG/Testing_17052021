using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Calculator.Tests")]
namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            return checked(a + b);
        }

        internal bool IstEsHeiß(int temp)
        {
            if (temp >= 20)
                return true;
            else
                return false;
        }
    }
}
