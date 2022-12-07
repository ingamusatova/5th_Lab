using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

namespace LABA_5_1
{
    internal class Program
    {
        static int VarCount(int n, int k)
        {

            return Fact(n) / (Fact(k) * Fact(n - k));



        }

        static int Fact(int f)
        {
            int a = 1;
            for (int i = 2; i <= f; i++)
            {
                a = a * i;
            }
            return a;
        }
        static void lvl1_1()
        {
            int n = 8, k = 5;
            Console.WriteLine("Количество вариантов для 5 человек из 8 = " + VarCount(n, k));
            int n1 = 11, k1 = 10;
            Console.WriteLine("Количество вариантов для 10 человек из 11 = " + VarCount(n1, k1));
        }
        static double Square(double a, double b, double c)
        {

            double p = (a + b + c) / 2;
            if (c > p || a > p || b > p)
            {
                Console.WriteLine("Это не треугольник");
                return 0;
            }

            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return s;
        }
        static void lvl1_2()
        {
            int a = 5, b = 5, c = 7;
            double q = Square(a, b, c);
            Console.WriteLine("Площадь первого треугольника  = " + q);
            int a1 = 6, b1 = 6, c1 = 11;
            double q2 = Square(a1, b1, c1);
            Console.WriteLine("Площадь второго треугольника  = " + q2);
            if (q > q2)
            {
                Console.WriteLine("Площадь первого треугольника больше");

            }
            else
            {
                Console.WriteLine("Площадь второго треугольника больше");
            }
        }
        static int[] DeleteMax(int[] arr)
        {
            int max = int.MinValue;
            int imax = 0;
            int[] a = new int[arr.Length - 1];
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    imax = i;
                }
            }
            n--;
            for (int i = 0; i < imax; i++)
            {
                a[i] = arr[i];
            }
            for (int i = imax; i < n; i++)
            {
                a[i] = arr[i + 1];
            }
            return a;
        }
        static void lvl2_6()
        {
            int[] a = new int[7] { 1, 2, 3, 10, 5, 6, 7 };
            int[] b = new int[8] { 4, 5, 6, 2, 3, 8, 9, 0 };
            Console.WriteLine("Первый массив без максимального ");
            a = DeleteMax(a);
            foreach (int u in a)
            {
                Console.Write(u + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Второй массив без максимального ");
            b = DeleteMax(b);
            foreach (int u in b)
            {
                Console.Write(u + " ");
            }
            Console.WriteLine();
            int[] c = new int[a.Length + b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                c[i] = a[i];
            }
            int bi = 0;
            for (int i = a.Length; i < a.Length + b.Length; i++)
            {
                c[i] = b[bi];
                bi++;
            }
            Console.WriteLine("Объединенный массив");
            foreach (int u in c)
            {
                Console.Write(u);
            }
        }
        static void PrintMatrix(int[,] arr)
        {

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        delegate int FindColumnToDelete(int[,] arr);
        static int FindMaxUpper(int[,] arr)
        {
            int min = int.MaxValue;//ищу минимальный выше главной диагонали
            int imin = 0;
            for (int i = arr.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = arr.GetLength(0) - 1; j > i; j--)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        imin = j;
                    }
                }
            }
            return imin;
        }
        static int[,] DeleteColumns2(int[,] arr, FindColumnToDelete f1, FindColumnToDelete f2)
        {
            int imax = f1(arr);

            int imin = f2(arr);


            if (imax < imin)
            {
                int[,] a = new int[arr.GetLength(0), arr.GetLength(1) - 2];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < imax; j++)
                    {
                        a[i, j] = arr[i, j];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imin; j < arr.GetLength(1) - 1; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imax; j < arr.GetLength(1) - 2; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }
                return a;
            }

            if (imax > imin)
            {
                int[,] a = new int[arr.GetLength(0), arr.GetLength(1) - 2];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < imin; j++)
                    {
                        a[i, j] = arr[i, j];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imax; j < arr.GetLength(1) - 1; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imin; j < arr.GetLength(1) - 2; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }
                return a;
            }

            {
                int[,] a = new int[arr.GetLength(0), arr.GetLength(1) - 1];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < imin; j++)
                    {
                        a[i, j] = arr[i, j];
                    }
                }
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imin; j < arr.GetLength(1) - 1; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }
                return a;
            }

        }
        static int[,] DeleteColumns(int[,] arr)
        {
            int max = int.MinValue;//ищу максимальный ниже главной диагонали(включая ее)
            int imax = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        imax = j;
                    }
                }
            }

            int min = int.MaxValue;//ищу минимальный выше главной диагонали
            int imin = 0;
            for (int i = arr.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = arr.GetLength(0) - 1; j > i; j--)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        imin = j;
                    }
                }
            }

            if (imax < imin)
            {
                int[,] a = new int[arr.GetLength(0), arr.GetLength(1) - 2];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < imax; j++)
                    {
                        a[i, j] = arr[i, j];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imin; j < arr.GetLength(1) - 1; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imax; j < arr.GetLength(1) - 2; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }
                return a;
            }

            if (imax > imin)
            {
                int[,] a = new int[arr.GetLength(0), arr.GetLength(1) - 2];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < imin; j++)
                    {
                        a[i, j] = arr[i, j];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imax; j < arr.GetLength(1) - 1; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imin; j < arr.GetLength(1) - 2; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }
                return a;
            }

            {
                int[,] a = new int[arr.GetLength(0), arr.GetLength(1) - 1];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < imin; j++)
                    {
                        a[i, j] = arr[i, j];
                    }
                }
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imin; j < arr.GetLength(1) - 1; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }
                return a;
            }


        }
        static void lvl2_10()
        {
            int[,] a = new int[3, 3] { { 1, 90, 15 }, { 2, 30, 4 }, { 4, 6, 90 } };
            PrintMatrix(a);
            a = DeleteColumns(a);
            Console.WriteLine("Новая матрица");
            PrintMatrix(a);
        }
        static int FindMax(int a, int[,] arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] > max && arr[i, j] < a)
                        {
                            max = arr[i, j];
                        }
                    }
                }
            }
            return max;
        }
        static void DoubleMax(int[,] arr)
        {

            int f = int.MaxValue;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(f = FindMax(f, arr));
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] >= f)
                    {
                        arr[i, j] *= 2;
                    }
                    else
                    {
                        arr[i, j] /= 2;
                    }
                }
            }
        }
        static int FindMaxLower(int[,] arr)
        {
            int max = int.MinValue;//ищу максимальный ниже главной диагонали(включая ее)
            int imax = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        imax = j;
                    }
                }
            }
            return imax;
        }
        static void lvl2_23()
        {
            int[,] a = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9, } };
            PrintMatrix(a);
            Console.WriteLine();
            DoubleMax(a);
            Console.WriteLine();
            PrintMatrix(a);
            Console.WriteLine();
            int[,] b = new int[4, 4] { { 1, 2, 3, 5 }, { 4, 5, 6, 8 }, { 12, 34, 12, 0 }, { 13, 22, 54, -1 } };
            PrintMatrix(b);
            Console.WriteLine();
            DoubleMax(b);
            Console.WriteLine();
            PrintMatrix(b);
        }
        static void lvl3_7_10()
        {
            int[,] a = new int[3, 3] { { 1, 90, 15 }, { 2, 31, 4 }, { 4, 6, 9 } };
            PrintMatrix(a);
            a = DeleteColumns2(a, FindMaxUpper, FindMaxLower);
            Console.WriteLine("Новая матрица");
            PrintMatrix(a);

        }
        delegate void ProccessRow(int[,] a, int i);
        static void SortRowUp(int[,]arr,int i)
        {
            
                for (int t = 0; t < arr.GetLength(1); t++)
                {
                    for (int j = t; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, t] > arr[i, j])
                        {
                            int temp = arr[i, t];
                            arr[i, t] = arr[i, j];
                            arr[i, j] = temp;
                        }
                    }
                }
            
        }

        static void SortRowDown(int[,]arr, int i)
        {
           
                for (int t = 0; t < arr.GetLength(1); t++)
                {
                    for (int j = t; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, t] < arr[i, j])
                        {
                            int temp = arr[i, t];
                            arr[i, t] = arr[i, j];
                            arr[i, j] = temp;
                        }
                    }
                }
            
        }
        static void SortMatrix(int[,] arr, ProccessRow f1, ProccessRow f2)
        {

            for (int i = 0; i < arr.GetLength(0); i+=2)
            {
               f1(arr,i);
            }

            for (int i = 1; i < arr.GetLength(0); i += 2)
            {
               f2(arr, i);
            }
        }
        static void lvl3_2()
        {
            int[,] a = new int[4, 4] { { 4, 3, 2, 1 }, { 4, 1, 10, 7 }, { 100, 9, 10, 11 }, { 12, 81, 1, 5 } };
            PrintMatrix(a);
            SortMatrix(a,SortRowUp, SortRowDown);
            Console.WriteLine("Новая матрица");
            PrintMatrix(a);
        }
        static  List <int> MakeListUp(int[,] arr)
        {
            List<int> a = new List<int>();
            for (int i = arr.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = arr.GetLength(0) - 1; j >= i; j--)
                {
                    a.Add(arr[i, j]);
                }
            }
            return a;
        }
        static List<int> MakeListDown(int[,] arr)
        {
            List<int> a = new List<int>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    a.Add(arr[i, j]);
                }
            }
            return a;
        }
        delegate List<int> MakeListFromMatrix(int[,] arr);
        static int SummMatrix(int[,] arr, MakeListFromMatrix f1)
        {

            List<int> a = f1(arr);
            
            int sum = 0;
            foreach (int i in a)
            {
                 sum+=i*i ;
            }
            return sum;
        }

        static void lvl3_4()
        {
            int[,] a = new int[3, 3] { { 4, 3, 2 }, { 4, 1, 10 }, { 1, 9, 10},  };
            PrintMatrix(a);
            Console.WriteLine(SummMatrix(a,MakeListDown));
        }

            static void Main(string[] args)
            {
            // lvl1_1();


            //lvl1_2();

            // lvl2_6();


            //   lvl2_10();


            //   lvl2_23();

            //  lvl3_7_10();


            //lvl3_2();

         //   lvl3_4();

            }
        }
    }
