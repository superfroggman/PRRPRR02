using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Strategy
{
    class SubtractionStrategy : ICalculationStrategy
    {
        public double Calculate(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
