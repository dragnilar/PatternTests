using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorTest.Classes.BasicIterator2Classes
{
    interface IAbstractIterator
    {
        ExampleItem First();
        ExampleItem Next();
        bool IsDone { get; }
        ExampleItem CurrentItem { get; }
    }
}
