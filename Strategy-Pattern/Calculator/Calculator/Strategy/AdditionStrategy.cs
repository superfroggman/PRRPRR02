using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Strategy
{
    class AdditionStrategy : ICalculationStrategy
    {
        public char _op = '+';
        public int _pred = 2;

        public double Calculate(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}
