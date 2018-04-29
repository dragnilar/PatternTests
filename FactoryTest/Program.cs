using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {


            while (true)
            {
                Console.WriteLine("Press 1 to Run Test");
                Console.WriteLine("Press Esc to Exit");

                while (true)
                {
                    var input = Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            RunFactoryTest();
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }

                    break;
                }
            }
        }

        private static void RunFactoryTest()
        {
            Console.WriteLine("Creating a new character factory...\n");
            var factory = new CharacterFactory();

            Console.WriteLine("Outputting the factory...\n");
            for (int i = 0; i < 3; i++)
            {
                var character = factory.GetCharacter(i);
                Console.WriteLine($"This character says: {character.Name}, \n  Their HP is: {character.HP}, \n Their MP is: {character.MP} ");
            }

            Console.WriteLine("\n\n Test finished, press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
