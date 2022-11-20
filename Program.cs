using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string ERROR = "Input incorrect!";

            #region Task_1_1
            Console.WriteLine("Task 1.1");
            int k = 5, n = 11;
            if (k <= 0 || n <= 0)
            {
                Console.WriteLine(ERROR);
                return;
            }
            int c = fact(n) / (fact(k) * fact(n - k));
            Console.WriteLine(c+"\n");
        #endregion

            #region Task_1_2
            Console.WriteLine("Task 1.2");
            double a = 1, b = 1, cc =1; 
            if (a<=0 || b<=0 || cc<=0 || (a >= b + cc) || (b >= a + cc) || (c >= a + cc))
            {
                Console.WriteLine(ERROR);
                return;
            }
            Console.WriteLine(geron(a, b, cc) + "\n");
        #endregion

            #region Task_2_6
            Console.WriteLine("Task 2.6");
            Random random = new Random();
            n = 7;
            int m = 8;
            int[] A = new int[n];
            int[] B = new int[m];
            int[] C = new int[n + m - 2];
            for (int i = 0; i < A.Length; i++)
                A[i] = random.Next(20);
            for (int i = 0; i < m; i++)
                B[i] = random.Next(20);
            int iA = ArM(A);
            int iB = ArM(B);
            C = MixAr(DArM(A, iA), DArM(B, iB));
            for (int i = 0; i < C.Length; i++)
                Console.Write(C[i] + "\t");
            Console.WriteLine();
        #endregion

            #region Task_2_10
            Console.WriteLine("Task 2.10");
            random = new Random();
            n = 4;
            int[,] M = new int[n, n];
            for (int i = 0; i<n; i++)
            {
                for (int j = 0; j<n; j++)
                {
                    M[i, j] = random.Next(500);
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int MaxjM = 0, MinjM = 0, count = 0;
            MatMax(M, out MaxjM);   MatMin(M, out MinjM);

            if (MaxjM == MinjM)
            {
                DellMinAndMax(M, MinjM); count += 1;
            }
            else if (MinjM > MaxjM)
            {
                DellMinAndMax(M, MaxjM); DellMinAndMax(M, MinjM - 1); count += 2; ;
            }
            else
            {
                DellMinAndMax(M, MinjM); DellMinAndMax(M, MaxjM - 1); count += 2;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - count; j++)
                {
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        #endregion

            #region Task_2_23
            Console.WriteLine("Task 2.23");
            random = new Random();
            n = 4; m = 3;
            M = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    M[i, j] = random.Next(-10, 10);
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            random = new Random();
            int nn = 5, mm = 3;
            int[,] N = new int[nn, mm];
            for (int i = 0; i < nn; i++)
            {
                for (int j = 0; j < mm; j++)
                {
                    N[i, j] = random.Next(-10 , 10);
                    Console.Write(N[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            FM(M); FM(N);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < nn; i++)
            {
                for (int j = 0; j < mm; j++)
                {
                    Console.Write(N[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        #endregion

            #region Task_3_2
            Console.WriteLine("Task 3.2");
            random = new Random();
            n = 4; m = 3;
            M = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    M[i, j] = random.Next(50);
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    action(M, Row2, i);
                }
                else
                {
                    action(M, Row1, i);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        #endregion

            #region Task_3_6
            Console.WriteLine("Task 3.6");
            random = new Random();
            n = 4;
            M = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    M[i, j] = random.Next(50);
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Changing(M, MD, S);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            #endregion
        }

        static int fact(int n)
        {
            int m = 1;
            for (int i = 2; i <= n; i++)
            {
                m *= i;
            }
            return m;
        }
        static double geron(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double S = p * (p - a) * (p - b) * (p - c);
            return Math.Sqrt(S);
        }
        static int ArM(int[] a)
        {
            int amax = 0;
            int imax = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > amax)
                {
                    amax = a[i];
                    imax = i;
                }
            }
            return imax;
        }
        static int[] DArM(int[] a, int ia)
        {
            int[] aa = new int[a.Length - 1];
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (i == ia)
                {
                    continue;
                }
                aa[count] = a[i];
                count++;
            }
            return aa;
        }
        static int[] MixAr(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                c[i] = a[i];
            }
            for (int i = 0; i < b.Length; i++)
            {
                c[i + a.Length] = b[i];
            }
            return c;
        }
        static void MatMax(int[,] a, out int ja)
        {
            int max = int.MinValue;
            ja = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    if ((i == j || i > j) && (a[i,j] > max))
                    {
                        max = a[i, j];
                        ja = j;
                    }
                }
            }
        }
        static void MatMin(int[,] a, out int ja)
        {
            int min = int.MaxValue;
            ja = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (j > i && (a[i, j] < min))
                    {
                        min = a[i, j];
                        ja = j;
                    }
                }
            }
        }
        static int[,] DellMinAndMax(int[,] a, int k)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            m -= 1;
            for (int i = 0; i < n; i++)
                for (int j = k; j < m; j++)
                    a[i, j] = a[i, j + 1];
            return a;
        }
        static void FM(int[,] a)
        {
            int[] ans = new int[a.GetLength(0) * a.GetLength(1)];
            int k = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    ans[k] = a[i, j];
                    k++;
                }
            }
            for (int i = 0; i < ans.Length; i++)
            {
                for (int j = 0; j < ans.Length - 1; j++)
                {
                    if (ans[j] < ans[j + 1])
                    {
                        int p = ans[j]; ans[j] = ans[j + 1]; ans[j + 1] = p;
                    }
                }
            }
            int count = 0;
            if (ans.Length > 5)
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if ((a[i, j] == ans[0] || a[i, j] == ans[1] || a[i, j] == ans[2] || a[i, j] == ans[3] || a[i, j] == ans[4]) && (count < 5))
                        {
                            a[i, j] *= 2;
                            count++;
                        }
                        else
                        {
                            a[i, j] /= 2;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        a[i, j] *= 2;
                    }
                }
            }
        }
        static void MatToAr(int[,] a, int i, out int[] A)
        {
            A = new int[a.GetLength(1)];
            for (int j = 0; j < a.GetLength(1); j++)
            {
                A[j] = a[i, j];
            }
        }

        delegate void Rows(int[] arr);
        static void Row1(int[] arr)
        {
            Array.Sort(arr);
            Array.Reverse(arr);
        }
        static void Row2(int[] arr)
        {
            Array.Sort(arr);
        }

        static void action(int[,] a, Rows Row, int i)
        {
            MatToAr(a, i, out int[] A);
            Row(A);
            int[] AA = A;
            for (int j = 0; j < AA.Length; j++)
            {
                a[i, j] = AA[j];
            }
        }

        delegate int MaxElement(int[,] a);
        static int MD(int[,] a)
        {
            int aMax = 0, jMax = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (a[i, i] > aMax)
                {
                    aMax = a[i, i];
                    jMax = i;
                }
            }
            return jMax;
        }
        static int S(int[,] a)
        {
            int i = 0, aMax = 0, jMax = 0;
            for (int j = 0; j < a.GetLength(1); j++)
            {
                if (a[i, j] > aMax)
                {
                    aMax = a[i, j];
                    jMax = j;
                }
            }
            return jMax;
        }

        static void Changing(int[,] a, MaxElement MD, MaxElement S)
        {
            int ii = MD(a), jj = S(a);
            if (ii == jj)
            {
                Console.WriteLine("No changes because max elements on the same row");
            }
            else
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    int p = a[i, ii]; a[i, ii] = a[i, jj]; a[i, jj] = p;
                }
            }
        }
    }
}
