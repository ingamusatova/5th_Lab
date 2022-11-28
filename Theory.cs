using System;

namespace ConsoleApp10
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("1.1 Ответ:");
            Console.WriteLine($"8: {Cnk(8)}, 10: {Cnk(10)}, 11: {Cnk(11)}");

            Console.WriteLine("1.2 Ответ:");
            Console.WriteLine(CompareTriangles());

            int[] a1 = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
            int[] a2 = new int[8] { 1, 8, 2, 3, 4, 5, 6, 7 };
            int max1 = ArrayMaxId(a1);
            int max2 = ArrayMaxId(a2);
            a1 = ArrayRemoverAtId(a1, max1);
            a2 = ArrayRemoverAtId(a2, max2);
            a1 = UnitArrays(a1, a2);
            Console.WriteLine("2.6 Ответ:");
            for (int i = 0; i < a1.Length; i++)
            {
                Console.Write($"{a1[i]} ");
            }
            Console.WriteLine();
            int[,] matrix = { {1,2,3,4},
                              {1,2,7,4},
                              {1,8,3,4},
                              {1,2,3,4} };
            int[] ids = findColumnsIds(matrix);
            matrix = DeleteColumnFromMatrix(matrix, ids[0], ids[1]);
            Console.WriteLine("2.10 Ответ:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }

            double[,] matrix1 = {{11,3,3,3,-5},
                       {-6,-7,-8,9,10} };
            double[,] matrix2 = {{5,-5,-5,-5,-5},
                       {1,1,-1,-1,-1},};
            double[,] matrixEdit1 = FindMaxes(matrix1);
            double[,] matrixEdit2 = FindMaxes(matrix2);
            Console.WriteLine("2.23 Ответ:");
            showDoubleMatrix(matrixEdit1);
            Console.WriteLine();
            showDoubleMatrix(matrixEdit2);
            double aa1 = 0.1, bb1 = 1, hh1 = 0.1, aa2 = Math.PI / 5, bb2 = Math.PI, hh2 = Math.PI / 25;
            Console.WriteLine("3.1 Ответ:");
            Console.WriteLine($"{1 + Sum(f1, aa1, bb1, hh1)}");
            Console.WriteLine($"{Sum(f2, aa2, bb2, hh2)}");
            int[,] matrixTypes = { {1,2,3,4,5},
                                   {5,4,3,2,1},
                                   {6,7,8,9,10},
                                   {10,9,8,7,6} };
            int[] row = new int[matrixTypes.GetLength(1)];
            fdRow type;
            for (int i = 0; i < matrixTypes.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTypes.GetLength(1); j++)
                {
                    row[j] = matrixTypes[i, j];
                }
                if ((i + 1) % 2 == 0)
                {
                    type = fRowEven;
                }
                else
                {
                    type = fRowNotEven;
                }
                row = type(row);
                for (int j = 0; j < matrixTypes.GetLength(1); j++)
                {
                    matrixTypes[i, j] = row[j];
                }
            }
            Console.WriteLine("3.2 Ответ:");
            for (int i = 0; i < matrixTypes.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTypes.GetLength(1); j++)
                {
                    Console.Write(matrixTypes[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        delegate int[] fdRow(int[] row);

        static int[] fRowEven(int[] row)
        {
            int sortIndex = 0;
            int temp = 0;
            while (sortIndex < row.Length)
            {
                if (sortIndex == 0 || row[sortIndex] >= row[sortIndex - 1])
                {
                    sortIndex++;
                }
                else
                {
                    temp = row[sortIndex];
                    row[sortIndex] = row[sortIndex - 1];
                    row[sortIndex - 1] = temp;
                    sortIndex--;
                }
            }
            return row;
        }

        static int[] fRowNotEven(int[] row)
        {
            int sortIndex = 0;
            int temp = 0;
            while (sortIndex < row.Length)
            {
                if (sortIndex == 0 || row[sortIndex] <= row[sortIndex - 1])
                {
                    sortIndex++;
                }
                else
                {
                    temp = row[sortIndex];
                    row[sortIndex] = row[sortIndex - 1];
                    row[sortIndex - 1] = temp;
                    sortIndex--;
                }
            }
            return row;
        }
        static void showDoubleMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        static int Fact(int num)
        {
            int result = 1;
            while (num > 1)
            {
                result *= num;
                num = num - 1;
            }
            return result;
        }

        static int Cnk(int n)
        {
            return (Fact(n) / (Fact(n - 5) * Fact(5)));
        }

        static double p(int a1, int a2, int a3)
        {
            return (a1 + a2 + a3) / 2;
        }

        static double s(double p1, int a1, int a2, int a3)
        {
            return Math.Sqrt(p1 * (p1 - a1) * (p1 - a2) * (p1 - a3));
        }

        static bool checkTriangle(int a1, int a2, int a3)
        {
            if (a1+a2 > a3 && a1+a3>a2)
            {
                return true;
            }
            return false;
        }
        static String CompareTriangles(int a1 = 3, int a2 = 3, int a3 = 3, int b1 = 5, int b2 = 6, int b3 = 7)
        {
            if (checkTriangle(a1,a2,a3) && checkTriangle(b1,b2,b3)) {
                double p1 = p(a1, a2, a3);
                double p2 = p(b1, b2, b3);
                double s1 = s(p1, a1, a2, a3);
                double s2 = s(p2, b1, b2, b3);
                if (s1 == s2)
                {
                    return "equals";
                }
                else if (s1 > s2)
                {
                    return "s1>s2";
                }
                else
                {
                    return "s1<s2";
                }
            }
            return "error";
        }

        static int ArrayMaxId(int[] arr)
        {
            int max = arr[0];
            int maxi = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxi = i;
                }
            }
            return maxi;
        }
        static int[] ArrayRemoverAtId(int[] arr, int id)
        {
            int[] resultArr = new int[arr.Length - 1];
            int c = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != id)
                {
                    resultArr[c] = arr[i];
                    c++;
                }
            }

            return resultArr;
        }

        static int[] UnitArrays(int[] a1, int[] a2)
        {
            int[] resultArr = new int[a1.Length + a2.Length];

            for (int i = 0; i < a1.Length; i++)
            {
                resultArr[i] = a1[i];
            }
            int c = 0;
            for (int i = a1.Length; i < resultArr.Length; i++)
            {
                resultArr[i] = a2[c];
                c++;
            }

            return resultArr;
        }

        static int[] findColumnsIds(int[,] matrix)
        {
            int[] ids = new int[2];
            int c = 0, max = 0, i = 0, maxj = 0, min = matrix[0, matrix.GetLength(0) - 1], minj = matrix.GetLength(0) - 1;
            while (i < matrix.GetLength(0))
            {
                for (int j = 0; j <= i; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxj = j;
                    }
                }
                i++;
            }
            ids[0] = maxj;
            i = 0;
            while (i < matrix.GetLength(0))
            {
                for (int j = matrix.GetLength(0) - 1; j > i; j--)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minj = j;
                    }
                }
                i++;
            }
            ids[1] = minj;
            return ids;
        }

        static int[,] DeleteColumnFromMatrix(int[,] matrix, int jD1, int jD2)
        {
            int c = 0;
            if (jD1!=jD2)
            {
                int[,] resMatrix = new int[matrix.GetLength(0), matrix.GetLength(1) - 2];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    c = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j != jD1 && j != jD2)
                        {
                            resMatrix[i, c] = matrix[i, j];
                            c++;
                        }
                    }
                }

                return resMatrix;
            } else
            {
                int[,] resMatrix = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    c = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j != jD1)
                        {
                            resMatrix[i, c] = matrix[i, j];
                            c++;
                        }
                    }
                }

                return resMatrix;
            }
        }

        static double[,] search(double[,] matrix, int[,] maxes, int c)
        {
            double[,] matrixRes = matrix;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i == maxes[c, 0] && j == maxes[c, 1]) && matrix[i, j] > 0)
                    {
                        matrixRes[i, j] = matrix[i, j] * 2;
                        return matrixRes;
                    }
                    else if ((i == maxes[c, 0] && j == maxes[c, 1]) && matrix[i, j] < 0)
                    {
                        matrixRes[i, j] = matrix[i, j] / 2;
                        return matrixRes;
                    }
                }
            }
            return matrixRes;
        }
        static double[,] FindMaxes(double[,] matrix)
        {
            int arrLength = matrix.GetLength(0) * matrix.GetLength(1);
            double[,] arr = new double[arrLength,3];
            int[,] maxes = new int[5,2];
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    arr[c,0] = matrix[i, j];
                    arr[c, 1] = i;
                    arr[c, 2] = j;
                    c++;
                }
            }

            int sortIndex = 0;
            double temp = 0;
            while (sortIndex < arrLength)
            {
                if (sortIndex == 0 || arr[sortIndex,0] <= arr[sortIndex - 1,0])
                {
                    sortIndex++;
                }
                else
                {
                    temp = arr[sortIndex,0];
                    arr[sortIndex,0] = arr[sortIndex - 1,0];
                    arr[sortIndex - 1,0] = temp;

                    temp = arr[sortIndex, 1];
                    arr[sortIndex, 1] = arr[sortIndex - 1, 1];
                    arr[sortIndex - 1, 1] = temp;

                    temp = arr[sortIndex, 2];
                    arr[sortIndex, 2] = arr[sortIndex - 1, 2];
                    arr[sortIndex - 1, 2] = temp;
                    sortIndex--;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                maxes[i,0] = (int)arr[i,1];
                maxes[i,1] = (int)arr[i, 2];
            }

            double[,] matrixRes = search(matrix, maxes, 0);

            for (int i = 1; i < 5; i++)
            {
                matrixRes = search(matrix, maxes, i);
            }
                    for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrixRes[i,j] == 0 && matrix[i,j] > 0)
                    {
                        matrixRes[i, j] = matrix[i, j] / 2;
                    } else if (matrixRes[i, j] == 0 && matrix[i, j] < 0)
                    {
                        matrixRes[i, j] = matrix[i, j] * 2;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i == maxes[0, 0] && j == maxes[0, 1]) || (i == maxes[1, 0] && j == maxes[1, 1]) || (i == maxes[2, 0] && j == maxes[2, 1]) || (i == maxes[3, 0] && j == maxes[3, 1]) || (i == maxes[4, 0] && j == maxes[4, 1]))
                    {
                        continue;
                    }
                    else if (matrix[i, j] > 0)
                    {
                        matrixRes[i, j] = matrix[i, j] / 2;
                    }
                    else if (matrix[i, j] < 0)
                    {
                        matrixRes[i, j] = matrix[i, j] * 2;

                    }
                }
            }

            return matrixRes;
        }

        delegate double fd(double x, int i);
        static double f1(double x, int i)
        {
            return Math.Cos(i * x) / Fact(i);
        }
        static double f2(double x, int i)
        {
            return Math.Pow(-1, i) * Math.Cos(i * x) / i * i;
        }
        static double Sum(fd f, double a, double b, double h)
        {
            double s = 0;
            int i = 1;
            for (double x = a; x <= b; x = x + h)
            {
                s = s + f(x, i);
                i++;
            }
            return s;
        }
    }
}
