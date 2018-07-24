using System;
using IteratorTest.Classes.BasicIteratorClasses;

namespace IteratorTest.Examples
{
    public class BasicIteratorExample
    {

        public void RunExample()
        {
            Console.Clear();
            var aggregate = new Aggregate
            {
                [0] = "Item A",
                [1] = "Item B",
                [2] = "Item C",
                [3] = "Item D",
                [4] = "Item E",
                [5] = "Item F"
            };

            var iterator = aggregate.CreateIterator();

            Console.WriteLine("Iterating over a collection...");

            var item = iterator.First();

            while (item != null)
            {
                Console.WriteLine(item);
                item = iterator.Next();
            }


            Console.WriteLine("\nDone with basic iterator example");
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();
            

        }
    }
}
