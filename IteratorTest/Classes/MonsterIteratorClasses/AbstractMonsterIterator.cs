using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorTest.Classes.MonsterIteratorClasses
{
    public abstract class AbstractMonsterIterator
    {
        public abstract Monster First();
        public abstract Monster Next();
        public abstract bool IsDone();
        public abstract Monster CurrentItem();
    }
}
