using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTest.Classes
{
    public class BoxAdapter : Spider
    {
        private Box box;


        public BoxAdapter(Box box) : base(0, string.Empty)
        {
            this.box = box;
        }

        public override int GetLegs()
        {
            return Convert.ToInt32(box.GetFlaps());
        }
    }
}
