using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Labb
{
    class Dog : Animal
    {
        public Dog(string color): base(color)
        {
            _phrase = "Dog is eating. Human is happy!";
        }

        public override void Eat()
        {
            Console.WriteLine("Dog is barking!");
        }

        public override void Sleep()
        {
            Console.WriteLine("Dog is sleeping!");
        }

        public override void Speak()
        {
            Console.WriteLine(_phrase);
            //TODO: add     
        }
    }
}
