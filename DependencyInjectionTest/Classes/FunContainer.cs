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
    public class FunContainer
    {
        public static void RegisterFunStuff(IUnityContainer container)
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
    }
}
