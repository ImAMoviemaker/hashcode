using System;

namespace hashcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            Google g = new Google();
            g.start();

            Console.ReadKey();
        }
    }
}
