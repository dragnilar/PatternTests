using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionTest.Classes.FunClasses
{
    public interface ICircus
    {
        IClown Clown { get; set; }
        IElephant Elephant { get; set; }
        string Location { get; set; }
        string GetLocation();
        void MakeElephantDoSomethingWithClown();
    }

    class Circus : ICircus
    {
        public IClown Clown { get; set; }
        public IElephant Elephant { get; set; }
        public string Location { get; set; }

        public Circus(IClown clown, IElephant elephant, string location)
        {
            Clown = clown;
            Elephant = elephant;
            Location = location;
        }

        public string GetLocation()
        {
            return $"This circus is located at: {Location}, too bad it is imaginary. :( ";
        }

        public void MakeElephantDoSomethingWithClown()
        {
            Console.WriteLine($"{Elephant.ElephantName} trumpets at {Clown.ClownName} while {Clown.ClownName} makes noises with his nose.");
        }
    }
}
