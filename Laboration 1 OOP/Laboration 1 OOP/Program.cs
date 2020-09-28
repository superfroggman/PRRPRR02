using System;
using System.Collections.Generic;


namespace Laboration_1_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            _products.AddRange(new List<Product>
            {
                new Product("Monster", 20),
                new Product("Powerking", 10),
                new Product("Tiger King", 7),
             });

            CustomerMenu();
        }

        static List<Customer> _customers = new List<Customer>();
        static List<Product> _products = new List<Product>();


        static void CustomerMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1: Create customer\n2: Select customer\n0: Exit");

                int inputInt = getIntInput();

                switch (inputInt)
                {
                    case 1:
                        CreateCustomer();
                        break;
                    case 2:
                        SelectCustomer();
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            }
        }

        static void CreateCustomer()
        {
            Console.WriteLine("\nName?");

            string name = Console.ReadLine();
            _customers.Add(new Customer(name));
        }

        static void SelectCustomer()
        {
            Console.WriteLine("\nCustomers:");

            for (int i = 0; i < _customers.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + _customers[i]._name);
            }

            Console.WriteLine("\nSelect customer by number");

            int inputInt = getIntInput();

            if (_customers.Count < inputInt || inputInt < 1)
            {
                Console.WriteLine("Invalid customer");
                return;
            }

            Customer customer = _customers[inputInt - 1];

            while (true)
            {
                Console.WriteLine("\n1: Select product\n2: View cart\n0: Back");

                inputInt = getIntInput();

                switch (inputInt)
                {
                    case 1:
                        SelectProduct(customer);
                        break;
                    case 2:
                        ViewCart(customer);
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            }
        }

        static void SelectProduct(Customer customer)
        {
            Console.WriteLine("\nProducts:");

            for (int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + _products[i]._name);
            }

            Console.WriteLine("\nSelect product by number");

            int inputInt = getIntInput();

            if (_products.Count < inputInt || inputInt < 1)
            {
                Console.WriteLine("Invalid product");
                return;
            }

            Product product = (Product)_products[inputInt - 1].Clone();

            Console.WriteLine("Amount?");


            int amount;
            while (true){
                amount = getIntInput();
                if (amount > 0) break;
                Console.WriteLine("Bad amount");
            }

            product._amount = amount;

            customer._products.Add(product);
        }


        static void ViewCart(Customer customer)
        {
            Console.WriteLine("\nProducts:");

            int cost = 0;

            for (int i = 0; i < customer._products.Count; i++)
            {
                Product product = customer._products[i];
                Console.WriteLine(product._amount + "st: " + product._name);

                cost += product._cost * product._amount;
            }

            Console.WriteLine("Total cost: " + cost + "kr");
        }

        //Default: -1
        static int getIntInput()
        {
            string inputString = Console.ReadLine();

            int inputInt = -1;

            int tryInput = 0;
            if (Int32.TryParse(inputString, out tryInput)) inputInt = tryInput;

            return inputInt;
        }
    }
}
