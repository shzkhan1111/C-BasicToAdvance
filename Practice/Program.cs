using Practice;
using Practice.ExceptionClass;

public class Program
{
    //interface and defaault implementation
    public static void Main()
    {
        try
        {
            Method1();
        }
        catch (Exception ex) 
        {
            Console.WriteLine("Exception caught in Main: " + ex.Message);
        }
    }
    static void Method1()
    {
        try
        {
            Method2();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    private static void Method2()
    {
        throw new Exception("This is a custom exception");
    }
}