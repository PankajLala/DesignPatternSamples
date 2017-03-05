using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterSample
{
    /*
     * Converts the interface of a class to another interface which client expects
     * */
    class AdapterPtrn
    {
        static void Main(string[] args)
        {
            /* Main method (client) was earlier using IEnumerator interface (thus its implementation). Now the new implementation
             * is  provided by IIterator. We have following requirements
             * a) Client wants to keep new Interface i.e IIterator
             * b) Client still wants to use old legacy code implementation.
             * */
            IIterator iterator = new EnumeratorIterator(new Enumerator());

            iterator.hasNext();
            iterator.moveNext();
    
            Console.ReadLine();
        }
    }

    public interface IEnumerator
    {
        void moveNext();
        void hasNext();
    }
    
    public class Enumerator : IEnumerator
    {
        public void hasNext()
        {
            Console.WriteLine("IEnumerator.hasNext");
        }

        public void moveNext()
        {
            Console.WriteLine("IEnumerator.moveNext");
        }
    }

    public interface IIterator
    {
        void moveNext();
        void hasNext();
        void remove();

    }

    public class Iterator : IIterator
    {
        public void hasNext()
        {
            Console.WriteLine("IIterator.hasNext");
        }

        public void moveNext()
        {
            Console.WriteLine("IIterator.moveNext");
        }

        public void remove()
        {
            Console.WriteLine("IIterator.remove");
        }
    }


    public class EnumeratorIterator : IIterator
    {
        private IEnumerator _enum;
        public EnumeratorIterator(IEnumerator enumerator)
        {
            _enum = enumerator;
        }

        public  void hasNext()
        {
            _enum.hasNext();
        }

        public  void moveNext()
        {
            _enum.moveNext();
        }

        public  void remove()
        {
            throw new NotSupportedException();
        }

    }
}
