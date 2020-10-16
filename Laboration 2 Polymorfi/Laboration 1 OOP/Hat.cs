using Laboration_2_Polymorfi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_1_OOP
{
    class Hat : Product
    {
        public int _coolness;
        public Hat(string name, int cost, int coolness)
        {
            _name = name;
            _cost = cost;
            _coolness = coolness;
        }
    }
}
