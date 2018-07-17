using System;

using System.Collections.Generic;
using VisitorTest.Classes;


namespace VisitorTest

{

    /// <summary>

    /// MainApp startup class for Structural 

    /// Visitor Design Pattern.

    /// </summary>

    class MainApp

    {

        static void Main()

        {
            Console.WriteLine("Starting RPG Visitor Example Using An Abstract Class...");
            var visitorExample1 = new RPGVisitorUsingAbstractClass();
            visitorExample1.PerformNpcAndMonsterVisit();
            Console.WriteLine("End of example using an abstract class");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }


    }




}