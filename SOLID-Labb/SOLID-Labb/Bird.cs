using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Labb
{
    class Bird : Animal
    {
        public Bird(string color): base(color)
        {
            
        }

        public override void Eat()
        {
            Console.WriteLine("Bird is chirping!");
        }

        public override void Sleep()
        {
            Console.WriteLine("Bird is sleeping!");
        }

        public override void Speak()
        {
            Console.WriteLine("Bird is peck-peck-pecking away!");
        }
    }
}
