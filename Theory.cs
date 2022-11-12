using System;

namespace _4th_Lab
{
    class Program
    {
        //for 3.4
        public delegate double[] sender(double[,] mas, int n);
        public static double[] sendsverh(double[,] mas, int n)
        {
            double[] newmas = new double[(n * (n + 1)) / 2];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    newmas[k] = mas[i, j];
                    k++;
                }
            }
            return newmas;
        }
        public static double[] sendsniz(double[,] mas, int n)
        {
            double[] newmas = new double[(n * (n + 1)) / 2];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    newmas[k] = mas[i, j];
                    k++;
                }
            }
            return newmas;
        }
        //end 
        //for 3.6
        public delegate int searcher(double[] line);
        public static int diagonal(double[] line)
        {
            double mx = line[0];
            int index = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] > mx)
                {
                    mx = line[i];
                    index = i;
                }
            }
            return index;
        }
        public static int line_1(double[] line)
        {
            double mx = line[0];
            int index = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] > mx)
                {
                    mx = line[i];
                    index = i;
                }
            }
            return index;
        }
        //end
        //for 3.13
        public delegate int find_extrem(double[,] x, int n, int m);
        public static int minfinder(double[,] x, int n, int m)
        {
            int ind = 0;
            double mn = x[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (x[i, j] < mn)
                    {
                        mn = x[i, j];
                        ind = i;
                    }
                }
            }
            return ind;
        }
        public static int maxfinder(double[,] x, int n, int m)
        {
            int ind = 0;
            double mx = x[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (x[i, j] > mx)
                    {
                        mx = x[i, j];
                        ind = i;
                    }
                }
            }
            return ind;
        }
        //end
        static void Main(string[] args)
        {
            #region Task 1
            {
                static void fact(int k, out double f)
                {
                    int i;
                    f = 1;
                    for (i = 1; i <= k; i++)
                        f *= i;
                }
                static void variants(int n,int k,out double  c)
                {
                    fact(n, out double vern);
                    fact(k, out double  verk);
                    fact(n - k, out double vernk);
                    c = vern / verk / vernk;
                }
                int n5 = 8, n10 = 11, k5 = 5, k10 = 10;
                variants(n5, k5, out double c5);
                variants(n10, k10, out double c10);
                Console.WriteLine($"Number of variants for 5 members team is  {c5}");
                Console.WriteLine($"Number of variants for 10 members team is  {c10}");
            }
            #endregion
            #region Task2
            {
                static double P(double a, double b, double c)
                {
                    double p=0;
                    if(a>0 && b>0 && c>0 && a+b>c && a+c>b && b+c>a)
                        p = (a + b + c) / 2;
                    return p;
                }
                static void S(double a, double b, double c,out double s)
                {
                    double p=P(a, b, c);
                    s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                }
                double a1, b1, c1, s1,a2,b2,c2,s2,p2,p1;
                Console.WriteLine("Enter a1");
                double.TryParse(Console.ReadLine(), out a1);
                Console.WriteLine("Enter b1");
                double.TryParse(Console.ReadLine(), out b1);
                Console.WriteLine("Enter c1");
                double.TryParse(Console.ReadLine(), out c1);
                Console.WriteLine("Enter a2");
                double.TryParse(Console.ReadLine(), out a2);
                Console.WriteLine("Enter b2");
                double.TryParse(Console.ReadLine(), out b2);
                Console.WriteLine("Enter c2");
                double.TryParse(Console.ReadLine(), out c2);
                S(a2, b2, c2, out s2);
                S(a1, b1, c1,out s1);
                if (s1 > s2)
                    Console.WriteLine($"1 bigger {s1 - s2}");
                else if (s2 > s1)
                    Console.WriteLine($"2 bigger {s2 - s1}");
                else
                    Console.WriteLine("same square");
            }
            #endregion
            #region Task6
            {
                static void maxx(double[] x, out int indm)
                {
                    double maxi = x[0];
                    indm = 0;
                    for (int i = 0; i < x.Length; i++)
                    {
                        if (x[i] > maxi)
                        {
                            maxi = x[i];
                            indm = i;
                        }
                    }
                }
                static void del(double[] x, int imx)
                {
                    for (int i = imx; i < x.Length - 1; i++)
                    {
                        x[i] = x[i + 1];
                    }
                }
                static void resize(ref double[] array, int newsize)
                {
                    double[] newar = new double[newsize];
                    for (int i = 0; i < array.Length && i < newar.Length; i++)
                    {
                        newar[i] = array[i];
                    }
                    array = newar;
                }
                const int n = 7;
                double[] a = new double[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Enter {i} el");
                    double el;
                    double.TryParse(Console.ReadLine(), out el);
                    a[i] = el;
                }
                int amax;
                maxx(a, out amax);
                del(a, amax);
                const int l = 8;
                double[] b = new double[l];
                for (int i = 0; i < l; i++)
                {
                    Console.WriteLine($"Enter {i} el");
                    double el;
                    double.TryParse(Console.ReadLine(), out el);
                    b[i] = el;
                }
                int bmax;
                maxx(b, out bmax);
                del(b, bmax);
                resize(ref a, n + l - 2);
                int k = 0;
                for (int i = n - 1; i < a.Length; i++)
                {
                    a[i] = b[k];
                    k++;
                }
                foreach (int x in a)
                    Console.Write("{0:} ", x);
                Console.WriteLine();
            }
            #endregion
            #region Task 10
            {
                int n;
                Console.WriteLine("Enter n of matrix");
                int.TryParse(Console.ReadLine(), out n);
                if (n > 1)
                {
                    double[,] a = new double[n, n];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.WriteLine($"Enter y {i} : x {j} : ");
                            double el;
                            double.TryParse(Console.ReadLine(), out el);
                            a[i, j] = el;
                        }
                    }
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write(a[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    int xmx = 0;
                    double mx = a[0, 0];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j <= i; j++)
                        {
                            if (a[i, j] > mx)
                            {
                                mx = a[i, j];
                                xmx = j;
                            }
                        }
                    }
                    Console.WriteLine(mx);
                    Console.WriteLine();
                    Console.WriteLine(xmx);
                    Console.WriteLine();
                    int xmn = 1;
                    double mn = a[0, 1];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = i + 1; j < n; j++)
                        {
                            if (a[i, j] > mx)
                            {
                                mn = a[i, j];
                                xmn = j;
                            }
                        }
                    }
                    Console.WriteLine(mn);
                    Console.WriteLine();
                    Console.WriteLine(xmn);
                    Console.WriteLine("New matrix is");
                    static void hel(double[,] x, int y, int k)
                    {
                        for (int i = 0; i < y; i++)
                            for (int j = k; j < y - 1; j++)
                            {
                                x[i, j] = x[i, j + 1];
                            }
                    }
                    if (xmn != xmx)
                    {
                        hel(a, n, xmn);
                        hel(a, n, xmx);
                        double[,] b = new double[n, n - 2];
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n - 2; j++)
                            {
                                b[i, j] = a[i, j];
                            }
                        }
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n - 2; j++)
                            {
                                Console.Write(a[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                    else if (xmx == xmn)
                    {
                        hel(a, n, xmn);
                        double[,] b = new double[n, n - 1];
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n - 1; j++)
                            {
                                b[i, j] = a[i, j];
                            }
                        }
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n - 1; j++)
                            {
                                Console.Write(a[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
            #endregion
            #region Task23
            {
                int x, y;
                Console.WriteLine("Enter y of matrix");
                int.TryParse(Console.ReadLine(), out y);
                Console.WriteLine("Enter x of matrix");
                int.TryParse(Console.ReadLine(), out x);
                int x1, y1;
                Console.WriteLine("Enter y1 of matrix");
                int.TryParse(Console.ReadLine(), out y1);
                Console.WriteLine("Enter x1 of matrix");
                int.TryParse(Console.ReadLine(), out x1);
                if (x*y>5 && x1*y1>5)
                {
                    double[,] a = new double[y, x];
                    for (int i = 0; i < y; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            double el;
                            Console.WriteLine($"Enter y {i} : x {j} : ");
                            double.TryParse(Console.ReadLine(), out el);
                            a[i, j] = el;
                        }
                    }
                    Console.WriteLine("Matrix A");
                    for (int i = 0; i < y; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            Console.Write(a[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    double[,] b = new double[y1, x1];
                    for (int i = 0; i < y1; i++)
                    {
                        for (int j = 0; j < x1; j++)
                        {
                            double el;
                            Console.WriteLine($"Enter y {i} : x {j} : ");
                            double.TryParse(Console.ReadLine(), out el);
                            b[i, j] = el;
                        }
                    }
                    Console.WriteLine("Matrix B");
                    for (int i = 0; i <y1; i++)
                    {
                        for (int j = 0; j < x1; j++)
                        {
                            Console.Write(b[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    int size = x * y;
                    int size1 = x1 * y1;
                    double[] ar = new double[size];
                    double[] ar1 = new double[size1];
                    int k = 0;
                    for (int i = 0; i < y; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            ar[k] = a[i, j];
                            k++;
                        }
                    }
                    k = 0;
                    for (int i = 0; i < y1; i++)
                    {
                        for (int j = 0; j < x1; j++)
                        {
                            ar1[k] = b[i, j];
                            k++;
                        }
                    }
                    k = 0;
                    Array.Sort(ar);
                    Array.Sort(ar1);
                    double[] maxa = new double[5];
                    double[] maxb = new double[5];
                    for(int i=size-5;i<size;i++)
                    {
                        maxa[k]=ar[i];
                        k++;
                    }
                    k = 0;
                    for (int i = size1 - 5; i < size1; i++)
                    {
                        maxb[k] = ar1[i];
                        k++;
                    }
                    change(a, maxa, y,x, out a);
                    change(b, maxb, y1, x1,out b);
                    Console.WriteLine("New matrix A");
                    for (int i = 0; i < y; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            Console.Write(a[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("New matrix B");
                    for (int i = 0; i < y1; i++)
                    {
                        for (int j = 0; j < x1; j++)
                        {
                            Console.Write(b[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    static void change(double[,] x, double[]maxi,int n,int m,out double[,]xafter)
                    {
                        int m_1 = 0, m_2 = 0, m_3 = 0, m_4 = 0, m_5 = 0;
                        for(int i=0;i<n;i++)
                        {
                            for(int j=0;j<m;j++)
                            {
                                if (x[i, j] == maxi[0] && m_1 == 0)
                                {
                                    m_1++;
                                    if (x[i, j] >= 0)
                                        x[i, j] *= 2;
                                    else
                                        x[i, j] /= 2;
                                }
                                else if (x[i, j] == maxi[1] && m_2 == 0)
                                {
                                    m_2++;
                                    if (x[i, j] >= 0)
                                        x[i, j] *= 2;
                                    else
                                        x[i, j] /= 2;
                                }
                                else if (x[i, j] == maxi[2] && m_3 == 0)
                                {
                                    m_3++;
                                    if (x[i, j] >= 0)
                                        x[i, j] *= 2;
                                    else
                                        x[i, j] /= 2;
                                }
                                else if (x[i, j] == maxi[3] && m_4 == 0)
                                {
                                    m_4++;
                                    if (x[i, j] >= 0)
                                        x[i, j] *= 2;
                                    else
                                        x[i, j] /= 2;
                                }
                                else if (x[i, j] == maxi[4] && m_5 == 0)
                                {
                                    m_5++;
                                    if (x[i, j] >= 0)
                                        x[i, j] *= 2;
                                    else
                                        x[i, j] /= 2;
                                }
                                else
                                {
                                    if (x[i, j] >= 0)
                                        x[i, j] /= 2;
                                    else
                                        x[i, j] *= 2;
                                }
                            }
                        }
                        xafter = x;
                    }
                }
            }
            #endregion
            #region Task 3.4
            {
                int n;
                Console.WriteLine("Enter size of Matrix");
                int.TryParse(Console.ReadLine(), out n);
                double[,] a = new double[n, n];
                double[] tip = new double[(n * (n + 1)) / 2];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        double el;
                        Console.WriteLine($"Enter y {i} : x {j} : ");
                        double.TryParse(Console.ReadLine(), out el);
                        a[i, j] = el;
                    }
                }
                Console.WriteLine("Matrix A");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(a[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                int button;
                Console.WriteLine("Choose which treangle of matrix u need. If verh, press 1. If niz, press 2");
                int.TryParse(Console.ReadLine(), out button);
                double summ;
                if (button == 1 || button == 2)
                {
                    sender verh_or_niz;
                    if (button == 1)
                    {
                        verh_or_niz = sendsverh;
                    }
                    else
                    {
                        verh_or_niz = sendsniz;
                    }
                    tip = verh_or_niz(a, n);
                    summ = summary(tip);
                    Console.WriteLine(summ);
                }
                static double summary(double[] x)
                {
                    double sm = 0;
                    for (int i = 0; i < x.Length; i++)
                    {
                        sm += x[i] * x[i];
                    }
                    return sm;
                }
            }
            #endregion
            #region Task 3.6
            {
                int n;
                Console.WriteLine("Enter n of matrix");
                int.TryParse(Console.ReadLine(), out n);
                double[,] a = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        double el;
                        Console.WriteLine($"Enter y {i} : x {j} : ");
                        double.TryParse(Console.ReadLine(), out el);
                        a[i, j] = el;
                    }
                }
                Console.WriteLine("Matrix A");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(a[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                double[] diag = new double[n];
                for (int i = 0; i < n; i++)
                {
                    diag[i] = a[i, i];
                }
                double[] row_1 = new double[n];
                double mx = a[0, 0];
                int imx = 0;
                for (int j = 0; j < n; j++)
                {
                    if (a[0, j] > mx)
                    {
                        mx = a[0, j];
                        imx = j;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    row_1[i] = a[0, i];
                }
                searcher ussing = diagonal;
                int ind1 = ussing(diag);
                ussing = line_1;
                int ind2 = ussing(row_1);
                change(a, n, ind1, ind2, out a);
                Console.WriteLine("New matrix A");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(a[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                static void change(double[,] x, int n, int ind1, int ind2, out double[,] x1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        double p = x[i, ind1];
                        x[i, ind1] = x[i, ind2];
                        x[i, ind2] = p;
                    }
                    x1 = x;
                }
            }
            #endregion
            #region Task 3.13
            {
                Console.WriteLine("Enter y of matrix");
                int y;
                int.TryParse(Console.ReadLine(), out y);
                int x;
                Console.WriteLine("Enter x of matrix");
                int.TryParse(Console.ReadLine(), out x);
                double[,] a = new double[y, x];
                for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        double el;
                        Console.WriteLine($"Enter y{i}: x{j}: ");
                        double.TryParse(Console.ReadLine(), out el);
                        a[i, j] = el;
                    }
                }
                for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        Console.Write(a[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                find_extrem extrem = minfinder;
                int indmin = extrem(a, y, x);
                extrem = maxfinder;
                int indmax = extrem(a, y, x);
                del(a, y, x, indmin, indmax, out a);
                if (indmin != indmax)
                {
                    double[,] b = new double[y - 2, x];
                    for (int i = 0; i < y - 2; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            b[i, j] = a[i, j];
                        }
                    }
                    for (int i = 0; i < y - 2; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            Console.Write(b[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    double[,] b = new double[y - 1, x];
                    for (int i = 0; i < y - 1; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            b[i, j] = a[i, j];
                        }
                    }
                    for (int i = 0; i < y - 1; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            Console.Write(b[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                }
                static void del(double[,] x, int n, int m, int ind1, int ind2, out double[,] x1)
                {
                    if (ind1 != ind2)
                    {
                        for (int i = ind1; i < n - 1; i++)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                x[i, j] = x[i + 1, j];
                            }
                        }
                        for (int i = ind2; i < n - 1; i++)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                x[i, j] = x[i + 1, j];
                            }
                        }
                    }
                    else
                    {
                        for (int i = ind1; i < n - 1; i++)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                x[i, j] = x[i + 1, j];
                            }
                        }
                    }
                    x1 = x;
                }
            }
            #endregion
        }
    }
}
