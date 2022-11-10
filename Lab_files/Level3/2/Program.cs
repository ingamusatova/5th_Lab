using System;

namespace LaboratoryL3N2
{
    class Program
    {
        public delegate void sorting(double[] line);
        public static void ascending(double[] line)
        {
            Array.Sort(line);
        }
        public static void descending(double[] line)
        {
            Array.Sort(line);
            Array.Reverse(line);
        }
        static void sort_method(sorting method, double[] line)
        {
            method(line);
        }
        static void print(double[] line)
        {
            for (int i = 0; i < line.Count(); i++)
            {
                Console.Write($"{line[i]} ");
            }
            Console.WriteLine();
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
            

            double[] line = new double[m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    line[j] = matrix[i,j];
                }
                if (i % 2  == 0)
                {
                    sort_method(ascending, line);
                }
                else
                {
                    sort_method(descending, line);
                }
                print(line);
            }
        }
    }
}