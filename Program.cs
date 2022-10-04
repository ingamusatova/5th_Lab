using System;

namespace Task
{

    class Program
    {
        
        static int Fact(int n)
        {
            if(n<0)
            {
                Console.WriteLine("не верное значение");
                return 1;
            }
            int ans = 1;
            for (int i = 2; i <= n; i++)
            {
                ans *= i;
            }
            return ans;
        }
        static int Сombination(int n, int k)
        {
            int ans = 0;
            ans = Fact(n)/(Fact(k)*Fact(n-k));
            return ans;
        }
        static void exercise_1_1()
        {
            //string error = "ошибка 1_1";
            InputOutput.Write(Сombination(8, 5));
            InputOutput.Write(Сombination(10, 5));
            InputOutput.Write(Сombination(11, 5));
        }

        static bool CheckTriangle(double a, double b, double c)
        {
            if (Math.Max(a, Math.Max(b, c)) * 2 <= a + b + c && a >= 0 && b >= 0 && c >= 0) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static double Geron(double a, double b, double c)
        {
            double p = (a + b + c) / 2,ans;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c)); ;
        }
        static void exercise_1_2()
        {
            string error = "ошибка 1_2";
            double a1, a2, b1, b2, c1, c2;
            Console.WriteLine("ведите a1 b1 c1");
            List<double> read = new List<double>();

            if (!InputOutput.CheckSplitRead(out read, error, 3))
            {
                return;
            }
            (a1, b1, c1) = (read[0], read[1], read[2]);
            if (!CheckTriangle(a1, b1, c1)){
                Console.WriteLine("невозможный треугольник");
                return;
            }
            Console.WriteLine("ведите a2 b2 c2");
            if (!InputOutput.CheckSplitRead(out read, error, 3))
            {
                return;
            }
            (a2, b2, c2) = (read[0], read[1], read[2]);
            if (!CheckTriangle(a2, b2, c2)){
                Console.WriteLine("невозможный треугольник");
                return;
            }

            double ans = Math.Max(Geron(a1,b1, c1), Geron(a2, b2, c2));
            InputOutput.Write(ans);
        }

        static double[] RemoveIndex(double[] x,int ind)
        {
            double[] ans = new double[x.Length - 1];
            int shi = 0;
            for(int i = 0; i < x.Length; i++)
            {
                if (i == ind) 
                {
                    continue;
                }
                ans[shi] = x[i];
                shi++;
            }
            return ans;
        }
        static double[] SplitArrays(double[] A, double[] B)
        {
            double[] ans = new double[A.Length + B.Length];
            for(int j = 0; j < A.Length; j++)
            {
                ans[j] = A[j];
            }
            for (int j = 0; j < B.Length; j++)
            {
                ans[j+ A.Length] = B[j];
            }
            return ans;
        }
        static void exercise_2_6()
        {
            string error = "ошибка 2_6";
            int n = 7, m = 8;
            double[] A = new double[n], B = new double[m], C = new double[n + m + 2];

            List<double> read = new List<double>();

            Console.WriteLine($"ведите {n} элементов");
            if (!InputOutput.CheckSplitRead(out read, error, n))
            {
                return;
            }

            int maxA = 0;
            for (int i = 0; i < n; ++i) 
            {
                A[i] = read[i];
                if (A[maxA] < A[i])
                {
                    maxA = i;
                }
            }
            Console.WriteLine($"ведите {m} элементов");
            if (!InputOutput.CheckSplitRead(out read, error, m))
            {
                return;
            }
            int maxB = 0;
            for (int i = 0; i < m; ++i)
            {
                B[i] = read[i];
                if (B[maxA] < B[i])
                {
                    maxB = i;
                }
            }
            C = SplitArrays(RemoveIndex(A, maxA), RemoveIndex(B, maxB));
            Console.WriteLine(ArrayToString(C));

        }
        
        static double[,] RemoveСolumn(double[,] A,int ind)
        {
            int n = A.GetLength(0), m = A.GetLength(1);
            double[,] ans = new double[n, m - 1];

            for(int i = 0; i < n; ++i)
            {
                int shj = 0;
                for (int j = 0; j < m; ++j)
                {
                    if (j == ind)
                    {
                        continue;
                    }

                    ans[i, shj] = A[i, j];
                    shj++;
                }
            }
            return ans;
            
        }

        static void exercise_2_10()
        {
            string error = "ошибка 2_10";
            int n = 7;
            Console.WriteLine("ведите n(n >= 0)");
            if (!InputOutput.CheckRead(out n, error))
            {
                return;
            }
            if (n < 0)
            {
                Console.WriteLine(error);
                return;
            }
            Console.WriteLine($"ведите {n} строк {n} столбцов");
            double[,] A = new double[n,n];
            int minI = 0, maxI = 0, minJ = 0, maxJ = 0;
            for (int i = 0; i < n; ++i)
            {
                List<double> read = new List<double>();
                if (!InputOutput.CheckSplitRead(out read, error, n))
                {
                    return;
                }
                for (int j = 0; j < n; ++j)
                {
                    double a = read[j];
                    A[i, j] = a;
                    if (j > i && (A[minI, minJ] > a || (minI == 0 && minJ == 0)))
                    {
                        minJ = j;
                        minI = i;
                    }
                    if (j < i && (A[maxI, maxJ] < a || (maxI == 0 && maxJ == 0)))
                    {
                        maxJ = j;
                        maxI = i;
                    }
                }
            }

            if(minJ > maxJ)
            {
                (minJ, maxJ) = (maxJ, minJ);
            }
            string[] S = ArrayToString(RemoveСolumn(RemoveСolumn(A, minJ), maxJ -1));

            Console.WriteLine("ans :");
            foreach(var s in S)
            {
                Console.WriteLine(s);
            }

        }

        static void Task_2_23_UpdateArray(double[,] A)
        {
            PriorityQueue<(int, int), double> Q = new PriorityQueue<(int, int), double>();
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            for (int i = 0; i < n; ++i) 
            {
                for (int j = 0; j < m; ++j)
                {
                    Q.Enqueue((i, j), -A[i, j]);
                }
            }
            int sh = 0;
            while(Q.Count > 0 && sh < 5)
            {
                (int x, int y) = Q.Peek();
                A[x, y] *= 2;
                sh++;
                Q.Dequeue();
            }
            while (Q.Count > 0)
            {
                (int x, int y) = Q.Peek();
                A[x, y] /= 2;
                Q.Dequeue();
            }
        }
        static void exercise_2_23()
        {
            string error = "ошибка 2_23";
            int n ,m;
            Console.WriteLine("ведите n(n >= 0)");
            if (!InputOutput.CheckRead(out n, error))
            {
                return;
            }
            if (n < 0)
            {
                Console.WriteLine(error);
                return;
            }
            Console.WriteLine($"ведите {n} строк {n} столбцов");
            double[,] A = new double[n, n];
            for (int i = 0; i < n; ++i)
            {
                List<double> read = new List<double>();
                if (!InputOutput.CheckSplitRead(out read, error, n))
                {
                    return;
                }
                for (int j = 0; j < n; ++j)
                {
                    double a = read[j];
                    A[i, j] = a;
                }
            }

            Console.WriteLine("ведите m(m >= 0)");
            if (!InputOutput.CheckRead(out m, error))
            {
                return;
            }
            if (m < 0)
            {
                Console.WriteLine(error);
                return;
            }
            Console.WriteLine($"ведите {m} строк {m} столбцов");
            double[,] B = new double[m, m];
            for (int i = 0; i < m; ++i)
            {
                List<double> read = new List<double>();
                if (!InputOutput.CheckSplitRead(out read, error, m))
                {
                    return;
                }
                for (int j = 0; j < m; ++j)
                {
                    double a = read[j];
                    B[i, j] = a;
                }
            }

            Task_2_23_UpdateArray(A);
            Task_2_23_UpdateArray(B);

            string[] S;
            S = ArrayToString(A);
            Console.WriteLine("ans :");
            foreach (var s in S)
            {
                Console.WriteLine(s);
            }

            S = ArrayToString(B);
            Console.WriteLine();
            foreach (var s in S)
            {
                Console.WriteLine(s);
            }

        }

        delegate double Term(double x);
        delegate double Check(double x);
        const double eps = 0.000001;
        static double Term_1(double x)
        {
            double ans = 0;
            double F = 1;
            for(int i = 1;i == i; ++i)
            {
                F *= i;
                double term = Math.Cos(i * x) / F;
                ans += term;
                if (term <= eps) break;
            }
            return ans;
        }
        static double Check_1(double x)
        {
            double ans = Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
            return ans;
        }
        static double Term_2(double x)
        {
            double ans = 0;
            double f = -1;
            for (int i = 1; i == i; ++i)
            {
              
                double term = Math.Cos(i * x) / (i*i) * f;
                f *= -1;
                ans += term;
                if (term <= eps) break;
            }
            return ans;
        }
        static double Check_2(double x)
        {
            double Pi = Math.PI;
            double ans = ((x * x) - Pi * Pi / 3) / 4;
            return ans;
        }
        static void Task_3_1(double a, double b, double h, Check check, Term term,double start = 0)
        {
            for (double x = a; x <= b; x += h)
            {
                double y = check(x);
                double sum = term(x) + start;

                Console.WriteLine($"y = {y} sum = {sum} ");
            }
        }
        static void exercise_3_1()
        {
            double Pi = Math.PI;
            Task_3_1(0.1, 1, 0.1, Check_1, Term_1, 1);
            Console.WriteLine();
            Task_3_1(Pi / 5, Pi, Pi / 25, Check_2, Term_2, 0);
        }

        delegate void Comp(double x, double y, out double X, out double Y);
        static void Compare1(double x, double y, out double X, out double Y)
        {
            if (x <= y)
            {
                X = x;
                Y = y;
            }
            else
            {
                X = y;
                Y = x;
            }
        }
        static void Compare2(double x, double y, out double X, out double Y)
        {
            if (x >= y)
            {
                X = x;
                Y = y;
            }
            else
            {
                X = y;
                Y = x;
            }
        }
       
        static void Sort(double[,] A, Comp comp ,int nom)
        {
            for(int i = 0; i < A.GetLength(1); i++)
            {
                for(int j = 0; j < A.GetLength(1); j++)
                {
                    comp(A[nom, i], A[nom, j], out A[nom, i], out A[nom, j]);
                }
            }
        }
        static void Task_3_2(double[,] A, int n, int m)
        {
            for(int i = 0; i < n; i++)
            {
                Comp comp = Compare1;
                if (i % 2 == 0)
                {
                    comp = Compare2;
                }
                Sort(A, comp, i);
            }
        }

        static void exercise_3_2()
        {
            string error = "ошибка 3_2";
            int n, m;
            Console.WriteLine("ведите n(n >= 0)");
            if (!InputOutput.CheckRead(out n, error))
            {
                return;
            }
            if (n < 0)
            {
                Console.WriteLine(error);
                return;
            }

            Console.WriteLine("ведите m(m >= 0)");
            if (!InputOutput.CheckRead(out m, error))
            {
                return;
            }
            if (m < 0)
            {
                Console.WriteLine(error);
                return;
            }

            double[,] A = new double[n,m];
            Console.WriteLine($"ведите {n} строк {m} столбца ");

            for (int i = 0; i < n; ++i)
            {
                if (!InputOutput.CheckSplitRead(out List<double> L, error, m))
                {
                    return;
                }
                for (int j = 0; j < m; ++j)
                {

                    double a = L[j];

                    A[i,j] = a;
                }
            }

            Task_3_2(A,n,m);

            string[] S;
            S = ArrayToString(A);
            Console.WriteLine("ans : ");

            foreach (string a in S)
            {
                Console.WriteLine(a);
            }
        }

        static void Main(string[] args)
        {
            /*#region exercise 1_1
            exercise_1_1();
            #endregion*/

            #region exercise 1_2
            exercise_1_2();
            #endregion

            #region exercise 2_6
            exercise_2_6();
            #endregion

            /*#region exercise 2_10
            exercise_2_10();
            #endregion*/

            /*#region exercise 2_23
            exercise_2_23();
            #endregion*/

            /*#region exercise 3_1
            exercise_3_1();
            #endregion*/

            /*#region exercise 3_2
            exercise_3_2();
            #endregion*/

        }

        static string ListToString(List<double> L)
        {
            string s = "";
            foreach (double v in L)
            {
                s += v.ToString();
                s += " ";
            }
            return s;
        }
        static string ArrayToString(double[] L)
        {
            string s = "";
            foreach (double v in L)
            {
                s += v.ToString();
                s += " ";
            }
            return s;
        }
        static string[] ArrayToString(double[][] L ,int n = 0)
        {
            string[] S = new string[n];
            int sh = 0;
            foreach (double[] v in L)
            {
                S[sh] = ArrayToString(v);
                sh++;
            }
            return S;
        }
        static string[] ArrayToString(double[,] L)
        {
            int n = L.GetLength(0), m = L.GetLength(1);
            string[] S = new string[n];
            for (int i = 0; i < n; i++)
            {
                string s = "";
                for (int j = 0; j < m; j++)
                {
                    s += L[i, j].ToString();
                    s += " ";
                }
                S[i] = s;
            }
            return S;
        }
        static int Compare((double, int) x, (double, int) y)
        {
            if (x.Item1 < y.Item1)
            {
                return 1;
            }

            if (x.Item1 > y.Item1)
            {
                return -1;
            }

            return 0;
        }
    }

    static class InputOutput
    {
        const string EndString = "";
        static public void Write(int ans)
        {
            Console.WriteLine("ans : " + ans.ToString());
        }
        static public void Write(double ans)
        {
            Console.WriteLine("ans : " + ans.ToString());
        }
        static public bool Read(out double x)
        {
            string s;
            s = Console.ReadLine();

            if (!double.TryParse(s, out x))
            {
                return false;
            }
            return true;
        }
        static public bool Read(out int x)
        {
            string s;
            s = Console.ReadLine();

            if (!int.TryParse(s, out x))
            {
                return false;
            }
            return true;
        }
        static public bool Read(out int x, out bool fl)
        {
            fl = false;
            string s;
            s = Console.ReadLine();
            if (s == EndString) fl = true;
            if (!int.TryParse(s, out x))
            {
                return fl;
            }
            return true;
        }
        static public bool Read(out double x, out bool fl)
        {
            fl = false;
            string s;
            s = Console.ReadLine();
            if (s == EndString) fl = true;
            if (!double.TryParse(s, out x))
            {
                return fl;
            }
            return true;
        }

        static public bool CheckRead(out double x, string Erorr = "ошибка", string? ans = null)
        {
            bool fl;
            if (!Read(out x, out fl))
            {
                Console.WriteLine(Erorr);
                return false;
            }

            if (fl)
            {
                if (ans != null)
                {
                    Console.WriteLine(ans);
                }
                return false;
            }
            return true;
        }
        static public bool CheckRead(out int x, string Erorr = "ошибка", string? ans = null)
        {
            bool fl;
            if (!Read(out x, out fl))
            {
                Console.WriteLine(Erorr);
                return false;
            }

            if (fl)
            {
                if (ans != null)
                {
                    Console.WriteLine(ans);
                }
                return false;
            }
            return true;
        }
        static public bool CheckSplitRead(out List<double> L, string Erorr = "ошибка", int? kol = null, string? ans = null)
        {
            List<double> l = new List<double>();
            L = l;
            string? s = Console.ReadLine();
            if (s == EndString)
            {
                if (ans != null)
                {
                    Console.WriteLine(ans);
                }
                return false;
            }
            if (s == null)
            {
                Console.WriteLine(Erorr);
                return false;
            }
            string[] S = s.Split(" ");
            foreach (string st in S)
            {
                double x;
                if (st == "") continue;
                if (!double.TryParse(st, out x))
                {
                    Console.WriteLine(Erorr);
                    return false;
                }
                L.Add(x);
            }
            if (kol != null && L.Count() != kol)
            {
                Console.WriteLine("не верное количество элементов в строке");
                return false;
            }
            return true;
        }
    }

}