using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTest.Classes
{
    public class Box
    {
        private double flaps;

        public Box(double flaps)
        {
            this.flaps = flaps;
        }

        public double GetFlaps()
        {
            return flaps;
        }

        public double GetSize()
        {
            return Math.Pow(flaps, 2);
        }
    }
}
