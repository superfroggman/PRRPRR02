using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Niklas!");

            Console.WriteLine("Namn?");
            String name = Console.ReadLine();


            Console.WriteLine("Ålder?");
            String age = Console.ReadLine();

            Console.WriteLine("Levande?");
            String alive = Console.ReadLine();

            Console.WriteLine("\nNamn: " + name);
            Console.WriteLine("Ålder: " + age);
            Console.WriteLine("Levande: " + alive);

            try
            {
                int age2 = int.Parse(age);
                Console.WriteLine("Ålder i kvadrat: " + Math.Pow(age2, 2));
            }
            catch
            {
                Console.WriteLine("Dålig ålder!");
            }

            Console.ReadKey();
        }
    }
}
