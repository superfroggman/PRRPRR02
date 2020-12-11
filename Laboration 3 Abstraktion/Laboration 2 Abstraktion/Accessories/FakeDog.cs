using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_2_Abstraktion.Animals
{
    class FakeDog : Accessory
    {
        public FakeDog()
        {
            price = 100;
            coolness = 3;

            name = "Fake Dog";
        }

        public override void Destroy()
        {
            Console.WriteLine("Who destroys a dog? You monster...");
        }

        public override void Use()
        {
            Console.WriteLine("You try to walk the dog, it might be a dog toy now that you think about it.");
        }
    }
}
