using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Strategy
{
    class Calculation
    {
        private ICalculationStrategy _strategy;

        //Constructor
        public Calculation(ICalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        public double CalculationInterface(double num1, double num2)
        {
            return _strategy.Calculate(num1, num2);
        }
    }
}
