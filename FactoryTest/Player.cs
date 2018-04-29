using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    class Player : Character
    {
        public override string Name => "I Am A Player";
        public override int HP => 500;
        public override int MP => 250;
    }
}
