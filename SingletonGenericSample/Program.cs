using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SingletonGenericSample
{
    class Program
    {
        static void Main(string[] args)
        {

            var ins = Singleton<Sample>.GetInstance();
            var ins1 = Singleton<Sample>.GetInstance();

            Console.WriteLine(ins == ins1);

            Console.ReadLine();
        }
    }

    public class Sample
    {
        private Sample()
        {
            Console.WriteLine("exits");
        }
    }

    public class Singleton<T> where T: class
    {
        private static T instance;
        private static object _lock = new object();

        public static T GetInstance()
        {
            if(instance == null)
            {
                CreateInstance();
            }

            return instance;
        }

        private static void CreateInstance()
        {
            lock (_lock)
            {
                if(instance == null)
                {
                    Type t = typeof(T);

                    ConstructorInfo[] ctors = t.GetConstructors();
                    if(ctors.Length > 0)
                    {
                        throw new InvalidOperationException("public ctor exists in type");
                    }

                    instance = (T)Activator.CreateInstance(t, true);

                    
                }
            }
        }
    }
}
