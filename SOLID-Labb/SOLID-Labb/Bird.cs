using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Labb
{
    class Bird : Animal
    {
        public Bird(string color): base(color)
        {
            _phrase = "Bird is peck-peck-pecking away!";
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
            Console.WriteLine(_phrase);
        }
    }
}
