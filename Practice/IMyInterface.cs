using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class IMyInterface
    {
        public void Greet()
        {
            Console.WriteLine("Hello from IMyInterface!");
        }
    }
    public class MyClass : IMyInterface
    {
        public  void Greet()
        {
            Console.WriteLine("Hello from My Class!");
        }
    }
    public class MyClass2 : IMyInterface
    {
        
    }
}
