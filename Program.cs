using System;

namespace _5th_Lab
{
    class Program
    {
        static int PolymorphMethod() { return 0; }
        static int PolymorphMethod(int number) { return number; }
        static int PolymorphMethod(double anotherNumber) { return (int)anotherNumber; }
        static int PolymorphMethod<T>(T yourType) { return yourType.GetHashCode(); } // general type

        //     static T PolymorphMethod<T>(T yourType) { return number; } - cannot create since there is method with same input params
        static double PolymorphMethod(int count, double[] array) 
        {
            var sum = 0.0;
            foreach(double value in array)
            {
                sum += value;
            }
            return sum + count;
        }

        static bool Compare(int left, int right) => left > right; // => it is lambda operator the same as { return }
        static bool Compare(double left, double right) => left > right;

        static void Main(string[] args)
        {
            #region OOP principles

            /* You operation mith moduls. Modul can work with data he get or keep inside. 
             * Moduls of higher lvl hould not know about lower ones.
             * So your code will be safe and logical.
             * 
             * 
             * What are you need?
             * 
             * Abstraction - noone shuld know HOW another modul (class / method) works.
             * You have to provide input value and get the output.
             * User interface shouldn't affect on the system's work.
             * Also realization should not change the pattern (abstract scheme)
             * 
             * Encapsulation - do not provide more than asked.
             * Another class or method shouldn't know about any field or method in your object (class, structure and so on) except you provide to it.
             * Group your data in a single object. One object (entity) should know and do only that things that incuded or were gotten outside.
             * 
             * Inheritance - Inheritance is the method of acquiring features of the existing class into the new class with additional properties or methods.
             * Also it is allow us to reach better incapsulation (up-cast).
             * Inheritance can be from 1 to many (classes / interfaces) or from many to one (interfaces only). 
             * So we can create an object (entity) with such properties we need and agregate in with another objects that have the same property.
             * 
             * Polymorphism - the most essential concept which allow any object or method has more than one name associated with it. And it allow your code be more flexible.
             * Difference can be in the type it use, parameters it get.
             * 
             * In that lab you will have an acquaintance with polymorphism
             * 
             */

            Console.WriteLine(PolymorphMethod());

            Console.WriteLine(PolymorphMethod(10));

            Console.WriteLine(PolymorphMethod(2.56));

            Console.WriteLine(PolymorphMethod("Abracadabra")); // general type will be called, because no another method that suit to this type

            Console.WriteLine(PolymorphMethod(5, new []{ 0.1223, 1.2, 8.9, -1.5 }));

            #endregion

            #region DRY - don't repeat yourself

            /* Very simple advice :)
             * You already did it, using cycle, for example instead maing calculation on each line
             * 
             * If you see that in your program is repeat, make a separate method and call it when it needs.
             */

            int numerator = 1, denominator = 1;


            double sum = 0, average = 0;

            if (numerator > denominator)
            {
                Console.WriteLine(true);
            }    
            else
            {
                Console.WriteLine(false);
            }

            if (sum > average)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }

            // Carry out the logic (DRY + Incapsilation + Polymorphism in such small example)) - look in the head of program
            Compare(numerator, denominator);
            Compare(sum, average);

            #endregion

            #region SOLID principles

            /* single responsibility, open–closed, Liskov substitution, interface segregation и dependency inversion
             * 
             * S - Each class should keep everithing he need for work inside itself.
             * O - Your program should be open for extentions but closed for changes. It is very difficlt to reach it, actually.
             * L - Heirs should be able to use father's metods.
             * I - Separate your program to interfaces and provide only what need in particular cases.
             * D - One object shouldn't to talk another at the same level what to do. Use actions instead.
             */

            // We will work with SOLID closely at 7-8 & 10th labs.

            #endregion
        }
    }
}
