using System;

namespace ContaBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Agencia agencia = new Agencia("01");
            Console.WriteLine(agencia.exibir());

            Agencia agencia02 = new Agencia();
            Console.WriteLine(agencia02.exibir());

            Cliente ClienteEduardo = new Cliente(1, "Eduardo");
            Cliente ClienteFulano = new Cliente(2, "Fulano");

            Console.WriteLine(ClienteEduardo.exibir());
            Console.WriteLine(ClienteFulano.exibir());

            CartaoCredito CartaoCreditoEduardo = new CartaoCredito(ClienteEduardo);

            Console.WriteLine(CartaoCreditoEduardo.exibir());

            Conta ContaBancaria = new Conta(ClienteEduardo, 100, 1500);
            Console.WriteLine(ContaBancaria.exibir());

            ContaBancaria.sacar(50);
            Console.WriteLine(ContaBancaria.exibir());
        }
    }
}
