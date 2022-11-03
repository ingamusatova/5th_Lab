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
        static Tuple<double[,], info[], int, int> first_five_fill(info[] max5, double[,] matrix, int n, int m)
        //First five elements of the matrix (They are also max by default, thats why im calling info[] structure)
        {
            int counter = 0, index_i = 0,  index_j = 0;
            while (counter != 5)
            {
                matrix[index_i,index_j] = input(index_i,index_j);
                
                max5[counter].x = matrix[index_i,index_j]; 
                max5[counter].i = index_i;
                max5[counter].j = index_j;

                index_j++;
                if ((index_j % m) == 0)
                {
                    index_j = 0;
                    index_i++;
                }
                counter++;
            }
            return Tuple.Create(matrix, max5, index_i, index_j);
        }
        static void sort_info(info[] max5, int n) //Sorting info[] structure by numbers so we can do fast insert in future
        {
            for (int i = 0; i < n; i++)
            {
                double minim = max5[i].x;
                for (int j = i + 1; j < n; j++)
                {
                    if (minim > max5[j].x)
                    {
                        minim = max5[j].x;
                        info temp = max5[i];
                        max5[i] = max5[j];
                        max5[j] = temp;
                    }
                }
            }
        }
        static void fill_matrix(info[] max5, double[,] matrix, int index_i, int index_j)
        //Heavy algorithm for sure
        {
            for (int i = index_i; i < matrix.GetLength(0); i++)
            {
                for (int j = index_j; j < matrix.GetLength(1); j++) //Iterating through every cell in matrix
                //Notice, that im starting from index_j and index_i variables, cuz it is the last spot from first_five_fill function
                {
                    matrix[i,j] = input(i,j);
                    if (matrix[i,j] > max5[0].x)
                    {
                        max5[0].x = matrix[i,j];
                        max5[0].i = i;
                        max5[0].j = j;
                        for (int ii = 1; ii < 5; ii++) //3rd for, but really fast (O(n=5) ~ Ω(1))
                        {
                            if (max5[ii - 1].x > max5[ii].x)
                            {
                                info tmp = max5[ii];
                                max5[ii] = max5[ii - 1];
                                max5[ii - 1] = tmp;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                index_j = 0;
            }
        }
        static void sort_info_index(info[] max5) //Sorting info[] by i and j index for condition in line 160
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
            int index_i, index_j;
            
            //Function mess
            (matrix_1, max5_1, index_i, index_j) = first_five_fill(max5_1, matrix_1, n_1, m_1);
            sort_info(max5_1, 5);
            fill_matrix(max5_1, matrix_1, index_i, index_j);
            sort_info_index(max5_1);
            
            //Second matrix
            int n_2, m_2;
            (n_2, m_2) = get_nm();

            double[,] matrix_2 = new double[n_1,m_1];
            info[] max5_2 = new info[5];
            int index_i2, index_j2;
            
            (matrix_2, max5_2, index_i2, index_j2) = first_five_fill(max5_1, matrix_2, n_2, m_2);
            sort_info(max5_2, 5);
            fill_matrix(max5_2, matrix_2, index_i2, index_j2);
            sort_info_index(max5_2);

            //Answer output
            print(matrix_1, max5_1, matrix_2, max5_2);
        }
    }
}