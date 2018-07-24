using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IteratorTest.Examples;

namespace IteratorTest
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
                Console.WriteLine("Press 1 to run a basic iterator example.");
                Console.WriteLine("Press 2 to run another basic iterator example with steps.");
                Console.WriteLine("Press 3 to run basic iterator example with MONSTERS.");
                Console.WriteLine("Press Esc to exit.");

                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        new BasicIteratorExample().RunExample();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        new BasicIterator2Example().RunExample();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        new MonsterIteratorExample().RunExample();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        break;

                }
            }
        }
    }
}
