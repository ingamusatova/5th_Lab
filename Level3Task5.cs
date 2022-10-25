using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;

class HelloWorld
{
    static void maxim(List<List<int>> matrix, out int k, out int l)
    {
        int max = matrix[0][0];
        k = 0;
        l = 0;
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                if (matrix[i][j] > max)
                {
                    max = matrix[i][j];
                    k = i;
                    l = j;
                }
            }
        }
    }
    static void vvodmatrici(int n, int m, out List<List<int>> matrix)
    {
        matrix = new List<List<int>>();
        string[] line;
        for (int i = 0; i < n; i++)
        {
            matrix.Add(new List<int>());
            while (true)
            {
                line = Console.ReadLine().Split(" ");
                if (line.Length != m) { Console.WriteLine("re-enter the line: "); continue; }
                else { break; }
            }

            for (int j = 0; j < m; j++)
            {
                matrix[i].Add(Convert.ToInt32(line[j]));
            }
        }

    }
    static void vivodmatrici(List<List<int>> matrix)
    {
        for (int i = 0; i < matrix.Count(); i++)
        {
            for (int j = 0; j < matrix[0].Count(); j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
    delegate double f(double x);
    static double f1(double x)
    {
        x = x * x - Math.Sin(x * 0.0175);
        return x;
    }
    static double f2(double x)
    {
        x = Math.Pow(Math.E, x) - 1;
        return x;
    }
    static void kolinter(f f1, double x, List<double> A, out List<double> A1)
    {
        if (f1(x) >= 0 ) A.Add(1);
        else A.Add(0);
        A1 = A;
        //Console.WriteLine(f1(x));
    }
    static void kollvo(f f1, double a, double b, double h, out double count)
    {
        count = 0;
        List<double> list = new List<double>();
        for (double x = a; x <= b; x = x + h)
        {
            kolinter(f1, x, list, out list);
        }
        for (int i = 0; i < list.Count-1; i++)
        {
            if (list[i] != list[i + 1]) count++;
        }
    }
    static int Main()
    {
        List<double> list = new List<double>();
        double kollvo1;
        double kollvo2;
        kollvo(f1, 0, 2, 0.1, out kollvo1);
        kollvo(f2, -1, 1, 0.2, out kollvo2);
        Console.WriteLine(kollvo1);
        Console.WriteLine(kollvo2);
        
        return 0;
    }
}