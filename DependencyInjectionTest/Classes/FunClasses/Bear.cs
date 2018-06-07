using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionTest.Classes.FunClasses
{
    public interface IBear
    {
        string BearName { get; set; }
        string Clothes { get; set; }
        Enums.BearType Type { get; set; }
        void Perform();

    }
    class DancingBear : IBear
    {
        public string BearName { get; set; }
        public string Clothes { get; set; }
        public Enums.BearType Type { get; set; }

        public DancingBear()
        {
            BearName = "Cynthia";
            Clothes = "Pink Tutu";
            Type = Enums.BearType.Brown;
        }

        public void Perform()
        {
            Console.WriteLine($"{BearName} the {Type}, dressed in {Clothes}, dances the ballet!");
        }
    }

    class SingingBear : IBear
    {
        public string BearName { get; set; }
        public string Clothes { get; set; }
        public Enums.BearType Type { get; set; }

        public SingingBear()
        {
            BearName = "James";
            Clothes = "Tuxedo";
            Type = Enums.BearType.Grizz;
        }

        public void Perform()
        {
            Console.WriteLine($"{BearName} the {Type}, dressed in {Clothes}, sings an opera song!");
        }
    }
}
