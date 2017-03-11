using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategySample
{
    /*Define a family of algorithms, encapsulate each one and make them interchangable
     * */
    class StrategyPtrn
    {
        static void Main(string[] args)
        {
            //Context
            SortedList sortedList = new SortedList();
            sortedList.Add("item1");
            sortedList.Add("item2");
            sortedList.Add("item3");

            //Create the intended algorithm 
            ISortStrategy sortAlgo = new QuickSort();

            //Inject it in the context
            sortedList.SetSortStrategy(sortAlgo);

            //Context to execute  the algorithm
            sortedList.Sort();

            //Change the algorithm without any change in context and client
            sortedList.SetSortStrategy(new MergeSort());

            //context to execute new algorithm
            sortedList.Sort();

            Console.ReadLine();
        }
    }

    public interface ISortStrategy
    {
        void Sort(IList<string> list);
    }

    public class QuickSort : ISortStrategy
    {
        public void Sort(IList<string> list)
        {
            Console.WriteLine("QuickSort");
        }
    }

    public class MergeSort : ISortStrategy
    {
        public void Sort(IList<string> list)
        {
            Console.WriteLine("MergeSort");
        }
    }

    public class BubbleSort : ISortStrategy
    {
        public void Sort(IList<string> list)
        {
            Console.WriteLine("BubbleSort");
        }
    }

    class SortedList
    {
        private IList<string> _list = new List<string>();
        private ISortStrategy _algo;
        public void SetSortStrategy(ISortStrategy algo)
        {
            _algo = algo;
        }

        public void Sort()
        {
            _algo.Sort(_list);
        }

        public void Add(string item)
        {
            _list.Add(item);
        }
    }


}
