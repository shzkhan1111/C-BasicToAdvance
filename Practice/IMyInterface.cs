using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public interface IMyInterface
    {
        //public string Name { get => "Anonymous"; }
        //public string LastName{ get; set; }
        void Log(string message);


    }
    public class MyClass : IMyInterface
    {
        void IMyInterface.Log(string message)
        {
            Console.WriteLine($"{message} from myClass");
        }
    }
    public class MyClass2 : IMyInterface
    {
        public void Log(string message)
        {
            Console.WriteLine($"{message} from myClass");
        }
    }
    //public class MyClass2 : IMyInterface
    //{

    //}
}
