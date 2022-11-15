using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForLab5
{
    internal class Program
    {
        #region Task1.1
        static int Fact(int a)
        {
            int fk = 1;
            for (int i = 1; i <= a; i++)
            {
                fk *= i;
            }
            return fk;
        }
        static int Combination(int n, int k)
        {
            return Fact(n) / (Fact(k) * Fact(n - k));
        }
        static void Task1_1()
        {
            Console.WriteLine("TASK#1_1");
            int n, k = 5;
            Console.WriteLine("Введите кол-во кандидатов");
            int.TryParse(Console.ReadLine(), out n);
            int C = Combination(n, k);
            Console.WriteLine("Кол-во способов {0:d}", C);
        }
        #endregion

        #region Task1.2
        static double FormGeron(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        static bool Check(double a, double b, double c)
        {
            if ((a < b + c || b < a + c || c < a + b) && (a > 0 && b > 0 && c > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Task1_2()
        {
            Console.WriteLine("TASK#1_2");
            Console.WriteLine("Введите стороны треугольника");
            double.TryParse(Console.ReadLine(), out double a);
            double.TryParse(Console.ReadLine(), out double b);
            double.TryParse(Console.ReadLine(), out double c);
            if (Check(a, b, c))
            {
                double S = FormGeron(a, b, c);
                Console.WriteLine("Площадь треугольника: {0:f1}", S);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        #endregion

        #region Task2.6
        static int MaxElem(int[] ans)
        {
            int ansMax = 0;
            int iMax = 0;
            for (int i = 0; i < ans.Length; i++)
            {
                if (ans[i] > ansMax)
                {
                    ansMax = ans[i];
                    iMax = i;
                }
            }
            return iMax;
        }
        static int[] DelMaxElement(int[] arr, int ind)
        {
            int[] ans = new int[arr.Length - 1];
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == ind)
                {
                    continue;
                }
                ans[count] = arr[i];
                count++;
            }
            return ans;
        }
        static int[] MixArrays(int[] a, int[] b)
        {
            int[] ans = new int[a.Length + b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                ans[i] = a[i];
            }
            for (int i = 0; i < b.Length; i++)
            {
                ans[i + a.Length] = b[i];
            }
            return ans;
        }
        static void Task2_6()
        {
            Console.WriteLine("TASK#2_6");
            Random random = new Random();
            int n = 7, m = 8;
            int[] A = new int[n];
            int[] B = new int[m];
            int[] C = new int[n + m - 2];
            for (int i = 0; i < A.Length; i++)
                A[i] = random.Next(50);
            for (int i = 0; i < m; i++)
                B[i] = random.Next(50);
            int indA = MaxElem(A);
            int indB = MaxElem(B);
            C = MixArrays(DelMaxElement(A, indA), DelMaxElement(B, indB));
            for (int i = 0; i < C.Length; i++)
                Console.Write(C[i] + "\t");
            Console.WriteLine();
        }
        #endregion

        #region Task2.10
        static int[,] DellMinAndMax(int[,] a, int ind)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            m -= 1;
            for (int i = 0; i < n; i++)
                for (int j = ind; j < m; j++)
                    a[i, j] = a[i, j + 1];
            return a;
        }
        static void Task2_10()
        {
            Console.WriteLine("TASK#2_10");
            Random random = new Random();
            Console.WriteLine("Введите размер квадратичной матрицы");
            int.TryParse(Console.ReadLine(), out int n);
            int[,] array = new int[n, n]; int count = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    array[i, j] = random.Next(50);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            int aMax = array[1, 0], aMin = array[0, 1];
            int jMax = 0, jMin = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (aMax < array[i, j] && ((i > j) || (i == j)))
                    {
                        aMax = array[i, j];
                        jMax = j;
                    }
                    if (aMin > array[i, j] && (i < j))
                    {
                        aMin = array[i, j];
                        jMin = j;
                    }
                }
            }

            Console.WriteLine("{0:d} {1:d}", aMin, aMax);
            if (jMax == jMin)
            {
                DellMinAndMax(array, jMin); count += 1;
            }
            else if (jMin > jMax)
            {
                DellMinAndMax(array, jMax); DellMinAndMax(array, jMin - 1); count += 2; ;
            }
            else
            {
                DellMinAndMax(array, jMin); DellMinAndMax(array, jMax - 1); count += 2;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - count; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Task2.23
        static void FixdMatrix(int[,] a)
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

        static void Task2_23()
        {
            Console.WriteLine("TASK#2_23");
            Random random = new Random();
            Console.WriteLine("Введите размер матрицы n, m");
            int.TryParse(Console.ReadLine(), out int n);
            int.TryParse(Console.ReadLine(), out int m);
            int[,] arr = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    arr[i, j] = random.Next(-10, 10);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            FixdMatrix(arr);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Task3.2
        static void MatrixToArray(int[,] a, int ii, out int[] arr)
        {
            arr = new int[a.GetLength(1)];
            for (int j = 0; j < a.GetLength(1); j++)
            {
                arr[j] = a[ii, j];
            }
        }
        delegate void Rows(int[] arr);
        static void RowOdd(int[] arr)
        {
            Array.Sort(arr);
            Array.Reverse(arr);
        }
        static void RowEven(int[] arr)
        {
            Array.Sort(arr);
        }
        static void splice(int[,] a, Rows Row, int ii)
        {
            MatrixToArray(a, ii, out int[] arr);
            Row(arr);
            int[] arr1 = arr;
            for (int i = 0; i < arr1.Length; i++)
            {
                a[ii, i] = arr1[i];
            }
        }
        static void Task3_2()
        {
            Console.WriteLine("TASK#3_2");
            Random random = new Random();
            Console.WriteLine("Введите размер массива n, m");
            int.TryParse(Console.ReadLine(), out int n);
            int.TryParse(Console.ReadLine(), out int m);
            int[,] A = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    A[i, j] = random.Next(50);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(A[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    splice(A, RowEven, i);
                }
                else
                {
                    splice(A, RowOdd, i);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(A[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Task3_6
        delegate int MaxElement(int[,] a);
        static int GlavDiag(int[,] a)
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
        static int Diag(int[,] a)
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
        static void Fisting(int[,] a, MaxElement f1, MaxElement f2)
        {
            int ii = f1(a), jj = f2(a);
            if (ii == jj)
            {
                Console.WriteLine("Матрица не изменилась");
            }
            else
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    int p = a[i, ii]; a[i, ii] = a[i, jj]; a[i, jj] = p;
                }
            }
        }
        static void Task3_6()
        {
            Console.WriteLine("TASK#3_6");
            Random random = new Random();
            Console.WriteLine("Введите размер матрицы n");
            int.TryParse(Console.ReadLine(), out int n);
            int[,] B = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    B[i, j] = random.Next(50);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Fisting(B, GlavDiag, Diag);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        #endregion

        static void Main()
        {
            #region Task1_1
            Task1_1();
            #endregion
            #region Task1_2
            Task1_2();
            #endregion
            #region Task2_6
            Task2_6();
            #endregion
            #region Task2_10
            Task2_10();
            #endregion
            #region Task2_23
            Task2_23();
            #endregion
            #region Task3_2
            Task3_2();
            #endregion
            #region Task3_6
            Task3_6();
            #endregion
        }
    }
}
