using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSample
{
    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            _logger.Error("hello, hello, hello");
            try
            {
                Hoge();
            }
            catch(Exception ex)
            {
                _logger.Error("01234567890", ex);
            }
                    
        }

        static void Hoge()
        {
            try
            {
                throw new Exception("death");
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("wrapped", ex);
            }
        }
    }
}
