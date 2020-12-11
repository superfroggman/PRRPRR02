using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_2_Abstraktion
{
    abstract class Animal : Product
    {
        public int cuteness;
        public int energy;

        public abstract void MakeNoise();

        public abstract void Eat();
    }
}
