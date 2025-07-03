using Practice;
using Practice.ExceptionClass;

public class Program
{
    //interface and defaault implementation
    public static void Main()
    {
        try
        {
            var i = Console.ReadLine();
            int e = int.Parse(i);
        }
        catch (Exception ex) 
        {
            throw new MyCustsomException("This is a custom exception", ex);
        }
    }
}