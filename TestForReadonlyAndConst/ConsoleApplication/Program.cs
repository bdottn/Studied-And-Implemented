using ConsoleApplicationClassLibrary;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int ni = ConstantClass.BeginNumber; ni < ConstantClass.EndNumber; ni++)
            {
                Console.WriteLine(ni);
            }
            Console.ReadKey();
        }
    }
}