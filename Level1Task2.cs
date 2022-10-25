using System.Collections.Generic;
using System.Windows.Markup;

class HelloWorld
{
    static double poluper(double a, double b, double c)
    {
        return (a+b+c)/2;
    }
    static double razn(double p, double x)
    {
        return p - x;
    }
    static int Main()
    {
        double a;
        double b;
        double c;
        Console.WriteLine("Enter 'a': ");
        double.TryParse(Console.ReadLine(), out a);
        Console.WriteLine("Enter 'b': ");
        double.TryParse(Console.ReadLine(), out b);
        Console.WriteLine("Enter 'c': ");
        double.TryParse(Console.ReadLine(), out c);
        if (a==0 || b==0 || c==0) { Console.WriteLine("Variables cannot be zeros."); return 0; }
        double S = Math.Sqrt(poluper(a, b, c) * razn(poluper(a, b, c), a) * razn(poluper(a, b, c), b) * razn(poluper(a, b, c), c));
        Console.WriteLine("Area = " + S);
        return 0;
    }
}