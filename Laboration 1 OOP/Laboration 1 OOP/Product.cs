using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_1_OOP
{
    class Product
    {
        public string _name;
        public int _cost;
        public int _amount = 0;

        public Product(string name, int cost)
        {
            _name = name;
            _cost = cost;
        }
    }
}
