using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionTest.Classes.FunClasses
{
    public interface IClown
    {
        string ClownName { get; set; }
        Enums.SuitColors SuitColor { get; set; }
    }

    class Clown : IClown
    {
        public string ClownName { get; set; }
        public Enums.SuitColors SuitColor { get; set; }

        public Clown()
        {
            ClownName = "Nameless Clown";
            SuitColor = Enums.SuitColors.White;
        }
    }
}
