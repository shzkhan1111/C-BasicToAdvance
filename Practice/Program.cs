using Practice;

public class Program
{
    //interface and defaault implementation
    public static void Main()
    {
        MyClass obj = new MyClass();
        obj.Greet();
        obj.Clicked += (sender, e) => Console.WriteLine("You have clicked a button");
        obj.Clicked += (sender, e) => Console.WriteLine("You have clicked a button");
        obj.Clicked += (sender, e) => Console.WriteLine("You have clicked a button");
        obj.OnClicked();
        obj.OnClicked();
        //MyClass2 obj2 = new MyClass2();
        //((IMyInterface)obj2).Greet();

        //IMyInterface iobj = new MyClass2();
        //iobj.Greet();

    }
}