using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;

class HelloWorld
{
    static void rem(List<List<int>> matrix, int k, out List<List<int>> matrix1)
    {
        for (int i=0; i < matrix.Count; i++)
        {
            matrix[i].RemoveAt(k);
        }
        matrix1 = matrix;
    }
    static int Main()
    {
        Console.WriteLine("Enter the lenght of side of matrix: ");
        int n = Convert.ToInt32(Console.ReadLine());
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
                matrix[i].Add(Convert.ToInt32(line[j]));
            }
        }
        double max = matrix[0][1];
        int k = 1;
        double min = matrix[1][0];
        int v = 0;
        for (int i=0; i < matrix.Count; i++)
        {
            for (int j=i+1; j < matrix[i].Count; j++)
            {
                if (matrix[i][j] > max) { max = matrix[i][j]; k = j; }
            }
        }
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (matrix[i][j] < min) { min = matrix[i][j]; v = j; }
            }
        }
        rem(matrix, k, out matrix);
        rem(matrix, v, out matrix);
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