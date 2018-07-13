using System;
using System.Linq;

namespace EvilFizzBizz
{
    public class FizzBizzMethods
    {

        public void ClassicFizzBizz()
        {
            for (var i = 1; i <= 100; i++)
                if (i % 3 == 0 && i % 5 == 0)
                {
                    PrintForFizzBizz(i, App.Config.FizzBizzString);
                }

                else
                {
                    if (i % 3 == 0) PrintForFizzBizz(i, App.Config.FizzString);

                    if (i % 5 == 0) PrintForFizzBizz(i, App.Config.BizzString);
                }
        }

        public void ClassicFizzBizz2()
        {
            for (var i = 1; i <= 100; i++)
                if (i % 15 == 0)
                {
                    PrintForFizzBizz(i, App.Config.FizzBizzString);
                }

                else
                {
                    if (i % 3 == 0) PrintForFizzBizz(i, App.Config.FizzString);

                    if (i % 5 == 0) PrintForFizzBizz(i, App.Config.BizzString);
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
                    PrintForFizzBizz(counter, App.Config.FizzBizzString);
                    fizzBizzNumber = 0;
                    fizzNumber = 0;
                    bizzNumber = 0;
                }
                else if (fizzNumber == 3)
                {
                    PrintForFizzBizz(counter, App.Config.FizzString);
                    fizzNumber = 0;
                }

                else if (bizzNumber == 5)
                {
                    PrintForFizzBizz(counter, App.Config.BizzString);
                    bizzNumber = 0;
                }
                else
                {
                    Console.WriteLine(counter);
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

        private void PrintForFizzBizz(int value, string word)
        {
            Console.WriteLine($"{value}, {word}");
        }
    }
}