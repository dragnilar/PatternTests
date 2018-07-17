using System;

using System.Collections.Generic;
using VisitorTest.Classes;


namespace VisitorTest

{

    /// <summary>
    /// This shows examples of using the visitor pattern. You can read more about the visitor pattern at
    /// the following link and of course other places around the web.
    /// https://refactoring.guru/design-patterns/visitor
    /// </summary>
    class MainApp

    {

        static void Main()

        {
            Console.WriteLine("Starting RPG Visitor Example Using An Abstract Class...");
            var visitorExample1 = new RPGVisitorUsingAbstractClass();
            visitorExample1.PerformNpcAndMonsterVisit();
            Console.WriteLine("End of example using an abstract class");
            Console.WriteLine("Press any key to view next example.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Starting RPG Visitor Example Using An Interface...");
            var visitorExample2 = new RPGVisitorExampleUsingInterface();
            visitorExample2.PerformVisitOnCharacters();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }


    }




}