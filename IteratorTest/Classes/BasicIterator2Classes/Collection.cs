using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorTest.Classes.BasicIterator2Classes
{
    public class Collection : IAbstractCollection
    {
        private List<object> ExampleItems = new List<object>();

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        public int Count => ExampleItems.Count;

        public object this[int index]
        {
            get => ExampleItems[index];
            set => ExampleItems.Add(value);
        }
    }
}
