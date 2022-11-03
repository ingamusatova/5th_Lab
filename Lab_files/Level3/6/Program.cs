using System;

namespace LaboratoryL3N6
{
    class Program
    {
        public delegate Tuple<double, int> max_element(double x, int i, int j, int index, double maxim);
        public static Tuple<double, int> diagonal(double x, int i, int j, int index, double maxim)
        {
            if (i == j && maxim < x) 
            {
                maxim = x;
                index = j;
            }
            return Tuple.Create(maxim, index);
        }
        public static Tuple<double, int> row(double x, int i, int j, int index, double maxim)
        {
            if (i == 0 && maxim < x) 
            {
                maxim = x;
                index = j;
            }
            return Tuple.Create(maxim, index);
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
        static int max(int a, int b)
        {
            if (a >= b)
            {
                return a;
            }
            return b;
        }

        static void swap(double[,] matrix, int i, int a, int b)
        {
            double temp = matrix[i,a];
            matrix[i,a] = matrix[i,b];
            matrix[i,b] = temp;
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
           
            max_element r = row;
            max_element d = diagonal;

            double max_first_row = -1000000000000, max_diagonal = -10000000000;
            int index_row = 0, index_diagonal = 0;
            double[,] matrix = new double[n,m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i,j] = input(i,j);
                    (max_diagonal, index_diagonal) = d(matrix[i,j], i, j, index_diagonal, max_diagonal);
                    (max_first_row, index_row) = r(matrix[i,j], i, j, index_row, max_first_row);
                }
            }
            
            Console.WriteLine("Matrix before manipulation");
            print(matrix);

            int index_last = max(index_diagonal, index_row);
            int index_first = index_diagonal+ index_row - index_last;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == index_last)
                    {
                        swap(matrix, i, index_last, index_first);
                    }
                }
            }

            Console.WriteLine("Matrix after manipulation");
            print(matrix);
        }
    }
}