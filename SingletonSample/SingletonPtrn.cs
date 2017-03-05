using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonSample
{
    class SingletonPtrn
    {
        static void Main(string[] args)
        {
            Logger log = Logger.GetLogger;
            Logger log1 = Logger.GetLogger;

            Console.WriteLine(log.Equals(log1));
            Console.ReadLine();
        }
    }

    public sealed class Logger
    {
        private  Logger(){}

        private static Logger _logger;

        public static Logger GetLogger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger();
                }
                return _logger;
            }
           
        }
    }
}
