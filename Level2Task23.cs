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
    static void preobr1(List<List<int>> matrix, List<List<int>> koordinati, int h, out List<List<int>> koordinati1)
    {
        int k;
        int l;
        maxim(matrix, out k, out l);
        koordinati.Add(new List<int>());
        koordinati[h].Add(k);
        koordinati[h].Add(l);
        koordinati[h].Add(matrix[k][l]);
        matrix[k][l] = matrix[0].Min() - 1;
        koordinati1 = koordinati;
    }
    static void preobr2(List<List<int>> matrix, List<List<int>> koordinati, out List<List<int>> matrix1)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[0].Count; j++)
            {
                matrix[i][j] = matrix[i][j] / 2;
                for (int t = 0; t < 5; t++)
                {
                    if (i == koordinati[t][0] && j == koordinati[t][1]) { matrix[i][j] = koordinati[t][2] * 2; }
                }
            }
        }
        matrix1 = matrix;
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

        List<List<int>> koordinati1 = new List<List<int>>();
        List<List<int>> koordinati2 = new List<List<int>>();
        for (int i = 0; i < 5; i++)
        {
            preobr1(matrix1, koordinati1, i, out koordinati1);
        }
        for (int i = 0; i < 5; i++)
        {
            preobr1(matrix2, koordinati2, i, out koordinati2);
        }

        preobr2(matrix1, koordinati1, out matrix1);
        preobr2(matrix2, koordinati2, out matrix2);


        Console.WriteLine("New first matrix: ");
        vivodmatrici(matrix1);
        Console.WriteLine("New second matrix: ");
        vivodmatrici(matrix2);
        return 0;
    }
}