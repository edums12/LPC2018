using System;

namespace ContaBancaria
{
    public class Conta
    {
        public string numero { get; set; }
        public double saldo { get; set; }
        public double limite { get; }
        public Cliente cliente { get; }

        public Conta(Cliente cliente)
        {
            this.gerarNumeroConta();
            this.saldo = 0;
            this.limite = 100;
            this.cliente = cliente;
        }
        public Conta(Cliente cliente, double saldo)
        {
            this.gerarNumeroConta();
            this.saldo = saldo;
            this.limite = 100;
            this.cliente = cliente;
        }
        public Conta(Cliente cliente, double saldo, double limite)
        {
            this.gerarNumeroConta();
            this.saldo = saldo;
            this.limite = limite;
            this.cliente = cliente;
        }

        private void gerarNumeroConta()
        {
            Random rand = new Random();
            for(int i = 0; i < 8; i++)
            {
                this.numero += (rand.Next(0, 9) + 1).ToString();
            }
        }
    
        public string exibir()
        {
            // Consulta saldo tbm
            return string.Format(
                "//CONTA//\nNº da Conta: {0}\nNome do Cliente: {1}\nSaldo: {2}\nLimite:{3}\n",
                this.numero,
                this.cliente.nome,
                this.saldo.ToString(),
                this.limite.ToString()
            );
        }

        public bool sacar(double valor)
        {
            if(valor <= this.saldo && valor <= this.limite)
            {
                this.saldo -= valor;
                return true;
            }

            return false;
        }

        public bool transferir(Conta origem, Conta destino, double valor)
        {
            if(origem.sacar(valor))
            {
                destino.saldo += valor;

                return true;
            }

            return false;
        }

    }
}