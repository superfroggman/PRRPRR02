using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_2_Abstraktion.Animals
{
    class Spider : Animal
    {
        public Spider()
        {
            price = 100;
            cuteness = 1;
            energy = 4;

            name = "Spider";
        }

        public override void MakeNoise()
        {
            Console.WriteLine("*spider noises*");
        }

        public override void Eat()
        {
            Console.WriteLine("pizza time");
        }
    }
}
