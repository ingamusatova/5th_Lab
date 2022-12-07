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
        double[,] result1 = p(mast1, x, y);
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
    static double[,] p(double[,] mast1, int x1, int y1)
    {
        double[,] maxi = new double[x1, y1];
        double mox = 0;
        for (int i = 0; i < x1; i++)
        {
            for (int j = 0; j < y1; j++)
            {
                if (mox < mast1[i, j])
                {
                    mox = mast1[i, j];
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
            int[] c = f(maxi, mast1, x1, y1, mox);
            if (mast1[c[0], c[1]] < 0)
            {
                maxi[c[0], c[1]] = mast1[c[0], c[1]] / 2;
            }
            else
            {
                maxi[c[0], c[1]] = mast1[c[0], c[1]] * 2;
            }
        }
        for (int i = 0; i < x1; i++)
        {
            for (int j = 0; j < y1; j++)
            {
                if (maxi[i, j] == mox)
                {
                    if (mast1[i, j] < 0)
                    {
                        maxi[i, j] = mast1[i, j] * 2;
                    }
                    else
                    {
                        maxi[i, j] = mast1[i, j] / 2;
                    }
                }
            }
        }
        return maxi;
    }
    static int[] f(double[,] maxi1, double[,] mast2, int x2, int y2, double mox)
    {
        double max = -(Math.Pow(9, 10));
        int indi = 0;
        int indj = 0;
        for (int i = 0; i < x2; i++)
        {
            for (int j = 0; j < y2; j++)
            {
                if (maxi1[i, j] == mox & mast2[i, j] > max)
                {
                    max = mast2[i, j];
                    indi = i;
                    indj = j;
                }
            }
        }
        int[] res = new int[2] { indi, indj };
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
            if(prok1[c[0], c[1]]<0)
            {
                maxi[c[0], c[1]] = prok1[c[0], c[1]] / 2;
            }
            else
            {
                maxi[c[0], c[1]] = prok1[c[0], c[1]] * 2;
            }
            
        }
        
        for (int i = 0; i < x1; i++)
        {
            for (int j = 0; j < y1; j++)
            {
                if (maxi[i, j] == mox)
                {
                    if(prok1[i, j] < 0)
                    {
                        maxi[i, j] = prok1[i, j] * 2;
                    }
                    else
                    {
                        maxi[i, j] = prok1[i, j] / 2;
                    }
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
