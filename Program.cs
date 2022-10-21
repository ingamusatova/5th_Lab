using System;
namespace _1st_Lab
{
    class Program
    {

        static int factorial(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("incorrect format");
                return 1;
            }

            if (n == 0 || n == 1)
            {
                return 1;
            }

            int f = 1;

            for (int i = 2; i <= n; ++i)
            {
                f *= i;
            }

            return f;

        }

        static int combination(int n, int k)
        {
            int c;
            c = factorial(n) / (factorial(k) * factorial(n - k));
            return c;
        }

        static double geron(double[] lengths)
        {
            double a, b, c;
            (a, b, c) = (lengths[0], lengths[1], lengths[2]);

            double p = (a + b + c) / 2;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        static bool check_triangle(double[] lengths)
        {
            double a, b, c;
            (a, b, c) = (lengths[0], lengths[1], lengths[2]);

            if (Math.Max(a, Math.Max(b, c)) * 2 <= a + b + c && a >= 0 && b >= 0 && c >= 0)
            {
                return true;
            }
            return false;
        }

        static double[] remove_idx(double[] x, int idx)
        {
            double[] res = new double[x.Length - 1];
            int j = 0;

            for (int i = 0; i < x.Length; i++)
            {
                if (i == idx)
                {
                    continue;
                }
                res[j] = x[i];
                j++;
            }
            return res;
        }

        static double[] merge_arrays(double[] a, double[] b)
        {
            double[] res = new double[a.Length + b.Length];

            for (int i = 0; i < a.Length; i++)
            {
                res[i] = a[i];
            }
            for (int i = 0; i < b.Length; i++)
            {
                res[i + a.Length] = b[i];
            }
            return res;
        }

        static string array2string(double[] x)
        {
            string res = "";

            foreach (double v in x)
            {
                res += v.ToString();
                res += " ";
            }
            return res;
        }

        static double[,] remove_column(double[,] x, int idx)
        {
            int n = x.GetLength(0), m = x.GetLength(1);
            double[,] res = new double[n, m - 1];

            for (int i = 0; i < n; i++)
            {
                int jj = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == idx)
                    {
                        continue;
                    }

                    res[i, jj] = x[i, j];
                    jj++;
                }
            }
            return res;
        }

        static string[] matrix2string(double[,] x)
        {
            int n = x.GetLength(0), m = x.GetLength(1);
            string[] array = new string[n];

            for (int i = 0; i < n; i++)
            {
                string str = "";
                for (int j = 0; j < m; j++)
                {
                    str += x[i, j].ToString();
                    str += " ";
                }
                array[i] = str;
            }
            return array;
        }

        static double[] find_5_maximums(double[,] x)
        {
            int n = x.GetLength(0), m = x.GetLength(1);
            List<double> tmp = new List<double>(n + m);
            double[] res = new double[5];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    tmp.Add(x[i, j]);
                }
            }

            tmp.Sort();

            int k = 0;
            for (int i = n + m - 5; i <= n + m - 1; i++)
            {
                res[k] = tmp[i];
                k++;
            }
            return res;
        }

        static bool is_in_array(double[] arr, double value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        static double[,] update_matrix(double[,] x)
        {
            int n = x.GetLength(0), m = x.GetLength(1);
            double[,] res = new double[n, m];

            double[] maximums = find_5_maximums(x);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    double value;
                    value = x[i, j];

                    if (is_in_array(maximums, value))
                    {
                        value *= 2;
                    }
                    else
                    {
                        value /= 2;
                    }

                    res[i, j] = value;
                }
            }

            return res;
        }

        delegate double element(double x);
        delegate double check(double x);
        const double eps = 0.0001;

        static double element1(double x)
        {
            double res = 0;
            double denominator = 1;
            int i = 1;
            double term = 0.0;

            do
            {
                denominator *= i;
                term = Math.Cos(i * x) / denominator;
                res += term;
                i++;
            } while (term > eps);

            return res;
        }

        static double y1(double x)
        {
            return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }

        static double element2(double x)
        {
            double res = 0;
            double sign = -1;
            int i = 1;
            double term = 0;

            do
            {
                term = sign * Math.Cos(i * x) / (i * i);
                sign = -sign;
                res += term;
            } while (term > eps);
            return res;
        }

        static double y2(double x)
        {
            double pi = Math.PI;
            return (x * x - (pi * pi) / 3.0) / 4.0;
        }

        static void task_3_1(double a, double b, double h, check y, element elem, double start)
        {
            for (double x = a; x <= b; x += h)
            {
                double yy = y(x);
                double sum = elem(x) + start;
                Console.WriteLine($"y = {yy} sum = {sum}");
            }
        }

        delegate void compare(double a, double b, out double first, out double second);

        static void compare1(double a, double b, out double first, out double second)
        {
            if (a <= b)
            {
                first = a;
                second = b;
            }
            else
            {
                first = b;
                second = a;
            }
        }

        static void compare2(double a, double b, out double first, out double second)
        {
            if (a >= b)
            {
                first = a;
                second = b;
            }
            else
            {
                first = b;
                second = a;
            }
        }

        static void matrix_sort(double[,] x, compare comparer, int idx)
        {
            int col_dim = x.GetLength(1);

            for (int i = 0; i < col_dim; i++)
            {
                for (int j = 0; j < col_dim; j++)
                {
                    comparer(x[idx, i], x[idx, j], out x[idx, j], out x[idx, i]);
                }
            }
        }

        static void task_3_2(double[,] x, int n)
        {
            for (int i = 0; i < n; i++)
            {
                compare comparer = compare1;

                if (i % 2 == 1)
                {
                    comparer = compare1;
                }
                else
                {
                    comparer = compare2;
                }

                matrix_sort(x, comparer, i);
            }
        }

        static void Main(string[] args)
        {

            #region level 1
            Console.WriteLine("level 1");

            #region task 1
            Console.WriteLine("task 1");
            {
                Console.WriteLine(combination(8, 5));
                Console.WriteLine(combination(10, 5));
                Console.WriteLine(combination(11, 5));
            }
            #endregion

            #region task 2
            Console.WriteLine("task 2");
            {

                Console.WriteLine("enter lengths of the triangle 1");
                string[] row_string = Console.ReadLine().Split(" ");
                double[] triangle1 = new double[3];
                double tmp;

                if (row_string.Count() != 3)
                {
                    Console.WriteLine("incorrect format");
                    return;
                }

                int i = -1;
                foreach (string elem in row_string)
                {
                    if (!double.TryParse(elem, out tmp))
                    {
                        Console.WriteLine("incorrect format");
                        return;
                    }
                    i++;
                    triangle1[i] = tmp;
                }

                if (!check_triangle(triangle1))
                {
                    Console.WriteLine("impossible triangle");
                    return;
                }

                double s1 = geron(triangle1);


                Console.WriteLine("enter lengths of the triangle 2");
                row_string = Console.ReadLine().Split(" ");
                double[] triangle2 = new double[3];

                if (row_string.Count() != 3)
                {
                    Console.WriteLine("incorrect format");
                    return;
                }

                i = -1;
                foreach (string elem in row_string)
                {
                    if (!double.TryParse(elem, out tmp))
                    {
                        Console.WriteLine("incorrect format");
                        return;
                    }
                    i++;
                    triangle2[i] = tmp;
                }

                if (!check_triangle(triangle2))
                {
                    Console.WriteLine("impossible triangle");
                    return;
                }

                double s2 = geron(triangle2);

                Console.WriteLine(Math.Max(s1, s2));
            }
            #endregion

            #endregion

            #region level 2
            Console.WriteLine("level 2");

            #region task 6
            Console.WriteLine("task 6");
            {
                int n = 7, m = 8;
                int idx_a = 0, idx_b = 0;
                double[] a = new double[n], b = new double[m], c = new double[n + m - 2];

                Console.WriteLine($"enter {n} values");

                string[] row_string = Console.ReadLine().Split(" ");

                if (row_string.Length != n)
                {
                    Console.WriteLine("incorrect format");
                    return;
                }
                int i = -1;
                foreach (string elem in row_string)
                {
                    double value;
                    if (!double.TryParse(elem, out value))
                    {
                        Console.WriteLine("incorrect format");
                        return;
                    }
                    i++;
                    a[i] = value;

                    if (a[idx_a] < a[i])
                    {
                        idx_a = i;
                    }
                }

                Console.WriteLine($"enter {n} values");

                row_string = Console.ReadLine().Split(" ");

                if (row_string.Length != m)
                {
                    Console.WriteLine("incorrect format");
                    return;
                }
                i = -1;
                foreach (string elem in row_string)
                {
                    double value;
                    if (!double.TryParse(elem, out value))
                    {
                        Console.WriteLine("incorrect format");
                        return;
                    }
                    i++;
                    b[i] = value;

                    if (b[idx_b] < b[i])
                    {
                        idx_b = i;
                    }
                }

                c = merge_arrays(remove_idx(a, idx_a), remove_idx(b, idx_b));

                Console.WriteLine(array2string(c));
            }
            #endregion

            #region task 10
            Console.WriteLine("task 10");
            {
                int n;

                Console.WriteLine("enter n");

                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    {
                        Console.WriteLine("incorrect format, try again");
                        continue;
                    }
                    break;
                }

                Console.WriteLine($"enter {n} rows {n} columns");
                double[,] a = new double[n, n];
                int min_i = 0, max_i = 0, min_j = 0, max_j = 0;

                for (int i = 0; i < n; i++)
                {
                    string[] row_string = Console.ReadLine().Split(" ");

                    if (row_string.Count() != n)
                    {
                        Console.WriteLine("incorrect format");
                        return;
                    }

                    int j = -1;
                    foreach (string elem in row_string)
                    {
                        double value;
                        if (!double.TryParse(elem, out value))
                        {
                            Console.WriteLine("incorrect format");
                            return;
                        }
                        j++;
                        a[i, j] = value;

                        if (j < i && (a[max_i, max_j] < value || (max_i == 0 && max_j == 0)))
                        {
                            max_j = j;
                            max_i = i;
                        }

                        if (j > i && (a[min_i, min_j] > value || (min_i == 0 && min_j == 0)))
                        {
                            min_j = j;
                            min_i = i;
                        }
                    }
                }

                if (min_j > max_j)
                {
                    (min_j, max_j) = (max_j, min_j);
                }

                string[] ans = matrix2string(remove_column(remove_column(a, min_j), max_j - 1));
                foreach (string s in ans)
                {
                    Console.WriteLine(s);
                }
            }
            #endregion

            #region task 23
            Console.WriteLine("task 23");
            {
                int n1, m1, n2, m2;

                Console.WriteLine("enter n1");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out n1) || n1 <= 0)
                    {
                        Console.WriteLine("incorrect format, try again");
                        continue;
                    }
                    break;
                }

                Console.WriteLine("enter m1");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out m1) || m1 <= 0)
                    {
                        Console.WriteLine("incorrect format, try again");
                        continue;
                    }
                    break;
                }

                Console.WriteLine($"enter {n1} rows {m1} columns");
                double[,] a = new double[n1, m1];

                for (int i = 0; i < n1; i++)
                {
                    string[] row_string = Console.ReadLine().Split(" ");

                    if (row_string.Count() != m1)
                    {
                        Console.WriteLine("incorrect format");
                        return;
                    }

                    int j = -1;
                    foreach (string elem in row_string)
                    {
                        double value;
                        if (!double.TryParse(elem, out value))
                        {
                            Console.WriteLine("incorrect format");
                            return;
                        }
                        j++;
                        a[i, j] = value;
                    }
                }

                Console.WriteLine("enter n2");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out n2) || n2 <= 0)
                    {
                        Console.WriteLine("incorrect format, try again");
                        continue;
                    }
                    break;
                }

                Console.WriteLine("enter m2");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out m2) || m2 <= 0)
                    {
                        Console.WriteLine("incorrect format, try again");
                        continue;
                    }
                    break;
                }

                Console.WriteLine($"enter {n2} rows {m2} columns");
                double[,] b = new double[n2, m2];

                for (int i = 0; i < n2; i++)
                {
                    string[] row_string = Console.ReadLine().Split(" ");

                    if (row_string.Count() != m2)
                    {
                        Console.WriteLine("incorrect format");
                        return;
                    }

                    int j = -1;
                    foreach (string elem in row_string)
                    {
                        double value;
                        if (!double.TryParse(elem, out value))
                        {
                            Console.WriteLine("incorrect format");
                            return;
                        }
                        j++;
                        b[i, j] = value;
                    }
                }

                string[] ans1 = matrix2string(update_matrix(a));
                string[] ans2 = matrix2string(update_matrix(b));

                foreach (string str in ans1)
                {
                    Console.WriteLine(str);
                }

                Console.WriteLine("********");

                foreach (string str in ans2)
                {
                    Console.WriteLine(str);
                }
            }
            #endregion

            #endregion

            #region level 3
            Console.WriteLine("level 3");

            #region task 1
            Console.WriteLine("task 1");
            {
                double pi = Math.PI;
                task_3_1(0.1, 1.0, 0.1, y1, element1, 1);
                Console.WriteLine("***********");
                task_3_1(pi / 5, pi, pi / 25, y2, element2, 0);
            }
            #endregion

            #region task 2
            Console.WriteLine("task 2");
            {
                int n, m;

                Console.WriteLine("enter n");

                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    {
                        Console.WriteLine("incorrect format, try again");
                        continue;
                    }
                    break;
                }

                Console.WriteLine("enter m");

                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
                    {
                        Console.WriteLine("incorrect format, try again");
                        continue;
                    }
                    break;
                }

                Console.WriteLine($"enter {n} rows {m} columns");
                double[,] a = new double[n, m];

                for (int i = 0; i < n; i++)
                {
                    string[] row_string = Console.ReadLine().Split(" ");

                    if (row_string.Count() != n)
                    {
                        Console.WriteLine("incorrect format");
                        return;
                    }

                    int j = -1;
                    foreach (string elem in row_string)
                    {
                        double value;
                        if (!double.TryParse(elem, out value))
                        {
                            Console.WriteLine("incorrect format");
                            return;
                        }
                        j++;
                        a[i, j] = value;
                    }
                }

                task_3_2(a, n);
                string[] ans = matrix2string(a);

                foreach (string s in ans)
                {
                    Console.WriteLine(s);
                }
            }
            #endregion

            #endregion

        }
    }
}