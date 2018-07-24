using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorTest.Classes.BasicIteratorClasses
{
    public class Aggregate : AbstractAggregate
    {
        private List<object> Items = new List<object>();

        public override AbstractIterator CreateIterator()
        {
            return new Iterator(this);
        }

        public int Count => Items.Count;

        public object this[int index]
        {
            get => Items[index];
            set => Items.Insert(index, value);
        }
    }
}
