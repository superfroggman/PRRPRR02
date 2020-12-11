using System;
using System.Collections.Generic;

using Laboration_2_Abstraktion.Animals;

namespace Laboration_2_Abstraktion
{
    class Program
    {
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            products.Add(new Dog());
            products.Add(new Snake());
            products.Add(new Spider());

            products.Add(new Hat());
            products.Add(new FakeDog());
            products.Add(new FakeFakeDog());

            while (true){
                Console.WriteLine("To exit: Destroy Fake Fake Dog");
                SelectProduct();
            }
            
        }

        static void SelectProduct()
        {
            Console.WriteLine("\nProducts:");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + products[i].name);
            }

            Console.WriteLine("\nSelect product by number");

            int inputInt = GetIntInput();

            if (products.Count < inputInt || inputInt < 1)
            {
                Console.WriteLine("Invalid product");
                return;
            }

            if(products[inputInt-1] is Animal animal){
                Console.WriteLine("Cuteness:" + animal.cuteness + "/10");
                Console.WriteLine("Energy:" + animal.energy + "/10");
                Console.WriteLine("\n1: Make " + animal.name + " eat\n2: 1: Make " + animal.name + " make noise\n0: Back");

                switch (GetIntInput())
                {
                    case 1:
                        animal.Eat();
                        break;
                    case 2:
                        animal.MakeNoise();
                        break;
                    default:
                        break;
                }
            }

            else if (products[inputInt - 1] is Accessory accessory)
            {
                Console.WriteLine("Cuteness:" + accessory.coolness + "/10");
                Console.WriteLine("\n1: Use " + accessory.name + "\n2: Destroy " + accessory.name + "\n0: Back");

                switch (GetIntInput())
                {
                    case 1:
                        accessory.Use();
                        break;
                    case 2:
                        accessory.Destroy();
                        break;
                    default:
                        break;
                }
            }
        }

        static int GetIntInput()
        {
            string inputString = Console.ReadLine();

            int inputInt = -1;

            int tryInput = 0;
            if (Int32.TryParse(inputString, out tryInput)) inputInt = tryInput;

            return inputInt;
        }
    }
}
