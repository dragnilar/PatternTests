using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    class NPC : Character
    {
        public override string Name => "I Am A Non Playable Character";
        public override int HP => 50;
        public override int MP => 0;
    }
}
