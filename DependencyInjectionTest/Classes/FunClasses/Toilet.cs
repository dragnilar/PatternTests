using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionTest.Classes.FunClasses
{
    public interface IToilet
    {
        string ToiletLocation { get; set; }
        int FlushPower { get; set; }
        Enums.ToiletType Type { get; set; }
    }
    class Toilet : IToilet
    {
        public string ToiletLocation { get; set; }
        public int FlushPower { get; set; }
        public Enums.ToiletType Type { get; set; }

        public Toilet()
        {
            ToiletLocation = "On the ceiling";
            FlushPower = 9001;
            Type = Enums.ToiletType.Amused;
        }

        
    }
}
