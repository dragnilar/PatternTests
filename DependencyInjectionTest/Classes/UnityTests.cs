using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionTest.Classes.BoringClasses;
using DependencyInjectionTest.Classes.FunClasses;
using Unity;
using Unity.Lifetime;
using Unity.Resolution;

namespace DependencyInjectionTest.Classes
{
    public interface IUnityTests
    {
        void RunRegisteredInstancesTest();
        void RunContainerControlledLifetimeManagerTest();
        void RunContainerControlledTransientManagerTest();
        void RunRegisteredInstancesWithContainerTest();
        void RunRegisteredInstancesWithNamedRegistrationTest();
    }
    public class UnityTests : IUnityTests
    {
        public  void RunRegisteredInstancesTest()
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

        public  void RunContainerControlledLifetimeManagerTest()
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

        public  void RunContainerControlledTransientManagerTest()
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

        public  void RunRegisteredInstancesWithContainerTest()
        {
            Console.WriteLine("Creating new unity container...");
            IUnityContainer container = new UnityContainer();

            Console.WriteLine("Registering fun stuff...");
            FunContainers.RegisterFunStuffForRegisterTest(container);

            Console.WriteLine("Resolving fun stuff...");
            IClown clown = container.Resolve<IClown>();
            clown.ClownName = "Bubbles";

            Console.WriteLine($"Clowns name is: {clown.ClownName}");

            IElephant elephant = container.Resolve<IElephant>();
            elephant.ElephantName = "Barbar";

            Console.WriteLine($"The elephants name is: {elephant.ElephantName}");

            IToilet toilet = container.Resolve<Toilet>();
            Console.WriteLine($"The toilet is hiding here: {toilet.ToiletLocation}");

            ICircus circus = container.Resolve<ICircus>(new ParameterOverride("clown", clown),
                new ParameterOverride("elephant", elephant),
                new ParameterOverride("location", "Some Place Imaginary"));

            Console.WriteLine("Executing circus methods...");
            Console.WriteLine(circus.GetLocation());
            circus.MakeElephantDoSomethingWithClown();

        }

        public void RunRegisteredInstancesWithNamedRegistrationTest()
        {
            Console.WriteLine("Creating new unity container...");
            IUnityContainer container = new UnityContainer();

            Console.WriteLine("Registering fun stuff...");
            FunContainers.RegisterFunStuffForNamedRegisterTest(container);

            IBear dancingBear = container.Resolve<IBear>("Dance");
            IBear singingBear = container.Resolve<IBear>("Sing");

            dancingBear.Perform();
            singingBear.Perform();
        }
    }
}
