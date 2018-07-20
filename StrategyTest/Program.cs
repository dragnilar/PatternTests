using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyTest.Classes;

namespace StrategyTest
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
                Console.WriteLine("Press 1 to Run Basic Strategy Test");
                Console.WriteLine("Press 2 to Monster Strategy Test");
                Console.WriteLine("Press Esc to Exit");

                while (true)
                {
                    var input = Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            new BasicStrategyExample().ShowExample();
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            new MonsterStrategy().RunExample();
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            break;
                    }

                    break;
                }
            }
        }
    }
}
