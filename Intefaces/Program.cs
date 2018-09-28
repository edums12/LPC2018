using System;

namespace Intefaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrinter printer = PrinterFactory.GetInstance("Daruma");

            Console.WriteLine(printer.Open());
            Console.WriteLine(printer.Print());
            Console.WriteLine(printer.Close());
        }
    }
}
