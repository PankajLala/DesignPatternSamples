using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverEvents
{
    class Program
    {
        static void Main(string[] args)
        {

            Subject subject = new Subject();

            Observer ob1 = new Observer(subject);
            Observer ob2 = new Observer(subject);

            ob1.Subscribe();
            ob2.Subscribe();

            subject.Notifiy();

            ob2.Unsubscribe();

            subject.Notifiy();

            Console.ReadLine();
        }
    }

    public class Subject
    {
        public event EventHandler eventHandler;

        public void Notifiy()
        {
            if (eventHandler != null)
            {
                eventHandler(this, EventArgs.Empty);
            }
        }
    }

    public class Observer
    {
        private Subject _subject;
        public Observer(Subject subject)
        {
            _subject = subject;
        }

        public void Subscribe()
        {
            _subject.eventHandler += DoWork; 
        }

        public void Unsubscribe()
        {
            _subject.eventHandler -= DoWork;
        }

        public void DoWork(object sender, EventArgs e)
        {
            Console.WriteLine("State updated");
        }
    }
}
