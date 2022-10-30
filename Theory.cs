using System;
using System.Collections.Generic;
using System.Linq;
namespace _5th_Lab
{
    class Program
    {
        #region
        public delegate double[] string_sort(double[] row);
        public static double[] for_chet_string(double[] row)
        {
            Array.Sort(row);
            return row;
        }
        public static double[] for_nechet_string(double[] row)
        {
            Array.Sort(row);
            Array.Reverse(row);
            return row;
        }
        #endregion
        #region
        public delegate double max_search(double[] row);
        public static double for_diagonal(double[] row)
        {
            double big = row[0];
            double ind = 0;
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] > big)
                {
                    big = row[i];
                    ind = i;
                }
            }
            return ind;
        }
        public static double for_1_row(double[] row)
        {
            double big = row[0];
            double ind = 0;
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] > big)
                {
                    big = row[i];
                    ind = i;
                }
            }
            return ind;

        }
        #endregion

        static void Main(string[] args)
        {

            static double[] double_array(string str_, int size, ref bool flag)
            {

                double[] fin_arr = new double[size];
                string[] array_1 = str_.Split(' ');
                for (int i = 0; i < size; i++)
                {
                    if (!(array_1.Length == size & double.TryParse(array_1[i], out fin_arr[i])))
                    {
                        Console.WriteLine("input error");
                        flag = true;
                        double[] arr = { };
                        return arr;
                    }
                }
                return fin_arr;
            }
            static double[] min_value_index(double[] array)
            {
                double smallest_value = array[0];
                int smallest_index = 0;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < smallest_value)
                    {
                        smallest_value = array[i];
                        smallest_index = i;
                    }
                }
                double[] fin_array = { smallest_value, smallest_index };
                return fin_array;
            }
            static double[] max_value_index(double[] array)
            {
                double biggest_value = array[0];
                int biggest_index = 0;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > biggest_value)
                    {
                        biggest_value = array[i];
                        biggest_index = i;
                    }
                }
                double[] fin_array = { biggest_value, biggest_index };
                return fin_array;
            }
            static double[,] double_matrix(int rows, int columns, ref bool flag)
            {
                double[,] fin_matrix = new double[rows, columns];
                for (int j = 0; j < rows; j++)
                {
                    Console.WriteLine($"enter row {j}:");
                    string str_ = Console.ReadLine();
                    double[] str_arr = new double[columns];
                    string[] row = str_.Split(' ');
                    for (int i = 0; i < columns; i++)
                    {
                        if (!(row.Length == columns & double.TryParse(row[i], out str_arr[i])))
                        {
                            Console.WriteLine("input error");
                            flag = true;
                            double[,] mat = { };
                            return mat;
                        }
                        fin_matrix[j, i] = str_arr[i];
                    }

                }
                return fin_matrix;
            }
            static void show_matrix(double[,] matrix, int rows, int columns, ref bool flag)
            {
                Console.WriteLine();
                for (int i = 0; i < rows; i++)
                {
                    Console.WriteLine();
                    for (int k = 0; k < columns; k++)
                    {
                        Console.Write($"{matrix[i, k]} ");
                    }
                }
            }


            static int Factorial(int numb)
            {
                int res = 1;
                for (int i = numb; i > 1; i--)
                    res *= i;
                return res;
            }
            static void for_1_1(int candidates, out int quality)
            {
                int k = 5;
                quality = Factorial(candidates) / (Factorial(k) * Factorial(candidates - k));
            }
            static double for_1_2(double a, double b, double c)
            {
                double p = (a + b + c) / 2;
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                return s;
            }//fixed
            static void for_2_6(ref double[] array_in_use_a, ref double[] arrau_in_use_b)
            {
                int ind_to_delete = (int)max_value_index(array_in_use_a)[1];
                for (int i = ind_to_delete; i < array_in_use_a.Length - 1; i++)
                {
                    array_in_use_a[i] = array_in_use_a[i + 1];
                }
                int ind_to_delete2 = (int)max_value_index(arrau_in_use_b)[1];
                for (int i = ind_to_delete2; i < arrau_in_use_b.Length - 1; i++)
                {
                    arrau_in_use_b[i] = arrau_in_use_b[i + 1];
                }
                Array.Resize(ref array_in_use_a, 13);
                for (int i = 6, j = 0; i < array_in_use_a.Length; i++, j++)
                {
                    array_in_use_a[i] = arrau_in_use_b[j];
                }

            }//fixed
            static void for_2_10(double[,] matrix, ref int m, ref int n, int index_column, out double[,] matrix_)
            {
                m -= 1;
                for (int i = index_column; i < m; i++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        matrix[k, i] = matrix[k, i + 1];
                    }
                }
                matrix_ = matrix;
            }
            static void for_2_23(double[,] matrix_in_use, double[] maximus, int n, int m, out double[,] matrix_in_use2)
            {

                int if_1 = 0;
                int if_2 = 0;
                int if_3 = 0;
                int if_4 = 0;
                int if_5 = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k < m; k++)
                    {

                        if (matrix_in_use[i, k] == maximus[0] & if_1 == 0)
                        {
                            matrix_in_use[i, k] *= 2;

                            if_1++;
                        }
                        else if (matrix_in_use[i, k] == maximus[1] & if_2 == 0)
                        {
                            matrix_in_use[i, k] *= 2;

                            if_2++;
                        }
                        else if (matrix_in_use[i, k] == maximus[2] & if_3 == 0)
                        {
                            matrix_in_use[i, k] *= 2;

                            if_3++;
                        }
                        else if (matrix_in_use[i, k] == maximus[3] & if_4 == 0)
                        {
                            matrix_in_use[i, k] *= 2;

                            if_4++;
                        }
                        else if (matrix_in_use[i, k] == maximus[4] & if_5 == 0)
                        {
                            matrix_in_use[i, k] *= 2;

                            if_5++;
                        }
                        else
                        {
                            matrix_in_use[i, k] /= 2;
                        }
                    }
                }
                matrix_in_use2 = matrix_in_use;
            }
            static void for_3_2(double[,] matrix_in_use, int n, int m, out double[,] matrix_in_use2)
            {
                string_sort for_nechet = for_nechet_string;
                string_sort for_chet = for_chet_string;
                double[] row = new double[m];
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        row[k] = matrix_in_use[i, k];
                    }
                    if (i % 2 == 0)
                    {
                        row = for_chet(row);

                    }
                    else row = for_nechet(row);
                    for (int j = 0; j < m; j++)
                    {
                        matrix_in_use[i, j] = row[j];
                    }
                }
                matrix_in_use2 = matrix_in_use;
            }
            static void for_3_6(double[,] matrix_in_use, int n, int m, double ind_1, double ind_2, out double[,] matrix_in_use2)
            {
                for (int i = 0; i < n; i++)
                {
                    double p = matrix_in_use[i, (int)ind_1];
                    matrix_in_use[i, (int)ind_1] = matrix_in_use[i, (int)ind_2];
                    matrix_in_use[i, (int)ind_2] = p;
                }
                matrix_in_use2 = matrix_in_use;
            }
            task_2_23();

            static void task_1_1()
            {
                int quality = 0;
                int candidates = 8;
                for (int i = 0; i < 3; i++)
                {
                    if (i == 1)
                    {
                        candidates = 10;
                    }
                    if (i == 2)
                    {
                        candidates = 11;
                    }
                    for_1_1(candidates, out quality);
                    Console.WriteLine($"answer for {candidates} candidstes: {quality}");

                }


            }
            static void task_1_2()
            {
                double a_1;
                double a_2;
                double b_1;
                double b_2;
                double c_1;
                double c_2;
                double s1 = 0;
                double s2 = 0;

                Console.WriteLine("enter a for 1 triangle:");
                bool res_1a = double.TryParse(Console.ReadLine(), out a_1);
                Console.WriteLine("enter b for 1 triangle:");
                bool res_1b = double.TryParse(Console.ReadLine(), out b_1);
                Console.WriteLine("enter c for 1 triangle:");
                bool res_1c = double.TryParse(Console.ReadLine(), out c_1);
                Console.WriteLine("enter a for 2 triangle:");
                bool res_2a = double.TryParse(Console.ReadLine(), out a_2);
                Console.WriteLine("enter b for 2 triangle:");
                bool res_2b = double.TryParse(Console.ReadLine(), out b_2);
                Console.WriteLine("enter c for 2 triangle:");
                bool res_2c = double.TryParse(Console.ReadLine(), out c_2);
                if  (!(a_1 < b_1+c_1 && a_2 < b_2+c_2&& b_1< a_1+c_1 && b_2<a_2+c_2&&c_1<a_1 + b_1 && c_2 < a_2 + b_2))
                {
                    Console.WriteLine("input error");
                    return;
                }


                if (!(res_1b & res_1a & res_1c & res_2a & res_2b & res_2c))
                {
                    Console.WriteLine("input error");
                    return;
                }
                if (!(a_1 > 0 & b_1 > 0 & c_1 > 0 & a_2 > 0 & b_2 > 0 & c_2 > 0))
                {
                    Console.WriteLine("input error");
                    return;
                }
                 s1 =for_1_2(a_1, b_1, c_1);
                Console.WriteLine($"s1= {s1}");
                s2 = for_1_2(a_2, b_2, c_2);
                Console.WriteLine($"s2= {s2}");
                if (s1 > s2)
                {
                    Console.WriteLine("s1 > s2");
                }
                else if (s2 > s1)
                {
                    Console.WriteLine("s2 > s1");
                }
                else
                {
                    Console.WriteLine("s2 = s1");
                }

            }//fixed


            static void task_2_6()
            {
                bool flag = false;
                int n = 7;
                Console.WriteLine("enter array A data:");
                string str_ = Console.ReadLine();
                double[] array_in_use_a = double_array(str_, n, ref flag);
                int m = 8;
                Console.WriteLine("enter array B data:");
                string str_1 = Console.ReadLine();
                double[] array_in_use_b = double_array(str_1, m, ref flag);
                if (flag)
                {
                    Console.WriteLine("input error");
                    return;
                }

                for_2_6(ref array_in_use_a,ref array_in_use_b);

                foreach (double elem in array_in_use_a)
                {
                    Console.Write($"{elem}\t");
                }


            }//fixed
            static void task_2_10()
            {
                bool flag = false;
                int n;

                Console.WriteLine("enter n:");
                bool res = int.TryParse(Console.ReadLine(), out n);

                if (!(res & n > 0)) return;
                Console.WriteLine("enter matrix data:");
                int m = n;
                double[,] matrix_in_use = double_matrix(n, m, ref flag);
                if (flag)
                {
                    Console.WriteLine("input error");
                    return;
                }
                show_matrix(matrix_in_use, n, m, ref flag);
                double smallest = matrix_in_use[0, 1];
                int ind_column = 1;
                for (int k = 0; k < n; k++)
                {
                    for (int i = 0; i < n - k - 1; i++)
                    {
                        if (matrix_in_use[k, k + 1 + i] < smallest)
                        {
                            smallest = matrix_in_use[k, k + 1 + i];
                            ind_column = i;
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine(smallest);
                double biggest = matrix_in_use[0, 0];
                int ind_column_2 = 0;
                for (int k = 0; k < n; k++)
                {

                    for (int i = 0; i < k + 1; i++)
                    {

                        if (matrix_in_use[k, i] > biggest)
                        {
                            biggest = matrix_in_use[k, i];
                            ind_column_2 = i;
                        }
                        if (i == k) break;
                    }
                }
                Console.WriteLine(biggest);
                for_2_10(matrix_in_use, ref m, ref n, ind_column, out matrix_in_use);
                for_2_10(matrix_in_use, ref m, ref n, ind_column_2 - 1, out matrix_in_use);
                show_matrix(matrix_in_use, n, m, ref flag);



            }
            static void task_2_23()
            {
                bool flag = false;
                int n;
                int m;
                Console.WriteLine("both matrix have to contain at least 5 elements: minimal size is 3/2 or 2/3(n+m>=5):");
                Console.WriteLine("enter n:");
                bool res = int.TryParse(Console.ReadLine(), out n);
                Console.WriteLine("enter m:");
                bool res2 = int.TryParse(Console.ReadLine(), out m);

                if (!(res & n > 0 & m > 0 & res2&n+m>=5)) return;
                Console.WriteLine("enter matrix data:");

                double[,] matrix_in_use = double_matrix(n, m, ref flag);
                if (flag)
                {
                    Console.WriteLine("input error");
                    return;
                }

                double[] matrix_array = new double[n * m];
                int j = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        matrix_array[j] = matrix_in_use[i, k];
                        j++;
                    }
                }
                Array.Sort(matrix_array);
                double[] maximus = new double[5];
                for (int i = n * m - 1, k = 0; i >= n * m - 5; i--, k++)
                {
                    maximus[k] = matrix_array[i];
                }
                for_2_23(matrix_in_use, maximus, n, m, out matrix_in_use);

                show_matrix(matrix_in_use, n, m, ref flag);



                Console.WriteLine("enter n:");
                bool res1 = int.TryParse(Console.ReadLine(), out n);
                Console.WriteLine("enter m:");
                bool res21 = int.TryParse(Console.ReadLine(), out m);

                if (!(res1 & n > 0 & m > 0 & res21&n+m>=5)) return;
                Console.WriteLine("enter matrix data:");

                double[,] matrix_in_use1 = double_matrix(n, m, ref flag);
                if (flag)
                {
                    Console.WriteLine("input error");
                    return;
                }

                double[] matrix_array1 = new double[n * m];
                int g = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        matrix_array1[g] = matrix_in_use1[i, k];
                        g++;
                    }
                }
                Array.Sort(matrix_array1);
                double[] maximus1 = new double[5];
                for (int i = n * m - 1, k = 0; i >= n * m - 5; i--, k++)
                {
                    maximus1[k] = matrix_array1[i];
                }
                for_2_23(matrix_in_use1, maximus1, n, m, out matrix_in_use1);

                show_matrix(matrix_in_use1, n, m, ref flag);



            }//fixed


            static void task_3_2()
            {
                bool flag = false;
                int n;
                int m;
                Console.WriteLine("enter n:");
                bool res = int.TryParse(Console.ReadLine(), out n);
                Console.WriteLine("enter m:");
                bool res2 = int.TryParse(Console.ReadLine(), out m);

                if (!(res & n > 0 & m > 0 & res2)) return;
                Console.WriteLine("enter matrix data:");

                double[,] matrix_in_use = double_matrix(n, m, ref flag);
                if (flag)
                {
                    Console.WriteLine("input error");
                    return;
                }
                for_3_2(matrix_in_use, n, m, out matrix_in_use);

                show_matrix(matrix_in_use, n, m, ref flag);

            }
            static void task_3_6()
            {
                bool flag = false;
                int n;
                int m;
                Console.WriteLine("enter n:");
                bool res = int.TryParse(Console.ReadLine(), out n);
                m = n;

                if (!(res & n > 0)) return;
                Console.WriteLine("enter matrix data:");

                double[,] matrix_in_use = double_matrix(n, m, ref flag);
                if (flag)
                {
                    Console.WriteLine("input error");
                    return;
                }
                show_matrix(matrix_in_use, n, m, ref flag);

                double[] row_d = new double[n];
                int j = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        if (i == k)
                        {
                            row_d[j] = matrix_in_use[i, k];
                            j++;
                            break;
                        }
                    }
                }
                double[] row_f = new double[n];

                for (int i = 0; i < n; i++)
                {
                    row_f[i] = matrix_in_use[0, i];
                }
                max_search diag_ind = for_diagonal;
                max_search first_ind = for_1_row;
                double ind_1 = diag_ind(row_d);
                double ind_2 = first_ind(row_f);
                for_3_6(matrix_in_use, n, m, ind_1, ind_2, out matrix_in_use);


                show_matrix(matrix_in_use, n, m, ref flag);



            }



        }
    }
}

