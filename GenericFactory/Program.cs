using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IProduct prod = new ProductFactory().CreateProduct<ProductC>();
            prod.DoWork();
            Console.ReadLine();
        }
    }

    public interface IProduct
    {
        void DoWork();
    }

    public class ProductA : IProduct
    {
        public void DoWork()
        {
            Console.WriteLine("Work done by Product A");
        }
    }
    public class ProductB : IProduct
    {
        public void DoWork()
        {
            Console.WriteLine("Work done by Product B");
        }
    }

    public class ProductC : IProduct
    {
        public void DoWork()
        {
            Console.WriteLine("Work done by Product C");
        }
    }

    public class ProductFactory
    {
        public T CreateProduct<T>()
        {
            Type type = typeof(T);
            return (T)Activator.CreateInstance(type);
        }
    }
}
