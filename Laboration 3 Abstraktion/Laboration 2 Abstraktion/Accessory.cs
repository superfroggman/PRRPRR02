using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_2_Abstraktion
{
    abstract class Accessory : Product
    {
        public int coolness;
        

        public abstract void Destroy();

        public abstract void Use();
    }
}
