using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Addition : Operator
    {
        
        public Addition()
        {
            _op = '+';
            _pred = 2;
        }

        public override double Operate(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}
