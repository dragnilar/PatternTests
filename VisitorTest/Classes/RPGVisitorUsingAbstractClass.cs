using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorTest.Classes
{
    public class RPGVisitorUsingAbstractClass
    {
        /// <summary>
        /// Performs visitor operation on some RPG game classes (NPC and Monster)
        /// </summary>
        public void PerformNpcAndMonsterVisit()
        {
            // Setup structure

            CharacterObjectStructure characterObjectStructure = new CharacterObjectStructure();

            characterObjectStructure.Attach(new NPCCharacter());

            characterObjectStructure.Attach(new MonsterCharacter());


            // Create visitor objects

            CharacterVisitorForNameAndType nameAndTypeVisitor = new CharacterVisitorForNameAndType();

            CharacterVisitorForHpAndMp hpAndMpVisitor = new CharacterVisitorForHpAndMp();


            // Structure accepting visitors

            characterObjectStructure.Accept(nameAndTypeVisitor);

            characterObjectStructure.Accept(hpAndMpVisitor);


            characterObjectStructure.DetachAll();

        }

        /// <summary>
        /// An abstract class representing the "visitor"
        /// </summary>
        abstract class Visitor

        {

            public abstract void VisitNPCCharacter(

              NPCCharacter npcCharacter);

            public abstract void VisitMonsterCharacter(

              MonsterCharacter monsterCharacter);

        }



        /// <summary>
        /// A concrete class representing a visitor that displays the name and type of what is being visited.
        /// </summary>
        class CharacterVisitorForNameAndType : Visitor

        {

            public override void VisitNPCCharacter(

              NPCCharacter npcCharacter)

            {

                Console.WriteLine($"{npcCharacter.GetType().Name} visited by {this.GetType().Name}, " +
                                  $"their Name is {npcCharacter.Name} and Their Type is {npcCharacter.Type}");

            }



            public override void VisitMonsterCharacter(

              MonsterCharacter monsterCharacter)

            {

                Console.WriteLine($"{monsterCharacter.GetType().Name} visited by {this.GetType().Name}, " +
                                  $"their Name is {monsterCharacter.Name} and Their Type is {monsterCharacter.Type}");

            }

        }



        /// <summary>
        /// A concrete class representing a visitor that displays the Hp and Mp of what is being visited.
        /// </summary>
        class CharacterVisitorForHpAndMp : Visitor

        {

            public override void VisitNPCCharacter(

              NPCCharacter npcCharacter)

            {

                Console.WriteLine($"{npcCharacter.GetType().Name} visited by {this.GetType().Name}, " +
                                  $"their Hp is {npcCharacter.Hp} and Their Mp is {npcCharacter.Mp}");

            }



            public override void VisitMonsterCharacter(

              MonsterCharacter monsterCharacter)

            {
                Console.WriteLine($"{monsterCharacter.GetType().Name} visited by {this.GetType().Name}, " +
                                  $"their Hp is {monsterCharacter.Hp} and Their Mp is {monsterCharacter.Mp}");

            }

        }




        /// <summary>
        /// The character class, which is an abstract class that is used to represent a character.
        /// </summary>
        abstract class Character

        {
            private string _name;
            private string _type;
            private decimal _hp;
            private decimal _mp;

            /// <summary>
            /// Gets or sets the characters Name
            /// </summary>
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            /// <summary>
            /// Gets or sets the characters Type
            /// </summary>
            public string Type
            {
                get { return _type; }
                set { _type = value; }
            }

            /// <summary>
            /// Gets or sets the characters HP
            /// </summary>
            public decimal Hp
            {
                get { return _hp; }
                set { _hp = value; }
            }

            /// <summary>
            /// Gets or sets the characters MP
            /// </summary>
            public decimal Mp
            {
                get { return _mp; }
                set { _mp = value; }
            }

            public abstract void Accept(Visitor visitor);
            public abstract void DoSomething();
            public abstract void Detach();

        }




        /// <summary>
        /// A NPC character, which is the concrete representation of the base class character.
        /// </summary>
        class NPCCharacter : Character

        {

            public NPCCharacter()
            {
                Name = "Johnny Who Walks Around";
                Type = "Wanderer";
                Hp = 10;
                Mp = 10;
            }
            public override void Accept(Visitor visitor)

            {

                visitor.VisitNPCCharacter(this);

            }

            public override void Detach()
            {
                Console.WriteLine($"The NPC Named {Name} went inside their house.\n");
            }


            public override void DoSomething()

            {
                Console.WriteLine($"The NPC Named {Name} Said Something Silly");
            }

        }




        /// <summary>
        /// A monster character, which is the concrete representation of the base class character.
        /// </summary>
        class MonsterCharacter : Character

        {
            public MonsterCharacter()
            {
                Name = "Big Red Lizard";
                Type = "Reptile";
                Hp = 1000.00M;
                Mp = 100.00M;
            }
            public override void Accept(Visitor visitor)

            {

                visitor.VisitMonsterCharacter(this);

            }

            public override void Detach()
            {
                Console.WriteLine($"The Monster Named {Name} ran away... \n");
            }

            public override void DoSomething()
            {
                Console.WriteLine($"The Monster Named {Name} Attacked You!");
            }

        }


        /// <summary>
        /// A class representing a character object structure.
        /// </summary>
        class CharacterObjectStructure

        {

            private List<Character> _characters = new List<Character>();



            public void Attach(Character character)

            {

                _characters.Add(character);
                Console.WriteLine($"{character} has been added to character object structure.");

            }

            public void DetachAll()
            {
                for (var i = _characters.Count - 1; i >= 0; i--)
                {
                    Detach(_characters[i]);
                }
            }

            public void Detach(Character character)

            {
                character.Detach();
                _characters.Remove(character);
                Console.WriteLine($"{character} has been detached from character object structure.");
                Console.WriteLine();

            }



            public void Accept(Visitor visitor)

            {

                foreach (Character element in _characters)

                {

                    element.Accept(visitor);
                    Console.WriteLine($"{element.Name} is doing something...");
                    element.DoSomething();
                    Console.WriteLine();

                }

            }

        }
    }
}
