using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Threading.Channels;
using Microsoft.VisualBasic;
using Tuple = System.Tuple;

namespace _5_Lab
{
    class Program
    {
        private static int k = 5;
        private static int n = 0;
        private static int m = 0;
        private static double Fn, Fk, Fnk;
        private static double C = 0;
        private static double a, b, c, s1, s2;
        
        static void Task1_1lvl()
        {
            Console.WriteLine("1 Level:");
            Console.WriteLine("1 Task:");
            n = 8;
            Fn = Fact(n);
            Fk = Fact(k);
            Fnk = Fact(n - k);
            Combinations(Fn, Fk, Fnk, out C);
            Console.WriteLine($"Combinations for {n} people:");
            Console.WriteLine(C);
            n = 10;
            Fn = Fact(n);
            Fnk = Fact(n - k);
            Combinations(Fn, Fk, Fnk, out C);
            Console.WriteLine($"Combinations for {n} people:");
            Console.WriteLine(C);
            n = 11;
            Fn = Fact(n);
            Fnk = Fact(n - k);
            Combinations(Fn, Fk, Fnk, out C);
            Console.WriteLine($"Combinations for {n} people:");
            Console.WriteLine(C);
        }
        static void Task2_1lvl()
        {
            s1 = s2 = 0;
            Console.WriteLine("2 Task:");
            Console.WriteLine("Enter 3 sides of 1 triangle:");
            if (double.TryParse(Console.ReadLine(), out a) && double.TryParse(Console.ReadLine(), out b) &&
                double.TryParse(Console.ReadLine(), out c))
            {
                if (TriangleCheck(a, b, c))
                {
                    Square(a, b, c, out s1);
                }
                else
                {
                    s1 = 0;
                    Console.WriteLine("Triangle doesnt exist");
                }
            }
            Console.WriteLine("Enter 3 sides of 2 triangle:");
            if (double.TryParse(Console.ReadLine(), out a) && double.TryParse(Console.ReadLine(), out b) &&
                double.TryParse(Console.ReadLine(), out c))
            {
                if (TriangleCheck(a, b, c))
                {
                    Square(a, b, c, out s2);
                }
                else
                {
                    s2 = 0;
                    Console.WriteLine("Triangle doesnt exist");
                }
            }

            if (s1 != 0 && s2 != 0)
            {
                if (s1 > s2) Console.WriteLine("Area of the 1 triangle is larger");
                else if (s2 > s1) Console.WriteLine("Area of the 1 triangle is larger");
                else Console.WriteLine("Areas are equal");
            }
        }
        static void Task6_2lvl()
        {
            Console.WriteLine("6 Task:");
            n = 7;
            m = 8;
            k = 0;
            double[] A = new double[n + m - 2];
            double[] B = new double[m];
            Console.WriteLine("Enter the first array separating elements with a space");
            ToArray(Console.ReadLine(), n ,out A);
            Console.WriteLine("Enter the second array separating elements with a space");
            ToArray(Console.ReadLine(), m ,out B);
            DelElem(n, A, out A);
            DelElem(m, B, out B);
            Array.Resize(ref A, (n + m - 2));
            for (int i = (n - 1); i < (n + m - 2); i++)
            {
                A[i] = B[k];
                k++;
            }
            Console.WriteLine("Final array:");
            Console.WriteLine(String.Join(" ", A));
        }
        static void Task10_2lvl()
        {
            double MaxN = Double.MinValue;
            double MinN = Double.MaxValue;
            int MinJ = -1, MaxJ = -1;
            Console.WriteLine("10 Task:");
            Console.WriteLine("Enter the number of rows and columns:");
            if (int.TryParse(Console.ReadLine(), out n))
            {
                double[,] A = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (double.TryParse(Console.ReadLine(), out C)) A[i, j] = C;
                        if (i - j >= 0)
                        {
                            if (C > MaxN)
                            {
                                MaxN = C;
                                MaxJ = j;
                            }
                        }
                        else
                        {
                            if (C < MinN)
                            {
                                MinN = C;
                                MinJ = j;
                            }
                        }
                    }
                }
                if (MaxJ != -1) DelColumn(A, MaxJ, out A);
                if (MinJ != -1) DelColumn(A, MinJ, out A);
                Console.WriteLine("Matrix:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < (A.GetLength(1)); j++)
                    {
                        Console.Write($"{A[i, j], 5}");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Task23_2lvl()
        {
            Console.WriteLine("23 Task:");
            Console.WriteLine("Enter the number of rows for 1 matrix:");
            if (int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Enter the number of columns for 1 matrix:");
                if (int.TryParse(Console.ReadLine(), out m))
                {
                    double[,] A = new double[n, m];
                    Console.WriteLine("Enter the matrix:");
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if (double.TryParse(Console.ReadLine(), out C))
                            {
                                A[i, j] = C;
                            }
                        }
                    }
                    Matrix5Maximums(A, out A);
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            Console.Write($"{A[i, j], 5}");
                        }
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine("Enter the number of rows for 2 matrix:");
            if (int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Enter the number of columns for 2 matrix:");
                if (int.TryParse(Console.ReadLine(), out m))
                {
                    double[,] A = new double[n, m];
                    Console.WriteLine("Enter the matrix:");
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if (double.TryParse(Console.ReadLine(), out C))
                            {
                                A[i, j] = C;
                            }
                        }
                    }
                    Matrix5Maximums(A, out A);
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            Console.Write($"{A[i, j], 5}");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        static void Task1_3lvl()
        {
            Console.WriteLine("3 Level:");
            Console.WriteLine("1 Task:");
            double S = 0;
            Console.WriteLine("First sum:");
            for (double i = 0.1; i <= 1.0; i += 0.1)
            {
                S = ElementsCycle(TaylorsRow1, i);
                Console.WriteLine($"x: {i}, y: {Math.Round(Math.Pow(Math.E, Math.Cos(i)) * Math.Cos(Math.Sin(i)), 5)}, s: {Math.Round(S + 1, 5)}");
            }

            Console.WriteLine("Second sum");
            for (double i = Math.PI / 5; i <= Math.PI; i += Math.PI / 25)
            {
                S = ElementsCycle(TaylorsRow2, i);
                Console.WriteLine($"x: {i}, y: {Math.Round((i * i - Math.PI * Math.PI / 3) / 4, 5)}, s: {Math.Round(S, 5)}");
            }
        }
        static void Task2_3lvl()
        {
            Console.WriteLine("2 Task:");
            double[,] A = new double[4, 4]
                { { 56, 23, 142, 5 }, { 764, -54, 63, 123 }, { -564, 1435, 92, 4 }, { 90, 78, 5762, -56 } };
            MatrixFindingRows(A, out A);
            Console.WriteLine("Matix:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{A[i, j], 5}");
                }
                Console.WriteLine();
            }
        }

        static void Task6_3lvl()
        {
            Console.WriteLine("6 Task:");
            double[,] A = new double[4, 4]
                { { 56, 23, 5, 142 }, { 764, -54, 63, 123 }, { -564, 1435, 92, 4 }, { 90, 78, 5762, -56 } };
            int j1 = Max(MaxFind1, A);
            int j2 = Max(MaxFind2, A);
            ColumnsSwap(A, j1, j2, out A);
            Console.WriteLine("Matrix:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{A[i, j], 5}");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Task1_1lvl();
            Task2_1lvl();
            Task6_2lvl();
            Task10_2lvl();
            Task23_2lvl();
            Task1_3lvl();
            Task2_3lvl();
            Task6_3lvl();
        }

        static bool TriangleCheck(double a, double b, double c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                if (a + b > c && b + c > a && a + c > b) return true;
                return false;
            }
            else
            {
                return false;
            }
        }
        static void ColumnsSwap(double[,] Matrix1, int j1, int j2, out double[,] Matrix2)
        {
            Matrix2 = new double[Matrix1.GetLength(0), Matrix1.GetLength(1)];
            for (int i = 0; i < Matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix1.GetLength(1); j++)
                {
                    if (j == j1) Matrix2[i, j] = Matrix1[i, j2];
                    else if (j == j2) Matrix2[i, j] = Matrix1[i, j1];
                    else Matrix2[i, j] = Matrix1[i, j];
                }
            }
        }
        delegate int MaxFindMatrix(double[,] x);
        static int MaxFind1(double[,] x)
        {
            double NMax = Double.MinValue;
            int JMax = 0;
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    if (x[i, j] > NMax && i == j)
                    {
                        NMax = x[i, j];
                        JMax = j;
                    }
                }
            }

            return JMax;
        }
        static int MaxFind2(double[,] x)
        {
            double NMax = Double.MinValue;
            int JMax = 0, i = 0;
            for (int j = 0; j < x.GetLength(1); j++)
            {
                if (x[i, j] > NMax)
                {
                    NMax = x[i, j];
                    JMax = j;
                }
            }

            return JMax;
        }
        
        static int Max(MaxFindMatrix f, double[,] x)
        {
            return f(x);
        }
        delegate double TaylorsRow(double i, int t);
        static double TaylorsRow1(double i, int t)
        {
            Fk = Fact(t);
            return Math.Cos(t * i) / Fk;
        }

        static double TaylorsRow2(double i, int t)
        {
            return Math.Pow(-1, t) * Math.Cos(t * i) / (t * t);
        }

        static double ElementsCycle(TaylorsRow f, double x)
        {
            double k = 1, s = 0;
            int i = 1;
            do
            {
                k = f(x, i);
                s += k;
                i++;
            } while (Math.Abs(k) > 0.0001);

            return s;
        }
        delegate double[] SortingRows(double[] x);
        static double[] SortingRowsEven(double[] x)
        {
            Array.Sort(x);
            return x;
        }
        static double[] SortingRowsOdd(double[] x)
        {
            Array.Sort(x);
            Array.Reverse(x);
            return x;
        }
        static double[] DelegateCall(SortingRows f, double[] Array)
        {
            return f(Array);
        }
        static void MatrixFindingRows(double[,] Matrix1, out double[,] Matrix2)
        {
            Matrix2 = new double[Matrix1.GetLength(0), Matrix1.GetLength(1)];
            double[] Array = new double[Matrix1.GetLength(1)];
            for (int i = 0; i < Matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix1.GetLength(1); j++)
                {
                    Array[j] = Matrix1[i, j];
                }
                if (i % 2 == 0)
                {
                    Array = DelegateCall(SortingRowsEven, Array);
                }
                else Array = DelegateCall(SortingRowsOdd, Array);

                for (int t = 0; t < Matrix1.GetLength(1); t++)
                {
                    Matrix2[i, t] = Array[t];
                }
            }
        }
        static void Matrix5Maximums(double[,] Matrix1, out double[,] Matrix2)
        {
            double NMax = Double.MinValue;
            k = 0;
            Matrix2 = new double[Matrix1.GetLength(0), Matrix1.GetLength(1)];
            Queue<Tuple<int, int>> MyQ = new Queue<Tuple<int, int>>(5);
            for (int i = 0; i < Matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix1.GetLength(1); j++)
                {
                    if (Matrix1[i, j] > NMax)
                    {
                        NMax = Matrix1[i, j];
                        if (k < 5) 
                        {
                            MyQ.Enqueue(Tuple.Create(i, j));
                            k++;
                        }
                        else
                        {
                            MyQ.Dequeue();
                            MyQ.Enqueue(Tuple.Create(i, j));
                            k++;
                        }
                    }
                }
            }

            var i1 = MyQ.Peek().Item1;
            var j1 = MyQ.Peek().Item2;
            for (int i = 0; i < Matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix1.GetLength(1); j++)
                {
                    if (i == i1 && j == j1)
                    {
                        Matrix2[i, j] = Matrix1[i, j] * 2;
                        MyQ.Dequeue();
                        if (MyQ.Count != 0)
                        {
                            i1 = MyQ.Peek().Item1;
                            j1 = MyQ.Peek().Item2;
                        }
                    }
                    else Matrix2[i, j] = Matrix1[i, j] / 2;
                }
            }
        }
        static void DelColumn(double[,] Matrix1, int j1, out double[,] Matrix2)
        {
            Matrix2 = new double[Matrix1.GetLength(0), Matrix1.GetLength(1) - 1];
            for (int i = 0; i < Matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix1.GetLength(1) - 1; j++)
                {
                    if (j1 <= j) Matrix2[i, j] = Matrix1[i, j + 1];
                    else Matrix2[i, j] = Matrix1[i, j];
                }
            }
        }
        static void ToArray(string input, int length, out double[] Array)
        {
            string[] array = input.Split(" ");
            Array = new double[length];
            for (int i = 0; i < length; i++) if (double.TryParse(array[i], out Array[i]));
        }
        static void Combinations(double n, double k, double nk, out double C)
        {
            C = 0;
            C = n / (k * nk);
        }
        static double Fact(int z)
        {
            double fz = 1;
            for (int i = 1; i <= z; i++)
            {
                fz *= i;
            }
            return fz;
        }
        static void Square(double a1, double b1, double c1, out double s)
        {
            s = 0;
            double p = (a1 + b1 + c1) / 2;
            s = Math.Sqrt(p * (p - a1) * (p - b1) * (p - c1));
        }
        static void DelElem(int length, double[] Array1, out double[] Array2)
        {
            double NMax = Double.MinValue;
            int IMax = 0;
            Array2 = new double[length - 1];
            for (int i = 0; i < length; i++)
            {
                if (Array1[i] > NMax)
                {
                    NMax = Array1[i];
                    IMax = i;
                }
            }

            for (int i = 0; i < (length - 1); i++)
            {
                if (i < IMax) Array2[i] = Array1[i];
                else Array2[i] = Array1[i + 1];
            }
        }
    }
}
