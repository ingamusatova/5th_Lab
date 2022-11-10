using System;

namespace LaboratoryL3N6
{
    class Program
    {
        public delegate int max_element(double[,] matrix);
        static int diagonal(double[,] matrix)
        {
            double maxim = -100000000000;
            int index = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxim)
                {
                    maxim = matrix[i, i];
                    index = i;
                }
            }
            return index;
        }
        static int row(double[,] matrix)
        {
            double maxim = -100000000000;
            int index = 0;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i] > maxim)
                {
                    maxim = matrix[i, i];
                    index = i;
                }
            }
            return index;
        }
        static int input_int() //Int input for size
        {
            Console.Write($"Size: ");
            string input_x = Console.ReadLine();
            if (!int.TryParse(input_x, out var n) || (n < 2))
            {
                Console.WriteLine("Invalid input");
                System.Environment.Exit(1);
            }
            return n;
        }
        static int input(int i, int j)
        {
            Console.Write($"Array[{i}][{j}]: ");
            string input_n = Console.ReadLine();
            if (!(int.TryParse(input_n, out var n)))
            {
                Console.WriteLine("Invalid input");
                System.Environment.Exit(1);
            }
            return n;
        }
        
        static void swap(max_element for_row, max_element for_diagonal, double[,] matrix)
        {
            int index_diagonal = for_diagonal(matrix);
            int index_row = for_row(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double temp = matrix[i, index_diagonal];
                matrix[i, index_diagonal] = matrix[i, index_row];
                matrix[i, index_row] = temp;
            }
        }
        static void print(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int n = input_int();
            int m = input_int();
            double[,] matrix = new double[n,m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i,j] = input(i,j);
                }
            }
            
            Console.WriteLine("Matrix before manipulation");
            print(matrix);

            Console.WriteLine("Matrix after manipulation");
            swap(row, diagonal, matrix);
            print(matrix);
        }
    }
}