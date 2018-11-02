using System;

namespace Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double pi = 3.14;
            Console.Write("Enter a radius: ");
            double r = 0.0;
            double.TryParse(Console.ReadLine(), out r);
            double area = pi * r * r;
            Console.WriteLine("The area of a circle with radius " + r + " is: " + area);
            Console.ReadLine();
        }
    }
}
