using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Schema;

namespace lab5
{
    /*
    class N1_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N1.1:");
            double[] a = new double[3]{8, 10, 11};
            double b = 5;
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"{p(a[i], b)} способов отобрать команду из {a[i]} кандидатов");
            }
        }
        static double p(double a1, double b1)
        {
            double n = 1;
            double nk = 1;
            double k = 1;
            for (int i = 1; i <=a1; i++)
            {
                n = n * i;
                if(i==5)
                {
                    k = n;
                }
                if (i == a1-b1)
                {
                    nk = n;
                }
            }
            return n / (k * nk); 
        }
    }
    */

    /*
    class N1_2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N1.2:");
            double[] a = new double[2] {7,9};
            double[] b = new double[2] {6,3};
            double[] c = new double[2] {4,9};
            double max = 0;
            double s = 0;
            for (int i = 0; i < a.Length; i+=2)
            {
                if (p(a[i], b[i], c[i])>max)
                {
                    max = p(a[i], b[i], c[i]);
                    s = i + 1;
                }
            }
            if(s==1)
            {
                Console.WriteLine($"Первый треугольник больше s={Math.Round(max,2)}");
            }
            else
            {
                Console.WriteLine($"Второй треугольник больше s={Math.Round(max,2)}");
            }
        }
        static double p(double a1, double b1,double c1)
        {
            double pl = 0;
            double per = (a1 + b1 + c1)/2;
            pl = Math.Sqrt(per * (per - a1) * (per - b1) * (per - c1));
            return pl;
        }
    }
    */

    /*
    class N2_6
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N2.6:");
            double[] a = new double[7];
            double[] b = new double[8];
            double vi;
            string[] orda = Console.ReadLine().Split();
            if (orda.Length != 7)
            {
              Console.WriteLine("Неверный ввод");
              Environment.Exit(0);
             }
            for (int j = 0; j < orda.Length; j++)
                {
                    bool tr = double.TryParse(orda[j], out vi);
                    if(tr==true)
                    {
                        a[j] = vi;
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод");
                        Environment.Exit(0);
                    }
                }
            string[] org = Console.ReadLine().Split();
            if (org.Length != 8)
            {
                Console.WriteLine("Неверный ввод");
                Environment.Exit(0);
            }
            for (int i = 0; i < org.Length; i++)
            {
                bool trq = double.TryParse(org[i], out vi);
                if (trq == true)
                {
                    b[i] = vi;
                }
                else
                {
                    Console.WriteLine("Неверный ввод");
                    Environment.Exit(0);
                }
            }
            double[] result = p(a, b);
            for(int i=0;i<result.Length; i++)
            {
                Console.Write($"{result[i]} ");
            }
        }
        static double[] p(double[] a1, double[] b1)
        {
            double max = 0;
            double aimax = 0;
            double[] c = new double[13];
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i]>max)
                {
                    max= a1[i];
                    aimax = i;
                }
            }
            max = 0;
            double bimax = 0;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] > max)
                {
                    max = b1[i];
                    bimax = i;
                }
            }
            int z = 0;
            for (int i = 0; i < a1.Length; i++)
            {
                if(i!=aimax)
                {
                    c[z] = a1[i];
                    z++;
                }
            }
            for (int i = 0; i < b1.Length; i++)
            {
                if (i != bimax)
                {
                    c[z] = b1[i];
                    z++;
                }
            }
            return c;
        }
    }
    */

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
            double[,] result = p(mast,x,y);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y-2; j++)
                {
                    Console.Write($"{result[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static double[,] p(double[,] mast1,int x1,int y1)
        {
            double max = 0;
            int jmax = 0;
            double min = 10000;
            int jmin = 0;
            double[,] mass = new double[x1, y1-2];
            for(int i=0;i<x1;i++)
            {
                for(int j=0;j<i+1;j++)
                {
                    if (mast1[i,j]>max)
                    {
                        max = mast1[i, j];
                        jmax=j;
                    }
                }
                for(int k=i+1;k<y1;k++)
                {
                    if (mast1[i, k] < min)
                    {
                        min = mast1[i, k];
                        jmin = k;
                    }
                }
            }
            for (int i = 0; i < x1; i++)
            {
                int z = 0;
                for (int j=0;j<y1;j++)
                {
                    if(j!=jmin & j!=jmax)
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
            for (int a = 0; a < 2; a++)
            {
                int x = Convert.ToInt32(Console.ReadLine());
                int y = Convert.ToInt32(Console.ReadLine());
                double zq;
                double[,] mast = new double[x, y];
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
                    for (int j = 0; j < y; j++)
                    {
                        Console.Write($"{result[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        static double[,] p(double[,] mast1, int x1, int y1)
        {
            double[] maxi = new double[5];
            for (int n = 0; n < 5; n++)
            {
                int[] c = f(maxi, mast1, x1, y1);
                mast1[c[0], c[1]] = mast1[c[0], c[1]] * 2;
                maxi[n] = mast1[c[0], c[1]];
            }
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < y1; j++)
                {
                    bool pro = maxi.Contains(mast1[i, j]);
                    if (pro == false)
                    {
                        mast1[i, j] = mast1[i, j] / 2;
                    }
                }
            }
            return mast1;
        }
        static int[] f(double[] maxi1, double[,] mast2, int x2, int y2)
        {
            double max = 0;
            int indi = 0;
            int indj = 0;
            for (int i = 0; i < x2; i++)
            {
                for (int j = 0; j < y2; j++)
                {
                    bool pro = maxi1.Contains(mast2[i, j]);
                    if (pro == false)
                    {
                        if (mast2[i, j] > max)
                        {
                            max = mast2[i, j];
                            indi = i;
                            indj = j;
                        }
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
        static double[] high(double[] a1)
        {
            Array.Sort(a1);
            return a1;
        }
        static double[] low(double[] a1)
        {
            Array.Sort(a1);
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
                if (i % 2 == 0)
                {
                    del prom = high;
                    double[] result = prom(mass);
                    for (int j = 0; j < y; j++)
                    {
                        a[i, j] = result[j];
                    }
                }
                else
                {
                    del prom = low;
                    double[] result = prom(mass);
                    for (int j = 0; j < y; j++)
                    {
                        a[i, j] = result[j];
                    }
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
        static double[] parn(double[] tuc1)
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
        static double[] park(double[] tuc1)
        {
            for (int i = tuc1.Length - 1; i < 0; i--)
            {
                double q = 0;
                q = tuc1[i - 1];
                tuc1[i - 1] = tuc1[i];
                tuc1[i] = q;
            }
            return tuc1;
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
            double s = 0;
            for(int i = 0; i < tuc.Length; i++)
            {
                s = s + tuc[i];
            }
            if (s / tuc.Length < tuc[0])
            {
                del prom = park;
                double[] result = prom(tuc);
                for (int j = 0; j < tuc.Length; j++)
                {
                    tuc[j] = result[j];
                }
            }
            else
            {
                del prom = parn;
                double[] result = prom(tuc);
                for (int j = 0; j < tuc.Length; j++)
                {
                    tuc[j] = result[j];
                }
            }
            double summa = nech(tuc);
            Console.WriteLine($"Искомая сумма{summa}");
        }
    }
    */
    delegate double[] del(double[,] a1,int x1);
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
            if (prov == true & (wex==1 | wex==2))
            {
                isp = wex;
            }
            else
            {
                Environment.Exit(0);
            }
            if (isp == 1)
            {
                del prom = nijn;
                double[] result = prom(a,x);
                Console.WriteLine($"Искомая сумма равна {func(result)}");
            }
            else
            {
                del prom = verh;
                double[] result = prom(a, x);
                Console.WriteLine($"Искомая сумма равна {func(result)}");
            }
        }
        static double[] nijn(double[,] a1,int x1)
        {
            int len = (x1*x1 - x1) / 2 + x1;
            double[] rep = new double[len];
            int z = 0;
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    rep[z]=a1[i,j];
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
            for(int i = 0; i < result1.Length; i++)
            {
                symma += Math.Pow(result1[i], 2);
            }
            return symma;
        }
    }

}
