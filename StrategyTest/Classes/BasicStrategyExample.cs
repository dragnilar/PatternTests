using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyTest.Classes
{
    public class BasicStrategyExample
    {
        public void ShowExample()
        {
            Console.Clear();
            Console.WriteLine("Begin basic strategy example.");

            var context = new BasicStrategyContext(new Strategy1());
            context.ContextInterface();
            context = new BasicStrategyContext(new Strategy2());
            context.ContextInterface();
            context = new BasicStrategyContext(new Strategy3());
            context.ContextInterface();

            Console.WriteLine("Finished basic strategy example.");
            Console.ReadKey();
            Console.Clear();

        }

        public class BasicStrategyContext
        {
            private BasicStrategy _basicStrategy;

            public BasicStrategyContext(BasicStrategy strategy)
            {
                this._basicStrategy = strategy;
            }

            public void ContextInterface()
            {
                _basicStrategy.AlgorithmInterface();
            }
        }

        public abstract class BasicStrategy
        {
            public abstract void AlgorithmInterface();
        }
        public class Strategy1 : BasicStrategy {
            public override void AlgorithmInterface()
            {
                Console.WriteLine($"Called {this.GetType().Name}'s Algorithm Interface");
            }
        }
        public class Strategy2 : BasicStrategy {
            public override void AlgorithmInterface()
            {
                Console.WriteLine($"Called {this.GetType().Name}'s Algorithm Interface");
            }
        }
        public class Strategy3 : BasicStrategy {
            public override void AlgorithmInterface()
            {
                Console.WriteLine($"Called {this.GetType().Name}'s Algorithm Interface");
            }
        }
    }
}
