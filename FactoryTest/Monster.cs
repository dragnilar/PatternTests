using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    class Monster : Character
    {
        public override string Name => "I Am A Monster";
        public override int HP => 1000;
        public override int MP => 500;
    }
}
