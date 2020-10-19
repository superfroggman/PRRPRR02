using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_2_Polymorfi
{
    class Drink : Product
    {
        public int _size;
        public Drink(string name, int cost, int size)
        {
            _name = name;
            _cost = cost;
            _size = size;
        }
    }
}
