using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Strategy
{
    class Operator
    {
        //TODO: LÖS SÅ ATT DESSA HÄNGER MED
        char _op = '+';
        int _pred = 2;

        private ICalculationStrategy _strategy;

        //Constructor
        public Operator(ICalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        public double CalculationInterface(double num1, double num2)
        {
            return _strategy.Calculate(num1, num2);
        }
    }
}
