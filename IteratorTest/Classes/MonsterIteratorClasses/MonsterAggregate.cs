using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorTest.Classes.MonsterIteratorClasses
{
    public class MonsterAggregate : AbstractMonsterAggregate
    {
        public List<Monster> MonsterList = new List<Monster>();

        
        public override AbstractMonsterIterator CreateIterator()
        {
            return new MonsterIterator(this);
        }

        public int MonsterCount => MonsterList.Count;


        public Monster this[int index]
        {
            get => MonsterList[index];
            set => MonsterList.Insert(index, value);
        }
    }
}
