using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Transactions;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
namespace lab4q
{
    class program
    {
        static int Factorial(int a1)
        {
            int s = 1;
            for (int i = 2; i <= a1; i++)
            {
                s = s * i;
            }
            return s;
        }
        static double Geron(double a, double b, double c)
        {
            double p;
            p = (a + b + c) / 2;
            return p;
        }
        static void Delete(double[] x,int k)
        {
            for (int i=k ;i<x.Length-1;i++)
            {
                x[i] = x[i+1];
            }
        }
        static void DeleteColomn(double[,] x,int k, out double[,] x1)
        {
            x1 = new double[x.GetLength(0), x.GetLength(1)-1];
            for (int i=0; i<x.GetLength(0); i++)
            {
                for (int j=0; j<x.GetLength(1)-1;j++)
                {
                    if (k <= j) x1[i, j] = x[i, j + 1];
                    else x1[i, j] = x[i, j];
                }
            }
        }
        static void Maximum5(double[,] x1, out double[,] x2)
        {
           List<double> list = new List<double>(5);
            x2=new double[x1.GetLength(0), x1.GetLength(1)];
            double[] maxi = new double[x1.GetLength(0) * x1.GetLength(1)];
            int count = 0;
            for (int i=0; i<x1.GetLength(0); i++)
            {
                for(int j=0; j<x1.GetLength(1); j++)
                {
                    maxi[count] = x1[i, j];
                    count++;
                }
            }
            Array.Sort(maxi);
            Array.Reverse(maxi);
            int l = 0;
            for(int i=0; i<5; i++)
            {
                list.Add(maxi[i]);
            }
            for(int i=0;i<x1.GetLength(0);i++)
            {
                for(int j=0;j<x1.GetLength(1);j++)
                {
                    if (list.Contains(x1[i, j]))
                    {
                        if (x1[i, j] < 0)
                        {
                            x2[i, j] = x1[i, j] / 2;
                            l = list.IndexOf(x1[i, j]);
                            list.RemoveAt(l);
                        }
                        else
                        {
                            x2[i, j] = x1[i, j] * 2;
                            l = list.IndexOf(x1[i, j]);
                            list.RemoveAt(l);
                        }
                    }
                    else
                    {
                        if (x1[i, j] < 0) x2[i, j] = x1[i, j] * 2;
                        else x2[i, j] = x1[i, j] / 2;
                    }
                }
            }
        }
        delegate double fi(double i, int k);
        static double f1 (double i, int k)
        {
            double F = Factorial(k);
            return Math.Cos(k * i) / F;
        }
        static double f2(double i, int k)
        {
            return Math.Pow(-1, k) * Math.Cos(k * i) / (k * k); ;
        }
        static double Cycle(fi f, double x)
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
        delegate double[] sorting(double[] x);
        static double[] Even(double[] x)
        {
            Array.Sort(x);
            return x;
        }
        static double[] Odd(double[] x)
        {
            Array.Sort(x);
            Array.Reverse(x);
            return x;
        }
        static double[] Push(sorting f, double[] array)
        {
            return f(array);
        }
        static void Rollcolomns(double[,] x1, out double[,] x2)
        {
            x2 = new double[x1.GetLength(0), x1.GetLength(1)];
            double[] array = new double[x1.GetLength(1)];
            for (int i=0;i<x1.GetLength(0); i++)
            {
                for(int j=0;j<x1.GetLength(1); j++)
                {
                    array[j]= x1[i,j];
                }
                if (i%2==0)
                {
                    array=Push(Even, array);
                }
                else array=Push(Odd, array);
                for(int k=0;k<x1.GetLength(1);k++)
                {
                    x2[i,k]=array[k];
                }
            }
        }
        
        static void Level1_1()
        {
            Console.WriteLine("Level 1_1");
            const int k = 5;
            int n = 8;
            double answer;
            Console.WriteLine("Answer with 8");
            answer = Factorial(n)/(Factorial(k)*Factorial(n-k));
            Console.WriteLine(answer);
            n = 10;
            Console.WriteLine("Answer with 10");
            answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
            Console.WriteLine(answer);
            n = 11;
            Console.WriteLine("Answer with 11");
            answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
            Console.WriteLine(answer);
        }
        static void Level1_2()
        {
            Console.WriteLine("Level1_2");
            double a, b, c, A, B, C;
            Console.WriteLine("Write sides of first tringle"); 
            double.TryParse(Console.ReadLine(), out a);
            double.TryParse(Console.ReadLine(), out b);
            double.TryParse(Console.ReadLine(), out c);
            Console.WriteLine("Write sides of second tringle");
            double.TryParse(Console.ReadLine(), out A);
            double.TryParse(Console.ReadLine(), out B);
            double.TryParse(Console.ReadLine(), out C);
            if ((a + b > c && a + c > b && b + c > a) && (A + B > C && A + C > B && B + C > A))
            {
                double s1, s2;
                double p1,p2;
                p1 = Geron(a, b, c);
                p2 = Geron(A, B, C);

                if (p1 > 0 && p2 > 0)
                {
                    s1 = Math.Sqrt(p1 * (p1 - a) * (p1 - b) * (p1 - c));
                    s2 = Math.Sqrt(p2 * (p2 - A) * (p2 - B) * (p2 - C));
                    if (s1 > s2) Console.WriteLine("square of first tringle more than second tringle");
                    else if (s1 == s2) Console.WriteLine("square is same");
                    else Console.WriteLine("square of second tringle more than first trignle ");
                }
                else Console.WriteLine("Impossible");
            }
            else Console.WriteLine("Not correct sides");
        }

        static void Level2_6()
        {
            Console.WriteLine("Level2_6");
            const int n = 7;
            const int k = 8;
            int m =0 , m1 =0;
            double max = double.MinValue;
            double[] a = new double[n];
            double[] b = new double[k];
            Console.WriteLine("Write elements in first mas");
            for (int i=0; i<n;i++)
            {
                double s;
                double.TryParse(Console.ReadLine(), out s);
                a[i] = s;
                if (s > max)
                {
                    max = s;
                    m= i;
                }
            }
            Console.WriteLine("Write elements in second mas");
            for (int i=0;i<k;i++)
            {
                double s;
                double.TryParse(Console.ReadLine(), out s);
                b[i] = s;
                if (s>max)
                {
                    m1 = i;
                }
            }
            Delete(a, m);
            a = a.SkipLast(1).ToArray();
            Delete(b,m1);
            b = b.SkipLast(1).ToArray();
            a = a.Concat(b).ToArray();
            Console.WriteLine("Answer");
            Console.WriteLine(string.Join(",", a));
        }
        static void Level2_10()
        {
            Console.WriteLine("Level2_10");
            double max=double.MinValue;
            double min = double.MaxValue;
            int maxj = 0;
            int minj = 0;
            int n;
            Console.WriteLine("Write size of matrix");
            int.TryParse(Console.ReadLine(), out n);
            double[,] mas = new double[n, n];
            Console.WriteLine("Write elements in matrix");
            for (int i=0;i<n;i++)
            {
                for (int j=0; j<n; j++)
                {
                    double s;
                    double.TryParse(Console.ReadLine(), out s);
                    mas[i,j] = s;
                    if (i>=j)
                    {
                        if (s>max)
                        {
                            max = s;
                            maxj = j;
                        }
                    }
                    else
                    {
                        if (s<min)
                        {
                            min = s;
                            minj = j;
                        }
                    }
                }
            }
            if (maxj == minj)
            {
                DeleteColomn(mas, minj, out mas);
            }
            else
            {
                DeleteColomn(mas, minj, out mas);
                DeleteColomn(mas, maxj, out mas);
            }
            Console.WriteLine("Answer");
            for (int i = 0; i < n; i++)
            {
                for (int j=0;j< mas.GetLength(1);j++ )
                {
                    Console.WriteLine($"{mas[i,j],5}");
                }
                Console.WriteLine();
            }
        }
        static void Level2_23()
        {
            Console.WriteLine("Level2_23");
            int n, m;
            Console.WriteLine("Write amount of strings in mareix");
            int.TryParse(Console.ReadLine(), out n);
            Console.WriteLine("Write amount of columnns in matrix");
            int.TryParse(Console.ReadLine(), out m);
            double[,] mas1 = new double[n, m];
            Console.WriteLine("Write elements in matrix");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    double s;
                    double.TryParse(Console.ReadLine(), out s);
                    mas1[i, j] = s;
                }
            }
            Maximum5(mas1, out mas1);
            Console.WriteLine("First matrix");
            for (int i=0; i<n;i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.WriteLine($"{mas1[i, j],5}");
                    }
                    Console.WriteLine();
                }
            Console.WriteLine("Write amount of strings in matrix");
            int.TryParse(Console.ReadLine(), out n);
            Console.WriteLine("Write amount of columns in matrix");
            int.TryParse(Console.ReadLine(), out m);
            double[,] mas2 = new double[n, m];
            Console.WriteLine("Write elements in matrix");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    double s;
                    double.TryParse(Console.ReadLine(), out s);
                    mas2[i, j] = s;
                }
            }
            Maximum5(mas2, out mas2);
            Console.WriteLine("Second matrix");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine($"{mas2[i, j],5}");
                }
                Console.WriteLine();
            }



        }
        static void Level3_1()
        {
            Console.WriteLine("Level3_1");
            double s;
            for (double x=0.1; x<=1.0; x+=0.1)
            {
                s=Cycle(f1,x);
                Console.WriteLine($"x - {x}, y - {Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x)),4}, s - {s + 1,4}"); 
            }
            for (double x = Math.PI/5; x<=Math.PI; x+= Math.PI/25)
            {
                s = Cycle(f2, x);
                Console.WriteLine($"x - {x} y - {(x * x - Math.PI * Math.PI / 3) / 4,4}, s - {s,4}");
            }
        }
        static void Level3_2()
        {
            Console.WriteLine("Level3_2");
            int n, m;
            Console.WriteLine("Write amount of strings in matrix");
            int.TryParse(Console.ReadLine(), out n);
            Console.WriteLine("Write amount of columns in matrix");
            int.TryParse(Console.ReadLine(), out m);
            double[,] mas = new double[n, m];
            Console.WriteLine("Write elements in matrix");
            for (int i=0;i<n; i++)
            {
                for(int j=0;j<m;j++)
                {
                    double s;
                    double.TryParse(Console.ReadLine(), out s);
                    mas[i, j] = s;
                }
            }
            Rollcolomns(mas, out mas);
            Console.WriteLine("Answer");
            for (int i=0;i<n;i++)
            {
                for (int j=0;j<m;j++)
                {
                    Console.WriteLine($"{mas[i, j],5}");
                }
                Console.WriteLine();
            }    

        }
        static void Main(string[] args)
        {
            Level1_1();
            Level1_2();
           Level2_6();
           Level2_10();
            Level2_23();
            Level3_1();
            Level3_2();
            
        }
    }

}
