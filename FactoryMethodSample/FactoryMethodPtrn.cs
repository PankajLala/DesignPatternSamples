using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodSample
{
    /*
     * Defines an interface for creating an object, but let the subclass decide which class to instantiate.
     * It let's a class defer instantiation to the subclasses.
       */
    class FactoryMethodPtrn
    {
        static void Main(string[] args)
        {
            IProduct product = new ProductFactoryA().CreateProduct();
            product.DoWork();
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

    public interface IProductFactory
    {
        IProduct CreateProduct();
    }

    public class ProductFactoryA : IProductFactory
    {
        public IProduct CreateProduct()
        {
            return new ProductA();
        }
    }

    public class ProductFactoryB : IProductFactory
    {
        public IProduct CreateProduct()
        {
            return new ProductB();
        }
    }
}
