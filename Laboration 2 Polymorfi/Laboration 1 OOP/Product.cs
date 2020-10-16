using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_2_Polymorfi
{
    class Product : ICloneable
    {
        public string _name;
        public int _cost;
        public int _amount = 0;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
