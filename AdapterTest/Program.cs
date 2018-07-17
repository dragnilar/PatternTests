using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdapterTest.Classes;

namespace AdapterTest
{
    class Program
    {
        /// <summary>
        /// This is a test showing an example of the adapter pattern. If you wish to learn more about it, please review the following site
        /// or look around the web:
        /// https://refactoring.guru/design-patterns/adapter/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Starting adapter test...");
            Console.WriteLine();
            PerformAdapterTest();
            Console.WriteLine("Done with adapter test. Press any key to exit.");
            Console.ReadKey();
        }

        private static void PerformAdapterTest()
        {
            Console.WriteLine("Creating a horse and a spider...");

            var horse = new Horse(4, "Samantha");
            var spider = new Spider(8, "Charlie");

            Console.WriteLine($"The horses name is {horse.Name()} and the spider's name is {spider.Name()}.\n");

            Console.WriteLine("Verifying that we can turn the horse into a spider.\n");

            if (horse.CanTurnInto(spider))
            {
                Console.WriteLine($"{horse.Name()} can turn into a {spider.GetType().Name}!!!\n{spider.Name()} will have a new friend!\n");
            }

            Console.WriteLine("Creating two boxes, one with 2 flaps another with 4 flaps.\n");

            var box1 = new Box(2);
            var box2 = new Box(4);

            var boxAdapter1 = new BoxAdapter(box1);
            var boxAdapter2 = new BoxAdapter(box2);

            Console.WriteLine("Verifying if we can turn the horse into box 1...");

            if (!horse.CanTurnInto(boxAdapter1))
            {
                Console.WriteLine($"{horse.Name()} can't turn into a box 1. Sorry.\n");
            }

            Console.WriteLine("Verifying if we can turn the horse into box 2...");
            if (horse.CanTurnInto(boxAdapter2))
            {
                Console.WriteLine($"{horse.Name()} can turn into box 2!!!!\nShe will be so happy as a box!!!\n");
            }
        }
    }
}
