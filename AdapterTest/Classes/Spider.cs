using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTest.Classes
{
    public class Spider
    {
        private int Legs;
        private string _name;

        public Spider(int legs, string name)
        {
            Legs = legs;
            _name = name;
        }

        public virtual int GetLegs()
        {
            return Legs;
        }

        public string Name()
        {
            return _name;
        }
    }
}
