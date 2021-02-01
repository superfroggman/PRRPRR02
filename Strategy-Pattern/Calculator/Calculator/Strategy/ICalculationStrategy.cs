using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Strategy
{
    interface ICalculationStrategy
    {
        double Calculate(double num1, double num2);
    }
}
