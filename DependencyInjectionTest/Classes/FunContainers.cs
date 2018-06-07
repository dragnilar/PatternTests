using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionTest.Classes.FunClasses;
using Unity;
using Unity.Injection;

namespace DependencyInjectionTest.Classes
{
    public class FunContainers
    {
        public static void RegisterFunStuffForRegisterTest(IUnityContainer container)
        {
            var aToilet = new Toilet();
            aToilet.ToiletLocation = "Hiding where you least suspect it...";
            container.RegisterInstance(aToilet);

            container.RegisterType<IElephant, Elephant>();
            container.RegisterType<IClown, Clown>();

            var anElephant = typeof(IElephant);

            var aClown = typeof(IClown);

            container.RegisterType<ICircus, Circus>(new InjectionConstructor(aClown, anElephant, typeof(string)));
        }

        public static void RegisterFunStuffForNamedRegisterTest(IUnityContainer container)
        {
            container.RegisterType<IBear, DancingBear>("Dance");
            container.RegisterType<IBear, SingingBear>("Sing");
        }
    }
}
