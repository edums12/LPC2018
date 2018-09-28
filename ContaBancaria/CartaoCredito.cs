using System;

namespace ContaBancaria
{
    public class CartaoCredito
    {
        public string numero { get; }
        public string dataValidade { get; }
        public Cliente cliente { get; }

        public CartaoCredito(Cliente cliente){
            this.cliente = cliente;

            var rand = new Random();

            for(int i = 0; i < 9; i++)
            {
                this.numero += (rand.Next(0, 9) + 1).ToString();
            }

            var dia = rand.Next(1, 31);
            var mes = rand.Next(1, 13);
            var ano = rand.Next(2020, 2025);

            this.dataValidade = 
                string.Format(
                    "{0}/{1}/{2}",
                    dia.ToString("00"),
                    mes.ToString("00"),
                    ano.ToString("00")
                );
        }

        public string exibir()
        {
            return string.Format(
                "//Cartão de crédito//\nNúmero:{0}\nData de validade: {1}\nNome do cliente: {2}\n",
                this.numero,
                this.dataValidade,
                this.cliente.nome
            );
        }
    }
}