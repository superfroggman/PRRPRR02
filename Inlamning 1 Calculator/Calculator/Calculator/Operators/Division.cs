using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Division : Operator
    {
        
        public Division()
        {
            _op = '/';
            _pred = 1;
        }

        public override double Operate(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}
