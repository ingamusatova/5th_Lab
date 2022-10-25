using System.Collections.Generic;
using System.Windows.Markup;

class HelloWorld
{
    static void rem(List<double> A, out List<double> B)
    {
        A.Remove(A.Max());
        B = A;
    }
    static int Main()
    {
        double n;
        double m;
        var A = new List<double>();
        var B = new List<double>();
        Console.WriteLine("Enter the size of first array: ");
        double.TryParse(Console.ReadLine(), out n);
        Console.WriteLine("Enter the size of second array: ");
        double.TryParse(Console.ReadLine(), out m);
        if (n == 0 || m == 0) { Console.WriteLine("Variables cannot be zeros."); return 0; }
        Console.WriteLine("Enter first array: ");
        for (int i = 0; i < n; i++)
        {
            double x;
            double.TryParse(Console.ReadLine(), out x);
            A.Add(x);
        }
        Console.WriteLine("Enter second array: ");
        for (int i = 0; i < m; i++)
        {
            double x;
            double.TryParse(Console.ReadLine(), out x);
            B.Add(x);
        }
        rem(A, out A);
        rem(B, out B);
        for (int i=0; i<B.Count(); i++)
        {
            A.Add(B[i]);
        }
        Console.WriteLine("New Array:");
        for (int i = 0; i < A.Count(); i++)
        {
            Console.Write(A[i]+ " ");
        }
        return 0;
    }
}