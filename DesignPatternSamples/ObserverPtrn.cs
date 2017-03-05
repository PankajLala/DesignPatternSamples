using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Defines a one to many relationship  between objects, such that one object changes all of its dependents objects are updated
 * */
namespace ObserverSamples
{
    class ObserverPtrn
    {
        static void Main(string[] args)
        {
            ISubject subject = new Subject();

            IObserver observer1 = new Observer();
            subject.Add(observer1);

            IObserver observer2 = new Observer();
            subject.Add(observer2);

            subject.SetState("Pankaj");

            subject.Remove(observer2);
            subject.SetState("Lala");

            Console.Read();
        }
    }

    public interface ISubject
    {
        void Notify();
        void Add(IObserver observer);
        void Remove(IObserver observer);

        void SetState(string str);

        string GetState();

    }

    public interface IObserver
    {
        void update(ISubject subject);
    }

    public class Subject : ISubject
    {
        private IList<IObserver> _observers = new List<IObserver>();
        private string _state;

        public void Add(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            foreach(IObserver observer in _observers)
            {
                observer.update(this);
            }
        }

        public void Remove(IObserver observer)
        {
            _observers.Remove(observer);
        }


        public string GetState()
        {
            return _state;
        }

        public void SetState(string str)
        {
            _state = str;
            Notify();
        }
    }

    public class Observer : IObserver
    {
        public void update(ISubject subject)
        {
            Console.Write(string.Format("Subjects state is changed to {0}",subject.GetState()));
        }
    }
}
