using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_2_Abstraktion.Animals
{
    class Hat : Accessory
    {
        public Hat()
        {
            price = 70;
            coolness = 9;

            name = "Hat";
        }

        public override void Destroy()
        {
            Console.WriteLine("The hat is indestructible");
        }

        public override void Use()
        {
            Console.WriteLine("You put the hat on a random animal, it looks nice.");
        }
    }
}
