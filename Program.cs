using System;


namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            //goto used to test the tasks faster, not as a part of the program

            //goto random_input_generator;

            //goto task_2_lv1;

            //goto task_6_lv2;
            //goto task_10_lv2;
            //goto task_23_lv2;

            //goto task_2_lv3;
            //goto task_6_lv3;


            #region task 1 lv1

            Console.WriteLine("Task 1 (level 1)");

            Console.WriteLine($"{choose(8, 5)} teams from 8 candidates.");
            Console.WriteLine($"{choose(10, 5)} teams from 10 candidates.");
            Console.WriteLine($"{choose(11, 5)} teams from 11 candidates.");

            Console.ReadLine();
        #endregion

        task_2_lv1:
            #region task 2 lv1

            Console.WriteLine("Task 2 (level 1)");

            double a1, b1, c1, a2, b2, c2;
            bool try_x;

            Console.WriteLine("Enter the sides of the 1st triangle.");

            try_x = double.TryParse(Console.ReadLine(), out a1);
            if ((!try_x) || (a1 <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            try_x = double.TryParse(Console.ReadLine(), out b1);
            if ((!try_x) || (b1 <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            try_x = double.TryParse(Console.ReadLine(), out c1);
            if ((!try_x) || (c1 <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            double[] sides = { a1, b1, c1 };
            Array.Sort(sides);

            if (sides[0] + sides[1] <= sides[2])
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"1st triangle: {a1}; {b1}; {c1}. S = {geron(a1, b1, c1)}.");

            Console.WriteLine();
            Console.WriteLine("Enter the sides of the 2nd triangle.");

            try_x = double.TryParse(Console.ReadLine(), out a2);
            if ((!try_x) || (a2 <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            try_x = double.TryParse(Console.ReadLine(), out b2);
            if ((!try_x) || (b2 <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            try_x = double.TryParse(Console.ReadLine(), out c2);
            if ((!try_x) || (c2 <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            sides = new double[] { a2, b2, c2 };
            Array.Sort(sides);

            if (sides[0] + sides[1] <= sides[2])
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"2nd triangle: {a2}; {b2}; {c2}. S = {geron(a2, b2, c2)}.");
            Console.WriteLine();

            if (geron(a2, b2, c2) > geron(a1, b1, c1))
            {
                Console.WriteLine("The 2nd triangle's surface area is bigger.");
            }

            else if (geron(a2, b2, c2) < geron(a1, b1, c1))
            {
                Console.WriteLine("The 1st triangle's surface area is bigger.");
            }

            else
            {
                Console.WriteLine("The surface areas are equal.");
            }

            Console.ReadLine();
        #endregion

        task_6_lv2:
            #region task 6 lv2

            Console.WriteLine("Task 6 (level 2)");

            double[] a = new double[7];
            double[] b = new double[8];

            Console.WriteLine("Enter the value of the array A (7).");

            for (int i = 0; i < 7; i++)
            {
                try_x = double.TryParse(Console.ReadLine(), out a[i]);
                if (!try_x)
                {
                    Console.WriteLine("Invalid input.");
                    Console.ReadLine();
                    return;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Enter the value of the array B (8).");

            for (int i = 0; i < 8; i++)
            {
                try_x = double.TryParse(Console.ReadLine(), out b[i]);
                if (!try_x)
                {
                    Console.WriteLine("Invalid input.");
                    Console.ReadLine();
                    return;
                }
            }

            double max = a[0];
            int max_i = 0;

            for (int i = 1; i < 7; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                    max_i = i;
                }
            }

            a = delete_elem(a, max_i);

            max = b[0];
            max_i = 0;

            for (int i = 1; i < 8; i++)
            {
                if (b[i] > max)
                {
                    max = b[i];
                    max_i = i;
                }
            }

            b = delete_elem(b, max_i);

            double[] temp_array = new double[13];

            for (int i = 0; i < 13; i++)
            {
                if (i < 6)
                {
                    temp_array[i] = a[i];
                }
                else
                {
                    temp_array[i] = b[i - 6];
                }
            }

            a = (double[])temp_array.Clone();

            Console.WriteLine();
            Console.WriteLine("Here is your new array:");

            foreach (double val in a)
            {
                Console.Write($"{val} ");
            }

            Console.ReadLine();
        #endregion

        task_10_lv2:
            #region task 10 lv2

            Console.WriteLine("Task 10 (level 2)");
            Console.WriteLine("Enter the value of N.");

            int n;

            try_x = int.TryParse(Console.ReadLine(), out n);
            if ((!try_x) || (n <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            double[,] matrix = new double[n, n];

            Console.WriteLine("Enter the values of the NxN matrix.");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    try_x = double.TryParse(Console.ReadLine(), out matrix[i, j]);
                    if (!try_x)
                    {
                        Console.WriteLine("Invalid input.");
                        Console.ReadLine();
                        return;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Here is your matrix:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j],5}  ");
                }
                Console.WriteLine();
            }


            max = matrix[0, 0];
            max_i = 0;
            int max_j = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        max_i = i;
                        max_j = j;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"The max value below main diagonal (or on it) is {max} ({max_i}; {max_j})");

            double min = matrix[0, 0];
            int min_i = 0;
            int min_j = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        min_i = i;
                        min_j = j;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"The min value above main diagonal is {min} ({min_i}; {min_j})");

            matrix = delete_column(matrix, n, n, max_j);
            int m = n - 1;
            double[,] temp_matrix = (double[,])matrix.Clone();

            matrix = delete_column(matrix, n, m, min_j);
            if (matrix != temp_matrix)
            {
                m--;
            }

            Console.WriteLine();
            Console.WriteLine("Here is your new matrix:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}  ");
                }
                Console.WriteLine();
            }



            Console.ReadLine();
        #endregion

        task_23_lv2:
            #region task 23 lv2

            Console.WriteLine("Task 23 (level 2)");

            Console.WriteLine("Enter the value of N of the 1st matrix.");
            try_x = int.TryParse(Console.ReadLine(), out n);
            if ((!try_x) || (n <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter the value of M of the 1st matrix.");
            try_x = int.TryParse(Console.ReadLine(), out m);
            if ((!try_x) || (m <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            matrix = new double[n, m];

            Console.WriteLine("Enter the values of the NxM matrix.");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    try_x = double.TryParse(Console.ReadLine(), out matrix[i, j]);
                    if (!try_x)
                    {
                        Console.WriteLine("Invalid input.");
                        Console.ReadLine();
                        return;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Here is your 1st matrix:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}  ");
                }
                Console.WriteLine();
            }

            temp_matrix = (double[,])matrix.Clone();
            min = matrix[0, 0];
            min_i = 0;
            min_j = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        min_i = i;
                        min_j = j;
                    }
                }
            }


            double[,] map_matrix = new double[n, m];

            for (int count = 1; count <= 5; count++)
            {
                max = matrix[0, 0];
                max_i = 0;
                max_j = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                            max_i = i;
                            max_j = j;
                        }
                    }
                }
                Console.WriteLine($"Maximum {count}: {max} ({max_i}; {max_j})");
                map_matrix[max_i, max_j] = max;
                matrix[max_i, max_j] = min;
            }

            matrix = transform(temp_matrix, n, m, map_matrix);

            Console.WriteLine();
            Console.WriteLine("Here is your new matrix (1):");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter the value of N of the 2nd matrix.");
            try_x = int.TryParse(Console.ReadLine(), out n);
            if ((!try_x) || (n <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter the value of M of the 2nd matrix.");
            try_x = int.TryParse(Console.ReadLine(), out m);
            if ((!try_x) || (m <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            matrix = new double[n, m];

            Console.WriteLine("Enter the values of the NxM matrix.");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    try_x = double.TryParse(Console.ReadLine(), out matrix[i, j]);
                    if (!try_x)
                    {
                        Console.WriteLine("Invalid input.");
                        Console.ReadLine();
                        return;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Here is your 2nd matrix:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}  ");
                }
                Console.WriteLine();
            }

            temp_matrix = (double[,])matrix.Clone();
            min = matrix[0, 0];
            min_i = 0;
            min_j = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        min_i = i;
                        min_j = j;
                    }
                }
            }


            map_matrix = new double[n, m];

            for (int count = 1; count <= 5; count++)
            {
                max = matrix[0, 0];
                max_i = 0;
                max_j = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                            max_i = i;
                            max_j = j;
                        }
                    }
                }
                Console.WriteLine($"Maximum {count}: {max} ({max_i}; {max_j})");
                map_matrix[max_i, max_j] = max;
                matrix[max_i, max_j] = min;
            }

            matrix = transform(temp_matrix, n, m, map_matrix);

            Console.WriteLine();
            Console.WriteLine("Here is your new matrix (2):");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}  ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        #endregion


        task_2_lv3:
            #region task 2 lv3
            Console.WriteLine("Task 2 (level 3)");



            /*double[] the = { 3, 2, 4, 0, -9};
            the = sort_desc(the, 5);

            foreach (double val in the)
            {
                Console.WriteLine(val);
            }*/



            Console.WriteLine("Enter the N value.");
            try_x = int.TryParse(Console.ReadLine(), out n);

            if ((!try_x) || (n <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Enter the M value.");
            try_x = int.TryParse(Console.ReadLine(), out m);

            if ((!try_x) || (n <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Enter the values of the NxM matrix.");

            matrix = new double[n, m];
            double x;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    try_x = double.TryParse(Console.ReadLine(), out x);

                    if (!try_x)
                    {
                        Console.WriteLine("Invalid input.");
                        Console.ReadLine();
                        return;
                    }

                    matrix[i, j] = x;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Here is your matrix:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}  ");
                }
                Console.WriteLine();
            }


            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    matrix = process(sort_asc, matrix, i, m);
                }

                else
                {
                    matrix = process(sort_desc, matrix, i, m);
                }

            }

            Console.WriteLine();
            Console.WriteLine("Here is your new matrix:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}  ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        #endregion

        task_6_lv3:
            #region task 6 lv3
            Console.WriteLine("Task 6 (level 3)");

            Console.WriteLine("Enter the N value.");
            try_x = int.TryParse(Console.ReadLine(), out n);

            if ((!try_x) || (n <= 0))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Enter the values of the NxN matrix.");

            m = n;
            matrix = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    try_x = double.TryParse(Console.ReadLine(), out x);

                    if (!try_x)
                    {
                        Console.WriteLine("Invalid input.");
                        Console.ReadLine();
                        return;
                    }

                    matrix[i, j] = x;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Here is your matrix:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}  ");
                }
                Console.WriteLine();
            }

            matrix = replace(search_diagonal, search_first, matrix, n, m);


            Console.WriteLine();
            Console.WriteLine("Here is your new matrix:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}  ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        #endregion


        random_input_generator:
            #region random input generator

            Console.WriteLine();
            Console.WriteLine("RNG:");
            Console.WriteLine();

            Random r = new Random();
            for (int i = 0; i < 7 * 7; i++)
            {
                Console.WriteLine($"{r.Next(100)}");
            }

            Console.ReadLine();
            #endregion

        }

    
        #region methods

        #region factorial
        static int factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else if (x < 0)
            {
                return 0;
            }

            int s = 1;
            for (int i = 1; i <= x; i++)
            {
                s *= i;
            }
            return s;
        }
        #endregion

        #region choose
        static int choose(int n, int k)
        {
            int c;
            c = factorial(n) / (factorial(k) * factorial(n - k));
            return c;
        }
        #endregion

        #region geron
        static double geron(double a, double b, double c)
        {
            double s;
            double p = (a + b + c) / 2.0;
            s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }
        #endregion

        #region delete_elem
        static double[] delete_elem(double[] a, int ind)
        {
            double[] b = new double[a.Length - 1];
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (i != ind)
                {
                    b[count] = a[i];
                    count++;
                }
            }
            return b;
        }
        #endregion

        #region delete_column
        static double[,] delete_column(double[,] a, int n, int m, int ind)
        {
            double[,] b = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < ind; j++)
                {
                    b[i, j] = a[i, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = ind; j < m - 1; j++)
                {
                    b[i, j] = a[i, j + 1];
                }
            }
            return b;
        }
        #endregion

        #region transform
        static double[,] transform(double[,] a, int n, int m, double[,] map)
        {
            double[,] b = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (map[i, j] != 0)
                    {
                        b[i, j] = map[i, j] * 2;
                    }
                    else
                    {
                        b[i, j] = a[i, j] / 2.0;
                    }
                }
            }

            return b;
        }
        #endregion

        #region replace
        static double[,] replace(search s1, search s2, double[,] a, int n, int m)
        {
            double temp;
            int j1 = s1(a, n, m);
            int j2 = s2(a, n, m);
            for (int i = 0; i < n; i++)
            {
                temp = a[i, j1];
                a[i, j1] = a[i, j2];
                a[i, j2] = temp;
            }

            return a;
        }



        #endregion

        #region search
        delegate int search(double[,] a, int n, int m);
        static int search_diagonal(double[,] a, int n, int m)
        {
            double max = a[0, 0];
            int max_j = 0;

            for (int i = 0; i < n; i++)
            {
                if (a[i, i] > max)
                {
                    max = a[i, i];
                    max_j = i;
                }

            }

            return max_j;
        }

        static int search_first(double[,] a, int n, int m)
        {
            double max = a[0, 0];
            int max_j = 0;

            for (int j = 0; j < m; j++)
            {
                if (a[0, j] > max)
                {
                    max = a[0, j];
                    max_j = j;
                }

            }

            return max_j;
        }

        #endregion

        #region process
        static double[,] process(sort sort, double[,] a, int n_ind, int m)
        {
            double[] cur_row = new double[m];

            for (int j = 0; j < m; j++)
            {
                cur_row[j] = a[n_ind, j];
            }
            cur_row = sort(cur_row, m);

            for (int j = 0; j < m; j++)
            {
                a[n_ind, j] = cur_row[j];
            }
            return a;
        }



        #endregion

        #region sort
        delegate double[] sort(double[] a, int n);
        static double[] sort_desc(double[] a, int n)
        {
            double max;
            int max_i;
            for (int i = 0; i < n; i++)
            {
                max = a[i];
                max_i = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (a[j] > max)
                    {
                        max = a[j];
                        max_i = j;
                    }
                }

                a[max_i] = a[i];
                a[i] = max;
            }

            return a;
        }

        static double[] sort_asc(double[] a, int n)
        {
            double min;
            int min_i;
            for (int i = 0; i < n; i++)
            {
                min = a[i];
                min_i = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (a[j] < min)
                    {
                        min = a[j];
                        min_i = j;
                    }
                }

                a[min_i] = a[i];
                a[i] = min;
            }

            return a;
            #endregion

            
        }
        
    }
}
#endregion