using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionTest.Classes;
using Unity;
using Unity.Lifetime;

namespace DependencyInjectionTest
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
                Console.WriteLine("Press 1 to Run DI Unity Test For Registered Instances");
                Console.WriteLine("Press 2 to Run DI Unity Test For Life Time Manager");
                Console.WriteLine("Press 3 to Run DI Unity Test For Transient Manager");
                Console.WriteLine("Press Esc to Exit");

                while (true)
                {
                    var input = Console.ReadKey();
                    CleanUpConsole();

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            UnityTests.RunRegisteredInstancesTest();
                            break;
                        case ConsoleKey.D2:
                            UnityTests.RunContainerControlledLifetimeManagerTest();
                            break;
                        case ConsoleKey.D3:
                            UnityTests.RunContainerControlledTransientManagerTest();

                            break;
                        case ConsoleKey.D4:
                            RunUnityTest4();
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }

                    ShowReturnToMainMenuPrompt();
                    break;
                }
            }
        }

        private static void RunUnityTest4()
        {

        }


        private static void ShowReturnToMainMenuPrompt()
        {
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
        }

        static void CleanUpConsole()
        {
            Console.Clear();
            Console.WriteLine();
        }
    }
}
