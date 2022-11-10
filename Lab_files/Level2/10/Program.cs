using System;

namespace LaboratoryL2N10
{
    class Program
    {
        static double input(int i, int j)
        {
            Console.Write($"Index_[{i}][{j}]: ");
            string input_x = Console.ReadLine();
            if (!double.TryParse(input_x, out var n))
            {
                Console.WriteLine("Invalid input");
                System.Environment.Exit(1);
            }
            return n;
        }
        static int input_int()
        {
            Console.Write($"Size: ");
            string input_x = Console.ReadLine();
            if (!int.TryParse(input_x, out var n))
            {
                Console.WriteLine("Invalid input");
                System.Environment.Exit(1);
            }
            return n;
        }
        static double[,] RemoveColumns(double[,] array, int index1, int index2)
        {
            int height = array.GetLength(0), width = array.GetLength(1) - 2;
            if (index1 == index2)
            {
                width++;
            }
            double[,] final_matrix = new double[height, width];

            for (int i = 0; i < height; i++)
            {
                int index_j = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((j == index1) || (j == index2))
                    {
                        continue;
                    }
                    final_matrix[i,index_j] = array[i,j];
                    index_j++;
                }
            }
            return final_matrix;
        }
        static void print(double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i,j]} ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int n = input_int();
            double[,] array = new double[n,n];
            
            double maxim_under = -1000000000;
            double minim_upper = 10000000000;
            int index_under = 0;
            int index_upper = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i,j] = input(i,j);
                    if (j <= i)
                    {
                        if (array[i,j] > maxim_under)
                        {
                            maxim_under = array[i,j];
                            index_under = j;
                        }
                    }
                    if (j > i)
                    {
                        if (array[i,j] < minim_upper)
                        {
                            minim_upper = array[i,j];
                            index_upper = j;
                        }
                    }
                }
            }

            array = RemoveColumns(array, index_upper, index_under);
            
            print(array);
        }
    }
}