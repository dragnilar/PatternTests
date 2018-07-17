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
            Console.WriteLine("Starting RPG Visitor Example 1...");
            var visitorExample1 = new RPGVisitorExample1();
            visitorExample1.PerformNpcAndMonsterVisit();
            Console.WriteLine("End RPG visitor example 1");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }


    }




}