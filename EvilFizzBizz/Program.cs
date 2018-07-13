using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EvilFizzBizz
{
    partial class Program
    {
        static readonly RegularFizzBizz RegularFizzBizzCollection = new RegularFizzBizz();
        static void Main(string[] args)
        {
            MainMenu();
        }



        static void MainMenu()
        {


            while (true)
            {
                ShowMenuOptions();

                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        RegularFizzBizzCollection.ClassicFizzBizz();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        RegularFizzBizzCollection.ClassicFizzBizz2();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        RegularFizzBizzCollection.LinqFizzBizz();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        RegularFizzBizzCollection.LinqFizzBizz2();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        RegularFizzBizzCollection.FizzBizzWithNoModulus();
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        Console.Clear();
                        Console.WriteLine("Toggling obscenities...");
                        App.Config.ToggleObscenities();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Console.Clear();
                        new SolidFizzBizz().DoSolidFizzBizz();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You selected an invalid test... :/");
                        break;
                }

                ReturnToMainMenu();
                break;
            }

        }

        static void ShowMenuOptions()
        {
            Console.WriteLine("Select a Fizz Bizz Test To Run..");
            Console.WriteLine("1. Classic Fizz Bizz");
            Console.WriteLine("2. Classic Fizz Bizz 2");
            Console.WriteLine("3. Linq Fizz Bizz");
            Console.WriteLine("4. Linq Fizz Bizz 2");
            Console.WriteLine("5. Fizz Bizz With NO Modulus");
            Console.WriteLine("6. Non-Standard Fizz Bizz With Classes");
            Console.WriteLine("You can also press 7 to toggle obscenities and tell 'em what you really think about Fizz Bizz...");
            Console.WriteLine("Press Esc to Exit");
        }



        private static void ReturnToMainMenu()
        {
            Console.WriteLine("Press Any Key To Return To Main Menu");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }


    }
}
