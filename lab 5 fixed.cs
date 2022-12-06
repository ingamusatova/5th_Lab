using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Schema;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace lab5fix
{
    /*
    class N2_10
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N2.10:");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            double zq;
            double[,] mast = new double[x, y];
            for (int i = 0; i < x; i++)
            {
                string[] d = Console.ReadLine().Split();
                for (int j = 0; j < d.Length; j++)
                {
                    if (d.Length == y)
                    {
                        bool r = double.TryParse(d[j], out zq);
                        if (r == true)
                        {
                            mast[i, j] = zq;
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод");
                        Environment.Exit(0);
                    }
                }
            }
            double[,] result = p(mast, x, y);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write($"{result[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static double[,] p(double[,] mast1, int x1, int y1)
        {
            double max = 0;
            int jmax = 0;
            double min = 10000;
            int jmin = 0;
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (mast1[i, j] > max)
                    {
                        max = mast1[i, j];
                        jmax = j;
                    }
                }
                for (int k = i + 1; k < y1; k++)
                {
                    if (mast1[i, k] < min)
                    {
                        min = mast1[i, k];
                        jmin = k;
                    }
                }
            }
            int tec = y1;
            if (jmin != jmax)
            {
                tec = tec - 2;
            }
            else
            {
                tec = tec - 1;
            }
            double[,] mass = new double[x1, tec];
            for (int i = 0; i < x1; i++)
               {
                int z = 0;
                for (int j = 0; j < y1; j++)
                  {
                      if (j != jmin & j!=jmax)
                      {
                            mass[i, z] = mast1[i, j];
                            z++;
                      }
                  }
               }
            return mass;
        }
    }
    */

    /*
    class N2_23
    {
        static void Main(string[] args)
        {
                Console.WriteLine("N2.23:");
                int x = Convert.ToInt32(Console.ReadLine());
                int y = Convert.ToInt32(Console.ReadLine());
                double zq;
                double[,] mast1 = new double[x, y];
                if (x * y - 5 < 0)
                {
                    Console.WriteLine("Неверный ввод");
                    Environment.Exit(0);
                }
                for (int i = 0; i < x; i++)
                {
                    string[] d = Console.ReadLine().Split();
                    for (int j = 0; j < d.Length; j++)
                    {
                        if (d.Length == y)
                        {
                            bool r = double.TryParse(d[j], out zq);
                            if (r == true)
                            {
                                mast1[i, j] = zq;
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод");
                            Environment.Exit(0);
                        }
                    }
                }
                Console.WriteLine("");
                double[,] prok1 = new double[x, y];
                if (x * y - 5 < 0)
                {
                    Console.WriteLine("Неверный ввод");
                    Environment.Exit(0);
                }
                for (int i = 0; i < x; i++)
                {
                    string[] w = Console.ReadLine().Split();
                    for (int j = 0; j < w.Length; j++)
                    {
                        if (w.Length == y)
                        {
                            bool ra = double.TryParse(w[j], out zq);
                            if (ra == true)
                            {
                                prok1[i, j] = zq;
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод");
                            Environment.Exit(0);
                        }
                    }
                }
                Console.WriteLine("");
                double[,] result1 = p(mast1,x, y);
                double[,] result2 = p1(prok1, x, y);
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        Console.Write($"{result1[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("");
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        Console.Write($"{result2[i, j]} ");
                    }
                    Console.WriteLine();
                }
        }
        static double[,] p(double[,] mast1,int x1, int y1)
        {
            double[,] maxi = new double[x1,y1];
            double mox = 0;
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < y1; j++)
                {
                    if (mox < mast1[i,j])
                    {
                        mox = mast1[i, j];
                    }
                }
            }
            mox = mox * 3+1;
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < y1; j++)
                {
                    maxi[i, j] = mox;
                }
            }
            for (int n = 0; n < 5; n++)
            {
                int[] c = f(maxi, mast1, x1, y1,mox);
                maxi[c[0], c[1]] = mast1[c[0], c[1]]*2;
            }
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < y1; j++)
                {
                    if (maxi[i, j] == mox)
                    {
                        maxi[i, j] = mast1[i, j] / 2;
                    }
                }
            }
            return maxi;
        }
        static int[] f(double[,] maxi1, double[,] mast2, int x2, int y2,double mox)
        {
            double max = -(Math.Pow(9,10));
            int indi = 0;
            int indj = 0;
            for (int i = 0; i < x2; i++)
            {
                for (int j = 0; j < y2; j++)
                {
                    if (maxi1[i,j]==mox & mast2[i,j]>max)
                    {
                        max = mast2[i, j];
                        indi = i;
                        indj = j;
                    }
                }
            }
            int[] res = new int[2] {indi, indj};
            return res;
        }
        static double[,] p1(double[,] prok1, int x1, int y1)
        {
            double[,] maxi = new double[x1, y1];
            double mox = 0;
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < y1; j++)
                {
                    if (mox < prok1[i, j])
                    {
                        mox = prok1[i, j];
                    }
                }
            }
            mox = mox * 3 + 1;
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < y1; j++)
                {
                    maxi[i, j] = mox;
                }
            }
            for (int n = 0; n < 5; n++)
            {
                int[] c = f1(maxi, prok1, x1, y1, mox);
                maxi[c[0], c[1]] = prok1[c[0], c[1]] * 2;
            }
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < y1; j++)
                {
                    if (maxi[i, j] == mox)
                    {
                        maxi[i, j] = prok1[i, j] / 2;
                    }
                }
            }
            return maxi;
        }
        static int[] f1(double[,] maxi1, double[,] prok2, int x2, int y2, double mox)
        {
            double max = -(Math.Pow(9, 10));
            int indi = 0;
            int indj = 0;
            for (int i = 0; i < x2; i++)
            {
                for (int j = 0; j < y2; j++)
                {
                    if (maxi1[i, j] == mox & prok2[i, j] > max)
                    {
                        max = prok2[i, j];
                        indi = i;
                        indj = j;
                    }
                }
            }
            int[] res = new int[2] { indi, indj };
            return res;
        }
    }
    */

    /*
    delegate double[] del(double[] a1);
    class N3_2
    {
        static double[] sort(double[] a1)
        {
            Array.Sort(a1);
            return a1;
        }
        static double[] reverse(double[] a1)
        {
            Array.Reverse(a1);
            return a1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("N3.2:");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            double q;
            double[,] a = new double[x, y];
            for (int i = 0; i < x; i++)
            {
                string[] d = Console.ReadLine().Split();
                for (int j = 0; j < d.Length; j++)
                {
                    if (d.Length == y)
                    {
                        bool r = double.TryParse(d[j], out q);
                        if (r == true)
                        {
                            a[i, j] = q;
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод");
                        Environment.Exit(0);
                    }
                }
            }
            for (int i = 0; i < x; i++)
            {
                double[] mass = new double[y];
                for (int j = 0; j < y; j++)
                {
                    mass[j] = a[i, j];
                }
                del prom = sort;
                if (i % 2 == 1)
                {
                    prom += reverse;
                }
                double[] result = prom(mass);
                for (int j = 0; j < y; j++)
                {
                   a[i, j] = result[j];
                }
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write($"{a[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
    */

    /*
    delegate double[] del(double[] a1);
    class N3_3
    {
        static double[] sort(double[] tuc1)
        {
          for(int i = 0; i < tuc1.Length-1; i++)
            {
                double q = 0;
                q = tuc1[i];
                tuc1[i] = tuc1[i + 1];
                tuc1[i + 1] = q;
            }
            return tuc1; 
        }
        static double[] obr(double[] tuc1)
        {
            double[] end = new double[tuc1.Length];
            end[0]=tuc1[tuc1.Length-2];
            end[1]=tuc1[tuc1.Length-1];
            int f = 2;
            for(int i = 0; i < tuc1.Length-2;i++)
            {
                end[f] = tuc1[i];
                f++;
            }
            return end;
        }
        static double nech(double[] tuc1)
        {
            double ls = 0;
            for(int i = 1; i < tuc1.Length; i+=2)
            {
                ls += tuc1[i];
            }
            return ls;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("N3.3:");
            double qwe;
            string[] prog = Console.ReadLine().Split();
            double[] tuc = new double[prog.Length];
            for(int i = 0; i <prog.Length; i++)
            {
                bool ter = double.TryParse(prog[i], out qwe);
                if(ter==true)
                {
                    tuc[i] = qwe;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            Console.WriteLine("");
            double s = 0;
            for(int i = 0; i < tuc.Length; i++)
            {
                s = s + tuc[i];
            }
            del prom = sort;
            if (tuc[0]<s/tuc.Length)
            {
                prom += obr;
            }
            double[] result = prom(tuc);
            for (int j = 0; j < tuc.Length; j++)
            {
                tuc[j] = result[j];
            }
            double summa = nech(tuc);
            Console.WriteLine($"Искомая сумма {summa}");
        }
    }
    */
    delegate double[] del(double[,] a1, int x1);
    class N3_4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N3.4:");
            int x = Convert.ToInt32(Console.ReadLine());
            double q;
            double[,] a = new double[x, x];
            for (int i = 0; i < x; i++)
            {
                string[] d = Console.ReadLine().Split();
                for (int j = 0; j < d.Length; j++)
                {
                    if (d.Length == x)
                    {
                        bool r = double.TryParse(d[j], out q);
                        if (r == true)
                        {
                            a[i, j] = q;
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод");
                        Environment.Exit(0);
                    }
                }
            }
            Console.WriteLine("Ниж. треуг. введите 1, иначе 2");
            string opr = Console.ReadLine();
            double wex;
            double isp = 0;
            bool prov = double.TryParse(opr, out wex);
            if (prov == true & (wex == 1 | wex == 2))
            {
                isp = wex;
            }
            else
            {
                Environment.Exit(0);
            }
            del prom = verh;
            if (isp == 1)
            {
                prom = prom - verh + nijn;
            }
            double[] result = prom(a, x);
            Console.WriteLine($"Искомая сумма равна {func(result)}");
        }
        static double[] nijn(double[,] a1, int x1)
        {
            int len = (x1 * x1 - x1) / 2 + x1;
            double[] rep = new double[len];
            int z = 0;
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    rep[z] = a1[i, j];
                    z++;
                }
            }
            return rep;
        }
        static double[] verh(double[,] a1, int x1)
        {
            int len = (x1 * x1 - x1) / 2 + x1;
            double[] rep = new double[len];
            int z = 0;
            for (int i = 0; i < x1; i++)
            {
                for (int j = i; j < x1; j++)
                {
                    rep[z] = a1[i, j];
                    z++;
                }
            }
            return rep;
        }
        static double func(double[] result1)
        {
            double symma = 0;
            for (int i = 0; i < result1.Length; i++)
            {
                symma += Math.Pow(result1[i], 2);
            }
            return symma;
        }
    }
}

