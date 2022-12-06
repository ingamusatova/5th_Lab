using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _5th_Lab
{
    internal class Triangle
    {
        int a;
        public int A
        {
            get
            {
                return a;
            }

            set
            {
                if(a > 0)
                {
                    a = value;
                }
                else
                {
                    while(value < 0)
                    {
                        Console.WriteLine("enter a value");
                        int.TryParse(Console.ReadLine(), out value);
                    }
                    a = value;
                }
            }
        }

        int b;
        public int B
        {
            get
            {
                return b;
            }

            set
            {
                if(b > 0)
                {
                    b = value;
                }
                else
                {
                    while (value < 0)
                    {
                        Console.WriteLine("enter a value");
                        int.TryParse(Console.ReadLine(), out value);
                    }
                    b = value;
                }
            }
        }

        int c;
        public int C
        {
            get
            {
                return c;
            }

            set
            {
                if (c > 0)
                {
                    c = value;
                }
                else
                {
                    while (value < 0)
                    {
                        Console.WriteLine("enter a value");
                        int.TryParse(Console.ReadLine(), out value);
                    }
                    c = value;
                }
            }
        }

        public double Perimetr
        {
            get;
        }

        public double Square
        {
            get;
        }

        public Triangle(int a, int b, int c)
        {
            if (!Exist(a, b, c))
            {
                Console.WriteLine("this triangle does not exist");
                Error.Kill();
            }

            this.a = a;
            this.b = b;
            this.c = c;

            Perimetr = a + b + c;
            Square = Math.Abs(Perimetr * (Perimetr - a) * (Perimetr - b) * (Perimetr - c));
        }

        private bool Exist(int a, int b, int c)
        {
            if (a + b > c)
                return true;
            if (a + c > b)
                return true;
            if (b + c > a)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return $"Triangle: a = {a}, b = {b}, c = {c}";
        }
    }
}
