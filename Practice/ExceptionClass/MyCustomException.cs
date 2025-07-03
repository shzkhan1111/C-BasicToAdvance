using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.ExceptionClass
{
    
    public class MyCustsomException : Exception
    {
        public MyCustsomException() : base("Some tHing went wrong no message passes")
        {
            
        }
        public MyCustsomException(string message) : base($"Some tHing went wrong a message passes {message}")
        { 

        }
        public MyCustsomException(string message, Exception innerException) : base($"Some tHing went wrong a message passed along with Exception " +
            $"{message}" , innerException)
        {
            
        }
    }
}
