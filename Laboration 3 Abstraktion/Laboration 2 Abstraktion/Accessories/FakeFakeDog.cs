using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_2_Abstraktion.Animals
{
    class FakeFakeDog : Accessory
    {
        public FakeFakeDog()
        {
            price = 4000;
            coolness = 7;

            name = "Fake Fake Dog";
        }

        public override void Destroy()
        {
            Console.WriteLine("You're confused and the dog destroys you instead.");
            Console.WriteLine("*YOU DIED*");
            System.Environment.Exit(1);
        }

        public override void Use()
        {
            Console.WriteLine("You try to walk the dog, it might be a dog toy now that you think about it. Wait no it's an actual dog.");
        }
    }
}
