using Laboration_2_Polymorfi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_1_OOP
{
    class Food : Product
    {
        public int _calories;
        public Food(string name, int cost, int calories)
        {
            _name = name;
            _cost = cost;
            _calories = calories;
        }
    }
}
