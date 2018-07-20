using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyTest.Classes
{
    public class MonsterStrategy
    {
        public void RunExample()
        {
            Console.Clear();
            Console.WriteLine("Starting monster strategy example.\nNOTE: For this we will create a list of the same monsters for each type of battle.\n");
            StrategyDemo();

            Console.WriteLine("End monster strategy example.");
            Console.ReadKey();
            Console.Clear();
        }

        private void StrategyDemo()
        {
            var monsterList = GetMonsters();

            var hardBattle = new Battle(monsterList, new AggressiveStrategy());
            var easyBattle = new Battle(monsterList, new CowardlyStrategy());
            var normalBattle = new Battle(monsterList, new ConservativeStrategy());

            Console.WriteLine("Starting a hard battle where the monsters use an aggressive strategy.");
            hardBattle.RunMonsterAi();
            Console.WriteLine("Starting a normal battle where the monsters use a cautious strategy.");
            normalBattle.RunMonsterAi();
            Console.WriteLine("Starting an easy battle where the monsters use a cowardly.");
            easyBattle.RunMonsterAi();
        }

        private abstract class MonsterFightStrategy
        {
            public abstract void FightRoutine(List<Monster> monsterList);
        }

        private class AggressiveStrategy : MonsterFightStrategy
        {
            public override void FightRoutine(List<Monster> monsterList)
            {
                foreach (var monster in monsterList)
                {
                    Console.WriteLine($"{monster.MonsterName} fights with all they got!");
                    
                }
            }
        }

        private class CowardlyStrategy : MonsterFightStrategy
        {
            public override void FightRoutine(List<Monster> monsterList)
            {
                foreach (var monster in monsterList)
                {
                    Console.WriteLine($"{monster.MonsterName} runs away!");
                }
            }
        }

        private class ConservativeStrategy : MonsterFightStrategy
        {
            public override void FightRoutine(List<Monster> monsterList)
            {
                foreach (var monster in monsterList)
                {
                    Console.WriteLine($"{monster.MonsterName} fights cautiously.");
                }
            }
        }

        private class Battle
        {
            private List<Monster> MonsterParty;
            private bool IsOver = false;
            private MonsterFightStrategy Strategy;

            public Battle(List<Monster> monsterParty, MonsterFightStrategy strategy)
            {
                MonsterParty = monsterParty;
                Strategy = strategy;
            }

            public void RunMonsterAi()
            {
                Console.WriteLine("The following monsters appeared:\n");
                foreach (var monster in MonsterParty)
                {
                    Console.WriteLine($"{monster.MonsterName}:\nHP: {monster.MonsterHp}\nMP: {monster.MonsterMp}\nType: {monster.MonsterType}\n");
                }
                Console.WriteLine("The monsters are getting ready to do something...\n");
                Strategy.FightRoutine(MonsterParty);
                Console.WriteLine();
            }
        }


        private class Monster
        {
            public string MonsterName { get; set; }
            public decimal MonsterHp { get; set; }
            public decimal MonsterMp { get; set; }
            public string MonsterType { get; set; }
            
        }

        private List<Monster> GetMonsters()
        {
            var monsterList = new List<Monster>
            {
                new Monster {MonsterName = "Imp", MonsterHp = 100, MonsterMp = 10, MonsterType = "Goblinoid"},
                new Monster {MonsterName = "Big Pumpkin", MonsterHp = 250, MonsterMp = 10, MonsterType = "Gourd"},
                new Monster {MonsterName = "Dancing Spider", MonsterHp = 300, MonsterMp = 50, MonsterType = "Arachnid"},
                new Monster
                {
                    MonsterName = "Plastic Bucket",
                    MonsterHp = 50,
                    MonsterMp = 50,
                    MonsterType = "Inanimate Object"
                },
                new Monster
                {
                    MonsterName = "Intrigued Robot",
                    MonsterHp = 1000,
                    MonsterMp = 100,
                    MonsterType = "Machine"
                }
            };


            return monsterList;
        }

    }
}
