using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;

class HelloWorld
{
    static List<int> maxim(List<List<int>> matrix, List<int>maxi)
    {
        int max = matrix[0][0];
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                if (matrix[i][j] > max && maxi.Contains(matrix[i][j]) == false)
                {
                    max = matrix[i][j];
                }
            }
        }
        maxi.Add(max);
        return maxi;
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
    static List<List<int>> preobr1(List<List<int>> matrix, List<int> maxi)
    {
        for (int i=0; i<matrix.Count; i++)
        {
            for(int j=0; j<matrix[0].Count(); j++)
            {
                if (maxi.Contains(matrix[i][j]) == true) matrix[i][j] = matrix[i][j] * 2;
                else matrix[i][j] = matrix[i][j] / 2;
            }
        }
        return matrix;
    }
    static int Main()
    {
        List<List<int>> matrix1 = new List<List<int>>();
        List<List<int>> matrix2 = new List<List<int>>();
        Console.WriteLine("Enter the first size of first matrix: ");
        int n1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the second size of first matrix: ");
        int m1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter first matrix: ");
        vvodmatrici(n1, m1, out matrix1);
        Console.WriteLine("Enter the first size of second matrix: ");
        int n2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the second size of second matrix: ");
        int m2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second matrix: ");
        vvodmatrici(n2, m2, out matrix2);

        List<int> maxi1 = new List<int>();
        List<int> maxi2 = new List<int>();


        for (int i=0; i<5; i++)
        {
            maxim(matrix1, maxi1);
            maxim(matrix2, maxi2);
        }

        matrix1 = preobr1(matrix1, maxi1);
        matrix2 = preobr1(matrix2, maxi2);

        Console.WriteLine("New first matrix: ");
        vivodmatrici(matrix1);
        Console.WriteLine("New second matrix: ");
        vivodmatrici(matrix2);
        return 0;
    }
}
