using System;

namespace DependencyInjectionTest.Classes
{
    class ClassThree
    {
        private IClassOne _classOne;
        private IClassTwo _classTwo;

        public ClassThree(IClassOne classOne, IClassTwo classTwo)
        {
            _classOne = classOne;
            _classTwo = classTwo;
        }

        public IClassOne ClassOneInstance
        {
            get => _classOne;
        }

        public IClassTwo ClassTwoInstance
        {
            get => _classTwo;
        }

        public void ShowClasses()
        {
            Console.WriteLine($"Class C In Unity Container has the following string On Class One: {_classOne.SomeString}");
            Console.WriteLine($"Class C In Unity Container has the following int On Class Two: {_classTwo.SomeInt}");
        }
    }
}
