using System;

namespace LaboratoryL1N2
{
    class Program
    {
        static void check(double[] array, int triangle)
        {
            for (int i = 0; i < 3; i++)
            {
                if (array[i] >= array[(i+1)%3] + array[(i+2)%3])
                {
                    Console.WriteLine($"Wrong sides of the triangle {triangle}");
                    System.Environment.Exit(1);
                }
            }
        }
        static double input(int i)
        {
            Console.Write($"Side_{i}: ");
            string input_x = Console.ReadLine();
            if (!double.TryParse(input_x, out var n))
            {
                Console.WriteLine("Invalid input");
                System.Environment.Exit(1);
            }
            return n;
        }
        static double Geron(double[] array)
        {
            double p = (array[0] + array[1] + array[2]) / 2;
            double ans = Math.Sqrt(p * (p - array[0]) * (p - array[1]) * (p - array[2]));
            return ans;
        }
        static void winner(double s1, double s2)
        {
            if (s1 > s2)
            {
                Console.WriteLine("1st triangle is bigger");
            }
            if (s1 < s2)
            {
                Console.WriteLine("2nd triangle is bigger");
            }
            if (s1 == s2)
            {
                Console.WriteLine("Triangles are equal");
            }
        }
        static double[] array_filling(double[] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                array[i] = input(i);
            }
            return array;
        }
        static void Main(string[] args)
        {
            double[] array_1st = new double[3];
            double[] array_2nd = new double[3];
            
            array_1st = array_filling(array_1st, 3);
            array_2nd = array_filling(array_2nd, 3);
            
            check(array_1st, 1);
            check(array_2nd, 2);
            
            double s1 = Geron(array_1st);
            double s2 = Geron(array_2nd);
            
            winner(s1, s2);
        }
    }
}