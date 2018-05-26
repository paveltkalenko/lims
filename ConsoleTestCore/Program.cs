using System;
using Domain.Services;
namespace ConsoleTestCore
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork UnitOfWork = new UnitOfWork();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
