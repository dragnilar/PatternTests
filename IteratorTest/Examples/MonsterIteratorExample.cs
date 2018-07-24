using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IteratorTest.Classes.MonsterIteratorClasses;

namespace IteratorTest.Examples
{
    public class MonsterIteratorExample
    {
        public void RunExample()
        {
            Console.Clear();

            Console.WriteLine("Creating monster aggregate with 10 monsters...");

            var aggregate = new MonsterAggregate
            {
                [0] = new Monster("Pumpkin", 1000, 100, "Gourd"),
                [1] = new Monster("Walking Toadstool", 10000, 1000, "Fungus"),
                [2] = new Monster("Coke Can", 500, 25, "Can"),
                [3] = new Monster("Rainbow Jelly", 250000, 25000, "Slime"),
                [4] = new Monster("Crazy Robot", 16500, 10000, "Machine"),
                [5] = new Monster("Meandering Zombie", 650, 0, "Undead"),
                [6] = new Monster("Skeleton Warrior", 10000, 1000, "Undead"),
                [7] = new Monster("New Age Retro Biker", 500, 50, "Undead"),
                [8] = new Monster("Plutonian Horror", 100000, 100000, "Alien")
            };

            var iterator = aggregate.CreateIterator();

            Console.WriteLine("Iterating over monsters...\n");


            var monster = iterator.First();

            while (monster != null)
            {
                Console.WriteLine($"A {monster.MonsterType} {monster.MonsterName} Appeared!\n" +
                                  $"Its Stats are as follows:\n" +
                                  $"HP : {monster.MonsterHp}\n" +
                                  $"MP : {monster.MonsterMp}\n");
                monster = iterator.Next();
            }

            Console.WriteLine("\nDone with monster iterator example. ");
            Console.WriteLine("Press any key to return to the main menu. ");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
