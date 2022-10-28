using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;

class HelloWorld
{
    static List<List<int>> rem(List<List<int>> matrix, int k)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            matrix[i].RemoveAt(k);
        }
        return matrix;
    }
    static int Main()
    {
        Console.WriteLine("Enter the lenght of side of matrix: ");
        int n;
        int.TryParse(Console.ReadLine(), out n);
        if (n == 1)
        {
            Console.WriteLine("In a one-element matrix, there are no elements below the main diagonal.");
            return 0;
        }
        List<List<int>> matrix = new List<List<int>>();
        var A = new List<int>();
        var B = new List<int>();
        string[] line;
        Console.WriteLine("Enter the matrix: ");
        for (int i = 0; i < n; i++)
        {
            matrix.Add(new List<int>());
            while (true)
            {
                line = Console.ReadLine().Split(" ");
                if (line.Length != n) { Console.WriteLine("re-enter the line: "); continue; }
                else { break; }
            }

            for (int j = 0; j < n; j++)
            {
                int x;
                int.TryParse(line[j], out x);
                matrix[i].Add(x);
            }
        }
        double max = matrix[0][0];
        int k = 0;
        double min = matrix[0][1];
        int v = 1;
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = i + 1; j < matrix[i].Count; j++)
            {
                if (matrix[i][j] < min) { min = matrix[i][j]; v = j; }
            }
        }
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                if (matrix[i][j] > max) { max = matrix[i][j]; k = j; }
            }
        }
        if (k != v)
        {
            matrix = rem(matrix, k);
            matrix = rem(matrix, v);
        }
        else matrix = rem(matrix, v);
        Console.WriteLine("New matrix: ");
        for (int i = 0; i < matrix.Count(); i++)
        {
            for (int j = 0; j < matrix[0].Count(); j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
        return 0;
    }
}
