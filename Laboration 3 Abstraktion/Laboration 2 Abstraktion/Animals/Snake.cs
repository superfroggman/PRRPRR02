using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_2_Abstraktion.Animals
{
    class Snake : Animal
    {
        public Snake()
        {
            price = 300;
            cuteness = 2;
            energy = 2;

            name = "Snake";
        }

        public override void MakeNoise()
        {
            Console.WriteLine("sssSSSsssSSSsss");
        }

        public override void Eat()
        {
            Console.WriteLine("-----======----:)");
        }
    }
}
