using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorTest.Classes.BasicIterator2Classes
{
    public class Iterator : IAbstractIterator
    {
        private Collection ExampleItemsCollection;
        private int CurrentIndex;
        private int CurrentStep = 1;

        public Iterator(Collection collection)
        {
            ExampleItemsCollection = collection;
        }

        public ExampleItem First()
        {
            CurrentIndex = 0;
            return ExampleItemsCollection[CurrentIndex] as ExampleItem;
        }

        public ExampleItem Next()
        {
            CurrentIndex += CurrentStep;
            return !IsDone ? ExampleItemsCollection[CurrentIndex] as ExampleItem : null;
        }

        public int Step
        {
            get => CurrentStep;
            set => CurrentStep = value;
        }

        public ExampleItem CurrentItem => ExampleItemsCollection[CurrentIndex] as ExampleItem;

        public bool IsDone => CurrentIndex >= ExampleItemsCollection.Count;
    }
}
