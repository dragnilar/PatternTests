using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IteratorTest.Classes.BasicIteratorClasses;

namespace IteratorTest.Classes.MonsterIteratorClasses
{
    public abstract class AbstractMonsterAggregate
    {
        public abstract AbstractMonsterIterator CreateIterator();
    }
}
