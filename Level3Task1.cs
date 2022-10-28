using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Markup;

class HelloWorld
{
    delegate double fc(double x);
    delegate double f(double x, double i);
    static double factorial(double x)
    {
        double fact = 1;
        for (double i=1; i<=x; i++)
        {
            fact = fact * i;
        }
        return fact;
    }
    static double f1(double x, double i)
    {
        x = Math.Cos(x * 0.0175 * i)/factorial(i);
        return x;
    }
    static double f2(double x,double i)
    {
        x = Math.Pow(-1, i) * (Math.Cos(x * 0.0175 * i) / Math.Pow(i, 2));
        return x;
    }
    static double y1(double x)
    {
        return Math.Pow(Math.E, Math.Cos(x*0.0175)) * Math.Cos(Math.Sin(x * 0.0175));
    }
    static double y2(double x)
    {
        return (Math.Pow(x, 2) - (Math.Pow(Math.PI, 2) / 2)) / 4;
    }
    static double sum(f f1, double x)
    {
        double summa = 0;
        for (double i = 1; i >= 0; i++)
        {
            if (Math.Abs(f1(x, i)) < 0.001) {return summa; }
            summa = summa + f1(x, i);
        }
        return summa;
    }
    static void sum1(f f1, fc f2,double a, double b, double h, double k)
    {
        for (double x = a; x <= b; x = x + h)
        {
            Console.WriteLine("Summa = " + sum(f1, x)+k + ". Accurancy of function = " + (f2(x) - sum(f1, x)+k));
        }
    }
    static int Main()
    {
        Console.WriteLine("The first: ");
        sum1(f1, y1, 0.1, 1, 0.1, 1);
        Console.WriteLine("The second: ");
        sum1(f2, y2, (Math.PI / 5), (Math.PI), (Math.PI / 25), 0);

        return 0;
    }
}