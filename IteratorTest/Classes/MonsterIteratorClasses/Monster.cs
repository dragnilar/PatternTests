using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorTest.Classes.MonsterIteratorClasses
{
    public class Monster
    {
        public string MonsterName { get; set; }
        public decimal MonsterHp { get; set; }
        public decimal MonsterMp { get; set; }
        public string MonsterType { get; set; }

        public Monster(string name, decimal hp, decimal mp, string type)
        {
            MonsterName = name;
            MonsterHp = hp;
            MonsterMp = mp;
            MonsterType = type;
        }
    }
}
