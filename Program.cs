namespace _5Lab
{
    class Program
    {
        static void WriteMass(int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write($"{x[i]}, ");
            }
            Console.WriteLine();
        }
        static bool CheckIfFirstMoreAverage(int[] x)
        {
            int sum = 0;
            double average = 0;

            for (int i = 0; i < x.Length; i++)
            {
                sum+= x[i];
            }

            average = sum / x.Length;

            if (x[0] > average)
            {
                return true;
            }
            else return false;
        }

        delegate int[] ForChange(int[] x);
        
        static int[] Changing(ForChange f, int[] x)
        {
            return f(x);
        }
        static int[] ChangePositions(int[] x)
        {
            bool condition = CheckIfFirstMoreAverage(x);
            int remembered = 0;
            if (condition == true)
            {
                for (int i = 0; i < x.Length - 1; i+= 2)
                {
                    remembered = x[i];
                    x[i] = x[i + 1];
                    x[i + 1] = remembered;
                }
            }
            else
            {
                for (int i = x.Length - 1; i > 0; i -= 2)
                {
                    remembered = x[i];
                    x[i] = x[i - 1];
                    x[i - 1] = remembered;
                }
            }

            return x;
        }

        static int FindSum(int[] x)
        {
            int sum = 0;
            for (int i = 1; i < x.Length; i+=2)
            {
                sum+= x[i];
            }

            return sum;
        }
        static void Main(string[] args)
        {
            int[] A = new int[10] {1, 43, 56, 2, 9, 11, 32, 15, 100, 99};

            Console.WriteLine("Исходная матрица: ");
            WriteMass(A);

            A = Changing(ChangePositions, A);

            Console.WriteLine("Матрица после перестановок");
            WriteMass(A);

            int sum = FindSum(A);
            Console.WriteLine($"Сумма элементов с нечётными индексами: {sum}");
        }
    }
}