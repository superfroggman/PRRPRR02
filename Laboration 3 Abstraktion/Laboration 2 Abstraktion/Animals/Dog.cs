using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_2_Abstraktion.Animals
{
    class Dog : Animal
    {
        public Dog()
        {
            price = 10000;
            cuteness = 9;
            energy = 10;

            name = "Dog";
        }

        public override void MakeNoise()
        {
            Console.WriteLine("Woof woof!");
        }

        public override void Eat()
        {
            Console.WriteLine("Shlafs shlafs...");
        }
    }
}
