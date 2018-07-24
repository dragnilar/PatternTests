using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorTest.Classes.BasicIterator2Classes
{
    interface IAbstractCollection
    {
        Iterator CreateIterator();
    }
}
