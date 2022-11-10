using System;

namespace LaboratoryL1N1
{
    class Program
    {
        static int Factorial(int n)
        {
            int ans = 1;
            for (int i = 1; i <= n; i++)
            {
                ans *= i;
            }
            return ans;
        }
        static int input()
        {
            Console.Write($"N (8, 10 or 11): ");
            string input_n = Console.ReadLine();
            if ((int.TryParse(input_n, out var n) && ((n == 8) || (n == 10) || (n == 11))) == false)
            {
                Console.WriteLine("Usage: n should be one of 8, 10 or 11");
                System.Environment.Exit(1);
            }
            return n;
        }
        static int ans(int n, int k)
        {
            return Factorial(n) / (Factorial(k)*Factorial(n-k));
        }
        static void Main(string[] args)
        {
            int n = input();
            int answer = ans(n,5);
            Console.WriteLine($"Answer: {answer}");
        }
    }
}