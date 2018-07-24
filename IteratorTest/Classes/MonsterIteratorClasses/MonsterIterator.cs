using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorTest.Classes.MonsterIteratorClasses
{
    class MonsterIterator : AbstractMonsterIterator
    {
        public MonsterAggregate Aggregate;
        public int CurrentIndex;

        public MonsterIterator(MonsterAggregate aggregate)
        {
            Aggregate = aggregate;
        }

        public override Monster First()
        {
            return Aggregate[0];
        }

        public override Monster Next()
        {
            Monster returnMonster = null;

            if (CurrentIndex < Aggregate.MonsterCount - 1)
            {
                returnMonster = Aggregate[++CurrentIndex];

            }

            return returnMonster;

        }

        public override bool IsDone()
        {
            return CurrentIndex >= Aggregate.MonsterCount;
        }

        public override Monster CurrentItem()
        {
            return Aggregate[CurrentIndex];
        }
    }
}
