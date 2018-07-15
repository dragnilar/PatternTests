using System;
using System.Collections.Generic;
using System.Linq;

namespace EvilFizzBizz
{
    public class RegularFizzBizz
    {

        public void ClassicFizzBizz()
        {
            for (var i = 1; i <= 100; i++)
                if (i % 3 == 0 && i % 5 == 0)
                {
                    App.Util.GenericPrint(i, App.Config.FizzBizzString);
                }

                else
                {
                    if (i % 3 == 0) App.Util.GenericPrint(i, App.Config.FizzString);

                    else if (i % 5 == 0) App.Util.GenericPrint(i, App.Config.BizzString);

                    else App.Util.GenericPrint(i);
                    
                }
        }

        public void ClassicFizzBizz2()
        {
            for (var i = 1; i <= 100; i++)
                if (i % 15 == 0)
                {
                    App.Util.GenericPrint(i, App.Config.FizzBizzString);
                }

                else
                {
                    if (i % 3 == 0) App.Util.GenericPrint(i, App.Config.FizzString);

                    else if (i % 5 == 0) App.Util.GenericPrint(i, App.Config.BizzString);

                    else App.Util.GenericPrint(i);
                }
        }

        public void FizzBizzWithForEach()
        {
            var integerList = new List<int>();
            integerList.AddRange(Enumerable.Range(1, 100));


            foreach (var integer in integerList)
            {
                if (integer % 15 == 0)
                {
                    App.Util.GenericPrint(integer, App.Config.FizzBizzString);
                }

                else if (integer % 5 == 0)
                {
                    App.Util.GenericPrint(integer, App.Config.BizzString);
                }

                else if (integer % 3 == 0)
                {
                    App.Util.GenericPrint(integer, App.Config.FizzString);
                }

                else
                {
                    App.Util.GenericPrint(integer);
                }
            }
        }

        public void LinqFizzBizz()
        {
            Enumerable.Range(1, 100).Select(
                x =>
                    x % 15 == 0 ? $"{x}, {App.Config.FizzBizzString}" :
                    x % 3 == 0 ? $"{x}, {App.Config.FizzString}" :
                    x % 5 == 0 ? $"{x}, {App.Config.BizzString}" :
                    x.ToString()).ToList().ToList().ForEach(Console.WriteLine);
        }

        public void LinqFizzBizz2()
        {
            Enumerable.Range(1, 100).ToList().ForEach(x =>
                Console.WriteLine(x % 15 == 0
                    ? App.Config.FizzBizzString
                    : (x % 3 == 0 ? App.Config.FizzString : (x % 5 == 0 ? App.Config.BizzString : x.ToString()))));
        }

        public void FizzBizzWithNoModulus()
        {
            var fizzBizzNumber = 1;
            var fizzNumber = 1;
            var bizzNumber = 1;
            var counter = 1;
            while (true)
            {
                if (fizzBizzNumber == 15)
                {
                    App.Util.GenericPrint(counter, App.Config.FizzBizzString);
                    fizzBizzNumber = 0;
                    fizzNumber = 0;
                    bizzNumber = 0;
                }
                else if (fizzNumber == 3)
                {
                    App.Util.GenericPrint(counter, App.Config.FizzString);
                    fizzNumber = 0;
                }

                else if (bizzNumber == 5)
                {
                    App.Util.GenericPrint(counter, App.Config.BizzString);
                    bizzNumber = 0;
                }
                else
                {
                   App.Util.GenericPrint(counter);
                }

                if (counter < 100)
                {
                    fizzBizzNumber = ++fizzBizzNumber;
                    fizzNumber = ++fizzNumber;
                    bizzNumber = ++bizzNumber;
                    counter = ++counter;
                    continue;
                }

                break;
            }
        }
    }
}