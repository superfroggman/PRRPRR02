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

            if (name == "Niklas")
            {
                Console.WriteLine("Coolt namn");
            }else if(name == "Anton")
            {
                Console.WriteLine("Bästa namnet");
            }
            else
            {
                Console.WriteLine("Inte så fint namn");
            }


            Console.WriteLine("Ålder?");
            var age = int.Parse(Console.ReadLine());

            for(int i = 1; age + i <= 50; i++)
            {
                Console.WriteLine("Om " + i + " år är du " + (age + i));
            }

            var alive = "";

            while (true)
            {
                Console.WriteLine("Levande? (ja/nej)");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "ja":
                        Console.WriteLine("Tur för dig");
                        break;
                    case "nej":
                        Console.WriteLine("segt, men jag tror dig inte");
                        continue;
                    default:
                        Console.WriteLine("Jag gillar inte din attityd");
                        continue;
                }
                alive = input;
                break;
            }


            Console.WriteLine("\nNamn: " + name);
            Console.WriteLine("Ålder: " + age);
            Console.WriteLine("Levande: " + alive);

            /*gammal skit
            try
            {
                int age2 = int.Parse(age);
                Console.WriteLine("Ålder i kvadrat: " + Math.Pow(age2, 2));
            }
            catch
            {
                Console.WriteLine("Dålig ålder!");
            }
            */

            Console.ReadKey();
        }
    }
}
