using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    /*Simple factory just abstract the responsibility of creating  object and let client delegate it to same.
     * */
    class Program
    {
        static void Main(string[] args)
        {
            IProduct product = Factory.CreateProduct("X");
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
        void IProduct.DoWork()
        {
            Console.WriteLine("Work done by product A"); 
        }

    }

    public class ProductB: IProduct
    {
        void IProduct.DoWork()
        {
            Console.WriteLine("Work done by product B");
        }
    }

    public  class Factory
    {
        public static IProduct CreateProduct(string identifier)
        {
            if (identifier == "A")
                return new ProductA();

            return new ProductB();
        }
    }
}
