﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_1_OOP
{
    class Customer
    {
        public string _name;

        public List<Product> _products = new List<Product>();

        public Customer(string name)
        {
            _name = name;
        }
    }
}
