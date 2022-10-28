using System.Collections.Generic;
using System.Windows.Markup;

class HelloWorld
{
    static double factorial(double f)
    {
        double fact = 1;
        for (double i=1; i<=f; i++)
        {
            fact = fact * i;
        }
        return fact;
    }
    static int Main()
    {
        double n;
        double k;
        Console.WriteLine("Enter 'n': ");
        double.TryParse(Console.ReadLine(), out n);
        Console.WriteLine("Enter 'k': ");
        double.TryParse(Console.ReadLine(), out k);
        if (k==0 || n==0) { Console.WriteLine("Variables cannot be zeros."); return 0; }
        Console.WriteLine("Number of ways: ");
        Console.WriteLine(factorial(n) / (factorial(k) * factorial(n - k)));
        return 0;
    }
}