using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.Commons
{
    public class BluePumpkinException : Exception
    {
        public BluePumpkinException()
        {
        }

        public BluePumpkinException(string message) : base(message)
        {
        }

        public BluePumpkinException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
