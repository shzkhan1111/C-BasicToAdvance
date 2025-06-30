using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public interface IMyInterface
    {
        event EventHandler Clicked;
        public void Greet()
        {
            Console.WriteLine("Hello from IMyInterface!");
        }
    }
    public class MyClass : IMyInterface
    {
        public event EventHandler Clicked;

        public void Greet()
        {
            Console.WriteLine("Hello from My Class!");
        }
        public void OnClicked()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
    //public class MyClass2 : IMyInterface
    //{
        
    //}
}
