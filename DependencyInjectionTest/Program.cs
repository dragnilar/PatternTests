using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionTest.Classes;
using DependencyInjectionTest.Classes.FunClasses;
using Unity;
using Unity.Lifetime;
using Unity.Resolution;

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
            var tests = GetTestsContainer();

            while (true)
            {
                ShowMenuOptions();

                ProcessMenuOptions(tests);
            }
        }

        private static void ShowMenuOptions()
        {
            Console.WriteLine("Press 1 to Run DI Unity Test For Registered Instances");
            Console.WriteLine("Press 2 to Run DI Unity Test For Life Time Manager");
            Console.WriteLine("Press 3 to Run DI Unity Test For Transient Manager");
            Console.WriteLine("Press 4 to Run DI Unity Test For Registered Instances With A Container");
            Console.WriteLine("Press 5 to Run DI Unity Test For Named Registered Instances With A Container");
            Console.WriteLine("Press Esc to Exit");
        }

        private static void ProcessMenuOptions(IUnityTests tests)
        {
            while (true)
            {
                var input = Console.ReadKey();
                CleanUpConsole();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        tests.RunRegisteredInstancesTest();
                        break;
                    case ConsoleKey.D2:
                        tests.RunContainerControlledLifetimeManagerTest();
                        break;
                    case ConsoleKey.D3:
                        tests.RunContainerControlledTransientManagerTest();
                        break;
                    case ConsoleKey.D4:
                        tests.RunRegisteredInstancesWithContainerTest();
                        break;
                    case ConsoleKey.D5:
                        tests.RunRegisteredInstancesWithNamedRegistrationTest();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }

                ShowReturnToMainMenuPrompt();
                break;
            }
        }

        private static IUnityTests GetTestsContainer()
        {
            var testContainer = new UnityContainer();
            testContainer.RegisterType<IUnityTests, UnityTests>();
            var tests = testContainer.Resolve<IUnityTests>();
            return tests;
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
