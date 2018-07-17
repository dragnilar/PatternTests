using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTest.Classes
{
    public class Horse
    {
        private int Legs;
        private string _name;

        public Horse(int legs, string name)
        {
            Legs = legs;
            _name = name;
        }

        public int GetLegs()
        {
            return Legs;
        }

        public string Name()
        {
            return _name;
        }

        public bool CanTurnInto(Spider spider)
        {
            return spider.GetLegs() >= Legs;
        }
    }
}
