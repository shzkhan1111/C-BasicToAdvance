using Practice;

public class Program
{
    //interface and defaault implementation
    public static void Main()
    {
        MyClass obj = new MyClass();
        //obj.Log(); //error
        IMyInterface ob1 = new MyClass();
        ob1.Log("This is my name"); //error
        MyClass2 obj2 = new MyClass2();
        obj2.Log("This is my name from myClass2");

    }
}