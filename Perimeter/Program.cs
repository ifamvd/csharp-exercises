using System;

namespace Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            // user input height
            Console.WriteLine("Type in the height: ");
            string height = Console.ReadLine();
            // user input width
            Console.WriteLine("Type in the width: ");
            string width = Console.ReadLine();
            // calculate perimeter
            double perimeter = CalculatePerimeter(height, width);
            // print out perimeter
            Console.WriteLine(perimeter);
            Console.ReadLine();
        }

        private static double CalculatePerimeter(string height, string width)
        {
            return double.Parse(height) * 2 + double.Parse(width) * 2;
        }
    }
}
