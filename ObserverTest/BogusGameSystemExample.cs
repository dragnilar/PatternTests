using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    public class BogusGameSystemExample
    {

        public void RunExample()
        {
            Console.Clear();
            Console.WriteLine("Running bogus game system observer example...");
            Console.WriteLine("Creating a bogus game system and attaching observers...\n");

            var bogusSystem = new BogusGameSystem();
            bogusSystem.Attach(new BootUpSequence());
            bogusSystem.Attach(new PowerSupplyObserver());
            bogusSystem.Attach(new GraphicsCardObserver());
            bogusSystem.Attach(new CpuObserver());

            Console.WriteLine("Running notify/getting state of the system.\n");

            bogusSystem.Notify();

            Console.WriteLine("\n Bogus game system example done. Press any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();
        }


        interface ISystemObserver
        {
            void Update();
        }

        private class BogusGameSystem
        {
            private List<ISystemObserver> systemObserversList = new List<ISystemObserver>();

            public void Attach(ISystemObserver systemObserver)
            {
                systemObserversList.Add(systemObserver);
            }

            public void Detach(ISystemObserver systemObserver)
            {
                systemObserversList.Remove(systemObserver);
            }

            public void Notify()
            {
                systemObserversList.ForEach(r=>r.Update());
            }
        }

        private class PowerSupplyObserver : ISystemObserver
        {
            public void Update()
            {
                Console.WriteLine("The power supply is running.");
            }
        }

        private class GraphicsCardObserver : ISystemObserver
        {
            public void Update()
            {
                Console.WriteLine("The graphics card is crunching numbers and making a lot of heat.");
            }
        }

        private class CpuObserver : ISystemObserver
        {
            public void Update()
            {
                Console.WriteLine("The CPU is working the threads. It's working. Yep.");
            }
        }

        public abstract class BootCheckList
        {
            public void RunTheRoutine()
            {
                PowerUp();
                BootOs();
                ShowDisplay();
            }

            protected virtual void PowerUp()
            {
                Console.WriteLine("The system is powering up!");
            }

            protected virtual void BootOs()
            {
                Console.WriteLine("The system is booting up the operating system.");
            }

            protected virtual void ShowDisplay()
            {
                Console.WriteLine("The system is outputting an image to whatever display is attached.");
            }
        }

        public class BootUpSequence : BootCheckList, ISystemObserver
        {
            public void Update()
            {
                Console.WriteLine("Starting boot up...");
                RunTheRoutine();
                Console.WriteLine("Boot up complete...");
            }

            protected override void ShowDisplay()
            {
                Console.WriteLine("The system is trying to output the OS startup animation.");
            }
        }
    }
}
