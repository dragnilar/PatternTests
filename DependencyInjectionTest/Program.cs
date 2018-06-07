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
                            RunRegisteredInstancesTest();
                            break;
                        case ConsoleKey.D2:
                            RunContainerControlledLifetimeManagerTest();
                            break;
                        case ConsoleKey.D3:
                            RunContainerControlledTransientManagerTest();
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }

                    break;
                }
            }
        }



        private static void RunRegisteredInstancesTest()
        {
            Console.WriteLine("This is a test using a Container with registered instances for both Class One and Class Two.");
            var ioc = new UnityContainer();


            var classOne = new ClassOne {SomeString = "Im Some Class!"};

            var classTwo = new ClassTwo {SomeInt = 200};

            ioc.RegisterInstance(classOne);
            ioc.RegisterInstance(classTwo);
            ioc.RegisterType<IClassOne, ClassOne>();
            ioc.RegisterType<IClassTwo, ClassTwo>();


            var classThree = ioc.Resolve<ClassThree>();

            Console.WriteLine("Calling class three the first time...");
            classThree.ShowClasses();
            Console.WriteLine("Calling class three the second time...");
            classThree.ShowClasses();


            ShowReturnToMainMenuPrompt();

            ioc.Dispose();
        }



        private static void RunContainerControlledLifetimeManagerTest()
        {
            Console.WriteLine("This is a test using a Container Controlled LifeTime Manager for both Class One and Class Two.");
            var ioc = new UnityContainer();

            ioc.RegisterType<IClassOne, ClassOne>(new ContainerControlledLifetimeManager());
            ioc.RegisterType<IClassTwo, ClassTwo>(new ContainerControlledLifetimeManager());

            var classThreeInstance1 = ioc.Resolve<ClassThree>();

            classThreeInstance1.ClassOneInstance.SomeString = "I Am Class A In A Container Controlled LifeTime Manager.";
            classThreeInstance1.ClassTwoInstance.SomeInt = 9990999;

            Console.WriteLine("Calling class one for the first time.");
            classThreeInstance1.ShowClasses();

            var classThreeInstance2 = ioc.Resolve<ClassThree>();

            Console.WriteLine("Calling class three a second time");
            classThreeInstance2.ShowClasses();

            ShowReturnToMainMenuPrompt();

            ioc.Dispose();

        }

        private static void RunContainerControlledTransientManagerTest()
        {
            Console.WriteLine("This is a test using a Container Controlled Transient Manager for both Class One and Class Two.");
            var ioc = new UnityContainer();

            ioc.RegisterType<IClassOne, ClassOne>(new ContainerControlledTransientManager());
            ioc.RegisterType<IClassTwo, ClassTwo>(new ContainerControlledTransientManager());

            var classThreeInstance1 = ioc.Resolve<ClassThree>();

            classThreeInstance1.ClassOneInstance.SomeString = "I Am Class A In A Container Controlled Transient Manager.";
            classThreeInstance1.ClassTwoInstance.SomeInt = 9990999;

            Console.WriteLine("Calling class one for the first time.");
            classThreeInstance1.ShowClasses();

            var classThreeInstance2 = ioc.Resolve<ClassThree>();

            Console.WriteLine("Calling class three a second time");
            classThreeInstance2.ShowClasses();

            ShowReturnToMainMenuPrompt();

            ioc.Dispose();
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
