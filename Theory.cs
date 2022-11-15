using System;
namespace _5th_Lab
{
    class Programm
    {
        #region 5.1.1

        static int Fact(int a)
        {
            int i;
            int fact_a = 1;
            for (i = 1; i <= a; i++)
            {
                fact_a = fact_a * i;
            }
            return fact_a;
        }
        static double Cab(int a, int b)
        {
            return Fact(a) / (Fact(b) * Fact(a - b) * 1.0);
        }

        #endregion

        #region 5.1.2

        static double Striangle(double a, double b, double c)
        {
            double p = (a + b + c) / (2 * 1.0);
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        #endregion

        #region 5.2.6

        static void delmax(double[] a, int len_a)
        {
            double amax = a[0];
            int imax = 0;
            for (int i = 0; i < len_a; i++)
            {
                if (a[i] > amax)
                {
                    amax = a[i];
                    imax = i;
                }
            }
            for (int i = imax; i < len_a - 1; i++)
            {
                a[i] = a[i + 1];
            }
        }

        #endregion

        #region 5.2.10

        static void Delvert(double[,] a, int n, int j)
        {
            for (int k = j; k < n - 1; k++)
            {
                for (int i = 0; i < Math.Sqrt(a.Length); i++)
                {
                    a[i, k] = a[i, k + 1];
                }
            }

        }

        #endregion

        #region 5.2.23

        static void Transformmatrix(double[,] a, int n)
        {
            const int h = 5;
            int count = 0;
            bool l = false;
            double[] b = new double[n * n];
            double[] c = new double[n * n];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    b[k] = a[i, j];
                    c[k] = a[i, j];
                    k++;
                }
            }
            Array.Sort(b);
            Array.Reverse(b);
            for (int i = 0; i < c.Length; i++)
            {
                l = false;
                for (int j = 0; j < h; j++)
                {
                    if (c[i] == b[j])
                    {
                        l = !l;
                        b[j] = b[0] + 1;
                        break;
                    }
                }
                if (l && count<=5)
                {
                    if (c[i] > 0)
                    {
                        c[i] = c[i] * 2;
                    }
                    else
                    {
                        c[i] = c[i] / 2.0;
                    }
                }
                else
                {
                    if (c[i] > 0)
                    {
                        c[i] = c[i] / 2.0;
                    }
                    else
                    {
                        c[i] = c[i] * 2;
                    }
                }
            }
            k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = c[k];
                    k++;
                }
            }
        }

        #endregion

        #region 5.3.1

        static int factorial(int i)
        {
            int a = 1;
            for (int j = 1; j <= i; j++)
            {
                a = a * j;
            }
            return a;
        }
        delegate double fx(double x, int i);
        static double f1(double x, int i)
        {
            double chs1;
            return chs1 = Math.Cos(i * x) / factorial(i);
        }
        static double f2(double x, int i)
        {
            double chs2;
            return chs2 = Math.Pow(-1, i) * Math.Cos(i * x) / i * i;
        }
        static double Sum(fx f, double a, double b, double h)
        {
            double s = 0;
            int i = 1;
            for (double x = a; x <= b; x = x + h)
            {
                s = s + f(x, i);
                i++;
            }
            return s;
        }

        #endregion

        #region 5.3.3

        static double average(double[] a)
        {
            double av = 0;
            for (int i = 0; i < a.Length; i++)
            {
                av = av + a[i] / a.Length;
            }
            return av;
        }
        delegate void Switch(double[] a);
        static void sw1(double[] a)
        {
            double p;
            for (int i = 0; i < a.Length - 1; i = i + 2)
            {
                p = a[i];
                a[i] = a[i + 1];
                a[i + 1] = p;
            }
        }
        static void sw2(double[] a)
        {
            double p;
            for (int i = a.Length - 1; i > 0; i = i - 2)
            {
                p = a[i];
                a[i] = a[i - 1];
                a[i - 1] = p;
            }
        }
        static double sum(Switch sw, double[] a)
        {
            double S = 0;
            sw(a);
            for (int i = 1; i < a.Length; i = i + 2)
            {
                S = S + a[i];
            }
            return S;
        }

        #endregion

        #region Main
        static void Main(string[] args)
        {
            #region 5.1.1 Main

            int n1 = 8, n2 = 10, n3 = 11, k = 5;
            Console.WriteLine($"variaties for a team of {k} ");
            Console.WriteLine($"from {n1} people - {Cab(n1, k)}");
            Console.WriteLine($"from {n2} people - {Cab(n2, k)}");
            Console.WriteLine($"from {n3} people - {Cab(n3, k)}");
            Console.WriteLine();

            #endregion

            #region 5.1.2 Main

            double S1, S2, Smax;
            double[] A_A = new double[3];
            double[] B_B = new double[3];
            Console.WriteLine("enter a, b, c for the first triangle:");
            for (int i= 0;i< 3; i++)
            {
                double.TryParse(Console.ReadLine(), out A_A[i]);
                while (A_A[i] <= 0)
                {
                    Console.WriteLine("sides must be positive! try another side");
                    double.TryParse(Console.ReadLine(), out A_A[i]);
                }
            }
            Array.Sort(A_A);
            while (A_A[2] >= A_A[0] + A_A[1] || A_A[0]<= A_A[2] - A_A[1])
            {
                Console.WriteLine("impossible triangle! try other a, b and c");
                for (int i = 0; i < 3; i++)
                {
                    double.TryParse(Console.ReadLine(), out A_A[i]);
                    while (A_A[i] <= 0)
                    {
                        Console.WriteLine("sides must be positive! try another side");
                        double.TryParse(Console.ReadLine(), out A_A[i]);
                    }
                }
                Array.Sort(A_A);
            }
            Console.WriteLine("enter a, b, c for the second triangle");
            for (int i = 0; i < 3; i++)
            {
                double.TryParse(Console.ReadLine(), out B_B[i]);
                while (B_B[i] <= 0)
                {
                    Console.WriteLine("sides must be positive! try another side");
                    double.TryParse(Console.ReadLine(), out B_B[i]);
                }
            }
            Array.Sort(B_B);
            while (B_B[2] >= B_B[0] + B_B[1] || B_B[0] <= B_B[2] - B_B[1])
            {
                Console.WriteLine("impossible triangle! try other a, b and c");
                for (int i = 0; i < 3; i++)
                {
                    double.TryParse(Console.ReadLine(), out B_B[i]);
                    while (B_B[i] <= 0)
                    {
                        Console.WriteLine("sides must be positive! try another side");
                        double.TryParse(Console.ReadLine(), out B_B[i]);
                    }
                }
                Array.Sort(B_B);
            }
            S1 = Striangle(A_A[0], A_A[1], A_A[2]);
            Console.WriteLine($"area 1: {S1}");
            S2 = Striangle(B_B[0], B_B[1], B_B[2]);
            Console.WriteLine($"area 2: {S2}");
            Smax = 1;
            if (S2 > S1)
            {
                Smax = 2;
            }
            if (S2 != S1)
            {
                Console.WriteLine($"the triangle with larger area is triangle {Smax}");
            }
            else
            {
                Console.WriteLine("there is no larger area");
            }
            Console.WriteLine();

            #endregion

            #region 5.2.6 Main

            const int a_q = 7, b_q = 8;
            int j_q = 0;
            double[] A = new double[a_q + b_q - 2];
            double[] B = new double[b_q];
            Console.WriteLine($"enter {a_q} elements for array A");
            for (int i = 0; i < a_q; i++)
            {
                double.TryParse(Console.ReadLine(), out A[i]);
            }
            Console.WriteLine($"enter {b_q} elements for array B");
            for (int i = 0; i < b_q; i++)
            {
                double.TryParse(Console.ReadLine(), out B[i]);
            }
            Console.WriteLine("array A:");
            for (int i = 0; i < a_q; i++)
            {
                Console.Write($"{A[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine("array B:");
            for (int i = 0; i < b_q; i++)
            {
                Console.Write($"{B[i]} ");
            }
            Console.WriteLine();
            delmax(A, a_q);
            delmax(B, b_q);
            for (int i = a_q - 1; i < A.Length; i++)
            {
                A[i] = B[j_q];
                j_q++;
            }
            Console.WriteLine("new array:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"{A[i]} ");
            }
            Console.WriteLine();

            #endregion

            #region 5.2.10 Main

            const int n_w = 4;
            double[,] AA = new double[n_w, n_w] { { 1, 3, 4, 4 },
                                                  { 5, 6, 7, 8 },
                                                  { 4, 8, 7, 9 },
                                                  { 2, 5, 4, 7 } };
            Console.WriteLine("matrix A:");
            for (int i = 0; i < n_w; i++)
            {
                for (int j = 0; j < n_w; j++)
                {
                    Console.Write($"{AA[i, j]} ");
                }
                Console.WriteLine();
            }
            double min_w = AA[0, 1], max_w = AA[1, 0];
            int jmin = 1, jmax = 0, k_w = 1; ;
            for (int i = 0; i < n_w; i++)
            {
                for (int j = 0; j < n_w; j++)
                {
                    if (j > i && AA[i, j] < min_w)
                    {
                        min_w = AA[i, j];
                        jmin = j;
                    }
                    if (j <= i && AA[i, j] > max_w)
                    {
                        max_w = AA[i, j];
                        jmax = j;
                    }
                }
            }
            Delvert(AA, n_w, jmin);
            if (jmax != jmin)
            {
                Delvert(AA, n_w - 1, jmax);
                k_w = 2;
            }
            Console.WriteLine("new matrix:");
            for (int i = 0; i < n_w; i++)
            {
                for (int j = 0; j < n_w - k_w; j++)
                {
                    Console.Write($"{AA[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            #endregion

            #region 5.2.23 Main

            const int n_e = 3;
            double[,] AAA = new double[n_e, n_e] { { -1, -1, 2 },
                                                   { -1, -4, 8 },
                                                   { -7, -2, 9 } };

            double[,] BBB = new double[n_e, n_e] { { 6, 5, 3 },
                                                   { 2, 3, 3 },
                                                   { 1, 3, 4 } };
            Console.WriteLine("matrix AAA:");
            for (int i = 0; i < n_e; i++)
            {
                for (int j = 0; j < n_e; j++)
                {
                    Console.Write($"{AAA[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("matrix BBB:");
            for (int i = 0; i < n_e; i++)
            {
                for (int j = 0; j < n_e; j++)
                {
                    Console.Write($"{BBB[i, j]} ");
                }
                Console.WriteLine();
            }
            Transformmatrix(AAA, n_e);
            Transformmatrix(BBB, n_e);
            Console.WriteLine("new matrix AAA:");
            for (int i = 0; i < n_e; i++)
            {
                for (int j = 0; j < n_e; j++)
                {
                    Console.Write($"{AAA[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("new matrix BBB:");
            for (int i = 0; i < n_e; i++)
            {
                for (int j = 0; j < n_e; j++)
                {
                    Console.Write($"{BBB[i, j]} ");
                }
                Console.WriteLine();
            }

            #endregion

            #region 5.3.1 Main

            const double pi = Math.PI;
            double aa1 = 0.1, bb1 = 1, hh1 = 0.1, aa2 = pi / 5, bb2 = pi, hh2 = pi / 25;
            Console.WriteLine("Summ 1: ");
            Console.WriteLine($"{1 + Sum(f1, aa1, bb1, hh1)}");
            Console.WriteLine("Summ 2: ");
            Console.WriteLine($"{Sum(f2, aa2, bb2, hh2)}");
            #endregion

            #region 5.3.3 Main

            const int n_r = 9;
            double[] F = new double[n_r] { 10, 5, 8, 9, 7, 6, 2, 3, 4 };
            Console.WriteLine("array F:");
            for (int i = 0; i < n_r; i++)
            {
                Console.Write($"{F[i]} ");
            }
            Console.WriteLine();
            double l_r, sw_r = 0;
            l_r = average(F);
            Console.WriteLine($"average = {l_r}");
            if (F[0] > l_r)
            {
                sw_r = sum(sw1, F);
            }
            else
            {
                sw_r = sum(sw2, F);
            }
            Console.WriteLine("new array:");
            for (int i = 0; i < n_r; i++)
            {
                Console.Write($"{F[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine($"the sum = {sw_r}");

            #endregion

        }

        #endregion
    }
}
