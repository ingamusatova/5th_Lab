using System;

namespace LaboratoryL2N23
{
    class Program
    {
        struct info //Info about max element matrix
        {
            public double x; //Number
            public int i;
            public int j; //Place in matrix
        }
        static double input(int i, int j) //For array elements
        {
            Console.Write($"Index_[{i}][{j}]: ");
            string input_x = Console.ReadLine();
            if (!double.TryParse(input_x, out var n))
            {
                Console.WriteLine("Invalid input");
                System.Environment.Exit(1);
            }
            return n;
        }
        static Tuple<int,int> get_nm() //Size of the matrix
        {
            int n = input_int();
            int m = input_int();
            if (n * m < 5)
            {
                Console.WriteLine("Less than 5 elements in the matrix is prohibited");
                System.Environment.Exit(1);
            }
            return Tuple.Create(n,m);
        }
        static int input_int() //Int input for size
        {
            Console.Write($"Size: ");
            string input_x = Console.ReadLine();
            if (!int.TryParse(input_x, out var n))
            {
                Console.WriteLine("Invalid input");
                System.Environment.Exit(1);
            }
            return n;
        }
        static void fill_matrix(double[,] matrix, double[] array, int n, int m)
        {
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i,j] = input(i,j);
                    array[k] = matrix[i,j];
                    k++;
                }
            }
        }
        static void fill_info(info[] max_5, double[] array, int n, int m)
        {
            int k = 0;
            int size = n*m;
            int[] index = new int[n*m];
            for (int i = 0; i < size; i++)
            {
                index[i] = i;
            }

            for (int i = 0; i < size; i++)
            {
                double maxim = array[i];
                int temp_index = index[i];
                for (int j = i+1; j < size; j++)
                {
                    if (array[j] > maxim)
                    {
                        maxim = array[j];
                        array[j] = array[i];
                        array[i] = maxim;
                        temp_index = index[j];
                        index[j] = index[i];
                        index[i] = temp_index;
                    }
                }
                max_5[k].x = maxim;
                max_5[k].i = temp_index / m;
                max_5[k].j = temp_index % m;
                k++;
                if (k == 5)
                {
                    break;
                }
            }
        }
        static void sort_info_index(info[] max5)
        {
            for (int i = 0; i < 5; i++)
            {
                int minim = max5[i].i;
                for (int j = i + 1; j < 5; j++)
                {
                    if (minim > max5[j].i)
                    {
                        minim = max5[j].i;
                        info temp = max5[i];
                        max5[i] = max5[j];
                        max5[j] = temp;
                    }
                    if (minim == max5[j].i && max5[i].j > max5[j].j)
                    {
                        info temp = max5[i];
                        max5[i] = max5[j];
                        max5[j] = temp;
                    }
                }
            }
        }
        static void printMatrix(double[,] matrix, info[] max, int n) //Literally
        {
            Console.WriteLine($"Array {n} before");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Array {n} After");
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (max[counter%5].i == i && max[counter%5].j == j)
                    {
                        if (matrix[i,j] >= 0)
                        {
                            Console.Write($"{matrix[i,j] * 2} ");
                            counter++;
                        }
                        else 
                        //For negative numbers (-4 -> -2)
                        {
                            Console.Write($"{matrix[i,j] / 2} ");
                            counter++;
                        }
                    }
                    else
                    {
                        if (matrix[i,j] >= 0)
                        {
                            Console.Write($"{matrix[i,j] / 2} ");
                        }
                        else
                        //For negative numbers (-4 -> -8)
                        {
                            Console.Write($"{matrix[i,j] * 2} ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        static void print(double[,] matrix_1, info[] max1, double[,] matrix_2, info[] max2)
        {
            printMatrix(matrix_1, max1, 1);
            printMatrix(matrix_2, max2, 2);
        }
        static void Main(string[] args)
        {
            //First matrix
            int n_1, m_1;
            (n_1, m_1) = get_nm();

            double[,] matrix_1 = new double[n_1,m_1];
            info[] max5_1 = new info[5];
            double[] array_1 = new double[n_1 * m_1];
            
            
            //Function mess
            fill_matrix(matrix_1, array_1, n_1, m_1);
            fill_info(max5_1, array_1, n_1, m_1);
            sort_info_index(max5_1);

            
            //Second matrix
            int n_2, m_2;
            (n_2, m_2) = get_nm();

            double[,] matrix_2 = new double[n_2, m_2];
            info[] max5_2 = new info[5];
            double[] array_2 = new double[n_2 * m_2];

            //Functions
            fill_matrix(matrix_2, array_2, n_2, m_2);
            fill_info(max5_2, array_2, n_2, m_2);
            sort_info_index(max5_2);


            //Answer output
            print(matrix_1, max5_1, matrix_2, max5_2);
        }
    }
}