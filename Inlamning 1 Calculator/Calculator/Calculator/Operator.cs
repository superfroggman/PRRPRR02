using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Operator
    {
        public char _op = '+';
        public int _pred = 0;

        public Operator(char op, int pred)
        {
            _op = op;
            _pred = pred;
        }
    }
}
