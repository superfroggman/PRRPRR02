using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Operator
    {
        public char _op = '+';
        public int _pred = 0;

        public virtual double Operate(double num1, double num2)
        {
            return 0;
        }
    }
}
