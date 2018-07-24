using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IteratorTest.Classes.BasicIterator2Classes;

namespace IteratorTest.Examples
{
    public class BasicIterator2Example
    {
        public void RunExample()
        {
            Console.Clear();

            Console.WriteLine("Creating a collection of 12 items...");
            var collection = new Collection
            {
                [0] = new ExampleItem("Item 0"),
                [1] = new ExampleItem("Item 1"),
                [2] = new ExampleItem("Item 2"),
                [3] = new ExampleItem("Item 3"),
                [4] = new ExampleItem("Item 4"),
                [5] = new ExampleItem("Item 5"),
                [6] = new ExampleItem("Item 6"),
                [7] = new ExampleItem("Item 7"),
                [8] = new ExampleItem("Item 8"),
                [9] = new ExampleItem("Item 9"),
                [10] = new ExampleItem("Item 10"),
                [11] = new ExampleItem("Item 11")
            };


            var iterator = collection.CreateIterator();

            iterator.Step = 2;

            Console.WriteLine("Iterating over the collection, skipping every 2 items.");

            for (var item = iterator.First(); !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Finished Basic Iterator Example 2\n");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
