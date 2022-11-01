using System;

namespace LaboratoryL2N6
{
    class Program
    {
        static double[] Remove(double[] array, int index)
        {
            double[] ans = new double[array.Length - 1];
            int tmp = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if (i == index) 
                {
                    continue;
                }
                ans[tmp] = array[i];
                tmp++;
            }
            return ans;
        }
        static double input(int i)
        {
            Console.Write($"Index_{i}: ");
            string input_x = Console.ReadLine();
            if (!double.TryParse(input_x, out var n))
            {
                Console.WriteLine("Invalid input");
                System.Environment.Exit(1);
            }
            return n;
        }
        static void Print(double[] array1, double[] array2)
        {
            for (int i = 0; i < array1.Length; i++)
            {
                Console.Write($"{array1[i]} ");
            }
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write($"{array2[i]} ");
            }
        }
        static void Main(string[] args)
        {
            double[] array_A = new double[7];
            double[] array_B = new double[8];
            double maxim_A = -1000000000;
            int index_A = 0;
            for (int i = 0; i < 7; i++)
            {
                array_A[i] = input(i);
                if (array_A[i] > maxim_A)
                {
                    maxim_A = array_A[i];
                    index_A = i;
                }
            }

            double maxim_B = -1000000000;
            int index_B = 0;
            for (int i = 0; i < 8; i++)
            {
                array_B[i] = input(i);
                if (array_B[i] > maxim_B)
                {
                    maxim_B = array_B[i];
                    index_B = i;
                }
            }
            
            array_A = Remove(array_A, index_A);
            array_B = Remove(array_B, index_B);
            
            Print(array_A, array_B);
        }
    }
}