using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Labb
{
    class Hedgehog : Animal
    {
        public Hedgehog(string color): base(color)
        {
            _phrase = "Hedgehog is omnomnoming!";
        }

        public override void Eat()
        {
            Console.WriteLine("Hedgehog is squeeking!");
        }

        public override void Sleep()
        {
            Console.WriteLine("Hedgehog is napping!");
        }

        public override void Speak()
        {
            Console.WriteLine(_phrase);
        }
    }
}
