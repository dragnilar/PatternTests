using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorTest.Classes
{
    class RPGVisitorExampleUsingInterface
    {
        /// <summary>
        /// Demonstrates using the visitor pattern on classes that uses interfaces
        /// </summary>
        public void PerformVisitOnCharacters()
        {
            var collection = new CharacterCollection();

            var characterVisitor = new CharacterVisitor();

            characterVisitor.Visit(collection);

        }

        /// <summary>
        /// A class representing a collection of characters. It accepts a visitor which in turn accepts the characters in the class
        /// and allows them to perform their behaviors.
        /// </summary>
        public class CharacterCollection
        {
            public List<ICharacter> Characters = new List<ICharacter>();

            public CharacterCollection()
            {
                Characters.Add(new Monster
                {
                    Hp = 1000,
                    Mp = 100,
                    Name = "Blue Adamantoise",
                    Type = "Turtle"
                });

                Characters.Add(new Npc
                {
                    Hp = 10,
                    Mp = 1,
                    Name = "Wandering Person A",
                    Type = "Townsperson"
                });

                Characters.Add(new Boss
                {
                    Hp = 100000,
                    Mp = 100000,
                    Name = "Dark Knight Enzemus",
                    Type = "Dark Knight"
                });
            }


            public void Accept(CharacterVisitor visitor)
            {
                foreach (var character in Characters)
                {
                    Console.WriteLine(character.GetType().Name);
                }
            }




        }


        #region Character Classes

        /// <summary>
        /// Interface of default functionality that all characters must implement
        /// </summary>
        public interface ICharacter
        {
            void PerformDefaultAction();
            void Accept(CharacterVisitor characterVisitor);
            void Leave();
        }

        /// <summary>
        /// A class that represents a monster character in an RPG game
        /// </summary>
        public class Monster : ICharacter
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public decimal Hp { get; set; }
            public decimal Mp { get; set; }

            public void PerformDefaultAction()
            {
                Console.WriteLine($"{Name} attacked you as soon as it saw you!");
            }

            public void Accept(CharacterVisitor characterVisitor)
            {
                characterVisitor.VisitMonster(this);
            }

            public void Leave()
            {
                Console.WriteLine($"{Name} ran away...");
            }
        }

        /// <summary>
        /// A class that represents a non-playable character in an RPG game
        /// </summary>
        public class Npc : ICharacter
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public decimal Hp { get; set; }
            public decimal Mp { get; set; }

            public void PerformDefaultAction()
            {
                Console.WriteLine($"{Name} started talking aimlessly...");
            }

            public void Accept(CharacterVisitor characterVisitor)
            {
                characterVisitor.VisitNPC(this);
            }

            public void Leave()
            {
                Console.WriteLine($"{Name} went inside their house.");
            }
        }

        /// <summary>
        /// A class that represents a boss character in an RPG game
        /// </summary>
        public class Boss : ICharacter
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public decimal Hp { get; set; }
            public decimal Mp { get; set; }

            public void PerformDefaultAction()
            {
                Console.WriteLine($"{Name} intimidated you with their overwhelming presence and knocked you out in one hit!");
            }

            public void Accept(CharacterVisitor characterVisitor)
            {
               characterVisitor.VisitBoss(this);
            }

            public void Leave()
            {
                Console.WriteLine($"{Name} disappeared in the blink of an eye!");
            }
        }

        #endregion

        #region Visitor Class

        /// <summary>
        /// An interface of default functionality that all visitor classes must implement.
        /// </summary>
        interface IVisitor
        {
            void VisitMonster(Monster monster);
            void VisitNPC(Npc npc);
            void VisitBoss(Boss boss);
        }

        /// <summary>
        /// A visitor that works off of characters from an RPG game
        /// </summary>
        public class CharacterVisitor : IVisitor
        {
             
            public void VisitMonster(Monster monster)
            {
                Console.WriteLine("We are visiting a monster...");
                monster.PerformDefaultAction();
                Console.WriteLine($"The monsters stats are:\nName: {monster.Name}\n" +
                                  $"Type: {monster.Type}\n" +
                                  $"HP: {monster.Hp}\n" +
                                  $"MP: {monster.Mp}");
                monster.Leave();

            }

            public void VisitNPC(Npc npc)
            {
                Console.WriteLine("We are visiting an NPC...");
                npc.PerformDefaultAction();
                Console.WriteLine($"The NPC's stats are:\nName: {npc.Name}\n" +
                                  $"Type: {npc.Type}\n" +
                                  $"HP: {npc.Hp}\n" +
                                  $"MP: {npc.Mp}");
                npc.Leave();
            }

            public void VisitBoss(Boss boss)
            {
                Console.WriteLine("We are visiting a Boss...");
                boss.PerformDefaultAction();
                Console.WriteLine($"The boss' stats are:\nName: {boss.Name}\n" +
                                  $"Type: {boss.Type}\n" +
                                  $"HP: {boss.Hp}\n" +
                                  $"MP: {boss.Mp}");
                boss.Leave();
                
            }

            public void Visit(CharacterCollection collection)
            {
                foreach (var character in collection.Characters)
                {
                    character.Accept(this);
                    Console.WriteLine();
                }
            }
        }

        #endregion




    }
}
