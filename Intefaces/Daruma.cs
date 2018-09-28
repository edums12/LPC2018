namespace Intefaces
{
    public class Daruma : IPrinter
    {
        public string Close()
        {
            return "A impressora fechou";
        }

        public string Open()
        {
            return "A impressora abriu";
        }

        public string Print()
        {
            return "Imprimir";
        }
    }
}