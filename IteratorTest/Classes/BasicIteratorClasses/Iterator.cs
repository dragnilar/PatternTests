using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorTest.Classes.BasicIteratorClasses
{
    class Iterator : AbstractIterator
    {
        private Aggregate _aggregate;
        private int CurrentIndex = 0;

        public Iterator(Aggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            object returnObject = null;

            if (CurrentIndex < _aggregate.Count - 1)
            {
                returnObject = _aggregate[++CurrentIndex];

            }

            return returnObject;
        }

        public override bool IsDone()
        {
            return CurrentIndex >= _aggregate.Count;
        }

        public override object CurrentItem()
        {
            return _aggregate[CurrentIndex];
        }
    }
}
