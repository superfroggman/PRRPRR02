using System;

namespace SOLID_Labb
{
    class Program
    {
        static void Main(string[] args)
        {
            Human[] humans = {new Human("Niklas")};
            Animal[] animals = {new Dog("Black"),
                            new Hedgehog("Pink"),
                            new Bird("Yellow")};

            Console.WriteLine("###############");
            Console.WriteLine();

            foreach (var animal in animals)
            {
                if (animal is Dog dog)
                {
                    Human human = humans[0];
                    human.GainOwnership(dog);
                    dog._phrase = "Dog is eating. " + human.name + " is happy";
                }

                animal.Eat();
                animal.Sleep();
                animal.Speak();
                animal._color = "Grey";
                Console.WriteLine(animal.GetType().Name + " is " + animal._color);
                Console.WriteLine();

                Console.WriteLine("###############");
                Console.WriteLine();
            }
        }
    }
}
