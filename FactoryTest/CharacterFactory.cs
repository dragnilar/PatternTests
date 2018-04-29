using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    class CharacterFactory
    {

        public Character GetCharacter(int id)
        {
            switch (id)
            {
                case 0:
                    return new Monster();
                case 1:
                    return new NPC();
                case 2:
                    return new Player();
                default:
                    return null;

            }
        }
    }
}
