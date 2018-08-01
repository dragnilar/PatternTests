using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    class Program
    {
        static void Main(string[] args)
        {

            ShowMainMenu();
        }

        private static void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("Press 1 to run a vanilla observer example.");
                Console.WriteLine("Press 2 to run a bogus game system observer example.");
                Console.WriteLine("Press Esc to exit.");

                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        new VanillaObserverExample().RunExample();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        new BogusGameSystemExample().RunExample();
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
