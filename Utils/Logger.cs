using System;
public static class Logger
{
    public static void i(string txt) {
        Console.WriteLine(txt);
     }
    public static void e(string txt) { 
        Console.WriteLine(txt);
    }
    public static void e(string txt, Exception ex)
    {
        Console.WriteLine(txt);
    }
}