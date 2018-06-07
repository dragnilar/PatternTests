using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionTest.Classes.BoringClasses;
using Unity;
using Unity.Lifetime;

namespace DependencyInjectionTest.Classes
{
    public class UnityTests
    {
        public static void RunRegisteredInstancesTest()
        {
            Console.WriteLine("This is a test using a Container with registered instances for both Class One and Class Two.");
            var ioc = new UnityContainer();


            var classOne = new ClassOne { SomeString = "Im Some Class!" };

            var classTwo = new ClassTwo { SomeInt = 200 };

            ioc.RegisterInstance(classOne);
            ioc.RegisterInstance(classTwo);
            ioc.RegisterType<IClassOne, ClassOne>();
            ioc.RegisterType<IClassTwo, ClassTwo>();


            var classThree = ioc.Resolve<ClassThree>();

            Console.WriteLine("Calling class three the first time...");
            classThree.ShowClasses();
            Console.WriteLine("Calling class three the second time...");
            classThree.ShowClasses();

            ioc.Dispose();
        }

        public static void RunContainerControlledLifetimeManagerTest()
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

            ioc.Dispose();

        }

        public static void RunContainerControlledTransientManagerTest()
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

            ioc.Dispose();
        }
    }
}
