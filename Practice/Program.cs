using Practice;

public class Program
{
    //interface and defaault implementation
    public static void Main()
    {
        MyClass obj = new MyClass();
        obj.Greet();
        MyClass2 obj2 = new MyClass2();
        obj2.Greet();

        IMyInterface iobj = new MyClass2();
        iobj.Greet();

    }
}