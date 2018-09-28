using System;

namespace Intefaces
{
    public class PrinterFactory
    {
        public static IPrinter GetInstance(string marca)
        {
            switch (marca)
            {
                case "Daruma":
                    return new Daruma();

                default:
                    throw new Exception("Impressora não implementada");
            }
        }
    }
}