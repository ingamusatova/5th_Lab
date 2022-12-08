using System;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region level 1 number 1
            Console.WriteLine("--------level 1 number 1--------");
            int a = 5;
            int b1 = 8, b2 = 10, b3 = 11;
            Console.WriteLine("options to assemble a team of {0} people:", a);
            Console.WriteLine("{0} from {1} people", formula(b1, a), b1);
            Console.WriteLine("{0} from {1} people", formula(b2, a), b2);
            Console.WriteLine("{0} from {1} people", formula(b3, a), b3);
            #endregion
            #region level 1 number 2
            Console.WriteLine("--------level 1 number 2--------");
            int[] arr1 = new int[3];
            int[] arr2 = new int[3];
            
            enter(arr1);
            enter(arr2);
            
            double S1 = S(arr1[0], arr1[1], arr1[2], p(arr1[0], arr1[1], arr1[2]));
            double S2 = S(arr2[0], arr2[1], arr2[2], p(arr2[0], arr2[1], arr2[2]));
            if (S1 > S2) Console.WriteLine("S of second triangle is less then first");
            else if (S2 > S1) Console.WriteLine("S of first triangle is less then second");
            else Console.WriteLine("S of triangles is equal");
            #endregion
            #region level 2 number 6
            Console.WriteLine("--------level 2 number 6--------");
            a = 7;
            int b = 8;
            double[] A = new double[a + b - 2];
            Console.WriteLine("Enter elements of array A");
            for(int i = 0; i < a; i++)
            {
                double.TryParse(Console.ReadLine(), out A[i]);
            }
            double[] B = new double[b];
            Console.WriteLine("Enter elements of array B");
            for (int i = 0; i < b; i++)
            {
                double.TryParse(Console.ReadLine(), out B[i]);
            }
            delete(A, a);
            delete(B, b);
            for(int i = a-1; i < a + b - 2; i++)
            {
                A[i] = B[i - a + 1];
            }
            Console.WriteLine("Your array:");
            for(int i = 0; i < a + b - 2; i++)
            {
                Console.Write("{0} ", A[i]);
            }
            Console.WriteLine();
            #endregion
            #region level 2 number 10
            Console.WriteLine("--------level 2 number 10--------");
            Console.WriteLine("Enter amount of rows:");
            int.TryParse(Console.ReadLine(), out a);
            double[,] matrix = new double[a, a];
            Console.WriteLine("Enter elements of matrix:");
            for(int i = 0; i < a; i++)
            {
                for(int j = 0; j < a; j++)
                {
                    double.TryParse(Console.ReadLine(), out matrix[i, j]);
                }
            }
            int index_max = 0;
            int index_min = 1;
            double maxi = matrix[0, 0];
            double mini = matrix[0, 1];
            for(int i = 0; i < a; i++)
            {
                for(int j = 0; j < a; j++)
                {
                    if (i < j)
                    {
                        if (matrix[i, j] < mini)
                        {
                            index_min = j;
                            mini = matrix[i, j];
                        }
                    }
                    else if (matrix[i, j] > maxi)
                    {
                        index_max = j;
                        maxi = matrix[i, j];
                    }
                }
            }
            if (index_max == index_min)
            {
                del_el(matrix, index_min,a);
                b=a-1;
            }
            else
            {
                del_el(matrix, index_min, a);
                del_el(matrix, index_max, a-1);
                b =a-2;
            }
            Console.WriteLine("Your matrix:");
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            #endregion
            #region level 2 number 23
            Console.WriteLine("--------level 2 number 23--------");
            Console.WriteLine("Enter n of 1st matrix");
            int n1, m1,n2,m2;
            int.TryParse(Console.ReadLine(), out n1);
            Console.WriteLine("Enter m of 1st matrix");
            int.TryParse(Console.ReadLine(), out m1);
            double[,] matrix1 = new double[n1, m1];
            Console.WriteLine("Enter n of 2nd matrix");
            int.TryParse(Console.ReadLine(), out n2);
            Console.WriteLine("Enter m of 2nd matrix");
            int.TryParse(Console.ReadLine(), out m2);
            double[,] matrix2 = new double[n2, m2];
            Console.WriteLine("Enter elements of 1st matrix");
            for (int i = 0; i < n1; i++)
            {
                for(int j = 0; j < m1; j++)
                {
                    double.TryParse(Console.ReadLine(), out matrix1[i,j]);
                }
            }
            Console.WriteLine("Enter elements of 2nd matrix");
            for(int i = 0; i < n2; i++)
            {
                for(int j = 0; j < m2; j++)
                {
                    double.TryParse(Console.ReadLine(), out matrix2[i, j]);
                }
            }
            //metod1
            change(matrix1, n1, m1);
            change(matrix2, n2, m2);
            //metod2
            Console.WriteLine("Your 1st matrix:");
            for(int i = 0; i < n1; i++)
            {
                for(int j = 0; j < m1; j++)
                {
                    Console.Write("{0} ", matrix1[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Your 2nd matrix:");
            for(int i = 0; i < n2; i++)
            {
                for(int j = 0; j < m2; j++)
                {
                    Console.Write("{0} ", matrix2[i, j]);
                }
                Console.WriteLine();
            }
            #endregion
            #region level 3 number 1
            Console.WriteLine("--------level 3 number 1--------");
            double a_1 = 0.1, b_1 = 1, h_1 = 0.1;
            double a_2 = Math.PI / 5, b_2 = Math.PI, h_2 = Math.PI / 25;
            Console.WriteLine("S1 = {0}", 1+sum(f1, a_1, b_1, h_1));
            Console.WriteLine("S2 = {0}", sum(f2, a_2, b_2, h_2));
            #endregion
            #region level 3 number 3
            Console.WriteLine("--------level 3 number 3--------");
            int n;
            Console.WriteLine("Enter n");
            int.TryParse(Console.ReadLine(), out n);
            double[] array = new double[n];
            Console.WriteLine("Enter elements of array");
            double summ = 0;
            for (int i = 0; i < n; i++)
            {
                double.TryParse(Console.ReadLine(), out array[i]);
                summ += array[i];
            }
            double average = summ / n;
            if (array[0] > average)
            {
                summ = summi(S_1, array);
            }
            else summ = summi(S_2, array);
            Console.WriteLine("Your array:");
            for(int i = 0; i < n; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Sum = {0}", summ);
            #endregion
        }
        static int factorial(int x)
        {
            int fact = 1;
            for (int i = 1; i < x; i++) fact *= i;
            return fact;
        }
        static double formula(int n, int k)
        {
            double res = factorial(n) / (factorial(k) * factorial(n - k)*1.0);
            return res;
        }
        static double p(int a, int b, int c)
        {
           return (a + b + c) / 2.0;
        }
        static double S(int a, int b, int c, double p)
        {
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        static void delete(double[] array, int n)
        {
            int maxi_index = 0;
            for(int i = 0; i < n; i++)
            {
                if (array[i] > array[maxi_index])
                {
                    maxi_index = i;
                }
            }
            for(int i = maxi_index; i < n - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }
        static void del_el(double[,] matrix, int ji, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for(int j = ji; j < n - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
            }
        }
        static void change(double[,] matrix, int n, int m)
        {
            double[] array = new double[n * m];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[k] = matrix[i, j];
                    k++;
                }
            }
            //sort
            int step = array.Length / 2;
            double temp;
            while (step > 0)
            {
                for (int i = step; i < array.Length; i++)
                {
                    int j = i;
                    while ((j >= step) && array[j - step] < array[j])
                    {
                        temp = array[j - step];
                        array[j - step] = array[j];
                        array[j] = temp;
                        j -= step;
                    }
                }
                step /= 2;
            }
            int count = 0;
            //change
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (matrix[i,j] == array[0] || matrix[i, j] == array[1] || matrix[i, j] == array[2] || matrix[i, j] == array[3]|| matrix[i, j] == array[4])
                    {
                        if (count < 5)
                        {
                            if (matrix[i, j] > 0) matrix[i, j] *= 2;
                            else matrix[i, j] /= 2.0;
                            count++;
                        }
                        else
                        {
                            if (matrix[i, j] > 0) matrix[i, j] /= 2.0;
                            else matrix[i, j] *= 2;
                        }
                    }
                    else
                    {
                        if (matrix[i, j] > 0) matrix[i, j] /= 2.0;
                        else matrix[i, j] *= 2;

                    }
                }
            }

        }
        delegate double fx(double x, int i);
        static int fact(int i)
        {
            int res = 1;
            for (int j = 1; j <= i; j++) res *= j;
            return res;
        }
        static double f1(double x, int i)
        {
            double res= Math.Cos(i * x) / factorial(i);
            return res;
        }
        static double f2(double x, int i)
        {
            double res = Math.Pow(-1, i) * Math.Cos(i * x) / i * i;
            return res;
        }
        static double sum(fx f, double a, double b, double h)
        {
            double res = 0;
            int i = 1;
            for (double x=a; x <= b; x += h)
            {
                res += f(x,i);
                i++;
            }
            return res;
        }
        delegate void wap(double[] a);
        static void S_1(double[] a)
        {
            double temp;
            for(int i = 0; i < a.Length - 1; i += 2)
            {
                temp = a[i + 1];
                a[i + 1] = a[i];
                a[i] = temp;
            }
        }
        static void S_2(double[] a)
        {
            double temp;
            for (int i = a.Length-1; i >0; i -= 2)
            {
                temp = a[i - 1];
                a[i - 1] = a[i];
                a[i] = temp;
            }
        }
        static double summi(wap s, double[] a)
        {
            double res = 0;
            s(a);
            for (int i = 1; i < a.Length; i += 2) res += a[i];
            return res;
        }
        static void enter(int[] a) 
        {
            Console.WriteLine("Enter a, b and c of triangle");
            int.TryParse(Console.ReadLine(), out a[0]);
            int.TryParse(Console.ReadLine(), out a[1]);
            int.TryParse(Console.ReadLine(), out a[2]);
            while (a[0] + a[1] < a[2] || a[0] + a[2] < a[1] || a[1] + a[2] < a[0])
            {
                Console.WriteLine("Error, enter another sides");
                int.TryParse(Console.ReadLine(), out a[0]);
                int.TryParse(Console.ReadLine(), out a[1]);
                int.TryParse(Console.ReadLine(), out a[2]);
            }
        }
    }
}

