using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    public class VanillaObserverExample
    {

        public void RunExample()
        {
            Console.Clear();
            Console.WriteLine("Begin vanilla observer example...\n");
            var subject = new ConcreteSubject();

            Console.WriteLine("Creating a few random observers and attaching to the subject.");

            subject.Attach(new ConcreteObserver(subject, "AbbaCabba"));
            subject.Attach(new ConcreteObserver(subject, "YaddAbba"));
            subject.Attach(new ConcreteObserver(subject, "MooNooGloo"));
            subject.Attach(new ConcreteObserver(subject, "Virus!!!!"));
            subject.Attach(new ConcreteObserver(subject, "The Last Gummy"));

            Console.WriteLine("Getting the current state of the subject.");

            subject.SubjectState = "Default State, nothing has changed yet.";

            subject.Notify();
            

            Console.WriteLine("Changing state...");

            Console.WriteLine("Getting the current state of the subject.");


            subject.SubjectState = "The state has changed!";

            subject.Notify();
            
            Console.WriteLine();

            Console.WriteLine("End vanilla observer example...\n Press any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();

        }

        abstract class Subject
        {
            private List<Observer> ObserverList = new List<Observer>();

            public void Attach(Observer observer)
            {
                ObserverList.Add(observer);
            }

            public void Detach(Observer observer)
            {
                ObserverList.Remove(observer);
            }

            public void Notify()
            {
                foreach (var observer in ObserverList)
                {
                    observer.Update();
                }
            }
        }


        class ConcreteSubject : Subject
        {
            public string SubjectState { get; set; }
        }

        abstract class Observer
        {
            public abstract void Update();
        }


        class ConcreteObserver : Observer
        {
            private string _name;
            private string _observerState;
            private ConcreteSubject _subject;

            public ConcreteObserver(ConcreteSubject subject, string name)
            {
                _subject = subject;
                _name = name;
            }

            public override void Update()
            {
                _observerState = _subject.SubjectState;
                Console.WriteLine($"Observer {_name}'s current state is {_observerState}");
            }

            public ConcreteSubject Subject
            {
                get => _subject;
                set => _subject = value;
            }
            
        }

    }
}
