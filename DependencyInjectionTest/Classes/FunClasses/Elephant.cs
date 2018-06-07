using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionTest.Classes.FunClasses
{
    public interface IElephant
    {
        string ElephantName { get; set; }
        int Weight { get; set; }
        Enums.ElephantType Type { get; set; }
    }
    public class Elephant : IElephant
    {
        public string ElephantName { get; set; }
        public int Weight { get; set; }
        public Enums.ElephantType Type { get; set; }

        public Elephant()
        {
            ElephantName = "Horton";
            Weight = 2000;
            Type = Enums.ElephantType.African;
        }
    }
}
