using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilFizzBizz
{
    public class UtilityMethods
    {
        public bool IsDivisibleBy15(int x)
        {
            return x % 15 == 0;
        }

        public bool IsDivisibleBy5(int x)
        {
            return x % 5 == 0;
        }

        public bool IsDivisibleBy3(int x)
        {
            return x % 3 == 0;
        }

        public bool IsDivisibleByDivisor(int dividend, int divisor)
        {
            return dividend % divisor == 0;
        }


        public void GenericPrint(int value, string word = null)
        {
            Console.WriteLine(string.IsNullOrWhiteSpace(word) ? $"{value}" : $"{value}, {word}");
        }

        public void PrintForFizzBizz(int value)
        {
            Console.WriteLine($"{value}, {App.Config.FizzBizzString}");
        }

        public void PrintForFizz(int value)
        {
            Console.WriteLine($"{value}, {App.Config.FizzString}");
        }

        public void PrintForBizz(int value)
        {
            Console.WriteLine($"{value}, {App.Config.BizzString}");
        }

        public void PrintForPozz(int value)
        {
            Console.WriteLine($"{value}, {App.Config.PozzString}");
        }
    }

}
