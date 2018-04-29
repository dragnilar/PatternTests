using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    abstract class Character
    {
        public abstract string Name { get; }
        public abstract int HP { get;  }
        public abstract int MP { get; }

    }
}
