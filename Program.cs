using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using _4th_Lab;

namespace _5th_Lab
{
    internal class Program
    {
        static int minValue = -1000;
        static int maxValue = 1000;

        static void Main(string[] args)
        {
            //int[,] matrix = new int[3, 3];
            //Matrix.Fill(matrix, -10, 10);
            //Matrix.Print(matrix);
            //Console.WriteLine();

            //int[] index = Matrix.FindMax(matrix);
            //int max = matrix[index[0], index[1]];
            //Console.WriteLine($"max = {max}");
            //index = Matrix.FindSecondaryMax(matrix, max);
            //int sMax = matrix[index[0], index[1]];
            //Console.WriteLine($"sMax = {sMax}");

            //Task1_1();
            //Task1_2();
            //Task2_6();
            //Task2_10();
            Task2_23();
        }

        #region Level1
        #region Task1_1
        static void Task1_1()
        {
            Console.WriteLine($"number of ways {Calculate(8, 5)}");
            Console.WriteLine($"number of ways {Calculate(10, 5)}");
            Console.WriteLine($"number of ways {Calculate(11, 5)}");
        }

        static int Calculate(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        static int Factorial(int n)
        {
            if(n > 0)
            {
                return n * Factorial(n - 1);
            }
            else
            {
                return 1;
            }
        }
        #endregion

        #region Task1_2
        static void Task1_2()
        {
            int a, b, c;
            Console.WriteLine("First triangle");
            InitLengths(out a, out b, out c);
            Triangle triangle1 = new Triangle(a, b, c);

            Console.WriteLine("Second triangle");
            InitLengths(out a, out b, out c);
            Triangle triangle2 = new Triangle(a, b, c);

            if(triangle1.Square > triangle2.Square)
            {
                Console.WriteLine($"the area of the first triangle is larger {triangle1}");
                Console.WriteLine(triangle1);
            }
            else
            {
                Console.WriteLine($"the area of the second triangle is larger {triangle2}");
                Console.WriteLine(triangle2);
            }
        }

        static void InitLengths(out int a, out int b, out int c)
        {
            Console.WriteLine("Enter the 1st side: ");
            int.TryParse(Console.ReadLine(), out a);
            Console.WriteLine("Enter the 2nd side: ");
            int.TryParse(Console.ReadLine(), out b);
            Console.WriteLine("Enter the 3rd side: ");
            int.TryParse(Console.ReadLine(), out c);
        }
        #endregion
        #endregion

        #region Level2
        #region Task2_6
        static void Task2_6()
        {
            int[] arrayA = new int[7];
            Line.Fill(arrayA, minValue, maxValue);
            Line.Print(arrayA);
            Console.WriteLine();

            int[] arrayB = new int[8];
            Line.Fill(arrayB, minValue, maxValue);
            Line.Print(arrayB);
            Console.WriteLine();

            int index = Line.FindMax(arrayA);
            Line.Remove(ref arrayA, index);

            index = Line.FindMax(arrayB);
            Line.Remove(ref arrayB, index);

            arrayA = Line.Concate(arrayA, arrayB);
            Line.Print(arrayA);
        }
        #endregion

        #region Task2_10
        static void Task2_10()
        {
            int rowLength = Matrix.SetLengthRow();
            int[,] matrix = new int[rowLength, rowLength];
            Matrix.Fill(matrix, minValue, maxValue);
            Matrix.Print(matrix);
            Console.WriteLine();

            int max = matrix[0, 0];
            int colNumber1 = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    if(max < matrix[i, j])
                    {
                        max = matrix[i, j];
                        colNumber1 = j;
                    }
                }
            }
            Console.WriteLine($"j = {colNumber1}, max = {max}");

            int min = matrix[0, matrix.GetLength(1) - 1];
            int colNumber2 = matrix.GetLength(1) - 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = matrix.GetLength(1) - 1; j > i; j--)
                {
                    if (min > matrix[i, j])
                    {
                        min = matrix[i, j];
                        colNumber2 = j;
                    }
                }
            }
            Console.WriteLine($"j = {colNumber2}, min = {min}");

            if(colNumber1 < colNumber2)
            {
                colNumber2--;
            }
            Matrix.EraseCol(ref matrix, colNumber1);
            Matrix.EraseCol(ref matrix, colNumber2);

            Matrix.Print(matrix);
        }
        #endregion

        #region Task2_23
        static void Task2_23()
        {
            int rowLength = Matrix.SetLengthRow();
            int colLength = Matrix.SetLengthCol();
            int[,] matrix = new int[rowLength, colLength];
            Matrix.Fill(matrix, -20, 20);
            Matrix.Print(matrix);
            Console.WriteLine();

            int[,] indexes = new int[5, 2];
            int[] buff = Matrix.FindMax(matrix);
            Matrix.SetRow(indexes, buff, 0);

            int max = matrix[buff[0], buff[1]];
            for (int i = 1; i < indexes.GetLength(0); i++)
            {
                buff = Matrix.FindSecondaryMax(matrix, max);
                Matrix.SetRow(indexes, buff, i);
                max = matrix[buff[0], buff[1]];
            }
            Matrix.Print(indexes);
            Console.WriteLine();

            SortIndex(indexes);
            Matrix.Print(indexes);
            Console.WriteLine();

            int external = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (external != indexes.GetLength(0))
                    {
                        if (i == indexes[external, 0] && j == indexes[external, 1])
                        {
                            matrix[i, j] = 2 * matrix[i, j];
                            external++;
                            continue;
                        }
                    }

                    matrix[i, j] = matrix[i, j] / 2;
                }
            }
            Matrix.Print(matrix);
        }

        static void SortIndex(int[,] indexes)
        {
            if(indexes == null)
            {
                Error.Kill();
            }

            for(int n = 0; n < indexes.GetLength(0) - 1; n++)
            {
                for(int i = 0; i < indexes.GetLength(0) - n -1; i++)
                {
                    if ((indexes[i, 0] > indexes[i + 1, 0]))
                    {
                        Swap(ref indexes[i, 0], ref indexes[i + 1, 0]);
                        Swap(ref indexes[i, 1], ref indexes[i + 1, 1]);
                    }

                    if ((indexes[i, 0] == indexes[i + 1, 0]) && (indexes[i, 1] > indexes[i + 1, 1]))
                    {
                        Swap(ref indexes[i, 0], ref indexes[i + 1, 0]);
                        Swap(ref indexes[i, 1], ref indexes[i + 1, 1]);
                    }
                }
            }
        }

        static void Swap(ref int a, ref int b)
        {
            a += b;
            b = a - b;
            a = a - b;
        }
        #endregion
        #endregion
    }
}
